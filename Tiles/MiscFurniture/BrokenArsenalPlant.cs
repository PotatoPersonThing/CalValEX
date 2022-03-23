using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CalValEX.Items.Tiles;

namespace CalValEX.Tiles.MiscFurniture
{
    public class BrokenArsenalPlant : ModTile
    {
        public enum state
        { 
            IdleOff,
            StartUp,
            IdleOn,
            ShutDown
        }
        state STstate = state.IdleOff;
        public bool trans = false;

        public string[] animTex = {
            "CalValEX/Tiles/MiscFurniture/BrokenArsenalPlant",
            "CalValEX/Tiles/MiscFurniture/BrokenArsenalPlantStartUp",
            "CalValEX/Tiles/MiscFurniture/BrokenArsenalPlantIdleOn",
            "CalValEX/Tiles/MiscFurniture/BrokenArsenalPlantShutDown"};
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileLighted[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileID.Sets.FramesOnKillWall[Type] = true; // Necessary since Style3x3Wall uses AnchorWall
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.newTile.Width = 2;
            TileObjectData.newTile.Height = 6;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16, 16, 16, 16 }; //
            TileObjectData.newTile.Origin = new Point16(1, 0);

            animationFrameHeight = 108;
            TileObjectData.addTile(Type);
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 24, 16, ItemType<BrokenArsenalPlantItem>());
        }
        public override bool NewRightClick(int i, int j)
        {
            //Main.PlaySound(mod.GetSoundSlot(SoundType.Custom, "Sounds/ScreenChange"), i * 16, j * 16, 0);
            if (STstate == state.IdleOff)
            {
                STstate = state.StartUp;
            }
            if (STstate == state.IdleOn)
            {
                STstate = state.ShutDown;
            }
            if (STstate == state.ShutDown)
            {
                STstate = state.IdleOff;
            }
            return true;
        }

        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            for(var i = 0; i < animTex.Length; i++)
            {

                if (STstate == state.IdleOff)
                {
                    frameCounter = 0;
                }
                if (STstate == state.StartUp)
                {
                    frameCounter++;
                    if (frameCounter > 8) //make this number lower/bigger for faster/slower animation
                    {
                        frameCounter = 0;
                        frame++;
                        if (frame > 13)
                        {
                            STstate = state.IdleOn;
                        }
                    }
                }
                if (STstate == state.IdleOn)
                {
                    frameCounter++;
                    if (frameCounter > 8)
                    {
                        frameCounter = 0;
                        frame++;
                        if (frame > 13)
                        {
                            frame = 0;
                        }
                    }
                }
                if (STstate == state.StartUp)
                {
                    frameCounter++;
                    if (frameCounter > 8)
                    {
                        frameCounter = 0;
                        frame++;
                        if (frame > 13)
                        {
                            STstate = state.IdleOff;
                        }
                    }
                }
            }
        }

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            Texture2D tex = ModContent.GetTexture(animTex[
                STstate == state.IdleOff ? 1
                : STstate == state.StartUp? 1
                : STstate == state.IdleOn ? 2
                : STstate == state.ShutDown ? 3
                : 0
                ]);

            spriteBatch.Draw(tex, new Rectangle(), Color.White);
        }
    }
}