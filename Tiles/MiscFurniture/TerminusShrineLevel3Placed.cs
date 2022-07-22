using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using CalValEX.Items.Tiles;
using Terraria.ObjectData;
//using CalamityMod;

namespace CalValEX.Tiles.MiscFurniture
{
	public class TerminusShrineLevel3Placed : ModTile
	{
		public override void SetStaticDefaults()
		{
			Terraria.ID.TileID.Sets.DisableSmartCursor[Type] = true;
			Main.tileFrameImportant[Type] = true;
			Main.tileLighted[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
			TileObjectData.newTile.Width = 4;
			TileObjectData.newTile.Height = 3;
			TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };
			TileObjectData.addTile(Type);
			AnimationFrameHeight = 54;
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Terminus Shrine");
			AddMapEntry(new Color(113, 142, 162), name);
		}

		public override void KillMultiTile(int i, int j, int TileFrameX, int TileFrameY)
		{
			Item.NewItem(new Terraria.DataStructures.EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 16, ModContent.ItemType<CalamityMod.Items.Rock>(), 1);
			Item.NewItem(new Terraria.DataStructures.EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 16, ModContent.ItemType<CalamityMod.Items.SummonItems.Terminus>(), 1);
			CalValEXPlayer modPlayer = Main.LocalPlayer.GetModPlayer<CalValEXPlayer>();
			CalValEXWorld.RockshrinEX = false;
			Item.NewItem(new Terraria.DataStructures.EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 16, ModContent.ItemType<TerminusShrine>());
		}

		private int count;
		private int rotation;
		private float stonepos;
		public override void PlaceInWorld(int i, int j, Item item)
		{
			stonepos = -1.00001f;
			CalValEXWorld.RockshrinEX = true;
		}
		public override void NearbyEffects(int i, int j, bool closer)
		{
			CalValEXWorld.RockshrinEX = true;
		}
		public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
		{
			Tile tile = Main.tile[i, j];
			if (tile.TileFrameX == 0 && tile.TileFrameY == 0)
			{
				CalValEXWorld.RockshrinEX = true;
				rotation += 30;
				if (stonepos <= -6)
				{
					stonepos = stonepos * 0.001f;
				}
				else if (stonepos >= 6)
				{
					stonepos = stonepos * -0.001f;
				}
				Texture2D auraTexture = ModContent.Request<Texture2D>("CalValEX/Tiles/MiscFurniture/TerminusShrineStone_Aura").Value;
				Texture2D stoneTexture = ModContent.Request<Texture2D>("CalValEX/Tiles/MiscFurniture/TerminusShrineStone").Value;
				Rectangle sourceRectangle = new Rectangle(0, 0, auraTexture.Width, auraTexture.Height);
				Rectangle stoneRectangle = new Rectangle(0, 0, stoneTexture.Width, stoneTexture.Height);
				Vector2 zero = Main.drawToScreen ? Vector2.Zero : new Vector2(Main.offScreenRange);
				Vector2 position = new Vector2((i * 16) + 31 - Main.screenPosition.X, (j * 16) - 16 - Main.screenPosition.Y) + zero;
				Vector2 stoneposition = new Vector2((i * 16) + 43 - Main.screenPosition.X + stonepos, (j * 16) - 10 - Main.screenPosition.Y) + zero;
				Color color = Color.White;
				Vector2 origin = new Vector2(auraTexture.Width, auraTexture.Height);

				//if (!tile.halfBrick() && tile.slope() == 0)
				{
						spriteBatch.End();
						spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied);
					spriteBatch.Draw(auraTexture, position, sourceRectangle, color, Main.GlobalTimeWrappedHourly * 4f, origin / 2f, 1f, SpriteEffects.None, 0f);
					spriteBatch.Draw(stoneTexture, stoneposition, stoneRectangle, color, 0f, origin / 2f, 1f, SpriteEffects.None, 0f);
				}
				count++;
				//spriteBatch.Draw(texture, this.Center - Main.screenPosition, sourceRectangle, lightColor, rotation, origin / 2f, 1f, SpriteEffects.None, 0);
			}
		}

		public override void AnimateTile(ref int frame, ref int frameCounter)
		{
			frame = 2;
		}
	}
}