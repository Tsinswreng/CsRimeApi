using System.Runtime.InteropServices;
using Rime.Api.Types;
namespace Rime.Api;

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
unsafe public delegate void RimeNotificationHandler(
	void* context_object
	,RimeSessionId session_id
	// [MarshalAs(UnmanagedType.LPStr)] string message_type,    // const char* -> string（自动转换为LPStr）[[3]]
	// [MarshalAs(UnmanagedType.LPStr)] string message_value    // 同上
	,byte* message_type // const char*
	,byte* message_value // const char*
);


unsafe public static class ExtnRimeNotificationHandler{
	extension(RimeNotificationHandler z){
		public delegate* unmanaged[Cdecl]<
			void* // context_object
			,RimeSessionId // session_id
			,u8* //message_type // const char*
			,u8* //message_value // const char*
			,void
		> // handler
		ToFnPtr(){
			var R = Marshal.GetFunctionPointerForDelegate(z);
			return (delegate* unmanaged[Cdecl]<
				void* // context_object
				,RimeSessionId // session_id
				,u8* //message_type // const char*
				,u8* //message_value // const char*
				,void
			>)R;
		}
	}
}
