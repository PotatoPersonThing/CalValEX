using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria;
using System.Collections.Generic;
using CalValEX.CalamityID;
using CalValEX.Projectiles.Plushies;
using Terraria.DataStructures;
using Terraria.Audio;

namespace CalValEX.Items.Plushies
{
    public class PlushManager : ModSystem
    {
        // Contains all of the plush items
        // To get a plush item, just insert the boss' name as per the wall of entries below
        public static Dictionary<string, int> PlushItems = new Dictionary<string, int>();

        // Load all of the plushies
        public override void Load()
        {
            LoadPlush("GiantClam", ItemUtils.BossRarity("DesertScourge"), sound: GetCalamitySound("Item/ClamImpact", SoundID.NPCHit4));
            LoadPlush("SandShark", ItemUtils.BossRarity("Aureus"), sound: GetCalamitySound("Custom/GreatSandSharkRoar", SoundID.Zombie7));
            LoadPlush("MireP1", ItemUtils.BossRarity("AS"), false, sound: SoundID.NPCHit42); // Has an unorthodox old name, so it must be done separately
            LoadPlush("MireP2", 13, false, sound: SoundID.NPCHit1); // Has an unorthodox old name, so it must be done separately
            LoadPlush("NuclearTerror", 13, sound: GetCalamitySound("Custom/NuclearTerrorSpawn", SoundID.NPCDeath10));
            LoadPlush("Mauler", 13, sound: GetCalamitySound("Custom/GreatSandSharkRoar", SoundID.Zombie7));
            LoadPlush("DesertScourge", ItemUtils.BossRarity("DesertScourge"), sound: GetCalamitySound("Custom/MaulerRoar", SoundID.Zombie92));
            LoadPlush("Crabulon", ItemUtils.BossRarity("Crabulon"), sound: SoundID.NPCHit45);
            LoadPlush("Perforator", ItemUtils.BossRarity("Perforator"), sound: GetCalamitySound("Custom/Perforator/PerfHiveWormSpawn", SoundID.NPCDeath23));
            LoadPlush("HiveMind", ItemUtils.BossRarity("HiveMind"), sound: GetCalamitySound("Custom/HiveMindRoar", SoundID.NPCHit9));
            LoadPlush("SlimeGod", ItemUtils.BossRarity("SlimeGod"), sound: GetCalamitySound("Custom/SlimeGodPossession", SoundID.NPCDeath1));
            LoadPlush("Cryogen", ItemUtils.BossRarity("Cryogen"), sound: GetCalamitySound("NPCHit/CryogenHit1", SoundID.NPCHit5));
            LoadPlush("AquaticScourge", ItemUtils.BossRarity("AS"), sound: SoundID.NPCDeath13);
            LoadPlush("BrimstoneElemental", ItemUtils.BossRarity("Brimmy"), sound: SoundID.NPCHit23);
            LoadPlush("Clone", ItemUtils.BossRarity("Cal"), sound: GetCalamitySound("Custom/SCalSounds/BrimstoneShoot", SoundID.NPCHit4));
            LoadPlush("Shadow", ItemUtils.BossRarity("Cal"), false, sound: GetCalamitySound("Custom/SupremeCalamitasSpawn", SoundID.Zombie109)); 
            LoadPlush("Leviathan", ItemUtils.BossRarity("Leviathan"), sound: GetCalamitySound("Custom/LeviathanRoarMeteor", SoundID.Zombie39));
            LoadPlush("Anahita", ItemUtils.BossRarity("Leviathan"), sound: SoundID.Item26);
            LoadPlush("AstrumAureus", ItemUtils.BossRarity("Aureus"), sound: GetCalamitySound("NPCHit/AureusHit1", SoundID.Item109));
            LoadPlush("Exotrexia", ItemUtils.BossRarity("Aureus"), false, sound: SoundID.NPCHit1);
            LoadPlush("Astigmageddon", ItemUtils.BossRarity("Aureus"), false, sound: SoundID.NPCHit1);
            LoadPlush("Cataractacomb", ItemUtils.BossRarity("Aureus"), false, sound: SoundID.NPCHit1);
            LoadPlush("Conjunctivirus", ItemUtils.BossRarity("Aureus"), false, sound: SoundID.NPCHit1);
            LoadPlush("Polyphemalus", ItemUtils.BossRarity("Aureus"), false, 3, 3, sound: SoundID.NPCDeath1);
            LoadPlush("PlaguebringerGoliath", ItemUtils.BossRarity("PBG"), sound: GetCalamitySound("Custom/PlagueSounds/PBGNukeWarning", SoundID.NPCDeath14));
            LoadPlush("Ravager", ItemUtils.BossRarity("Ravager"), sound: GetCalamitySound("NPCKilled/RavagerLimbLoss1", SoundID.NPCHit41));
            LoadPlush("BereftVassal", ItemUtils.BossRarity("Deus"), false, sound: GetOtherModSound("InfernumMode", "InfernumMode/Assets/Sounds/Custom/BereftVassal/VassalHornSound", SoundID.DD2_OgreHurt));
            LoadPlush("AstrumDeus", ItemUtils.BossRarity("Deus"), sound: GetCalamitySound("Custom/AstrumDeus/AstrumDeusMine", SoundID.Item4));
            LoadPlush("ProfanedGuardian", ItemRarityID.Purple, sound: GetCalamitySound("Custom/ProfanedGuardians/GuardianRockShieldActivate", SoundID.NPCHit52));
            LoadPlush("Providence", 12, sound: GetCalamitySound("Custom/Providence/ProvidenceHolyRay", SoundID.NPCHit44));
            LoadPlush("Bumblefuck", ItemRarityID.Purple, sound: SoundID.NPCHit51);
            LoadPlush("StormWeaver", 12, sound: GetCalamitySound("Item/StormWeaverSpawn", SoundID.Thunder));
            LoadPlush("Signus", 12, sound: GetCalamitySound("Item/SignusSpawn", SoundID.NPCHit54));
            LoadPlush("CeaselessVoid", 12, sound: GetCalamitySound("Item/CeaselessVoidSpawn", SoundID.NPCHit4));
            LoadPlush("OldDuke", 13, sound: GetCalamitySound("Custom/OldDukeRoar", SoundID.NPCHit14));
            LoadPlush("Polterghast", 13, sound: GetCalamitySound("Custom/Polterghast/PolterSpook1", SoundID.NPCHit36));
            LoadPlush("DevourerofGods", 14, sound: GetCalamitySound("Custom/DevourerAttack", SoundID.Item27));
            LoadPlush("Yharon", 15, sound: GetCalamitySound("Custom/Yharon/YharonRoarShort", SoundID.Zombie92));
            LoadPlush("Apollo", 15, sound: GetCalamitySound("Custom/ExoMechs/ArtemisApolloDash", SoundID.Item34));
            LoadPlush("Artemis", 15, sound: GetCalamitySound("Custom/ExoMechs/ArtemisShotgunLaser", SoundID.Item27));
            LoadPlush("Thanatos", 15, sound: GetCalamitySound("Custom/ExoMechs/ThanatosVent", SoundID.Item27));
            LoadPlush("Ares", 15, sound: GetCalamitySound("Custom/ExoMechs/AresCircleLaserStart", SoundID.Item34));
            LoadPlush("Draedon", 15, sound: GetCalamitySound("Custom/DraedonLaugh", SoundID.Clown));
            LoadPlush("Calamitas", 15, false, sound: GetCalamitySound("Custom/SupremeCalamitasSpawn", SoundID.Zombie109)); // Has an unorthodox old name, so it must be done separately
            LoadPlush("Jared", 16, sound: GetCalamitySound("Custom/PrimordialWyrmCharge", SoundID.NPCHit1));
            LoadPlush("Astrageldon", 12, sound: GetOtherModSound("CatalystMod", "CatalystMod/Assets/Sounds/AstrageldonImpact", SoundID.Item4));
            LoadPlush("Goozma", 15, sound: GetOtherModSound("CalamityHunt", "CalamityHunt/Assets/Sounds/Goozma/GoozmaAwaken", SoundID.NPCDeath1));
            LoadPlush("Hypnos", 15, sound: GetCalamitySound("Custom/ExoMechs/ExoLaserShoot", SoundID.Item34));
            LoadPlush("Exodygen", 16, false, sound: SoundID.NPCDeath61);
            LoadPlush("LeviathanEX", ItemUtils.BossRarity("Leviathan"), false, 3, 3, sound: GetCalamitySound("Custom/LeviathanRoarCharge", SoundID.Zombie39));
            LoadPlush("YharonEX", 15, false, 3, 3, sound: GetCalamitySound("Custom/Yharon/YharonRoar", SoundID.Zombie92));
            LoadPlush("DevourerofGodsEX", 14, false, 3, 3, sound: GetCalamitySound("Custom/DevourerSpawn", SoundID.Meowmere));
            LoadPlush("EntropicNoxus", 16, false, sound: GetOtherModSound("CalRemix", "CalRemix/Assets/Sounds/Noxus/NoxusScream", SoundID.Item104));
            LoadPlush("NamelessDeity", 16, false, sound: GetOtherModSound("NoxusBoss", "NoxusBoss/Assets/Sounds/Custom/NamelessDeity/ScreamShort", SoundID.Item163));
            LoadPlush("NamelessDeityEX", 16, false, 3, 3, sound: GetOtherModSound("NoxusBoss", "NoxusBoss/Assets/Sounds/Custom/NamelessDeity/ScreamLong", SoundID.Item164));
        }

