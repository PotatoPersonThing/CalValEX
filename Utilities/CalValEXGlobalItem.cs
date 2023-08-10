//using CalValEX.Buffs.LightPets;
using CalValEX.Buffs.Pets;
using CalValEX.Items;
using CalValEX.Items.Critters;
using CalValEX.Items.Equips.Balloons;
using CalValEX.Items.Equips.Hats;
using CalValEX.Items.Equips.Legs;
using CalValEX.Items.Equips.Scarves;
using CalValEX.Items.Equips.Shields;
using CalValEX.Items.Equips.Shirts;
using CalValEX.Items.Equips.Transformations;
using CalValEX.Items.Equips.Wings;
using CalValEX.Items.Hooks;
using CalValEX.Items.LightPets;
using CalValEX.Buffs.Mounts;
using CalValEX.Items.Mounts.InfiniteFlight;
using CalValEX.Items.Mounts.Ground;
using CalValEX.Items.Mounts.LimitedFlight;
using CalValEX.Items.Pets;
using CalValEX.Items.Pets.Elementals;
using CalValEX.Items.Tiles;
using CalValEX.Items.Tiles.Blocks;
using CalValEX.Items.Tiles.FurnitureSets.Bloodstone;
using CalValEX.Tiles.Blocks;
using CalValEX.Tiles;
using CalValEX.Tiles.MiscFurniture;
using CalValEX.Items.Tiles.Monoliths;
using CalValEX.Items.Tiles.Paintings;
using CalValEX.Items.Tiles.Plants;
using CalValEX.Items.Tiles.Statues;
using CalValEX.AprilFools;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.GameContent.ItemDropRules;
using System.Linq;
using Terraria.ModLoader.Default;
using CalValEX.Items.Tiles.Blueprints;
using Microsoft.Xna.Framework.Graphics;

namespace CalValEX
{
    public class CalValEXGlobalitem : GlobalItem
    {
        public override bool InstancePerEntity => true;
        //public override bool CloneNewInstances => true;

        [JITWhenModsEnabled("CalamityMod")]
        public override void SetDefaults(Item item)
        {
            if (!CalValEX.CalamityActive)
                return;

            MakePlaceable(item, CalValEX.CalamityItem("Bloodstone"), ModContent.TileType<BloodstonePlaced>());
            MakePlaceable(item, CalValEX.CalamityItem("MeldConstruct"), ModContent.TileType<MeldConstructPlaced>());
            MakePlaceable(item, CalValEX.CalamityItem("CeremonialUrn"), ModContent.TileType<CeremonialUrnPlaced>());
            MakePlaceable(item, CalValEX.CalamityItem("SupremeCalamitasCoffer"), ModContent.TileType<CalamitasCofferPlaced>());
            MakePlaceable(item, CalValEX.CalamityItem("DraedonBag"), ModContent.TileType<DraedonQuoteonQuoteBagPlaced>());
        }

        public void MakePlaceable(Item item, int theitem, int tile)
        {
            if (item.type == theitem)
            {
                item.useTurn = true;
                item.autoReuse = true;
                item.useAnimation = 15;
                item.useTime = 10;
                item.useStyle = ItemUseStyleID.Swing;
                item.consumable = true;
                item.createTile = tile;
            }
        }

        public override void ArmorSetShadows(Player player, string set)
        {
            if (player.GetModPlayer<CalValEXPlayer>().cassette)
            {
                player.armorEffectDrawShadow = true;
                player.armorEffectDrawOutlines = true;
			}
		}

