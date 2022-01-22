using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.IO;

namespace CalValEX.Projectiles.Pets
{
    public class SiremberSpook : ModProjectile
    {
        int countdown = 0;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Giant Decapitated Floating Siren Head");
            Main.projFrames[projectile.type] = 6; //frames
        }

        public override string Texture => "CalValEX/Projectiles/Pets/Sirember";

        public override void SetDefaults() 
        {
            projectile.width = 112;
            projectile.height = 112;
            projectile.ignoreWater = true;
            projectile.penetrate = -1;
            projectile.netImportant = true;
            projectile.timeLeft *= 5;
            projectile.friendly = true;
            projectile.tileCollide = false;
            projectile.aiStyle = -1;
        }

        public override void AI()
        {
            
            Player player = Main.LocalPlayer;
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            countdown++;

            if (projectile.frame != 1)
            {
                projectile.frame = 1;
            }
            projectile.rotation = 0;
            if (countdown == 660)
            { 
                projectile.Kill();

            }
            else if (countdown == 600)
            {
                player.AddBuff(BuffID.Obstructed, 60);
            }
            else if (countdown == 300)
            {
                player.AddBuff(BuffID.Blackout, 360);
                player.AddBuff(BuffID.Darkness, 360);
            }
        }

        public override void Kill(int timeLeft)
        {
            for (int x = 0; x < 60; x++)
            {
                Dust dust;
                dust = Main.dust[Terraria.Dust.NewDust(projectile.Center, 30, 30, 16, 0f, 0f, 0, new Color(255, 255, 255), 1.644737f)];
            }
        }
        public override void SendExtraAI(BinaryWriter writer)
        {
            writer.Write(countdown);
        }

        public override void ReceiveExtraAI(BinaryReader reader)
        {
            countdown = reader.ReadInt32();
        }
    }
}
