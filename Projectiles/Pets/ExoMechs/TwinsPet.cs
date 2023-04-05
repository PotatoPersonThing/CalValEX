using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.Pets.ExoMechs
{
    public class TwinsPet : ModProjectile
    {

        public Vector2[] PositionsApollo;
        public Vector2[] PositionsArtemis;

        public float ApolloRotation;
        public float ArtemisRotation;

        public Color RibbonStartColor = new Color(34, 40, 48);


        public ref float Initialized => ref Projectile.ai[0];
        public ref float Behavior => ref Projectile.ai[1];
        public Player Owner => Main.player[Projectile.owner];

        public static int TrailLenght = 30;
        public float SpinRadius => 125 + (Owner.GetModPlayer<CalValEXPlayer>().ares ? 200 : 0); //Change the 200 for any distance you want to add whenever ares is equipped


        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Toy Twins");
            Main.projFrames[Projectile.type] = 1;
            Main.projPet[Projectile.type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.width = 1;
            Projectile.height = 1;
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
            if (!modPlayer.twins)
                Projectile.timeLeft = 0;
            if (modPlayer.twins)
                Projectile.timeLeft = 2;

            if (Initialized == 0)
            {
                //Initialize the arm positions
                PositionsArtemis = new Vector2[TrailLenght];
                PositionsApollo = new Vector2[TrailLenght];

                for (int i = 0; i < TrailLenght; i++)
                {
                    PositionsApollo[i] = Projectile.Center;
                    PositionsArtemis[i] = Projectile.Center;
                }
                Initialized = 1f;
            }

            Projectile.rotation += (MathHelper.Pi / (40f - (Owner.velocity.Length() / 20f) * 20f)) * (Owner.direction);
            Projectile.Center = Owner.Center;
            UpdateTwins();

        }

        public void UpdateTwins()
        {
            //Shift down the previous positions
            for (int i = 0; i < TrailLenght - 1; i++)
            {
                PositionsApollo[i] = PositionsApollo[i + 1];
                PositionsArtemis[i] = PositionsArtemis[i + 1];
            }

            //Give them a new position

            //If the owner is going fast, place them at both sides of the player facing in the direction of the motion
            if (Owner.velocity.Length() > 10)
            {
                PositionsApollo[TrailLenght - 1] = Vector2.Lerp(PositionsApollo[TrailLenght - 1], Owner.Center + Vector2.Normalize(Owner.velocity.RotatedBy(MathHelper.PiOver2)) * SpinRadius + Owner.velocity, 0.2f);
                PositionsArtemis[TrailLenght - 1] = Vector2.Lerp(PositionsArtemis[TrailLenght - 1], Owner.Center - Vector2.Normalize(Owner.velocity.RotatedBy(MathHelper.PiOver2)) * SpinRadius + Owner.velocity, 0.2f);

                ApolloRotation = ApolloRotation.AngleLerp(Owner.velocity.ToRotation() + MathHelper.PiOver2, 0.2f);
                ArtemisRotation = ApolloRotation.AngleLerp(Owner.velocity.ToRotation() + MathHelper.PiOver2, 0.2f);
            }

            //If the owner is going slow make them rotate around the player
            else
            {
                PositionsApollo[TrailLenght - 1] = Vector2.Lerp(PositionsApollo[TrailLenght - 1], Projectile.Center + Projectile.rotation.ToRotationVector2() * SpinRadius, 0.2f);
                PositionsArtemis[TrailLenght - 1] = Vector2.Lerp(PositionsArtemis[TrailLenght - 1], Projectile.Center - Projectile.rotation.ToRotationVector2() * SpinRadius, 0.2f);

                float idealApolloRotation = Projectile.rotation - MathHelper.Pi * (Owner.direction < 0 ? 0 : 1);
                float idealArtemisRotation = Projectile.rotation - MathHelper.Pi * (Owner.direction < 0 ? 1 : 0);

                //Snap them in place if they're close enough to their ideal rotation or else some funky stuff starts to happen
                if (Math.Abs(ApolloRotation - idealApolloRotation) > MathHelper.PiOver4)
                    ApolloRotation = ApolloRotation.AngleTowards(idealApolloRotation, 0.2f);
                else
                    ApolloRotation = idealApolloRotation;

                if (Math.Abs(ArtemisRotation - idealArtemisRotation) > MathHelper.PiOver4)
                    ArtemisRotation = ArtemisRotation.AngleTowards(idealArtemisRotation, 0.2f);
                else
                    ArtemisRotation = idealArtemisRotation;
            }

            //Ribbons go blue if you go fast, go back to gray if you go slow
            Color IdealColor = Color.Lerp(new Color(34, 40, 48), Color.DeepSkyBlue, MathHelper.Clamp(Owner.velocity.Length() - 5, 0, 20) / 10f);
            RibbonStartColor = Color.Lerp(RibbonStartColor, IdealColor, 0.2f);
        }

        //STOLED FROM THE REAL ONES???
        public float RibbonTrailWidthFunction(float completionRatio)
        {
            float tail = (float)Math.Pow(completionRatio, 2) * 7;
            float bump = Utils.GetLerpValue(0.7f, 0.8f, 1-completionRatio, true) * Utils.GetLerpValue(1f, 0.8f, 1-completionRatio, true) * 4;
            return tail + bump;
        }
        public Color OrangeRibbonTrailColorFunction(float completionRatio)
        {
            Color startingColor = RibbonStartColor;
            Color endColor = new Color(219, 82, 28);
            return Color.Lerp(startingColor, endColor, (float)Math.Pow(1 - completionRatio, 1.5D)) * 0.7f;
        }
        public Color GreenRibbonTrailColorFunction(float completionRatio)
        {
            Color startingColor = RibbonStartColor;
            Color endColor = new Color(40, 160, 32);
            return Color.Lerp(startingColor, endColor, (float)Math.Pow(1 - completionRatio, 1.5D)) * 0.7f;
        }


        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D tex = (ModContent.Request<Texture2D>("CalValEX/Projectiles/Pets/ExoMechs/TwinsPet")).Value;


            bool secondPhase = false;
            if (Owner.velocity.Length() > 10)
                secondPhase = true;


            Rectangle apolloFrame = new Rectangle(0, secondPhase ? 54 : 0, 62, 52);
            Rectangle artemisFrame = new Rectangle(64, secondPhase ? 54 : 0, 62, 52);
            Vector2 origin = new Vector2(31, 36);

            float[] RotationsApollo = new float[PositionsApollo.Length];
            float[] RotationsArtemis = new float[PositionsArtemis.Length];
            for (int i = 1; i < PositionsApollo.Length; i++)
            {
                RotationsApollo[i] = PositionsApollo[i - 1].AngleTo(PositionsApollo[i]);
                RotationsArtemis[i] = PositionsArtemis[i - 1].AngleTo(PositionsArtemis[i]);
            }
            RotationsApollo[0] = ApolloRotation;
            RotationsArtemis[0] = ArtemisRotation;

            Terraria.Graphics.VertexStrip apolloStrip = new Terraria.Graphics.VertexStrip();
            Terraria.Graphics.VertexStrip artemisStrip = new Terraria.Graphics.VertexStrip();
            apolloStrip.PrepareStripWithProceduralPadding(PositionsApollo, RotationsApollo, GreenRibbonTrailColorFunction, RibbonTrailWidthFunction, -Main.screenPosition, true);
            artemisStrip.PrepareStripWithProceduralPadding(PositionsArtemis, RotationsArtemis, OrangeRibbonTrailColorFunction, RibbonTrailWidthFunction, -Main.screenPosition, true);

            Effect vertexShader = ModContent.Request<Effect>($"{nameof(CalValEX)}/Effects/VertexShader", ReLogic.Content.AssetRequestMode.ImmediateLoad).Value;
            vertexShader.Parameters["uColor"].SetValue(Vector4.One);
            vertexShader.Parameters["uTransformMatrix"].SetValue(Main.GameViewMatrix.NormalizedTransformationmatrix);
            vertexShader.CurrentTechnique.Passes[0].Apply();

            apolloStrip.DrawTrail();
            artemisStrip.DrawTrail();

            Main.pixelShader.CurrentTechnique.Passes[0].Apply();

            Main.EntitySpriteDraw(tex, PositionsApollo[TrailLenght - 1] - Main.screenPosition, apolloFrame, lightColor, ApolloRotation, origin, Projectile.scale, 0, 0);
            Main.EntitySpriteDraw(tex, PositionsArtemis[TrailLenght - 1] - Main.screenPosition, artemisFrame, lightColor, ArtemisRotation, origin, Projectile.scale, 0, 0);
            return false;
        }
    }
}