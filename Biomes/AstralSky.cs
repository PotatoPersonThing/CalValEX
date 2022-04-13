using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.Utilities;

namespace CalValEX.Biomes
{
    public class AstralSky : CustomSky
    {
        //public static bool DeactivateBGs;
        public bool Active;
        public float Intensity;

        public static Texture2D SkyTexture;

        public override void OnLoad()
        {
            SkyTexture = ModContent.Request<Texture2D>("CalValEX/Backgrounds/AstralSky").Value;
        }

        public override void Update(GameTime gameTime)
        {
            /*Mod catalyst = ModLoader.GetMod("CatalystMod");
            if (catalyst != null)
            {
                DeactivateBGs = (bool)catalyst.Call("anyimportantbgsactive");
            }*/
            if (Active)
            {
                Intensity = Math.Min(1f, 0.01f + Intensity);
            }
            else
            {
                Intensity = Math.Max(0f, Intensity - 0.01f);
            }
        }

        public override void Draw(SpriteBatch spriteBatch, float minDepth, float maxDepth)
        {
            float depth = 7;
            //spriteBatch.Draw(SkyTexture, new Rectangle(0, 0, Main.screenWidth, Main.screenHeight), Color.Lime);
            if (maxDepth >= depth && minDepth < depth)
            {
                if (Main.player[Main.myPlayer].InModBiome(ModContent.GetInstance<AstralBlight>())/* && !DeactivateBGs*/)
                {
                    //Draw the sky box texture
                    spriteBatch.Draw(SkyTexture, new Rectangle(0, 0, Main.screenWidth, Main.screenHeight), Color.Lime);
                }
            }
            //deactivate the sky if in the menu
            if (Main.gameMenu || !Main.LocalPlayer.active /*|| DeactivateBGs*/)
            {
                Active = false;
            }
        }

        public override float GetCloudAlpha()
        {
            return 1f - Intensity;
        }

        public override void Activate(Vector2 position, params object[] args)
        {
            //Intensity = 0.002f;
            Active = true;
        }

        public override void Deactivate(params object[] args)
        {
            Active = false;
        }

        public override void Reset()
        {
            Active = false;
        }

        public override bool IsActive()
        {
            return Active;
        }
    }

    /*public class AstralSkyData : ScreenShaderData
    {
        public AstralSkyData(string passName)
            : base(passName)
        {
        }
        private void UpdateAstralIndex()
        {

        }

        public override void Apply()
        {
            UpdateAstralIndex();
            if (Main.player[Main.myPlayer].InModBiome(ModContent.GetInstance<AstralBlight>()))
            {
                for (int i = 0; i < Main.npc.Length; i++)
                {
                    UseTargetPosition(Main.player[(int)Player.FindClosest(Main.npc[i].position, Main.npc[i].width, Main.npc[i].height)].Center);
                }
            }
            base.Apply();
        }
    }*/
}