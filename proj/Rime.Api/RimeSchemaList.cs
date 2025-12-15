using System.Runtime.InteropServices;
using Tsinswreng.CsInterop;

namespace Rime.Api;

[StructLayout(LayoutKind.Sequential)]
unsafe public struct RimeSchemaList{
	public size_t size;
	public RimeSchemaListItem* list;
}
