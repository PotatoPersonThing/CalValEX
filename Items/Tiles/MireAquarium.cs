using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.ID;
using CalValEX.Tiles.MiscFurniture;
using Terraria.ModLoader;

namespace CalValEX.Items.Tiles
{
    public class MireAquarium : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Mire Aquarium");
            /* Tooltip
                .SetDefault("'Hopefully it doesn't try to break out...'"); */
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTurn = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.autoReuse = true;
            Item.maxStack = 9999;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<MireAquariumPlaced>();
            Item.width = 32;
            Item.height = 50;
            Item.rare = CalamityID.CalRarityID.PureGreen;
        }
    }
}