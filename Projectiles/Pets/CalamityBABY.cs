using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.Pets
{
    public class CalamityBABY : FlyingPet
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Calamity BABY");
            Main.projFrames[Projectile.type] = 15;
            Main.projPet[Projectile.type] = true;
        }

        public override void SafeSetDefaults()
        {
            Projectile.width = 76;
            Projectile.height = 76;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            DrawOffsetX = 2;
            facingLeft = true;
            spinRotation = false;
            shouldFlip = true;
        }

        public override void SafeSendExtraAI(BinaryWriter writer)
        {
            writer.Write(MyDudeJustGotHitLikeTheIdiotItIs);
        }

        public override void SafeReceiveExtraAI(BinaryReader reader)
        {
            MyDudeJustGotHitLikeTheIdiotItIs = reader.ReadBoolean();
        }

        public override void SetUpFlyingPet()
        {
            distance[0] = 1840f;
            distance[1] = 560f;
            speed = 12f;
            inertia = 60f;
            animationSpeed = -1;
            spinRotationSpeedMult = 1f;
            offSetX = 48f * -Main.player[Projectile.owner].direction;
            offSetY = -50f;
        }

        private bool firstTick = false;
        private bool MyDudeJustGotHitLikeTheIdiotItIs = false;

        public override bool PreAI()
        {
            if (!firstTick)
            {
                MyDudeJustGotHitLikeTheIdiotItIs = false;
                for (int i = 0; i < Main.maxPlayers; i++)
                {
                    Player player = Main.player[i];
                    if (player.active)
                    {
                        player.GetModPlayer<CalValEXPlayer>().CalamityBabyGotHit = false;
                    }
                }
                firstTick = true;
            }

            if (!MyDudeJustGotHitLikeTheIdiotItIs && !nameList.Contains(Main.player[Projectile.owner].name))
            {
                if (Main.player[Projectile.owner].GetModPlayer<CalValEXPlayer>().CalamityBabyGotHit)
                {
                    MyDudeJustGotHitLikeTheIdiotItIs = true;
                    Projectile.localAI[1] = -1;
                    Projectile.ai[0] = 0;
                    Projectile.ai[1] = 0;
                    Projectile.localAI[0] = 0;
                    Projectile.frameCounter = 0;
                    Projectile.frame = 12;
                    Projectile.netUpdate = true;
                }
            }
            return true;
        }

        private float[] myRotation = new float[2];
        private float scale = 0.25f;

        public override void SafePreDraw(Color lightColor)
        {
            if (Projectile.localAI[1] == -1)
            {
                Texture2D auraTexture_1 = ModContent.Request<Texture2D>("CalValEX/Projectiles/Pets/CalamityBABY_Aura_1").Value;
                Rectangle sourceRectangle_1 = new Rectangle(0, 0, auraTexture_1.Width, auraTexture_1.Height);
                Vector2 origin_1 = new Vector2(auraTexture_1.Width, auraTexture_1.Height);
                Main.EntitySpriteDraw(auraTexture_1, Projectile.Center - Main.screenPosition, sourceRectangle_1, Color.White, myRotation[0], origin_1 / 2f, scale, SpriteEffects.None, 0);
                Texture2D auraTexture_2 = ModContent.Request<Texture2D>("CalValEX/Projectiles/Pets/CalamityBABY_Aura_2").Value;
                Rectangle sourceRectangle_2 = new Rectangle(0, 0, auraTexture_2.Width, auraTexture_2.Height);
                Vector2 origin_2 = new Vector2(auraTexture_2.Width, auraTexture_2.Height);
                Main.EntitySpriteDraw(auraTexture_2, Projectile.Center - Main.screenPosition, sourceRectangle_2, Color.White, myRotation[1], origin_2 / 2f, scale * 0.75f, SpriteEffects.None, 0);
            }
        }

        public override void SafeAI(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.CalamityBABYBool = false;
            if (modPlayer.CalamityBABYBool)
                Projectile.timeLeft = 2;

            Vector2 vectorToOwner = player.Center - Projectile.Center;
            float distanceToOwner = vectorToOwner.Length();

            myRotation[0] += 0.025f;
            myRotation[1] -= 0.025f;

            switch (Projectile.localAI[1])
            {
                case -1: //TRANSITION
                    Projectile.tileCollide = false;
                    Projectile.rotation = 0;
                    if (scale < 2f)
                        scale += 0.002f;

                    Projectile.velocity *= 0.93f;

                    if (Projectile.frameCounter++ > 5)
                    {
                        Projectile.frameCounter = 0;
                        Projectile.frame++;
                        if (Projectile.frame < 13 || Projectile.frame > 14)
                            Projectile.frame = 13;
                    }

                    Projectile.ai[0]++;
                    int timeBetweenTexts = 120;

                    if (Projectile.ai[0] == timeBetweenTexts)
                    {
                        EdgyTalk("Congratulations, I see you are unworthy...", Color.White, true);
                    }
                    if (Projectile.ai[0] == timeBetweenTexts * 2)
                    {
                        EdgyTalk("If you only summoned Astrageldon I could spare you, but well", Color.White, true);
                    }
                    if (Projectile.ai[0] == timeBetweenTexts * 3)
                    {
                        EdgyTalk("GL surviving my power", Color.White, true);
                    }
                    if (Projectile.ai[0] == timeBetweenTexts * 4)
                    {
                        EdgyTalk("Next time call my friend if you want me to be your pet... or don't get hit.", Color.White, true);
                    }
                    if (Projectile.ai[0] == timeBetweenTexts * 5)
                    {
                        //Mod calamityMod = ModLoader.GetMod("CalamityMod");
                        for (int i = 0; i < bossList.Count; i++)
                        {
                            //NPC.NewNPC((int)Projectile.position.X, (int)Projectile.position.Y, calamityMod.NPCType(bossList[i]));
                        }
                    }
                    if (Projectile.ai[0] == (timeBetweenTexts * 5) + 30)
                    {
                        Projectile.ai[0] = 0;
                        Projectile.localAI[1] = 0;

                        for (int i = 0; i < Main.maxPlayers; i++)
                        {
                            Player myPlayer = Main.player[i];
                            if (myPlayer.active)
                            {
                                myPlayer.GetModPlayer<CalValEXPlayer>().CalamityBabyGotHit = false;
                            }
                        }
                        MyDudeJustGotHitLikeTheIdiotItIs = false;
                        Projectile.netUpdate = true;
                    }
                    break;

                case 0:
                    Projectile.tileCollide = false;
                    Projectile.rotation = Projectile.velocity.X * 0.025f;
                    scale = 0.25f;
                    Vector2 offset = new Vector2(offSetX, offSetY);
                    vectorToOwner += offset;
                    distanceToOwner = vectorToOwner.Length();
                    if (Math.Abs(player.velocity.X) < 0.05 && Math.Abs(player.velocity.Y) < 0.05)
                    {
                        if (++Projectile.ai[0] >= 210 && distanceToOwner < 50f)
                        {
                            Projectile.localAI[1] = 1;
                            Projectile.ai[0] = 0;
                        }
                    }
                    else
                        Projectile.ai[0] = 0;

                    if (Projectile.frameCounter++ > 15)
                    {
                        Projectile.frameCounter = 0;
                        Projectile.frame++;
                        if (Projectile.frame > 3)
                            Projectile.frame = 0;
                    }
                    break;

                case 1: //laying down
                    Projectile.tileCollide = true;
                    Projectile.velocity *= 0.98f;
                    Projectile.velocity.Y += 0.1f;
                    Projectile.rotation = 0;
                    scale = 0.25f;

                    if (distanceToOwner > 320f)
                    {
                        if (++Projectile.ai[0] >= 210)
                        {
                            Projectile.localAI[1] = 0;
                            Projectile.ai[0] = 0;
                        }
                    }
                    else
                        Projectile.ai[0] = 0;

                    if (Projectile.frameCounter++ > 15)
                    {
                        Projectile.frameCounter = 0;
                        Projectile.frame++;
                        if (Projectile.frame < 4 || Projectile.frame > 11)
                            Projectile.frame = 4;
                    }
                    break;
            }
        }

        private void EdgyTalk(string text, Color color, bool combatText = false)
        {
            if (combatText)
            {
                CombatText.NewText(Projectile.getRect(), color, text, true);
            }
            else
            {
                if (Main.netMode == NetmodeID.SinglePlayer)
                {
                    Main.NewText(text, color);
                }
                else if (Main.netMode == NetmodeID.Server)
                {
                    //NetMessage.BroadcastChatMessage(NetworkText.FromKey(text), color);
                }
            }
        }

        private List<string> bossList = new List<string>
        {
            "Yharon",
            "SupremeCalamitas",
            "DevourerofGodsHeadS",
            "Providence",
            "Polterghast",
            "BrimstoneElemental",
            "PlaguebringerGoliath",
            "AstralSlime"
        };

        public static List<string> nameList = new List<string>
        {
            "Yharex",
            "Yharex87",
            "Mochi",
            "YuH",
            "Iban",
            "Lucca",
            "Junko"
        };
    }
}