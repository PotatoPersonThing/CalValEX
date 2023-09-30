using CalValEX.Items.Pets.TownPets;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace CalValEX.NPCs.TownPets.Slimes {
    // HIIIII if you're looking for ways to make ur own town pet, just know it's kinda complicated, if you have any doubts about this code or town pet code in general,
    // send a message to Reika#0876 on discord, I'll help as much as I can until tmod gets some documentation or something going, good luck!
    [AutoloadHead]
    public class Tarr : ModNPC {
        public static double spawnTime = double.MaxValue;
        public override void SetStaticDefaults() {
            Main.npcFrameCount[Type] = 14;
            NPCID.Sets.ExtraFramesCount[Type] = 0;
            NPCID.Sets.AttackFrameCount[Type] = 0;
            NPCID.Sets.ExtraTextureCount[Type] = 0;
            NPCID.Sets.HatOffsetY[Type] = NPCID.Sets.HatOffsetY[NPCID.TownSlimeBlue];
            NPCID.Sets.NPCFramingGroup[Type] = NPCID.Sets.NPCFramingGroup[NPCID.TownSlimeBlue];
            NPCID.Sets.IsTownPet[Type] = true;
            NPCID.Sets.IsTownSlime[Type] = true;

            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0) { Hide = true };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, value);
        }

        public override void SetDefaults() {
            NPC.CloneDefaults(NPCID.TownSlimeBlue);

            AIType = NPCID.TownSlimeBlue;
            AnimationType = NPCID.TownSlimeBlue;
            NPC.lifeMax = 10000;
            NPC.height = 36;
            NPC.width = 50;
        }

        public override string GetChat() {
            Main.player[Main.myPlayer].currentShoppingSettings.HappinessReport = "";
            WeightedRandom<string> chat = new();
            chat.Add(Language.GetTextValue("Grah!"));
            chat.Add(Language.GetTextValue("Grooz..."));
            chat.Add(Language.GetTextValue("It's ya boy Goozma"), 0.05f);
            chat.Add(Language.GetTextValue("Gronch"));
            return chat;
        }
        public static List<string> PossibleNames = new List<string>()
        {
            "Sugma", "Sludgetar", "Sooty", "Slabbish", "Slickster", "Swirls", "Sable", "Stickytoil", "Smoltar", "Slithergrime"
        };
        public override List<string> SetNPCNameList() => PossibleNames;

        /*public int Frame(int firstFrame, int lastFrame, int speed) {
            frameCounter++;
            if (frameCounter > speed) {
                frameCounter = 0;
                frame++;
                if (frame > lastFrame)
                    frame = firstFrame;
            }

            return frame;
        }*/
        public override void SetChatButtons(ref string button, ref string button2)
        {
            //button = "";
        }

        public override void OnChatButtonClicked(bool firstButton, ref string shopName)
        {
            Main.LocalPlayer.isPettingAnimal = true;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs)/* tModPorter Suggestion: Copy the implementation of NPC.SpawnAllowed_Merchant in vanilla if you to count money, and be sure to set a flag when unlocked, so you don't count every tick. */ {
            return CalValEXWorld.tar;
        }

        public override void AI() {
            Player player = Main.player[Main.myPlayer];
            /*
            if (player.talkNPC > -1 && Main.npc[player.talkNPC].type == Type)
            {
                int targetDirection = (NPC.Center.X > player.Center.X) ? 1 : (-1);
                Vector2 playerPositionWhenPetting2 = (NPC.Bottom + new Vector2((float)(-targetDirection * 30), 0f)).Floor();
                if (player.talkNPC == -1)
                {
                    return;
                }
                int num = System.Math.Sign(NPC.Center.X - player.Center.X);
                if (player.controlLeft || player.controlRight || player.controlUp || player.controlDown || player.controlJump || player.pulley || player.mount.Active || num != player.direction)
                {
                    return;
                }
                /*if (player.Bottom.Distance(playerPositionWhenPetting2) > 31f)
                {
                    return;
                }*/
                /*Vector2 offset = playerPositionWhenPetting2 - player.Bottom;
                bool flag = player.CanSnapToPosition(offset);
                if (flag && !WorldGen.SolidTileAllowBottomSlope((int)playerPositionWhenPetting2.X / 16, (int)playerPositionWhenPetting2.Y / 16))
                {
                    flag = false;
                }
                if (!flag)
                {
                    return;
                }
                player.StopVanityActions();
                player.RemoveAllGrapplingHooks();
                if (player.mount.Active)
                {
                    player.mount.Dismount(player);
                }
                player.Bottom = playerPositionWhenPetting2;
                player.ChangeDir(targetDirection);
                player.velocity = Vector2.Zero;
                player.gravDir = 1f;
                if (player.whoAmI == Main.myPlayer)
                {
                    Terraria.GameContent.Achievements.AchievementsHelper.HandleSpecialEvent(player, 21);
                }
                int num17 = player.miscCounter % 14 / 7;
                Player.CompositeArmStretchAmount stretch11 = Player.CompositeArmStretchAmount.ThreeQuarters;
                if (num17 == 1)
                {
                    stretch11 = Player.CompositeArmStretchAmount.Full;
                }
                float num16 = 0.1f;
                if (player.isTheAnimalBeingPetSmall)
                {
                    num16 = 0.1f;
                }
                player.SetCompositeArmBack(enabled: true, stretch11, MathHelper.Pi * -2f * num16 * (float)player.direction);
            }*/

            NPC.position.X = MathHelper.Clamp(NPC.position.X, 150f, Main.maxTilesX * 16f - 150f);
            NPC.position.Y = MathHelper.Clamp(NPC.position.Y, 150f, Main.maxTilesY * 16f - 150f);
            if (!CalValEXWorld.tar)
            {
                CalValEXWorld.tar = true;
            }
        }

        // all from the REAL Goozma
        public static Vector3[] Oil = new Vector3[] //regular
        {
            new Color(0, 0, 0).ToVector3(),
            new Color(51, 46, 78).ToVector3(),
            new Color(113, 53, 146).ToVector3(),
            new Color(174, 23, 189).ToVector3(),
            new Color(237, 128, 60).ToVector3(),
            new Color(247, 255, 101).ToVector3(),
            new Color(176, 234, 85).ToVector3(),
            new Color(102, 219, 249).ToVector3(),
            new Color(0, 0, 0).ToVector3()
        };
        public static float Modulo(float dividend, float divisor) => dividend - (float)Math.Floor(dividend / divisor) * divisor;
        public static void GetGradientMapValues(out float[] brightnesses, out Vector3[] colors) => GetGradientMapValues(Oil, out brightnesses, out colors);

        public static void GetGradientMapValues(Vector3[] gradient, out float[] brightnesses, out Vector3[] colors)
        {
            float maxBright = 0.667f;
            brightnesses = new float[10];
            colors = new Vector3[10];

            float rainbowStartOffset = 0.35f + Main.GlobalTimeWrappedHourly * 0.5f % (maxBright * 2f);
            //Calculate and store every non-modulo brightness, with the shifting offset. 
            //The first brightness is ignored for the moment, it will be relevant later. Setting it to -1 temporarily
            brightnesses[0] = -1;
            brightnesses[1] = rainbowStartOffset + 0.35f;
            brightnesses[2] = rainbowStartOffset + 0.42f;
            brightnesses[3] = rainbowStartOffset + 0.47f;
            brightnesses[4] = rainbowStartOffset + 0.51f;
            brightnesses[5] = rainbowStartOffset + 0.56f;
            brightnesses[6] = rainbowStartOffset + 0.61f;
            brightnesses[7] = rainbowStartOffset + 0.64f;
            brightnesses[8] = rainbowStartOffset + 0.72f;
            brightnesses[9] = rainbowStartOffset + 0.75f;

            //Pass the entire rainbow through modulo 1
            for (int i = 1; i < 10; i++)
                brightnesses[i] = Modulo(brightnesses[i], maxBright) * maxBright;

            //Store the first element's value so we can find it again later
            float firstBrightnessValue = brightnesses[1];

            //Sort the values from lowest to highest
            Array.Sort(brightnesses);

            //Find the new index of the original first element after the list being sorted
            int rainbowStartIndex = Array.IndexOf(brightnesses, firstBrightnessValue);
            //Substract 1 from the index, because we are ignoring the currently negative first array slot.
            rainbowStartIndex--;

            //9 loop, filling a list of colors in a array of 10 elements (ignoring the first one)
            for (int i = 0; i < 9; i++)
            {
                colors[1 + (rainbowStartIndex + i) % 9] = gradient[i];
            }

            //We always want a brightness at index 0 to be the lower bound
            brightnesses[0] = 0;
            //Make the color at index 0 be a mix between the first and last colors in the list, based on the distance between the 2.
            float interpolant = (1 - brightnesses[9]) / (brightnesses[1] + (1 - brightnesses[9]));
            colors[0] = Vector3.Lerp(colors[9], colors[0], interpolant);
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            GetGradientMapValues(out float[] brightnesses, out Vector3[] colors);
            SpriteEffects fx = NPC.spriteDirection == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
            Effect effect = ModContent.Request<Effect>("CalValEX/Effects/HolographEffect", AssetRequestMode.ImmediateLoad).Value;
            effect.Parameters["uTime"].SetValue(Main.GlobalTimeWrappedHourly % 1f);
            effect.Parameters["colors"].SetValue(colors);
            effect.Parameters["brightnesses"].SetValue(brightnesses);
            effect.Parameters["baseToScreenPercent"].SetValue(1.05f);
            effect.Parameters["baseToMapPercent"].SetValue(-0.05f); spriteBatch.End();
            SpriteSortMode sortMode = SpriteSortMode.Deferred;
            spriteBatch.Begin(sortMode, BlendState.AlphaBlend, Main.DefaultSamplerState, DepthStencilState.None, Main.Rasterizer, effect, Main.Transform);
            spriteBatch.Draw(TextureAssets.Npc[Type].Value, NPC.Center - screenPos, NPC.frame, drawColor * 0.2f, NPC.rotation, NPC.frame.Size() * 0.5f, NPC.scale, fx, 0);
            spriteBatch.End();
            spriteBatch.Begin(sortMode, BlendState.AlphaBlend, Main.DefaultSamplerState, DepthStencilState.None, Main.Rasterizer, null, Main.Transform);
            spriteBatch.Draw(ModContent.Request<Texture2D>("CalValEX/NPCs/TownPets/Slimes/TarrGlow").Value, NPC.Center - screenPos, NPC.frame, Main.DiscoColor, NPC.rotation, NPC.frame.Size() * 0.5f, NPC.scale, fx, 0);
            return false;
        }
    }
}