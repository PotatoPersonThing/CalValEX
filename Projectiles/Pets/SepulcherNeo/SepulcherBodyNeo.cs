using Microsoft.Xna.Framework;
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
        private static readonly int Size = 66;

        public bool segmentalt = false;
        //private bool segmentcheck = false;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sepulcher Body");
            ProjectileID.Sets.NeedsUUID[projectile.type] = true;
            Main.projPet[projectile.type] = true;
        }

        public override void SetDefaults()
        {
            projectile.width = 140; //Old was 74
            projectile.height = 52;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.netImportant = true;
            //projectile.timeLeft = 300;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
        }

        public override void AI()
        {
            // Consistently update the worm
            if ((int)Main.time % 120 == 0)
            {
                projectile.netUpdate = true;
            }
            if (projectile.ai[1] == 1f)
            {
                projectile.ai[1] = 0f;
                projectile.netUpdate = true;
            }
            float segmentAheadRotation;

            // This, and Size will likely need to be changed based on the sprite size of the segment
            float travelFactor = projectile.height * 0.8f;

            Vector2 segmentAheadCenter;
            int segmentAhead = (int)projectile.ai[0];
            // Verify the projectile we specified as the segment ahead is a part of this worm, and exists
            if (segmentAhead >= 0 && Main.projectile[segmentAhead].active &&
                (Main.projectile[segmentAhead].type == ModContent.ProjectileType<SepulcherBody1Neo>()) ||
                 Main.projectile[segmentAhead].type == ModContent.ProjectileType<SepulcherHeadNeo>())
            {
                segmentAheadCenter = Main.projectile[segmentAhead].Center;
                segmentAheadRotation = Main.projectile[segmentAhead].rotation;
                Main.projectile[segmentAhead].localAI[0] = projectile.localAI[0] + 1f;
            }
            // Otherwise, kill the segment and ignore the rest of the code
            else
            {
                projectile.Kill();
                return;
            }
            projectile.velocity = Vector2.Zero;
            Vector2 vectorToAhead = segmentAheadCenter - projectile.Center;
            if (segmentAheadRotation != projectile.rotation)
            {
                // Fix the angle between -pi and pi (wraps back over if one of the bounds are reached)
                float deltaAngle = MathHelper.WrapAngle(segmentAheadRotation - projectile.rotation);
                vectorToAhead = vectorToAhead.RotatedBy(deltaAngle * 0.1f);
            }
            projectile.rotation = vectorToAhead.ToRotation() + MathHelper.PiOver2;
            projectile.position = projectile.Center;

            // If scale is not 1, adjust the width and height based on that too
            projectile.width = 140; 
            switch (projectile.knockBack)
            {
                case 2f:
                    projectile.height = 66;
                    break;
                case 3f:
                    projectile.height = 33;
                    break;
                default:
                    projectile.height = 66;
                    break;
            } 
            projectile.Center = projectile.position;

            // Adjust the position of this segment relative to the one ahead
            if (vectorToAhead != Vector2.Zero)
            {
                projectile.Center = segmentAheadCenter - Vector2.Normalize(vectorToAhead) * travelFactor;
            }
            projectile.spriteDirection = (vectorToAhead.X > 0f).ToDirectionInt();

            Player player = Main.player[projectile.owner];
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
            if (modPlayer.sepneo)
            {
                projectile.timeLeft = 2;
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
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            if (projectile.knockBack == 1f)
            {
                Texture2D texture = ModContent.GetTexture("CalValEX/Projectiles/Pets/SepulcherNeo/SepulcherBodyMergedNeo");
                int frameHeight = texture.Height / Main.projFrames[projectile.type];
                int hei = frameHeight * projectile.frame;
                spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, new Microsoft.Xna.Framework.Rectangle?(new Rectangle(0, frameHeight * projectile.frame, texture.Width, frameHeight)), lightColor, projectile.rotation, projectile.Size / 2f, 1f, SpriteEffects.None, 0f);
                return false;
            }
            else if (projectile.knockBack == 3f)
            {
                Texture2D texture = ModContent.GetTexture("CalValEX/Projectiles/Pets/SepulcherNeo/SepulcherOrbNeoMerged");
                int frameHeight = texture.Height / Main.projFrames[projectile.type];
                int hei = frameHeight * projectile.frame;
                spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, new Microsoft.Xna.Framework.Rectangle?(new Rectangle(0, frameHeight * projectile.frame, texture.Width, frameHeight)), lightColor, projectile.rotation, projectile.Size / 2f, 1f, SpriteEffects.None, 0f);
                return false;
            }
            else if (projectile.knockBack == 4f)
            {
                Texture2D texture = ModContent.GetTexture("CalValEX/Items/Equips/Shields/Invishield_Shield");
                int frameHeight = texture.Height / Main.projFrames[projectile.type];
                int hei = frameHeight * projectile.frame;
                spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, new Microsoft.Xna.Framework.Rectangle?(new Rectangle(0, frameHeight * projectile.frame, texture.Width, frameHeight)), lightColor, projectile.rotation, projectile.Size / 2f, 1f, SpriteEffects.None, 0f);
                return false;
            }
            else
            {
                Texture2D texture = ModContent.GetTexture("CalValEX/Projectiles/Pets/SepulcherNeo/SepulcherBody2NeoMerged");
                int frameHeight = texture.Height / Main.projFrames[projectile.type];
                int hei = frameHeight * projectile.frame;
                spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, new Microsoft.Xna.Framework.Rectangle?(new Rectangle(0, frameHeight * projectile.frame, texture.Width, frameHeight)), lightColor, projectile.rotation, projectile.Size / 2f, 1f, SpriteEffects.None, 0f);

                //Arms... I'LL DEAL WITH THIS SHIT LATER
                /*Texture2D armtoptexture = ModContent.GetTexture("CalValEX/Projectiles/Pets/SepulcherNeo/SepulcherArmTopNeo");
                Texture2D armbottomtexture = ModContent.GetTexture("CalValEX/Projectiles/Pets/SepulcherNeo/SepulcherArmBottomNeo");
                Texture2D handtexture = ModContent.GetTexture("CalValEX/Projectiles/Pets/SepulcherNeo/SepulcherHandNeo");

                int topframeHeight = armtoptexture.Height / Main.projFrames[projectile.type];
                int botframeHeight = armbottomtexture.Height / Main.projFrames[projectile.type];
                int handframeHeight = handtexture.Height / Main.projFrames[projectile.type];

                int tophei = topframeHeight * projectile.frame;
                int bothei = botframeHeight * projectile.frame;
                int handhei = handframeHeight * projectile.frame;

                Vector2 lefttopposition = new Vector2(projectile.Center.X - Main.screenPosition.X - 10, projectile.Center.Y - Main.screenPosition.Y);
                Vector2 leftbottomposition = new Vector2(projectile.Center.X - Main.screenPosition.X - 20, projectile.Center.Y - Main.screenPosition.Y);
                Vector2 lefthandposition = new Vector2(projectile.Center.X - Main.screenPosition.X - 26, projectile.Center.Y - Main.screenPosition.Y);
                Vector2 righttopposition = new Vector2(projectile.Center.X - Main.screenPosition.X + 50, projectile.Center.Y - Main.screenPosition.Y);
                Vector2 rightbottomposition = new Vector2(projectile.Center.X - Main.screenPosition.X + 60, projectile.Center.Y - Main.screenPosition.Y);
                Vector2 righthandposition = new Vector2(projectile.Center.X - Main.screenPosition.X + 66, projectile.Center.Y - Main.screenPosition.Y);

                Rectangle topleftanchor = new Rectangle(30, topframeHeight * projectile.frame, armtoptexture.Width, topframeHeight);
                Rectangle toprightanchor = new Rectangle(-30, topframeHeight * projectile.frame, armtoptexture.Width, topframeHeight);

                spriteBatch.Draw(armtoptexture, lefttopposition, new Microsoft.Xna.Framework.Rectangle?(new Rectangle(0, topframeHeight * projectile.frame, armtoptexture.Width, topframeHeight)), lightColor, projectile.rotation, projectile.Size / 2f, 1f, SpriteEffects.None, 0f);
                spriteBatch.Draw(armtoptexture, righttopposition, new Microsoft.Xna.Framework.Rectangle?(new Rectangle(0, topframeHeight * projectile.frame, armtoptexture.Width, topframeHeight)), lightColor, projectile.rotation, projectile.Size / 2f, 1f, SpriteEffects.FlipHorizontally, 0f);*/

                //spriteBatch.Draw(armbottomtexture, leftbottomposition, new Microsoft.Xna.Framework.Rectangle?(new Rectangle(0, topleftanchor.Y, armbottomtexture.Width, botframeHeight)), lightColor, projectile.rotation, projectile.Size / 2f, 1f, SpriteEffects.None, 0f);
                //spriteBatch.Draw(armbottomtexture, rightbottomposition, new Microsoft.Xna.Framework.Rectangle?(new Rectangle(0, topleftanchor.Y, armbottomtexture.Width, botframeHeight)), lightColor, projectile.rotation, projectile.Size / 2f, 1f, SpriteEffects.FlipHorizontally, 0f);

                //spriteBatch.Draw(handtexture, lefthandposition, new Microsoft.Xna.Framework.Rectangle?(new Rectangle(0, topleftanchor.Y, handtexture.Width, handframeHeight)), lightColor, projectile.rotation, projectile.Size / 2f, 1f, SpriteEffects.None, 0f);
                //spriteBatch.Draw(handtexture, righthandposition, new Microsoft.Xna.Framework.Rectangle?(new Rectangle(0, topleftanchor.Y, handtexture.Width, handframeHeight)), lightColor, projectile.rotation, projectile.Size / 2f, 1f, SpriteEffects.FlipHorizontally, 0f);
                return false;
            }
        }
        /*public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            if (projectile.knockBack == 1f)
            {
                Texture2D texture = ModContent.GetTexture("CalValEX/Projectiles/Pets/JaredBodyAlt_Glow");
                int frameHeight = texture.Height / Main.projFrames[projectile.type];
                int hei = frameHeight * projectile.frame;
                spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, new Microsoft.Xna.Framework.Rectangle?(new Rectangle(0, frameHeight * projectile.frame, texture.Width, frameHeight)), Color.White, projectile.rotation, projectile.Size / 2f, 1f, SpriteEffects.None, 0f);
            }
            else
            {
                Texture2D texture = ModContent.GetTexture("CalValEX/Projectiles/Pets/JaredBody_Glow");
                int frameHeight = texture.Height / Main.projFrames[projectile.type];
                int hei = frameHeight * projectile.frame;
                spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, new Microsoft.Xna.Framework.Rectangle?(new Rectangle(0, frameHeight * projectile.frame, texture.Width, frameHeight)), Color.White, projectile.rotation, projectile.Size / 2f, 1f, SpriteEffects.None, 0f);
            }
        }*/
    }
}