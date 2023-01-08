using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using CalamityMod.Projectiles.Magic;

namespace CalValEX.Projectiles
{
    [ExtendsFromMod("CalamityMod")]
    public class JharimKiller : SeethingDischargeBrimstoneHellblast
    {
        public override string Texture => "CalamityMod/Projectiles/Boss/BrimstoneHellblast";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eat crap Jharim");
            Main.projFrames[Projectile.type] = 4;
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 4;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Default;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
        }

        public override bool? CanHitNPC(NPC target)
        {
            if (target.type == ModContent.NPCType<AprilFools.Jharim.Jharim>())
            {
                return true;
            }
            else
            { 
                return false;
            }
        }

        public override bool CanHitPlayer(Player target)
        {
            return false;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (target.type == ModContent.NPCType<AprilFools.Jharim.Jharim>() && target.life <= 0)
            {
                CalValEXWorld.jharinter = true;
            }
        }
    }
}