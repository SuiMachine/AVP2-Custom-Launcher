#include <Windows.h>
#include "Functions.h"
#include "Main.h"
#include <math.h>

static DWORD cshellAddress = 0x0;
static DWORD baseAddress = (DWORD)0x00400000;
static float aspectRatio = 1.337f;
static DWORD resolutionX = 1024;
static DWORD resolutionY = 768;
static DWORD verticalRadians = 0;
static DWORD horizontalRadians = 0;


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
DWORD jmpViewmodelAddress;
float horizontalRadiansF;
float viewmodelFOVRadians;
bool d3drenHooked = false;

static float increaseHorFOV()
{
	float tempVradian = 2 * atanf(tanf(horizontalRadiansF / 2.0f) * 0.75f);
	return (2.0f * atanf(tanf(tempVradian / 2.0f) * aspectRatio));
}

static float modifyViewmodels(float val)
{
	float tempVradian = 2 * atanf(tanf(val / 2.0f) * ((float)resolutionY / resolutionX));
	return (2.0f * atanf(tanf(tempVradian / 2.0f) * 1.333333f));
}

void __declspec(naked) fovHack()
{
	/*
	lithtech.exe+B7E1 - 25 00410000           - and eax,00004100 { 16640 }
	lithtech.exe+B7E6 - 75 08                 - jne lithtech.exe+B7F0
	lithtech.exe+B7E8 - DDD8                  - fstp st(0)
	lithtech.exe+B7EA - D9 05 186B4C00        - fld dword ptr [lithtech.exe+C6B18] { [6.25] }
	lithtech.exe+B7F0 - 8B 44 24 08           - mov eax,[esp+08]
	lithtech.exe+B7F4 - D9 99 C4010000        - fstp dword ptr [ecx+000001C4]
	lithtech.exe+B7FA - 89 81 C0010000        - mov [ecx+000001C0],eax
	lithtech.exe+B800 - C3                    - ret {to cshell.dll +602B8}
	*/

	__asm
	{
		fstp dword ptr[ecx + 0x000001C4]
		push ebx
		push ecx
		push edx
		push esi
		push edi
		push esp
		push ebp
		mov horizontalRadiansF, eax
	}
	horizontalRadiansF = increaseHorFOV();

	__asm
	{
		pop ebp
		pop esp
		pop edi
		pop esi
		pop edx
		pop ecx
		pop ebx
		mov eax, horizontalRadiansF
		mov[ecx + 0x000001C0], eax
		jmp[jmpFovAddress]
	}
}

void __declspec(naked) viewModelFOV()
{
	/*
	d3d.ren+FA4C - D8 2D B8628004        - fsubr dword ptr [d3d.ren+462B8] { [3.14] }
	d3d.ren+FA52 - D9 5B 4C              - fstp dword ptr [ebx+4C]  <- this
	d3d.ren+FA55 - D9 83 98000000        - fld dword ptr [ebx+00000098]
	*/

	__asm
	{
		fstp [viewmodelFOVRadians]
		push eax
		push ebx
		push ecx
		push edx
		push esi
		push edi
		push esp
		push ebp
	}

	viewmodelFOVRadians = modifyViewmodels(viewmodelFOVRadians);
	viewmodelFOVRadians = modifyViewmodels(viewmodelFOVRadians);

	__asm
	{
		pop ebp
		pop esp
		pop edi
		pop esi
		pop edx
		pop ecx
		pop ebx
		pop eax
		fld dword ptr[viewmodelFOVRadians]
		fstp dword ptr[ebx + 0x4C]
		fld dword ptr[ebx + 0x00000098]
		jmp[jmpViewmodelAddress]
	}
}

void __declspec(naked) resHack()
{
	__asm
	{
		mov eax, resolutionX
		mov ecx, resolutionY
		jmp[jmpResAddress]
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

	//FOV hack
	{
		//Overriding:
		//fstp dword ptr [ecx+000001C4]	- 6 OP bytes
		//mov [ecx+000001C0],eax		- 6 OP bytes
		int hookLenght = 12;
		DWORD hookAddress = baseAddress + 0xB7F4; 		//Solve address = "lithtech.exe"+B7F4
		jmpFovAddress = hookAddress + hookLenght;
		Hook((void*)hookAddress, fovHack, hookLenght);
	}

	while (true)
	{
		aspectRatio = (float)(1.0 * resolutionX / resolutionY);
		MODULEINFO d3dren = GetModuleInfo("d3d.ren");
		if (d3dren.lpBaseOfDll == 0x0)
		{
			d3drenHooked = false;
		}
		else if (!d3drenHooked)
		{
			#ifdef _DEBUG
			OutputDebugString("d3dRenHooked");
			#endif // DEBUG

			//ViewModel hack
			//Overriding:
			//fstp dword ptr [ebx+4C]
			//fld dword ptr[ebx + 00000098]
			int hookLenght = 9;
			DWORD hookAddress = (DWORD)d3dren.lpBaseOfDll + 0xFA52; //SolveAddress = d3d.ren +FA52
			jmpViewmodelAddress = hookAddress + hookLenght;
			Hook((void*)hookAddress, viewModelFOV, hookLenght);
			d3drenHooked = true;
		}
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