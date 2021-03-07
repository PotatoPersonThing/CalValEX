using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Buffs.Pets
{
    public class DEBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Dark Aura");
            Description.SetDefault("An aura of pure nothingness floats near you.");
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().VoidOrb = true;
            bool petProjectileNotSpawned = player.ownedProjectileCounts[mod.ProjectileType("VoidOrb")] <= 0;
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("VoidOrb"), 0, 0f, player.whoAmI, 0f, 0f);
            }
        }
    }
}