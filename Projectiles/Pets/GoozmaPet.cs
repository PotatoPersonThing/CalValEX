//using CalamityMod.CalPlayer;
using Terraria.GameContent;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

// If you don't know what to change this to, don't mess with this code.
// You will fail
namespace CalValEX.Projectiles.Pets
{
    public class GoozmaPet : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Goozma");
            ProjectileID.Sets.NeedsUUID[Projectile.type] = true;
            Main.projPet[Projectile.type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.width = 66;
            Projectile.height = 66;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            Projectile.netImportant = true;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 30000000;
            Projectile.tileCollide = false;
        }

        public List<int> GoozmaSlimeGods = new List<int>();

        public override void AI()
        {
            // Custom AI here
            Player player = Main.player[Projectile.owner];
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
            //((CalamityPlayer calPlayer = player.GetModPlayer<CalamityPlayer>();
            if (player.dead)
            {
                modPlayer.goozmaPet = false;
            }
            if (modPlayer.goozmaPet)
            {
                Projectile.timeLeft = 2;
            }

            Vector2 PlayerCenter = player.Center;
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
            else if (Projectile.velocity.Length() > 1.6f)
            {
                Projectile.velocity *= 0.96f;
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

            Projectile.rotation += MathHelper.ToRadians(3.6f);

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
         * 20 = snow
         * 21 = abyss layer 1
         * :22: = abyss layer 3
         * 23 = pillars
         * 24 = ug snow/cryonic
         * 25 = frost moon
         * 26 = pumpkin moon
         * 27 = blood moon
         * 28 = eclipse
         * 29 = astral blight
         * 30 = arsenal
         */
            /*if (CalamityMod.Events.BossRushEvent.BossRushActive) //Auric
            {
                GoozmaSlimeGods = new List<int>
                {
                    19,19,19,19,
                };
            }
            else if (Main.eclipse) //Darksun
            {
                GoozmaSlimeGods = new List<int>
                {
                    28,28,28,28,
                };
            }
            else if (Main.snowMoon) //Endothermic
            {
                GoozmaSlimeGods = new List<int>
                {
                    25,25,25,25,
                };
            }
            else if (Main.pumpkinMoon) //Nightmare
            {
                GoozmaSlimeGods = new List<int>
                {
                    26,26,26,26,
                };
            }
            else if (Main.bloodMoon) //Bloodstone
            {
                GoozmaSlimeGods = new List<int>
                {
                    27,27,27,27,
                };
            }
            else
            {
                if (player.ZoneTowerVortex || player.ZoneTowerSolar || player.ZoneTowerStardust || player.ZoneTowerNebula)
                {
                    AddDeity(23);
                }
                else if (modPlayer.ZoneLab) //Astral Blight
                {
                    AddDeity(30);
                }
                else if (player.ZoneCorrupt) //Ebonian
                {
                    AddDeity(1);
                }
                else if (player.ZoneCrimson) //Crimulan
                {
                    AddDeity(2);
                }
                else if (player.ZoneHoly) //Crystalline
                {
                    AddDeity(3);
                }
                else if (modPlayer.ZoneAstral) //Astral Blight
                {
                    AddDeity(29);
                }
                else if (calPlayer.ZoneAstral) //I wonder what this could be
                {
                    AddDeity(4);
                }
                else if (calPlayer.ZoneCalamity) //Charred
                {
                    AddDeity(6);
                }
                else if (player.ZoneDesert) //Victide
                {
                    AddDeity(18);
                }
                else if (player.ZoneSkyHeight) //Exodium
                {
                    AddDeity(12);
                }
                else if (player.ZoneUnderworldHeight) //Chaotic
                {
                    AddDeity(9);
                }
                else if (calPlayer.ZoneAbyssLayer1 || calPlayer.ZoneAbyssLayer2) //Scoria
                {
                    AddDeity(21);
                }
                else if (calPlayer.ZoneAbyssLayer3) //Mirage
                {
                    AddDeity(11);
                }
                else if (calPlayer.ZoneAbyssLayer4) //Lumenyl
                {
                    AddDeity(22);
                }
                else if (calPlayer.ZoneSunkenSea) //Prism
                {
                    AddDeity(14);
                }
                else if (player.ZoneJungle && player.ZoneRockLayerHeight) //Plague
                {
                    AddDeity(10);
                }
                else if (player.ZoneJungle && player.ZoneDirtLayerHeight) //Plague alt
                {
                    AddDeity(10);
                }
                else if (player.ZoneJungle && !player.ZoneDirtLayerHeight && !player.ZoneRockLayerHeight) //Uelibloom
                {
                    AddDeity(15);
                }
                else if (player.ZoneDungeon) //Phantoplasm
                {
                    AddDeity(13);
                }
                else if (player.ZoneSnow && player.ZoneRockLayerHeight) //Cryogenic
                {
                    AddDeity(24);
                }
                else if (player.ZoneSnow && player.ZoneDirtLayerHeight) //Cryogenic alt
                {
                    AddDeity(24);
                }
                else if (player.ZoneSnow && !player.ZoneDirtLayerHeight && !player.ZoneRockLayerHeight) //Cryonic
                {
                    AddDeity(20);
                }
                else if (calPlayer.ZoneSulphur)
                {
                    if (CalamityMod.World.CalamityWorld.rainingAcid) //Gamma
                    {
                        AddDeity(16);
                    }
                    else //Irradiated
                    {
                        AddDeity(17);
                    }
                }
                else if (player.ZoneBeach) //Box Jelly
                {
                    AddDeity(8);
                }
                else if (player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight) //Perennial
                {
                    AddDeity(7);
                }
                else //Wulfrum
                {
                    AddDeity(5);
                }
            }*/
        }

        public Rectangle getFrameFromTexture(int frame)
        {
            //Texture2D texture = Main.ProjectileTexture[Projectile.type];

            return new Rectangle(0, 66 * frame, 66, 66);
        }

        public Vector2 getOriginFromFrame(int frame)
        {
            //Texture2D texture = Main.ProjectileTexture[Projectile.type];

            return new Vector2(33, (66 * frame) + 33);
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

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D projTexture = TextureAssets.Projectile[Projectile.type].Value;

            float textureRotation = MathHelper.Lerp((float)Math.PI / -4f, (float)Math.PI / 4f, 0.5f + MathHelper.Clamp(Projectile.velocity.X / 33f, -0.5f, 0.5f));

            Vector2 center = Projectile.Center - Main.screenPosition + new Vector2(0, Projectile.gfxOffY);

            Main.EntitySpriteDraw(projTexture, center, getFrameFromTexture(0), lightColor, textureRotation, getOriginFromFrame(0), Projectile.scale, SpriteEffects.None, 0);

            for (int i = 0; i < GoozmaSlimeGods.Count; ++i)
            {
                Vector2 offset = new Vector2(60, 0).RotatedBy((MathHelper.PiOver2 * i) + Projectile.rotation);

                Main.EntitySpriteDraw(projTexture, center + offset, getFrameFromTexture(GoozmaSlimeGods[i]), lightColor, textureRotation, new Vector2(33, 33), Projectile.scale, SpriteEffects.None, 0);//+(GoozmaSlimeGods[i]*44)
            }

            return false;
        }
    }
}