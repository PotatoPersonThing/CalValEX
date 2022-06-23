using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX.NPCs.Critters;

namespace CalValEX.Items.Critters
{
    public class AstJRItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Astragelly Slime");
        }

        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Swing;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.maxStack = 999;
            Item.consumable = true;
            Item.width = 22;
            Item.height = 20;
            Item.noUseGraphic = true;
            Item.makeNPC = (short)NPCType<AstJR>();
            Item.rare = ItemRarityID.Lime;
        }
    }
}