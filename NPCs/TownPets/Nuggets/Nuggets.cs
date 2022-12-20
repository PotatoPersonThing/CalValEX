using CalValEX.Items.Pets.TownPets;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace CalValEX.NPCs.TownPets.Nuggets {
    // HIIIII if you're looking for ways to make ur own town pet, just know it's kinda complicated, if you have any doubts about this code or town pet code in general,
    // send a message to Drædon Gaming#1669 on discord, I'll help as much as I can until tmod gets some documentation or something going, good luck!

    #region //Base NPC
    public abstract class TownNuggets : ModNPC {
        private int frame = 0;
        private int frameCounter = 0;
        public static double spawnTime = double.MaxValue;
        public override void SetStaticDefaults() {
            DisplayName.SetDefault(Language.GetTextValue("Nugget"));

            Main.npcFrameCount[Type] = 9;
            NPCID.Sets.ExtraFramesCount[Type] = 0;
            NPCID.Sets.AttackFrameCount[Type] = 0;
            NPCID.Sets.ExtraTextureCount[Type] = 0;
            NPCID.Sets.HatOffsetY[Type] = NPCID.Sets.HatOffsetY[NPCID.TownDog];
            NPCID.Sets.NPCFramingGroup[Type] = NPCID.Sets.NPCFramingGroup[NPCID.TownDog];
            NPCID.Sets.IsTownPet[Type] = true;

            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0) { Hide = true };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, value);
        }

        public override void SetDefaults() {
            NPC.CloneDefaults(NPCID.TownDog);

            AIType = NPCID.TownDog;
            NPC.lavaImmune = true;
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

        public override void OnKill() {
            CalValEXWorld.nugget = CalValEXWorld.draco = CalValEXWorld.folly = CalValEXWorld.godnug = CalValEXWorld.mammoth = CalValEXWorld.shadow = false;

            if (CalValEXWorld.CanNugsSpawn()) {
                int spawnwhichnug = Main.rand.Next(0, 6);
                NuggetLicense.PickANug(spawnwhichnug);
            } else {
                Main.NewText(Language.GetTextValue("There's not enough space for a rebirth in" + ($" {Main.worldName}") + "!"), byte.MaxValue, 0, 0);
            }
        }

        public override void OnSpawn(IEntitySource source) {
            for (int i = 0; i < 16; i++) {
                int num = Dust.NewDust(NPC.position, 16, 16, DustID.FlameBurst, NPC.velocity.X / 2f, NPC.velocity.Y / 2f, 100, default(Color), 1);
                
                var dust = Main.dust[num];

                dust.velocity *= 0.66f;
                dust.scale -= 0.1f;

                if (dust.scale < 0.5f)
                    dust.active = false;
            }
        }

        public void DrawGlow(string nugName, Vector2 screenPos) {
            Texture2D glowMask = ModContent.Request<Texture2D>("CalValEX/NPCs/TownPets/Nuggets/" + nugName + "_Glow").Value;
            bool flip = NPC.spriteDirection == 1;
            Main.EntitySpriteDraw(glowMask, NPC.position - new Vector2(-10 , -14) - screenPos, NPC.frame, Color.White, NPC.rotation, 
                new Vector2(glowMask.Width / 2, glowMask.Height / 2 / 9), NPC.scale, flip ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);
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
                    NPC.frame.Y = frameHeight * Frame(0, 2, 3);
                    break;
            }
        }
    }
    #endregion

    #region // Yharon
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
                "Pollito",
                "Yhary",
                "Kulu-Ya-Ku",
                "Kazooie",
                "Taco"
            };
        }

        public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor) => DrawGlow(GetType().Name, screenPos);

        public override void AI() {
            if (!CalValEXWorld.nugget)
                CalValEXWorld.nugget = true;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money) {
            if (CalValEXWorld.nugget)
                CalValEXWorld.isThereAHouse = true;
            else
                CalValEXWorld.isThereAHouse = false;
            return true;
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
                "Pollito",
                "Rocky",
                "Aknosom",
                "Pico",
                "Frijol"
            };
        }

        public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor) => DrawGlow(GetType().Name, screenPos);

        public override void AI() {
            if (!CalValEXWorld.draco)
                CalValEXWorld.draco = true;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money) {
            if (CalValEXWorld.draco)
                CalValEXWorld.isThereAHouse = true;
            else
                CalValEXWorld.isThereAHouse = false;
            return true;
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
                "Pollito",
                "Yatagarasu",
                "Huginn",
                "Munnin",
                "Alitas"
            };
        }
        public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor) => DrawGlow(GetType().Name, screenPos);

        public override void AI() {
            if (!CalValEXWorld.folly)
                CalValEXWorld.folly = true;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money) {
            if (CalValEXWorld.folly)
                CalValEXWorld.isThereAHouse = true;
            else
                CalValEXWorld.isThereAHouse = false;
            return true;
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
                "Pollito",
                "Fiery",
                "Fatalis",
                "Guacamole"
            };
        }

        public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor) => DrawGlow(GetType().Name, screenPos);

        public override void AI() {
            if (!CalValEXWorld.godnug)
                CalValEXWorld.godnug = true;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money) {
            if (CalValEXWorld.godnug)
                CalValEXWorld.isThereAHouse = true;
            else
                CalValEXWorld.isThereAHouse = false;
            return true;
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
                "Pollito",
                "Betty",
                "Ibushi",
                "Pechuga",
                "Sobras"
            };
        }

        public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor) => DrawGlow(GetType().Name, screenPos);

        public override void AI() {
            if (!CalValEXWorld.mammoth)
                CalValEXWorld.mammoth = true;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money) {
            if (CalValEXWorld.mammoth)
                CalValEXWorld.isThereAHouse = true;
            else
                CalValEXWorld.isThereAHouse = false;
            return true;
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
                "Pollito",
                "Darky",
                "Gore Magala",
                "JubJub",
                "Mole"
            };
        }

        public override void AI() {
            if (!CalValEXWorld.shadow)
                CalValEXWorld.shadow = true;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money) {
            if (CalValEXWorld.shadow)
                CalValEXWorld.isThereAHouse = true;
            else
                CalValEXWorld.isThereAHouse = false;
            return true;
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