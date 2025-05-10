using System;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;
using System.Collections.Generic;

namespace CalValEX.Projectiles.Pets
{
    public class WormPetSegment
    {
		public Vector2 position, oldPosition;
		public bool head;

		public WormPetVisualSegment visual;
	}

	public class WormPetVisualSegment : ICloneable
    {
		public string TexturePath;
		public bool Glows;
		public int Variants;
		public int FrameCount;
		public int Frame;
		public int FrameDuration;
		public int FrameCounter;
		public bool Directional;
		public int LateralShift;

		/// <summary>
		/// The visual half of a worm pet segment
		/// </summary>
		/// <param name="path">The texture path of the segment</param>
		/// <param name="glows">Does the segment glow</param>
		/// <param name="variants">How many variants (sheeted horizontally) does the segment have</param>
		/// <param name="frames">Is the segment animated?</param>
		/// <param name="frameDuration">How many frames does a frame last</param>
		/// <param name="directional">Should the segment face "up"? or does it not care. If set to true, it will try to keep the left side of the segment up, and the right side down</param>
		/// <param name="lateralShift">How many pixels from the horizontal center should the origin of a segment be displaced. Useful for segments with arms or stuff that sticks out assymetrically</param>
		public WormPetVisualSegment(string path, bool glows = false, int variants = 1, int frames = 1, int frameDuration = 6, bool directional = false, int lateralShift = 0)
        {
			TexturePath = path;
			Glows = glows;
			Variants = variants;
			FrameCount = frames;
			Frame = 0;
			FrameCounter = 0;
			FrameDuration = frameDuration;
			Directional = directional;
			LateralShift = lateralShift;
		}

		public object Clone()
		{
			return MemberwiseClone();
		}
	}

	public abstract class BaseWormPet : ModProjectile
	{
		public abstract WormPetVisualSegment HeadSegment();
		public abstract WormPetVisualSegment BodySegment();
		public abstract WormPetVisualSegment TailSegment();

		private Dictionary<string, WormPetVisualSegment> DefaultSegments => new()
		{
			{ "Head" , HeadSegment() },
			{ "Body" , BodySegment() },
			{ "Tail" , TailSegment() }
		};

		/// <summary>
		/// A dictionary that contains custom segment types if you need to use them
		/// If you want to add custom segments, please remember to not use the "Head", "Body" and "Tail" keys since those are used by the base worm.
		/// </summary>
		public virtual Dictionary<string, WormPetVisualSegment> CustomSegments => new() { };

