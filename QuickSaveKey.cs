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
			Properties = new ModProperties()
			{
				Autoload = true
			};

			quickSave = RegisterHotKey("Quick save", "F5");
		}
		public override void Unload()
		{
			base.Unload();
			quickSave = null;
		}

		private static ModHotKey quickSave;
		public override void HotKeyPressed(string name)
		{
			bool IsLocalPlayer(Player player) => player.whoAmI == Main.myPlayer;

			var playerData = Main.ActivePlayerFileData;

			if (!IsLocalPlayer(playerData.Player) || !quickSave.JustPressed)
			{
				return;
			}

			Main.SaveRecent();
			Main.SaveSettings();

			// Singleplayer
			if (Main.netMode == NetmodeID.SinglePlayer)
			{
				WorldGen.saveToonWhilePlaying();
				WorldGen.saveAndPlay();

				Main.NewText("Game saved.", 0, 200, 0);
			}
			// Multiplayer
			else
			{
				WorldGen.saveToonWhilePlaying();
				Main.NewText("Character saved.", 0, 200, 0);
			}
		}
	}
}