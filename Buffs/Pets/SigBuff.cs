using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Buffs.Pets
{
    public class SigBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Cloak and Dagger");
            Description.SetDefault("The Ethereal Assassin will watch your back... probably.");
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().SignusMini = true;
            bool petProjectileNotSpawned = player.ownedProjectileCounts[mod.ProjectileType("SignusMini")] <= 0;
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, mod.ProjectileType("SignusMini"), 0, 0f, player.whoAmI);
            }
        }
    }
}