		/// <summary>
		/// The "height" of a segment. Only counted for the body, the head and tail may be longer and it will be automatically adjusted for it
		/// </summary>
		public abstract int SegmentSize();
		/// <summary>
		/// The amount of segments in the worm
		/// </summary>
		public abstract int SegmentCount();
		/// <summary>
		/// Returns wether or not the pet should exist or not. This usually should be checking for the player bool
		/// </summary>
		/// <returns></returns>
		public abstract bool ExistenceCondition();
		/// <summary>
		/// Where the worm head would like to go, relative to the player's center
		/// </summary>
		public Vector2 RelativeIdealPosition;
		/// <summary>
		/// Where the worm head would like to go relative to the world
		/// </summary>
		public Vector2 IdealPosition => RelativeIdealPosition + Owner.Center;
		/// <summary>
		/// Has the projectile been initialized? This variable is automatically set so please don't use it yourself
		/// </summary>
		public ref float Initialized => ref Projectile.ai[0];
		/// <summary>
		/// The steering angle of the worm head if its far away from the ideal position
		/// </summary>
		public virtual float MinimumSteerAngle => MathHelper.PiOver4 / 4f;
		/// <summary>
		/// The steering angle of the worm head if its close enough to the ideal position. Its good to have this steering angle high so the worm doesnt continually miss its target
		/// </summary>
		public virtual float MaximumSteerAngle => MathHelper.PiOver2;
		/// <summary>
		/// How many variants the worm body has. Variants are sheeted horizontally, so you may have multiple variants and an animated body at once. Of course you can always do the custom drawing yourself
		/// </summary>
		public virtual int BodyVariants => 1;
		/// <summary>
		/// How many pixels down should the head be bashed into the body. Useful if the head doesnt have a flat surface at the bottom of its sprite
		/// </summary>
		public virtual float BashHeadIn => 0;
		/// <summary>
		/// How many iterations of the verlet chain simulation gets run every frame. More iterations = less gaps in the chain at higher speed
		/// </summary>
		public virtual int NumSimulationIterations => 15;
		/// <summary>
		/// How far away the worm should wander away from the players center. This is only useful if UpdateIdealPosition isn't overridden.
		/// </summary>
		public virtual float WanderDistance => Owner.velocity.Length() < 10 ? 200 : 100;
		/// <summary>
		/// The speed at which the worm head moves
		/// </summary>
		public virtual float GetSpeed => MathHelper.Lerp(15, 40, MathHelper.Clamp(Projectile.Distance(IdealPosition) / (WanderDistance * 2.2f) - 1f, 0, 1));
		/// <summary>
		/// The string of text at the end of your texture files if you're going to have a glowmask on the worm (Like, "_Glow" or something)
		/// </summary>
		public virtual string GlowmaskSuffix => "Glow";
		/// <summary>
		/// How opaque the glowmask is
		/// </summary>
		public virtual float GlowmaskOpacity => 1;
		/// <summary>
		/// The texture progression. If you need to introduce custom textures in the progression, add them to the TexturePaths dictionary under a new key, and use that key into the list.
		/// The list starts from the first segment and goes toward the tail. You don't need to put the tail into the list, its automatically taken into account
		/// If the list is shorter than the worm itself, it will continue to use regular body segments after the list stops. If its longer, everything thats further than the tail is not taken into account
		/// For example, if i wanted to have a custom "arm" segment for the first 2 body segments, i'd set the TextureProgression to a new String[] {"Arm", "Arm"}.
		/// </summary>
		public virtual string[] TextureProgression => new string[0];
		/// <summary>
		/// The color the emitted light will be lit in, leave as black for no light.
		/// </summary>
		public virtual Color Lightcolor => Color.Black;
		/// <summary>
		/// How intense the light is.
		/// </summary>
		public virtual float Intensity => 1f;
		/// <summary>
		/// The level of light emitted, check wiki for values.
		/// </summary>
		public virtual int AbyssLightLevel => 0;
		public Player Owner => Main.player[Projectile.owner];
		public CalValEXPlayer ModOwner => Owner.GetModPlayer<CalValEXPlayer>();

		public List<WormPetSegment> Segments;

		public ref float TimeTillReset => ref Projectile.ai[1];

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Base Worm Head");
			ProjectileID.Sets.NeedsUUID[Projectile.type] = true;
			Main.projPet[Projectile.type] = true;
		}

		public override void SetDefaults()
		{
			Projectile.width = Projectile.height = SegmentSize();
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.ignoreWater = true;
			Projectile.netImportant = true;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 300;
			Projectile.tileCollide = false;
		}

		/// <summary>
		/// The full AI. If you don't need to entirely modify it, you can modify other behavior functions
		/// </summary>
		public virtual void WormAI()
		{
			bool shouldDoAI = CheckIfAlive();
			if (shouldDoAI)
			{
				UpdateIdealPosition();
				MoveTowardsIdealPosition();
				SimulateSegments();
				Animate();
				CustomAI();
			}
		}

