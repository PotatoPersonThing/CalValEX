using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Buffs.Pets
{
    public class Excalibuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Claidheamh Soluis");
            Description.SetDefault("You can't expect to wield supreme power just because some tart threw a sword at you!");
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().excal = true;
            bool petProjectileNotSpawned = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.WraithsExcalibur>()] <= 0;
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.GetProjectileSource_Buff(buffIndex), player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.WraithsExcalibur>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
        }
    }
}