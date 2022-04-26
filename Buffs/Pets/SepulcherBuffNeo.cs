using CalValEX.Projectiles.Pets.SepulcherNeo;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CalValEX.Buffs.Pets
{
    public class SepulcherBuffNeo : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().sepneo = true;
            bool petProjectileNotSpawned = player.ownedProjectileCounts[ProjectileType<SepulcherHeadNeo>()] <= 0;
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ProjectileType<SepulcherHeadNeo>(), 0, 0f, player.whoAmI);
            }
        }
    }
}