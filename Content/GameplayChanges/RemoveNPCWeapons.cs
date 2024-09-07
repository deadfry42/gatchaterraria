using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;
using Terraria.GameContent.ItemDropRules;
using static badgatchagame.Content.Randomisation.RandomItemsLists;
using Terraria.ID;

namespace badgatchagame.Content.GameplayChanges
{
    public class RemoveNPCWeapons : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            List<int> itemsToRemove = getAllRandomItems();
            foreach (int item in itemsToRemove) {
                foreach (var droptable in npcLoot.Get(false)) {
                    iterateItemDropRules(npcLoot, droptable, item);
                }
            }
        }

        public override void ModifyShop(NPCShop shop)
        {
            List<int> itemPool = getAllRandomItems();
            foreach (var entry in shop.Entries) {
                if (itemPool.Contains(entry.Item.type)) {
                    entry.Disable();
                }
            }
            base.ModifyShop(shop);
        }

        public override void ModifyActiveShop(NPC npc, string shopName, Item[] items)
        { // hacky solution for travelling merchant
            List<int> itemPool = getAllRandomItems();
            for (int i = 0; i < items.Length; i++) {
                Item it = items[i];
                if (it == null) continue;
                if (itemPool.Contains(it.type)) {items[i] = new Item(0);}
            }
            base.ModifyActiveShop(npc, shopName, items);
        }

        private static int[] RemoveAllItemsInDropIDS(int[] dropIds) {
            for (int i = 0; i < dropIds.Length; i++) {
                dropIds[i] = 0;
            }
            return dropIds;
        }

        private static void iterateItemDropRules(NPCLoot npcLoot, IItemDropRule droptable, int item) {
            if (droptable is CommonDrop drop1 && drop1.itemId == item) npcLoot.Remove(drop1);
            if (droptable is CommonDropNotScalingWithLuck drop2 && drop2.itemId == item) npcLoot.Remove(drop2);
            if (droptable is CommonDropWithRerolls drop3 && drop3.itemId == item) npcLoot.Remove(drop3);
            if (droptable is DropPerPlayerOnThePlayer drop4 && drop4.itemId == item) npcLoot.Remove(drop4);
            if (droptable is DropOneByOne drop5 && drop5.itemId == item) npcLoot.Remove(drop5);
            if (droptable is ItemDropWithConditionRule drop6 && drop6.itemId == item) npcLoot.Remove(drop6);
            if (droptable is DropLocalPerClientAndResetsNPCMoneyTo0 drop15 && drop15.itemId == item) npcLoot.Remove(drop15);

            if (droptable is OneFromOptionsNotScaledWithLuckDropRule drop7) drop7.dropIds = RemoveAllItemsInDropIDS(drop7.dropIds);
            if (droptable is FewFromOptionsNotScaledWithLuckDropRule drop8) drop8.dropIds = RemoveAllItemsInDropIDS(drop8.dropIds);
            if (droptable is FromOptionsWithoutRepeatsDropRule drop9) drop9.dropIds = RemoveAllItemsInDropIDS(drop9.dropIds);
            if (droptable is FewFromOptionsDropRule drop10) drop10.dropIds = RemoveAllItemsInDropIDS(drop10.dropIds);
            if (droptable is OneFromOptionsDropRule drop11) drop11.dropIds = RemoveAllItemsInDropIDS(drop11.dropIds);

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