using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Buffs.Pets
{
    public class CrabBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Fungal Crab");
            Description.SetDefault("They're a pretty Fun-Gi");
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().SmolCrab = true;
            bool petProjectileNotSpawned = player.ownedProjectileCounts[mod.ProjectileType("SmolCrab")] <= 0;
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("SmolCrab"), 0, 0f, player.whoAmI, 0f, 0f);
            }
        }
    }
}