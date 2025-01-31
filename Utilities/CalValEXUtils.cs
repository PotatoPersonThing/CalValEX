using Terraria;

namespace CalValEX
{
    public class CVUtils
    {
        public static void PetBuff(Player player, int buffIndex, int projType, int amount = 1)
        {
            bool petProjectileNotSpawned = player.ownedProjectileCounts[projType] < amount;
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, projType, 0, 0f, player.whoAmI, 0f, 0f);
            }
        }
    }
}