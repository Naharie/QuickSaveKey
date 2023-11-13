using Terraria;
using Terraria.Audio;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;

namespace QuickSaveKey;

public class QuickSavePlayer: ModPlayer
{
    public override void ProcessTriggers(TriggersSet triggersSet)
    {
        if (QuickSaveMod.QuickSave.JustPressed)
        {
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

        if (QuickSaveMod.QuickLoad.JustPressed)
        {
            if (Main.netMode == NetmodeID.SinglePlayer)
            {
                var loaded = Player.LoadPlayer(Main.ActivePlayerFileData.Path, Main.ActivePlayerFileData.IsCloudSave);

                Main.player[Main.myPlayer] = loaded.Player;
                Main.ActivePlayerFileData = loaded;
                
                WorldFile.LoadWorld(Main.ActiveWorldFileData.IsCloudSave);
                
                //WorldGen.playWorldCallBack((object)1);

                if (Main.mapEnabled)
                {
                    Main.Map.Load();
                }

                //if (Main.netMode != NetmodeID.Server)
                //{
                    Main.sectionManager.SetAllSectionsLoaded();
                //}
                
                if (Main.netMode == NetmodeID.SinglePlayer && Main.anglerWhoFinishedToday.Contains(Main.player[Main.myPlayer].name))
                {
                    Main.anglerQuestFinished = true;
                }
                
                Main.player[Main.myPlayer].Spawn(PlayerSpawnContext.SpawningIntoWorld);
                
                WorldGen._lastSeed = Main.ActiveWorldFileData.Seed;
                WorldFile.SetOngoingToTemps();
                Main.resetClouds = true;
                WorldGen.noMapUpdate = false;
            }
            else
            {
                Main.NewText("Quick load does not work in multiplayer due to this being a client side only mod!", 200, 0, 0);
            }
        }
    }
}