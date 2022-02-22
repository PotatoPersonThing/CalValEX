using Terraria.ModLoader;
using Terraria.ID;
using CalValEX.Tiles.MiscFurniture;

namespace CalValEX.Items.Tiles
{
    public class DecommissionedDaedalusGolem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Decommissioned Daedalus Golem");
            Tooltip.SetDefault("'4.3%...'");
        }

        public override void SetDefaults()
        {
            item.useStyle = 1;
            item.useTurn = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.autoReuse = true;
            item.maxStack = 99;
            item.consumable = true;
            item.createTile = ModContent.TileType<DecommissionedDaedalusGolemPlaced>();
            item.width = 48;
            item.height = 32;
            item.rare = 5;
        }
    }
}