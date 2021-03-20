using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{
    public class OldTennisBall : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Old Tennis Ball");
            Tooltip.SetDefault("'They used to be everywhere at one point.'");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.ZephyrFish);
            item.UseSound = SoundID.NPCHit29;
            item.shoot = mod.ProjectileType("Buppy");
            item.value = Item.sellPrice(0, 0, 0, 30);
            item.rare = 1;
            item.buffType = mod.BuffType("BuppyBuff");
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
            type = mod.ProjectileType("Buppy");
            return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }
    }
}