using badgatchagame.Content.Items;
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
    }
}