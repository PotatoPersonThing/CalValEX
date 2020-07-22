using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Oracle
{
    public class OracleNPC_Cards : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Oracle Card");
        }

        public override void SetDefaults()
        {
            projectile.width = 26;
            projectile.height = 18;
            projectile.damage = 30;
            projectile.ignoreWater = false;
            projectile.tileCollide = true;
            projectile.friendly = true;
            projectile.penetrate = 3;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            int randNumb = Main.rand.Next(0, 6); //change this to higher or lower, depending on how many debuffs it can potentially inflict
            switch(randNumb)
            {
                case 0:
                    target.AddBuff(BuffID.OnFire, Main.rand.Next(300, 1200)); //5 to 25 seconds (each second is 60 ticks)
                    break;
                case 1:
                    target.AddBuff(BuffID.Poisoned, Main.rand.Next(300, 1200));
                    break;
                case 2:
                    target.AddBuff(BuffID.Confused, Main.rand.Next(300, 1200));
                    break;
                case 3:
                    target.AddBuff(BuffID.BrokenArmor, Main.rand.Next(300, 1200));
                    break;
                case 4:
                    target.AddBuff(BuffID.CursedInferno, Main.rand.Next(300, 1200));
                    break;
                default:
                    target.AddBuff(BuffID.Ichor, Main.rand.Next(300, 1200));
                    break;
            }
        }

        public override void AI()
        {
            projectile.ai[0]++;
            if (projectile.ai[0] > 60)
            {
                projectile.velocity.Y += 0.1f;
            }
            projectile.rotation = projectile.velocity.ToRotation();
        }
    }
}
