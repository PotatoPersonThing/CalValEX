using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.ObjectData;

namespace CalValEX.Tiles.MiscFurniture
{
    public class TerminusShrinePlaced : ModTile
	{
		public override void SetStaticDefaults()
		{
            TileID.Sets.DisableSmartCursor[Type] = true;
			Main.tileFrameImportant[Type] = true;
			Main.tileLighted[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
			TileObjectData.newTile.Width = 4;
			TileObjectData.newTile.Height = 3;
			TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };
			TileObjectData.addTile(Type);
			AnimationFrameHeight = 54;
			LocalizedText name = CreateMapEntryName();
			// name.SetDefault("Terminus Shrine");
			AddMapEntry(new Color(113, 142, 162), name);
		}

		public override void KillMultiTile(int i, int j, int TileFrameX, int TileFrameY)
		{
			/*if (l2)
            {
				Item.NewItem(new Terraria.DataStructures.EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 16, ModLoader.GetMod("CalamityMod").ItemType("BossRush"), 1);
			}
			if (l3)
			{
				Item.NewItem(new Terraria.DataStructures.EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 16, ModLoader.GetMod("CalamityMod").ItemType("Rock"), 1);
			}
			l2 = false;
			l3 = false;*/
		}

		/*private int count;
		private int rotation;
		private float stonepos;
		private bool l2;
		private bool l3;
		public override void PlaceInWorld(int i, int j, Item item)
		{
			stonepos = -1.00001f;
			l2 = false;
			l3 = false;
		}
		public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
		{
			if (l3)
            {
				rotation++;
				rotation++;
				CalValEXWorld.RockshrinEX = true;
			}
			else
			{
				CalValEXWorld.RockshrinEX = false;
			}
			rotation++;
			if (stonepos <= -1)
			{
				stonepos = stonepos * 0.01f;
			}
			else if (stonepos >= 1)
            {
				stonepos = stonepos * -0.01f;
            }
			Texture2D auraTexture = mod.GetTexture("Tiles/MiscFurniture/TerminusShrineStone_Aura");
			Texture2D stoneTexture = mod.GetTexture("Tiles/MiscFurniture/TerminusShrineStone");
			Rectangle sourceRectangle = new Rectangle(0, 0, auraTexture.Width, auraTexture.Height);
			Rectangle stoneRectangle = new Rectangle(0, 0, stoneTexture.Width, stoneTexture.Height);
			Vector2 zero = Main.drawToScreen ? Vector2.Zero : new Vector2(Main.offScreenRange);
			Vector2 position = new Vector2((i * 16) - 16 - Main.screenPosition.X, (j * 16) - 36 - Main.screenPosition.Y) + zero;
			Vector2 stoneposition = new Vector2((i * 16) - 4 - Main.screenPosition.X + stonepos, (j * 16) - 29 - Main.screenPosition.Y) + zero;
			Color color = Color.White;
			Tile tile = Main.tile[i, j];
			Vector2 origin = new Vector2(auraTexture.Width, auraTexture.Height);

			if (!tile.halfBrick() && tile.slope() == 0)
			{
				if (l2)
				{
					if (count == 11)
					{
						spriteBatch.End();
						spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied);
						spriteBatch.Draw(auraTexture, position, sourceRectangle, color, rotation * 0.01f, origin / 2f, 1f, SpriteEffects.None, 0f);
						spriteBatch.Draw(stoneTexture, stoneposition, stoneRectangle, color, 0f, origin / 2f, 1f, SpriteEffects.None, 0f);
					}
				}
			}
			count++;
			if (count >= 12)
				count = 0;
			//spriteBatch.Draw(texture, this.Center - Main.screenPosition, sourceRectangle, lightColor, rotation, origin / 2f, 1f, SpriteEffects.None, 0);
		}*/

		/*public override bool HasSmartInteract()
		{
			return true;
		}*/

		public override void AnimateTile(ref int frame, ref int frameCounter)
		{
			//if (!l2)
				frame = 0;
			//else if (l3)
				//frame = 2;
			//else if (l2)
				//frame = 1;
		}

		/*public override void MouseOver(int i, int j)
		{
			if (!l2)
			{
				Player localPlayer = Main.LocalPlayer;
				localPlayer.noThrow = 2;
				localPlayer.showItemIcon = true;
				localPlayer.showItemIcon2 = ModLoader.GetMod("CalamityMod").ItemType("BossRush");
			}
			else if (!l3)
			{
				Player localPlayer = Main.LocalPlayer;
				localPlayer.noThrow = 2;
				localPlayer.showItemIcon = true;
				localPlayer.showItemIcon2 = ModLoader.GetMod("CalamityMod").ItemType("Rock");
			}
		}*/

		/*public override bool NewRightClick(int i, int j)
		{
			Player localPlayer = Main.LocalPlayer;
			if (!l2 && localPlayer.HasItem(ModLoader.GetMod("CalamityMod").ItemType("BossRush")))
			{
				localPlayer.ConsumeItem(ModLoader.GetMod("CalamityMod").ItemType("BossRush"));
				l2 = true;
				Vector2 eyel = new Vector2(i + 10, j + 10);
				Vector2 eyer = new Vector2(i + 20, j + 10);
				Dust dust;
				for (int x = 0; x < 20; x++)
				{
					dust = Main.dust[Terraria.Dust.NewDust(eyel, 1, 1, 258, 4.736842f, -2.368421f, 0, new Color(255, 255, 255), 0.9210526f)];
					dust = Main.dust[Terraria.Dust.NewDust(eyer, 1, 1, 258, -4.736842f, -2.368421f, 0, new Color(255, 255, 255), 0.9210526f)];
				}
			}
			else if (l2 && localPlayer.HasItem(ModLoader.GetMod("CalamityMod").ItemType("Rock")))
			{
				l3 = true;
				localPlayer.ConsumeItem(ModLoader.GetMod("CalamityMod").ItemType("Rock"));
				Main.PlaySound(SoundID.Item119);
				Vector2 eyel = new Vector2(i + 10, j + 10);
				Vector2 eyer = new Vector2(i + 20, j + 10);
				Dust dust;
				for (int x = 0; x < 20; x++)
				{
					dust = Main.dust[Terraria.Dust.NewDust(eyel, 1, 1, 258, 4.736842f, -2.368421f, 0, new Color(255, 255, 255), 0.9210526f)];
					dust = Main.dust[Terraria.Dust.NewDust(eyer, 1, 1, 258, -4.736842f, -2.368421f, 0, new Color(255, 255, 255), 0.9210526f)];
				}
			}
			else if (l3)
            {
				l3 = false;
				Item.NewItem(new Terraria.DataStructures.EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 16, ModLoader.GetMod("CalamityMod").ItemType("Rock"), 1);
			}
			else if (l2 && !localPlayer.HasItem(ModLoader.GetMod("CalamityMod").ItemType("BossRush")))
            {
				l2 = false;
				Item.NewItem(new Terraria.DataStructures.EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 16, ModLoader.GetMod("CalamityMod").ItemType("BossRush"), 1);
            }
			return true;
		}*/
	}
}