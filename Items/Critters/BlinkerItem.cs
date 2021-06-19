using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CalValEX.Items.Critters
{
    internal class BlinkerItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blinker");
        }

        public override void SetDefaults()
        {
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.autoReuse = true;
            item.useTurn = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.maxStack = 999;
            item.consumable = true;
            item.width = 22;
            item.height = 24;
            item.noUseGraphic = true;
            item.makeNPC = (short)NPCType<Blinker>();
            item.rare = ItemRarityID.Lime;
        }
    }
}