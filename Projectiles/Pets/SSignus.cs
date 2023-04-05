using Microsoft.Xna.Framework;
using Terraria;
using System.IO;
using Microsoft.Xna.Framework.Graphics;

namespace CalValEX.Projectiles.Pets
{
    public class SSignus : ModFlyingPet
    {
        private bool sigtep = false;
        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            // DisplayName.SetDefault("Mini Signus");
            Main.projFrames[Projectile.type] = 4;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            Projectile.width = 36;
            Projectile.height = 48;
            Projectile.ignoreWater = true;
            Projectile.GetGlobalProjectile<CalValEXGlobalProjectile>().isCalValPet = true;
        }

        public override void PostDraw(Color lightColor)
        {
            SimpleGlowmask(Main.spriteBatch);
        }

        public override Vector2 FlyingOffset => new Vector2(90f * -Main.player[Projectile.owner].direction, -75f);

        public override float TeleportThreshold => 1440f;

        public override void Animation(int state)
        {
            SimpleAnimation(speed: 12);
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.sSignus = false;

            if (modPlayer.sSignus)
                Projectile.timeLeft = 2;
        }

        public override void CustomBehaviour(Player player, ref int state, float flyingSpeed, float flyingInertia)
        {
            Player owner = Main.player[Projectile.owner];
            Vector2 vectorToOwner = owner.Center - Projectile.Center;
            float distanceToOwner = vectorToOwner.Length();
            if (distanceToOwner > 1138)
            {
                sigtep = true;
            }
            if (distanceToOwner < 1139)
            {
                sigtep = false;
                Projectile.alpha--;
                Projectile.alpha--;
            }

            if (Projectile.alpha == 45)
            {
                for (int x = 0; x < 20; x++)
                {
                    Dust.NewDust(Projectile.Center, 30, 30, 173, 0f, 0f, 0, new Color(255, 255, 255), 0.8f);
                }
            }

            if (sigtep)
            {
                Projectile.alpha = 255;
                for (int x = 0; x < 5; x++)
                {
                    Dust.NewDust(Projectile.Center, 30, 30, 173, 0f, 0f, 0, new Color(255, 255, 255), 0.8f);
                }
            }
        }

        public override void SendExtraAI(BinaryWriter writer)
        {
            writer.Write(sigtep);
            base.SendExtraAI(writer);
        }

        public override void ReceiveExtraAI(BinaryReader reader)
        {
            sigtep = reader.ReadBoolean();
            base.ReceiveExtraAI(reader);
        }
    }
}