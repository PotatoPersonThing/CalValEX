using Terraria.ModLoader;
using Terraria.ID;
using CalValEX.Tiles.MiscFurniture;

namespace CalValEX.Items.Tiles
{
    public class PongMachine : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pong Machine");
            Tooltip.SetDefault("INCOMPLETE ITEM, EXTREMELY UNSTABLE\nPong game");
            SacrificeTotal = 1;
        }

        public override void SetDefaults()
        {
            Item.useStyle = 1;
            Item.useTurn = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.autoReuse = true;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<PongMachinePlaced>();
            Item.maxStack = 99;
            Item.width = 48;
            Item.height = 32;
            Item.rare = ItemRarityID.LightRed;
        }
    }
}