        public SoundStyle GetCalamitySound(string calPath, SoundStyle vanillaSound)
        {
            if (ModLoader.HasMod("CalamityMod"))
            {
                return new SoundStyle("CalamityMod/Sounds/" + calPath);
            }
            return vanillaSound;
        }

        public SoundStyle GetOtherModSound(string modName, string path, SoundStyle vanillaSound)
        {
            if (ModLoader.TryGetMod(modName, out _))
            {
                SoundStyle style = new SoundStyle(path);

                if (style != default)
                    return new SoundStyle(path);
            }
            return vanillaSound;
        }

        /// <summary>
        /// Adds a plush 
        /// </summary>
        /// <param name="name">The name of the entity a plush is being made of. The sprites should follow the same naming convention with XPlush and XPlushPlaced</param>
        /// <param name="rarity">The rarity, same as the boss drops.</param>
        /// <param name="loadLegacy">Whether or not a legacy plush should be loaded for refunding. Set this to false for all future plushies.</param>
        /// <param name="width">The plush tile width</param>
        /// <param name="height">The plush tile height</param>
        public static void LoadPlush(string name, int rarity, bool loadLegacy = true, int width = 2, int height = 2, SoundStyle sound = default)
        {
            PlushItem item = new PlushItem(name, rarity);
            PlushTile tile = new PlushTile(name, sound);
            PlushProj proj = new PlushProj(name);
            ModContent.GetInstance<CalValEX>().AddContent(item);
            ModContent.GetInstance<CalValEX>().AddContent(tile);
            ModContent.GetInstance<CalValEX>().AddContent(proj);
            // Add the legacy "throwable" plush
            if (loadLegacy)
            {
                CompensatedPlushItem comp = new CompensatedPlushItem(name);
                ModContent.GetInstance<CalValEX>().AddContent(comp);
                item.LegacyType = comp.Type;
            }
            // Set the item's projectile and tile types, as well as the projectile's item drop type
            item.ProjectileType = proj.Type;
            item.TileType = tile.Type;
            proj.ItemType = item.Type;
            tile.Width = width;
            tile.Height = height;
            tile.ItemType = item.Type;
            // Add the item to the plush list
            PlushItems.Add(name, item.Type);
        }
    }

