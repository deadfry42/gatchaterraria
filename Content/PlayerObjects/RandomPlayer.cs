using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace badgatchagame.Content.PlayerObjects
{
    public class RandomPlayer : ModPlayer
    {
        public double RerollPrice = 0D;
        public int LoweredPrices = 0;
        public bool Congrats = false;
        public bool Brainwashed = false;
        public int CouponWeapon1 = 0;
        public int CouponWeapon2 = 0;
        public short ClassChosen = -1;
        // ClassChosen info:
        // -1 = no class
        // 0 = melee
        // 1 = range
        // 2 = mage
        // 3 = summoner

        public override void SaveData(TagCompound tag)
        {
            tag["RerollPrice"] = RerollPrice;
            tag["LoweredPrices"] = LoweredPrices;
            tag["Congrats"] = Congrats;
            tag["Brainwashed"] = Brainwashed;
            tag["ClassChosen"] = ClassChosen;
            tag["CouponWeapon1"] = CouponWeapon1;
            tag["CouponWeapon2"] = CouponWeapon2;
            base.SaveData(tag);
        }

        public override void LoadData(TagCompound tag)
        {
            RerollPrice = tag.GetDouble("RerollPrice");
            LoweredPrices = tag.GetInt("LoweredPrices");
            Congrats = tag.GetBool("Congrats");
            Brainwashed = tag.GetBool("Brainwashed");
            ClassChosen = tag.GetShort("ClassChosen");
            CouponWeapon1 = tag.GetInt("CouponWeapon1");
            CouponWeapon2 = tag.GetInt("CouponWeapon2");
            base.LoadData(tag);
        }
    }
}