using Terraria.ModLoader;
using CalValEX.Tiles.Balloons;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace CalValEX.Items.Tiles.Balloons
{
    public class TiedChaosBalloon : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Tied Chaos Balloon");
            Item.ResearchUnlockCount = 1;
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
            Item.createTile = ModContent.TileType<TiedChaosBalloonPlaced>();
            Item.width = 16;
            Item.height = 40;
            Item.rare = 6;
        }
    }
}