using Microsoft.Xna.Framework.Input;
using Terraria.ModLoader;

namespace QuickSaveKey
{
	public class QuickSaveMod : Mod
	{
		public override void Load()
		{
			QuickSave = KeybindLoader.RegisterKeybind(this, "Quick Save", Keys.F5);
			QuickLoad = KeybindLoader.RegisterKeybind(this, "Quick Load", Keys.F6);
		}
		public override void Unload()
		{
			QuickSave = null;
			QuickLoad = null;
		}

		public static ModKeybind QuickSave;
		public static ModKeybind QuickLoad;
	}
}