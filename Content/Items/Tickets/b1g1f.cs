using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using badgatchagame.Content.PlayerObjects;

namespace badgatchagame.Content.Items.Tickets
{ 
	public class b1g1f : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 42;
			Item.height = 34;
			Item.useStyle = ItemUseStyleID.None;
			Item.value = Item.sellPrice(gold: 10);
			Item.rare = ItemRarityID.Expert;
            Item.expert = true;
            Item.expertOnly = true;
		}

        public override bool CanUseItem(Player player)
        {
            return false;
        }

        public override bool CanResearch()
        {
            return false;
        }
	}
}
