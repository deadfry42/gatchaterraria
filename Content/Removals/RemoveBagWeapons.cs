using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using System.Collections.Generic;
using badgatchagame.Content.PlayerObjects;
using static badgatchagame.Content.Randomisation.RandomItemsLists;

namespace badgatchagame.Content.Removals
{
    public class RemoveBagWeapons : GlobalItem
    {
        public override void ModifyItemLoot(Item item, ItemLoot itemLoot)
        {
            List<int> itemsToRemove = getAllRandomItems();
            foreach (int itemID in itemsToRemove) {
                foreach (var droptable in itemLoot.Get(false)) {
                    iterateItemDropRules(itemLoot, droptable, itemID);
                }
            }
        }

        public override void OnConsumeItem(Item item, Player player)
        {
            if (item.type == ItemID.DemonHeart) {
                Player plr = Main.player[Main.myPlayer];
                plr.GetModPlayer<RandomPlayer>().Congrats = true;
                base.OnConsumeItem(item, player);
            }
        }

        private static int[] RemoveAllItemsInDropIDS(int[] dropIds, int item) {
            for (int i = 0; i < dropIds.Length; i++) {
                if (dropIds[i] == item) dropIds[i] = 0;
            }
            return dropIds;
        }

        private static void iterateItemDropRules(ItemLoot npcLoot, IItemDropRule droptable, int item) {
            if (droptable is CommonDrop drop1 && drop1.itemId == item) npcLoot.Remove(drop1);
            if (droptable is CommonDropNotScalingWithLuck drop2 && drop2.itemId == item) npcLoot.Remove(drop2);
            if (droptable is CommonDropWithRerolls drop3 && drop3.itemId == item) npcLoot.Remove(drop3);
            if (droptable is DropPerPlayerOnThePlayer drop4 && drop4.itemId == item) npcLoot.Remove(drop4);
            if (droptable is DropOneByOne drop5 && drop5.itemId == item) npcLoot.Remove(drop5);
            if (droptable is ItemDropWithConditionRule drop6 && drop6.itemId == item) npcLoot.Remove(drop6);
            if (droptable is DropLocalPerClientAndResetsNPCMoneyTo0 drop15 && drop15.itemId == item) npcLoot.Remove(drop15);

            if (droptable is OneFromOptionsNotScaledWithLuckDropRule drop7) drop7.dropIds = RemoveAllItemsInDropIDS(drop7.dropIds, item);
            if (droptable is FewFromOptionsNotScaledWithLuckDropRule drop8) drop8.dropIds = RemoveAllItemsInDropIDS(drop8.dropIds, item);
            if (droptable is FromOptionsWithoutRepeatsDropRule drop9) drop9.dropIds = RemoveAllItemsInDropIDS(drop9.dropIds, item);
            if (droptable is FewFromOptionsDropRule drop10) drop10.dropIds = RemoveAllItemsInDropIDS(drop10.dropIds, item);
            if (droptable is OneFromOptionsDropRule drop11) drop11.dropIds = RemoveAllItemsInDropIDS(drop11.dropIds, item);

            if (droptable is DropBasedOnExpertMode drop12) {
                iterateItemDropRules(npcLoot, drop12.ruleForNormalMode, item);
                iterateItemDropRules(npcLoot, drop12.ruleForExpertMode, item);
            }
            if (droptable is DropBasedOnMasterAndExpertMode drop13) {
                iterateItemDropRules(npcLoot, drop13.ruleForMasterMode, item);
                iterateItemDropRules(npcLoot, drop13.ruleForExpertmode, item);
                iterateItemDropRules(npcLoot, drop13.ruleForDefault, item);
            }
            if (droptable is DropBasedOnMasterMode drop14) {
                iterateItemDropRules(npcLoot, drop14.ruleForDefault, item);
                iterateItemDropRules(npcLoot, drop14.ruleForMasterMode, item);
            }

            if (droptable is LeadingConditionRule drop16) {
                foreach (var chained in drop16.ChainedRules) {
                    iterateItemDropRules(npcLoot, chained.RuleToChain, item);
                }
            }

            if (droptable is SequentialRulesRule drop17) {
                foreach (var chained in drop17.ChainedRules) {
                    iterateItemDropRules(npcLoot, chained.RuleToChain, item);
                }
            }
            
            if (droptable is SequentialRulesNotScalingWithLuckRule drop18) {
                foreach (var chained in drop18.ChainedRules) {
                    iterateItemDropRules(npcLoot, chained.RuleToChain, item);
                }
            }

            if (droptable is OneFromRulesRule drop19) {
                foreach (var chained in drop19.ChainedRules) {
                    iterateItemDropRules(npcLoot, chained.RuleToChain, item);
                }
            }
        }
    }
}