using System.Runtime.InteropServices;

namespace Rime.Api;

// [DllImport(DllPath,EntryPoint = nameof(rime_get_api),CallingConvention = CallingConvention.Cdecl)]
// 	public static extern RimeApi* rime_get_api();

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
unsafe public delegate RimeApi* rime_get_api();


unsafe public class RimeDllLoader{
	//TODO test
	public static rime_get_api loadFn_rime_get_api(str dllPath){
		var dllPtr = NativeLibrary.Load(dllPath);
		var fnPtr = NativeLibrary.GetExport(dllPtr, nameof(rime_get_api));
		var ans = fnPtr.asFn<rime_get_api>();
		return ans;
	}

	// public str dllPath{get;set;}="rime";

	// public rime_get_api rime_get_api = null!;

	// public RimeDllLoader(str dllPath){
	// 	// this. dllPath = dllPath;
	// 	// var fnPtr = NativeLibrary.Load(dllPath);
	// 	// rime_get_api = fnPtr.asFn<rime_get_api>();//TODO test
	// }
}
