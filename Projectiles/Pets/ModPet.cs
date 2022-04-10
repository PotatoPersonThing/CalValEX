using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.Pets
{
    /// <summary>
    /// Methods that are not used should be sealed. The base of a pet
    /// </summary>
    public abstract class ModPet : ModProjectile
    {
        /// <summary>
        /// Implement most, if not all, methods in here
        /// </summary>
        public abstract void PetBehaviour();

        /// <summary>
        /// The current state of the projectile
        /// </summary>
        public int state = 0;

        /// <summary>
        /// The rotation (in radians) of the aura. Automatically gets it's rotation wrapped
        /// </summary>
        public float auraRotation = 0f;

        /// <summary>
        /// The usual static defaults for a pet
        /// </summary>
        /// <param name="lightPet">If it is a light pet or not</param>
        public virtual void PetSetStaticDefaults(bool lightPet)
        {
            Main.projPet[projectile.type] = true;

            if (lightPet)
            {
                ProjectileID.Sets.LightPet[projectile.type] = true;
            }
        }

        /// <summary>
        /// The usual defaults for a pet
        /// </summary>
        public virtual void PetSetDefaults()
        {
            projectile.penetrate = -1;
            projectile.netImportant = true;
            projectile.timeLeft *= 5;
            projectile.friendly = true;
            projectile.tileCollide = true;
            projectile.aiStyle = -1;
        }

        /// <summary>
        /// Default value is 20f
        /// </summary>
        public virtual float FlyingArea => 20f;

        /// <summary>
        /// Default is 2400f
        /// </summary>
        public virtual float TeleportThreshold => 2400f;

        /// <summary>
        /// Default is 560f
        /// </summary>
        public virtual float SpeedupThreshold => 560f;

        /// <summary>
        /// If this pet can speedup after the threshold is hit. Default is true
        /// </summary>
        public virtual bool ShouldSpeedup => true;

        /// <summary>
        /// Default is 12f
        /// </summary>
        public virtual float FlyingSpeed => 12f;

        /// <summary>
        /// Default is 80f
        /// </summary>
        public virtual float FlyingInertia => 80f;

        /// <summary>
        /// Default is 1f
        /// </summary>
        public virtual float FlyingDrag => 1f;

        /// <summary>
        /// Default is 48 pixels (3 tiles) on the back of the player and 50 pixels (3.125 tiles) up
        /// </summary>
        public virtual Vector2 FlyingOffset => new Vector2(48f * -Main.player[projectile.owner].direction, -50f);

        /// <summary>
        /// Default is true
        /// </summary>
        public virtual bool FacesLeft => true;

        /// <summary>
        /// Default is true
        /// </summary>
        public virtual bool ShouldFlip => true;

        /// <summary>
        /// Default is true
        /// </summary>
        public virtual bool ShouldFlyRotate => true;

        /// <summary>
        /// Default is true
        /// </summary>
        public virtual bool CanTeleport => true;

        /// <summary>
        /// Default is true
        /// </summary>
        public virtual bool AllowRotationReset => true;

        /// <summary>
        /// Set the pet bool and the despawn logic in here
        /// </summary>
        /// <param name="player">The owner of the pet</param>
        public abstract void PetFunctionality(Player player);

        /// <summary>
        /// Put the animation code here. This is called before any movement or state changes happen. Called before CustomBehaviour and after teleportation
        /// </summary>
        /// <param name="state">The current state the pet is in</param>
        public abstract void Animation(int state);

        /// <summary>
        /// Put the dust spawning code here. Allows you to modify the dust type. Return <see langword="false"/> to disable normal spawning. Return <see langword="true"/> for normal code. Returns <see langword="false"/> by default
        /// </summary>
        /// <param name="dustType">The dust type</param>
        public virtual bool ModifyDustSpawn(ref int dustType)
        {
            return false;
        }

        /// <summary>
        /// Allows you to add custom behaviour to this pet. Called right before the normal AI is done
        /// </summary>
        /// <param name="player">The owner of the pet</param>
        /// <param name="state">The state of the pet</param>
        public virtual void CustomBehaviour(Player player, ref int state)
        {
        }

        /// <summary>
        /// Allows you to add custom logic when this pet teleports, like adding dust
        /// </summary>
        public virtual void OnTeleport()
        {
        }

        /// <summary>
        /// Allows you to add custom logic when this pet is reset to a different state, like resetting values
        /// </summary>
        /// <param name="state">The state it got reset to</param>
        public virtual void OnReset(int state)
        {
        }

        /// <summary>
        /// Allows you to reset the pet
        /// </summary>
        /// <param name="state">The state to reset to</param>
        public void ResetMe(int state)
        {
            projectile.ai[0] = 0;
            projectile.ai[1] = 0;
            projectile.localAI[0] = 0;
            projectile.localAI[1] = 0;
            this.state = state;
            OnReset(state);
            projectile.netUpdate = true;
        }

        /// <summary>
        /// <inheritdoc cref="ModProjectile.SendExtraAI(BinaryWriter)"/> It is important that you call base.SendExtraAI(writer) at the end.
        /// </summary>
        /// <param name="writer"></param>
        public new virtual void SendExtraAI(BinaryWriter writer)
        {
            writer.Write(projectile.localAI[0]);
            writer.Write(projectile.localAI[1]);
            writer.Write(state);
            base.SendExtraAI(writer);
        }

        /// <summary>
        /// <inheritdoc cref="ModProjectile.ReceiveExtraAI(BinaryReader)"/> It is important that you call base.ReceiveExtraAI(reader) at the end.
        /// </summary>
        /// <param name="writer"></param>
        public new virtual void ReceiveExtraAI(BinaryReader reader)
        {
            projectile.localAI[0] = reader.ReadSingle();
            projectile.localAI[1] = reader.ReadSingle();
            state = reader.ReadInt32();
            base.ReceiveExtraAI(reader);
        }

        public override bool? CanCutTiles()
        {
            return false;
        }

        public sealed override void AI()
        {
            PetBehaviour();
        }

        public void SimpleAnimation(int speed)
        {
            projectile.frameCounter++;
            if (projectile.frameCounter > speed)
            {
                projectile.frameCounter = 0;
                projectile.frame++;
                if (projectile.frame > Main.projFrames[projectile.type] - 1)
                    projectile.frame = 0;
            }
        }

        public void SimpleGlowmask(SpriteBatch spriteBatch, string path)
        {
            Texture2D glowTexture = ModContent.GetTexture(path);
            spriteBatch.Draw(glowTexture, projectile.Center - Main.screenPosition, new Rectangle(0, (glowTexture.Height / Main.projFrames[projectile.type]) * projectile.frame, glowTexture.Width, glowTexture.Height / Main.projFrames[projectile.type]), Color.White, projectile.rotation, projectile.Size / 2f, projectile.scale, projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);
        }

        public void SimpleGlowmask(SpriteBatch spriteBatch)
        {
            SimpleGlowmask(spriteBatch, Texture + "_Glow");
        }

        public void SimpleAura(SpriteBatch spriteBatch, string[] paths, bool glowing)
        {
            if (paths.Length < 1)
                return;

            Texture2D auraTexture = ModContent.GetTexture(paths[0]);
            Color color = Lighting.GetColor((int)projectile.Center.X / 16, (int)projectile.Center.Y / 16);

            spriteBatch.Draw(auraTexture, projectile.Center - Main.screenPosition, auraTexture.Bounds, color, auraRotation, auraTexture.Size() / 2f, 1f, SpriteEffects.None, 0);

            if (glowing)
            {
                if (paths.Length < 2)
                    return;

                Texture2D glowTexture = ModContent.GetTexture(paths[1]);
                spriteBatch.Draw(glowTexture, projectile.Center - Main.screenPosition, glowTexture.Bounds, Color.White, auraRotation, glowTexture.Size() / 2f, 1f, SpriteEffects.None, 0);
            }
        }

        public void SimpleAura(SpriteBatch spriteBatch, bool glowing)
        {
            SimpleAura(spriteBatch, new string[] { Texture + "_Aura", Texture + "_Aura_Glow" }, glowing);
        }

        public void AddLight(Vector3 RGB, float intensity, int abyssLight)
        {
            AddLight(projectile.Center, RGB, intensity, abyssLight);
        }

        public void AddLight(Color color, float intensity, int abyssLight)
        {
            AddLight(color.ToVector3(), intensity, abyssLight);
        }

        public void AddLight(byte R, byte G, byte B, float intensity, int abyssLight)
        {
            AddLight(new Vector3(R, G, B), intensity, abyssLight);
        }

        public void AddLight(Vector2 position, byte R, byte G, byte B, float intensity, int abyssLight)
        {
            AddLight(position, new Vector3(R, G, B), intensity, abyssLight);
        }

        public void AddLight(Vector2 position, Color color, float intensity, int abyssLight)
        {
            AddLight(position, color.ToVector3(), intensity, abyssLight);
        }

        public void AddLight(Vector2 position, Vector3 RGB, float intensity, int abyssLight)
        {
            Vector3 lightColor = RGB * intensity;

            Lighting.AddLight(position, lightColor);

            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            if (calamityMod != null)
            {
                calamityMod.Call("AddAbyssLightStrength", Main.player[projectile.owner], abyssLight);
            }
        }
    }
}
