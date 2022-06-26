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
            SacrificeTotal = 5;
        }

        public override void SetDefaults()
        {
            Item.rare = 11;
            Item.CloneDefaults(ItemID.JuliaButterfly);
            Item.makeNPC = (short)NPCType<CrystalFly>();
            Item.bait = 45;
        }
    }
}