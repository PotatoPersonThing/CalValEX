using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX.NPCs.Critters;

namespace CalValEX.Items.Critters
{
    public class GoldenIsopodItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 5;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.GlowingSnail);
            Item.makeNPC = (short)NPCType<GoldenIsopod>();
            Item.value = Item.sellPrice(0, 20, 0, 0);
            Item.rare = CalamityID.CalRarityID.PureGreen;
        }
    }
}