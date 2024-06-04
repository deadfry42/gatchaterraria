using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using static badgatchagame.Content.Randomisation.RandomItemsLists;

namespace badgatchagame.Content.Randomisation
{
    public class ChooseRandomItem : ModSystem
    {
        public static int GetRandomItemID() {
            List<int> itemPool = getCurrentProgressionList();
            int index = Main.rand.Next(itemPool.Count);
            int chosenID = itemPool[index];

            return chosenID;
        }

        public static Item GetRandomItem() {
            return new Item(GetRandomItemID());
        }
    }
}