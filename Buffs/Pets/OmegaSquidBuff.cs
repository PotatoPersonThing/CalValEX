using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Buffs.Pets
{
    public class OmegaSquidBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().oSquid = true;
            bool petProjectileNotSpawned = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.OmegaCultistTrident>()] <= 0;
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.OmegaCultistTrident>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            bool petProjectileNotSpawned2 = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.OmegaCultistCandle>()] <= 0;
            if (petProjectileNotSpawned2 && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.OmegaCultistCandle>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
        }
    }
}