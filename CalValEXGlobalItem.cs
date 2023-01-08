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

            if (item.type == CalValEX.CalamityItem("Bloodstone"))
            {
                item.useTurn = true;
                item.autoReuse = true;
                item.useAnimation = 15;
                item.useTime = 10;
                item.useStyle = ItemUseStyleID.Swing;
                item.consumable = true;
                item.createTile = ModContent.TileType<BloodstonePlaced>();
            }
            if (item.type == CalValEX.CalamityItem("MeldConstruct"))
            {
                item.useTurn = true;
                item.autoReuse = true;
                item.useAnimation = 15;
                item.useTime = 10;
                item.useStyle = ItemUseStyleID.Swing;
                item.consumable = true;
                item.createTile = ModContent.TileType<MeldConstructPlaced>();
            }
            if (item.type == CalValEX.CalamityItem("CeremonialUrn"))
            {
                item.useTurn = true;
                item.autoReuse = true;
                item.useAnimation = 15;
                item.useTime = 10;
                item.useStyle = ItemUseStyleID.Swing;
                item.consumable = true;
                item.createTile = ModContent.TileType<CeremonialUrnPlaced>();
            }
            if (item.type == CalValEX.CalamityItem("SupremeCalamitasCoffer"))
            {
                item.useTurn = true;
                item.autoReuse = true;
                item.useAnimation = 15;
                item.useTime = 10;
                item.useStyle = ItemUseStyleID.Swing;
                item.consumable = true;
                item.createTile = ModContent.TileType<CalamitasCofferPlaced>();
            }
            if (item.type == CalValEX.CalamityItem("DraedonBag"))
            {
                item.useTurn = true;
                item.autoReuse = true;
                item.useAnimation = 15;
                item.useTime = 10;
                item.useStyle = ItemUseStyleID.Swing;
                item.consumable = true;
                item.createTile = ModContent.TileType<DraedonQuoteonQuoteBagPlaced>();
            }
        }

        /*public override void ModifyWeaponDamage(Item item, Player player, ref float add, ref float mult)
        {
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            Mod orthoceraDLC = ModLoader.GetMod("CalValPlus");
            bool april = (CalValEX.month == 4 && (CalValEX.day == 1 || CalValEX.day == 2 || CalValEX.day == 3 || CalValEX.day == 4 || CalValEX.day == 5 || CalValEX.day == 6 || CalValEX.day == 7));
            if (orthoceraDLC != null || april)
            {
                if (item.type == calamityMod.ItemType("CosmicDischarge"))
                {
                    item.damage = item.damage + ((bool)calamityMod.Call("GetBossDowned", "yharon") ? 1 : 0)
                        + ((bool)calamityMod.Call("GetBossDowned", "supremecalamitas") ? 1 : 0);
                }
                else if (item.type == calamityMod.ItemType("SHPC"))
                {
                    item.damage = item.damage + (NPC.downedMechBoss1 ? 0 : 1)
                        + (NPC.downedMechBoss2 ? 0 : 1) + (NPC.downedMechBoss3 ? 0 : 1)
                        + (NPC.downedPlantBoss ? 0 : 1) + (NPC.downedGolemBoss ? 0 : 1)
                        + (NPC.downedMoonlord ? 0 : 1)
                        + ((bool)calamityMod.Call("GetBossDowned", "providence") ? 1 : 0)
                        + ((bool)calamityMod.Call("GetBossDowned", "devourerofgods") ? 1 : 0)
                        + ((bool)calamityMod.Call("GetBossDowned", "yharon") ? 1 : 0)
                        + ((bool)calamityMod.Call("GetBossDowned", "supremecalamitas") ? 1 : 0);
                }
                else if (item.type == calamityMod.ItemType("BlossomFlux"))
                {
                    item.damage = item.damage + (NPC.downedGolemBoss ? 0 : 1)
                        + (NPC.downedMoonlord ? 0 : 1)
                        + ((bool)calamityMod.Call("GetBossDowned", "providence") ? 1 : 0)
                        + ((bool)calamityMod.Call("GetBossDowned", "devourerofgods") ? 1 : 0)
                        + ((bool)calamityMod.Call("GetBossDowned", "yharon") ? 1 : 0)
                        + ((bool)calamityMod.Call("GetBossDowned", "supremecalamitas") ? 1 : 0);
                }
                else if (item.type == calamityMod.ItemType("Malachite"))
                {
                    item.damage = item.damage + (NPC.downedMoonlord ? 0 : 1)
                        + ((bool)calamityMod.Call("GetBossDowned", "providence") ? 1 : 0)
                        + ((bool)calamityMod.Call("GetBossDowned", "devourerofgods") ? 1 : 0)
                        + ((bool)calamityMod.Call("GetBossDowned", "yharon") ? 1 : 0)
                        + ((bool)calamityMod.Call("GetBossDowned", "supremecalamitas") ? 1 : 0);
                }
                else if (item.type == calamityMod.ItemType("AegisBlade"))
                {
                    item.damage = item.damage + (NPC.downedMoonlord ? 0 : 1)
                        + ((bool)calamityMod.Call("GetBossDowned", "providence") ? 1 : 0)
                        + ((bool)calamityMod.Call("GetBossDowned", "devourerofgods") ? 1 : 0)
                        + ((bool)calamityMod.Call("GetBossDowned", "yharon") ? 1 : 0)
                        + ((bool)calamityMod.Call("GetBossDowned", "supremecalamitas") ? 1 : 0);
                }
                else if (item.type == calamityMod.ItemType("BrinyBaron"))
                {
                    item.damage = item.damage + (NPC.downedMoonlord ? 0 : 1)
                        + ((bool)calamityMod.Call("GetBossDowned", "providence") ? 1 : 0)
                        + ((bool)calamityMod.Call("GetBossDowned", "devourerofgods") ? 1 : 0)
                        + ((bool)calamityMod.Call("GetBossDowned", "yharon") ? 1 : 0)
                        + ((bool)calamityMod.Call("GetBossDowned", "supremecalamitas") ? 1 : 0);
                }
                else if (item.type == calamityMod.ItemType("Vesuvius"))
                {
                    item.damage = item.damage + (NPC.downedMoonlord ? 0 : 1)
                        + ((bool)calamityMod.Call("GetBossDowned", "providence") ? 1 : 0)
                        + ((bool)calamityMod.Call("GetBossDowned", "devourerofgods") ? 1 : 0)
                        + ((bool)calamityMod.Call("GetBossDowned", "yharon") ? 1 : 0)
                        + ((bool)calamityMod.Call("GetBossDowned", "supremecalamitas") ? 1 : 0);
                }
                else if (item.type == calamityMod.ItemType("ElementalBlaster"))
                {
                    item.damage = item.damage + 1;
                }
            }
        }*/

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

            /*
			var rule = itemLoot.DefineConditionalDropSet(() => !CalValEXConfig.Instance.DisableVanityDrops);
            var rule2 = itemLoot.DefineConditionalDropSet(() => !CalValEXConfig.Instance.ConfigBossBlocks);
            var rule3 = itemLoot.DefineConditionalDropSet(() => DownedBossSystem.downedProvidence);
            var rule4 = itemLoot.DefineConditionalDropSet(() => !CalValEXConfig.Instance.ConfigBossBlocks && DownedBossSystem.downedYharon);
            var rule5 = itemLoot.DefineConditionalDropSet(() => !CalValEXConfig.Instance.ConfigBossBlocks && DownedBossSystem.downedDoG);
            var rule6 = itemLoot.DefineConditionalDropSet(() => CalValEX.month == 6 && CalValEX.day == 1);
            var rule7 = itemLoot.DefineConditionalDropSet(() => DownedBossSystem.downedThanatos);
            var rule8 = itemLoot.DefineConditionalDropSet(() => DownedBossSystem.downedArtemisAndApollo);
            var rule9 = itemLoot.DefineConditionalDropSet(() => DownedBossSystem.downedAres);
            var rule10 = itemLoot.DefineConditionalDropSet(() => DownedBossSystem.downedCalamitas || NPC.downedPlantBoss);
            var rule11 = itemLoot.DefineConditionalDropSet(() => NPC.downedAncientCultist);
            var rule12 = itemLoot.DefineConditionalDropSet(() => NPC.downedMechBossAny);

            #region bags
            if (item.type == ModContent.ItemType<StarterBag>())
			{
				rule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<C>()));
			}
			else if (item.type == ModContent.ItemType<DesertScourgeBag>())
			{
				rule.OnSuccess(new CommonDrop(ModContent.ItemType<DesertMedallion>(), 10, chanceNumerator: 3));
				rule.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<DriedLocket>(), 5));
				rule.OnSuccess(new CommonDrop(ModContent.ItemType<SlightlyMoistbutalsoSlightlyDryLocket>(), 100, chanceNumerator: 7));
			}
			else if (item.type == ModContent.ItemType<CrabulonBag>())
			{
				rule.OnSuccess(new CommonDrop(ModContent.ItemType<ClawShroom>(), 10, chanceNumerator: 3));
			}
			else if (item.type == ModContent.ItemType<HiveMindBag>())
			{
				rule.OnSuccess(new CommonDrop(ModContent.ItemType<RottenKey>(), 10, chanceNumerator: 3));
			}
			else if (item.type == ModContent.ItemType<PerforatorBag>())
			{
				rule.OnSuccess(new CommonDrop(ModContent.ItemType<MeatyWormTumor>(), 10, chanceNumerator: 3));
				rule.OnSuccess(new OneFromOptionsNotScaledWithLuckDropRule(100, 40, ModContent.ItemType<SmallWorm>(), ModContent.ItemType<MidWorm>(), ModContent.ItemType<BigWorm>()));
			}
			else if (item.type == ModContent.ItemType<SlimeGodBag>())
			{
				rule2.OnSuccess(ItemDropRule.Common(ModContent.ItemType<CalamityMod.Items.Placeables.FurnitureStatigel.StatigelBlock>(), 1, 205, 335));
				rule.OnSuccess(new CommonDrop(ModContent.ItemType<SlimeDeitysSoul>(), 10, chanceNumerator: 3));
			}
			else if (item.type == ModContent.ItemType<CryogenBag>())
			{
				rule.OnSuccess(new CommonDrop(ModContent.ItemType<CoolShades>(), 10, chanceNumerator: 3));
			}
			else if (item.type == ModContent.ItemType<AquaticScourgeBag>())
			{
				rule.OnSuccess(new CommonDrop(ModContent.ItemType<MoistLocket>(), 10, chanceNumerator: 3));
			}
			else if (item.type == ModContent.ItemType<BrimstoneWaifuBag>())
			{
				rule2.OnSuccess(ItemDropRule.Common(ModContent.ItemType<CalamityMod.Items.Placeables.BrimstoneSlag>(), 1, 205, 335));
				rule.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<BrimmyBody>(), 5));
				rule.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<BrimmySpirit>(), 5));
				rule.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<RareBrimtulip>(), 5));
				rule.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<FoilSpoon>(), 20));
			}
			else if (item.type == ModContent.ItemType<CalamitasBag>())
			{
				IItemDropRule demonshade = ItemDropRule.Common(ModContent.ItemType<DemonshadeHood>());
				demonshade.OnSuccess(ItemDropRule.Common(ModContent.ItemType<DemonshadeRobe>()));
				demonshade.OnSuccess(ItemDropRule.Common(ModContent.ItemType<DemonshadePants>()));

				rule.OnSuccess(new CommonDrop(ModContent.ItemType<Calacirclet>(), 10, chanceNumerator: 3));
				rule.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<AncientAuricTeslaHelm>(), 1000));
				rule3.OnSuccess(demonshade);
			}
			else if (item.type == ModContent.ItemType<LeviathanBag>())
			{
				rule.OnSuccess(new CommonDrop(ModContent.ItemType<AquaticMonolith>(), 100, chanceNumerator: 15));
				rule.OnSuccess(new CommonDrop(ModContent.ItemType<LeviWings>(), 10, chanceNumerator: 3));
				rule.OnSuccess(new CommonDrop(ModContent.ItemType<LeviathanEgg>(), 10, chanceNumerator: 3));
				rule.OnSuccess(new CommonDrop(ModContent.ItemType<FoilAtlantis>(), 10, chanceNumerator: 3));
				rule.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<StrangeMusicNote>(), 100));
			}
			else if (item.type == ModContent.ItemType<AstrumAureusBag>())
			{
				rule.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<AstralInfectedIcosahedron>(), 5));
				rule.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<AureusShield>(), 5));
				rule.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<AncientAuricTeslaHelm>(), 1000));
			}
			else if (item.type == ModContent.ItemType<PlaguebringerGoliathBag>())
			{
				rule2.OnSuccess(ItemDropRule.Common(ModContent.ItemType<CalamityMod.Items.Placeables.FurniturePlagued.PlaguedContainmentBrick>(), 1, 205, 335));
				rule.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<AncientAuricTeslaHelm>(), 250));
				rule.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<InfectedController>(), 5));
				rule.OnSuccess(new CommonDrop(ModContent.ItemType<PlaguePack>(), 10, chanceNumerator: 3));
				rule.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<PlagueHiveWand>(), 3));
			}
			else if (item.type == ModContent.ItemType<RavagerBag>())
			{
				rule2.OnSuccess(ItemDropRule.Common(ModContent.ItemType<Necrostone>(), 1, 205, 335));
				rule.OnSuccess(new CommonDrop(ModContent.ItemType<SkullCluster>(), 10, chanceNumerator: 3));
				rule.OnSuccess(new CommonDrop(ModContent.ItemType<ScavaHook>(), 100, chanceNumerator: 7));
				rule.OnSuccess(new CommonDrop(ModContent.ItemType<RavaHook>(), 10, chanceNumerator: 3));
				rule.OnSuccess(new CommonDrop(ModContent.ItemType<SkullBalloon>(), 10, chanceNumerator: 3));
				rule.OnSuccess(new CommonDrop(ModContent.ItemType<StonePile>(), 10, chanceNumerator: 3));
			}
			else if (item.type == ModContent.ItemType<AstrumDeusBag>())
			{
				rule.OnSuccess(new CommonDrop(ModContent.ItemType<Geminga>(), 10, chanceNumerator: 3));
				rule.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<AstBandana>(), 5));
			}
			else if (item.type == ModContent.ItemType<DragonfollyBag>())
			{
				rule4.OnSuccess(ItemDropRule.Common(ModContent.ItemType<CalamityMod.Items.Placeables.FurnitureSilva.SilvaCrystal>(), 1, 205, 335));
				rule.OnSuccess(ItemDropRule.OneFromOptions(1, ModContent.ItemType<FollyWings>(), ModContent.ItemType<Birbhat>(), ModContent.ItemType<DocilePheromones>()));
				rule.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<AncientAuricTeslaHelm>(), 200));
			}
			else if (item.type == ModContent.ItemType<ProvidenceBag>())
			{
				rule2.OnSuccess(ItemDropRule.Common(ModContent.ItemType<CalamityMod.Items.Placeables.FurnitureProfaned.ProfanedRock>(), 1, 205, 335));
				rule.OnSuccess(new CommonDrop(ModContent.ItemType<ProfanedHeart>(), 10, chanceNumerator: 3));
				rule.OnSuccess(new CommonDrop(ModContent.ItemType<ProviCrystal>(), 10, chanceNumerator: 3));
			}
			else if (item.type == ModContent.ItemType<StormWeaverBag>())
			{
				rule5.OnSuccess(ItemDropRule.Common(ModContent.ItemType<CalamityMod.Items.Placeables.FurnitureOtherworldly.OtherworldlyStone>(), 1, 205, 335));
				rule.OnSuccess(ItemDropRule.OneFromOptionsNotScalingWithLuckWithX(10, 3, ModContent.ItemType<StormMedal>(), ModContent.ItemType<ArmoredScrap>()));
				rule.OnSuccess(new CommonDrop(ModContent.ItemType<StormBandana>(), 10, chanceNumerator: 3));
				rule.OnSuccess(new CommonDrop(ModContent.ItemType<AncientAuricTeslaHelm>(), 1000, chanceNumerator: 7));
			}
			else if (item.type == ModContent.ItemType<CeaselessVoidBag>())
			{
				rule5.OnSuccess(ItemDropRule.Common(ModContent.ItemType<CalamityMod.Items.Placeables.FurnitureOtherworldly.OtherworldlyStone>(), 1, 205, 335));
				rule.OnSuccess(new CommonDrop(ModContent.ItemType<MirrorMatter>(), 10, chanceNumerator: 3));
				rule.OnSuccess(new CommonDrop(ModContent.ItemType<VoidWings>(), 10, chanceNumerator: 3));
				rule.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<OldVoidWings>(), 20));
				rule.OnSuccess(new CommonDrop(ModContent.ItemType<AncientAuricTeslaHelm>(), 1000, chanceNumerator: 7));
			}
			else if (item.type == ModContent.ItemType<SignusBag>())
			{
				rule5.OnSuccess(ItemDropRule.Common(ModContent.ItemType<CalamityMod.Items.Placeables.FurnitureOtherworldly.OtherworldlyStone>(), 1, 205, 335));
				rule.OnSuccess(new CommonDrop(ModContent.ItemType<ShadowCloth>(), 10, chanceNumerator: 3));
				rule.OnSuccess(ItemDropRule.OneFromOptions(1, ModContent.ItemType<SignusEmblem>(), ModContent.ItemType<SignusNether>(), ModContent.ItemType<SignusBalloon>(), ModContent.ItemType<Items.Equips.Capes.SigCape>()));
				rule.OnSuccess(new CommonDrop(ModContent.ItemType<AncientAuricTeslaHelm>(), 1000, chanceNumerator: 7));
			}
			else if (item.type == ModContent.ItemType<PolterghastBag>())
			{
				rule2.OnSuccess(new OneFromRulesRule(1, ItemDropRule.Common(ModContent.ItemType<CalamityMod.Items.Placeables.FurnitureStratus.StratusBricks>(), 1, 205, 335), ItemDropRule.Common(ModContent.ItemType<PhantowaxBlock>(), 1, 205, 335)));
				rule.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<Polterhook>(), 10));
                rule.OnSuccess(new CommonDrop(ModContent.ItemType<ZygoteinaBucket>(), 10, chanceNumerator: 3));
            }
			else if (item.type == ModContent.ItemType<OldDukeBag>())
			{
				rule.OnSuccess(new CommonDrop(ModContent.ItemType<OldWings>(), 10, chanceNumerator: 3));
				rule.OnSuccess(new CommonDrop(ModContent.ItemType<CorrodedCleaver>(), 10, chanceNumerator: 3));
				rule.OnSuccess(new CommonDrop(ModContent.ItemType<CharredChopper>(), 100, chanceNumerator: 7));
			}
			else if (item.type == ModContent.ItemType<DevourerofGodsBag>())
			{
				rule.OnSuccess(new CommonDrop(ModContent.ItemType<CosmicWormScarf>(), 10, chanceNumerator: 3));
				rule.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<CosmicRapture>(), 5));
				rule.OnSuccess(new CommonDrop(ModContent.ItemType<RapturedWormScarf>(), 100, chanceNumerator: 7));
				rule.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<AncientAuricTeslaHelm>(), 100));
			}
			else if (item.type == ModContent.ItemType<YharonBag>())
			{
				IItemDropRule demonshade = ItemDropRule.NotScalingWithLuck(ModContent.ItemType<DemonshadeHood>(), 10);
				demonshade.OnSuccess(ItemDropRule.Common(ModContent.ItemType<DemonshadeRobe>()));
				demonshade.OnSuccess(ItemDropRule.Common(ModContent.ItemType<DemonshadePants>()));

				rule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<Termipebbles>(), 1, 5, 8));
				rule.OnSuccess(new CommonDrop(ModContent.ItemType<JunglePhoenixWings>(), 10, chanceNumerator: 3));
				rule6.OnSuccess(new CommonDrop(ModContent.ItemType<YharonsAnklet>(), 10, chanceNumerator: 3));
				rule.OnSuccess(new CommonDrop(ModContent.ItemType<NuggetinaBiscuit>(), 10, chanceNumerator: 3));
				rule.OnSuccess(new CommonDrop(ModContent.ItemType<YharonShackle>(), 10, chanceNumerator: 3));
				rule.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<AncientAuricTeslaHelm>(), 20));
				rule.OnSuccess(demonshade);
			}
			else if (item.type == ModContent.ItemType<DraedonBag>())
			{
				IItemDropRule draedon = ItemDropRule.NotScalingWithLuck(ModContent.ItemType<DraedonBody>(), 7);
				draedon.OnSuccess(ItemDropRule.Common(ModContent.ItemType<DraedonLegs>()));
				IItemDropRule balloons = ItemDropRule.NotScalingWithLuck(ModContent.ItemType<ApolloBalloonSmall>(), 2);
				balloons.OnSuccess(ItemDropRule.Common(ModContent.ItemType<ArtemisBalloonSmall>()));

				rule2.OnSuccess(ItemDropRule.Common(ModContent.ItemType<CalamityMod.Items.Placeables.FurnitureExo.ExoPlating>(), 1, 205, 335));

				rule7.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<XMLightningHook>(), 2));
				rule7.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<Items.Pets.ExoMechs.GunmetalRemote>(), 2));

				rule8.OnSuccess(balloons);
				rule8.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<Items.Pets.ExoMechs.GeminiMarkImplants>(), 2));

				rule9.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<Items.Equips.Shirts.AresChestplate.AresChestplate>(), 2));
				rule9.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<Items.Pets.ExoMechs.OminousCore>(), 2));

				rule.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<AncientAuricTeslaHelm>(), 10));
				rule.OnSuccess(draedon);
			}
			else if (item.type == ModContent.ItemType<SupremeCalamitasCoffer>())
			{
				rule.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<AncientAuricTeslaHelm>(), 10));
				rule.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<GruelingMask>(), 3));
			}

			if (ModLoader.TryGetMod("CatalystMod", out Mod catalyst))
			{
				if (item.type == catalyst.Find<ModItem>("AstrageldonBag").Type)
					rule.OnSuccess(new CommonDrop(ModContent.ItemType<SpaceJunk>(), 10, chanceNumerator: 3));
			}
			#endregion

			#region crates
            if (item.type == ModContent.ItemType<CalamityMod.Items.Fishing.SulphurCatches.AbyssalCrate>())
			{
                rule.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<AcidGun>(), 100));
                rule.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<CursedLockpick>(), 50));
                rule.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<SulphurColumn>(), 20, 5, 7));
                rule.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<SulphurGeyser>(), 20, 2, 3));
                rule.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<SulphurousCactus>(), 20, 1, 3));
                rule.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<SulphurousPlanter>(), 25));
                rule10.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<InkyPollution>(), 50));
                rule11.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<EidolonTree>(), 40));
                rule11.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<NuclearFumes>(), 10, 2, 11));
                rule12.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<BelchingCoral>(), 20));
            }
            else if (item.type == ModContent.ItemType<CalamityMod.Items.Fishing.AstralCatches.AstralCrate>())
            {
                rule.OnSuccess(new CommonDrop(ModContent.ItemType<MonolithPot>(), 100, 1, 1, 3));
                rule11.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<NetherTree>(), 20));
            }
            else if (item.type == ModContent.ItemType<CalamityMod.Items.Fishing.SunkenSeaCatches.SunkenCrate>())
            {
                rule.OnSuccess(new CommonDrop(ModContent.ItemType<SSCoral>(), 100, 1, 1, 3));
                rule.OnSuccess(new CommonDrop(ModContent.ItemType<Anemone>(), 100, 1, 1, 3));
                rule.OnSuccess(new CommonDrop(ModContent.ItemType<TableCoral>(), 100, 1, 1, 3));
                rule.OnSuccess(new CommonDrop(ModContent.ItemType<FanCoral>(), 100, 1, 1, 3));
                rule.OnSuccess(new CommonDrop(ModContent.ItemType<BrainCoral>(), 100, 1, 1, 3));
                rule.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<SeaCrown>(), 100));
                rule.OnSuccess(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<SunkenLamp>(), 40));
            }
			#endregion

			/*#region spaghetti starter
			if (item.type != ModContent.ItemType<StarterBag>())
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
            names[27].OnSuccess(brimmy);
            #endregion*/
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

            if (!CalValEXConfig.Instance.DisableVanityDrops && item.type == CalValEX.CalamityItem("StarterBag") && player.whoAmI == Main.myPlayer && CalValEX.AprilFoolWeek)
			{
				NPC.NewNPC(player.GetSource_ReleaseEntity(), (int)player.Center.X, (int)player.Center.Y, ModContent.NPCType<AprilFools.Jharim.Jharim>(), 0, 0f, 0f, 0f, 0f, 255);
			}
		}

        [JITWhenModsEnabled("CalamityMod")]
        public override string IsArmorSet(Item head, Item body, Item legs)
        {
            if (!CalValEX.CalamityActive)
                return "";

            if (head.type == CalValEX.CalamityItem("WulfrumHat") &&
                body.type == CalValEX.CalamityItem("WulfrumJacket") &&
                legs.type == CalValEX.CalamityItem("WulfrumOveralls"))
            {
                return "Wulfrumset";
            }

            return "";
        }

        public override void UpdateArmorSet(Player player, string set)
        {
            if (player.HasBuff(ModContent.BuffType<Buffs.LightPets.PylonBuff>()) &&
                player.HasBuff(ModContent.BuffType<WulfrumArmy>()) &&
                player.HasBuff(ModContent.BuffType<TractorMount>()) && set == "Wulfrumset")
            {
                CalValEX.WulfrumsetReal = true;
            }
            else
            {
                CalValEX.WulfrumsetReal = false;
            }
        }
    }
}
