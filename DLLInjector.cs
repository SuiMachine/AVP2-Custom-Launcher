﻿//This class was written by evolution536 for UnknownCheats
//Gotta give credit, where credit is due, although reading that code, I could probably re-write it.
//It's just, I'm lazy.

using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace AVP_CustomLauncher
{
	public enum DllInjectionResult
	{
		DllNotFound,
		GameProcessNotFound,
		InjectionFailed,
		Success
	}

	public sealed class DllInjector
	{
		static readonly IntPtr INTPTR_ZERO = (IntPtr)0;

		[DllImport("kernel32.dll", SetLastError = true)]
		static extern IntPtr OpenProcess(uint dwDesiredAccess, int bInheritHandle, uint dwProcessId);

		[DllImport("kernel32.dll", SetLastError = true)]
		static extern int CloseHandle(IntPtr hObject);

		[DllImport("kernel32.dll", SetLastError = true)]
		static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

		[DllImport("kernel32.dll", SetLastError = true)]
		static extern IntPtr GetModuleHandle(string lpModuleName);

		[DllImport("kernel32.dll", SetLastError = true)]
		static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, IntPtr dwSize, uint flAllocationType, uint flProtect);

		[DllImport("kernel32.dll", SetLastError = true)]
		static extern int WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] buffer, uint size, int lpNumberOfBytesWritten);

		[DllImport("kernel32.dll", SetLastError = true)]
		static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttribute, IntPtr dwStackSize, IntPtr lpStartAddress,
			IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

		static DllInjector _instance;

		public static DllInjector GetInstance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new DllInjector();
				}
				return _instance;
			}
		}

		DllInjector() { }

		public DllInjectionResult Inject(Process[] _procs, string sDllPath)
		{
			if (!File.Exists(sDllPath))
			{
				return DllInjectionResult.DllNotFound;
			}

			uint _procId = 0;


			_procId = (uint)_procs[0].Id;

			if (_procId == 0)
			{
				return DllInjectionResult.GameProcessNotFound;
			}

			if (!bInject(_procId, sDllPath))
			{
				return DllInjectionResult.InjectionFailed;
			}

			return DllInjectionResult.Success;
		}

		bool bInject(uint pToBeInjected, string sDllPath)
		{
			IntPtr hndProc = OpenProcess((0x2 | 0x8 | 0x10 | 0x20 | 0x400), 1, pToBeInjected);

			if (hndProc == INTPTR_ZERO)
			{
				return false;
			}

			IntPtr lpLLAddress = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");

			if (lpLLAddress == INTPTR_ZERO)
			{
				return false;
			}

			IntPtr lpAddress = VirtualAllocEx(hndProc, (IntPtr)null, (IntPtr)sDllPath.Length, (0x1000 | 0x2000), 0X40);

			if (lpAddress == INTPTR_ZERO)
			{
				return false;
			}

			byte[] bytes = Encoding.ASCII.GetBytes(sDllPath);

			if (WriteProcessMemory(hndProc, lpAddress, bytes, (uint)bytes.Length, 0) == 0)
			{
				return false;
			}

			if (CreateRemoteThread(hndProc, (IntPtr)null, INTPTR_ZERO, lpLLAddress, lpAddress, 0, (IntPtr)null) == INTPTR_ZERO)
			{
				return false;
			}

			CloseHandle(hndProc);

			return true;
		}
	}
}