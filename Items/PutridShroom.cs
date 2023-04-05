using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items
{
    public class PutridShroom : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Aromatic Shroom");
            Item.ResearchUnlockCount = 1;
            // Tooltip.SetDefault("Causes the great fungus crab's Crab Shrooms to become passive, but also enrage upon defeat\n" + "Keeps the small fungal crab on your head, even when moving\n" + "'Smells like cheese...?'");
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 36;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.maxStack = 1;
            Item.rare = ItemRarityID.Blue;
        }
    }
}