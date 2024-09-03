using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using badgatchagame.Content.PlayerObjects;

namespace badgatchagame.Content.Items.Tickets
{ 
	public class meleeticket : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 42;
			Item.height = 34;
			Item.useTime = 50;
			Item.useAnimation = 50;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.value = Item.buyPrice(gold: 5);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item4;
			Item.autoReuse = false;
			Item.consumable = true;
		}

        public override bool? UseItem(Player plr)
        {
			RandomPlayer mplr = plr.GetModPlayer<RandomPlayer>();
			if (mplr.ClassChosen > -1) return base.UseItem(plr);
			mplr.ClassChosen = 0;
			Main.NewText("The Retired Weaponsmith now has a more limited selection..");
            return true;
        }

        public override bool CanResearch()
        {
            return false;
        }
	}
}
