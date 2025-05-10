using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;
using System;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CalValEX.Tiles.MiscFurniture
{
    public class SePlaced : ModTile
    {
        int rotationbottom;
        int negavar;
        public override void SetStaticDefaults()
        {
            TileID.Sets.DisableSmartCursor[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileLighted[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileID.Sets.FramesOnKillWall[Type] = true; // Necessary since Style3x3Wall uses AnchorWall
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.newTile.Width = 3;
            TileObjectData.newTile.Height = 2;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16 }; //
            TileObjectData.newTile.Origin = new Point16(0, 1);
            TileObjectData.newTile.UsesCustomCanPlace = true;
            TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(GetInstance<SepulcherTubemanTE>().Hook_AfterPlacement, -1, 0, false);
            TileObjectData.addTile(Type);
        }

        private bool shittypostimer = true;
        private bool shittynegatimer = false;
        public override void PlaceInWorld(int i, int j, Item item)
        {
            rotationbottom = -35;
        }
        public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            GetInstance<SepulcherTubemanTE>().Kill(i, j);
        }

        /*public override void RandomUpdate(int i, int j)
        {
            if (rotationbottom <= -30f)
            {
                rotationbottom++;
            }
            if (rotationbottom >= 30f)
            {
                rotationbottom--;
            }
        }*/

        float count;
        float abso;
        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            Tile tile = Main.tile[i, j];
            if (tile.TileFrameX == 0 && tile.TileFrameY == 0)
            {
                //Sproots

                Texture2D Seg1 = Request<Texture2D>("CalValEX/ExtraTextures/Sepulcher/SepulcherBottomOrb").Value;
                Texture2D Seg2 = Request<Texture2D>("CalValEX/ExtraTextures/Sepulcher/SepulcherBottomSegment").Value;
                Texture2D Seg3 = Request<Texture2D>("CalValEX/ExtraTextures/Sepulcher/SepulcherLowerSegment").Value;
                Texture2D Seg4 = Request<Texture2D>("CalValEX/ExtraTextures/Sepulcher/SepulcherMiddleOrb").Value;
                Texture2D Seg5 = Request<Texture2D>("CalValEX/ExtraTextures/Sepulcher/SepulcherMiddleSegment").Value;
                Texture2D Seg6 = Request<Texture2D>("CalValEX/ExtraTextures/Sepulcher/SepulcherTopOrb").Value;
                Texture2D Seg7 = Request<Texture2D>("CalValEX/ExtraTextures/Sepulcher/SepulcherHead").Value;
                Texture2D ArmR = Request<Texture2D>("CalValEX/ExtraTextures/Sepulcher/SepulcherRightArm").Value;
                Texture2D ArmRU = Request<Texture2D>("CalValEX/ExtraTextures/Sepulcher/SepulcherRightArmUpper").Value;                

                SepulcherTubemanTE cables = new SepulcherTubemanTE();
                GetTEFromCoords(i, j + 1, out cables);
                Vector2 weirdOffset = new Vector2(224, 176);
                if (tile.TileFrameX == 0 && tile.TileFrameY == 0)
                {
                    GetTEFromCoords(i, j + 1, out cables);
                    if (cables != null)
                    {

                        if (cables.Segments != null)
                        {
                            for (int u = 0; u < cables.Segments.Count; u++)
                            {
                                VerletSimulatedSegment v = cables.Segments[u];
                                float rot = u == 0 ? 0f : v.position.DirectionTo(cables.Segments[u - 1].position).ToRotation() - MathHelper.PiOver2;
                                int ct = cables.Segments.Count;
                                //Main.NewText(v.position);
                                Texture2D s2u = Seg1;
                                switch (u)
                                {
                                    case 0:
                                        s2u = Seg1;
                                        break;
                                    case 1:
                                        s2u = Seg2;
                                        break;
                                    case 2:
                                    case 4:
                                    case 6:
                                        s2u = Seg3;
                                        break;
                                    case 3:
                                    case 5:
                                    case 7:
                                        s2u = Seg4;
                                        break;
                                    case 8:
                                        s2u = Seg5;
                                        break;
                                    case 9:
                                        s2u = Seg6;
                                        break;
                                    case 10:
                                        s2u = Seg7;
                                        break;

                                }
                                Vector2 origine = new(s2u.Width / 2, s2u.Height);
                                spriteBatch.Draw(s2u, v.position - Main.screenPosition - Vector2.UnitX * s2u.Width / 2 + weirdOffset, new(0, 0, s2u.Width, s2u.Height), Color.White, rot, origine, 1f, SpriteEffects.None, 0f);
                            }
                        }
                        else
                        {
                            if (cables.Segments is null || cables.Segments.Count < 7)
                            {
                                cables.Segments = new List<VerletSimulatedSegment>();
                                for (int jh = 0; jh < 7; ++jh)
                                    cables.Segments.Add(new VerletSimulatedSegment(new Vector2((int)cables.Position.X * 16, (int)cables.Position.Y * 16), false));
                            }

                            cables.Segments[0].oldPosition = cables.Segments[0].position;
                            cables.Segments[0].position = new Vector2((int)cables.Position.X * 16, (int)cables.Position.Y * 16);

                            cables.Segments = VerletSimulatedSegment.SimpleSimulation(cables.Segments, 20);
                        }
                        if (cables.ArmSegmentsL != null)
                        {
                            for (int u = 1; u < cables.ArmSegmentsL.Count; u++)
                            {
                                VerletSimulatedSegment v = cables.ArmSegmentsL[u];
                                float rot = u == 0 ? 0f : v.position.DirectionTo(cables.ArmSegmentsL[u - 1].position).ToRotation() - MathHelper.PiOver2;
                                Texture2D s2u = Seg1;
                                switch (u)
                                {
                                    case 0:
                                        s2u = Seg1;
                                        break;
                                    case 1:
                                        s2u = ArmRU;
                                        break;
                                    case 2:
                                        s2u = ArmR;
                                        break;
                                }
                                Vector2 origine = new(0, s2u.Height / 2);
                                spriteBatch.Draw(s2u, v.position - Main.screenPosition - Vector2.UnitX * s2u.Width / 2 + weirdOffset, new(0, 0, s2u.Width, s2u.Height), Color.White, rot, origine, 1f, SpriteEffects.None, 0f);
                            }
                        }
                        if (cables.ArmSegmentsR != null)
                        {
                            for (int u = 1; u < cables.ArmSegmentsR.Count; u++)
                            {
                                VerletSimulatedSegment v = cables.ArmSegmentsR[u];
                                float rot = u == 0 ? 0f : v.position.DirectionTo(cables.ArmSegmentsR[u - 1].position).ToRotation() - MathHelper.PiOver4;
                                Texture2D s2u = Seg1;
                                switch (u)
                                {
                                    case 0:
                                        s2u = Seg1;
                                        break;
                                    case 1:
                                        s2u = ArmRU;
                                        break;
                                    case 2:
                                        s2u = ArmR;
                                        break;
                                }
                                Vector2 origine = new(s2u.Width, s2u.Height / 2);
                                spriteBatch.Draw(s2u, v.position - Main.screenPosition - Vector2.UnitX * s2u.Width / 2 + weirdOffset, new(0, 0, s2u.Width, s2u.Height), Color.White, rot, origine, 1f, SpriteEffects.FlipHorizontally, 0f);
                            }
                        }
                    }
                    else
                    {
                        Main.NewText("Cables was null");
                    }
                }
            }
        }
        public bool GetTEFromCoords(int i, int j, out SepulcherTubemanTE cable)
        {
            cable = new SepulcherTubemanTE();
            //for (int k = 0; k <= TileEntity.ByPosition.Count; k++)
            {
                if (TileEntity.ByPosition[new Point16(i, j)] == null)
                    return false;
                if (TileEntity.ByPosition[new Point16(i, j)].type == TileEntityType<SepulcherTubemanTE>())
                {
                    if (TileEntity.ByPosition[new Point16(i, j)].Position == new Point16(i, j))
                    {
                        cable = TileEntity.ByPosition[new Point16(i, j)] as SepulcherTubemanTE;
                        return true;
                    }
                }
            }
            cable = new SepulcherTubemanTE();
            return false;
        }
    }

    public class SepulcherTubemanTE : ModTileEntity
    {
        public List<VerletSimulatedSegment> Segments;
        public List<VerletSimulatedSegment> ArmSegmentsL;
        public List<VerletSimulatedSegment> ArmSegmentsR;
        public override bool IsTileValidForEntity(int x, int y)
        {
            Tile tile = Main.tile[x, y];
            return tile.HasTile && tile.TileType == TileType<SePlaced>();
        }
        public override int Hook_AfterPlacement(int i, int j, int type, int style, int direction, int alternate)
        {
            TileObjectData tileData = TileObjectData.GetTileData(type, style, alternate);

            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                //Sync the entire multitile's area. 
                NetMessage.SendTileSquare(Main.myPlayer, i, j, tileData.Width, tileData.Height);

                //Sync the placement of the tile entity with other clients
                NetMessage.SendData(MessageID.TileEntityPlacement, -1, -1, null, i, j, Type);

                return -1;
            }

            int placedEntity = Place(i, j);

            return placedEntity;
        }

        public override void OnNetPlace()
        {
            NetMessage.SendData(MessageID.TileEntitySharing, -1, -1, null, ID, Position.X, Position.Y);
        }

        public override void Update()
        {
            if (Segments is null || Segments.Count < 11)
            {
                Segments = new List<VerletSimulatedSegment>();
                for (int i = 0; i < 11; ++i)
                    Segments.Add(new VerletSimulatedSegment(new Vector2((int)Position.X * 16, (int)Position.Y * 16), false));
            }
            if (ArmSegmentsL is null || ArmSegmentsL.Count < 3)
            {
                ArmSegmentsL = new List<VerletSimulatedSegment>();
                for (int i = 0; i < 3; ++i)
                    ArmSegmentsL.Add(new VerletSimulatedSegment(new Vector2((int)Position.X * 16, (int)Position.Y * 16), false));
            }
            if (ArmSegmentsR is null || ArmSegmentsR.Count < 3)
            {
                ArmSegmentsR = new List<VerletSimulatedSegment>();
                for (int i = 0; i < 3; ++i)
                    ArmSegmentsR.Add(new VerletSimulatedSegment(new Vector2((int)Position.X * 16, (int)Position.Y * 16), false));
            }

            char numbo = Position.X.ToString()[(short)(Position.X.ToString().Length - 1)];
            double num = char.GetNumericValue(numbo);
            if (num < 4)
            {
                num += 4;
            }
            Segments[Segments.Count - 7].oldPosition = Segments[Segments.Count - 7].position;
            Segments[Segments.Count - 7].position = new Vector2(Position.X * 16, Position.Y * 16) + Vector2.UnitX * (float)Math.Sin(Main.GlobalTimeWrappedHourly * num) * 92 + Main.windSpeedCurrent * 100 * Vector2.UnitX - Vector2.UnitY * 140 + Vector2.UnitY * Math.Abs((float)Math.Cos(Main.GlobalTimeWrappedHourly * 6)) * 42;
            Segments[0].locked = true;
            Segments[0].oldPosition = Segments[0].position;
            Segments[0].position = new Vector2((int)Position.X * 16, (int)Position.Y * 16);

            ArmSegmentsL[0].locked = true;
            ArmSegmentsR[0].locked = true;

            ArmSegmentsL[0].oldPosition = Segments[Segments.Count - 5].oldPosition;
            ArmSegmentsL[0].position = Segments[Segments.Count - 5].position;

            ArmSegmentsR[0].oldPosition = Segments[Segments.Count - 5].oldPosition;
            ArmSegmentsR[0].position = Segments[Segments.Count - 5].position;

            Segments = VerletSimulatedSegment.SimpleSimulation(Segments, 16, loops: 22, gravity : - 0.9f);
            ArmSegmentsR = VerletSimulatedSegment.SimpleSimulation(ArmSegmentsR, 30, loops: 10, gravity: -0.2f);
            ArmSegmentsL = VerletSimulatedSegment.SimpleSimulation(ArmSegmentsL, 30, loops: 10, gravity: 0.2f);
        }
    }
}