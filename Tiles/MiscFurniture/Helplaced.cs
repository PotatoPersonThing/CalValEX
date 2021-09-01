using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;
using CalValEX.Items.Tiles;

namespace CalValEX.Tiles.MiscFurniture
{
    internal class Helplaced : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileLighted[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileID.Sets.FramesOnKillWall[Type] = true; // Necessary since Style3x3Wall uses AnchorWall
            TileID.Sets.HasOutlines[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.newTile.Width = 2;
            TileObjectData.newTile.Height = 3;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 }; //

            animationFrameHeight = 54;
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Help me");
            AddMapEntry(new Color(139, 0, 0), name);
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 16, 24, ItemType<Help>());
        }

        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            frameCounter++;
            if (choketimer < 120 && choking)
            {
                if (frameCounter > 4) //make this number lower/bigger for faster/slower animation
                {
                    frameCounter = 0;
                    frame++;
                    if (frame > 1)
                    {
                        frame = 0;
                    }
                }
            }
            else
            {
                if (frameCounter > 15) //make this number lower/bigger for faster/slower animation
                {
                    frameCounter = 0;
                    frame++;
                    if (frame > 1)
                    {
                        frame = 0;
                    }
                }
            }
        }

        public override bool HasSmartInteract()
        {
            return true;
        }

        public override void MouseOver(int i, int j)
        {
            Player localPlayer = Main.LocalPlayer;
            localPlayer.noThrow = 2;
            localPlayer.showItemIcon = true;
            localPlayer.showItemIcon2 = ModContent.ItemType<Help>();
            int dust = Dust.NewDust(new Vector2(i, j) * 16f, 5, 5, 1, 0f, 6.315789f, 161, new Color(0, 217, 255), 1.315789f);
            if (Main.LocalPlayer.name == "Bumbledoge")
            {
                Main.LocalPlayer.AddBuff(ModLoader.GetMod("CalamityMod").BuffType("TemporalSadness"), 10);
            }
            else if (Main.LocalPlayer.name == "willowmaine")
            {
                Main.LocalPlayer.AddBuff(ModLoader.GetMod("CalamityMod").BuffType("TemporalSadness"), 10);
            }
            else if (Main.LocalPlayer.name == "Mochi")
            {
                Main.LocalPlayer.AddBuff(ModLoader.GetMod("CalamityMod").BuffType("OrthoceraShell"), 10);
            }
            else
            {
                Main.LocalPlayer.AddBuff(146, 20);
            }
        }
        int choketimer = 0;
        private bool choking = false;
        private bool feed = false;

        public override bool NewRightClick(int i, int j)
        {
            Player player = Main.LocalPlayer;
            if (player.HasItem(ItemID.GreenMushroom) && !choking)
            {
                player.ConsumeItem(ItemID.GreenMushroom);
                Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Nom"));
                feed = false;
                choking = true;
            }
            else if (!choking)
            {
                Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Help"));
            }
            return true;
        }

        public override void NearbyEffects(int i, int j, bool closer)
        {
            if (choking)
            {
                choketimer++;
                if (choketimer == 120 && !feed)
                {
                    feed = true;
                    Main.PlaySound(SoundID.NPCDeath13);
                    Item.NewItem(i * 16, j * 16, 16, 16, ModLoader.GetMod("CalamityMod").ItemType("HardenedSulphurousSandstone"), Main.rand.Next(6, 21));
                }
                if (choketimer == 160)
                {
                    Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Help"));
                    choking = false;
                    feed = false;
                    choketimer = 0;
                }
            }
            if (closer)
            {
                if (Main.LocalPlayer.HasItem(ModLoader.GetMod("CalamityMod").ItemType("OrthoceraShell")))
                {
                    int dust = Dust.NewDust(new Vector2(i, j) * 16f, 5, 5, 1, 0f, 6.315789f, 161, new Color(0, 217, 255), 1.315789f);
                    if (Main.LocalPlayer.name == "Bumbledoge")
                    {
                        Main.LocalPlayer.AddBuff(ModLoader.GetMod("CalamityMod").BuffType("TemporalSadness"), 10);
                    }
                    else if (Main.LocalPlayer.name == "willowmaine")
                    {
                        Main.LocalPlayer.AddBuff(ModLoader.GetMod("CalamityMod").BuffType("TemporalSadness"), 10);
                    }
                    else if (Main.LocalPlayer.name == "Mochi")
                    {
                        Main.LocalPlayer.AddBuff(ModLoader.GetMod("CalamityMod").BuffType("TemporalSadness"), 10);
                    }
                    else
                    {
                        Main.LocalPlayer.AddBuff(146, 10);
                    }
                }
            }
        }
    }
}