    [Autoload(false)]
    public class PlushItem : ModItem
    {
        public override string Texture => TexturePath;
        public override string Name => InternalName;

        public int ProjectileType;
        public int TileType;
        public int Rarity;
        public string TexturePath;
        public string InternalName;
        public int LegacyType;
        public string PlushName;
        protected override bool CloneNewInstances => true;

        public PlushItem(string name, int rarity)
        {
            PlushName = name;
            InternalName = name + "Plush";
            TexturePath = "CalValEX/Items/Plushies/" + name + "Plush";
            Rarity = rarity;
        }
        public override void SetStaticDefaults()
        {
            if (Name.Contains("EX"))
            {
                string withoutEX = PlushName.Replace("EX", "");
                ItemID.Sets.ShimmerTransformToItem[Type] = PlushManager.PlushItems[withoutEX];
                ItemID.Sets.ShimmerTransformToItem[PlushManager.PlushItems[withoutEX]] = Type;
            }
        }

        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Swing;
            Item.width = 44;
            Item.height = 44;
            Item.consumable = true;
            Item.UseSound = SoundID.Item1;
            Item.rare = Rarity;
            // CalRarityID isn't done by load time, so unfortunately, this has to be done like this
            if (Rarity > 11)
            {
                Item.rare = CalRarityID.Turquoise;
                switch (Rarity)
                {
                    case 13:
                        Item.rare = CalRarityID.PureGreen;
                        break;
                    case 14:
                        Item.rare = CalRarityID.DarkBlue;
                        break;
                    case 15:
                        Item.rare = CalRarityID.Violet;
                        break;
                    case 16:
                        Item.rare = CalRarityID.HotPink;
                        break;
                }
            }
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.value = 20;
            Item.createTile = TileType;
            Item.maxStack = 9999;
        }

