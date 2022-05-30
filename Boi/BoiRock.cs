using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.ID;
using System.Collections.Generic;
using CalValEX.Boi.BaseClasses;

namespace CalValEX.Boi
{
    public class BoiRock : BoiEntity, ICollidable
    {
        public string Texture => "CalValEX/Boi/Block";

        //Those should be made into Icolliding
        //List<int> push = new List<int>() { ModContent.ProjectileType<Brimhita>(), ModContent.ProjectileType<Anahita>(), ModContent.ProjectileType<Spider>(), ModContent.ProjectileType<Terror>() };

        RectangleHitbox CollisionHitbox => new RectangleHitbox(Position - Vector2.One * 45, Vector2.One * 90);

        public float SimulationDistance => 64f;

        public Vector2 MovementCheck(CircleHitbox hitbox)
        {
            bool collisionOccured;

            float distanceBetweenCenters = (hitbox.center - Position).Length();

            //45 is the closest you can be to the rocks center without being inside of it
            if (distanceBetweenCenters < (45 + hitbox.radius))
                collisionOccured = true;

            //Do some complicated math if you're not sure of the collision
            else
            {
                var c1c2Vect = (hitbox.center - Position).SafeNormalize(Vector2.Zero);
                var outerPoint = hitbox.center + hitbox.radius * c1c2Vect;

                collisionOccured = CollisionHitbox.Contains(outerPoint);
            }

            //Don't move the entity if no collision occured lol
            if (!collisionOccured)
                return Vector2.Zero;

            //Check from which side of the box did the hitbox get into it.
            Vector2 pushbackNormal;
            float pushbackLength;

            if (CollisionHitbox.Bottom.IsIntersecting(hitbox.trajectoryLine))
            {
                pushbackNormal = Vector2.UnitY;
                pushbackLength = (Position.Y + 45) - (hitbox.center.Y - hitbox.radius);
            }
            else if (CollisionHitbox.Left.IsIntersecting(hitbox.trajectoryLine))
            {
                pushbackNormal = Vector2.UnitX;
                pushbackLength = (Position.X - 45) - (hitbox.center.X + hitbox.radius);
            }
            else if (CollisionHitbox.Right.IsIntersecting(hitbox.trajectoryLine))
            {
                pushbackNormal = Vector2.UnitX;
                pushbackLength = (Position.X + 45) - (hitbox.center.X - hitbox.radius);
            }
            else
            {
                pushbackNormal = Vector2.UnitY;
                pushbackLength = (Position.Y - 45) - (hitbox.center.Y + hitbox.radius);
            }

            return pushbackNormal * pushbackLength;
        }
    }
}