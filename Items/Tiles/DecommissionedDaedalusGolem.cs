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
            SacrificeTotal = 1;
        }

        public override void SetDefaults()
        {
            Item.useStyle = 1;
            Item.useTurn = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.autoReuse = true;
            Item.maxStack = 99;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<DecommissionedDaedalusGolemPlaced>();
            Item.width = 48;
            Item.height = 32;
            Item.rare = 5;
        }
    }
}