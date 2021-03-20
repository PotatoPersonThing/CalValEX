using CalValEX.Projectiles.Pets;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CalValEX.Buffs.Pets
{
    public class SepulcherBuff : ModBuff
    {
        public override void SetDefaults()
        {
            // DisplayName and Description are automatically set from the .lang files, but below is how it is done normally.
            DisplayName.SetDefault("Sepulchling");
            Description.SetDefault("A dark construct composed of the long deceased souls of the innocent...\nCute");
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().sepet = true;
            bool petProjectileNotSpawned = player.ownedProjectileCounts[ProjectileType<SepulcherHead>()] <= 0;
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ProjectileType<SepulcherHead>(), 0, 0f, player.whoAmI);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().BMonster = true;
            bool petProjectileNotSpawnedbm = player.ownedProjectileCounts[ProjectileType<BabyMonster>()] <= 0;
            if (petProjectileNotSpawnedbm && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ProjectileType<BabyMonster>(), 0, 0f, player.whoAmI);
            }

            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().hage = true;
            bool petProjectileNotSpawnedbh = player.ownedProjectileCounts[ProjectileType<BabyHage>()] <= 0;
            if (petProjectileNotSpawnedbh && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ProjectileType<BabyHage>(), 0, 0f, player.whoAmI);
            }

        }
    }
}