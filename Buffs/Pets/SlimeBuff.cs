using CalValEX.Projectiles.Pets;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Buffs.Pets
{
    public class SlimeBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().mSlime = true;
            bool petProjectileNotSpawned = player.ownedProjectileCounts[ModContent.ProjectileType<SlimeDemi>()] <= 0;
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<SlimeDemi>(), 0, 0f, player.whoAmI);
            }
        }
    }
}