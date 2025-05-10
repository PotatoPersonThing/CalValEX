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
            chat.Add(Language.GetTextValue("Mods.CalValEX.NPCs.NinjaSlime.Chat1"));
            chat.Add(Language.GetTextValue("Mods.CalValEX.NPCs.NinjaSlime.Chat2"));
            chat.Add(Language.GetTextValue("Mods.CalValEX.NPCs.NinjaSlime.Chat3"), 0.05f);
            chat.Add(Language.GetTextValue("Mods.CalValEX.NPCs.NinjaSlime.Chat4"));
            chat.Add(Language.GetTextValue("Mods.CalValEX.NPCs.NinjaSlime.Chat5"), 0.01f);
            return chat;
        }
        public static List<string> PossibleNames = new()
        {
            Language.GetTextValue("Mods.CalValEX.NPCs.NinjaSlime.SlimeName1"),
            Language.GetTextValue("Mods.CalValEX.NPCs.NinjaSlime.SlimeName2"),
            Language.GetTextValue("Mods.CalValEX.NPCs.NinjaSlime.SlimeName3"),
            Language.GetTextValue("Mods.CalValEX.NPCs.NinjaSlime.SlimeName4"),
            Language.GetTextValue("Mods.CalValEX.NPCs.NinjaSlime.SlimeName5"),
            Language.GetTextValue("Mods.CalValEX.NPCs.NinjaSlime.SlimeName6"),
            Language.GetTextValue("Mods.CalValEX.NPCs.NinjaSlime.SlimeName7"),
            Language.GetTextValue("Mods.CalValEX.NPCs.NinjaSlime.SlimeName8"),
            Language.GetTextValue("Mods.CalValEX.NPCs.NinjaSlime.SlimeName9"),
            Language.GetTextValue("Mods.CalValEX.NPCs.NinjaSlime.SlimeName10")
        };
        public override List<string> SetNPCNameList() => PossibleNames;

        public override bool CanTownNPCSpawn(int numTownNPCs)/* tModPorter Suggestion: Copy the implementation of NPC.SpawnAllowed_Merchant in vanilla if you to count money, and be sure to set a flag when unlocked, so you don't count every tick. */ {
            return CalValEXWorld.ninja;
        }

        public override void AI() 
        {
            NPC.position.X = MathHelper.Clamp(NPC.position.X, 150f, Main.maxTilesX * 16f - 150f);
            NPC.position.Y = MathHelper.Clamp(NPC.position.Y, 150f, Main.maxTilesY * 16f - 150f);
            if (!CalValEXWorld.ninja)
            {
                CalValEXWorld.ninja = true;
            }
        }
    }
}