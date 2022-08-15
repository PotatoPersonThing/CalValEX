using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Terraria.Audio;
using CalValEX.ExtraTextures.ChristmasPets;
using CalValEX.Biomes;
using Terraria.ModLoader;
using CalValEX.AprilFools.Meldosaurus;
using CalValEX.Items;
using CalValEX.Items.Dyes;
using CalValEX.Items.Equips.Balloons;
using CalValEX.Items.Equips.Capes;
using CalValEX.Items.Equips.Hats;
using CalValEX.Items.Equips.Hats.Draedon;
using CalValEX.Items.Equips.Legs;
using CalValEX.Items.Equips.Scarves;
using CalValEX.Items.Equips.Shields;
using CalValEX.Items.Equips.Shirts;
using CalValEX.Items.Equips.Shirts.Draedon;
using CalValEX.Items.Equips.Transformations;
using CalValEX.Items.Equips.Wings;
using CalValEX.Items.Equips.Blanks;
using CalValEX.Items.Hooks;
using CalValEX.Items.LightPets;
using CalValEX.Items.Mounts;
using CalValEX.Items.Mounts.LimitedFlight;
using CalValEX.Items.Mounts.InfiniteFlight;
using CalValEX.Walls;
using CalValEX.Items.Walls.Astral;
using CalValEX.Items.Walls;
using CalValEX.Items.Pets;
using CalValEX.Items.Plushies;
using CalValEX.Items.Pets.Elementals;
using CalValEX.Items.Tiles;
using CalValEX.Items.Tiles.Blocks;
using CalValEX.Items.Tiles.FurnitureSets.Bloodstone;
using CalValEX.Items.Tiles.Plushies;
using CalValEX.NPCs.Oracle;
using CalValEX.NPCs.JellyPriest;
using CalValEX.Items.Equips.Legs.Draedon;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Shaders;
using CalValEX.Tiles.MiscFurniture;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.Localization;
using ReLogic.Content;
using CalamityMod;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Placeables.Plates;
using CalamityMod.Items.Placeables;
using CalamityMod.Items.Placeables.FurnitureStatigel;
using CalamityMod.Items.Placeables.FurnitureOtherworldly;
using CalamityMod.Items.Placeables.FurnitureStratus;
using CalamityMod.Items.Placeables.FurniturePlagued;
using CalamityMod.Items.Placeables.FurnitureProfaned;
using CalamityMod.Items.Placeables.FurnitureSilva;

namespace CalValEX
{
    public class CalValEX : Mod
    {
        public enum MessageType
        {
            SyncOraclePlayer = 0,
            PlayerBagChanged,
            SyncCalValEXPlayer,
            SyncSCalHits
        }

        public static CalValEX instance;
        public Mod herosmod;
        public Mod ortho;
        public Mod bossChecklist;
        public Mod cata;

        public const string heropermission = "CalValEX";
        public const string heropermissiondisplayname = "Calamity's Vanities";
        public bool hasPermission;

        public static bool Bumble;
        public static bool Wulfrumset;
        public static bool WulfrumsetReal;

        public static bool AprilFoolMonth;
        public static bool AprilFoolWeek;
        public static bool AprilFoolDay;

        public static string currentDate;
        public static int day;
        public static int month;
        public static Texture2D AstralSky;

        public static MethodInfo compactFraming;
        public static MethodInfo brimstoneFraming;