        public override bool AltFunctionUse(Player player) => true;

        public override void UseAnimation(Player player)
        {
            if (player.altFunctionUse == 2f)
            {
                Item.shoot = ProjectileType;
                Item.shootSpeed = 6f;
                Item.createTile = -1;
                // Calamitas plush has a custom projectile
                if (Item.type == PlushManager.PlushItems["Calamitas"])
                {
                    Item.shoot = ModContent.ProjectileType<CalaFumoSpeen>();
                }
            }
            else
            {
                Item.shoot = ProjectileID.None;
                Item.shootSpeed = 0f;
                Item.createTile = TileType;
            }
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            // Calamitas plush can randomly throw out very concerning alt variants
            if (Item.type == PlushManager.PlushItems["Calamitas"])
            {
                if (Main.rand.NextFloat() < 0.01f)
                {
                    type = ModContent.ProjectileType<ItsReal>();
                    Terraria.Audio.SoundEngine.PlaySound(SoundID.NPCHit49, player.position);
                    Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI);
                    return false;
                }
                else if (Main.rand.NextFloat() < 0.1f && CalValEX.month == 6 && CalValEX.day == 22)
                {
                    type = ModContent.ProjectileType<ItsReal>();
                    Terraria.Audio.SoundEngine.PlaySound(SoundID.NPCHit49, player.position);
                    Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI);
                    return false;
                }
                else if (Main.rand.NextFloat() < 0.002f)
                {
                    type = ModContent.ProjectileType<ItsRealAlt>();
                    Terraria.Audio.SoundEngine.PlaySound(SoundID.NPCHit49, player.position);
                    Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI);
                    return false;
                }
            }
            return true;
        }

        public override void AddRecipes()
        {
            if (LegacyType > 0)
            {
                Recipe.Create(Type).AddIngredient(LegacyType).DisableDecraft().Register();
            }
        }
    }

    [Autoload(false)]
    public class PlushTile : ModTile
    {
        public override string Texture => TexturePath;
        public override string Name => InternalName;

        public string InternalName;
        public string TexturePath;

        public int Height = 2;
        public int Width = 2;

        public SoundStyle ClickSound;

        public int ItemType;

        public PlushTile(string name, SoundStyle sound)
        {
            InternalName = name + "PlushPlaced";
            TexturePath = "CalValEX/Tiles/Plushies/" + name + "PlushPlaced";
            ClickSound = sound;
        }

        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Terraria.ID.TileID.Sets.DisableSmartCursor[Type] = true;
            Main.tileObsidianKill[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.Width = Width;
            TileObjectData.newTile.Height = Height;
            List<int> heightArray = new List<int>(0);
            for (int i = 0; i < Height; i++)
            {
                heightArray.Add(16);
            }
            TileObjectData.newTile.CoordinateHeights = heightArray.ToArray();
            TileObjectData.addTile(Type);
            LocalizedText name = CreateMapEntryName();
            AddMapEntry(new Color(144, 148, 144), name);
            DustType = 11;
        }
        public override void MouseOver(int i, int j)
        {
            Player localPlayer = Main.LocalPlayer;
            localPlayer.noThrow = 2;
            localPlayer.cursorItemIconEnabled = true;
            localPlayer.cursorItemIconID = ItemType;
        }
        public override bool RightClick(int i, int j)
        {
            Player player = Main.LocalPlayer;
            SoundEngine.PlaySound(ClickSound with { Pitch = 0.5f }, new Vector2(i * 16, j * 16));
            if (CalValEX.CalamityActive)
            {
                if (ItemType == PlushManager.PlushItems["DevourerofGods"] || ItemType == PlushManager.PlushItems["DevourerofGodsEX"])
                {
                    List<string> dialogue =
                    [
                        Language.GetTextValue("Mods.CalamityMod.Status.Boss.EdgyBossText"),
                        Language.GetTextValue("Mods.CalamityMod.Status.Boss.EdgyBossText2"),
                        Language.GetTextValue("Mods.CalamityMod.Status.Boss.EdgyBossText3"),
                        Language.GetTextValue("Mods.CalamityMod.Status.Boss.EdgyBossText4"),
                        Language.GetTextValue("Mods.CalamityMod.Status.Boss.EdgyBossText5"),
                        Language.GetTextValue("Mods.CalamityMod.Status.Boss.EdgyBossText6"),
                        Language.GetTextValue("Mods.CalamityMod.Status.Boss.EdgyBossText7"),
                        Language.GetTextValue("Mods.CalamityMod.Status.Boss.EdgyBossText8"),
                    ];
                    CombatText.NewText(new Rectangle(i * 16, j * 16, 16 * Width, 16 * Height), Color.LightBlue, dialogue[Main.rand.Next(0, dialogue.Count - 1)]);
                }
            }
            return true;
        }


    }

    [Autoload(false)]
    public class PlushProj : ModProjectile
    {
        public override string Texture => "CalValEX/Items/Plushies/" + PlushName + "Plush";
        public override string Name => PlushName + "Plush";

        protected readonly string PlushName;
        public int ItemType;
        protected override bool CloneNewInstances => true;

        public PlushProj(string name)
        {
            PlushName = name;
        }
        public override void SetDefaults()
        {
            Projectile.netImportant = true;
            Projectile.width = 44;
            Projectile.height = 44;
            Projectile.aiStyle = 32;
            Projectile.friendly = true;
        }

        public override void OnKill(int timeLeft)
        {
            Item.NewItem(Projectile.GetSource_DropAsItem(), Projectile.getRect(), ItemType);
        }
    }
    [Autoload(false)]
    public class CompensatedPlushItem : ModItem
    {
        public override string Texture => TexturePath;
        public override string Name => InternalName;

        public string TexturePath;
        public string InternalName;
        public string PlushName;
        protected override bool CloneNewInstances => true;

        public CompensatedPlushItem(string name)
        {
            PlushName = name;
            InternalName = name + "PlushThrowable";
            TexturePath = "CalValEX/Items/Plushies/" + name + "Plush";
        }

        public override void SetDefaults()
        {
            Item.width = 44;
            Item.height = 44;
            Item.rare = ItemRarityID.Gray;
            Item.value = 40;
            Item.maxStack = 9999;
        }

        public override void UpdateInventory(Player player)
        {
            Item.SetDefaults(PlushManager.PlushItems[PlushName]);
        }
    }
}
