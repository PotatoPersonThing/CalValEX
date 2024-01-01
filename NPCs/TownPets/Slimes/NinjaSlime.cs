using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace CalValEX.NPCs.TownPets.Slimes
{
    // HIIIII if you're looking for ways to make ur own town pet, just know it's kinda complicated, if you have any doubts about this code or town pet code in general,
    // send a message to Reika#0876 on discord, I'll help as much as I can until tmod gets some documentation or something going, good luck!
    [AutoloadHead]
    public class NinjaSlime : ModNPC {
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

            NPCID.Sets.NPCBestiaryDrawModifiers value = new(0) { Hide = true };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, value);
        }

        public override void SetDefaults() {
            NPC.CloneDefaults(NPCID.TownSlimeBlue);

            AIType = NPCID.TownSlimeBlue;
            AnimationType = NPCID.TownSlimeBlue;
            NPC.lifeMax = 1000;
        }

        public override string GetChat() {
            Main.player[Main.myPlayer].currentShoppingSettings.HappinessReport = "";
            WeightedRandom<string> chat = new();
            chat.Add(Language.GetTextValue("Gooyah!"));
            chat.Add(Language.GetTextValue("Splitch splotch!"));
            chat.Add(Language.GetTextValue("Herb."), 0.05f);
            chat.Add(Language.GetTextValue("Squaaargh!"));
            chat.Add(Language.GetTextValue("*drowning noises*"), 0.01f);
            return chat;
        }
        public static List<string> PossibleNames = new()
        {
            "Slipstream Sam", "Sasuke", "Sine", "Sekiro", "Sakura", "Slash", "Shadow", "Shade", "Shatter", "Strike"
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
        }

        public override bool CanTownNPCSpawn(int numTownNPCs)/* tModPorter Suggestion: Copy the implementation of NPC.SpawnAllowed_Merchant in vanilla if you to count money, and be sure to set a flag when unlocked, so you don't count every tick. */ {
            return CalValEXWorld.ninja;
        }

        public override void AI() {
            Player player = Main.player[Main.myPlayer];
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
                Vector2 offset = playerPositionWhenPetting2 - player.Bottom;
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
            }

            NPC.position.X = MathHelper.Clamp(NPC.position.X, 150f, Main.maxTilesX * 16f - 150f);
            NPC.position.Y = MathHelper.Clamp(NPC.position.Y, 150f, Main.maxTilesY * 16f - 150f);
            if (!CalValEXWorld.ninja)
            {
                CalValEXWorld.ninja = true;
            }
        }
    }
}