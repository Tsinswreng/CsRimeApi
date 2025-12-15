namespace Rime.Api.Types;
using TPrimitive = System.UIntPtr;
using TStruct = RimeSessionId;
public struct RimeSessionId(TPrimitive V){
	public TPrimitive Value = V;
	public static implicit operator TPrimitive(TStruct e){
		return e.Value;
	}
	public static implicit operator TStruct(TPrimitive s){
		return new TStruct(s);
	}
}


