#include <Windows.h>
#include "Functions.h"
#include "Main.h"

static DWORD cshellAddress = 0x0;
//static float aspectRatio = 1.333;
static DWORD resolutionX = 1024;
static DWORD resolutionY = 768;

bool Hook(void * toHook, void * ourFunction, int lenght)
{
	if (lenght < 5)
		return false;

	DWORD curProtectionFlag;
	VirtualProtect(toHook, lenght, PAGE_EXECUTE_READWRITE, &curProtectionFlag);
	memset(toHook, 0x90, lenght);
	DWORD relativeAddress = ((DWORD)ourFunction - (DWORD)toHook) - 5;

	*(BYTE*)toHook = 0xE9;
	*(DWORD*)((DWORD)toHook + 1) = relativeAddress;
	
	DWORD temp;
	VirtualProtect(toHook, lenght, curProtectionFlag, &temp);
	return true;
}

DWORD jmpResAddress;
DWORD jmpFovAddress;

void __declspec(naked) fovHack()
{
	//DisplayFOV
	//Start at: d3d.ren+FA52
	//Ends at: d3d.ren+FA71
	//TODO: Write the corrected FOV function

	__asm
	{
		mov eax, resolutionX
		mov ecx, resolutionY
		jmp[jmpResAddress]
	}
}

void __declspec(naked) resHack()
{
	__asm 
	{
		mov eax, resolutionX
		mov ecx, resolutionY
		jmp [jmpResAddress]
	}
}

bool rendererHooked = false;
DWORD rendererModuleAddress = 0x0;
void periodicCheck()
{
	DWORD address = GetBaseAddressForModuleInfo("d3d.ren");
	if (address != rendererModuleAddress)
	{
		//I have no idea why I wrote this like this...
		rendererModuleAddress = address;

		//This I know however - base address is 0, it means the d3d.ren got deallocated, needs to be rehooked.
		if (address == 0x0)
			rendererHooked = false;
		else
		{
			//Module was found, if it needs to be rehooked - do that. Set flag to true either way
			if (!rendererHooked)
			{
				int hookLenght = 0x5;
				DWORD hookAddress = rendererModuleAddress + 0xFA52;
				Hook((void*)hookAddress, fovHack, hookLenght);
			}

			rendererHooked = true;
		}
	}
}



DWORD WINAPI HookThread(LPVOID param)
{
	MODULEINFO cshell = GetModuleInfo("cshell.dll");
	cshellAddress = (DWORD)cshell.lpBaseOfDll;

	//Resolution Hooking
	{
		//Overriding:
		//mov eax,[edx]       - 2 OP bytes
		//mov ecx,[edx + 04]  - 3 OP bytes
		int hookLenght = 0x5;
		DWORD hookAddress = cshellAddress+0xE389; 		//Solve address = "cshell.dll"+E389
		jmpResAddress = hookAddress + hookLenght;
		Hook((void*)hookAddress, resHack, hookLenght);
	}

	while (true)
	{
		periodicCheck();
		Sleep(400);
	}
}

BOOL WINAPI DllMain(HINSTANCE hModule, DWORD dwReason, LPVOID lpReserved)
{
	//starts from here
	switch (dwReason)
	{
		case DLL_PROCESS_ATTACH:
			CreateThread(0, 0, HookThread, hModule, 0, 0);
			break;
	}

	return true;
}