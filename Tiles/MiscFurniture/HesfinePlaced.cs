using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;
using Terraria.Graphics.Shaders;
using CalValEX.Items.Tiles;

namespace CalValEX.Tiles.MiscFurniture
{
    public class HesfinePlaced : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileLighted[Type] = true;
            Terraria.ID.TileID.Sets.DisableSmartCursor[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileID.Sets.FramesOnKillWall[Type] = true; // Necessary since Style3x3Wall uses AnchorWall
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.newTile.Width = 3;
            TileObjectData.newTile.Height = 3;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 }; //

            AnimationFrameHeight = 54;
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("I'm still not fine");
            AddMapEntry(new Color(139, 0, 0), name);
        }

        public override void KillMultiTile(int i, int j, int TileFrameX, int TileFrameY)
        {
            Item.NewItem(new Terraria.DataStructures.EntitySource_TileBreak(i, j), i * 16, j * 16, 24, 24, ItemType<Hesfine>());
        }

        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            frameCounter++;
            if (choketimer < 360 && choking)
            {
                if (frameCounter > 2) //make this number lower/bigger for faster/slower animation
                {
                    frameCounter = 0;
                    frame++;
                    if (frame > 3)
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
                    if (frame > 3)
                    {
                        frame = 0;
                    }
                }
            }
        }

        public override void NearbyEffects(int i, int j, bool closer)
        {
            if (choking)
            {
                choketimer++;
                if (choketimer == 360 && !feed)
                {
                    feed = true;
                    Terraria.Audio.SoundEngine.PlaySound(SoundID.NPCDeath13);
                    Item.NewItem(new Terraria.DataStructures.EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 16, ItemID.Sandstone, Main.rand.Next(6, 21));
                }
                if (choketimer == 460)
                {
                    Terraria.Audio.SoundEngine.PlaySound(SoundLoader.GetLegacySoundSlot(Mod, "Sounds/Help"));
                    choking = false;
                    feed = false;
                    choketimer = 0;
                }
            }
            if (Main.rand.Next(24) < 2)
            {
                Dust dust = Dust.NewDustDirect(new Vector2(i, j) * 16f, 30, 30, 271, 0f, 0f, 255, new Color(255, 255, 255), 1f);
                dust.shader = GameShaders.Armor.GetSecondaryShader(29, Main.LocalPlayer);
            }
        }
        //int dust = Dust.NewDust(new Vector2(i, j) * 16f, 5, 5, 1, 0f, 6.315789f, 161, new Color(0, 217, 255), 1.315789f);

        public override bool HasSmartInteract()
        {
            return true;
        }
        private bool choking = false;
        int choketimer = 0;
        private bool feed = false;

        public override bool RightClick(int i, int j)
        {
            Player player = Main.LocalPlayer;
            if (player.HasItem(ItemID.GreenMushroom) && !choking)
            {
                player.ConsumeItem(ItemID.GreenMushroom);
                Terraria.Audio.SoundEngine.PlaySound(SoundLoader.GetLegacySoundSlot(Mod, "Sounds/Nom"));
                choking = true;
            }
            else if (!choking)
            {
                Terraria.Audio.SoundEngine.PlaySound(SoundLoader.GetLegacySoundSlot(Mod, "Sounds/Help"));
            }
            for (int x = 0; x < 100; x++)
            {
                Dust dust = Dust.NewDustDirect(new Vector2(i, j) * 16f, 30, 30, 271, 0f, 0f, 255, new Color(255, 255, 255), 1f);
                dust.shader = GameShaders.Armor.GetSecondaryShader(29, Main.LocalPlayer);
            }
            return true;
        }
    }
}