		/// <summary>
		/// Initialize the worm. You shouldn't have to ever change this yourself
		/// </summary>
		public virtual void Initialize()
		{
			//Initialize the visual segments
			Dictionary<string, WormPetVisualSegment> defaultPool = DefaultSegments;
			Dictionary<string, WormPetVisualSegment> customPool = CustomSegments;
			//Create an ordered list of all the segments 
			WormPetVisualSegment[] visualSegments = new WormPetVisualSegment[SegmentCount()];

			//Start by filling the list with body segments
			for (int i = 0; i < visualSegments.Length; i++)
			{
				visualSegments[i] = (WormPetVisualSegment)defaultPool["Body"].Clone();
			}

			//If any custom segment progression exists, replace the body segments appropriately
			for (int i = 1; i < visualSegments.Length && i < TextureProgression.Length + 1; i++)
			{
				WormPetVisualSegment segment;
				string key = TextureProgression[i - 1];

				//Get the segment from the proper pool of segments
				if (defaultPool.ContainsKey(key))
					segment = defaultPool[key];
				else
					segment = customPool[key];

				//add it to the progression
				visualSegments[i] = (WormPetVisualSegment)segment.Clone();
			}
			//Make the first element be the head and the last element be the tail, obviously
			visualSegments[0] = (WormPetVisualSegment)defaultPool["Head"].Clone();
			visualSegments[visualSegments.Length - 1] = (WormPetVisualSegment)defaultPool["Tail"].Clone();


			//Initialize the segments
			Segments = new List<WormPetSegment>(SegmentCount());
			for (int i = 0; i < SegmentCount(); i++)
            {
				WormPetSegment segment = new();
				segment.head = false;
				segment.position = Projectile.Center + Vector2.UnitY * SegmentSize() * i;
				segment.oldPosition = segment.position;
				segment.visual = visualSegments[i];
				Segments.Add(segment);
            }

			Segments[0].head = true;

			Initialized = 1f;
			return;
		}

		/// <summary>
		/// Checks if the worm should remain alive or if it should kill itself. Return false if the rest of the AI shouldn't even bother executing. This also kills the worm if its too far away from the player
		/// </summary>
		public virtual bool CheckIfAlive()
        {
			if (ExistenceCondition())
			{
				Projectile.timeLeft = 2;
			}

			if (Owner.dead || !Owner.active || Owner.Distance(Projectile.Center) > 4000)
			{
				Projectile.timeLeft = 0;
				return false;
			}

			return true;
		}
		/// <summary>
		/// Updates the ideal position the worm head wants to reach
		/// </summary>
		public virtual void UpdateIdealPosition()
		{
			TimeTillReset++;
			if (TimeTillReset > 150)
			{
				RelativeIdealPosition = Vector2.Zero;
				TimeTillReset = 0;
			}

			//Reset the ideal position if the ideal position was reached
			if (Projectile.Distance(IdealPosition) < GetSpeed)
				RelativeIdealPosition = Vector2.Zero;

			//Get a new ideal position
			if (RelativeIdealPosition == Vector2.Zero)
			{
				RelativeIdealPosition = Main.rand.NextVector2CircularEdge(WanderDistance, WanderDistance);
				return;
			}
		}
		/// <summary>
		/// Makes the head move towards its ideal position.
		/// </summary>
		public virtual void MoveTowardsIdealPosition()
		{
			//Rotate towards its ideal position
			Projectile.rotation = Projectile.rotation.AngleTowards((IdealPosition - Projectile.Center).ToRotation(), MathHelper.Lerp(MaximumSteerAngle, MinimumSteerAngle, MathHelper.Clamp(Projectile.Distance(IdealPosition) / 80f, 0, 1)));
			Projectile.velocity = Projectile.rotation.ToRotationVector2() * GetSpeed;

			//Update its segment
			Segments[0].oldPosition = Segments[0].position;
			Segments[0].position = Projectile.Center;
		}

