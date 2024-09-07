using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using Terraria.GameContent.Generation;

using System.Collections.Generic;

using static badgatchagame.Content.Randomisation.RandomItemsLists;

namespace badgatchagame.Content.GameplayChanges
{
    public class ModifyChestGeneration : ModSystem
    {
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
        {
            int genIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Micro Biomes"));
            if (genIndex != -1)
            {
                tasks.Insert(genIndex + 1, new PassLegacy("CustomChestEdit", FilterItems));
            }
        }

        private void FilterItems(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Allowing the Retired Weaponsmith to steal every weapon";

            for (int chestIndex = 0; chestIndex < Main.maxChests; chestIndex++)
            {
                Chest chest = Main.chest[chestIndex];
                if (chest != null)
                {
                    List<int> itemPool = getAllRandomItems();

                    for (int inventoryIndex = 0; inventoryIndex < chest.item.Length; inventoryIndex++)
                    {
                        Item item = chest.item[inventoryIndex];
                        if (item != null && itemPool.Contains(item.type))
                        {
                            chest.item[inventoryIndex] = new Item(ItemID.GoldCoin, Main.rand.Next(9)+1);
                        }
                    }
                }
            }
        }
    }
}