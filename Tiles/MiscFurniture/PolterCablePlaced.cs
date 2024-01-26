using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.ObjectData;
namespace CalValEX.Tiles.MiscFurniture
{
    public class PolterCablePlaced : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileSolid[Type] = false;
            Main.tileLighted[Type] = true;

            DustType = -1;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.UsesCustomCanPlace = true;
            TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(ModContent.GetInstance<PolterCableTE>().Hook_AfterPlacement, -1, 0, false);

            TileObjectData.addTile(Type);

            LocalizedText name = CreateMapEntryName();

            AddMapEntry(new Color(200, 200, 200), name);
        }
        public override void PlaceInWorld(int i, int j, Item item)
        {
            PolterCableTE.UpdateHooks();
        }
        public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            ModContent.GetInstance<PolterCableTE>().Kill(i, j);
            PolterCableTE.UpdateHooks();
        }
        public override bool PreDraw(int i, int j, SpriteBatch spriteBatch)
        {
            DrawChains(spriteBatch, i, j);
            return true;
        }

        public bool GetCableFromCoords(int i, int j, out PolterCableTE cable)
        {
            for (int k = 0; k <= TileEntity.ByID.Keys.Max(); k++)
            {
                if (!TileEntity.ByID.ContainsKey(k))
                    continue;
                if (TileEntity.ByID[k] == null)
                    continue;
                if (TileEntity.ByID[k].type == ModContent.TileEntityType<PolterCableTE>())
                {
                    if (TileEntity.ByID[k].Position == new Point16(i, j))
                    {
                        cable = TileEntity.ByID[k] as PolterCableTE;
                        return true;
                    }
                }
            }
            cable = new PolterCableTE();
            return false;
        }

        public void DrawChains(SpriteBatch sb, int i, int j)
        {
            Tile tile = Main.tile[i, j];

            PolterCableTE cables = new PolterCableTE();
            if (tile.TileFrameX == 0 && tile.TileFrameY == 0)
            {
                GetCableFromCoords(i, j, out cables);
                var entity = cables;

                foreach (PolterCableTE k in PolterCableTE.chains)
                {
                    if (k == null)
                        continue;
                    if (!Main.tile[k.Position.X, k.Position.Y].HasTile)
                        continue;
                    if (Main.tile[k.Position.X, k.Position.Y].TileType != ModContent.TileType<PolterCablePlaced>())
                        continue;
                    PolterCableTE cable = k;
                    if ((cable.channel == entity.channel && k.ID <= entity.ID && cable.channel != 0) || cable.toChainedCords.Contains((entity.Position.X, entity.Position.Y)))
                    {
                        int offset = 196;
                        Vector2 myPosition = entity.Position.ToVector2() * 16 + new Vector2(offset, offset);
                        Vector2 theirPosition = cable.Position.ToVector2() * 16 + new Vector2(offset, offset);
                        if ((theirPosition == new Vector2(offset, offset)) || myPosition == new Vector2(offset, offset))
                            continue;
                        //if (theirPosition.Distance(myPosition) > 1100)
                        // continue;
                        float projRotation = myPosition.AngleTo(theirPosition) - 1.57f;
                        bool doIDraw = true;
                        Texture2D texture = ModContent.Request<Texture2D>("CalValEX/Items/Tiles/PolterCable").Value; //change this accordingly to your chain texture

                        while (doIDraw)
                        {
                            float distance = (myPosition - theirPosition).Length();
                            if (distance < (texture.Height + 1))
                            {
                                doIDraw = false;
                            }
                            else if (!float.IsNaN(distance))
                            {
                                int colType = Main.tile[i, j].TileColor;
                                Color paintCol = WorldGen.paintColor(colType);
                                if (colType >= 13 && colType <= 24)
                                {
                                    paintCol.R = (byte)(paintCol.R / 255f * Color.White.R);
                                    paintCol.G = (byte)(paintCol.G / 255f * Color.White.G);
                                    paintCol.B = (byte)(paintCol.B / 255f * Color.White.B);
                                }
                                myPosition += myPosition.DirectionTo(theirPosition) * texture.Height;
                                sb.Draw(texture, myPosition - Main.screenPosition,
                                    new Rectangle(0, 0, texture.Width, texture.Height), paintCol, projRotation,
                                    Utils.Size(texture) / 2f, 1f, SpriteEffects.None, 0);
                            }
                        }
                    }
                }
            }
        }
    }
    public class PolterCableTE : ModTileEntity
    {
        public int channel { get; set; } = 0;
        public static List<PolterCableTE> chains = new List<PolterCableTE> ();
        public List<(int, int)> toChainedCords = new List<(int, int)> ();
        public override bool IsTileValidForEntity(int x, int y)
        {
            Tile tile = Main.tile[x, y];
            return tile.HasTile && tile.TileType == ModContent.TileType<PolterCablePlaced>();
        }
        public override void Update()
        {
            if (chains.Count <= 0)
            {
                UpdateHooks();
            }
            if (!chains.Contains(this))
            {
                chains.Add(this);
            }
            for (int i = 0; i < toChainedCords.Count; i++)
            {
                (int, int) pair = toChainedCords[i];
                Point16 tileMouse = new Point16(pair.Item1, pair.Item2);
                if (!ByPosition.ContainsKey(tileMouse))
                {
                    toChainedCords.Remove(pair);
                }
                else
                {
                    if (ByPosition[tileMouse].type != ModContent.TileEntityType<PolterCableTE>())
                    {
                        toChainedCords.Remove(pair);
                    }
                }
            }
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

        public static void UpdateHooks()
        {
            chains.Clear();
            if (ByID.Count != 0)
            for (int k = 0; k < ByID.Keys.Max(); k++)
            {
                if (!ByID.ContainsKey(k))
                    continue;
                if (ByID[k] == null)
                    continue;
                if (ByID[k].type != ModContent.TileEntityType<PolterCableTE>())
                    continue;
                PolterCableTE c = ByID[k] as PolterCableTE;
                chains.Add(c);
            }
        }
        public override void SaveData(TagCompound tag)
        {
            tag["Poltchannel"] = channel;
            List<int> xcords = new List<int>();
            List<int> ycords = new List<int>();
            foreach ((int, int) pair in toChainedCords)
            {
                xcords.Add(pair.Item1);
                ycords.Add(pair.Item2);
            }
            tag["PoltchaincordsX"] = xcords;
            tag["PoltchaincordsY"] = ycords;

        }
        public override void LoadData(TagCompound tag)
        {
            List<int> xcords;
            List<int> ycords;
            channel = tag.Get<int>("Poltchannel");
            xcords = tag.Get<List<int>>("PoltchaincordsX");
            ycords = tag.Get<List<int>>("PoltchaincordsY");
            for (int i = 0; i < xcords.Count; i++)
            {
                toChainedCords.Add((xcords[i], ycords[i]));
            }
        }
    }
}