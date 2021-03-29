using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Buffs.LightPets
{
    public class LightshieldBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Arctic Shield");
            Description.SetDefault("You've mastered the spin!");
            Main.buffNoTimeDisplay[Type] = true;
            Main.lightPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().Lightshield = true;
            bool petProjectileNotSpawned = player.ownedProjectileCounts[mod.ProjectileType("Lightshield")] <= 0;
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, mod.ProjectileType("Lightshield"), 0, 0f, player.whoAmI);
            }
        }
    }
}