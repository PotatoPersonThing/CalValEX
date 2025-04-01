using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.ID; 
using CalValEX.Tiles.Paintings;
using Terraria.ModLoader;
using CalValEX.CalamityID;

namespace CalValEX.Items.Tiles.Paintings
{
    public class TheYhar : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault(":THE_YHAR:");
            // Tooltip.SetDefault("You gotta admit, he's a very cool dude despite his crimes");
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
            Item.createTile = ModContent.TileType<TheYharPlaced>();
            Item.width = 12;
            Item.height = 12;
            Item.rare = CalRarityID.HotPink;
        }
    }
}