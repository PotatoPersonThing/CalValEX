using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Buffs.Pets
{
    public class ChilledOut : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cool Dude");
            Description.SetDefault("A really cool dude will follow you around");
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 19000;
            player.GetModPlayer<CalValEXPlayer>().MiniCryo = true;
            bool petProjectileNotSpawned = (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.MiniCryo>()] <= 0);

            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.GetProjectileSource_Buff(buffIndex), player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.MiniCryo>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
        }
    }
}