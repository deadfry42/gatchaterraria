using Terraria.ModLoader;
using MonoMod.Cil;
using Terraria.UI;

using static Mono.Cecil.Cil.OpCodes;
using static badgatchagame.Content.Randomisation.RandomItemsLists;

using System.Collections.Generic;
using System;
using Terraria;

namespace badgatchagame.Content.GameplayChanges
{
    internal class IlEditing : ModSystem
    {
        public override void Load()
        {
            IL_ItemSlot.LeftClick_ItemArray_int_int += HookChests;
            IL_Player.DropSelectedItem_int_refItem += HookDrop;
            base.Load();
        }

        public override void Unload()
        {
            IL_ItemSlot.LeftClick_ItemArray_int_int -= HookChests;
            IL_Player.DropSelectedItem_int_refItem -= HookDrop;
            base.Unload();
        }

        public static void HookChests(ILContext il) {
            // WORKS 1.4.4.9
            try {
                ILCursor c = new(il);
                var start = c.DefineLabel();

                // this IL patch makes it so you cannot interact with restricted items
                // while in a chest or other storage.

                // please forgive me for the bad patching job
                // this is literally the first time i've ever IL Edited

                c.Index+=2;

                // loads ref Item
                c.Emit(Ldelem_Ref);
                // sets it to index 0
                c.Emit(Stloc_0);

                // loads index 0
                c.Emit(Ldarg_0);
                // loads index 2
                c.Emit(Ldarg_2);
                // loads ref item
                c.Emit(Ldelem_Ref);
                // do the ItemIsAllowed function
                c.Emit(Call, Type.GetType("badgatchagame.Content.GameplayChanges.RestrictChestItems").GetMethod("ItemIsAllowed", new Type[] { typeof(Terraria.Item) } ));
                // if true, continue with the rest of the code
                c.Emit(Brfalse_S, start);

                // loads index 0
                c.Emit(Ldloc_0);
                // loads the current chest the player is in
                c.Emit(Ldfld, typeof(Terraria.Player).GetField(nameof(Terraria.Player.chest)));
                // load -1 as the next variable
                c.Emit(Ldc_I4_M1);
                // if the 2 above values are equal, continue with the rest of the code
                // (if the player is not in a chest/bank)
                c.Emit(Beq_S, start);

                // else, return and stop execution
                c.Emit(Ret);

                c.Index += 2;

                c.MarkLabel(start);
            } catch (Exception e) { 
                throw new ILPatchFailureException(ModContent.GetInstance<badgatchagame>(), il, e);
            }
        }

        public static void HookDrop(ILContext il) {
            // come back to later
            try {
                ILCursor c = new(il);
                var start = c.DefineLabel();

                // this IL patch makes it so you cannot drop restricted items

                // please forgive me for the bad patching job
                // this is literally the second time i've ever IL Edited

                // c.Index += 2;

                // c.Emit(Ldarg_1);
                // c.Emit(Call, Type.GetType("badgatchagame.Content.GameplayChanges.RestrictChestItems").GetMethod("ItemIsAllowed", new Type[] { typeof(Terraria.Item) } ));
                // c.Emit(Brfalse_S, start);

                // c.MarkLabel(start);
            } catch (Exception e) { 
                throw new ILPatchFailureException(ModContent.GetInstance<badgatchagame>(), il, e);
            }
            // MonoModHooks.DumpIL(ModContent.GetInstance<badgatchagame>(), il);
        }

        public static int a() {
            Item newItem = new(69);

            return newItem.type;
        }

        public static bool ItemIsAllowed(Item item) {
            List<int> ritems = getAllRandomItems();
            for (int i = 0; i < ritems.Count; i++) {
                if (ritems[i] == item.type) return true;
            }
            return false;
        }
    }
}