		/// <summary>
		/// Makes the segments trail behind the worm
		/// </summary>
		public virtual void SimulateSegments()
        {
			//https://youtu.be/PGk0rnyTa1U?t=400 we use verlet integration chains here
			int i = 0;
			float movementLenght = Projectile.velocity.Length();
			foreach(WormPetSegment segment in Segments)
            {
				if (!segment.head)
				{
					Vector2 positionBeforeUpdate = segment.position;

					//segment.position += (segment.position - segment.oldPosition); //=> This adds conservation of energy to the worm segments. This makes it super bouncy and shouldnt be used but it's really funny. Especially if you make the worm affected by gravity
					//segment.position += Vector2.UnitY * 0.2f; //=> This adds gravity to the worm segments. Works especially well when springy

					segment.position += Utils.SafeNormalize(Segments[i - 1].oldPosition - segment.position, Vector2.Zero) * movementLenght; //Makes the segment move towards the forward segment 
					segment.oldPosition = positionBeforeUpdate;
				}
				i++;
            }

			for (int k = 0; k < NumSimulationIterations; k++)
            {
				for (int j = 0; j < SegmentCount() - 1; j++)
				{
					WormPetSegment pointA = Segments[j];
					WormPetSegment pointB = Segments[j + 1];
					Vector2 segmentCenter = (pointA.position + pointB.position) / 2f;
					Vector2 segmentDirection = Utils.SafeNormalize(pointA.position - pointB.position, Vector2.UnitY);

					if (!pointA.head)
						pointA.position = segmentCenter + segmentDirection * SegmentSize() / 2f;

					if (!pointB.head)
						pointB.position = segmentCenter - segmentDirection * SegmentSize() / 2f;

					Segments[j] = pointA;
					Segments[j + 1] = pointB;

					Player owner = Main.player[Projectile.owner];
					Lighting.AddLight(segmentCenter, Lightcolor.ToVector3());

					if (CalValEX.CalamityActive)
						CalValEX.Calamity.Call("AddAbyssLightStrength", owner, AbyssLightLevel);
				}
			}
        }

		/// <summary>
		/// Mess with the frames here if you want a custom animation. By default, simply makes all frames cycle forward
		/// </summary>
		public virtual void Animate()
		{
			foreach (WormPetSegment segment in Segments)
			{
				segment.visual.FrameCounter++;
				if (segment.visual.FrameCounter > segment.visual.FrameDuration)
                {
					segment.visual.Frame++;
					if (segment.visual.Frame >= segment.visual.FrameCount)
						segment.visual.Frame = 0;

					segment.visual.FrameCounter = 0;
                }
			}
		}
		/// <summary>
		/// Gets ran after everything else. Do whatever you want
		/// </summary>
		public virtual void CustomAI() { }


		public override void AI()
        {
			if (Initialized == 0)
				Initialize();
			WormAI();

            // Consistently update the worm
            if ((int)Main.time % 120 == 0)
            {
                Projectile.netUpdate = true;
            }
        }

		public void OldWormMovement()
		{
            Segments[0].oldPosition = Segments[0].position;
            Segments[0].position = Projectile.Center;
            Vector2 PlayerCenter = Owner.Center;
            float MinVel = 0.36f;
            Vector2 ProjDistance = PlayerCenter - Projectile.Center;
            if (ProjDistance.Length() < 100f)
            {
                MinVel = 0.22f;
            }
            if (ProjDistance.Length() < 80f)
            {
                MinVel = 0.1f;
            }
            if (ProjDistance.Length() > 50f)
            {
                if (Math.Abs(PlayerCenter.X - Projectile.Center.X) > 10f)
                {
                    Projectile.velocity.X = Projectile.velocity.X + MinVel * (float)Math.Sign(PlayerCenter.X - Projectile.Center.X);
                }
                if (Math.Abs(PlayerCenter.Y - Projectile.Center.Y) > 5f)
                {
                    Projectile.velocity.Y = Projectile.velocity.Y + MinVel * (float)Math.Sign(PlayerCenter.Y - Projectile.Center.Y);
                }
            }
            float MaxVel = 15f;
            if (ProjDistance.Length() > 800f)
            {
                MaxVel = 25;
            }
            else if (ProjDistance.Length() > 500f)
            {
                MaxVel = 22f;
            }
            else if (ProjDistance.Length() > 300f)
            {
                MaxVel = 18.5f;
            }
            else
            {
                MaxVel = 15;
            }

            if (Projectile.velocity.Length() > MaxVel)
            {
                Projectile.velocity = Vector2.Normalize(Projectile.velocity) * MaxVel;
            }
            if (ProjDistance.Length() > 2000f)
            {
                Projectile.Center = PlayerCenter;
            }
            if (Math.Abs(Projectile.velocity.Y) < 1f)
            {
                Projectile.velocity.Y = Projectile.velocity.Y - 0.1f;
            }
            // NOTE: If you wish for this worm to travel at very high speeds, the
            // Body and tail segments will gain gaps. You would have to change the position adjusting
            // In the body and tail's code to mitigate this problem.

            Projectile.rotation = Projectile.velocity.ToRotation();

            int oldDirection = Projectile.direction;
            Projectile.direction = Projectile.spriteDirection = (Projectile.velocity.X > 0f).ToDirectionInt();

            // Update the projectile in multiplayer if the determined direction is not the true direction.
            // It will do weird things in multiplayer because of a lack of syncing among the directions
            if (oldDirection != Projectile.direction)
            {
                Projectile.netUpdate = true;
            }
        }

