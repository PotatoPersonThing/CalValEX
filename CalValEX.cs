using System;
using System.IO;
using CalValEX.ExtraTextures.ChristmasPets;
using CalValEX.Biomes;
using Terraria.ModLoader;
using CalValEX.Items.Pets;
using CalValEX.NPCs.Oracle;
using CalValEX.NPCs.JellyPriest;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.Localization;
using ReLogic.Content;
using CalValEX.NPCs.TownPets.Nuggets;
using CalValEX.Items.Pets.TownPets;

namespace CalValEX
{
    public partial class CalValEX : Mod
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

        public static bool AprilFoolMonth;
        public static bool AprilFoolWeek;
        public static bool AprilFoolDay;

        public static string currentDate;
        public static int day;
        public static int month;
        public static Texture2D AstralSky;


        public override void Load()
        {
            instance = this;

            calamityActive = ModLoader.TryGetMod("CalamityMod", out calamity);

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

            //ModLoader.TryGetMod("Wikithis", out Mod wikithis);
            //if (wikithis != null)
                //wikithis.Call("AddModURL", this, "terrariamods.fandom.com$Calamity%27s_Vanities");
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
            day = -1;
            month = -1;
            AstralSky = null;
            AprilFoolDay = false;
            AprilFoolWeek = false;
            AprilFoolMonth = false;

            if (Main.dedServ)
                return;

            ChristmasTextureChange.Unload();
        }

        public static bool GetShopJelly(Player player)
        {
            return Main.LocalPlayer.GetModPlayer<CalValEXPlayer>().jellyInv;
        }
        public static void SetShopJelly(Player player, bool enabled)
        {
            Main.LocalPlayer.GetModPlayer<CalValEXPlayer>().jellyInv = enabled;
        }

        public static bool GetShopOracle(Player player)
        {
            return Main.LocalPlayer.GetModPlayer<CalValEXPlayer>().oracleInv;
        }
        public static void SetShopOracle(Player player, bool enabled)
        {
            Main.LocalPlayer.GetModPlayer<CalValEXPlayer>().oracleInv = enabled;
        }

        public override void PostSetupContent()
        {
            if (CalamityActive)
            {
                Mod cal = ModLoader.GetMod("CalamityMod");
                cal.Call("MakeItemExhumable", ModContent.ItemType<RottingCalamitousArtifact>(), ModContent.ItemType<CalamitousSoulArtifact>());
                cal.Call("RegisterNPCShop", ModContent.NPCType<JellyPriestNPC>(), new Predicate<Player>(GetShopJelly), new Action<Player, bool>(SetShopJelly));
                cal.Call("RegisterNPCShop", ModContent.NPCType<OracleNPC>(), new Predicate<Player>(GetShopOracle), new Action<Player, bool>(SetShopOracle));
            }

            //Census support
            ModLoader.TryGetMod("Census", out Mod censusMod);
            if (censusMod != null)
            {
                censusMod.Call("TownNPCCondition", ModContent.NPCType<OracleNPC>(), "Equip a Pet or Light Pet");
                censusMod.Call("TownNPCCondition", ModContent.NPCType<JellyPriestNPC>(),
                    "Find at the Sulphurous Sea after defeating the Acid Rain's first tier");
                censusMod.Call("TownNPCCondition", ModContent.NPCType<AprilFools.Jharim.Jharim>(), "It's a secret");
                censusMod.Call("TownNPCCondition", ModContent.NPCType<NPCs.TownPets.Slimes.AstroSlime>(), "Hit Astrum Aureus with the ABandoned Slime Staff's minion");
                censusMod.Call("TownNPCCondition", ModContent.NPCType<NPCs.TownPets.Slimes.NinjaSlime>(), "Has a chance to spawn upon hitting any normal slime with a Shuriken");
                censusMod.Call("TownNPCCondition", ModContent.NPCType<NPCs.TownPets.Slimes.Tarr>(), "Defeat Goozma (with CalamityHunt) or let the Slime God eat a town slime (without CalamityHunt)");

                censusMod.Call("TownNPCCondition", ModContent.NPCType<NuggetNugget>(), Language.GetText("Mods.CalValEX.Census") + $" [i:{ModContent.ItemType<NuggetLicense>()}]");
                censusMod.Call("TownNPCCondition", ModContent.NPCType<DracoNugget>(), Language.GetTextValue("Mods.CalValEX.Census") + $" [i:{ModContent.ItemType<NuggetLicense>()}]");
                censusMod.Call("TownNPCCondition", ModContent.NPCType<FollyNugget>(), Language.GetTextValue("Mods.CalValEX.Census") + $" [i:{ModContent.ItemType<NuggetLicense>()}]");
                censusMod.Call("TownNPCCondition", ModContent.NPCType<GODNugget>(), Language.GetTextValue("Mods.CalValEX.Census") + $" [i:{ModContent.ItemType<NuggetLicense>()}]");
                censusMod.Call("TownNPCCondition", ModContent.NPCType<MammothNugget>(), Language.GetTextValue("Mods.CalValEX.Census") + $" [i:{ModContent.ItemType<NuggetLicense>()}]");
                censusMod.Call("TownNPCCondition", ModContent.NPCType<ShadowNugget>(), Language.GetTextValue("Mods.CalValEX.Census") + $" [i:{ModContent.ItemType<NuggetLicense>()}]");
            }

            //Christmas textures
            ChristmasTextureChange.Load();
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

        public bool getPermission()
        {
            return hasPermission;
        }
    }
}