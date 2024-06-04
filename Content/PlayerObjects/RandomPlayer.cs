using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace randomitems.Content.PlayerObjects
{
    public class RandomPlayer : ModPlayer
    {
        public double RerollPrice = 0D;
        public int LoweredPrices = 0;
        public bool Congrats = false;

        public override void SaveData(TagCompound tag)
        {
            tag["RerollPrice"] = RerollPrice;
            tag["LoweredPrices"] = LoweredPrices;
            tag["Congrats"] = Congrats;
            base.SaveData(tag);
        }

        public override void LoadData(TagCompound tag)
        {
            RerollPrice = tag.GetDouble("RerollPrice");
            LoweredPrices = tag.GetInt("LoweredPrices");
            Congrats = tag.GetBool("Congrats");
            base.LoadData(tag);
        }
    }
}