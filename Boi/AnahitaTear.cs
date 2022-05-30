using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.ID;
using CalValEX.Boi.BaseClasses;
using System.Collections.Generic;

namespace CalValEX.Boi
{
    public class AnahitaTear : BoiEntity, IColliding, IDamageDealer, BaseClasses.IDrawable
    {
        //public override string Texture => "CalValEX/ExtraTextures/Pong/PongBall";

        public float CollisionRadius = 11f;
        private float _damage;

        public CircleHitbox CollisionHitbox => new CircleHitbox(Position, CollisionRadius);

        //Explode on walls or tiles
        public bool OnCollide(BoiEntity collider)
        {
            SoundEngine.PlaySound(SoundID.Item10);
            return true;
        }

        public List<Factions> hostileTo => new List<Factions>() { Factions.enemy };

        public bool HitCheck(CircleHitbox hurtbox) => (hurtbox.center - Position).Length() - hurtbox.radius < CollisionRadius;

        public float DealDamage(BoiEntity target)
        {
            //Explode on hit
            BoiHandler.DeadEntities.Add(this);
            SoundEngine.PlaySound(SoundID.Item10);
            return _damage;
        }
        

        public AnahitaTear(Vector2 position, Vector2 velocity, float damage)
        {
            Position = position;
            Velocity = velocity;
            _damage = damage;
        }

        public int Layer => 2;

        public void Draw(SpriteBatch spriteBatch, Vector2 offset)
        {
            Texture2D Tear = ModContent.Request<Texture2D>("CalValEX/ExtraTextures/Pong/PongBall").Value;

            Vector2 drawPosition = Position + offset;

            Main.EntitySpriteDraw(Tear, drawPosition, null, Color.White, 0f, Tear.Size() / 2f, 1f, 0, 0);

        }

    }
}