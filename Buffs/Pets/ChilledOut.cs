using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Buffs.Pets
{
    public class ChilledOut : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 19000;
            player.GetModPlayer<CalValEXPlayer>().MiniCryo = true;
            int type = CalValEX.CalamityActive ? ModContent.ProjectileType<Projectiles.Pets.MiniCryo>() : ModContent.ProjectileType<Projectiles.Pets.MiniCryoCalless>();
            bool petProjectileNotSpawned = (player.ownedProjectileCounts[type] <= 0);

            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, type, 0, 0f, player.whoAmI, 0f, 0f);
            }
        }
    }
}