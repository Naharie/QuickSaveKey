using Microsoft.Xna.Framework.Input;
using Terraria.ModLoader;

namespace QuickSaveKey
{
	public class QuickSaveMod : Mod
	{
		public override void Load()
		{
			QuickSave = KeybindLoader.RegisterKeybind(this, "Quick Save", Keys.F5);
		}
		public override void Unload()
		{
			QuickSave = null;
		}

		public static ModKeybind QuickSave;
	}
}