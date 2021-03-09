using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.AprilFools
{
    public class AmogusItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stratus Astronaut");
            Tooltip
                .SetDefault("'amogus'");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(4, 4));
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 36;
            item.CloneDefaults(ItemID.ZephyrFish);
            item.UseSound = SoundID.NPCHit33;
            item.shoot = mod.ProjectileType("Amogus");
            item.value = Item.sellPrice(0, 0, 0, 0);
            item.rare = 10;
            item.buffType = mod.BuffType("AmogusBuff");
            item.noUseGraphic = true;
            item.expert = true;
        }

        public override void UseStyle(Player player)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(item.buffType, 3600, true);
            }
        }
    }
}