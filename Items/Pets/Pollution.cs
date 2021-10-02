using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{
    public class Pollution : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Inky Pollution");
            Tooltip.SetDefault("Tis a shame what we do to the environment\n" + "Summons a baby squid");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.ZephyrFish);
            item.UseSound = SoundID.NPCHit25;
            item.shoot = mod.ProjectileType("BabySquid");
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = 5;
            item.buffType = mod.BuffType("BabySquidBuff");
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
            type = mod.ProjectileType("BabySquid");
            return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }
    }
}