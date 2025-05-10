using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

// If you don't know what to change this to, don't mess with this code.
// You will fail
namespace CalValEX.Projectiles.Pets.SepulcherNeo
{
    public class SepulcherBody1Neo : ModProjectile
    {
        public bool segmentalt = false;
        //private bool segmentcheck = false;

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Sepulcher Body");
            ProjectileID.Sets.NeedsUUID[Projectile.type] = true;
            Main.projPet[Projectile.type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.width = 140; //Old was 74
            Projectile.height = 52;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            Projectile.netImportant = true;
            //Projectile.timeLeft = 300;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
        }

        public override void AI()
        {
            // Consistently update the worm
            if ((int)Main.time % 120 == 0)
            {
                Projectile.netUpdate = true;
            }
            if (Projectile.ai[1] == 1f)
            {
                Projectile.ai[1] = 0f;
                Projectile.netUpdate = true;
            }
            float segmentAheadRotation;

            // This, and Size will likely need to be changed based on the sprite size of the segment
            float travelFactor = Projectile.height * 0.8f;

            Vector2 segmentAheadCenter;
            int segmentAhead = (int)Projectile.ai[0];
            // Verify the projectile we specified as the segment ahead is a part of this worm, and exists
            if (segmentAhead >= 0 && Main.projectile[segmentAhead].active &&
                (Main.projectile[segmentAhead].type == ModContent.ProjectileType<SepulcherBody1Neo>()) ||
                 Main.projectile[segmentAhead].type == ModContent.ProjectileType<SepulcherHeadNeo>())
            {
                segmentAheadCenter = Main.projectile[segmentAhead].Center;
                segmentAheadRotation = Main.projectile[segmentAhead].rotation;
                Main.projectile[segmentAhead].localAI[0] = Projectile.localAI[0] + 1f;
            }
            // Otherwise, kill the segment and ignore the rest of the code
            else
            {
                Projectile.Kill();
                return;
            }
            Projectile.velocity = Vector2.Zero;
            Vector2 vectorToAhead = segmentAheadCenter - Projectile.Center;
            if (segmentAheadRotation != Projectile.rotation)
            {
                // Fix the angle between -pi and pi (wraps back over if one of the bounds are reached)
                float deltaAngle = MathHelper.WrapAngle(segmentAheadRotation - Projectile.rotation);
                vectorToAhead = vectorToAhead.RotatedBy(deltaAngle * 0.1f);
            }
            Projectile.rotation = vectorToAhead.ToRotation() + MathHelper.PiOver2;
            Projectile.position = Projectile.Center;

            // If scale is not 1, adjust the width and height based on that too
            Projectile.width = 140; 
            switch (Projectile.knockBack)
            {
                case 2f:
                    Projectile.height = 66;
                    break;
                case 3f:
                    Projectile.height = 33;
                    break;
                default:
                    Projectile.height = 66;
                    break;
            } 
            Projectile.Center = Projectile.position;

            // Adjust the position of this segment relative to the one ahead
            if (vectorToAhead != Vector2.Zero)
            {
                Projectile.Center = segmentAheadCenter - Vector2.Normalize(vectorToAhead) * travelFactor;
            }
            Projectile.spriteDirection = (vectorToAhead.X > 0f).ToDirectionInt();

            Player player = Main.player[Projectile.owner];
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
            if (modPlayer.sepneo)
            {
                Projectile.timeLeft = 2;
            }
            /*if ((Main.rand.Next(2) == 0) && !segmentcheck)
            {
                segmentalt = true;
                segmentcheck = true;
            }
            else
            {
                segmentcheck = true;
            }*/
        }
        public override bool PreDraw(ref Color lightColor)
        {
            if (Projectile.knockBack == 1f)
            {
                Texture2D texture = ModContent.Request<Texture2D>("CalValEX/Projectiles/Pets/SepulcherNeo/SepulcherBodyMergedNeo").Value;
                int frameHeight = texture.Height / Main.projFrames[Projectile.type];
                int hei = frameHeight * Projectile.frame;
                Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition, new Microsoft.Xna.Framework.Rectangle?(new Rectangle(0, frameHeight * Projectile.frame, texture.Width, frameHeight)), lightColor, Projectile.rotation, Projectile.Size / 2f, 1f, SpriteEffects.None, 0);
                return false;
            }
            else if (Projectile.knockBack == 3f)
            {
                Texture2D texture = ModContent.Request<Texture2D>("CalValEX/Projectiles/Pets/SepulcherNeo/SepulcherOrbNeoMerged").Value;
                int frameHeight = texture.Height / Main.projFrames[Projectile.type];
                int hei = frameHeight * Projectile.frame;
                Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition, new Microsoft.Xna.Framework.Rectangle?(new Rectangle(0, frameHeight * Projectile.frame, texture.Width, frameHeight)), lightColor, Projectile.rotation, Projectile.Size / 2f, 1f, SpriteEffects.None, 0);
                return false;
            }
            else if (Projectile.knockBack == 4f)
            {
                Texture2D texture = ModContent.Request<Texture2D>("CalValEX/Items/Equips/Shields/Invishield_Shield").Value;
                int frameHeight = texture.Height / Main.projFrames[Projectile.type];
                int hei = frameHeight * Projectile.frame;
                Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition, new Microsoft.Xna.Framework.Rectangle?(new Rectangle(0, frameHeight * Projectile.frame, texture.Width, frameHeight)), lightColor, Projectile.rotation, Projectile.Size / 2f, 1f, SpriteEffects.None, 0);
                return false;
            }
            else
            {
                Texture2D texture = ModContent.Request<Texture2D>("CalValEX/Projectiles/Pets/SepulcherNeo/SepulcherBody2NeoMerged").Value;
                int frameHeight = texture.Height / Main.projFrames[Projectile.type];
                int hei = frameHeight * Projectile.frame;
                Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition, new Microsoft.Xna.Framework.Rectangle?(new Rectangle(0, frameHeight * Projectile.frame, texture.Width, frameHeight)), lightColor, Projectile.rotation, Projectile.Size / 2f, 1f, SpriteEffects.None, 0);

                //Arms... I'LL DEAL WITH THIS SHIT LATER
                /*Texture2D armtoptexture = ModContent.Request<Texture2D>("CalValEX/Projectiles/Pets/SepulcherNeo/SepulcherArmTopNeo");
                Texture2D armbottomtexture = ModContent.Request<Texture2D>("CalValEX/Projectiles/Pets/SepulcherNeo/SepulcherArmBottomNeo");
                Texture2D handtexture = ModContent.Request<Texture2D>("CalValEX/Projectiles/Pets/SepulcherNeo/SepulcherHandNeo");

                int topframeHeight = armtoptexture.Height / Main.projFrames[Projectile.type];
                int botframeHeight = armbottomtexture.Height / Main.projFrames[Projectile.type];
                int handframeHeight = handtexture.Height / Main.projFrames[Projectile.type];

                int tophei = topframeHeight * Projectile.frame;
                int bothei = botframeHeight * Projectile.frame;
                int handhei = handframeHeight * Projectile.frame;

                Vector2 lefttopposition = new Vector2(Projectile.Center.X - Main.screenPosition.X - 10, Projectile.Center.Y - Main.screenPosition.Y);
                Vector2 leftbottomposition = new Vector2(Projectile.Center.X - Main.screenPosition.X - 20, Projectile.Center.Y - Main.screenPosition.Y);
                Vector2 lefthandposition = new Vector2(Projectile.Center.X - Main.screenPosition.X - 26, Projectile.Center.Y - Main.screenPosition.Y);
                Vector2 righttopposition = new Vector2(Projectile.Center.X - Main.screenPosition.X + 50, Projectile.Center.Y - Main.screenPosition.Y);
                Vector2 rightbottomposition = new Vector2(Projectile.Center.X - Main.screenPosition.X + 60, Projectile.Center.Y - Main.screenPosition.Y);
                Vector2 righthandposition = new Vector2(Projectile.Center.X - Main.screenPosition.X + 66, Projectile.Center.Y - Main.screenPosition.Y);

                Rectangle topleftanchor = new Rectangle(30, topframeHeight * Projectile.frame, armtoptexture.Width, topframeHeight);
                Rectangle toprightanchor = new Rectangle(-30, topframeHeight * Projectile.frame, armtoptexture.Width, topframeHeight);

                Main.EntitySpriteDraw(armtoptexture, lefttopposition, new Microsoft.Xna.Framework.Rectangle?(new Rectangle(0, topframeHeight * Projectile.frame, armtoptexture.Width, topframeHeight)), lightColor, Projectile.rotation, Projectile.Size / 2f, 1f, SpriteEffects.None, 0f);
                Main.EntitySpriteDraw(armtoptexture, righttopposition, new Microsoft.Xna.Framework.Rectangle?(new Rectangle(0, topframeHeight * Projectile.frame, armtoptexture.Width, topframeHeight)), lightColor, Projectile.rotation, Projectile.Size / 2f, 1f, SpriteEffects.FlipHorizontally, 0f);*/

                //Main.EntitySpriteDraw(armbottomtexture, leftbottomposition, new Microsoft.Xna.Framework.Rectangle?(new Rectangle(0, topleftanchor.Y, armbottomtexture.Width, botframeHeight)), lightColor, Projectile.rotation, Projectile.Size / 2f, 1f, SpriteEffects.None, 0f);
                //Main.EntitySpriteDraw(armbottomtexture, rightbottomposition, new Microsoft.Xna.Framework.Rectangle?(new Rectangle(0, topleftanchor.Y, armbottomtexture.Width, botframeHeight)), lightColor, Projectile.rotation, Projectile.Size / 2f, 1f, SpriteEffects.FlipHorizontally, 0f);

                //Main.EntitySpriteDraw(handtexture, lefthandposition, new Microsoft.Xna.Framework.Rectangle?(new Rectangle(0, topleftanchor.Y, handtexture.Width, handframeHeight)), lightColor, Projectile.rotation, Projectile.Size / 2f, 1f, SpriteEffects.None, 0f);
                //Main.EntitySpriteDraw(handtexture, righthandposition, new Microsoft.Xna.Framework.Rectangle?(new Rectangle(0, topleftanchor.Y, handtexture.Width, handframeHeight)), lightColor, Projectile.rotation, Projectile.Size / 2f, 1f, SpriteEffects.FlipHorizontally, 0f);
                return false;
            }
        }
        /*public override void PostDraw(Color lightColor)
        {
            if (Projectile.knockBack == 1f)
            {
                Texture2D texture = ModContent.Request<Texture2D>("CalValEX/Projectiles/Pets/JaredBodyAlt_Glow");
                int frameHeight = texture.Height / Main.projFrames[Projectile.type];
                int hei = frameHeight * Projectile.frame;
                Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition, new Microsoft.Xna.Framework.Rectangle?(new Rectangle(0, frameHeight * Projectile.frame, texture.Width, frameHeight)), Color.White, Projectile.rotation, Projectile.Size / 2f, 1f, SpriteEffects.None, 0f);
            }
            else
            {
                Texture2D texture = ModContent.Request<Texture2D>("CalValEX/Projectiles/Pets/JaredBody_Glow");
                int frameHeight = texture.Height / Main.projFrames[Projectile.type];
                int hei = frameHeight * Projectile.frame;
                Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition, new Microsoft.Xna.Framework.Rectangle?(new Rectangle(0, frameHeight * Projectile.frame, texture.Width, frameHeight)), Color.White, Projectile.rotation, Projectile.Size / 2f, 1f, SpriteEffects.None, 0f);
            }
        }*/
    }
}