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
            Main.projFrames[Projectile.type] = 15;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            Projectile.width = 76;
            Projectile.height = 76;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            DrawOffsetX = 2;
            Projectile.GetGlobalProjectile<CalValEXGlobalProjectile>().isCalValPet = true;
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

            if (!MyDudeJustGotHitLikeTheIdiotItIs && !nameList.Contains(Main.player[Projectile.owner].name))
            {
                if (Main.player[Projectile.owner].GetModPlayer<CalValEXPlayer>().CalamityBabyGotHit)
                {
                    MyDudeJustGotHitLikeTheIdiotItIs = true;
                    state = States.Transition;
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

        public override bool PreDraw(ref Color lightColor)
        {
            if (state == States.Transition)
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
            return base.PreDraw(ref lightColor);
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.CalamityBABYBool = false;

            if (modPlayer.CalamityBABYBool)
                Projectile.timeLeft = 2;
        }

        public override void Animation(int state) //I am too lazy to put the animation code in here.
        {
        }

        //this is a bad example of having all the custom code here instead of putting the animation in the right method
        //Animation() gets called before this, so it can matter
        //vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv//
        public override void CustomBehaviour(Player player, ref int state, float flyingSpeed, float flyingInertia)
        {
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            Vector2 vectorToOwner = player.Center - Projectile.Center;
            float distanceToOwner = vectorToOwner.Length();

            myRotation[0] = MathHelper.WrapAngle(myRotation[0] + (0.025f * (Projectile.ai[0] / 180f)));
            myRotation[1] = MathHelper.WrapAngle(myRotation[1] - (0.025f * (Projectile.ai[0] / 180f)));

            switch (state)
            {
                case States.Transition: //TRANSITION
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
                        for (int i = 0; i < bossList.Count; i++)
                        {
                           //NPC.NewNPC((int)Projectile.position.X, (int)Projectile.position.Y, calamityMod.TryFind<ModNPC>(bossList[i]));
                        }
                    }
                    if (Projectile.ai[0] == (timeBetweenTexts * 5) + 30)
                    {
                        Projectile.ai[0] = 0;
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
                        Projectile.netUpdate = true;
                    }
                    break;

                case States.Flying:
                    Projectile.tileCollide = false;
                    Projectile.rotation = Projectile.velocity.X * 0.025f;
                    scale = 0.25f;
                    Vector2 offset = FlyingOffset;
                    vectorToOwner += offset;
                    distanceToOwner = vectorToOwner.Length();
                    if (Math.Abs(player.velocity.X) < 0.05 && Math.Abs(player.velocity.Y) < 0.05)
                    {
                        if (++Projectile.ai[0] >= 210 && distanceToOwner < 50f)
                        {
                            state = States.LayingDown;
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

                case States.LayingDown:
                    Projectile.tileCollide = true;
                    Projectile.velocity *= 0.98f;
                    Projectile.velocity.Y += 0.1f;
                    Projectile.rotation = 0;
                    scale = 0.25f;

                    if (distanceToOwner > 320f)
                    {
                        if (++Projectile.ai[0] >= (420 * (1 - (distanceToOwner / 640f))))
                        {
                            state = States.Flying;
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
                    Terraria.Chat.ChatHelper.BroadcastChatMessage(NetworkText.FromKey(text), color);
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