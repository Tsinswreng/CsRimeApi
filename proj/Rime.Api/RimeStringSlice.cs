using System.Runtime.InteropServices;
using Tsinswreng.CsInterop;

namespace Rime.Api;

[StructLayout(LayoutKind.Sequential)]
unsafe public struct RimeStringSlice{
	public byte* str;// const char
	public size_t length;
}
