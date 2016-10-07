#pragma once

#include <iostream>
#include <Windows.h>
#include <TlHelp32.h>
#include <Psapi.h>

void debugMsgBoxAddress(DWORD addr)
{
	char szBuffer[1024];
	sprintf_s(szBuffer, "Address: %02x", addr);
	MessageBox(NULL, szBuffer, "Title", MB_OK);
}

void PlaceJMP(BYTE *Address, DWORD jumpTo, DWORD lenght)
{
	DWORD dwOldProtectionFlag, dwBkup, dwRealAddress;

	VirtualProtect(Address, lenght, PAGE_EXECUTE_READWRITE, &dwOldProtectionFlag);
	dwRealAddress = (DWORD)(jumpTo - (DWORD)Address) - 5;
	*Address = 0xE9;
	*((DWORD *)(Address + 0x1)) = dwRealAddress;

	for (DWORD x = 0x5; x < lenght; x++)
	{
		*(Address + x) = 0x90;
	}

	VirtualProtect(Address, lenght, dwOldProtectionFlag, &dwBkup);
}

MODULEINFO GetModuleInfo(char * moduleName)
{
	MODULEINFO modInfo = { 0 };
	HMODULE hModule = GetModuleHandle(moduleName);

	if (hModule == 0)
		return modInfo;

	GetModuleInformation(GetCurrentProcess(), hModule, &modInfo, sizeof(MODULEINFO));
	return modInfo;
}

DWORD GetBaseAddressForModuleInfo(char * moduleName)
{
	MODULEINFO modInfo = { 0 };
	HMODULE hModule = GetModuleHandle(moduleName);

	if (hModule == 0)
		return (DWORD)0;

	GetModuleInformation(GetCurrentProcess(), hModule, &modInfo, sizeof(MODULEINFO));
	return (DWORD)modInfo.lpBaseOfDll;
}