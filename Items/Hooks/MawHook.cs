using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace CalValEX.Items.Hooks
{
    public class MawHook : ModItem {
        public override void SetStaticDefaults() => Item.ResearchUnlockCount = 1;

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.BatHook);
            Item.shootSpeed = 18f;
            Item.shoot = ProjectileType<MawTeeth>();
            Item.rare = CalamityID.CalRarityID.PureGreen;
        }
    }
}