using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;

namespace CalValEX.Boi.BaseClasses
{
    public enum Factions
    {
        ally,
        enemy
    }

    public struct CircleHitbox
    {
        public float radius;
        public Vector2 center;
        public Vector2 prevCenter;

        public CircleHitbox(Vector2 _center, float _radius)
        {
            radius = _radius;
            center = _center;
            prevCenter = center;
        }

        public CircleHitbox(Vector2 _center, Vector2 _prevCenter, float _radius)
        {
            radius = _radius;
            center = _center;
            prevCenter = _prevCenter;
        }

        public Line trajectoryLine => new Line(center, prevCenter);
    }

    public struct RectangleHitbox
    {
        public Vector2 position;
        public Vector2 center => position - dimensions / 2f;

        public Vector2 dimensions;

        public Line Top => new Line(position, position + Vector2.UnitX * dimensions.X);
        public Line Bottom => new Line(position + Vector2.UnitY * dimensions.Y, position + Vector2.UnitY * dimensions.Y + Vector2.UnitX * dimensions.X);
        public Line Left => new Line(position, position + Vector2.UnitY * dimensions.Y);
        public Line Right => new Line(position + Vector2.UnitX * dimensions.X, position + Vector2.UnitY * dimensions.Y + Vector2.UnitX * dimensions.X);


        public RectangleHitbox(Vector2 _position, Vector2 _dimensions)
        {
            position = _position;
            dimensions = _dimensions;
        }

        public bool Contains(Vector2 point)
        {
            if (position.X <= point.X && point.X < position.X + dimensions.X && position.Y <= point.y)
            {
                return point.y < position.Y + dimensions.Y;
            }

            return false;
        }
    }

    public struct Line
    {
        public Vector2 position;
        public Vector2 size;

        public Vector2 start => position;
        public Vector2 finish => position + size;

        public Line(Vector2 _position, Vector2 _size)
        {
            position = _position;
            size = _size;
        }

        //I copied this from the internet teehee
        public bool IsIntersecting(Line line2)
        {
            Vector2 a = start;
            Vector2 b = finish;
            Vector2 c = line2.start;
            Vector2 d = line2.finish;

            float denominator = ((b.X - a.X) * (d.Y - c.Y)) - ((b.Y - a.Y) * (d.X - c.X));
            float numerator1 = ((a.Y - c.Y) * (d.X - c.X)) - ((a.X - c.X) * (d.Y - c.Y));
            float numerator2 = ((a.Y - c.Y) * (b.X - a.X)) - ((a.X - c.X) * (b.Y - a.Y));

            // Detect coincident lines (has a problem, read below)
            if (denominator == 0) return numerator1 == 0 && numerator2 == 0;

            float r = numerator1 / denominator;
            float s = numerator2 / denominator;

            return (r >= 0 && r <= 1) && (s >= 0 && s <= 1);
        }
    }

    /// <summary>
    /// Used for any entity that can deal damage, such as bullets or enemies with contact damage.
    /// </summary>
    public interface IDamageDealer
    {
        /// <summary>
        /// What faction is this entity able to deal damage to?
        /// </summary>
        public List<Factions> hostileTo
        {
            get;
        }

        /// <summary>
        /// Checks if for any given active hurtbox, this entity collides with it.
        /// </summary>
        /// <param name="hurtbox">The hurtbox of the entity you're checking if you're hittign</param>
        /// <returns>Wether or not a collision happened</returns>
        public bool HitCheck(CircleHitbox hurtbox);

        /// <summary>
        /// Returns the amount of damage this should deal
        /// You can use this function to add extra on-hit effects as well.
        /// Do not reduce the target's health in this method though. This is handled automatically
        /// </summary>
        /// <returns>The damage dealt</returns>
        public float DealDamage(BoiEntity target);

        /// <summary>
        /// Can the entity currently hit any other?
        /// </summary>
        public bool ActiveHitbox => true;
    }