        [JITWhenModsEnabled("CalamityMod")]
		public override void ModifyItemLoot(Item item, ItemLoot itemLoot)
		{
            if (!CalValEX.CalamityActive)
                return;

            LeadingConditionRule rule = new LeadingConditionRule(new DropsEnabled());
            LeadingConditionRule rule2 = new LeadingConditionRule(new BlockDrops());
            LeadingConditionRule rule3 = new LeadingConditionRule(new ProvidenceDowned());
            LeadingConditionRule rule4 = new LeadingConditionRule(new SilvaCrystal());
            LeadingConditionRule rule5 = new LeadingConditionRule(new OtherworldlyStoneDrop());
            LeadingConditionRule rule6 = new LeadingConditionRule(new CalamityDay());
            LeadingConditionRule rule7 = new LeadingConditionRule(new ThanatosDowned());
            LeadingConditionRule rule8 = new LeadingConditionRule(new TwinsDowned());
            LeadingConditionRule rule9 = new LeadingConditionRule(new AresDowned());
            LeadingConditionRule rule10 = new LeadingConditionRule(new MidhardmodeDowned());
            LeadingConditionRule rule11 = new LeadingConditionRule(new PolterDowned());
            LeadingConditionRule rule12 = new LeadingConditionRule(new AquaDowned());

            #region bags
            if (item.type == CalValEX.CalamityItem("StarterBag"))
			{
				itemLoot.Add(rule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<C>())));
			}
			else if (item.type == CalValEX.CalamityItem("DesertScourgeBag"))
			{
				itemLoot.Add(rule.OnSuccess(new CommonDrop(ModContent.ItemType<DesertMedallion>(), 10, chanceNumerator: 3)));
				itemLoot.Add(rule.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<DriedLocket>(), 5)));
				itemLoot.Add(rule.OnSuccess(new CommonDrop(ModContent.ItemType<SlightlyMoistbutalsoSlightlyDryLocket>(), 100, chanceNumerator: 7)));
			}
			else if (item.type == CalValEX.CalamityItem("CrabulonBag"))
			{
				itemLoot.Add(rule.OnSuccess(new CommonDrop(ModContent.ItemType<ClawShroom>(), 10, chanceNumerator: 3)));
			}
			else if (item.type == CalValEX.CalamityItem("HiveMindBag"))
			{
				itemLoot.Add(rule.OnSuccess(new CommonDrop(ModContent.ItemType<RottenKey>(), 10, chanceNumerator: 3)));
			}
			else if (item.type == CalValEX.CalamityItem("PerforatorBag"))
			{
				itemLoot.Add(rule.OnSuccess(new CommonDrop(ModContent.ItemType<MeatyWormTumor>(), 10, chanceNumerator: 3)));
				itemLoot.Add(rule.OnSuccess(new OneFromOptionsNotScaledWithLuckDropRule(100, 40, ModContent.ItemType<SmallWorm>(), ModContent.ItemType<MidWorm>(), ModContent.ItemType<BigWorm>())));
			}
			else if (item.type == CalValEX.CalamityItem("SlimeGodBag"))
			{
				itemLoot.Add(rule2.OnSuccess(ItemDropRule.Common(CalValEX.CalamityItem("StatigelBlock"), 1, 205, 335)));
				itemLoot.Add(rule.OnSuccess(new CommonDrop(ModContent.ItemType<SlimeDeitysSoul>(), 10, chanceNumerator: 3)));
                itemLoot.Add(rule.OnSuccess(new CommonDrop(ModContent.ItemType<SlimeGodMask>(), 7)));
            }
			else if (item.type == CalValEX.CalamityItem("CryogenBag"))
			{
				itemLoot.Add(rule.OnSuccess(new CommonDrop(ModContent.ItemType<CoolShades>(), 10, chanceNumerator: 3)));
			}
			else if (item.type == CalValEX.CalamityItem("AquaticScourgeBag"))
			{
				itemLoot.Add(rule.OnSuccess(new CommonDrop(ModContent.ItemType<MoistLocket>(), 10, chanceNumerator: 3)));
			}
			else if (item.type == CalValEX.CalamityItem("BrimstoneWaifuBag"))
			{
				itemLoot.Add(rule2.OnSuccess(ItemDropRule.Common(CalValEX.CalamityItem("BrimstoneSlag"), 1, 205, 335)));
                itemLoot.Add(rule.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<BrimmyBody>(), 5)));
				itemLoot.Add(rule.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<BrimmySpirit>(), 5)));
				itemLoot.Add(rule.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<RareBrimtulip>(), 5)));
				itemLoot.Add(rule.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<FoilSpoon>(), 20)));
			}
			else if (item.type == CalValEX.CalamityItem("CalamitasCloneBag"))
			{
				itemLoot.Add(rule.OnSuccess(new CommonDrop(ModContent.ItemType<Calacirclet>(), 10, chanceNumerator: 3)));
				itemLoot.Add(rule.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<AncientAuricTeslaHelm>(), 1000)));
			}
			else if (item.type == CalValEX.CalamityItem("LeviathanBag"))
			{
				itemLoot.Add(rule.OnSuccess(new CommonDrop(ModContent.ItemType<AquaticMonolith>(), 100, chanceNumerator: 15)));
				itemLoot.Add(rule.OnSuccess(new CommonDrop(ModContent.ItemType<LeviWings>(), 10, chanceNumerator: 3)));
				itemLoot.Add(rule.OnSuccess(new CommonDrop(ModContent.ItemType<LeviathanEgg>(), 10, chanceNumerator: 3)));
				itemLoot.Add(rule.OnSuccess(new CommonDrop(ModContent.ItemType<FoilAtlantis>(), 10, chanceNumerator: 3)));
				itemLoot.Add(rule.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<StrangeMusicNote>(), 100)));
			}
			else if (item.type == CalValEX.CalamityItem("AstrumAureusBag"))
			{
				itemLoot.Add(rule.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<AstralInfectedIcosahedron>(), 5)));
				itemLoot.Add(rule.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<AureusShield>(), 5)));
				itemLoot.Add(rule.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<AncientAuricTeslaHelm>(), 1000)));
			}
			else if (item.type == CalValEX.CalamityItem("PlaguebringerGoliathBag"))
			{
				itemLoot.Add(rule2.OnSuccess(ItemDropRule.Common(CalValEX.CalamityItem("PlaguedContainmentBrick"), 1, 205, 335)));
                itemLoot.Add(rule.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<AncientAuricTeslaHelm>(), 250)));
				itemLoot.Add(rule.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<InfectedController>(), 5)));
				itemLoot.Add(rule.OnSuccess(new CommonDrop(ModContent.ItemType<PlaguePack>(), 10, chanceNumerator: 3)));
				itemLoot.Add(rule.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<PlagueHiveWand>(), 3)));
			}
			else if (item.type == CalValEX.CalamityItem("RavagerBag"))
			{
				itemLoot.Add(rule2.OnSuccess(ItemDropRule.Common(ModContent.ItemType<Necrostone>(), 1, 205, 335)));
				itemLoot.Add(rule.OnSuccess(new CommonDrop(ModContent.ItemType<SkullCluster>(), 10, chanceNumerator: 3)));
				itemLoot.Add(rule.OnSuccess(new CommonDrop(ModContent.ItemType<ScavaHook>(), 100, chanceNumerator: 7)));
				itemLoot.Add(rule.OnSuccess(new CommonDrop(ModContent.ItemType<RavaHook>(), 10, chanceNumerator: 3)));
				itemLoot.Add(rule.OnSuccess(new CommonDrop(ModContent.ItemType<SkullBalloon>(), 10, chanceNumerator: 3)));
				itemLoot.Add(rule.OnSuccess(new CommonDrop(ModContent.ItemType<StonePile>(), 10, chanceNumerator: 3)));
			}
			else if (item.type == CalValEX.CalamityItem("AstrumDeusBag"))
			{
				itemLoot.Add(rule.OnSuccess(new CommonDrop(ModContent.ItemType<Geminga>(), 10, chanceNumerator: 3)));
				itemLoot.Add(rule.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<AstBandana>(), 5)));
			}
			else if (item.type == CalValEX.CalamityItem("DragonfollyBag"))
			{
				itemLoot.Add(rule4.OnSuccess(ItemDropRule.Common(CalValEX.CalamityItem("SilvaCrystal"), 1, 205, 335)));
                itemLoot.Add(rule.OnSuccess(ItemDropRule.OneFromOptions(1, ModContent.ItemType<FollyWings>(), ModContent.ItemType<Birbhat>(), ModContent.ItemType<DocilePheromones>())));
				itemLoot.Add(rule.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<AncientAuricTeslaHelm>(), 200)));
			}
			else if (item.type == CalValEX.CalamityItem("ProvidenceBag"))
			{
				itemLoot.Add(rule2.OnSuccess(ItemDropRule.Common(CalValEX.CalamityItem("ProfanedRock"), 1, 205, 335)));
                itemLoot.Add(rule.OnSuccess(new CommonDrop(ModContent.ItemType<ProfanedHeart>(), 10, chanceNumerator: 3)));
				itemLoot.Add(rule.OnSuccess(new CommonDrop(ModContent.ItemType<ProviCrystal>(), 10, chanceNumerator: 3)));
			}
			else if (item.type == CalValEX.CalamityItem("StormWeaverBag"))
            {
                itemLoot.Add(rule5.OnSuccess(ItemDropRule.Common(CalValEX.CalamityItem("OtherworldlyStone"), 1, 205, 335)));
                itemLoot.Add(rule.OnSuccess(ItemDropRule.OneFromOptionsNotScalingWithLuckWithX(10, 3, ModContent.ItemType<StormMedal>(), ModContent.ItemType<ArmoredScrap>())));
				itemLoot.Add(rule.OnSuccess(new CommonDrop(ModContent.ItemType<StormBandana>(), 10, chanceNumerator: 3)));
				itemLoot.Add(rule.OnSuccess(new CommonDrop(ModContent.ItemType<AncientAuricTeslaHelm>(), 1000, chanceNumerator: 7)));
			}
			else if (item.type == CalValEX.CalamityItem("CeaselessVoidBag"))
			{
				itemLoot.Add(rule5.OnSuccess(ItemDropRule.Common(CalValEX.CalamityItem("OtherworldlyStone"), 1, 205, 335)));

                itemLoot.Add(rule.OnSuccess(new CommonDrop(ModContent.ItemType<MirrorMatter>(), 10, chanceNumerator: 3)));
				itemLoot.Add(rule.OnSuccess(new CommonDrop(ModContent.ItemType<VoidWings>(), 10, chanceNumerator: 3)));
				itemLoot.Add(rule.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<OldVoidWings>(), 20)));
				itemLoot.Add(rule.OnSuccess(new CommonDrop(ModContent.ItemType<AncientAuricTeslaHelm>(), 1000, chanceNumerator: 7)));
			}
			else if (item.type == CalValEX.CalamityItem("SignusBag"))
            {
                itemLoot.Add(rule5.OnSuccess(ItemDropRule.Common(CalValEX.CalamityItem("OtherworldlyStone"), 1, 205, 335)));
                itemLoot.Add(rule.OnSuccess(new CommonDrop(ModContent.ItemType<ShadowCloth>(), 10, chanceNumerator: 3)));
				itemLoot.Add(rule.OnSuccess(ItemDropRule.OneFromOptions(1, ModContent.ItemType<SignusEmblem>(), ModContent.ItemType<SignusNether>(), ModContent.ItemType<SignusBalloon>(), ModContent.ItemType<Items.Equips.Capes.SigCape>())));
				itemLoot.Add(rule.OnSuccess(new CommonDrop(ModContent.ItemType<AncientAuricTeslaHelm>(), 1000, chanceNumerator: 7)));
			}
			else if (item.type == CalValEX.CalamityItem("PolterghastBag"))
			{
				itemLoot.Add(rule2.OnSuccess(new OneFromRulesRule(1, ItemDropRule.Common(CalValEX.CalamityItem("StratusBricks"), 1, 205, 335), ItemDropRule.Common(CalValEX.CalamityItem("PhantowaxBlock"), 1, 205, 335))));

                itemLoot.Add(rule.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<Polterhook>(), 10)));
                itemLoot.Add(rule.OnSuccess(new CommonDrop(ModContent.ItemType<ZygoteinaBucket>(), 10, chanceNumerator: 3)));
            }
			else if (item.type == CalValEX.CalamityItem("OldDukeBag"))
			{
				itemLoot.Add(rule.OnSuccess(new CommonDrop(ModContent.ItemType<OldWings>(), 10, chanceNumerator: 3)));
				itemLoot.Add(rule.OnSuccess(new CommonDrop(ModContent.ItemType<CorrodedCleaver>(), 10, chanceNumerator: 3)));
				itemLoot.Add(rule.OnSuccess(new CommonDrop(ModContent.ItemType<CharredChopper>(), 100, chanceNumerator: 7)));
			}
			else if (item.type == CalValEX.CalamityItem("DevourerofGodsBag"))
			{
				itemLoot.Add(rule.OnSuccess(new CommonDrop(ModContent.ItemType<CosmicWormScarf>(), 10, chanceNumerator: 3)));
				itemLoot.Add(rule.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<CosmicRapture>(), 5)));
				itemLoot.Add(rule.OnSuccess(new CommonDrop(ModContent.ItemType<RapturedWormScarf>(), 100, chanceNumerator: 7)));
				itemLoot.Add(rule.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<AncientAuricTeslaHelm>(), 100)));
			}
			else if (item.type == CalValEX.CalamityItem("YharonBag"))
			{
				IItemDropRule demonshade = ItemDropRule.NotScalingWithLuck(ModContent.ItemType<DemonshadeHood>(), 10);
				demonshade.OnSuccess(ItemDropRule.Common(ModContent.ItemType<DemonshadeRobe>()));
				demonshade.OnSuccess(ItemDropRule.Common(ModContent.ItemType<DemonshadePants>()));

				itemLoot.Add(rule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<Termipebbles>(), 1, 5, 8)));
				itemLoot.Add(rule.OnSuccess(new CommonDrop(ModContent.ItemType<JunglePhoenixWings>(), 10, chanceNumerator: 3)));
				itemLoot.Add(rule6.OnSuccess(new CommonDrop(ModContent.ItemType<YharonsAnklet>(), 10, chanceNumerator: 3)));
				itemLoot.Add(rule.OnSuccess(new CommonDrop(ModContent.ItemType<NuggetinaBiscuit>(), 10, chanceNumerator: 3)));
				itemLoot.Add(rule.OnSuccess(new CommonDrop(ModContent.ItemType<YharonShackle>(), 10, chanceNumerator: 3)));
				itemLoot.Add(rule.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<AncientAuricTeslaHelm>(), 20)));
				itemLoot.Add(rule.OnSuccess(demonshade));
			}
			else if (item.type == CalValEX.CalamityItem("DraedonBag"))
			{
				IItemDropRule draedon = ItemDropRule.NotScalingWithLuck(ModContent.ItemType<DraedonBody>(), 7);
				draedon.OnSuccess(ItemDropRule.Common(ModContent.ItemType<DraedonLegs>()));
				IItemDropRule balloons = ItemDropRule.NotScalingWithLuck(ModContent.ItemType<ApolloBalloonSmall>(), 2);
				balloons.OnSuccess(ItemDropRule.Common(ModContent.ItemType<ArtemisBalloonSmall>()));
				itemLoot.Add(rule2.OnSuccess(ItemDropRule.Common(CalValEX.CalamityItem("ExoPlating"), 1, 205, 335)));

                itemLoot.Add(rule7.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<XMLightningHook>(), 2)));
				itemLoot.Add(rule7.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<Items.Pets.ExoMechs.GunmetalRemote>(), 2)));

				itemLoot.Add(rule8.OnSuccess(balloons));
				itemLoot.Add(rule8.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<Items.Pets.ExoMechs.GeminiMarkImplants>(), 2)));

				itemLoot.Add(rule9.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<Items.Equips.Shirts.AresChestplate.AresChestplate>(), 2)));
				itemLoot.Add(rule9.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<Items.Pets.ExoMechs.OminousCore>(), 2)));

				itemLoot.Add(rule.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<AncientAuricTeslaHelm>(), 10)));
				itemLoot.Add(rule.OnSuccess(draedon));
			}
			else if (item.type == CalValEX.CalamityItem("CalamitasCoffer"))
            {
                itemLoot.Add(rule2.OnSuccess(ItemDropRule.Common(CalValEX.CalamityItem("OccultBrickItem"), 1, 205, 335)));
                itemLoot.Add(rule.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<AncientAuricTeslaHelm>(), 10)));
				itemLoot.Add(rule.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<GruelingMask>(), 3)));
			}

			if (ModLoader.TryGetMod("CatalystMod", out Mod catalyst))
			{
				if (item.type == catalyst.Find<ModItem>("AstrageldonBag").Type)
					itemLoot.Add(rule.OnSuccess(new CommonDrop(ModContent.ItemType<SpaceJunk>(), 10, chanceNumerator: 3)));
			}
			#endregion

			#region crates
            if (item.type == CalValEX.CalamityItem("SulphurousCrate"))
			{
                itemLoot.Add(rule.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<AcidGun>(), 100)));
                itemLoot.Add(rule.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<CursedLockpick>(), 50)));
                itemLoot.Add(rule.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<SulphurColumn>(), 20, 5, 7)));
                itemLoot.Add(rule.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<SulphurGeyser>(), 20, 2, 3)));
                itemLoot.Add(rule.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<SulphurousCactus>(), 20, 1, 3)));
                itemLoot.Add(rule.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<SulphurousPlanter>(), 25)));
                itemLoot.Add(rule10.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<InkyPollution>(), 50)));
                itemLoot.Add(rule11.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<EidolonTree>(), 40)));
                itemLoot.Add(rule11.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<NuclearFumes>(), 10, 2, 11)));
                itemLoot.Add(rule12.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<BelchingCoral>(), 20)));
            }
            else if (item.type == CalValEX.CalamityItem("AstralCrate"))
            {
                itemLoot.Add(rule.OnSuccess(new CommonDrop(ModContent.ItemType<MonolithPot>(), 100, 1, 1, 3)));
                itemLoot.Add(rule11.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<NetherTree>(), 20)));
            }
            else if (item.type == CalValEX.CalamityItem("SunkenCrate"))
            {
                itemLoot.Add(rule.OnSuccess(new CommonDrop(ModContent.ItemType<SSCoral>(), 100, 1, 1, 3)));
                itemLoot.Add(rule.OnSuccess(new CommonDrop(ModContent.ItemType<Anemone>(), 100, 1, 1, 3)));
                itemLoot.Add(rule.OnSuccess(new CommonDrop(ModContent.ItemType<TableCoral>(), 100, 1, 1, 3)));
                itemLoot.Add(rule.OnSuccess(new CommonDrop(ModContent.ItemType<FanCoral>(), 100, 1, 1, 3)));
                itemLoot.Add(rule.OnSuccess(new CommonDrop(ModContent.ItemType<BrainCoral>(), 100, 1, 1, 3)));
                itemLoot.Add(rule.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<SeaCrown>(), 100)));
                itemLoot.Add(rule.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<SunkenLamp>(), 40)));
            }
			#endregion

			#region spaghetti starter
			/*if (item.type != ModContent.ItemType<StarterBag>())
                return;

            LeadingConditionRule[] names = new LeadingConditionRule[]
            {
                new(new Combine(true, null, new rule, new PlayerNameRule("Jared"))),
                new(new Combine(true, null, new VanityDropsEnabled(), new PlayerNameRule("RamG", "Ramgear"))),
                new(new Combine(true, null, new VanityDropsEnabled(), new PlayerNameRule("Bumbledoge", "BumbleDoge", "Bojangles", "Bojeangles"))),
                new(new Combine(true, null, new VanityDropsEnabled(), new PlayerNameRule("William"))),
                new(new Combine(true, null, new VanityDropsEnabled(), new PlayerNameRule("Kiwabug"))),
                new(new Combine(true, null, new VanityDropsEnabled(), new PlayerNameRule("YuH", "Yuh", "yuh", "Lilsigtum", "GinYuH", "Lil Sigtum"))),
                new(new Combine(true, null, new VanityDropsEnabled(), new PlayerNameRule("Hypera"))),
                new(new Combine(true, null, new VanityDropsEnabled(), new PlayerNameRule("Drakudragonx"))),
                new(new Combine(true, null, new VanityDropsEnabled(), new PlayerNameRule("Spider", "spider", "Spooktacular", "spooktacular"))),
                new(new Combine(true, null, new VanityDropsEnabled(), new PlayerNameRule("Fabsol"))),
                new(new Combine(true, null, new VanityDropsEnabled(), new PlayerNameRule("Lucca"))),
                new(new Combine(true, null, new VanityDropsEnabled(), new PlayerNameRule("Junko"))),
                new(new Combine(true, null, new VanityDropsEnabled(), new PlayerNameRule("Lil Junko"))),
                new(new Combine(true, null, new VanityDropsEnabled(), new PlayerNameRule("Cooper"))),
                new(new Combine(true, null, new VanityDropsEnabled(), new PlayerNameRule("Tess"))),
                new(new Combine(true, null, new VanityDropsEnabled(), new PlayerNameRule("Enreden"))),
                new(new Combine(true, null, new VanityDropsEnabled(), new PlayerNameRule("Iban", "IbanPlay", "IBlockaroz"))),
                new(new Combine(true, null, new VanityDropsEnabled(), new PlayerNameRule("Mathew", "Mathew Maple", "Maple"))),
                new(new Combine(true, null, new VanityDropsEnabled(), new PlayerNameRule("Emerald", "EmeraldXLapis"))),
                new(new Combine(true, null, new VanityDropsEnabled(), new PlayerNameRule("Yharex87", "Yharex"))),
                new(new Combine(true, null, new VanityDropsEnabled(), new PlayerNameRule("Scarfy", "ScarfyScout", "Krysmun", "DodoNation", "Dodo"))),
                new(new Combine(true, null, new VanityDropsEnabled(), new PlayerNameRule("caligulasAquarium", "caligulas"))),
                new(new Combine(true, null, new VanityDropsEnabled(), new PlayerNameRule("Willow", "willowmaine", "bean long"))),
                new(new Combine(true, null, new VanityDropsEnabled(), new PlayerNameRule("Potato Person"))),
                new(new Combine(true, null, new VanityDropsEnabled(), new PlayerNameRule("Dorira", "Marco"))),
                new(new Combine(true, null, new VanityDropsEnabled(), new PlayerNameRule("Hat Enthusiast"))),
                new(new Combine(true, null, new VanityDropsEnabled(), new PlayerNameRule("Triangle"))),
                new(new Combine(true, null, new VanityDropsEnabled(), new PlayerNameRule("Brimmy"))),
            };

            IItemDropRule jaredPack = ItemDropRule.Common(ModContent.ItemType<CanofWyrms>());
            jaredPack.OnSuccess(ItemDropRule.Common(ModContent.ItemType<SoulShard>()));

            IItemDropRule bumbledoge = ItemDropRule.Common(ModContent.ItemType<AerialiteBubble>());
            bumbledoge.OnSuccess(ItemDropRule.Common(ModContent.ItemType<ExtraFluffyFeatherClump>()));

            IItemDropRule yuh = ItemDropRule.Common(ModContent.ItemType<FlareRune>());
            yuh.OnSuccess(ItemDropRule.Common(ModContent.ItemType<SmolEldritchHoodie>()));

            IItemDropRule lucca = ItemDropRule.Common(ModContent.ItemType<SuspiciousLookingChineseCrown>());
            lucca.OnSuccess(ItemDropRule.Common(ModContent.ItemType<ToyScythe>()));

            IItemDropRule junko = ItemDropRule.Common(ModContent.ItemType<SuspiciousLookingChineseCrown>());
            junko.OnSuccess(ItemDropRule.Common(ModContent.ItemType<ToyScythe>()));
            junko.OnSuccess(ItemDropRule.Common(ModContent.ItemType<ProfanedBalloon>()));

            IItemDropRule maple = ItemDropRule.Common(ModContent.ItemType<DeepseaLantern>());
            maple.OnSuccess(ItemDropRule.Common(ModContent.ItemType<SwearingShroom>()));
            maple.OnSuccess(ItemDropRule.Common(ModContent.ItemType<FleshThing>()));

            IItemDropRule yhar = ItemDropRule.Common(ModContent.ItemType<SpaceJunk>());
            yhar.OnSuccess(ItemDropRule.Common(ModContent.ItemType<AstraEGGeldon>()));

            IItemDropRule willow = ItemDropRule.Common(ModContent.ItemType<OldMirage>());
            willow.OnSuccess(ItemDropRule.Common(ModContent.ItemType<PerennialFlower>()));
            willow.OnSuccess(ItemDropRule.Common(ModContent.ItemType<VVanities>()));

            IItemDropRule dorira = ItemDropRule.Common(ModContent.ItemType<CharredChopper>());
            dorira.OnSuccess(ItemDropRule.Common(ModContent.ItemType<RapturedWormScarf>()));

            IItemDropRule triangle = ItemDropRule.Common(ModContent.ItemType<BubbledFin>());
            triangle.OnSuccess(ItemDropRule.Common(ModContent.ItemType<IonizedJellyCrystal>()));

            IItemDropRule brimmy = ItemDropRule.Common(ModContent.ItemType<BurningEye>());
            brimmy.OnSuccess(ItemDropRule.Common(ModContent.ItemType<FoilSpoon>()));
            brimmy.OnSuccess(ItemDropRule.Common(ModContent.ItemType<RareBrimtulip>()));

            names[0].OnSuccess(jaredPack);
            names[1].OnSuccess(ItemDropRule.Common(ModContent.ItemType<ToyScythe>()));
            names[2].OnSuccess(bumbledoge);
            names[3].OnSuccess(ItemDropRule.Common(ModContent.ItemType<RuinedBandage>()));
            names[4].OnSuccess(ItemDropRule.Common(ModContent.ItemType<UglyTentacle>()));
            names[5].OnSuccess(yuh);
            names[6].OnSuccess(ItemDropRule.Common(ModContent.ItemType<SunBun>()));
            names[7].OnSuccess(ItemDropRule.Common(ModContent.ItemType<BambooStick>()));
            names[8].OnSuccess(ItemDropRule.Common(ModContent.ItemType<IsopodItem>(), 1, 5, 5));
            names[9].OnSuccess(ItemDropRule.Common(ModContent.ItemType<CosmicRapture>()));
            names[10].OnSuccess(lucca);
            names[11].OnSuccess(junko);
            names[12].OnSuccess(ItemDropRule.Common(ModContent.ItemType<SuspiciousLookingChineseCrown>()));
            names[13].OnSuccess(ItemDropRule.Common(ModContent.ItemType<CooperShortsword>()));
            names[14].OnSuccess(ItemDropRule.Common(ModContent.ItemType<Geminga>()));
            names[15].OnSuccess(ItemDropRule.Common(ModContent.ItemType<CosmicBubble>()));
            names[16].OnSuccess(ItemDropRule.Common(ModContent.ItemType<ProtoRing>()));
            names[17].OnSuccess(maple);
            names[18].OnSuccess(ItemDropRule.Common(ModContent.ItemType<PurifiedFog>()));
            names[19].OnSuccess(yhar);
            names[20].OnSuccess(ItemDropRule.Common(ModContent.ItemType<ExtraFluffyFeather>()));
            names[21].OnSuccess(ItemDropRule.Common(ModContent.ItemType<BleuBlob>()));
            names[22].OnSuccess(willow);
            names[23].OnSuccess(ItemDropRule.Common(ModContent.ItemType<RottenKey>()));
            names[24].OnSuccess(dorira);
            names[25].OnSuccess(ItemDropRule.Common(ModContent.ItemType<InkyArtifact>()));
            names[26].OnSuccess(triangle);
            names[27].OnSuccess(brimmy);*/
            #endregion
        }
		#region drop rules
        private class PlayerNameRule : IItemDropRuleCondition
        {
            public readonly string[] names;

            public PlayerNameRule(params string[] names) => this.names = names;

			public bool CanDrop(DropAttemptInfo info)
			{
                foreach (string s in names)
                    if (info.player.name == s)
                        return true;
				return false;
			}

			public bool CanShowItemDropInUI() => true;

            public string GetConditionDescription() => null;
        }
		private class Combine : IItemDropRuleCondition
        {
            private readonly bool andConditions;
            private readonly IItemDropRuleCondition[] conditions;
            private readonly string description;

            public Combine(bool andConditions = true, string? description = null,
                   params IItemDropRuleCondition[] dropRuleConditions)
            {
                this.andConditions = andConditions;
                this.description = description;
                conditions = dropRuleConditions;
            }

            public bool CanDrop(DropAttemptInfo info) => andConditions
                    ? conditions.All(val => val.CanDrop(info))
                    : conditions.Any(val => val.CanDrop(info));

			public bool CanShowItemDropInUI() => andConditions
					? conditions.All(val => val.CanShowItemDropInUI())
					: conditions.Any(val => val.CanShowItemDropInUI());

			public string GetConditionDescription() => description;
		}
        #endregion
        [JITWhenModsEnabled("CalamityMod")]
        public override void RightClick(Item item, Player player)
        {
            if (!CalValEX.CalamityActive)
                return;

            if (!CalValEXConfig.Instance.DisableVanityDrops && item.type == CalValEX.CalamityItem("StarterBag") && player.whoAmI == Main.myPlayer && CalValEX.AprilFoolWeek&& !NPC.AnyNPCs(ModContent.NPCType<AprilFools.Jharim.Jharim>()))
			{
				NPC.NewNPC(player.GetSource_ReleaseEntity(), (int)player.Center.X, (int)player.Center.Y, ModContent.NPCType<AprilFools.Jharim.Jharim>());
			}
		}

        public override void UpdateAccessory(Item item, Player player, bool hide)
        {
            CalValEXPlayer modplayer = player.GetModPlayer<CalValEXPlayer>();
            if (CalValEX.CalamityActive)
            {
                if (item.type == CalValEX.CalamityItem("AquaticHeart") && !hide)
                {
                    modplayer.SirenHeart = true;
                }
                if (item.type == CalValEX.CalamityItem("CirrusDress"))
                {
                    modplayer.CirrusDress = true;
                }
            }
        }

        public override void UpdateVanity(Item item, Player player)
        {
            CalValEXPlayer modplayer = player.GetModPlayer<CalValEXPlayer>();
            if (CalValEX.CalamityActive)
            {
                if (item.type == CalValEX.CalamityItem("AquaticHeart"))
                {
                    modplayer.SirenHeart = true;
                }
                if (item.type == CalValEX.CalamityItem("CirrusDress"))
                {
                    modplayer.CirrusDress = true;
                }
            }
        }

        public override void UpdateEquip(Item item, Player player)
        {
            CalValEXPlayer modplayer = player.GetModPlayer<CalValEXPlayer>();
            if (CalValEX.CalamityActive)
            {
                if (item.type == CalValEX.CalamityItem("CirrusDress"))
                {
                    modplayer.CirrusDress = true;
                }
            }
        }
    }
}
