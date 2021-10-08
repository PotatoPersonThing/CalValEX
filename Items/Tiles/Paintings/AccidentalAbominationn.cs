using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.ID; using CalValEX.Tiles.Paintings;
using Terraria.ModLoader;

namespace CalValEX.Items.Tiles.Paintings
{
    public class AccidentalAbominationn : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Accidental Abomination");
            Tooltip.SetDefault("'Mathew Maple'");
        }

        public override void SetDefaults()
        {
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTurn = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.autoReuse = true;
            item.maxStack = 99;
            item.consumable = true;
            item.createTile = ModContent.TileType<AccidentalAbominationnPlaced>();
            item.width = 12;
            item.height = 12;
            item.rare = 11;
        }
    }
}