    /// <summary>
    /// Used for any entity that can take damage.
    /// </summary>
    public interface IDamageable
    {
        /// <summary>
        /// The health of the entity
        /// </summary>
        public float Health 
        {
            get;
            set;
        }

        /// <summary>
        /// What faction does this entity belong to?
        /// </summary>
        public Factions Faction
        {
            get;
        }

        /// <summary>
        /// Gets the hurtbox of the entity
        /// </summary>
        public CircleHitbox Hurtbox
        {
            get;
        }

        /// <summary>
        /// Can the entity be hit currently?
        /// </summary>
        public bool Vulnerable => true;

        /// <summary>
        /// Called when the entity gets hit. Use for any on hit effects. Do not use this function to remove health from the entity.
        /// </summary>
        public void TakeHit(float damageTaken);

        /// <summary>
        /// Called when the entity hits zero health.
        /// Return true if the entity's health should be checked again after this method is called. Use this if you want ressurection effects / Death prevention.
        /// </summary>
        public bool Die() { return false; }
    }

    /// <summary>
    /// Any entity that can prevent movement
    /// The hitbox should be convex. If you need concave shapes , use more convex objects
    /// </summary>
    public interface ICollidable
    {
        /// <summary>
        /// This should represent the longest distance a point can be from the center of this object and still collide with it.
        /// E.G, a round rock of radius 1 would return 1. A square tile would return the value of one half its diagonal, since the distance between the center and the corner of a square is the longest distance
        /// </summary>
        public float SimulationDistance
        {
            get;
        }

        /// <summary>
        /// Returns the displacement the collision between this object and an entity may lead to.
        /// </summary>
        /// <param name="entityHitbox">The potentially colliding entity' hitbox.</param>
        /// <returns></returns>
        public Vector2 MovementCheck(CircleHitbox entityHitbox);


        /// <summary>
        /// If the collision of this object is currently on. If the entity just never collides, please simply don't implement this interface uwu
        /// </summary>
        public bool CanCollide
        {
            get => true;
        }

        /// <summary>
        /// What happens on a collision with an entity. If you want to hurt them on contact though, it would be wiser to implement an IDamageDealer interface to the object.
        /// </summary>
        /// <param name="collider">What entity collided with this object</param>
        public void OnCollide(BoiEntity collider) { }

    }

    /// <summary>
    /// Represents an entity that can collide with collidable objects.
    /// </summary>
    public interface IColliding
    {
        /// <summary>
        /// Gets the hitbox of the colliding entity
        /// </summary>
        public CircleHitbox CollisionHitbox
        {
            get;
        }

        /// <summary>
        /// If the collision of this object is currently on. If the entity just never collides, please simply don't implement this interface uwu
        /// </summary>
        public bool CanCollide
        {
            get => true;
        }

        /// <summary>
        /// What happens on a collision. Return true if this entity dies on collision
        /// If the collider is null, it means the entity collided with the out of bounds
        /// </summary>
        public bool OnCollide(BoiEntity collider) => false;
    }

    /// <summary>
    /// Represents an object the player can interact with
    /// </summary>
    public interface IInteractable
    {
        /// <summary>
        /// How big the radius of collision is for this interactable.
        /// </summary>
        public float CollisionCircleRadius
        {
            get;
        }

        /// <summary>
        /// Can the player interact with this?
        /// Useful if you want certain items to only be pickable up with a keybind.
        /// </summary>
        public bool CanBeInteractedWith => true;

        /// <summary>
        /// What happens when the item gets interacted with
        /// Return true to kill the interactable after the itneraction
        /// </summary>
        /// <param name="player">The player that interacted with the entity</param>
        public bool Interact(BoiPlayer player);
    }

    /// <summary>
    /// Represents an entity that can be drawn
    /// </summary>
    public interface IDrawable
    {

        /// <summary>
        /// The layer this should be drawn at. 
        /// Higher number = gets drawn above everything else on a lower layer.
        /// </summary>
        public int Layer => 0;

        public void Draw(SpriteBatch spriteBatch, Vector2 offset, float scale);
    }
}