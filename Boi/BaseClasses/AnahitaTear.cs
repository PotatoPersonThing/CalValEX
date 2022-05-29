using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace CalValEX.Boi.BaseClasses
{
    public class AnahitaTear : BoiEntity, IDamageDealer, IDrawable
    {
        public CircleHitbox Hitbox => new CircleHitbox(Position, 5);
        public string Texture => "CalValEX/ExtraTextures/Boi/AnahitaTear";
        public Factions Faction => Factions.ally;
        public CircleHitbox Hurtbox => Hitbox;

        public float DealDamage(BoiEntity target)
        {
            return 1;
        }
        public bool HitCheck(CircleHitbox hit)
        {
            return false;
        }

        public bool ActiveHitbox => true;
        public List<Factions> hostileTo
        {
            get => hostileTo;
        }
        
        public override void Update() { }

        public void Draw(SpriteBatch spriteBatch, Vector2 offset, float scale)
        {

        }
        public int Layer => 1;
    }
}