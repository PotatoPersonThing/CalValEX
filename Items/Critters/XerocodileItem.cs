using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.ID;
using CalValEX.NPCs.Critters;

namespace CalValEX.Items.Critters
{
    public class XerocodileItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 5;
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
            Item.height = 18;
            Item.noUseGraphic = true;
            Item.rare = ItemRarityID.Red;
            Item.makeNPC = (short)NPCType<Xerocodile>();
            Item.rare = CalamityID.CalRarityID.Turquoise;
        }
    }
}