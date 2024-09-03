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
    internal class RestrictChestItems : ModSystem
    {
        public override void Load()
        {
            IL_ItemSlot.LeftClick_ItemArray_int_int += HookChests;
            base.Load();
        }

        public override void Unload()
        {
            IL_ItemSlot.LeftClick_ItemArray_int_int -= HookChests;
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

                c.Emit(Ldelem_Ref);
                c.Emit(Stloc_0);

                c.Emit(Ldarg_0);
                c.Emit(Ldarg_2);
                c.Emit(Ldelem_Ref);
                c.Emit(Call, Type.GetType("badgatchagame.Content.GameplayChanges.RestrictChestItems").GetMethod("ItemIsAllowed", new Type[] { typeof(Terraria.Item) } ));
                c.Emit(Brfalse_S, start);

                c.Emit(Ldloc_0);
                c.Emit(Ldfld, typeof(Terraria.Player).GetField(nameof(Terraria.Player.chest)));
                c.Emit(Ldc_I4_M1);
                c.Emit(Beq_S, start);

                c.Emit(Ret);

                c.Index += 2;

                c.MarkLabel(start);
            } catch (Exception e) { 
                throw new ILPatchFailureException(ModContent.GetInstance<badgatchagame>(), il, e);
            }
            MonoModHooks.DumpIL(ModContent.GetInstance<badgatchagame>(), il);
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