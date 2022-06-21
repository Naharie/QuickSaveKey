using Terraria;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;

namespace QuickSaveKey;

public class QuickSavePlayer: ModPlayer
{
    public override void ProcessTriggers(TriggersSet triggersSet)
    {
        if (!QuickSaveMod.QuickSave.JustPressed) return;

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