using CalValEX.CalamityID;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.Player;

namespace CalValEX.NPCs.TownPets.Slimes
{
    // HIIIII if you're looking for ways to make ur own town pet, just know it's kinda complicated, if you have any doubts about this code or town pet code in general,
    // send a message to Reika#0876 on discord, I'll help as much as I can until tmod gets some documentation or something going, good luck!
    [AutoloadHead]
    public class AstroSlime : ModNPC {
        public static double spawnTime = double.MaxValue;
        public override void Load()
        {
            // Adjust the player's position to make it look like they're actually patting the wider shorter slimes
            Terraria.On_Player.ItemCheck_ApplyHoldStyle_Inner += PetSlime;
            Terraria.On_Player.PetAnimal += PetSlime2;
            Terraria.On_Player.UpdatePettingAnimal += PetSlime3;
        }

        public static void PetSlime(On_Player.orig_ItemCheck_ApplyHoldStyle_Inner orig, Player p, float mountOffset, Item sItem, Rectangle heldItemFrame)
        {
            if (p.isPettingAnimal && (p.TalkNPC?.type == ModContent.NPCType<AstroSlime>() || p.TalkNPC?.type == ModContent.NPCType<NinjaSlime>()))
            {
                int counter = p.miscCounter % 14 / 7;
                CompositeArmStretchAmount stretch = CompositeArmStretchAmount.ThreeQuarters;
                if (counter == 1)
                {
                    stretch = CompositeArmStretchAmount.Full;
                }
                p.SetCompositeArmBack(enabled: true, stretch, (float)Math.PI * -2f * 0.18f * (float)p.direction);
            }
            else
            {
                orig(p, mountOffset, sItem, heldItemFrame);
            }
        }
        public static void PetSlime2(On_Player.orig_PetAnimal orig, Player p, int npc)
        {
            if (p.TalkNPC?.type == ModContent.NPCType<AstroSlime>() || p.TalkNPC?.type == ModContent.NPCType<NinjaSlime>())
            {
                int targetDirection = (p.TalkNPC.Center.X > p.Center.X) ? 1 : (-1);
                Vector2 playerPositionWhenPetting = Main.npc[p.talkNPC].Bottom + new Vector2(-targetDirection * 30, 0f);
                playerPositionWhenPetting = playerPositionWhenPetting.Floor();
                if (p.talkNPC == -1)
                {
                    return;
                }
                int dirtoplayer = System.Math.Sign(p.TalkNPC.Center.X - p.Center.X);
                if (p.controlLeft || p.controlRight || p.controlUp || p.controlDown || p.controlJump || p.pulley || p.mount.Active || dirtoplayer != p.direction)
                {
                    return;
                }
                Vector2 offset = playerPositionWhenPetting - p.Bottom;
                bool cansnaptopos = p.CanSnapToPosition(offset);
                if (cansnaptopos && !WorldGen.SolidTileAllowBottomSlope((int)playerPositionWhenPetting.X / 16, (int)playerPositionWhenPetting.Y / 16))
                {
                    cansnaptopos = false;
                }
                if (!cansnaptopos)
                {
                    return;
                }
                if (p.isPettingAnimal && p.Bottom == playerPositionWhenPetting)
                {
                    p.isPettingAnimal = false;
                    p.isTheAnimalBeingPetSmall = false;
                    return;
                }
                p.StopVanityActions();
                p.RemoveAllGrapplingHooks();
                if (p.mount.Active)
                {
                   p.mount.Dismount(p);
                }
                p.Bottom = playerPositionWhenPetting;
                p.ChangeDir(targetDirection);
                p.isPettingAnimal = true;
                p.isTheAnimalBeingPetSmall = true;
                p.velocity = Vector2.Zero;
                p.gravDir = 1f;
                if (p.whoAmI == Main.myPlayer)
                {
                    AchievementsHelper.HandleSpecialEvent(p, 21);
                }
                return;
            }
            else
            {
                orig(p, npc);
            }
        }