        public override bool PreDraw(ref Color lightColor)
        {
			if (Initialized == 0f)
				return false;
			DrawWorm(lightColor);
			return false;
		}

		public override void PostDraw(Color lightColor)
		{
			if (Initialized == 0f)
				return;

			//DrawWorm(lightColor, true);
		}


		/// <summary>
		/// Draws the worm. Override this if you want to draw it yourself. 
		/// Glow indicates wether or not this is the glowmask. You can use it to just change the segmentlight to always be white, or use it to do custom drawing when in the glowmask
		/// </summary>
		public virtual void DrawWorm(Color lightColor, bool glow = false) 
		{
			for (int i = SegmentCount() - 1; i >= 0; i--)
			{
				WormPetVisualSegment currentSegment = Segments[i].visual;
				//If the segment doesn't have a glowmask on the glow pass, simply don't draw it lol?
				if (glow & !currentSegment.Glows)
					continue;

				bool bodySegment = i != 0 && i != SegmentCount() - 1;
				Texture2D sprite = ModContent.Request<Texture2D>(currentSegment.TexturePath).Value;

                Vector2 angleVector = (i == 0 ? Projectile.rotation.ToRotationVector2() : (Segments[i - 1].position - Segments[i].position));
				bool flipped = Math.Sign(angleVector.X) < 0 && currentSegment.Directional; 

				//Get the horizontal start of the frame (for segments with variants)
				int frameStartX = (i % currentSegment.Variants) * sprite.Width / currentSegment.Variants;

				//Get the vertical segment of the frame
				int frameStartY = sprite.Height / currentSegment.FrameCount * currentSegment.Frame;

				int frameWidth = sprite.Width / currentSegment.Variants;
				int frameHeight = (sprite.Height / currentSegment.FrameCount);

				//Remove 2 from the width and height of the frame if the segment has variants/is animated to account for the extra gap of 2 pixels
				frameWidth -= currentSegment.Variants > 1 ? 2 : 0; 
				frameHeight -= (Main.projFrames[Projectile.type] > 1) ? 2 : 0;

				Rectangle frame = new(frameStartX, frameStartY, frameWidth, frameHeight);
				Vector2 origin = bodySegment ? frame.Size() / 2f : i == 0 ? new Vector2(frame.Width / 2f, frame.Height - SegmentSize() / 2f) : new Vector2(frame.Width / 2f, SegmentSize() / 2f);

				if (i == 0)
					origin -= Vector2.UnitY * BashHeadIn;

				origin -= Vector2.UnitX * currentSegment.LateralShift * (flipped ? -1 : 1);

				float rotation = i == 0 ? Projectile.rotation + MathHelper.PiOver2 : (Segments[i].position - Segments[i - 1].position).ToRotation() - MathHelper.PiOver2;

				Color segmentLight = Lighting.GetColor((int)Segments[i].position.X / 16, (int)Segments[i].position.Y / 16); //Lighting of the position of the segment. Pure white if its a glowmask

				Main.EntitySpriteDraw(sprite, Segments[i].position - Main.screenPosition, frame, segmentLight, rotation, origin, Projectile.scale, flipped ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);
				if (currentSegment.Glows)
                {
                    Texture2D glowT = ModContent.Request<Texture2D>(currentSegment.TexturePath + GlowmaskSuffix).Value;
                    Main.EntitySpriteDraw(glowT, Segments[i].position - Main.screenPosition, frame, Color.White * GlowmaskOpacity, rotation, origin, Projectile.scale, flipped ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);
				}
            }
		}
    }
}