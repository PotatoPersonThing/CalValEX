using Terraria;
using Terraria.ModLoader;
using CalValEX.Projectiles.Pets.LightPets;

namespace CalValEX.Buffs.LightPets {
    public class DiggerBuff : ModBuff {
        public override void SetStaticDefaults() {
            Main.buffNoTimeDisplay[Type] = true;
            Main.lightPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex) {
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().digger = true;
            bool petProjectileNotSpawned = player.ownedProjectileCounts[ModContent.ProjectileType<DiggerPet>()] <= 0;
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer) {
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + player.width / 2,
                    player.position.Y + player.height / 2, 0f, 0f, ModContent.ProjectileType<DiggerPet>(), 0, 0f, player.whoAmI);
            }
        }
    }
}