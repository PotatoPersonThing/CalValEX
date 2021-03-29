using CalValEX.Projectiles.Pets;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Buffs.Pets
{
    public class TopazBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Topaz Scuttler");
            Description.SetDefault("Still won't let go of its gem");
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().mTop = true;
            bool petProjectileNotSpawned = player.ownedProjectileCounts[ModContent.ProjectileType<TopazPet>()] <= 0;
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<TopazPet>(), 0, 0f, player.whoAmI);
            }
        }
    }
}