using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CalamityMod.CalPlayer;
using CalamityMod.World;
// If you don't know what to change this to, don't mess with this code.
// You will fail
namespace CalValEX.Projectiles.Pets
{
    public class GoozmaPet : ModProjectile
    {
        private static readonly int Size = 46;

        
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Goozma");
            ProjectileID.Sets.NeedsUUID[projectile.type] = true;
        }

        public override void SetDefaults()
        {
            projectile.width = 46;
            projectile.height = 44;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.netImportant = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 30000000;
            projectile.tileCollide = false;
        }

        public List<int> GoozmaSlimeGods = new List<int>();

        public override void AI()
        {
            

            // Custom AI here
            Player player = Main.player[projectile.owner];
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
            CalamityPlayer calPlayer = player.GetModPlayer<CalamityPlayer>();
            if (player.dead)
            {
                modPlayer.goozmaPet = false;
            }
            if (modPlayer.goozmaPet)
            {
                projectile.timeLeft = 2;
            }

            Vector2 PlayerCenter = player.Center;
            float MinVel = 0.36f;
            Vector2 ProjDistance = PlayerCenter - projectile.Center;
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
                if (Math.Abs(PlayerCenter.X - projectile.Center.X) > 10f)
                {
                    projectile.velocity.X = projectile.velocity.X + MinVel * (float)Math.Sign(PlayerCenter.X - projectile.Center.X);
                }
                if (Math.Abs(PlayerCenter.Y - projectile.Center.Y) > 5f)
                {
                    projectile.velocity.Y = projectile.velocity.Y + MinVel * (float)Math.Sign(PlayerCenter.Y - projectile.Center.Y);
                }
            }
            else if (projectile.velocity.Length() > 1.6f)
            {
                projectile.velocity *= 0.96f;
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


            if (projectile.velocity.Length() > MaxVel)
            {
                projectile.velocity = Vector2.Normalize(projectile.velocity) * MaxVel;
            }
            if (ProjDistance.Length() > 2000f)
            {
                projectile.Center = PlayerCenter;
            }
            if (Math.Abs(projectile.velocity.Y) < 1f)
            {
                projectile.velocity.Y = projectile.velocity.Y - 0.1f;
            }

            projectile.rotation += MathHelper.ToRadians(3.6f);


            //Deity Logic
            /*
         * FRAME KEY:
         * 0 = main
         * 1 = corrupt
         * 2 = crimson
         * 3 = hallow
         * 4 = astral
         * 5 = surface
         * 6 = brimstone
         * 7 = underground
         * 8 = ocean
         * 9 = abyss
         * 10 = jungle post golem
         * 11 = ???
         * 12 = space
         * 13 = dungeon
         * 14 = sunken sea
         * 15 = jungle pre golem
         * 16 = sulphur sea
         * 17 = acid rain
         * 18 = desert
         * 19 = boss rush
         */
            if (CalamityMod.Events.BossRushEvent.BossRushActive)
            {
                GoozmaSlimeGods = new List<int>
                {
                    19,19,19,19,
                };
            }
            else
            {
                if (player.ZoneCorrupt)
                {
                    AddDeity(1);
                }
                else if (player.ZoneCrimson)
                {
                    AddDeity(2);
                }
                else if (player.ZoneHoly)
                {
                    AddDeity(3);
                }
                else if (calPlayer.ZoneAstral)
                {
                    AddDeity(4);
                }
                else if (calPlayer.ZoneCalamity)
                {
                    AddDeity(6);
                }
                else if (player.ZoneDesert)
                {
                    AddDeity(18);
                }
                else if (player.ZoneSkyHeight)
                {
                    AddDeity(12);
                }
                else if (player.ZoneUnderworldHeight)
                {
                    AddDeity(9);
                }
                else if (calPlayer.ZoneAbyss)
                {
                    AddDeity(11);
                }
                else if (player.ZoneJungle)
                {
                    if (NPC.downedGolemBoss)
                    {
                        AddDeity(Main.rand.NextBool() ? 10 : 15);
                    }
                    else
                    {
                        AddDeity(15);
                    }
                }
                else if (player.ZoneDungeon)
                {
                    AddDeity(13);
                }
                else if (calPlayer.ZoneSulphur)
                {

                    if (CalamityMod.World.CalamityWorld.rainingAcid)
                    {
                        AddDeity(16);
                    }
                    else
                    {
                        AddDeity(17);
                    }

                }
                else if (player.ZoneBeach)
                {
                    AddDeity(8);
                }
                else if (player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight)
                {
                    AddDeity(7);
                }
                else
                {
                    AddDeity(5);
                }
            }
            
            






        }

        

        public Rectangle getFrameFromTexture(int frame)
        {
            //Texture2D texture = Main.projectileTexture[projectile.type];

            return new Rectangle(0, 44 * frame, 46, 44);


        }

        public Vector2 getOriginFromFrame(int frame)
        {
            //Texture2D texture = Main.projectileTexture[projectile.type];

            return new Vector2(23, (44 * frame)+22);


        }

        public void AddDeity(int which)
        {
            if (!GoozmaSlimeGods.Contains(which))
            {
                GoozmaSlimeGods.Add(which);

                if (GoozmaSlimeGods.Count > 4)
                {
                    GoozmaSlimeGods.RemoveAt(0);
                }
            }
        }

       

        




        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D projTexture = Main.projectileTexture[projectile.type];

            float textureRotation = MathHelper.Lerp((float)Math.PI / -4f, (float)Math.PI / 4f, 0.5f + MathHelper.Clamp(projectile.velocity.X / 22f, -0.5f, 0.5f));

            Vector2 center = projectile.Center - Main.screenPosition + new Vector2(0, projectile.gfxOffY);

            spriteBatch.Draw(projTexture, center, getFrameFromTexture(0), lightColor, textureRotation, getOriginFromFrame(0), projectile.scale, SpriteEffects.None, 0);

            for (int i = 0; i < GoozmaSlimeGods.Count; ++i)
            {

                Vector2 offset = new Vector2(60, 0).RotatedBy((MathHelper.PiOver2 * i) + projectile.rotation);

                spriteBatch.Draw(projTexture, center+offset, getFrameFromTexture(GoozmaSlimeGods[i]), lightColor, textureRotation, new Vector2(23, 22), projectile.scale, SpriteEffects.None, 0);//+(GoozmaSlimeGods[i]*44)

            }

            return false;
        }
    }
}
