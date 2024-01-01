using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.ID;
using CalValEX.Tiles.MiscFurniture;
using Terraria.ModLoader;

namespace CalValEX.Items.Tiles
{
    public class Evolution : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Toy Evolution");
            /* Tooltip
                .SetDefault("'Pondering the orb...'"); */
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTurn = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.autoReuse = true;
            Item.maxStack = 99;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<EvolutionPlaced>();
            Item.width = 32;
            Item.height = 50;
            Item.rare = CalamityID.CalRarityID.Turquoise;
        }
    }
}