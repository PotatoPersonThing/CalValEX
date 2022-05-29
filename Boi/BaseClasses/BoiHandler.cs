using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;

namespace CalValEX.Boi.BaseClasses
{
	public class BoiHandler
	{
		public const float OOBLeeway = 100;
		public static Vector2 playingField = new Vector2(500, 500);
		public List<BoiRoom> Map;
		public List<BoiEntity> Entities = new List<BoiEntity> { BoiPlayer, AnahitaTear};

		public List<BoiEntity> DeadEntities = new List<BoiEntity>();
		public Dictionary<IColliding, BoiEntity> CollidingEntities = new Dictionary<IColliding, BoiEntity>();
		public Dictionary<ICollidable, BoiEntity> CollidableEntities = new Dictionary<ICollidable, BoiEntity>();
		public Dictionary<IDamageable, BoiEntity> DamageableEntities = new Dictionary<IDamageable, BoiEntity>();
		public Dictionary<IDamageDealer, BoiEntity> DamageDealingEntities = new Dictionary<IDamageDealer, BoiEntity>();
		public Dictionary<IInteractable, BoiEntity> InteractibleEntities = new Dictionary<IInteractable, BoiEntity>();
		public Dictionary<IDrawable, BoiEntity> DrawableEntities = new Dictionary<IDrawable, BoiEntity>();

		public bool spawnAna = false;


		public void Run()
		{
			//Process the players movement and actions
			foreach (BoiPlayer player in Entities)
            {
				player.ProcessControls();
            }

			//Spawn Anahita...?
			foreach (BoiPlayer player in Entities)
			{
				if (!spawnAna)
				{
					Entities.Add(player);
					spawnAna = true;
				}				
			}

			//For each entity
			foreach (BoiEntity entity in Entities)
            {
				//-Run their update function (and the UpdateEffect functions of their inventory slots
				entity.Update();
				foreach (BoiItem item in entity.Inventory)
					item.UpdateEffect();

				entity.OldPosition = entity.Position;
				entity.Position += entity.Velocity;

				//-If they are an active colliding entity, add them to the list.
				if (entity is IColliding colliding && colliding.CanCollide)
                {
					CollidingEntities.Add(colliding, entity);
                }

				//-If they are an active collidable entity, add them to the list.
				if (entity is ICollidable collider && collider.CanCollide)
				{
					CollidableEntities.Add(collider, entity);
				}

				//-If they are an active damageable entity, add them to the list.
				if (entity is IDamageable damageTaker && damageTaker.Vulnerable)
				{
					DamageableEntities.Add(damageTaker, entity);
				}

				//-If they are an active damage dealing entity, add them to the list.
				if (entity is IDamageDealer damageDealer && damageDealer.ActiveHitbox)
				{
					DamageDealingEntities.Add(damageDealer, entity);
				}

				//-If they are an active interactible  entity, add them to the list.
				if (entity is IInteractable interactable && interactable.CanBeInteractedWith)
				{
					InteractibleEntities.Add(interactable, entity);
				}
			}

			//If their health is now under zero, run the Die function, then clear them from the Entities list, unless the function returns true. In which case, check if their health is under zero again (until either they have more than zero hp, or the function returns false)
			//For each IDamageDealer 
			foreach (IDamageDealer damageDealer in DamageDealingEntities.Keys)
            {
				BoiEntity hurtfulEntity = DamageDealingEntities[damageDealer];

				//Run the HitCheck function on all IDamageable hurtboxes that can are of a faction that they are hostile to. 
				foreach (IDamageable damageable in DamageableEntities.Keys)
                {
					if (!damageDealer.hostileTo.Contains(damageable.Faction))
						continue;

					BoiEntity damageableEntity = DamageableEntities[damageable];

					//Ignore entities that arleady died.
					if (DeadEntities.Contains(damageableEntity))
						continue;

					//Call the DamageTaken function of any of the IDamageable entity that were hit

					if (damageDealer.HitCheck(damageable.Hurtbox))
					{
						float damage = damageDealer.DealDamage(damageableEntity);
						damageable.Health -= damage;
						damageable.TakeHit(damage);

						bool hasDied = false;
						while (damageable.Health <= 0 && !hasDied)
                        {
							hasDied = !damageable.Die();
						}

						if (hasDied)
							DeadEntities.Add(damageableEntity);

					}
                }
            }

			//For each entity that is IColliding and has CanCollide set to true (as listed above)
			foreach (IColliding colliding in CollidingEntities.Keys)
			{
				BoiEntity collidingEntity = CollidingEntities[colliding];

				//Check for all IColliders, and grab their SimulationDistance.
				foreach (ICollidable collider in CollidableEntities.Keys)
				{
					BoiEntity colliderEntity = CollidableEntities[collider];

					//If the simulation distance + the CollisionCircleRadius of the IColliding is higher than the distance between the two entities, thats awesome, don't even do anything about it and go to the next one
					if ((colliderEntity.Position - collidingEntity.Position).Length() > collider.SimulationDistance + colliding.CollisionHitbox.radius)
						continue;

					//If it ISNT, call the MovementCheck function and displace the colliding entity by the provided vector
					collidingEntity.Position += collider.MovementCheck(colliding.CollisionHitbox);

					//Call both their onCollide function. Kill the colliding entity if its onCollide returns true
					collider.OnCollide(collidingEntity);
					if (colliding.OnCollide(colliderEntity))
					{
						DeadEntities.Add(collidingEntity);
						break;
					}
				}
			}
			Draw();

			//For each IInteractable, check if the player is in their InteractionRadius and if they have CanBeInteracted to true. If it is the case, simply just run their Interact() function.
			//Kill the interactable if the Interact function returns true


			//Out of bounds checks
			foreach (BoiEntity entity in Entities)
			{
				if (OOBCheck(entity, entity is IColliding collider))
					DeadEntities.Add(entity);
			}

			//Remove all the dead entities from the list of simulated entities
			Entities.RemoveAll(n => DeadEntities.Contains(n));

			//Clear all the lists created earlier
			DeadEntities.Clear();
			CollidingEntities.Clear();
			CollidableEntities.Clear();
			DamageableEntities.Clear();
			DamageDealingEntities.Clear();
		}

