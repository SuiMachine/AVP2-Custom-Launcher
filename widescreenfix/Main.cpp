#include <Windows.h>

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

DWORD jmpBackAddress;

void __declspec(naked) ourFunct()
{
	/*
	[ENABLE]
//code from here to '[DISABLE]' will be used to enable the cheat
alloc(newmem,2048)
label(resx)
registersymbol(resx)
label(resy)
registersymbol(resy)
label(returnhere)
label(code)
label(exit)

newmem: //this is allocated memory, you have read,write,execute access
//place your code here
resx:
dd (int)1280
resy:
dd (int)720

code:
mov eax,[resx]
mov ecx,[resy]

exit:
jmp returnhere

"cshell.dll"+E389:
jmp code
returnhere:


 
 
[DISABLE]
//code from here till the end of the code will be used to disable the cheat
unregistersymbol(resx)
unregistersymbol(resy)
dealloc(newmem)
"cshell.dll"+E389:
mov eax,[edx]
mov ecx,[edx+04]
//Alt: db 8B 02 8B 4A 04*/
	__asm 
	{
		jmp [jmpBackAddress]
	}
}

DWORD WINAPI MainThread(LPVOID param)
{
	int hookLenght = 0;
	DWORD hookAddress = 0x0;
	jmpBackAddress = hookAddress + hookLenght;

	Hook((void*)hookAddress, ourFunct, hookLenght);

	while (true)
	{
		Sleep(50);
	}
}

BOOL WINAPI DllMain(HINSTANCE hModule, DWORD dwReason, LPVOID lpReserved)
{
	switch (dwReason)
	{
		case DLL_PROCESS_ATTACH:
			CreateThread(0, 0, MainThread, hModule, 0, 0);
			break;
	}

	return true;
}
