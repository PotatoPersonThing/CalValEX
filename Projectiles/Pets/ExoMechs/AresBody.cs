using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.Pets.ExoMechs
{
    public class AresBody : ModProjectile
    {
        bool isInfernumActive;
        //A list of the ideal positions for each arm. The first 2 variables of the Vector2 represent the relative position of the arm to the body and the last variable represents the rotation of the hand
        internal readonly List<Vector3> IdealPositions = new List<Vector3>()
        {
            new Vector3(-170f, -32f, MathHelper.ToRadians(240)), //Top left arm
            new Vector3(-100f, 42f, MathHelper.ToRadians(270)), //Bottom left arm
            
            new Vector3(100f, 42f, MathHelper.ToRadians(270)), //Bottom right arm
            new Vector3(170f, -32f, MathHelper.ToRadians(300)) //Top right arm
        };

        private Vector2 GetIdealPosition(int i) => Projectile.Center + new Vector2(IdealPositions[i].X, IdealPositions[i].Y);

        private Vector2 BobVector => new Vector2(0, -2 + 4 * MathHelper.Clamp((float)Math.Sin(Main.time % MathHelper.Pi), 0, 1) * 0.7f + 0.3f);

        private List<Vector3> ArmPositions;

        public ref float Initialized => ref Projectile.ai[0];

        public Player Owner => Main.player[Projectile.owner];

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Toy Ares");
            Main.projFrames[Projectile.type] = 1;
            Main.projPet[Projectile.type] = true;
            //drawOriginOffsetY = -15;
            //drawOffsetX = -14;
        }

        public override void SetDefaults()
        {
            Projectile.width =  66;
            Projectile.height = 66;
            Projectile.penetrate = -1;
            Projectile.netImportant = true;
            Projectile.timeLeft *= 5;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.aiStyle = -1;
        }

        public override void AI()
        {
            CalValEXPlayer modPlayer = Owner.GetModPlayer<CalValEXPlayer>();
            if (Owner.dead)
                Projectile.timeLeft = 0;
            if (!modPlayer.ares)
                Projectile.timeLeft = 0;
            if (modPlayer.ares)
                Projectile.timeLeft = 2;

            if (Initialized == 0)
            {
                //Initialize the arm positions
                ArmPositions = new List<Vector3>(4);
                for (int i = 0; i < 4; i++)
                {
                    ArmPositions.Add(new Vector3(GetIdealPosition(i), IdealPositions[i].Z));
                }
                Initialized = 1f;
            }

            Vector2 idealPosition = Owner.Center + Vector2.UnitY * -60;
            Projectile.Center = Vector2.Lerp(Projectile.Center, idealPosition, 0.2f);
            Projectile.Center.MoveTowards(idealPosition, 2);

            //Teleport ares to the ideal position if the owner is too far
            if ((idealPosition - Projectile.Center).Length() > 2000)
                Projectile.Center = idealPosition;

            if (ArmPositions != null)
            {
                for (int i = 0; i < ArmPositions.Count; i++)
                {
                    //Make the arm lag behind a bit
                    Vector3 armPosition = ArmPositions[i];
                    Vector2 idealArmPosition = GetIdealPosition(i);
                    Vector2 vector2position = new Vector2(armPosition.X, armPosition.Y);
                    vector2position = Vector2.Lerp(vector2position, idealArmPosition, 0.2f) + BobVector;

                    //Make the cannon look at the mouse cursor if its close enough

                    armPosition.Z = Utils.AngleLerp(armPosition.Z, IdealPositions[i].Z ,MathHelper.Clamp((Main.MouseWorld - vector2position).Length() / 300f, 0, 1));

                    armPosition.Z = Utils.AngleLerp(armPosition.Z, (vector2position - Main.MouseWorld).ToRotation(), 1 - MathHelper.Clamp((Main.MouseWorld - vector2position).Length() / 300f, 0, 1));

                    ArmPositions[i] = new Vector3(vector2position, armPosition.Z);
                }
            }
        }
        public override bool PreDrawExtras()
        {
            DrawChain();


            if (ArmPositions == null)
                return true;

            Texture2D teslaTex = (ModContent.Request<Texture2D>("CalValEX/Projectiles/Pets/ExoMechs/AresTesla")).Value;
            Texture2D laserTex = (ModContent.Request<Texture2D>("CalValEX/Projectiles/Pets/ExoMechs/AresLaser")).Value;
            Texture2D nukeTex = (ModContent.Request<Texture2D>("CalValEX/Projectiles/Pets/ExoMechs/AresNuke")).Value;
            Texture2D plasmaTex = (ModContent.Request<Texture2D>("CalValEX/Projectiles/Pets/ExoMechs/AresPlasma")).Value;
            //Mod infern = ModLoader.GetMod("InfernumMode");
            /*if (infern != null)
            {
                if ((bool)infern.Call("GetInfernumActive"))
                {
                    isInfernumActive = true;
                }
                else
                {
                    isInfernumActive = false;
                }
            }*/

            //Upper arms
            DrawSingleArm(laserTex, new Vector2(ArmPositions[0].X, ArmPositions[0].Y), ArmPositions[0].Z, new Vector2(0, -10), true);
            DrawSingleArm(nukeTex, new Vector2(ArmPositions[3].X, ArmPositions[3].Y), ArmPositions[3].Z, new Vector2(0, -10), true, isInfernumActive);

            //Lower arms
            DrawSingleArm(teslaTex, new Vector2(ArmPositions[1].X, ArmPositions[1].Y), ArmPositions[1].Z, Vector2.Zero, false);
            DrawSingleArm(plasmaTex, new Vector2(ArmPositions[2].X, ArmPositions[2].Y), ArmPositions[2].Z, Vector2.Zero, false);

            return true;
        }

        public void DrawSingleArm(Texture2D handTex, Vector2 handPosition, float rotation, Vector2 offset, bool top, bool infernum = false)
        {
            Vector2 position = handPosition - Projectile.Center;
            bool flipped = Math.Sign(position.X) != -1;

            Texture2D armTex = ModContent.Request<Texture2D>("CalValEX/Projectiles/Pets/ExoMechs/AresArm").Value;
            Texture2D forearmTex = ModContent.Request<Texture2D>("CalValEX/Projectiles/Pets/ExoMechs/AresForearm").Value;

            Rectangle armFrame = new Rectangle(0, top ? 0 : 42, armTex.Width, 40);
            Rectangle handFrame = new Rectangle(0, infernum ? 40 : 0, 60, 38);

            Vector2 armOrigin = new Vector2(flipped ? 0 : armFrame.Width, armFrame.Height / 2);
            Vector2 forearmOrigin = new Vector2(flipped ? 0 : forearmTex.Width, forearmTex.Height / 2);
            Vector2 handOrigin = new Vector2(flipped ? 28 : 22, 22); //22

            Vector2 armPosition = Projectile.Center + position * 0.1f;

            //Do some trigonometry to get the elbow position
            //https://media.discordapp.net/attachments/802291445360623686/945629317608669194/unknown.png
            float armLenght = 175;
            float directLenght = MathHelper.Clamp((handPosition - armPosition).Length(), 0, armLenght); //Clamp the direct lenght to avoid getting an error from trying to calculate the square root of a negative number
            float elbowElevation = (float)Math.Sqrt(Math.Pow(armLenght / 2f, 2) - Math.Pow(directLenght / 2f, 2));
            Vector2 elbowPosition = Vector2.Lerp(handPosition, armPosition, 0.5f) + Utils.SafeNormalize(position, Vector2.Zero).RotatedBy(-MathHelper.PiOver2 * Math.Sign(position.X)) * elbowElevation;

            float armAngle = (elbowPosition - armPosition).ToRotation();
            float forearmAngle = (handPosition - elbowPosition).ToRotation();

            Vector2 forearmPosition = elbowPosition + forearmAngle.ToRotationVector2() * (((elbowPosition - handPosition).Length() - 40) / 2f);
            armPosition += armAngle.ToRotationVector2() * (top ? 30 : 20);

            armAngle += flipped ? 0 : MathHelper.Pi;
            forearmAngle += flipped ? 0 : MathHelper.Pi;

            SpriteEffects flip = flipped ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
            SpriteEffects armFlip = flipped ? SpriteEffects.None : SpriteEffects.FlipHorizontally;

            Main.EntitySpriteDraw(armTex, armPosition + offset - Main.screenPosition, armFrame, Color.White, armAngle, armOrigin, Projectile.scale, armFlip, 0);
            Main.EntitySpriteDraw(forearmTex, forearmPosition + offset - Main.screenPosition, null, Color.White, forearmAngle, forearmOrigin, Projectile.scale, armFlip, 0);
            Main.EntitySpriteDraw(handTex, handPosition + offset - Main.screenPosition, handFrame, Color.White, rotation + (flipped ? 0 : MathHelper.Pi), handOrigin, Projectile.scale, flip, 0);
        }

        private void DrawChain()
        {
            Texture2D chainTex = ModContent.Request<Texture2D>("CalValEX/Projectiles/Pets/ExoMechs/AresChain").Value;

            float curvature = MathHelper.Clamp(Math.Abs(Owner.Center.X - Projectile.Center.X) / 50f * 80, 15, 80);

            Vector2 controlPoint1 = Owner.Center - Vector2.UnitY * curvature;
            Vector2 controlPoint2 = Projectile.Center + Vector2.UnitY * curvature;

            //BezierCurve curve = new BezierCurve(new Vector2[] { Owner.Center, controlPoint1, controlPoint2, Projectile.Center });
            int numPoints = 20; //"Should make dynamic based on curve length, but I'm not sure how to smoothly do that while using a bezier curve" -Graydee, from the code i referenced. I do agree.
            /*Vector2[] chainPositions = curve.GetPoints(numPoints).ToArray();

            //Draw each chain segment bar the very first one
            for (int i = 1; i < numPoints; i++)
            {
                Vector2 position = chainPositions[i];
                float rotation = (chainPositions[i] - chainPositions[i - 1]).ToRotation() - MathHelper.PiOver2; //Calculate rotation based on direction from last point
                float yScale = Vector2.Distance(chainPositions[i], chainPositions[i - 1]) / chainTex.Height; //Calculate how much to squash/stretch for smooth chain based on distance between points
                Vector2 scale = new Vector2(1, yScale);
                Color chainLightColor = Lighting.GetColor((int)position.X / 16, (int)position.Y / 16); //Lighting of the position of the chain segment
                Vector2 origin = new Vector2(chainTex.Width / 2, chainTex.Height); //Draw from center bottom of texture
                spriteBatch.Draw(chainTex, position - Main.screenPosition, null, chainLightColor, rotation, origin, scale, SpriteEffects.None, 0);
            }*/
        }

        public override void PostDraw(Color lightColor)
        {
            Texture2D eyesTex = ModContent.Request<Texture2D>("CalValEX/Projectiles/Pets/ExoMechs/AresEyes").Value;

            Vector2 offset = Utils.SafeNormalize(Main.MouseWorld - (Projectile.Center - Vector2.UnitY * 10), Vector2.Zero) * MathHelper.Clamp((Projectile.Center - Vector2.UnitY * 10 - Main.MouseWorld).Length(), 0, 1);
            float eyeOpacity = (1 - MathHelper.Clamp((float)Math.Sin(Main.time % MathHelper.Pi) * 2f, 0, 1)) * 0.5f;

            Main.EntitySpriteDraw(eyesTex, Projectile.Center + offset - Main.screenPosition, null, Color.White * eyeOpacity, Projectile.rotation, eyesTex.Size() / 2f, Projectile.scale, 0f, 0);
        }
    }
}