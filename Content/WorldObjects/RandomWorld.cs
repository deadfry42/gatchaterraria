using Terraria;
using Terraria.ModLoader;

namespace badgatchagame.Content.WorldObjects
{
    public class RandomWorld : ModSystem
    { // my hacky solution to making a notification the first time EoW/BoC is killed
        public static bool Boss2Defeated = false;
        public static void SetBoss2Defeated() {
            Boss2Defeated = true;
        }

        public override void Unload()
        {
            Boss2Defeated = false;
            base.Unload();
        }

        public override void OnWorldUnload()
        {
            Boss2Defeated = false;
            base.OnWorldUnload();
        }

        public override void OnWorldLoad()
        {
            Boss2Defeated = NPC.downedBoss2;
            base.OnWorldLoad();
        }
    }
}