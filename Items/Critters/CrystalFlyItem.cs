using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX.NPCs.Critters;

namespace CalValEX.Items.Critters
{
    public class CrystalFlyItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystal Butterfly");
        }

        public override void SetDefaults()
        {
            //Item.useStyle = 1;
            //Item.autoReuse = true;
            //Item.useTurn = true;
            //Item.useAnimation = 15;
            //Item.useTime = 10;
            //Item.maxStack = 999;
            //Item.consumable = true;
            //Item.width = 12;
            //Item.height = 12;
            //Item.makeNPC = 360;
            //Item.noUseGraphic = true;
            //Item.bait = 15;
            Item.rare = 11;
            Item.CloneDefaults(ItemID.JuliaButterfly);
            Item.makeNPC = (short)NPCType<CrystalFly>();
            Item.bait = 45;
        }
    }
}