using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Buffs.Pets.ExoMechs
{
    public class ExoMayhemBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Toy Exo Mechs");
            //Description.SetDefault("Perfected entertainment providers");
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().ares = true;
            player.GetModPlayer<CalValEXPlayer>().thanos = true;
            player.GetModPlayer<CalValEXPlayer>().twins = true;

            bool thanosNotHere = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.ExoMechs.ThanatosPet>()] <= 0;
            if (thanosNotHere && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.ExoMechs.ThanatosPet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool aresNotHere = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.ExoMechs.AresBody>()] <= 0;
            if (aresNotHere && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.ExoMechs.AresBody>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            bool twinsNotHere = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.ExoMechs.TwinsPet>()] <= 0;
            if (twinsNotHere && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.ExoMechs.TwinsPet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
        }
    }
}