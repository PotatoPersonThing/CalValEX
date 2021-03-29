using CalValEX.Projectiles.Pets;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Buffs.Pets
{
    public class TUBBUFF : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("T.U.B");
            Description.SetDefault("A tentacle monster is following you");
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().tub = true;
            bool petProjectileNotSpawned = player.ownedProjectileCounts[ModContent.ProjectileType<TUB>()] <= 0;
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<TUB>(), 0, 0f, player.whoAmI);
            }
        }
    }
}