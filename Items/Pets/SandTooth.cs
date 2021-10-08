using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{
    public class SandTooth : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Slightly Moist, but also Slightly Dry Locket");
            Tooltip.SetDefault("'There's a worm wriggling in it'\n" + "Summons a Slightly Moisturized Pest");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.ZephyrFish);
            item.UseSound = SoundID.NPCHit13;
            item.shoot = mod.ProjectileType("MoistScourgeHead");
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = 2;
            item.buffType = mod.BuffType("MoistScourgeBuff");
        }

        public override void UseStyle(Player player)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(item.buffType, 3600, true);
            }
        }

        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            type = mod.ProjectileType("MoistScourgeHead");
            return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }
    }
}