namespace Rime.Api;

using System.Runtime.InteropServices;
using Tsinswreng.CsInterop;

//懶得寫 delegate* unmanaged 了
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
unsafe public delegate RimeApi* rime_get_api();

unsafe public class RimeDllLoader{
	//TODO test
	public static rime_get_api loadFn_rime_get_api(str dllPath){
		var dllPtr = NativeLibrary.Load(dllPath);
		var fnPtr = NativeLibrary.GetExport(dllPtr, nameof(rime_get_api));
		var ans = fnPtr.AsFn<rime_get_api>();
		return ans;
	}
}
