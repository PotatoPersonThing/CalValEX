using CalValEX.Projectiles.Pets;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Buffs.Pets
{
    public class StasisArmoredBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Armored Stasis Drone");
            Description.SetDefault("Dense as most anime protagonists");
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().mArmored = true;
            bool petProjectileNotSpawned =
                player.ownedProjectileCounts[ModContent.ProjectileType<StasisArmored>()] <= 0;
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2,
                    0f, 0f, ModContent.ProjectileType<StasisArmored>(), 0, 0f, player.whoAmI);
            }
        }
    }
}