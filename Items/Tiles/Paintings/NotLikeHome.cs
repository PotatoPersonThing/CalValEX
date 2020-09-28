using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.ModLoader;
using Terraria.ID;

namespace CalValEX.Items.Tiles.Paintings
{
    public class NotLikeHome : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Not Like Home");
            Tooltip.SetDefault("'Mathew Maple'\nFriends!");
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
            item.createTile = ModContent.TileType<NotLikeHomePlaced>();
            item.width = 12;
            item.height = 12;
            item.rare = 4;
        }
    }
}