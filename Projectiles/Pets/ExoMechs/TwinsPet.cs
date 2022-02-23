using CalamityMod;
using CalamityMod.DataStructures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using static CalamityMod.CalamityUtils;

namespace CalValEX.Projectiles.Pets.ExoMechs
{
    public class TwinsPet : ModProjectile
    {
        internal PrimitiveTrail ArtemisRibbon;
        internal PrimitiveTrail ApolloRibbon;

        public Vector2[] PositionsApollo;
        public Vector2[] PositionsArtemis;

        public float ApolloRotation;
        public float ArtemisRotation;


        public ref float Initialized => ref projectile.ai[0];
        public ref float Behavior => ref projectile.ai[1];
        public Player Owner => Main.player[projectile.owner];

        public static int TrailLenght = 30;
        public float SpinRadius => 100 + (float)Math.Sin(Main.GlobalTime) * 20f + (Owner.GetModPlayer<CalValEXPlayer>().ares ? 200 : 0); //Change the 200 for any distance you want to add whenever ares is equipped


        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Toy Twins");
            Main.projFrames[projectile.type] = 1;
            Main.projPet[projectile.type] = true;
        }

        public override void SetDefaults()
        {
            projectile.width =  1;
            projectile.height = 1;
            projectile.penetrate = -1;
            projectile.netImportant = true;
            projectile.timeLeft *= 5;
            projectile.friendly = true;
            projectile.tileCollide = false;
            projectile.aiStyle = -1;
        }

        public override void AI()
        {
            CalValEXPlayer modPlayer = Owner.GetModPlayer<CalValEXPlayer>();
            if (Owner.dead)
                projectile.timeLeft = 0;
            if (!modPlayer.twins)
                projectile.timeLeft = 0;
            if (modPlayer.twins)
                projectile.timeLeft = 2;

            if (Initialized == 0)
            {
                //Initialize the arm positions
                PositionsArtemis = new Vector2[TrailLenght];
                PositionsApollo = new Vector2[TrailLenght];

                for (int i = 0 ; i < TrailLenght ; i++)
                {
                    PositionsApollo[i] = projectile.Center;
                    PositionsArtemis[i] = projectile.Center;
                }
                Initialized = 1f;
            }

            projectile.rotation += (MathHelper.Pi / (40f - (Owner.velocity.Length() / 20f) * 20f)) * (Owner.direction);
            projectile.Center = Owner.Center;
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
            if (Owner.velocity.Length() > 8)
            {
                PositionsApollo[TrailLenght - 1] = Vector2.Lerp(PositionsApollo[TrailLenght - 1], Owner.Center + Vector2.Normalize(Owner.velocity.RotatedBy(MathHelper.PiOver2)) * SpinRadius + Owner.velocity, 0.2f );
                PositionsArtemis[TrailLenght - 1] = Vector2.Lerp(PositionsArtemis[TrailLenght - 1], Owner.Center - Vector2.Normalize(Owner.velocity.RotatedBy(MathHelper.PiOver2)) * SpinRadius + Owner.velocity, 0.2f );

                ApolloRotation = ApolloRotation.AngleLerp(Owner.velocity.ToRotation() + MathHelper.PiOver2, 0.2f);
                ArtemisRotation = ApolloRotation.AngleLerp(Owner.velocity.ToRotation() + MathHelper.PiOver2, 0.2f);
            }    

            else
            {

                PositionsApollo[TrailLenght - 1] = Vector2.Lerp(PositionsApollo[TrailLenght - 1], projectile.Center + projectile.rotation.ToRotationVector2() * SpinRadius, 0.2f);
                PositionsArtemis[TrailLenght - 1] = Vector2.Lerp(PositionsArtemis[TrailLenght - 1], projectile.Center - projectile.rotation.ToRotationVector2() * SpinRadius, 0.2f);

                float idealApolloRotation = projectile.rotation - MathHelper.Pi * (Owner.direction < 0 ? 0 : 1);
                float idealArtemisRotation = projectile.rotation - MathHelper.Pi * (Owner.direction < 0 ? 1 : 0);

                if (Math.Abs(ApolloRotation - idealApolloRotation) > MathHelper.PiOver4)
                    ApolloRotation = ApolloRotation.AngleTowards(idealApolloRotation, 0.2f);
                else
                    ApolloRotation = idealApolloRotation;

                if (Math.Abs(ArtemisRotation - idealArtemisRotation) > MathHelper.PiOver4)
                    ArtemisRotation = ArtemisRotation.AngleTowards(idealArtemisRotation, 0.2f);
                else
                    ArtemisRotation = idealArtemisRotation;
            }

        }

        //STOLED FROM THE REAL ONES???
        public float RibbonTrailWidthFunction(float completionRatio)
        {
            float baseWidth = Utils.InverseLerp(1f, 0.54f, 1 - completionRatio, true) * 5f;
            float endTipWidth = CalamityUtils.Convert01To010(Utils.InverseLerp(0.96f, 0.89f, 1 - completionRatio, true)) * 2.4f;
            return baseWidth + endTipWidth;
        }
        public Color OrangeRibbonTrailColorFunction(float completionRatio)
        {
            Color startingColor = new Color(34, 40, 48);
            Color endColor = new Color(219, 82, 28);
            return Color.Lerp(startingColor, endColor, (float)Math.Pow(1 - completionRatio, 1.5D)) * 0.7f;
        }
        public Color GreenRibbonTrailColorFunction(float completionRatio)
        {
            Color startingColor = new Color(34, 40, 48);
            Color endColor = new Color(40, 160, 32);
            return Color.Lerp(startingColor, endColor, (float)Math.Pow(1 - completionRatio, 1.5D)) * 0.7f;
        }


        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D tex = (ModContent.GetTexture("CalValEX/Projectiles/Pets/ExoMechs/TwinsPet"));
            Rectangle apolloFrame = new Rectangle(0, 0, 62, 52);
            Rectangle artemisFrame = new Rectangle(64, 0, 62, 52);
            Vector2 origin = new Vector2(31, 36);

            if (ArtemisRibbon is null)
                ArtemisRibbon = new PrimitiveTrail(RibbonTrailWidthFunction, OrangeRibbonTrailColorFunction);
            if (ApolloRibbon is null)
                ApolloRibbon = new PrimitiveTrail(RibbonTrailWidthFunction, GreenRibbonTrailColorFunction);

            ApolloRibbon.Draw(PositionsApollo, -Main.screenPosition, 66);
            ArtemisRibbon.Draw(PositionsArtemis, -Main.screenPosition, 66);

            spriteBatch.Draw(tex, PositionsApollo[TrailLenght - 1] - Main.screenPosition, apolloFrame, drawColor, ApolloRotation, origin, projectile.scale, 0f, 0f);
            spriteBatch.Draw(tex, PositionsArtemis[TrailLenght - 1] - Main.screenPosition, artemisFrame, drawColor, ArtemisRotation, origin, projectile.scale, 0f, 0f);
            return false;
        }
    }
}