		public void Draw()
		{
			Texture2D screen = ModContent.Request<Texture2D>("CalValEX/ExtraTextures/Pong/PongBG").Value;
			Texture2D walls = ModContent.Request<Texture2D>("CalValEX/ExtraTextures/Boi/Room").Value;
			Main.EntitySpriteDraw(screen, playingField, null, Color.White, 0f, new Vector2(screen.Width, screen.Height) / 2, 1f, SpriteEffects.None, 0);
			Main.EntitySpriteDraw(walls, playingField, null, Color.White, 0f, new Vector2(screen.Width, screen.Height) / 2, 1f, SpriteEffects.None, 0);
			foreach (IDrawable tear  in DrawableEntities)
            {
				tear.Draw();
			}
		}

		/// <summary>
		/// Do the necessary processes to make sure an entity doesnt end up out of bound, and kills it if necessary. If the entity needs to die, this function returns true
		/// </summary>
		/// <param name="entity">The entity to check</param>
		/// <param name="Collision">Wether or not the entity can collide with walls. If false, the entity will be able to go out of bounds for a while before getting cleared</param>
		/// <returns>Wether or not the entity died from the oob check</returns>
		public bool OOBCheck(BoiEntity entity, bool Collision)
        {
			if (Collision)
            {
				IColliding collider = entity as IColliding;
				bool isOOB = false;
				float collisionRadius = collider.CollisionHitbox.radius;

				if (entity.Position.X > playingField.X - collisionRadius || entity.Position.X < collisionRadius)
                {
					isOOB = true;
					entity.Position.X = MathHelper.Clamp(entity.Position.X, collisionRadius, playingField.X - collisionRadius);
                }

				if (entity.Position.Y > playingField.Y - collisionRadius || entity.Position.Y < collisionRadius)
				{
					isOOB = true;
					entity.Position.Y = MathHelper.Clamp(entity.Position.Y, collisionRadius, playingField.Y - collisionRadius);
				}

				if (isOOB)
                {
					return collider.OnCollide(null);
                }

				return false;
            }

			else
            {
				if (entity.Position.X > playingField.X + OOBLeeway || entity.Position.X < OOBLeeway || entity.Position.Y > playingField.Y + OOBLeeway || entity.Position.Y < OOBLeeway)
				{
					return true;
				}

				return false;
			}
        }
	}
}