        public override void Load()
        {
            instance = this;
            ModLoader.TryGetMod("HEROsMod", out herosmod);
            ModLoader.TryGetMod("CalValPlus", out ortho);
            ModLoader.TryGetMod("BossChecklist", out bossChecklist);

            DateTime dateTime = DateTime.Now;
            currentDate = dateTime.ToString("dd/MM/yyyy");
            day = dateTime.Day;
            month = dateTime.Month;

            AprilFoolWeek = ortho != null || (DateTime.Now.Month == 4 && (DateTime.Now.Day == 1 || DateTime.Now.Day == 2 || DateTime.Now.Day == 3 || DateTime.Now.Day == 4 || DateTime.Now.Day == 5 || DateTime.Now.Day == 6 || DateTime.Now.Day == 7));
            AprilFoolDay = ortho != null || (DateTime.Now.Month == 4 && DateTime.Now.Day == 1);
            AprilFoolMonth = ortho != null || (DateTime.Now.Month == 4);

            AstralSky = ModContent.Request<Texture2D>("CalValEX/Biomes/AstralSky", AssetRequestMode.ImmediateLoad).Value;

            if (Main.dedServ)
                return;
            SkyManager.Instance["CalValEX:AstralBiome"] = new AstralSky();

            ModLoader.TryGetMod("Wikithis", out Mod wikithis);
            if (wikithis != null)
                wikithis.Call("AddModURL", this, "terrariamods.fandom.com$Calamity%27s_Vanities");
        }

        public override void Unload()
        {
            instance = null;
            herosmod = null;
            ortho = null;
            bossChecklist = null;
            cata = null;
            // infernum = null;
            hasPermission = false;

            currentDate = null;
            Bumble = false;
            Wulfrumset = false;
            day = -1;
            month = -1;
            compactFraming = null;
            brimstoneFraming = null;
            AstralSky = null;
            AprilFoolDay = false;
            AprilFoolWeek = false;
            AprilFoolMonth = false;

            if (Main.dedServ)
                return;

            ChristmasTextureChange.Unload();
        }

