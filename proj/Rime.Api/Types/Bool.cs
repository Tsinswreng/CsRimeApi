namespace Rime.Api.Types;
using TPrimitive = System.Int32;
using TStruct = Bool;
public struct Bool(TPrimitive V){
	public TPrimitive Value = V;
	public static implicit operator TPrimitive(TStruct e){
		return e.Value;
	}
	public static implicit operator TStruct(TPrimitive s){
		return new TStruct(s);
	}

	public static readonly TStruct True = new (1);
	public static readonly TStruct False = new (0);
}
