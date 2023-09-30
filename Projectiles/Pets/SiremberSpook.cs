using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.IO;

namespace CalValEX.Projectiles.Pets
{
    public class SiremberSpook : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Giant Decapitated Floating Siren Head");
            Main.projFrames[Projectile.type] = 6; //frames
        }

        public override string Texture => "CalValEX/Projectiles/Pets/Sirember";

        public override void SetDefaults() 
        {
            Projectile.width = 112;
            Projectile.height = 112;
            Projectile.ignoreWater = true;
            Projectile.penetrate = -1;
            Projectile.netImportant = true;
            Projectile.timeLeft *= 5;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.aiStyle = -1;
            Projectile.GetGlobalProjectile<CalValEXGlobalProjectile>().isCalValPet = true;
        }

        public override void AI()
        {
            
            Player player = Main.LocalPlayer;
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            Projectile.ai[0]++;

            if (Projectile.frame != 1)
            {
                Projectile.frame = 1;
            }
            Projectile.rotation = 0;
            if (Projectile.ai[0] == 660)
            { 
                Projectile.Kill();

            }
            else if (Projectile.ai[0] == 600)
            {
                player.AddBuff(BuffID.Obstructed, 60);
            }
            else if (Projectile.ai[0] == 300)
            {
                player.AddBuff(BuffID.Blackout, 360);
                player.AddBuff(BuffID.Darkness, 360);
            }
        }

        public override void OnKill(int timeLeft)
        {
            for (int x = 0; x < 60; x++)
            {
                Dust dust;
                dust = Main.dust[Terraria.Dust.NewDust(Projectile.Center, 30, 30, 16, 0f, 0f, 0, new Color(255, 255, 255), 1.644737f)];
            }
        }
    }
}
