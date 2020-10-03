using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.Pets
{
    public abstract class FlyingPet : ModProjectile
    {
        public override bool CloneNewInstances => true;

        public bool spinRotation;
        public float spinRotationSpeedMult;
        public float speed;
        public float inertia;
        public int animationSpeed;
        public float[] distance = new float[2];
        public bool facingLeft;
        public bool shouldFlip;
        public float offSetX;
        public float offSetY;
        public bool usesAura;
        public string auraTexture;
        public bool auraRotates;
        public bool auraRotation;
        public float auraRotationSpeedMult;
        public bool auraUsesGlowmask;
        public string auraGlowmaskTexture;
        public bool usesGlowmask;
        public string glowmaskTexture;
        public bool shouldLightUp;
        public Vector3 RGB;
        public float intensity;
        public int abyssLightLevel;
        public virtual void SafeSetDefaults()
        {
            spinRotation = false;
            facingLeft = false;
            shouldFlip = true;
            usesAura = false;
            usesGlowmask = false;
            auraUsesGlowmask = false;
        }

        public sealed override void SetDefaults()
        {
            SafeSetDefaults();

            projectile.penetrate = -1;
            projectile.netImportant = true;
            projectile.timeLeft *= 5;
            projectile.friendly = true; 
            projectile.tileCollide = false;
        }

        public virtual void SetUpFlyingPet()
        {
            distance[0] = 1840f;
            distance[1] = 560f;
            speed = 12f;
            inertia = 60f;
            animationSpeed = 30;
            spinRotationSpeedMult = 1f;
            offSetX = 48f * -Main.player[projectile.owner].direction;
            offSetY = -50f;
        }

        public virtual void SetUpAuraAndGlowmask()
        {
            auraTexture = "";
            auraRotates = false;
            auraRotation = false;
            auraRotationSpeedMult = 1f;

            glowmaskTexture = "";
            auraGlowmaskTexture = "";
        }

        public virtual void SetUpLight()
        {
            shouldLightUp = false;
            RGB = new Vector3(255, 255, 255);
            intensity = 1f;
            abyssLightLevel = 0;
        }
        public virtual void SafeSendExtraAI(BinaryWriter writer) { }
        public sealed override void SendExtraAI(BinaryWriter writer)
        {
            //local ai is not synchronized, as it normaly is local. however, since this is a pet, there is no harm using it like this
            writer.Write(projectile.localAI[0]);
            writer.Write(projectile.localAI[1]); //the state it is in, aka if its flying, walking or idling. 0 = idling, 1 = walking, 2 = flying for this example

            SafeSendExtraAI(writer);
        }

        public virtual void SafeReceiveExtraAI(BinaryReader reader) { }
        public sealed override void ReceiveExtraAI(BinaryReader reader) //first in, first out. make sure the first thing you send is the first thing you read.
        {
            projectile.localAI[0] = reader.ReadSingle();
            projectile.localAI[1] = reader.ReadSingle();

            SafeReceiveExtraAI(reader);
        }

        private float rotation = 0f;
        public sealed override void AI()
        {
            SetUpFlyingPet();
            SetUpAuraAndGlowmask();
            SetUpLight();

            Player owner = Main.player[projectile.owner];

            if (shouldLightUp)
            {
                float r = RGB.X / 255 * intensity;
                float g = RGB.Y / 255 * intensity;
                float b = RGB.Z / 255 * intensity;

                Lighting.AddLight(projectile.Center, r, g, b);

                Mod calamityMod = ModLoader.GetMod("CalamityMod");
                if (calamityMod != null)
                {
                    calamityMod.Call("AddAbyssLightStrength", owner, abyssLightLevel);
                }
            }

            if (auraRotates)
            {
                float tempRot = auraRotation ? 1f : -1f;
                tempRot *= auraRotationSpeedMult;
                rotation += tempRot;
            }

            if (!owner.active)
            {
                projectile.active = false;
                return;
            }

            Vector2 offset = new Vector2(offSetX, offSetY);

            Vector2 vectorToOwner = owner.Center - projectile.Center;
            float distanceToOwner = vectorToOwner.Length();

            if (facingLeft && shouldFlip)
                projectile.spriteDirection = projectile.velocity.X > 0 ? -1 : 1;
            else if (!facingLeft && shouldFlip)
                projectile.spriteDirection = projectile.velocity.X > 0 ? 1 : -1;


            if (distanceToOwner > distance[0])
            {
                projectile.position = owner.Center;
                projectile.velocity *= 0.1f;
                projectile.netUpdate = true;
            }

            if (distanceToOwner > distance[1])
            {
                speed *= 1.25f;
                inertia *= 0.75f;
            }

            

            switch((int)projectile.localAI[1])
            {
                case 0:
                    projectile.tileCollide = false;

                    vectorToOwner += offset;
                    distanceToOwner = vectorToOwner.Length();
                    //movement
                    if (distanceToOwner > 20f)
                    {
                        vectorToOwner.Normalize();
                        vectorToOwner *= speed;
                        projectile.velocity = (projectile.velocity * (inertia - 1) + vectorToOwner) / inertia;
                    }
                    else if (projectile.velocity == Vector2.Zero)
                    {
                        //boop it so it moves
                        projectile.velocity.X = -0.15f;
                        projectile.velocity.Y = -0.15f;
                    }

                    //animation
                    if (animationSpeed > 0)
                    {
                        projectile.frameCounter++;
                        if (projectile.frameCounter >= animationSpeed)
                        {
                            projectile.frameCounter = 0;
                            projectile.frame++;
                            if (projectile.frame >= Main.projFrames[projectile.type])
                                projectile.frame = 0;
                        }
                        if (!spinRotation)
                        {
                            projectile.rotation = projectile.velocity.X * 0.1f; //so that it turns towards where its flying
                        }
                    }
                    break;
            }

            if (spinRotation)
            {
                if (Math.Abs(projectile.velocity.X) != 0)
                {
                    float spinRotationSpeed = (projectile.velocity.X / 10) * spinRotationSpeedMult;
                    projectile.rotation += spinRotationSpeed;
                }
            }
        }

        public virtual void SafeAI(Player player) { }
        public sealed override void PostAI()
        {
            SafeAI(Main.player[projectile.owner]);
        }

        public virtual void SafePreDraw(SpriteBatch spriteBatch, Color lightColor) { }
        public sealed override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            if (usesAura)
            {
                if (auraTexture == null)
                    return true;
                Texture2D texture = mod.GetTexture(auraTexture);
                //Rectangle sourceRectangle = new Rectangle(0, 0, (int)(texture.Width / 2f), (int)(texture.Height / 2f));
                Rectangle sourceRectangle = new Rectangle(0, 0, texture.Width, texture.Height);
                Vector2 origin = new Vector2(texture.Width, texture.Height);
                spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, sourceRectangle, lightColor, rotation, origin / 2f, 1f, SpriteEffects.None, 0);
                if (auraUsesGlowmask)
                {
                    Texture2D texture2 = mod.GetTexture(auraGlowmaskTexture);
                    //Rectangle sourceRectangle = new Rectangle(0, 0, (int)(texture.Width / 2f), (int)(texture.Height / 2f));
                    Rectangle sourceRectangle2 = new Rectangle(0, 0, texture.Width, texture.Height);
                    Vector2 origin2 = new Vector2(texture.Width, texture.Height);
                    spriteBatch.Draw(texture2, projectile.Center - Main.screenPosition, sourceRectangle2, Color.White, rotation, origin2 / 2f, 1f, SpriteEffects.None, 0);
                }
            }

            SafePreDraw(spriteBatch, lightColor);
            return true;
        }

        public virtual void SafePostDraw(SpriteBatch spriteBatch, Color lightColor) { }
        public sealed override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            if (usesGlowmask)
            {
                Texture2D texture = mod.GetTexture(glowmaskTexture);
                Rectangle rectangle = new Rectangle(0, 0, texture.Width, texture.Height);
                spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, rectangle, Color.White, projectile.rotation, projectile.Size / 2f, 1f, SpriteEffects.None, 0f);
            }
            /*
            if (auraUsesGlowmask)
            {
                if (usesAura)
                {
                    Texture2D texture = mod.GetTexture(auraGlowmaskTexture);
                    Rectangle sourceRectangle = new Rectangle(0, 0, texture.Width, texture.Height);
                    Vector2 origin = new Vector2(texture.Width, texture.Height);
                    spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, sourceRectangle, Color.White, rotation, origin / 2f, 1f, SpriteEffects.None, 0f);
                }
            }
            */
            SafePostDraw(spriteBatch, lightColor);
        }
    }
}
