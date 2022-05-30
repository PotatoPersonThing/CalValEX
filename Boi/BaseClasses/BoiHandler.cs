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
		public static readonly Vector2 playingField = new Vector2(789, 472);
		public static List<BoiRoom> Map; //Idk how to handle that rn
		public static BoiPlayer Ana;
		public static int UnexploredDoors; //To avoid ending up with unfinished floors

		public static List<BoiEntity> DeadEntities = new List<BoiEntity>();
		public static Dictionary<IColliding, BoiEntity> CollidingEntities = new Dictionary<IColliding, BoiEntity>();
		public static Dictionary<ICollidable, BoiEntity> CollidableEntities = new Dictionary<ICollidable, BoiEntity>();
		public static Dictionary<IDamageable, BoiEntity> DamageableEntities = new Dictionary<IDamageable, BoiEntity>();
		public static Dictionary<IDamageDealer, BoiEntity> DamageDealingEntities = new Dictionary<IDamageDealer, BoiEntity>();
		public static Dictionary<IInteractable, BoiEntity> InteractibleEntities = new Dictionary<IInteractable, BoiEntity>();
		public static List<List<IDrawable>> DrawLayers = new List<List<IDrawable>>();

		public static Vector2 ScreenOffset => new Vector2(Main.screenWidth / 2f, Main.screenHeight / 2f) - playingField / 2f;

		public static void Initialize()
        {
			Map = new List<BoiRoom>();

			BoiRoom room = NewRoom(0, 0, null);
			Map.Add(room);
			Ana = new BoiPlayer(playingField / 2f, 5f, room);

			DrawLayers = new List<List<IDrawable>>();
			DeadEntities = new List<BoiEntity>();
			CollidingEntities = new Dictionary<IColliding, BoiEntity>();
			CollidableEntities = new Dictionary<ICollidable, BoiEntity>();
			DamageableEntities = new Dictionary<IDamageable, BoiEntity>();
			DamageDealingEntities = new Dictionary<IDamageDealer, BoiEntity>();
			InteractibleEntities = new Dictionary<IInteractable, BoiEntity>();
		}

		public static void Unload()
        {
			Map.Clear();
			Ana = null;
			UnexploredDoors = 0;
			DrawLayers.Clear();

        }

		public static BoiRoom NewRoom(int x, int y, BoiRoom roomFrom)
        {
			//Generate room sstuff
			BoiRoom room = new BoiRoom(x, y, roomFrom);

			//Fill the room with entities, i assume.
			room.Populate();

			return room;
        }

		public static void Run()
        {
			//Process the players movement and actions
			Ana.ProcessControls();

			BoiRoom simulatedRoom = Ana.RoomImIn;

			//For each entity
			foreach (BoiEntity entity in simulatedRoom.Entities)
            {
				//-Run their update function (and the UpdateEffect functions of their inventory slots
				entity.Update();
				if (entity.Inventory != null)
				{
					foreach (BoiItem item in entity.Inventory)
						item.UpdateEffect();
				}

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

				//-If they are an active interactible entity and close enough to the player, add them to the list
				if (entity is IInteractable interactable && interactable.CanBeInteractedWith)
				{
					if ((entity.Position - Ana.Position).Length() - Ana.Hitbox.radius < interactable.CollisionCircleRadius)
					{
						InteractibleEntities.Add(interactable, entity);
					}
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

			foreach (IInteractable interactible in InteractibleEntities.Keys)
            {
				if (interactible.Interact(Ana))
					DeadEntities.Add(InteractibleEntities[interactible]);
            }

			//Out of bounds checks & entityn interaction
			foreach (BoiEntity entity in simulatedRoom.Entities)
			{
				if (OOBCheck(entity, entity is IColliding collider))
					DeadEntities.Add(entity);
			}

			//Remove all the dead entities from the list of simulated entities
			simulatedRoom.Entities.RemoveAll(n => DeadEntities.Contains(n));

			//Clear all the lists created earlier (since they were just here to store the entities that were being processed this frame.
			DeadEntities.Clear();
			CollidingEntities.Clear();
			CollidableEntities.Clear();
			DamageableEntities.Clear();
			DamageDealingEntities.Clear();
			InteractibleEntities.Clear();
		}

		public static void Draw(SpriteBatch spriteBatch)
        {
			//Draw base screen
			Texture2D BackgroundTex = ModContent.Request<Texture2D>("CalValEX/ExtraTextures/Pong/PongBG").Value;
			Vector2 offset = BackgroundTex.Size() / 2f - playingField / 2f;
			spriteBatch.Draw(BackgroundTex, ScreenOffset - offset, null, Color.White, 0f, Vector2.Zero, 1f, 0, 0f);

			//Draw room border
			Texture2D BorderTex = ModContent.Request<Texture2D>("CalValEX/Boi/Room").Value;
			Vector2 BorderScale = new Vector2(playingField.X / BorderTex.Width, playingField.Y / BorderTex.Height);
			spriteBatch.Draw(BorderTex, ScreenOffset, null, Color.White, 0f, Vector2.Zero, BorderScale, 0, 0f);


			//Healthbar
			Texture2D HeartTexture = ModContent.Request<Texture2D>("CalValEX/Boi/Heart").Value;
			Vector2 BaseHeartOffset = new Vector2(HeartTexture.Width / 2f, -16 - HeartTexture.Height / 2f);
			Vector2 HeartOffset = new Vector2(HeartTexture.Width + 4f, 0f);

			for (int i = 0; i < (int)Ana.MaxHealth; i++)
			{
				spriteBatch.Draw(HeartTexture, ScreenOffset + BaseHeartOffset + i * HeartOffset, null, Color.DarkGray, 0f, HeartTexture.Size() / 2f, 1f, 0, 0);
			}

			for (int i = 0; i < (int)Ana.Health; i++)
			{
				spriteBatch.Draw(HeartTexture, ScreenOffset +  BaseHeartOffset + i * HeartOffset, null, Color.White, 0f, HeartTexture.Size() / 2f, 1f, 0, 0);
			}

			/* Map

				{
				Texture2D mapicon = ModContent.Request<Texture2D>("CalValEX/ExtraTextures/Pong/PongBall").Value;
				Rectangle rectangle3 = new Rectangle(0, mapicon.Height / Main.projFrames[Projectile.type] * Projectile.frame, mapicon.Width, mapicon.Height / Main.projFrames[Projectile.type]);
				Vector2 position3 = Projectile.Center - Main.screenPosition;
				position3.X = position3.X + DrawOffsetX + 380;
				position3.Y = position3.Y + DrawOriginOffsetY - 150;
				for (int cont = 0; cont < 10; cont++)
				{
					Color cooo;
					if (cont == Projectile.localAI[0])
					{
						cooo = Color.Lime;
					}
					else if (rooms[cont] == 1)
					{
						cooo = Color.White;
					}
					else
					{
						cooo = Color.DarkCyan;
					}
					Main.EntitySpriteDraw(mapicon, new Vector2(position3.X + mapicon.Width * cont, position3.Y), rectangle3, cooo, Projectile.rotation, Projectile.Size / 4f, 1f, (Projectile.direction == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally), 0);
				}
			}

			*/

			//For each entity in Entities, if its an IDrawable, store them in new lists, separated on their Layer
			foreach (BoiEntity entity in Ana.RoomImIn.Entities)
            {
				if (entity is IDrawable drawableEntity)
                {
					int layer = drawableEntity.Layer;

					//If they are just enough layers minus the one we're looking at 
					//For example, if currently we have zero layers and we want to put an entity on layer zero. Or if there are two layers (the layers zero and one) and we want to put an entity on the layer two.
					//In this case, we simply create a new layer after the already existing ones
					if (DrawLayers.Count == layer)
					{
						DrawLayers.Add(new List<IDrawable>());
					}

					//If there are less layers than the amount needed 
					//For example, if we want to add an entity to layer 2 but currently, there is just one layer (The layer zero)
					if (DrawLayers.Count < layer)
					{
						while (!(DrawLayers.Count == layer + 1))
							DrawLayers.Add(new List<IDrawable>());
					}

					//If there are more layers than the layer we want to draw on (this means the layer already got initialized) (which it should have , because of the previous checks.
					if (DrawLayers.Count > layer)
					{
						DrawLayers[layer].Add(drawableEntity);
					}
                }
            }

			//Then for all these lists, draw the IDrawables with the proper scale and offset.
			for (int i = 0; i < DrawLayers.Count; i++)
            {
				foreach (IDrawable drawer in DrawLayers[i])
                {
					drawer.Draw(spriteBatch, ScreenOffset);
                }
            }

			DrawLayers.Clear();
        }

		/// <summary>
		/// Do the necessary processes to make sure an entity doesnt end up out of bound, and kills it if necessary. If the entity needs to die, this function returns true
		/// </summary>
		/// <param name="entity">The entity to check</param>
		/// <param name="Collision">Wether or not the entity can collide with walls. If false, the entity will be able to go out of bounds for a while before getting cleared</param>
		/// <returns>Wether or not the entity died from the oob check</returns>
		public static bool OOBCheck(BoiEntity entity, bool Collision)
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
				if (entity.Position.X > playingField.X + OOBLeeway || entity.Position.X < -OOBLeeway || entity.Position.Y > playingField.Y + OOBLeeway || entity.Position.Y < -OOBLeeway)
				{
					return true;
				}

				return false;
			}
        }
	}
}