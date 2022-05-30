using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace CalValEX.Boi.BaseClasses
{
    public class BoiPlayer : BoiEntity, IDamageable, IColliding, IDrawable
    {
        public BoiRoom RoomImIn;

        public BoiPlayer(Vector2 position, float health, BoiRoom room)
        {
            Position = position;
            Health = health;
            MaxHealth = health;

            RoomImIn = null;
            RoomImIn = room;
            RoomImIn.Entities.Add(this);

            Inventory = new List<BoiItem>();
        }


        public static float InteractionRadius = 5;

        public int RoomCooldown = 0;
        public int ShotCooldown = 0;
        public int immunityFramesOnHit = 60;
        public int ImmunityFrames = 0;
        private float _health;
        public float MaxHealth = 5;

        //The general hitbox of the player. Its the same for collisions and damage.
        public CircleHitbox Hitbox => new CircleHitbox(Position, 25);

        //IDamageable stuff
        public float Health
        {
            get => _health;
            set => _health = MathHelper.Min(value, MaxHealth);
        }

        public bool Vulnerable => ImmunityFrames <= 0;
        public Factions Faction => Factions.ally;
        public CircleHitbox Hurtbox => Hitbox;
        public void TakeHit(float damageTaken)
        {
            Terraria.Audio.SoundEngine.PlaySound(Terraria.ID.SoundID.FemaleHit);
            ImmunityFrames = immunityFramesOnHit;
            _health -= damageTaken;
        }

        //IColliding stuff
        public bool CanCollide => true; //If, for example, you were to give anahita wings, you could turn this to false and shed be able to fly over any collidable blocks. Not out of bounds tho.
        public CircleHitbox CollisionHitbox => Hitbox;


        public override void Update()
        {
            ImmunityFrames--;
            ShotCooldown--;
            RoomCooldown--;
        }

        public void ProcessControls()
        {
            Player player = Main.LocalPlayer;

            #region movement
            

            if (player.controlLeft)
            {
                Velocity.X = Math.Clamp(Velocity.X, -5, 0);
                Velocity.X -= 0.2f;
                Velocity.X *= 1.2f;
            }

            else if (player.controlRight)
            {
                Velocity.X = Math.Clamp(Velocity.X, 0, 5);
                Velocity.X += 0.2f;
                Velocity.X *= 1.2f;
            }
            else
            {
                Velocity.X *= 0.9f;
            }

            if (player.controlUp)
            {
                Velocity.Y = Math.Clamp(Velocity.Y, -5, 0);
                Velocity.Y -= 0.2f;
                Velocity.Y *= 1.2f;
            }
            else if (player.controlDown)
            {
                Velocity.Y = Math.Clamp(Velocity.Y, 0, 5);
                Velocity.Y += 0.2f;
                Velocity.Y *= 1.2f;
            }
            else
            {
                Velocity.Y *= 0.9f;
            }

            Velocity.X = Math.Clamp(Velocity.X, -5, 5);
            Velocity.Y = Math.Clamp(Velocity.Y, -5, 5);

            #endregion

            Vector2 cursor = Main.MouseScreen;
            if (player.controlUseItem && ShotCooldown <= 0)
            {
                Vector2 position = ScreenPosition() - 25 * Vector2.UnitY;
                Vector2 targetPosition = cursor;
                Vector2 direction = targetPosition - position;
                direction.Normalize();
                float speed = 10f;

                RoomImIn.Entities.Add(new AnahitaTear(Position - Vector2.UnitY * 25, direction * speed, 1f));

                Terraria.Audio.SoundEngine.PlaySound(Terraria.ID.SoundID.Item21);
                ShotCooldown = 20;
            }
        }


        //Should happen in Atlantis.cs and ElderBerry.cs as IINteractables
        //for (int i = 0; i < Main.maxProjectiles; i++)
        //{
        //    var proj = Main.projectile[i];
        //
        //    if (proj != null && proj.active && proj.getRect().Intersects(thisRect) && proj.type == ModContent.ProjectileType<Atlantis>() && proj.alpha <= 0)
        //    {
        //        Terraria.Audio.SoundEngine.PlaySound(Terraria.ID.SoundID.Item9, Projectile.Center);
        //        Projectile.penetrate = 2;
        //        modPlayer.boiatlantis = true;
        //    }
        //}


        //for (int i = 0; i < Main.maxProjectiles; i++)
        //{
        //    var proj = Main.projectile[i];

        //    if (proj != null && proj.active && proj.getRect().Intersects(thisRect) && proj.type == ModContent.ProjectileType<ElderBerry>() && proj.alpha <= 0)
        //    {
        //        Terraria.Audio.SoundEngine.PlaySound(Terraria.ID.SoundID.Item8, Projectile.Center);
        //        Projectile.ai[0]++;
        //        proj.active = false;
        //    }
        //}

        public bool Die()
        {
            Terraria.Audio.SoundEngine.PlaySound(Terraria.ID.SoundID.PlayerKilled);
            return false;
        }

        public int Layer => 3;

        public void Draw(SpriteBatch spriteBatch, Vector2 offset)
        {
            float opacity = 1f;
            if (ImmunityFrames > 0)
                opacity *= (float)Math.Sin(Main.GlobalTimeWrappedHourly * 10f) * 0.2f + 0.7f;


            Texture2D Anahita = ModContent.Request<Texture2D>("CalValEX/Boi/Anahita").Value;
            Texture2D Shadow = ModContent.Request<Texture2D>("CalValEX/Boi/AnahitaShadow").Value;

            Vector2 drawPosition = Position + offset;

            Main.EntitySpriteDraw(Shadow, drawPosition, null, Color.White * opacity, 0f, Shadow.Size() / 2f, 1f, 0, 0);
            Main.EntitySpriteDraw(Anahita, drawPosition, null, Color.White * opacity, 0f, Anahita.Size() / 2f, 1f, 0, 0);

        }
    }
}