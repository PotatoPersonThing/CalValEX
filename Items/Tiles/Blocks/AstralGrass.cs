using Terraria;
using Terraria.ModLoader;
using Terraria.Audio;
using CalValEX.Tiles.AstralBlocks;
using Terraria.ID;

namespace CalValEX.Items.Tiles.Blocks
{
    public class AstralGrass : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Blighted Astral Grass Seeds");
			// Tooltip.SetDefault("Places grass on blighted astral dirt");
		}
		public override void SetDefaults()
		{
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.consumable = true;
			Item.width = Item.height = 16;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.maxStack = 999;
		}

		public override bool? UseItem(Player player)
		{
			Tile tile = Framing.GetTileSafely(Player.tileTargetX, Player.tileTargetY);
			
			if (tile.HasTile && tile.TileType == ModContent.TileType<AstralDirtPlaced>() && player.IsInTileInteractionRange(Player.tileTargetX, Player.tileTargetY, Terraria.DataStructures.TileReachCheckSettings.Simple))
			{
				Main.tile[Player.tileTargetX, Player.tileTargetY].TileType = (ushort)ModContent.TileType<AstralGrassPlaced>();

				SoundEngine.PlaySound(SoundID.Dig, player.Center);

				return true;
			}

			return false;
		}
    }
}