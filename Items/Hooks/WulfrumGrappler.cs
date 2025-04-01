using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace CalValEX.Items.Hooks
{
    public class WulfrumGrappler : ModItem
    {
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.BatHook);
            Item.shootSpeed = 8f;
            Item.shoot = ProjectileType<WulfrumGrapplerHook>();
            Item.rare = ItemRarityID.Blue;
        }
    }
}