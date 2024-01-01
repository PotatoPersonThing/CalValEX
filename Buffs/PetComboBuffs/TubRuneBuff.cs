using Terraria;
using Terraria.ModLoader;
using CalValEX.Projectiles.Pets;

namespace CalValEX.Buffs.PetComboBuffs
{
    public class TubRuneBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;

            player.GetModPlayer<CalValEXPlayer>().TubRune = true;
            player.GetModPlayer<CalValEXPlayer>().CalamityBABYBool = true;
            player.GetModPlayer<CalValEXPlayer>().bSignut = true;
            player.GetModPlayer<CalValEXPlayer>().bSlime = true;
            player.GetModPlayer<CalValEXPlayer>().goozmaPet = true;
            player.GetModPlayer<CalValEXPlayer>().uSerpent = true;
            player.GetModPlayer<CalValEXPlayer>().sirember = true;

            bool petProjectileNotSpawnedA = player.ownedProjectileCounts[ModContent.ProjectileType<CalamityBABY>()] <= 0;
            if (petProjectileNotSpawnedA && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<CalamityBABY>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedBA = player.ownedProjectileCounts[ModContent.ProjectileType<CoolBlueSignut>()] <= 0;
            if (petProjectileNotSpawnedBA && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<CoolBlueSignut>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            bool petProjectileNotSpawnedBB = player.ownedProjectileCounts[ModContent.ProjectileType<CoolBlueSlime>()] <= 0;
            if (petProjectileNotSpawnedBB && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<CoolBlueSlime>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedC = player.ownedProjectileCounts[ModContent.ProjectileType<GoozmaPet>()] <= 0;
            if (petProjectileNotSpawnedC && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<GoozmaPet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedD = player.ownedProjectileCounts[ModContent.ProjectileType<UngodlySerpent>()] <= 0;
            if (petProjectileNotSpawnedD && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<UngodlySerpent>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool petProjectileNotSpawnedE = player.ownedProjectileCounts[ModContent.ProjectileType<Sirember>()] <= 0;
            if (petProjectileNotSpawnedE && player.whoAmI == Main.myPlayer){
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ModContent.ProjectileType<Sirember>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
        }
    }
}