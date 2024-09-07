using badgatchagame.Content.Items;
using badgatchagame.Content.Items.Tickets;
using badgatchagame.Content.PlayerObjects;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static badgatchagame.Content.WorldObjects.RandomWorld;

namespace badgatchagame.Content.GameplayChanges
{
    public class NewItemDrops : GlobalNPC
    {
        public static Condition NotInAClass = new Condition("Mods.badgatchagame.Conditions.NotInAClass", () => Main.LocalPlayer.GetModPlayer<RandomPlayer>().ClassChosen <= -1);

        public override void ModifyShop(NPCShop shop)
        {
            switch (shop.NpcType) {
                case NPCID.Merchant:
                    shop.Add<meleeticket>(Condition.DownedEowOrBoc, NotInAClass);
                    shop.Add<rangerticket>(Condition.DownedEowOrBoc, NotInAClass);
                    shop.Add<mageticket>(Condition.DownedEowOrBoc, NotInAClass);
                    shop.Add<summonerticket>(Condition.DownedEowOrBoc, NotInAClass);
                break;

                case NPCID.Wizard:
                    shop.Add<brainwash>();
                break;
            }
            base.ModifyShop(shop);
        }

        public static int EaterOfWorldSegmentsAlive() {
            return NPC.CountNPCS(NPCID.EaterofWorldsBody) + NPC.CountNPCS(NPCID.EaterofWorldsHead) + NPC.CountNPCS(NPCID.EaterofWorldsTail);
        }

        public override void OnKill(NPC npc)
        {
            // alerting players that class tickets are available
            if (npc.type == NPCID.EaterofWorldsHead || npc.type == NPCID.EaterofWorldsBody || npc.type == NPCID.EaterofWorldsTail || npc.type == NPCID.BrainofCthulhu) {
                if (!Boss2Defeated && EaterOfWorldSegmentsAlive() <= 1) {
                    SetBoss2Defeated();
                    Main.NewText("The merchant now offers new items for sale!", 50, 255, 130);
                }
            }
            base.OnKill(npc);
        }
    }
}