        public override void PostSetupContent()
        {
            Mod cal = ModLoader.GetMod("CalamityMod");
            cal.Call("MakeItemExhumable", ModContent.ItemType<RottingCalamitousArtifact>(), ModContent.ItemType<CalamitousSoulArtifact>());

            //Census support
            ModLoader.TryGetMod("Census", out Mod censusMod);
            if (censusMod != null)
            {
                censusMod.Call("TownNPCCondition", ModContent.NPCType<OracleNPC>(), "Equip a Pet or Light Pet");
                censusMod.Call("TownNPCCondition", ModContent.NPCType<JellyPriestNPC>(),
                    "Find at the Ocean after defeating the Eye of Cthulhu");
                censusMod.Call("TownNPCCondition", ModContent.NPCType<AprilFools.Jharim.Jharim>(), "It's a secret");
            }

            //Christmas textures
            ChristmasTextureChange.Load();

            //Boss log support
            if (bossChecklist != null)
            {
                bossChecklist.Call("AddToBossCollection", "CalamityMod", "Desert Scourge",
                    new List<int>
                    {
                        ModContent.ItemType<DesertScourgePlush>(), ModContent.ItemType<DesertMedallion>(),
                        ModContent.ItemType<DriedLocket>(), ModContent.ItemType<SlightlyMoistbutalsoSlightlyDryLocket>()
                    });
                bossChecklist.Call("AddToBossCollection", "CalamityMod", "Giant Clam",
                    new List<int> { ModContent.ItemType<ClamMask>(), ModContent.ItemType<ClamHermitMedallion>() });
                bossChecklist.Call("AddToBossCollection", "CalamityMod", "Crabulon",
                    new List<int> { ModContent.ItemType<CrabulonPlush>(), ModContent.ItemType<ClawShroom>() });
                bossChecklist.Call("AddToBossCollection", "CalamityMod", "Hive Mind",
                    new List<int> { ModContent.ItemType<HiveMindPlush>(), ModContent.ItemType<RottenKey>() });
                bossChecklist.Call("AddToBossCollection", "CalamityMod", "The Perforators",
                    new List<int> { ModContent.ItemType<PerforatorPlush>(),
                        ModContent.ItemType<MeatyWormTumor>(), ModContent.ItemType<SmallWorm>(),
                        ModContent.ItemType<MidWorm>(), ModContent.ItemType<BigWorm>()});
                bossChecklist.Call("AddToBossLoot", "CalamityMod", "Slime God",
                    new List<int> { ModContent.ItemType<StatigelBlock>() });
                bossChecklist.Call("AddToBossCollection", "CalamityMod", "Slime God",
                    new List<int> { ModContent.ItemType<SlimeGodMask>(), ModContent.ItemType<SlimeGodPlush>(), ModContent.ItemType<SlimeDeitysSoul>() });
                bossChecklist.Call("AddToBossCollection", "CalamityMod", "Cryogen",
                    new List<int> { ModContent.ItemType<CryogenPlush>(), ModContent.ItemType<CoolShades>() });
                bossChecklist.Call("AddToBossCollection", "CalamityMod", "Aquatic Scourge",
                    new List<int> { ModContent.ItemType<AquaticScourgePlush>(), ModContent.ItemType<MoistLocket>() });
                bossChecklist.Call("AddToBossLoot", "CalamityMod", "Brimstone Elemental",
                    new List<int> { ModContent.ItemType<BrimstoneSlag>() });
                bossChecklist.Call("AddToBossCollection", "CalamityMod", "Brimstone Elemental",
                    new List<int>
                    {
                        ModContent.ItemType<BrimstoneElementalPlush>(), ModContent.ItemType<BrimmyBody>(),
                        ModContent.ItemType<BrimmySpirit>(), ModContent.ItemType<FoilSpoon>(),
                        ModContent.ItemType<RareBrimtulip>()
                    });
                bossChecklist.Call("AddToBossCollection", "CalamityMod", "Calamitas",
                    new List<int> { ModContent.ItemType<ClonePlush>(), ModContent.ItemType<Calacirclet>(), ModContent.ItemType<AncientAuricTeslaHelm>() });
                bossChecklist.Call("AddToBossCollection", "CalamityMod", "Leviathan",
                    new List<int>
                    {
                        ModContent.ItemType<AnahitaPlush>(), ModContent.ItemType<LeviathanPlush>(),
                        ModContent.ItemType<LeviWings>(), ModContent.ItemType<FoilAtlantis>(), ModContent.ItemType<LeviathanEgg>(),
                        ModContent.ItemType<StrangeMusicNote>()
                    });
                //Remove pet from Aureus' boss log if Catalyst is enabled
                if (cata == null)
                {
                    bossChecklist.Call("AddToBossCollection", "CalamityMod", "Astrum Aureus",
                        new List<int>
                        {
                        ModContent.ItemType<AstrumAureusPlush>(), ModContent.ItemType<AureusShield>(), ModContent.ItemType<AstralInfectedIcosahedron>(),
                        ModContent.ItemType<SpaceJunk>(), ModContent.ItemType<AncientAuricTeslaHelm>()
                        });
                }
                else
                {
                    bossChecklist.Call("AddToBossCollection", "CalamityMod", "Astrum Aureus",
                        new List<int>
                        {
                        ModContent.ItemType<AstrumAureusPlush>(), ModContent.ItemType<AureusShield>(), ModContent.ItemType<AstralInfectedIcosahedron>(), ModContent.ItemType<AncientAuricTeslaHelm>()
                        });
                }
                bossChecklist.Call("AddToBossLoot", "CalamityMod", "Plaguebringer Goliath",
                    new List<int> { ModContent.ItemType<PlaguedContainmentBrick>(), ModContent.ItemType<PlagueHiveWand>() });
                bossChecklist.Call("AddToBossCollection", "CalamityMod", "Plaguebringer Goliath",
                    new List<int>
                    {
                        ModContent.ItemType<PlaguebringerGoliathPlush>(), ModContent.ItemType<PlaguePack>(),
                        ModContent.ItemType<InfectedController>(), ModContent.ItemType<AncientAuricTeslaHelm>()
                    });
                bossChecklist.Call("AddToBossLoot", "CalamityMod", "Ravager",
                    new List<int> { ModContent.ItemType<Necrostone>() });
                bossChecklist.Call("AddToBossCollection", "CalamityMod", "Ravager",
                    new List<int>
                    {
                        ModContent.ItemType<RavagerPlush>(), ModContent.ItemType<SkullBalloon>(),
                        ModContent.ItemType<RavaHook>(), ModContent.ItemType<ScavaHook>(),
                        ModContent.ItemType<SkullCluster>()
                    });
                bossChecklist.Call("AddToBossCollection", "CalamityMod", "Astrum Deus",
                    new List<int> {
                        ModContent.ItemType<AstrumDeusPlush>(), ModContent.ItemType<AstBandana>(),
                        ModContent.ItemType<Geminga>() });
                bossChecklist.Call("AddToBossCollection", "CalamityMod", "Profaned Guardians",
                    new List<int>
                    {
                        ModContent.ItemType<ProfanedGuardianPlush>(), ModContent.ItemType<ProfanedFrame>(),
                        ModContent.ItemType<ProfanedBattery>(), ModContent.ItemType<ProfanedWheels>()
                    });
                bossChecklist.Call("AddToBossLoot", "CalamityMod", "Dragonfolly",
                    new List<int> { ModContent.ItemType<SilvaCrystal>() });
                bossChecklist.Call("AddToBossCollection", "CalamityMod", "Dragonfolly",
                    new List<int>
                    {
                        ModContent.ItemType<BumblefuckPlush>(), ModContent.ItemType<FollyWings>(),
                        ModContent.ItemType<Birbhat>(), ModContent.ItemType<DocilePheromones>(),
                        ModContent.ItemType<TheDragonball>(), ModContent.ItemType<ExtraFluffyFeather>(),
                        ModContent.ItemType<SparrowMeat>(), ModContent.ItemType<ExtraFluffyFeatherClump>(),
                        ModContent.ItemType<AncientAuricTeslaHelm>()
                    });
                bossChecklist.Call("AddToBossLoot", "CalamityMod", "Providence",
                    new List<int> { ModContent.ItemType<ProfanedRock>() });
                bossChecklist.Call("AddToBossCollection", "CalamityMod", "Providence",
                    new List<int>
                    {
                        ModContent.ItemType<ProvidencePlush>(), ModContent.ItemType<ProviCrystal>(),
                        ModContent.ItemType<ProfanedHeart>()
                    });
                bossChecklist.Call("AddToBossLoot", "CalamityMod", "Ceaseless Void",
                    new List<int> { ModContent.ItemType<OtherworldlyStone>() });
                bossChecklist.Call("AddToBossCollection", "CalamityMod", "Ceaseless Void",
                    new List<int>
                    {
                        ModContent.ItemType<CeaselessVoidPlush>(), ModContent.ItemType<VoidWings>(),
                        ModContent.ItemType<OldVoidWings>(), ModContent.ItemType<MirrorMatter>(),
                        ModContent.ItemType<AncientAuricTeslaHelm>()
                    });
                bossChecklist.Call("AddToBossLoot", "CalamityMod", "Storm Weaver",
                    new List<int> { ModContent.ItemType<OtherworldlyStone>() });
                bossChecklist.Call("AddToBossCollection", "CalamityMod", "Storm Weaver",
                    new List<int>
                    {
                        ModContent.ItemType<StormWeaverPlush>(), ModContent.ItemType<StormBandana>(),
                        ModContent.ItemType<ArmoredScrap>(), ModContent.ItemType<StormMedal>(),
                        ModContent.ItemType<AncientAuricTeslaHelm>()
                    });
                bossChecklist.Call("AddToBossLoot", "CalamityMod", "Signus",
                    new List<int> { ModContent.ItemType<OtherworldlyStone>() });
                bossChecklist.Call("AddToBossCollection", "CalamityMod", "Signus",
                    new List<int>
                    {
                        ModContent.ItemType<SignusPlush>(), ModContent.ItemType<SignusEmblem>(),
                        ModContent.ItemType<SigCape>(), ModContent.ItemType<SignusNether>(),
                        ModContent.ItemType<ShadowCloth>(), ModContent.ItemType<SignusBalloon>(), ModContent.ItemType<SuspiciousLookingChineseCrown>(),
                        ModContent.ItemType<AncientAuricTeslaHelm>()
                    });
                bossChecklist.Call("AddToBossLoot", "CalamityMod", "Polterghast",
                    new List<int> { ModContent.ItemType<StratusBricks>(), ModContent.ItemType<PhantowaxBlock>() });
                bossChecklist.Call("AddToBossCollection", "CalamityMod", "Polterghast",
                    new List<int> {
                        ModContent.ItemType<PolterghastPlush>(),
                        ModContent.ItemType<Polterhook>(), ModContent.ItemType<ToyScythe>()
                    });
                bossChecklist.Call("AddToBossCollection", "CalamityMod", "Old Duke",
                    new List<int>
                    {
                        ModContent.ItemType<OldDukePlush>(), ModContent.ItemType<OldWings>(),
                        ModContent.ItemType<CorrodedCleaver>(), ModContent.ItemType<CharredChopper>()
                    });
                bossChecklist.Call("AddToBossCollection", "CalamityMod", "Devourer of Gods",
                    new List<int>
                    {
                        ModContent.ItemType<DevourerofGodsPlush>(),
                        ModContent.ItemType<CosmicWormScarf>(), ModContent.ItemType<RapturedWormScarf>(),
                        ModContent.ItemType<CosmicRapture>(), ModContent.ItemType<AncientAuricTeslaHelm>()
                    });
                bossChecklist.Call("AddToBossLoot", "CalamityMod", "Yharon",
                    new List<int> { ModContent.ItemType<Termipebbles>() });
                bossChecklist.Call("AddToBossCollection", "CalamityMod", "Yharon",
                    new List<int>
                    {
                        ModContent.ItemType<YharonPlush>(), ModContent.ItemType<JunglePhoenixWings>(),
                        ModContent.ItemType<YharonShackle>(), ModContent.ItemType<NuggetinaBiscuit>(), ModContent.ItemType<YharonsAnklet>(),
                        ModContent.ItemType<AncientAuricTeslaHelm>(),
                        ModContent.ItemType<DemonshadeHood>(), ModContent.ItemType<DemonshadeRobe>(), ModContent.ItemType<DemonshadePants>()
                    });
                bossChecklist.Call("AddToBossCollection", "CalamityMod", "Supreme Calamitas",
                    new List<int> { ModContent.ItemType<CalamitasFumo>(), ModContent.ItemType<GruelingMask>(), ModContent.ItemType<AncientAuricTeslaHelm>() });
                bossChecklist.Call("AddToBossLoot", "CalamityMod", "Exo Mechs",
                    new List<int> { ModContent.ItemType<CalamityMod.Items.Placeables.FurnitureExo.ExoPlating>(), ModContent.ItemType<XMLightningHook>() });
                bossChecklist.Call("AddToBossCollection", "CalamityMod", "Exo Mechs",
                    new List<int> { ModContent.ItemType<DraedonBody>(), ModContent.ItemType<DraedonLegs>(), ModContent.ItemType<DraedonPlush>(), ModContent.ItemType<AresPlush>(), ModContent.ItemType<ApolloPlush>(), ModContent.ItemType<ArtemisPlush>(), ModContent.ItemType<ThanatosPlush>(), ModContent.ItemType<AncientAuricTeslaHelm>(), ModContent.ItemType<ArtemisBalloonSmall>(), ModContent.ItemType<ApolloBalloonSmall>(), ModContent.ItemType<Items.Equips.Shirts.AresChestplate.AresChestplate>(), ModContent.ItemType<Items.Pets.ExoMechs.GunmetalRemote>(), ModContent.ItemType<Items.Pets.ExoMechs.GeminiMarkImplants>(), ModContent.ItemType<Items.Pets.ExoMechs.OminousCore>() });
                bossChecklist.Call("AddToBossLoot", "CalamityMod", "Adult Eidolon Wyrm",
                    new List<int> { ModContent.ItemType<RespirationShrine>() });
                bossChecklist.Call("AddToBossCollection", "CalamityMod", "Adult Eidolon Wyrm",
                    new List<int> { ModContent.ItemType<JaredPlush>(), ModContent.ItemType<SoulShard>(), ModContent.ItemType<OmegaBlue>() });
                bossChecklist.Call("AddToBossCollection", "CalamityMod", "Acid Rain (Post-AS)",
                    new List<int>
                    {
                        ModContent.ItemType<MawHook>(), ModContent.ItemType<FlakHeadCrab>(),
                        ModContent.ItemType<AcidLamp>(), ModContent.ItemType<Help>(),
                        ModContent.ItemType<TrilobiteShield>()
                    });
                bossChecklist.Call("AddToBossLoot", "CalamityMod", "Acid Rain (Post-Polter)",
                    new List<int> { ModContent.ItemType<NuclearFumes>() });
                bossChecklist.Call("AddToBossCollection", "CalamityMod", "Acid Rain (Post-Polter)",
                    new List<int>
                    {
                        ModContent.ItemType<MawHook>(), ModContent.ItemType<FlakHeadCrab>(),
                        ModContent.ItemType<AcidLamp>(), ModContent.ItemType<Help>(), ModContent.ItemType<Items.Mounts.Ground.RadJuice>(), ModContent.ItemType<Items.Equips.Legs.TerrorLegs>(),
                        ModContent.ItemType<TrilobiteShield>(),
                        ModContent.ItemType<GammaHelmet>()
                    });
                //Catalyst Support
                if (cata != null)
                {
                    bossChecklist.Call("AddToBossCollection", "CatalystMod", "Astrageldon",
                           new List<int> { ModContent.ItemType<SpaceJunk>(), ModContent.ItemType<Items.Tiles.Plushies.AstrageldonPlush>() });
                }
            }

            /*if (ModContent.GetInstance<CalValEXConfig>().DiscordRichPresence)
            {
                try
                {
                    var drp = ModLoader.GetMod("DiscordRP");
                    if (drp != null)
                    {
                        // This discord rich presence stuff is very wacky.
                        // Get in contact with (Discord: nalyddd#9372, Github: NalydddNobel) if you want to change any of this.
                        // (even if you are completely removing this, atleast tell me so I can get rid of my Discord-Developer-Application which hosts these images)
                        drp.Call("AddClient", "929973580178010152", "mod_calvalex");
                        drp.Call("AddBiome", (Func<bool>)(() => Main.LocalPlayer.GetModPlayer<CalValEXPlayer>().ZoneAstral), "Astral Blight",
                            "biome_astralblight", 50f, "mod_calvalex");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("There was an error when adding Discord Rich Presence support!", ex);
                }
            }*/
        }

