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

        public static List<int> FilterWeaponType(List<int> currentList, int classid) {
            List<int> newList = [];
            for (int i = 0; i < currentList.Count; i++) {
                Item item = new(currentList[i]);
                bool pass = false;
                if (classid == 0 && (item.DamageType == DamageClass.Melee || item.DamageType == DamageClass.MeleeNoSpeed)) pass = true;
                else if (classid == 1 && (item.DamageType == DamageClass.Ranged)) pass = true;
                else if (classid == 2 && (item.DamageType == DamageClass.Magic)) pass = true;
                else if (classid == 3 && (item.DamageType == DamageClass.Summon || item.DamageType == DamageClass.SummonMeleeSpeed)) pass = true;

                if (pass == true) {
                    newList.Add(currentList[i]);
                }
            }
            return newList;
        }
    }
}