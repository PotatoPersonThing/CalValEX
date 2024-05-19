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

namespace CalValEX.Items.Plushies
{
    public class PlushManager : ModSystem
    {
        public static Dictionary<string, int> PlushItems = new Dictionary<string, int>();
        public override void Load()
        {
            LoadPlush("GiantClam", ItemUtils.BossRarity("DesertScourge"));
            LoadPlush("SandShark", ItemUtils.BossRarity("Aureus"));
            LoadPlush("MireP1", ItemUtils.BossRarity("AS"), false);
            LoadPlush("MireP2", CalRarityID.PureGreen, false);
            LoadPlush("NuclearTerror", CalRarityID.PureGreen);
            LoadPlush("Mauler", CalRarityID.PureGreen);
            LoadPlush("DesertScourge", ItemUtils.BossRarity("DesertScourge"));
            LoadPlush("Crabulon", ItemUtils.BossRarity("Crabulon"));
            LoadPlush("Perforator", ItemUtils.BossRarity("Perforator"));
            LoadPlush("HiveMind", ItemUtils.BossRarity("HiveMind"));
            LoadPlush("SlimeGod", ItemUtils.BossRarity("SlimeGod"));
            LoadPlush("Cryogen", ItemUtils.BossRarity("Cryogen"));
            LoadPlush("AquaticScourge", ItemUtils.BossRarity("AS"));
            LoadPlush("BrimstoneElemental", ItemUtils.BossRarity("Brimmy"));
            LoadPlush("Clone", ItemUtils.BossRarity("Cal"));
            LoadPlush("Shadow", ItemUtils.BossRarity("Cal"), false);
            LoadPlush("Leviathan", ItemUtils.BossRarity("Leviathan"));
            LoadPlush("Anahita", ItemUtils.BossRarity("Leviathan"));
            LoadPlush("AstrumAureus", ItemUtils.BossRarity("Aureus"));
            LoadPlush("PlaguebringerGoliath", ItemUtils.BossRarity("PBG"));
            LoadPlush("Ravager", ItemUtils.BossRarity("Ravager"));
            LoadPlush("BereftVassal", ItemUtils.BossRarity("Deus"), false);
            LoadPlush("AstrumDeus", ItemUtils.BossRarity("Deus"));
            LoadPlush("ProfanedGuardian", ItemRarityID.Purple);
            LoadPlush("Providence", 12);
            LoadPlush("Bumblefuck", ItemRarityID.Purple);
            LoadPlush("StormWeaver", 12);
            LoadPlush("Signus", 12);
            LoadPlush("CeaselessVoid", 12);
            LoadPlush("OldDuke", 13);
            LoadPlush("Polterghast", 13);
            LoadPlush("DevourerofGods", 14);
            LoadPlush("Yharon", 15);
            LoadPlush("Apollo", 15);
            LoadPlush("Artemis", 15);
            LoadPlush("Thanatos", 15);
            LoadPlush("Ares", 15);
            LoadPlush("Draedon", 15);
            LoadPlush("Calamitas", 15, false);
            LoadPlush("Jared", 16);
            LoadPlush("Astrageldon", 12);
            LoadPlush("Goozma", 15);
            LoadPlush("Hypnos", 15);
        }

        public static void LoadPlush(string name, int rarity, bool loadLegacy = true)
        {
            PlushItem item = new PlushItem(name, rarity);
            PlushTile tile = new PlushTile(name);
            PlushProj proj = new PlushProj(name);
            ModContent.GetInstance<CalValEX>().AddContent(item);
            ModContent.GetInstance<CalValEX>().AddContent(tile);
            ModContent.GetInstance<CalValEX>().AddContent(proj);
            if (loadLegacy)
            {
                CompensatedPlushItem comp = new CompensatedPlushItem(name);
                ModContent.GetInstance<CalValEX>().AddContent(comp);
                item.LegacyType = comp.Type;
            }
            item.ProjectileType = proj.Type;
            item.TileType = tile.Type;
            proj.ItemType = item.Type;
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
        protected override bool CloneNewInstances => true;

        public PlushItem(string name, int rarity)
        {
            InternalName = name + "Plush";
            TexturePath = "CalValEX/Items/Plushies/" + name + "Plush";
            Rarity = rarity;
        }

        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Swing;
            Item.width = 44;
            Item.height = 44;
            Item.consumable = true;
            Item.UseSound = SoundID.Item1;
            Item.rare = Rarity;
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
            Recipe.Create(Type).AddIngredient(LegacyType).DisableDecraft().Register();
        }
    }

    [Autoload(false)]
    public class PlushTile : ModTile
    {
        public override string Texture => TexturePath;
        public override string Name => InternalName;

        public string InternalName;
        public string TexturePath;

        public PlushTile(string name)
        {
            InternalName = name + "PlushPlaced";
            TexturePath = "CalValEX/Tiles/Plushies/" + name + "PlushPlaced";
        }

        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Terraria.ID.TileID.Sets.DisableSmartCursor[Type] = true;
            Main.tileObsidianKill[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.Width = 2;
            TileObjectData.newTile.Height = 2;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16 };
            TileObjectData.addTile(Type);
            LocalizedText name = CreateMapEntryName();
            AddMapEntry(new Color(144, 148, 144), name);
            DustType = 11;
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
