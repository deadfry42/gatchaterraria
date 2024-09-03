using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using badgatchagame.Content.PlayerObjects;

namespace badgatchagame.Content.Items
{ 
	public class brainwash : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 21;
			Item.useTime = 100;
			Item.useAnimation = 100;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.value = Item.buyPrice(platinum: 3);
			Item.rare = ItemRarityID.Pink;
			Item.UseSound = SoundID.NPCDeath11;
			Item.autoReuse = false;
			Item.consumable = true;
		}

        public override bool? UseItem(Player plr)
        {
			RandomPlayer mplr = plr.GetModPlayer<RandomPlayer>();
			if (mplr.Brainwashed != false || Main.dayTime) return base.UseItem(plr);
			mplr.RerollPrice = 0D;
			mplr.LoweredPrices = 0;
			mplr.Congrats = false;
			mplr.Brainwashed = true;
			mplr.ClassChosen = -1;
			Main.NewText("The Retired Weaponsmith suddenly no longer remembers you..");
            return true;
        }

        public override bool CanResearch()
        {
            return false;
        }
	}
}
