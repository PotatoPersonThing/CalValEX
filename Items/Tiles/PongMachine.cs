using Terraria.ModLoader;
using Terraria.ID;
using CalValEX.Tiles.MiscFurniture;

namespace CalValEX.Items.Tiles
{
    internal class PongMachine : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pong Machine");
            Tooltip.SetDefault("INCOMPLETE ITEM, EXTREMELY UNSTABLE\nPong game");
        }

        public override void SetDefaults()
        {
            /*item.useStyle = 1;
            item.useTurn = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.autoReuse = true;
            item.consumable = true;
            item.createTile = ModContent.TileType<PongMachinePlaced>();*/
            item.maxStack = 99;
            item.width = 48;
            item.height = 32;
            item.rare = ItemRarityID.LightRed;
        }
    }
}