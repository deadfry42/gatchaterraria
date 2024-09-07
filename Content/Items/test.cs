using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace badgatchagame.Content.Items
{ // this item is used to help me debug lol
// ignore
	public class test : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 21;
			Item.useTime = 1;
			Item.useAnimation = 1;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.value = Item.buyPrice(platinum: 3);
			Item.rare = ItemRarityID.Pink;
			Item.UseSound = SoundID.NPCDeath11;
			Item.autoReuse = false;
			Item.consumable = true;
		}

        public override bool? UseItem(Player plr)
        {
			Main.NewText(SpawnCondition.Meteor.Active.ToString());
            return false;
        }

        public override bool CanResearch()
        {
            return false;
        }
	}
}
