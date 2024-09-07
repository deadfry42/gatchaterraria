using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using System.Collections.Generic;
using badgatchagame.Content.PlayerObjects;
using static badgatchagame.Content.Randomisation.RandomItemsLists;
using badgatchagame.Content.Items.Tickets;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace badgatchagame.Content.GameplayChanges
{
    public class RemoveTileWeapons : GlobalTile
    {
        // purely used to alter shadow orb/crimson heart drops

        public override bool CanDrop(int i, int j, int type)
        {
            if (type == TileID.ShadowOrbs) return false;
            return base.CanDrop(i, j, type);
        }

        public override void KillTile(int i, int j, int type, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            if (type == TileID.AbigailsFlower) noItem = true; // disable abigails flower
            if (type == 50 && Main.tile[i, j].TileFrameX == 90 && Main.tile[i, j].TileFrameY == 0)  noItem = true; // disable water bolt
            if (type == TileID.ShadowOrbs && !fail) {
                noItem = true;
                if (WorldGen.crimson) {
                    if (Main.tile[i, j].TileFrameX != 36 || Main.tile[i, j].TileFrameY != 0) return;
                    // crimson heart

                    IEntitySource source = WorldGen.GetItemSource_FromTileBreak(i, j);

                    if (!WorldGen.shadowOrbSmashed) {
                        Item.NewItem(source, new Vector2(i*16, j*16), new Vector2(), ItemID.CrimsonHeart, 1);
                    } else {
                        if (Main.rand.NextBool()) {
                            Item.NewItem(source, new Vector2(i*16, j*16), new Vector2(), ItemID.CrimsonHeart, 1);
                        } else {
                            Item.NewItem(source, new Vector2(i*16, j*16), new Vector2(), ItemID.PanicNecklace, 1);
                        }
                    }
                } else {
                    if (Main.tile[i, j].TileFrameX != 0 || Main.tile[i, j].TileFrameY != 0) return;
                    // shadow orb

                    IEntitySource source = WorldGen.GetItemSource_FromTileBreak(i, j);

                    if (!WorldGen.shadowOrbSmashed) {
                        Item.NewItem(source, new Vector2(i*16, j*16), new Vector2(), ItemID.ShadowOrb, 1);
                    } else {
                        if (Main.rand.NextBool()) {
                            Item.NewItem(source, new Vector2(i*16, j*16), new Vector2(), ItemID.ShadowOrb, 1);
                        } else {
                            Item.NewItem(source, new Vector2(i*16, j*16), new Vector2(), ItemID.BandofStarpower, 1);
                        }
                    }
                }
            }
            // base.KillTile(i, j, type, ref fail, ref effectOnly, ref noItem);
        }
    }
}