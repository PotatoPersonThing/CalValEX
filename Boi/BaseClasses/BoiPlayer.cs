using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;

namespace CalValEX.Boi.BaseClasses
{
    public class BoiPlayer : BoiEntity, IDamageable, IColliding
    {
        public static float InteractionRadius = 5;

        public int immunityFramesOnHit = 60;
        public int ImmunityFrames = 0;
        private float _health = 5;

        //The general hitbox of the player. Its the same for collisions and damage.
        public CircleHitbox Hitbox => new CircleHitbox(Position, 5);

        //IDamageable stuff
        public float Health
        {
            get => _health;
            set => _health = value;
        }

        public bool Vulnerable => ImmunityFrames <= 0;
        public Factions Faction => Factions.ally;
        public CircleHitbox Hurtbox => Hitbox;
        public void TakeHit(float damageTaken)
        {
            ImmunityFrames = immunityFramesOnHit;
            _health -= damageTaken;
        }

        //IColliding stuff
        public bool CanCollide => true; //If, for example, you were to give anahita wings, you could turn this to false and shed be able to fly over any collidable blocks. Not out of bounds tho.
        public CircleHitbox CollisionHitbox => Hitbox;


        public override void Update()
        {
            ImmunityFrames--;
        }

        public void ProcessControls()
        {
            Player player = Main.LocalPlayer;
            if (player.controlLeft && Position.X > player.Center.X - 382)
            {
                Velocity.X = -4;
            }
            else if (player.controlRight && Position.X < player.Center.X + 332)
            {
                Velocity.X = 4;
            }
            else
            {
                Velocity.X = 0;
            }
            if (player.controlUp && Position.Y > player.Center.Y - 238)
            {
                Velocity.Y = -4;
            }
            else if (player.controlDown && Position.Y < player.Center.Y + 173)
            {
                Velocity.Y = 4;
            }
            else
            {
                Velocity.Y = 0;
            }
            return;
        }
    }
}