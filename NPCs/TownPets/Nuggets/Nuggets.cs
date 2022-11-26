using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace CalValEX.NPCs.TownPets.Nuggets {
    public abstract class TownNuggets : ModNPC {
        private int frame = 0;
        private int frameCounter = 0;
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
            NPCID.Sets.ExtraFramesCount[Type] = 0;
            NPCID.Sets.AttackFrameCount[Type] = 0;
            NPCID.Sets.HatOffsetY[Type] = NPCID.Sets.HatOffsetY[NPCID.TownDog];
            NPCID.Sets.NPCFramingGroup[Type] = NPCID.Sets.NPCFramingGroup[NPCID.TownDog];
            NPCID.Sets.ExtraTextureCount[Type] = 0;
            NPCID.Sets.IsTownPet[Type] = true;

            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0) { Hide = true };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, value);
        }

        public int Frame(int firstFrame, int lastFrame, int speed) {
            frameCounter++;
            if (frameCounter > speed) {
                frameCounter = 0;
                frame++;
                if (frame > lastFrame)
                    frame = firstFrame;
            }

            return frame;
        }

        public void DrawGlow(string nugName) {
            Texture2D glowMask = ModContent.Request<Texture2D>("CalValEX/NPCs/TownPets/Nuggets/" + nugName + "_Glow").Value;
            Main.EntitySpriteDraw(glowMask, NPC.position - Main.screenPosition - new Vector2(10 * NPC.spriteDirection, -14), NPC.frame, Color.White, NPC.rotation, 
                new Vector2(glowMask.Width / 2, glowMask.Height / 2 / 9), NPC.scale, NPC.spriteDirection == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);
        }

        public override void AI() {
            if (Main.player[Main.myPlayer].talkNPC > -1 && Main.npc[Main.player[Main.myPlayer].talkNPC].type == Type)
                Main.player[Main.myPlayer].isTheAnimalBeingPetSmall = true;
        }

        public override void FindFrame(int frameHeight) {
            NPC.spriteDirection = NPC.direction;

            switch (NPC.ai[0]) {
                case 0:
                    NPC.frame.Y = frameHeight * Frame(0, 2, 3);
                    break;

                case 1:
                    NPC.frame.Y = frameHeight * Frame(3, 8, 3);
                    break;

                default:
                    NPC.frame.Y = frameHeight * 6;
                    break;
            }
        }

        public override void SetDefaults() {
            NPC.CloneDefaults(NPCID.TownDog);
            AIType = NPCID.TownDog;
        }

        public override string GetChat() {
            Main.player[Main.myPlayer].currentShoppingSettings.HappinessReport = "";
            WeightedRandom<string> chat = new();
            chat.Add(Language.GetTextValue("Cluck!"));
            chat.Add(Language.GetTextValue("Peep peep"));
            chat.Add(Language.GetTextValue("Cluck cluck"));
            chat.Add(Language.GetTextValue("Bawk!"));
            chat.Add(Language.GetTextValue("Pock pock"));
            chat.Add(Language.GetTextValue("Cock-a-doodle-doo"));
            return chat;
        }
    }

    #region // Nugget
    [AutoloadHead]
    public class NuggetNugget : TownNuggets {
        public override List<string> SetNPCNameList() {
            return new List<string>() {
                "Melvin", // Bc big smoke
                "Mike", // The headless chicken
                "Gordy", // Rango chicken
                "Cluckin Bell",
                "McDonald",
                "Buckbeak",
                "Doodle",
                "Beaky",
                "Randy",
                "Spurs",
                "Yhary",
                "Kulu-Ya-Ku",
                "Kazooie"
            };
        }

        public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor) => DrawGlow(GetType().Name);

        public override bool CanTownNPCSpawn(int numTownNPCs, int money) {
            if (NPC.CountNPCS(ModContent.NPCType<NuggetNugget>()) < 1 && CalValEXWorld.nugget)
                return true;
            else
                return false;
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
                "Mike", // The headless chicken
                "Gordy", // Rango chicken
                "Cluckin Bell",
                "McDonald",
                "Buckbeak",
                "Doodle",
                "Beaky",
                "Randy",
                "Spurs",
                "Rocky",
                "Aknosom"
            };
        }

        public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor) => DrawGlow(GetType().Name);

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
                "Mike", // The headless chicken
                "Gordy", // Rango chicken
                "Cluckin Bell",
                "McDonald",
                "Buckbeak",
                "Doodle",
                "Beaky",
                "Randy",
                "Spurs",
                "Yatagarasu",
                "Huginn",
                "Munnin"
            };
        }
        public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor) => DrawGlow(GetType().Name);

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
                "Mike", // The headless chicken
                "Gordy", // Rango chicken
                "Cluckin Bell",
                "McDonald",
                "Buckbeak",
                "Doodle",
                "Beaky",
                "Randy",
                "Spurs",
                "Fiery",
                "Fatalis"
            };
        }

        public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor) => DrawGlow(GetType().Name);

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
                "Mike", // The headless chicken
                "Gordy", // Rango chicken
                "Cluckin Bell",
                "McDonald",
                "Buckbeak",
                "Doodle",
                "Beaky",
                "Randy",
                "Spurs",
                "Betty",
                "Ibushi"
            };
        }

        public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor) => DrawGlow(GetType().Name);

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
                "Mike", // The headless chicken
                "Gordy", // Rango chicken
                "Cluckin Bell",
                "McDonald",
                "Buckbeak",
                "Doodle",
                "Beaky",
                "Randy",
                "Spurs",
                "Darky",
                "Gore Magala",
                "JubJub"
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