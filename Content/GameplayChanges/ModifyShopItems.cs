using badgatchagame.Content.Items.Tickets;
using badgatchagame.Content.PlayerObjects;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace badgatchagame.Content.GameplayChanges
{
    public class ModifyShopItems : GlobalNPC
    {
        public static Condition NotInAClass = new Condition("Mods.badgatchagame.Conditions.NotInAClass", () => Main.LocalPlayer.GetModPlayer<RandomPlayer>().ClassChosen <= -1);

        public override void ModifyShop(NPCShop shop)
        {
            if (shop.NpcType == NPCID.Merchant) {
                shop.Add<meleeticket>(Condition.DownedEyeOfCthulhu, NotInAClass);
                shop.Add<rangerticket>(Condition.DownedEyeOfCthulhu, NotInAClass);
                shop.Add<mageticket>(Condition.DownedEyeOfCthulhu, NotInAClass);
                shop.Add<summonerticket>(Condition.DownedEyeOfCthulhu, NotInAClass);
            }
            base.ModifyShop(shop);
        }

        public override void OnKill(NPC npc)
        {
            switch (npc.type) {
                case NPCID.EaterofWorldsHead:
                case NPCID.BrainofCthulhu:
                    if (NPC.downedBoss2) return;
                    Main.NewText("The merchant can now afford to sell a very important item!");
                break;
            }
        }
    }
}