        public override object Call(params object[] args)
        {
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args), "Arguments cannot be null!");
            }

            if (args.Length == 0)
            {
                throw new ArgumentException("Arguments cannot be empty!");
            }

            if (args[0] is string content)
            {
                switch (content)
                {
                    case "downedMeldosaurus":
                    case "meldosaurus":
                    case "downedmeldosaurus":
                    case "Meldosaurus":
                        return CalValEXWorld.downedMeldosaurus;
                    case "downedStratusApocalypse":
                    case "downedstratusapocalypse":
                    case "amogus":
                    case "downedamogus":
                        return CalValEXWorld.amogus;
                    case "inAstralBlight":
                    case "AstralBlight":
                    case "inastralblight":
                    case "oldastral":
                    case "astralblight":
                        return Main.LocalPlayer.GetModPlayer<CalValEXPlayer>().ZoneAstral;
                }
            }

            return false;
        }

        public static void MountNerf(Player player, float reduceDamageBy, float reduceHealthBy)
        {
            bool bossIsAlive = false;
            for (int i = 0; i < Main.maxNPCs; i++)
            {
                NPC npc = Main.npc[i];
                if (npc.active && npc.boss)
                {
                    bossIsAlive = true;
                }
            }

            if (bossIsAlive && !CalValEXConfig.Instance.GroundMountLol)
            {
                int calculateLife = (int)(player.statLifeMax2 * reduceHealthBy);
                player.statLifeMax2 -= calculateLife;
                player.GetDamage(DamageClass.Generic) -= reduceDamageBy;
            }
        }

        public static bool DetectProjectile(int proj)
        {
            bool bossIsAlive = false;
            for (int i = 0; i < Main.maxProjectiles; i++)
            {
                Projectile pro = Main.projectile[i];
                if (pro.type == proj && pro.active && pro != null)
                {
                    bossIsAlive = true;
                }
            }
            return bossIsAlive;
        }

        public override void HandlePacket(BinaryReader reader, int whoAmI)
        {
            MessageType msgType = (MessageType)reader.ReadByte();
            byte playerNumber;
            OraclePlayer oraclePlayer;
            CalValEXPlayer calValEXPlayer;
            int SCalHits;
            switch (msgType)
            {
                case MessageType.SyncOraclePlayer:
                    playerNumber = reader.ReadByte();
                    oraclePlayer = Main.player[playerNumber].GetModPlayer<OraclePlayer>();
                    oraclePlayer.playerHasGottenBag = reader.ReadBoolean();
                    break;

                case MessageType.PlayerBagChanged:
                    playerNumber = reader.ReadByte();
                    oraclePlayer = Main.player[playerNumber].GetModPlayer<OraclePlayer>();
                    oraclePlayer.playerHasGottenBag = reader.ReadBoolean();
                    if (Main.netMode == NetmodeID.Server)
                    {
                        var packet = GetPacket();
                        packet.Write((byte)MessageType.PlayerBagChanged);
                        packet.Write(playerNumber);
                        packet.Write(oraclePlayer.playerHasGottenBag);
                        packet.Send(-1, playerNumber);
                    }

                    break;

                case MessageType.SyncCalValEXPlayer:
                    playerNumber = reader.ReadByte();
                    calValEXPlayer = Main.player[playerNumber].GetModPlayer<CalValEXPlayer>();
                    SCalHits = reader.ReadInt32();
                    calValEXPlayer.SCalHits = SCalHits;
                    break;

                case MessageType.SyncSCalHits:
                    playerNumber = reader.ReadByte();
                    calValEXPlayer = Main.player[playerNumber].GetModPlayer<CalValEXPlayer>();
                    SCalHits = reader.ReadInt32();
                    calValEXPlayer.SCalHits = SCalHits;
                    if (Main.netMode == NetmodeID.Server)
                    {
                        var packet = GetPacket();
                        packet.Write((byte)MessageType.SyncSCalHits);
                        packet.Write(playerNumber);
                        packet.Write(calValEXPlayer.SCalHits);
                        packet.Send(-1, playerNumber);
                    }

                    break;

                default:
                    Logger.WarnFormat("CalValEX: Unknown Message type: {0}", msgType);
                    break;
            }
        }

        public override void AddRecipeGroups()/* tModPorter Note: Removed. Use ModSystem.AddRecipeGroups */
        {
            RecipeGroup sand = RecipeGroup.recipeGroups[RecipeGroup.recipeGroupIDs["Sand"]];
            sand.ValidItems.Add(ModContent.ItemType<AstralSand>());
            RecipeGroup fieref = RecipeGroup.recipeGroups[RecipeGroup.recipeGroupIDs["Fireflies"]];
            fieref.ValidItems.Add(ModContent.ItemType<Items.Critters.VaporoflyItem>());
            fieref.ValidItems.Add(ModContent.ItemType<Items.Critters.BlinkerItem>());
            RecipeGroup bf = RecipeGroup.recipeGroups[RecipeGroup.recipeGroupIDs["Butterflies"]];
            bf.ValidItems.Add(ModContent.ItemType<Items.Critters.ProvFlyItem>());
            bf.ValidItems.Add(ModContent.ItemType<Items.Critters.CrystalFlyItem>());
            if (RecipeGroup.recipeGroupIDs.ContainsKey("WingsGroup"))
            {
                int index = RecipeGroup.recipeGroupIDs["WingsGroup"];
                RecipeGroup groupe = RecipeGroup.recipeGroups[index];
                groupe.ValidItems.Add(ModContent.ItemType<WulfrumHelipack>());
                groupe.ValidItems.Add(ModContent.ItemType<AeroWings>());
                groupe.ValidItems.Add(ModContent.ItemType<GodspeedBoosters>());
                groupe.ValidItems.Add(ModContent.ItemType<FollyWings>());
                groupe.ValidItems.Add(ModContent.ItemType<JunglePhoenixWings>());
                groupe.ValidItems.Add(ModContent.ItemType<LeviWings>());
                groupe.ValidItems.Add(ModContent.ItemType<OldVoidWings>());
                groupe.ValidItems.Add(ModContent.ItemType<VoidWings>());
                groupe.ValidItems.Add(ModContent.ItemType<PlaugeWings>());
                groupe.ValidItems.Add(ModContent.ItemType<ScryllianWings>());
                groupe.ValidItems.Add(ModContent.ItemType<TerminalWings>());
            }
            if (RecipeGroup.recipeGroupIDs.ContainsKey("AnyIceBlock"))
            {
                int index = RecipeGroup.recipeGroupIDs["AnyIceBlock"];
                RecipeGroup groupe = RecipeGroup.recipeGroups[index];
                groupe.ValidItems.Add(ModContent.ItemType<AstralIce>());
            }
            RecipeGroup group = new RecipeGroup(() => "Any Plate", new int[]
            {
                ModContent.ItemType<Plagueplate>(),
                ModContent.ItemType<Cinderplate>(),
                ModContent.ItemType<Chaosplate>(),
                ModContent.ItemType<Navyplate>(),
                ModContent.ItemType<Elumplate>()
            });
            RecipeGroup.RegisterGroup("AnyPlate", group);
            
            /*RecipeGroup group2 = new RecipeGroup(() => "Any Hardmode Drill", new int[]
            {
                ItemID.CobaltDrill,
                ItemID.PalladiumDrill,
                ItemID.MythrilDrill,
                ItemID.OrichalcumDrill,
                ItemID.AdamantiteDrill,
                ItemID.TitaniumDrill,
            });
            RecipeGroup.RegisterGroup("AnyHardmodeDrill", group2);*/
        }
        public override void AddRecipes()/* tModPorter Note: Removed. Use ModSystem.AddRecipes */
        {
            if (cata != null)
            {
                cata.Call("itemset_superbossrarity", ModContent.ItemType<AstrageldonPlush>(), true);
                cata.Call("itemset_superbossrarity", ModContent.ItemType<AstrageldonPlushThrowable>(), true);
                cata.Call("itemset_superbossrarity", ModContent.ItemType<SpaceJunk>(), true);
                cata.Call("itemset_superbossrarity", ModContent.ItemType<JaredPlush>(), true);
                cata.Call("itemset_superbossrarity", ModContent.ItemType<JaredPlushThrowable>(), true);
                cata.Call("itemset_superbossrarity", ModContent.ItemType<RespirationShrine>(), true);
                cata.Call("itemset_superbossrarity", ModContent.ItemType<SoulShard>(), true);
            }
        }

        public void SetupHerosMod()
        {
            if (herosmod != null)
            {
                herosmod.Call(
                    // Special string
                    "AddPermission",
                    // Permission Name
                    heropermission,
                    // Permission Display Name
                    heropermissiondisplayname);
            }
        }

        public override void PostAddRecipes()/* tModPorter Note: Removed. Use ModSystem.PostAddRecipes */
        {
            SetupHerosMod();
        }

        public bool getPermission()
        {
            return hasPermission;
        }
    }
}