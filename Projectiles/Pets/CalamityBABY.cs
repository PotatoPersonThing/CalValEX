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
    public class CalamityBABY : ModFlyingPet
    {
        public new class States
        {
            public const int Transition = -1;
            public const int Flying = 0;
            public const int LayingDown = 1;
        }

        public override float TeleportThreshold => 1840f;

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            DisplayName.SetDefault("Calamity BABY");
            Main.projFrames[projectile.type] = 15;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            projectile.width = 76;
            projectile.height = 76;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            drawOffsetX = 2;
        }

        public override void SendExtraAI(BinaryWriter writer)
        {
            writer.Write(MyDudeJustGotHitLikeTheIdiotItIs);
            base.SendExtraAI(writer);
        }

        public override void ReceiveExtraAI(BinaryReader reader)
        {
            MyDudeJustGotHitLikeTheIdiotItIs = reader.ReadBoolean();
            base.ReceiveExtraAI(reader);
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

            if (!MyDudeJustGotHitLikeTheIdiotItIs && !nameList.Contains(Main.player[projectile.owner].name))
            {
                if (Main.player[projectile.owner].GetModPlayer<CalValEXPlayer>().CalamityBabyGotHit)
                {
                    MyDudeJustGotHitLikeTheIdiotItIs = true;
                    state = States.Transition;
                    projectile.ai[0] = 0;
                    projectile.ai[1] = 0;
                    projectile.localAI[0] = 0;
                    projectile.frameCounter = 0;
                    projectile.frame = 12;
                    projectile.netUpdate = true;
                }
            }
            return true;
        }

        private float[] myRotation = new float[2];
        private float scale = 0.25f;

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            if (state == States.Transition)
            {
                Texture2D auraTexture_1 = ModContent.GetTexture("CalValEX/Projectiles/Pets/CalamityBABY_Aura_1");
                Rectangle sourceRectangle_1 = new Rectangle(0, 0, auraTexture_1.Width, auraTexture_1.Height);
                Vector2 origin_1 = new Vector2(auraTexture_1.Width, auraTexture_1.Height);
                spriteBatch.Draw(auraTexture_1, projectile.Center - Main.screenPosition, sourceRectangle_1, Color.White, myRotation[0], origin_1 / 2f, scale, SpriteEffects.None, 0);
                Texture2D auraTexture_2 = ModContent.GetTexture("CalValEX/Projectiles/Pets/CalamityBABY_Aura_2");
                Rectangle sourceRectangle_2 = new Rectangle(0, 0, auraTexture_2.Width, auraTexture_2.Height);
                Vector2 origin_2 = new Vector2(auraTexture_2.Width, auraTexture_2.Height);
                spriteBatch.Draw(auraTexture_2, projectile.Center - Main.screenPosition, sourceRectangle_2, Color.White, myRotation[1], origin_2 / 2f, scale * 0.75f, SpriteEffects.None, 0);
            }
            return base.PreDraw(spriteBatch, lightColor);
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.CalamityBABYBool = false;

            if (modPlayer.CalamityBABYBool)
                projectile.timeLeft = 2;
        }

        public override void Animation(int state) //I am too lazy to put the animation code in here.
        {
        }

        //this is a bad example of having all the custom code here instead of putting the animation in the right method
        //Animation() gets called before this, so it can matter
        //vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv//
        public override void CustomBehaviour(Player player, ref int state, float flyingSpeed, float flyingInertia)
        {
            Vector2 vectorToOwner = player.Center - projectile.Center;
            float distanceToOwner = vectorToOwner.Length();

            myRotation[0] = MathHelper.WrapAngle(myRotation[0] + (0.025f * (projectile.ai[0] / 180f)));
            myRotation[1] = MathHelper.WrapAngle(myRotation[1] - (0.025f * (projectile.ai[0] / 180f)));

            switch (state)
            {
                case States.Transition: //TRANSITION
                    projectile.tileCollide = false;
                    projectile.rotation = 0;
                    if (scale < 2f)
                        scale += 0.002f;

                    projectile.velocity *= 0.93f;

                    if (projectile.frameCounter++ > 5)
                    {
                        projectile.frameCounter = 0;
                        projectile.frame++;
                        if (projectile.frame < 13 || projectile.frame > 14)
                            projectile.frame = 13;
                    }

                    projectile.ai[0]++;
                    int timeBetweenTexts = 120;

                    if (projectile.ai[0] == timeBetweenTexts)
                    {
                        EdgyTalk("Congratulations, I see you are unworthy...", Color.White, true);
                    }
                    if (projectile.ai[0] == timeBetweenTexts * 2)
                    {
                        EdgyTalk("If you only summoned Astrageldon I could spare you, but well", Color.White, true);
                    }
                    if (projectile.ai[0] == timeBetweenTexts * 3)
                    {
                        EdgyTalk("GL surviving my power", Color.White, true);
                    }
                    if (projectile.ai[0] == timeBetweenTexts * 4)
                    {
                        EdgyTalk("Next time call my friend if you want me to be your pet... or don't get hit.", Color.White, true);
                    }
                    if (projectile.ai[0] == timeBetweenTexts * 5)
                    {
                        Mod calamityMod = ModLoader.GetMod("CalamityMod");
                        for (int i = 0; i < bossList.Count; i++)
                        {
                            NPC.NewNPC((int)projectile.position.X, (int)projectile.position.Y, calamityMod.NPCType(bossList[i]));
                        }
                    }
                    if (projectile.ai[0] == (timeBetweenTexts * 5) + 30)
                    {
                        projectile.ai[0] = 0;
                        state = States.Flying;

                        for (int i = 0; i < Main.maxPlayers; i++)
                        {
                            Player myPlayer = Main.player[i];
                            if (myPlayer.active)
                            {
                                myPlayer.GetModPlayer<CalValEXPlayer>().CalamityBabyGotHit = false;
                            }
                        }
                        MyDudeJustGotHitLikeTheIdiotItIs = false;
                        projectile.netUpdate = true;
                    }
                    break;

                case States.Flying:
                    projectile.tileCollide = false;
                    projectile.rotation = projectile.velocity.X * 0.025f;
                    scale = 0.25f;
                    Vector2 offset = FlyingOffset;
                    vectorToOwner += offset;
                    distanceToOwner = vectorToOwner.Length();
                    if (Math.Abs(player.velocity.X) < 0.05 && Math.Abs(player.velocity.Y) < 0.05)
                    {
                        if (++projectile.ai[0] >= 210 && distanceToOwner < 50f)
                        {
                            state = States.LayingDown;
                            projectile.ai[0] = 0;
                        }
                    }
                    else
                        projectile.ai[0] = 0;

                    if (projectile.frameCounter++ > 15)
                    {
                        projectile.frameCounter = 0;
                        projectile.frame++;
                        if (projectile.frame > 3)
                            projectile.frame = 0;
                    }
                    break;

                case States.LayingDown:
                    projectile.tileCollide = true;
                    projectile.velocity *= 0.98f;
                    projectile.velocity.Y += 0.1f;
                    projectile.rotation = 0;
                    scale = 0.25f;

                    if (distanceToOwner > 320f)
                    {
                        if (++projectile.ai[0] >= (420 * (1 - (distanceToOwner / 640f))))
                        {
                            state = States.Flying;
                            projectile.ai[0] = 0;
                        }
                    }
                    else
                        projectile.ai[0] = 0;

                    if (projectile.frameCounter++ > 15)
                    {
                        projectile.frameCounter = 0;
                        projectile.frame++;
                        if (projectile.frame < 4 || projectile.frame > 11)
                            projectile.frame = 4;
                    }
                    break;
            }
        }

        private void EdgyTalk(string text, Color color, bool combatText = false)
        {
            if (combatText)
            {
                CombatText.NewText(projectile.getRect(), color, text, true);
            }
            else
            {
                if (Main.netMode == NetmodeID.SinglePlayer)
                {
                    Main.NewText(text, color);
                }
                else if (Main.netMode == NetmodeID.Server)
                {
                    NetMessage.BroadcastChatMessage(NetworkText.FromKey(text), color);
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