        public static void PetSlime3(On_Player.orig_UpdatePettingAnimal orig, Player p)
        {
            if (p.TalkNPC?.type == ModContent.NPCType<AstroSlime>() || p.TalkNPC?.type == ModContent.NPCType<NinjaSlime>())
            {
                if (!p.isPettingAnimal)
                {
                    return;
                }
                if (p.talkNPC == -1)
                {
                    p.isPettingAnimal = false;
                    p.isTheAnimalBeingPetSmall = false;
                    return;
                }
                int playerdir = Math.Sign(Main.npc[p.talkNPC].Center.X - p.Center.X);
                int targetDirection = (p.TalkNPC.Center.X > p.Center.X) ? 1 : (-1);
                Vector2 playerPositionWhenPetting = Main.npc[p.talkNPC].Bottom + new Vector2(-targetDirection * 30, 0f);
                playerPositionWhenPetting = playerPositionWhenPetting.Floor();
                if (p.controlLeft || p.controlRight || p.controlUp || p.controlDown || p.controlJump || p.pulley || p.mount.Active || playerdir != p.direction)
                {
                    p.isPettingAnimal = false;
                    p.isTheAnimalBeingPetSmall = false;
                    return;
                }
                if (p.Bottom.Distance(playerPositionWhenPetting) > 2f)
                {
                    p.isPettingAnimal = false;
                    p.isTheAnimalBeingPetSmall = false;
                }
            }
            else
            {
                orig(p);
            }
        }

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
            chat.Add(Language.GetTextValue("Mods.CalValEX.NPCs.AstroSlime.Chat1"));
            chat.Add(Language.GetTextValue("Mods.CalValEX.NPCs.AstroSlime.Chat2"));
            chat.Add(Language.GetTextValue("Mods.CalValEX.NPCs.AstroSlime.Chat3"));
            return chat;
        }
        public static List<string> PossibleNames = new()
        {
            Language.GetTextValue("Mods.CalValEX.NPCs.AstroSlime.SlimeName1"),
            Language.GetTextValue("Mods.CalValEX.NPCs.AstroSlime.SlimeName2"),
            Language.GetTextValue("Mods.CalValEX.NPCs.AstroSlime.SlimeName3"),
            Language.GetTextValue("Mods.CalValEX.NPCs.AstroSlime.SlimeName4"),
            Language.GetTextValue("Mods.CalValEX.NPCs.AstroSlime.SlimeName5"),
            Language.GetTextValue("Mods.CalValEX.NPCs.AstroSlime.SlimeName6"),
            Language.GetTextValue("Mods.CalValEX.NPCs.AstroSlime.SlimeName7"),
            Language.GetTextValue("Mods.CalValEX.NPCs.AstroSlime.SlimeName8"),
            Language.GetTextValue("Mods.CalValEX.NPCs.AstroSlime.SlimeName9"),
            Language.GetTextValue("Mods.CalValEX.NPCs.AstroSlime.SlimeName10"),
            Language.GetTextValue("Mods.CalValEX.NPCs.AstroSlime.SlimeName11"),
            Language.GetTextValue("Mods.CalValEX.NPCs.AstroSlime.SlimeName12"),
            Language.GetTextValue("Mods.CalValEX.NPCs.AstroSlime.SlimeName13")
        };
        public override List<string> SetNPCNameList() => PossibleNames;

        public override bool CanTownNPCSpawn(int numTownNPCs)/* tModPorter Suggestion: Copy the implementation of NPC.SpawnAllowed_Merchant in vanilla if you to count money, and be sure to set a flag when unlocked, so you don't count every tick. */ {
            return CalValEXWorld.astro;
        }

        public override void AI() 
        {
            NPC.position.X = MathHelper.Clamp(NPC.position.X, 150f, Main.maxTilesX * 16f - 150f);
            NPC.position.Y = MathHelper.Clamp(NPC.position.Y, 150f, Main.maxTilesY * 16f - 150f);
            if (!CalValEXWorld.astro)
            {
                CalValEXWorld.astro = true;
            }
        }

        public override bool CanBeHitByNPC(NPC attacker)
        {
            if (CalValEX.CalamityActive)
            {
                if (attacker.type == CalNPCID.AstrumAureus || attacker.type == CalValEX.CalamityNPC("AureusSpawn"))
                {
                    return false;
                }
            }
            return true;
        }

        public override bool? CanBeHitByProjectile(Projectile projectile)
        {
            if (CalValEX.CalamityActive)
            {
                if (projectile.type == CalValEX.CalamityProjectile("AstralFlame") || projectile.type == CalValEX.CalamityProjectile("AstralLaser"))
                {
                    return false;
                }
            }
            return null;
        }
    }
}