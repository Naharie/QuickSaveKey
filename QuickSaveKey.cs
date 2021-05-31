using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System;

namespace QuickSaveKey
{
	public class QuickSave : Mod
	{
		public QuickSave()
		{
		}

		public override void Load()
		{
			quickSave = RegisterHotKey("Quick save", "F5");
		}
		public override void Unload()
		{
			quickSave = null;
		}

		private static ModHotKey quickSave;

		public override void HotKeyPressed(string name)
		{
			if (!quickSave.JustPressed) return;

			Main.SaveRecent();
			Main.SaveSettings();

			if (Main.netMode == NetmodeID.SinglePlayer)
			{
				WorldGen.saveToonWhilePlaying();
				WorldGen.saveAndPlay();

				Main.NewText("Game saved.", 0, 200, 0);
			}
			else
			{
				WorldGen.saveToonWhilePlaying();
				Main.NewText("Character saved.", 0, 200, 0);
			}
		}
	}
}