using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;
using CalValEX;

namespace CalValEX.NPCs.TownPets.Nuggets {
    public abstract class TownNuggets : ModNPC {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault(Language.GetTextValue("Nugget"));
            DisplayName.AddTranslation((int)GameCulture.CultureName.German, "Hund");
            DisplayName.AddTranslation((int)GameCulture.CultureName.Italian, "Cane");
            DisplayName.AddTranslation((int)GameCulture.CultureName.French, "Chien");
            DisplayName.AddTranslation((int)GameCulture.CultureName.Spanish, "Perro");
            DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Собака");
            DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "狗狗");
            DisplayName.AddTranslation((int)GameCulture.CultureName.Portuguese, "Cão");
            DisplayName.AddTranslation((int)GameCulture.CultureName.Polish, "Pies");

            Main.npcFrameCount[Type] = 9;
            NPCID.Sets.ExtraFramesCount[Type] = 3;
            NPCID.Sets.AttackFrameCount[Type] = NPCID.Sets.AttackFrameCount[NPCID.TownDog];
            NPCID.Sets.HatOffsetY[Type] = NPCID.Sets.HatOffsetY[NPCID.TownDog];
            NPCID.Sets.ExtraTextureCount[Type] = NPCID.Sets.ExtraTextureCount[NPCID.TownDog];
            NPCID.Sets.NPCFramingGroup[Type] = NPCID.Sets.NPCFramingGroup[NPCID.TownDog];
            NPCID.Sets.IsTownPet[Type] = true;

            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0) { Hide = true };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, value);
        }

        public override void SetDefaults() {
            NPC.CloneDefaults(NPCID.TownDog);
            AIType = NPCID.TownDog;
            AnimationType = NPCID.TownDog;
        }

        /* dogs don't need it since they're the default
        public override void AI()
        {
            // for petting corrections, since vanilla defaults petting to Town Dog Dimensions
            // only height fix so far, messing with width triggers StopPetting() since that's also hardcoded to Dog width
            if (Main.player[Main.myPlayer].talkNPC > -1 && Main.npc[Main.player[Main.myPlayer].talkNPC].type == Type)
            {
                Main.player[Main.myPlayer].isTheAnimalBeingPetSmall = true;
            }
        }
        */

        // Woofs for the world
        public override string GetChat() {
            Main.player[Main.myPlayer].currentShoppingSettings.HappinessReport = ""; // workaround for happiness button showing up on Town Pets
            WeightedRandom<string> chat = new();
            chat.Add(Language.GetTextValue("Cluck!"));
            chat.Add(Language.GetTextValue("Peep peep"));
            chat.Add(Language.GetTextValue("Cluck cluck"));
            return chat;
        }
    }

    #region // Nugget
    [AutoloadHead]
    public class NuggetNugget : TownNuggets {
        public override List<string> SetNPCNameList() {
            return new List<string>() {
                "Melvin", // Bc big smoke
                "Cluckin Bell", // GTA SA ref!!
                "McDonald",
                "Buckbeak",
                "Mike", // The headless chicke
                "Doodle",
                "Beaky",
                "Randy",
                "Spurs",
                "Gordy" // Rango chicken
            };
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money) {
            if (NPC.CountNPCS(ModContent.NPCType<NuggetNugget>()) < 1 && CalValEXWorld.nugget) {
                return true;
            } else {
                return false;
            }
        }

        public override ITownNPCProfile TownNPCProfile() {
            return new NuggetProfile();
        }
    }

    public class NuggetProfile : ITownNPCProfile {
        public int RollVariation() => 0;
        public string GetNameForVariant(NPC npc) => npc.getNewNPCName();

        public Asset<Texture2D> GetTextureNPCShouldUse(NPC npc) {
            return ModContent.Request<Texture2D>("CalValEX/NPCs/TownPets/Nuggets/NuggetNugget");
        }

        public int GetHeadTextureIndex(NPC npc) => ModContent.GetModHeadSlot("CalValEX/NPCs/TownPets/Nuggets/NuggetNugget_Head");
    }
    #endregion

    #region // Draco
    [AutoloadHead]
    public class DracoNugget : TownNuggets {
        public override List<string> SetNPCNameList() {
            return new List<string>() {
                "Melvin", // Bc big smoke
                "Cluckin Bell", // GTA SA ref!!
                "McDonald",
                "Buckbeak",
                "Mike", // The headless chicke
                "Doodle",
                "Beaky",
                "Randy",
                "Spurs",
                "Gordy" // Rango chicken
            };
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money) {
            if (NPC.CountNPCS(ModContent.NPCType<DracoNugget>()) < 1 && CalValEXWorld.draco) {
                return true;
            } else {
                return false;
            }
        }

        public override ITownNPCProfile TownNPCProfile() {
            return new DracoProfile();
        }
    }

    public class DracoProfile : ITownNPCProfile {
        public int RollVariation() => 0;
        public string GetNameForVariant(NPC npc) => npc.getNewNPCName();

        public Asset<Texture2D> GetTextureNPCShouldUse(NPC npc) {
            return ModContent.Request<Texture2D>("CalValEX/NPCs/TownPets/Nuggets/DracoNugget");
        }

        public int GetHeadTextureIndex(NPC npc) => ModContent.GetModHeadSlot("CalValEX/NPCs/TownPets/Nuggets/DracoNugget_Head");
    }
    #endregion

    #region // Folly
    [AutoloadHead]
    public class FollyNugget : TownNuggets {
        public override List<string> SetNPCNameList() {
            return new List<string>() {
                "Melvin", // Bc big smoke
                "Cluckin Bell", // GTA SA ref!!
                "McDonald",
                "Buckbeak",
                "Mike", // The headless chicke
                "Doodle",
                "Beaky",
                "Randy",
                "Spurs",
                "Gordy" // Rango chicken
            };
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money) {
            if (NPC.CountNPCS(ModContent.NPCType<FollyNugget>()) < 1 && CalValEXWorld.folly) {
                return true;
            } else {
                return false;
            }
        }

        public override ITownNPCProfile TownNPCProfile() {
            return new FollyProfile();
        }
    }

    public class FollyProfile : ITownNPCProfile {
        public int RollVariation() => 0;
        public string GetNameForVariant(NPC npc) => npc.getNewNPCName();

        public Asset<Texture2D> GetTextureNPCShouldUse(NPC npc) {
            return ModContent.Request<Texture2D>("CalValEX/NPCs/TownPets/Nuggets/FollyNugget");
        }

        public int GetHeadTextureIndex(NPC npc) => ModContent.GetModHeadSlot("CalValEX/NPCs/TownPets/Nuggets/FollyNuggetHead");
    }
    #endregion

    #region // GOD
    [AutoloadHead]
    public class GODNugget : TownNuggets {
        public override List<string> SetNPCNameList() {
            return new List<string>() {
                "Melvin", // Bc big smoke
                "Cluckin Bell", // GTA SA ref!!
                "McDonald",
                "Buckbeak",
                "Mike", // The headless chicke
                "Doodle",
                "Beaky",
                "Randy",
                "Spurs",
                "Gordy" // Rango chicken
            };
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money) {
            if (NPC.CountNPCS(ModContent.NPCType<GODNugget>()) < 1 && CalValEXWorld.godnug) {
                return true;
            } else {
                return false;
            }
        }

        public override ITownNPCProfile TownNPCProfile() {
            return new GODProfile();
        }
    }

    public class GODProfile : ITownNPCProfile {
        public int RollVariation() => 0;
        public string GetNameForVariant(NPC npc) => npc.getNewNPCName();

        public Asset<Texture2D> GetTextureNPCShouldUse(NPC npc) {
            return ModContent.Request<Texture2D>("CalValEX/NPCs/TownPets/Nuggets/GODNugget");
        }

        public int GetHeadTextureIndex(NPC npc) => ModContent.GetModHeadSlot("CalValEX/NPCs/TownPets/Nuggets/GODNugget_Head");
    }
    #endregion

    #region // Mammoth
    [AutoloadHead]
    public class MammothNugget : TownNuggets {
        public override List<string> SetNPCNameList() {
            return new List<string>() {
                "Melvin", // Bc big smoke
                "Cluckin Bell", // GTA SA ref!!
                "McDonald",
                "Buckbeak",
                "Mike", // The headless chicke
                "Doodle",
                "Beaky",
                "Randy",
                "Spurs",
                "Gordy" // Rango chicken
            };
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money) {
            if (NPC.CountNPCS(ModContent.NPCType<MammothNugget>()) < 1 && CalValEXWorld.mammoth) {
                return true;
            } else {
                return false;
            }
        }

        public override ITownNPCProfile TownNPCProfile() {
            return new MammothProfile();
        }
    }

    public class MammothProfile : ITownNPCProfile {
        public int RollVariation() => 0;
        public string GetNameForVariant(NPC npc) => npc.getNewNPCName();

        public Asset<Texture2D> GetTextureNPCShouldUse(NPC npc) {
            return ModContent.Request<Texture2D>("CalValEX/NPCs/TownPets/Nuggets/MammothNugget");
        }

        public int GetHeadTextureIndex(NPC npc) => ModContent.GetModHeadSlot("CalValEX/NPCs/TownPets/Nuggets/MammothNugget_Head");
    }
    #endregion

    #region // Shadow
    [AutoloadHead]
    public class ShadowNugget : TownNuggets {
        public override List<string> SetNPCNameList() {
            return new List<string>() {
                "Melvin", // Bc big smoke
                "Cluckin Bell", // GTA SA ref!!
                "McDonald",
                "Buckbeak",
                "Mike", // The headless chicke
                "Doodle",
                "Beaky",
                "Randy",
                "Spurs",
                "Gordy" // Rango chicken
            };
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money) {
            if (NPC.CountNPCS(ModContent.NPCType<ShadowNugget>()) < 1 && CalValEXWorld.shadow) {
                return true;
            } else {
                return false;
            }
        }

        public override ITownNPCProfile TownNPCProfile() {
            return new ShadowProfile();
        }
    }

    public class ShadowProfile : ITownNPCProfile {
        public int RollVariation() => 0;
        public string GetNameForVariant(NPC npc) => npc.getNewNPCName();

        public Asset<Texture2D> GetTextureNPCShouldUse(NPC npc) {
            return ModContent.Request<Texture2D>("CalValEX/NPCs/TownPets/Nuggets/ShadowNugget");
        }

        public int GetHeadTextureIndex(NPC npc) => ModContent.GetModHeadSlot("CalValEX/NPCs/TownPets/Nuggets/ShadowNugget_Head");
    }
    #endregion
}