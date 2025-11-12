/// librime/src/rime/key_table.h
namespace Rime.Api;
using Mask = int;
public class RimeModifier {
	/// <summary>
	/// 按下時潙0
	/// </summary>
	public static Mask zero = 0;
	public static Mask kShiftMask = 1 << 0;
	public static Mask kLockMask = 1 << 1;
	public static Mask kControlMask = 1 << 2;
	public static Mask kMod1Mask = 1 << 3;
	public static Mask kAltMask = kMod1Mask;
	public static Mask kMod2Mask = 1 << 4;
	public static Mask kMod3Mask = 1 << 5;
	public static Mask kMod4Mask = 1 << 6;
	public static Mask kMod5Mask = 1 << 7;
	public static Mask kButton1Mask = 1 << 8;
	public static Mask kButton2Mask = 1 << 9;
	public static Mask kButton3Mask = 1 << 10;
	public static Mask kButton4Mask = 1 << 11;
	public static Mask kButton5Mask = 1 << 12;

	/* The next few modifiers are used by XKB; so we skip to the end.
	* Bits 15 - 23 are currently unused. Bit 29 is used internally.
	*/

	/* ibus :) mask */
	public static Mask kHandledMask = 1 << 24;
	public static Mask kForwardMask = 1 << 25;
	public static Mask kIgnoredMask = kForwardMask;

	public static Mask kSuperMask = 1 << 26;
	public static Mask kHyperMask = 1 << 27;
	public static Mask kMetaMask = 1 << 28;

	public static Mask kReleaseMask = 1 << 30;

	public static Mask kModifierMask = 0x5f001fff;

}