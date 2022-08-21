using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using CalamityMod.Items;
using CalamityMod.Items.Fishing;
using CalamityMod.Items.Materials;
using CalamityMod.Items.Placeables;
using CalamityMod.Items.Armor;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Accessories.Wings;
using CalamityMod.Items.Accessories.Vanity;
using CalamityMod.Items.Placeables.DraedonStructures;
using CalamityMod.Items.Placeables.FurnitureMonolith;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.Items.Weapons.Rogue;
using CalamityMod.Items.Weapons.Summon;
using CalamityMod.Items.Weapons.Ranged;
using CalamityMod.Items.Weapons.Magic;
using CalamityMod.Tiles.Furniture.CraftingStations;
using CalValEX.AprilFools;
using CalValEX.Items;
using CalValEX.Items.Critters;
using CalValEX.Items.Dyes;
using CalValEX.Items.Equips.Backs;
using CalValEX.Items.Equips.Balloons;
using CalValEX.Items.Equips.Capes;
using CalValEX.Items.Equips.Hats;
using CalValEX.Items.Equips.Legs;
using CalValEX.Items.Equips.Scarves;
using CalValEX.Items.Equips.Shields;
using CalValEX.Items.Equips.Shirts;
using CalValEX.Items.Equips.Transformations;
using CalValEX.Items.Equips.Wings;
using CalValEX.Items.Hooks;
using CalValEX.Items.LightPets;
using CalValEX.Items.Mounts;
using CalValEX.Items.Mounts.Ground;
using CalValEX.Items.Mounts.Morshu;
using CalValEX.Items.Mounts.LimitedFlight;
using CalValEX.Items.Mounts.InfiniteFlight;
using CalValEX.Items.Pets;
using CalValEX.Items.Pets.Elementals;
using CalValEX.Items.Pets.ExoMechs;
using CalValEX.Items.Pets.Scuttlers;
using CalValEX.Items.Plushies;
using CalValEX.Items.Tiles.Blocks;
using CalValEX.Items.Tiles.Blocks.Astral;
using CalValEX.Items.Tiles.Plushies;
using CalValEX.Items.Tiles;
using CalValEX.Items.Tiles.Blueprints;
using CalValEX.Items.Tiles.Cages;
using CalValEX.Items.Tiles.FurnitureSets.Astral;
using CalValEX.Items.Tiles.FurnitureSets.Auric;
using CalValEX.Items.Tiles.FurnitureSets.Bloodstone;
using CalValEX.Items.Tiles.FurnitureSets.Necrotic;
using CalValEX.Items.Tiles.FurnitureSets.Phantowax;
using CalValEX.Items.Tiles.Monoliths;
using CalValEX.Items.Tiles.Statues;
using CalValEX.Items.Walls;
using CalValEX.Tiles.MiscFurniture;
using CalValEX.Tiles.FurnitureSets.Auric;
using CalValEX.Tiles.Plants;
using System.Collections.Generic;
using System.Linq;
using static Terraria.ModLoader.ModContent;


namespace CalValEX
{
	public class CalValEXRecipes : ModSystem
	{

		public override void AddRecipes()
		{
			//April Fools
			if (CalValEX.AprilFoolWeek)
			{
				{
					Recipe recipe = Recipe.Create(ItemType<JharimHead>());
					recipe.AddIngredient(ItemID.GoldOre);
					recipe.AddTile(TileID.WorkBenches);
					recipe.Register();
				}
				{
					Recipe recipe = Recipe.Create(ItemType<AprilFools.Meldosaurus.MeldosaurusRelic>());
					recipe.AddIngredient(ModContent.ItemType<AprilFools.Meldosaurus.MeldosaurusTrophy>());
					recipe.AddIngredient(ModContent.ItemType<PearlShard>(), 10);
					recipe.AddTile(TileID.Bookcases);
					recipe.Register();
				}
			}
			//Misc
			{
				Recipe recipe = Recipe.Create(ItemType<Items.BleachBall>());
				recipe.AddIngredient(ItemType<CalamityMod.Items.BleachBall>());
				recipe.AddIngredient(ItemID.BeachBall);
				recipe.AddTile(TileID.MythrilAnvil);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<SparrowMeat>());
				recipe.AddIngredient(ItemType<ExtraFluffyFeather>());
				recipe.AddIngredient(ItemType<JunglePhoenixWings>());
				recipe.AddIngredient(ItemID.ChickenNugget);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<OldCassette>());
				recipe.AddIngredient(ItemID.Diamond, 5);
				recipe.AddIngredient(ItemID.ShadowScale, 5);
				recipe.AddTile(TileID.Anvils);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<OldCassette>());
				recipe.AddIngredient(ItemID.Diamond, 5);
				recipe.AddIngredient(ItemID.TissueSample, 5);
				recipe.AddTile(TileID.Anvils);
				recipe.Register();
			}
			//Critters
			{
				Recipe recipe = Recipe.Create(ItemType<XerocodileItem>());
				recipe.AddIngredient(ItemType<CalamityMod.Items.Fishing.Xerocodile>(), 10);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			//Dyes
			{
				Recipe recipe = Recipe.Create(ItemType<DraedonHologramDye>());
				recipe.AddIngredient(ItemID.BottledWater);
				recipe.AddRecipeGroup(RecipeGroupID.IronBar);
				recipe.AddTile(TileID.DyeVat);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<BlightedAstralDye>());
				recipe.AddIngredient(ItemID.BottledWater);
				recipe.AddIngredient(ItemType<XenoSolution>());
				recipe.AddTile(TileID.DyeVat);
				recipe.Register();
			}
			//Backpacks
			{
				Recipe recipe = Recipe.Create(ItemType<BackpackServer>());
				recipe.AddIngredient(ItemType<DubiousPlating>(), 4);
				recipe.AddIngredient(ItemType<MysteriousCircuitry>(), 4);
				recipe.AddTile(TileID.Anvils);
				recipe.Register();
			}
			//Balloons
			{
				Recipe recipe = Recipe.Create(ItemType<ApolloBalloon>());
				recipe.AddIngredient(ItemType<ApolloBalloonSmall>());
				recipe.AddIngredient(ItemType<ExoPrism>(), 8);
				recipe.AddTile(TileType<DraedonsForge>());
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<ArtemisBalloon>());
				recipe.AddIngredient(ItemType<ArtemisBalloonSmall>());
				recipe.AddIngredient(ItemType<ExoPrism>(), 8);
				recipe.AddTile(TileType<DraedonsForge>());
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<ExoTwinsBalloon>());
				recipe.AddIngredient(ItemType<ApolloBalloon>());
				recipe.AddIngredient(ItemType<ArtemisBalloon>());
				recipe.AddIngredient(ItemType<MiracleMatter>(), 1);
				recipe.AddTile(TileType<DraedonsForge>());
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<BoB2>());
				recipe.AddIngredient(ItemType<ChaosBalloon>());
				recipe.AddIngredient(ItemType<Mirballoon>());
				recipe.AddIngredient(ItemType<BoxBalloon>());
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<AuricBalloon>());
				recipe.AddIngredient(159);
				recipe.AddIngredient(ItemType<AuricBar>(), 10);
				recipe.AddTile(TileType<CosmicAnvil>());
				recipe.Register();
			}
			//Capes
			{
				Recipe recipe = Recipe.Create(ItemType<YharimCape>());
				recipe.AddIngredient(ItemID.MysteriousCape);
				recipe.AddIngredient(ItemID.CrimsonCloak);
				recipe.AddIngredient(ItemID.WinterCape);
				recipe.AddIngredient(ItemID.RedCape);
				recipe.AddIngredient(ItemType<AuricBar>(), 10);
				recipe.AddTile(TileID.Loom);
				recipe.Register();
			}
			//Hats
			{
				Recipe recipe = Recipe.Create(ItemType<Aestheticrown>());
				recipe.AddIngredient(ItemType<AerialiteBar>(), 2);
				recipe.AddIngredient(ItemType<SeaPrism>(), 4);
				recipe.AddIngredient((ItemID.Glass), 7);
				recipe.AddIngredient((ItemID.Gel), 5);
				recipe.AddIngredient((ItemID.MeteoriteBar), 3);
				recipe.AddIngredient((ItemID.HellstoneBar), 3);
				recipe.AddIngredient((ItemID.FallenStar), 1);
				recipe.AddTile(TileID.Anvils);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<BloodyMaryHat>());
				recipe.AddIngredient(ItemType<BloodstoneCore>(), 3);
				recipe.AddIngredient((ItemID.TheBrideHat), 1);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<FallenPaladinsHelmet>());
				recipe.AddIngredient(ItemType<AshesofCalamity>());
				recipe.AddIngredient(ItemType<ScoriaBar>());
				recipe.AddIngredient(ItemType<CoreofChaos>());
				recipe.AddTile(TileID.MythrilAnvil);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<TerminalMask>());
				recipe.AddIngredient(ItemType<Termipebbles>(), 5);
				recipe.AddIngredient(ItemType<Rock>());
				recipe.AddTile(TileType<DraedonsForge>());
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<TrueCosmicCone>());
				recipe.AddIngredient(ItemType<CosmicCone>());
				recipe.AddIngredient(ItemType<CosmicCone>());
				recipe.AddIngredient(ItemType<CosmiliteBar>());
				recipe.AddTile(TileType<CosmicAnvil>());
				recipe.Register();
			}
			/*{
				Recipe recipe = Recipe.Create(ItemType<Items.Equips.Hats.Draedon.DraedonHelmet>());
				recipe.AddIngredient(ItemType<DubiousPlating>(), 6);
				recipe.AddIngredient(ItemType<MysteriousCircuitry>(), 6);
				recipe.AddTile(TileID.Anvils);
				recipe.Register();
			}
			//Legs
			{
				Recipe recipe = Recipe.Create(ItemType<Items.Equips.Legs.Draedon.DraedonLeggings>());
				recipe.AddIngredient(ItemType<DubiousPlating>(), 8);
				recipe.AddIngredient(ItemType<MysteriousCircuitry>(), 8);
				recipe.AddTile(TileID.Anvils);
				recipe.Register();
			}*/
			{
				Recipe recipe = Recipe.Create(ItemType<FallenPaladinsGreaves>());
				recipe.AddIngredient(ItemType<AshesofCalamity>());
				recipe.AddIngredient(ItemType<ScoriaBar>(), 2);
				recipe.AddIngredient(ItemType<CoreofChaos>());
				recipe.AddTile(TileID.MythrilAnvil);
				recipe.Register();
			}
			//Scarves
			{
				Recipe recipe = Recipe.Create(ItemType<UniversalWormScarf>());
				recipe.AddIngredient(ItemType<RapturedWormScarf>());
				recipe.AddIngredient(ItemType<CosmiliteBar>(), 20);
				recipe.AddTile(TileType<CosmicAnvil>());
				recipe.Register();
			}
			//Shirts
			{
				Recipe recipe = Recipe.Create(ItemType<BloodyMaryDress>());
				recipe.AddIngredient(ItemType<BloodstoneCore>(), 8);
				recipe.AddIngredient((ItemID.TheBrideDress), 1);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<FallenPaladinsPlateMail>());
				recipe.AddIngredient(ItemType<AshesofCalamity>(), 2);
				recipe.AddIngredient(ItemType<ScoriaBar>(), 2);
				recipe.AddIngredient(ItemType<CoreofChaos>());
				recipe.AddTile(TileID.MythrilAnvil);
				recipe.Register();
			}
			/*{
				Recipe recipe = Recipe.Create(ItemType<Items.Equips.Shirts.Draedon.DraedonChestplate>());
				recipe.AddIngredient(ItemType<DubiousPlating>(), 12);
				recipe.AddIngredient(ItemType<MysteriousCircuitry>(), 12);
				recipe.AddTile(TileID.Anvils);
				recipe.Register();
			}*/
			//Transformations
			{
				Recipe recipe = Recipe.Create(ItemType<ProtoRing>());
				recipe.AddIngredient(ItemType<DubiousPlating>(), 12);
				recipe.AddIngredient(ItemType<MysteriousCircuitry>(), 12);
				recipe.AddIngredient(ItemID.Wire, 200);
				recipe.AddTile(TileID.Anvils);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<Signus>());
				recipe.AddIngredient(ItemType<CalamityMod.Items.Armor.Vanity.SignusMask>());
				recipe.AddIngredient(ItemType<SigCape>());
				recipe.AddIngredient(ItemType<SignusEmblem>());
				recipe.AddIngredient(ItemType<SignusNether>());
				recipe.AddIngredient(ItemType<TwistingNether>(), 5);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			//Wings
			{
				Recipe recipe = Recipe.Create(ItemType<TerminalWings>());
				recipe.AddIngredient(ItemType<Termipebbles>(), 5);
				recipe.AddIngredient(ItemType<Rock>());
				recipe.AddTile(TileType<DraedonsForge>());
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<GodspeedBoosters>());
				recipe.AddIngredient(ItemType<PlaguePack>());
				recipe.AddIngredient(ItemType<CosmiliteBar>(), 5);
				recipe.AddTile(TileType<CosmicAnvil>());
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<WulfrumHelipack>());
				recipe.AddIngredient(ItemID.LuckyHorseshoe);
				recipe.AddIngredient(ItemType<EnergyCore>(), 3);
				recipe.AddIngredient(ItemType<WulfrumMetalScrap>(), 30);
				recipe.AddRecipeGroup(RecipeGroupID.IronBar, 12);
				recipe.AddTile(TileID.Anvils);
				recipe.Register();
			}
			//Light pets
			{
				Recipe recipe = Recipe.Create(ItemType<DarksunSigil>());
				recipe.AddIngredient(ItemType<CoreofVanity>());
				recipe.AddIngredient(ItemType<DarksunFragment>(), 20);
				recipe.AddTile(TileType<CosmicAnvil>());
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<DivineFly>());
				recipe.AddIngredient(ItemType<FROM>());
				recipe.AddIngredient(ItemType<VaporoflyItem>());
				recipe.AddIngredient(ItemType<NuclearFumes>(), 10);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<PhantominaJar>());
				recipe.AddIngredient(ItemID.WispinaBottle);
				recipe.AddIngredient(ItemType<RuinousSoul>(), 5);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<SuperstitiousJewel>());
				recipe.AddIngredient(ItemType<DarksunSigil>());
				recipe.AddIngredient(ItemType<HolyTorch>());
				recipe.AddIngredient(ItemType<PhantominaJar>());
				recipe.AddIngredient(ItemType<CoolShades>());
				recipe.AddIngredient(ItemType<ShuttleBalloon>());
				recipe.AddIngredient(ItemType<AscendantSpiritEssence>(), 3);
				recipe.AddTile(TileType<DraedonsForge>());
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<CoreofVanity>());
				recipe.AddIngredient(ItemType<EssenceofDisorder>());
				recipe.AddIngredient(ItemType<EssenceofYeet>());
				recipe.AddIngredient(ItemType<CoreofCalamity>(), 1);
				recipe.AddTile(TileID.MythrilAnvil);
				recipe.Register();
			}
			//Mounts
			{
				Recipe recipe = Recipe.Create(ItemType<AuricCarKey>());
				recipe.AddIngredient(ItemType<SilvaJeepItem>());
				recipe.AddIngredient(ItemType<GodRiderItem>());
				recipe.AddIngredient(ItemType<BloodstoneCarriageItem>());
				recipe.AddIngredient(ItemType<ProfanedCycleItem>());
				recipe.AddIngredient(ItemType<AuricBar>(), 5);
				recipe.AddTile(TileType<CosmicAnvil>());
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<BloodstoneCarriageItem>());
				recipe.AddIngredient(ItemType<ChiseledBloodstone>(), 50);
				recipe.AddIngredient(ItemType<BloodstoneCore>(), 10);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<GodRiderItem>());
				recipe.AddIngredient(ItemType<CosmiliteBar>(), 10);
				recipe.AddTile(TileType<CosmicAnvil>());
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<ProfanedCycleItem>());
				recipe.AddIngredient(ItemType<ProfanedFrame>());
				recipe.AddIngredient(ItemType<ProfanedBattery>());
				recipe.AddIngredient(ItemType<ProfanedWheels>());
				recipe.AddIngredient(ItemType<DivineGeode>(), 5);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<SilvaJeepItem>());
				recipe.AddIngredient(ItemType<EffulgentFeather>(), 20);
				recipe.AddIngredient(ItemType<Tenebris>(), 10);
				recipe.AddIngredient(ItemID.GoldBar, 10);
				recipe.AddTile(TileType<CosmicAnvil>());
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<SilvaJeepItem>());
				recipe.AddIngredient(ItemType<EffulgentFeather>(), 20);
				recipe.AddIngredient(ItemType<Tenebris>(), 10);
				recipe.AddIngredient(ItemID.PlatinumBar, 10);
				recipe.AddTile(TileType<CosmicAnvil>());
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<ShadowShedding>());
				recipe.AddIngredient(ItemType<CalamityMod.Items.Placeables.Furniture.CorruptionEffigy>(), 1);
				recipe.AddIngredient(ItemType<RottenMatter>(), 20);
				recipe.AddIngredient(ItemID.SoulofFlight, 20);
				recipe.AddTile(TileID.MythrilAnvil);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<PopUpShop>());
				recipe.AddIngredient(ItemType<ThiefsDime>());
				recipe.AddIngredient(ItemID.LargeRuby);
				recipe.AddIngredient(ItemID.RopeCoil, 5);
				recipe.AddIngredient(ItemID.Bomb, 10);
				recipe.AddIngredient(ItemID.Gel, 20);
				recipe.AddTile(TileID.MythrilAnvil);
				recipe.Register();
			}
			//Pets
			{
				Recipe recipe = Recipe.Create(ItemType<AuricBottle>());
				recipe.AddIngredient(ItemType<InkyArtifact>());
				recipe.AddIngredient(ItemType<Exoblade>());
				recipe.AddIngredient(ItemType<SubsumingVortex>());
				recipe.AddIngredient(ItemType<VividClarity>());
				recipe.AddIngredient(ItemType<HeavenlyGale>());
				recipe.AddIngredient(ItemType<CosmicImmaterializer>());
				recipe.AddIngredient(ItemType<Photoviscerator>());
				recipe.AddIngredient(ItemType<Celestus>());
				recipe.AddIngredient(ItemType<MagnomalyCannon>());
				recipe.AddIngredient(ItemType<Supernova>());
				recipe.AddIngredient(ItemType<AuricBar>(), 50);
				recipe.AddTile(TileType<DraedonsForge>());
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<InkyArtifact>());
				recipe.AddIngredient(ItemType<InkyPollution>());
				recipe.AddIngredient(ItemType<SoulEdge>());
				recipe.AddIngredient(ItemType<EidolicWail>());
				recipe.AddIngredient(ItemType<CalamarisLament>());
				recipe.AddIngredient(ItemType<Valediction>());
				recipe.AddIngredient(ItemType<Lumenyl>(), 3996);
				recipe.AddIngredient(ItemType<DepthCells>(), 3996);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<RottingCalamitousArtifact>());
				recipe.AddIngredient(ItemType<AshesofCalamity>(), 15);
				recipe.AddIngredient(ItemType<CalamityMod.Items.Placeables.Plates.Cinderplate>(), 20);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<DustyBadge>());
				recipe.AddIngredient(ItemType<GrandScale>(), 1);
				recipe.AddIngredient(ItemID.Bass, 1);
				recipe.AddTile(TileType<BelchingCoralPlaced>());
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<BleuBlob>());
				recipe.AddIngredient(ItemType<ShadowCloth>());
				recipe.AddIngredient(ItemType<SlimeDeitysSoul>());
				recipe.AddIngredient(ItemType<TwistingNether>(), 20);
				recipe.AddIngredient(ItemType<PurifiedGel>(), 20);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<ExtraFluffyFeatherClump>());
				recipe.AddIngredient(ItemType<SparrowMeat>());
				recipe.AddIngredient(ItemType<HolyCollider>());
				recipe.AddIngredient(ItemType<BansheeHook>());
				recipe.AddIngredient(ItemType<CosmicDischarge>());
				recipe.AddIngredient(ItemType<SoulEdge>());
				recipe.AddIngredient(ItemType<StreamGouge>());
				recipe.AddTile(TileType<CosmicAnvil>());
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<FROM>());
				recipe.AddIngredient(ItemType<BubbleGum>());
				recipe.AddIngredient(ItemType<PlagueFrogItem>());
				recipe.AddIngredient(ItemType<InfectedArmorPlating>(), 5);
				recipe.AddIngredient(ItemType<DubiousPlating>(), 20);
				recipe.AddIngredient(ItemType<MysteriousCircuitry>(), 20);
				recipe.AddTile(TileID.MythrilAnvil);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<RepurposedMonitor>());
				recipe.AddIngredient(ItemType<DubiousPlating>(), 10);
				recipe.AddIngredient(ItemType<MysteriousCircuitry>(), 10);
				recipe.AddRecipeGroup("AnyPlate", 10);
				recipe.AddTile(TileID.Anvils);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<IonizedJellyCrystal>());
				recipe.AddIngredient(ItemType<SlimeDeitysSoul>());
				recipe.AddIngredient(ItemType<BlightedGel>(), 20);
				recipe.AddIngredient(ItemType<PurifiedGel>(), 20);
				recipe.AddIngredient(ItemID.Gel, 30);
				recipe.AddTile(TileType<StaticRefiner>());
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<Sirember>());
				recipe.AddIngredient(ItemType<CorrodedCleaver>());
				recipe.AddIngredient(ItemType<CalamityMod.Items.Placeables.Furniture.Trophies.AnahitaTrophy>());
				recipe.AddIngredient(ItemType<CosmiliteBar>(), 20);
				recipe.AddIngredient(ItemType<NuclearFumes>(), 20);
				recipe.AddTile(TileType<CosmicAnvil>());
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<TheSeaKingsCoin>());
				recipe.AddIngredient(ItemType<DriedLocket>());
				recipe.AddIngredient(ItemType<MoistLocket>());
				recipe.AddIngredient(ItemType<NuclearFumes>(), 20);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<Finality>());
				recipe.AddIngredient(ItemType<Termipebbles>(), 5);
				recipe.AddIngredient(ItemType<Rock>());
				recipe.AddTile(TileType<DraedonsForge>());
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<SunBun>());
				recipe.AddIngredient(ItemID.Bunny);
				recipe.AddIngredient(ItemID.FragmentSolar, 50);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<GodSlayerDoll>());
				recipe.AddIngredient(ItemType<ArmoredScrap>());
				recipe.AddIngredient(ItemType<MirrorMatter>());
				recipe.AddIngredient(ItemType<ShadowCloth>());
				recipe.AddIngredient(ItemType<CosmiliteBar>(), 15);
				recipe.AddTile(TileType<CosmicAnvil>());
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<AstraEGGeldon>());
				recipe.AddIngredient(ItemType<Termipebbles>(), 999);
				recipe.AddIngredient(ItemType<CalamityMod.Items.Placeables.Banners.AstralSlimeBanner>(), 30);
				recipe.AddTile(TileType<DraedonsForge>());
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<AstraEGGeldon>());
				recipe.AddIngredient(ItemType<Rock>());
				recipe.AddIngredient(ItemType<CalamityMod.Items.Placeables.Banners.AstralSlimeBanner>(), 30);
				recipe.AddTile(TileType<DraedonsForge>());
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<MiniatureElementalHeart>());
				recipe.AddIngredient(ItemType<RareBrimtulip>());
				recipe.AddIngredient(ItemType<StrangeMusicNote>());
				recipe.AddIngredient(ItemType<CloudCandy>());
				recipe.AddIngredient(ItemType<SmallSandPail>());
				recipe.AddIngredient(ItemType<SmallSandPlushie>());
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<BejeweledSpike>());
				recipe.AddIngredient(ItemType<AmberGeode>());
				recipe.AddIngredient(ItemType<AmethystGeode>());
				recipe.AddIngredient(ItemType<CrystalGeode>());
				recipe.AddIngredient(ItemType<DiamondGeode>());
				recipe.AddIngredient(ItemType<EmeraldGeode>());
				recipe.AddIngredient(ItemType<RubyGeode>());
				recipe.AddIngredient(ItemType<SapphireGeode>());
				recipe.AddIngredient(ItemType<TopazGeode>());
				recipe.AddIngredient(ItemType<ScuttlersJewel>());
				recipe.AddTile(TileID.MythrilAnvil);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<ExoGemstone>());
				recipe.AddIngredient(ItemType<OminousCore>());
				recipe.AddIngredient(ItemType<GunmetalRemote>());
				recipe.AddIngredient(ItemType<GeminiMarkImplants>());
				recipe.AddIngredient(ItemType<MiracleMatter>());
				recipe.AddTile(TileType<DraedonsForge>());
				recipe.Register();
			}
			//Blocks
			{
				Recipe recipe = Recipe.Create(ItemType<MeldBlock>(), 50);
				recipe.AddIngredient(ItemType<CalamityMod.Items.Materials.MeldBlob>());
				recipe.AddIngredient(ItemID.StoneBlock, 50);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<WulfrumPlating>(), 50);
				recipe.AddIngredient(ItemType<WulfrumMetalScrap>());
				recipe.AddIngredient(ItemID.StoneBlock, 50);
				recipe.AddTile(TileID.Anvils);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<AuricBrick>(), 50);
				recipe.AddIngredient(ItemType<CalamityMod.Items.Placeables.Ores.AuricOre>());
				recipe.AddIngredient(ItemID.StoneBlock, 50);
				recipe.AddTile(TileType<CosmicAnvil>());
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<Items.Tiles.Blocks.AstralBrick>(), 1);
				recipe.AddIngredient(ItemType<AstralStone>());
				recipe.AddIngredient(ItemID.StoneBlock);
				recipe.AddTile(TileType<StarstruckSynthesizerPlaced>());
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<BloodstoneBrick>(), 200);
				recipe.AddIngredient(ItemType<BloodstoneCore>());
				recipe.AddIngredient(ItemID.StoneBlock, 200);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<ChiseledBloodstone>(), 200);
				recipe.AddIngredient(ItemType<BloodstoneCore>());
				recipe.AddIngredient(ItemID.StoneBlock, 200);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<EidolicSlab>(), 200);
				recipe.AddIngredient(ItemType<CalamityMod.Items.Placeables.FurnitureVoid.SmoothVoidstone>(), 200);
				recipe.AddIngredient(ItemType<ReaperTooth>());
				recipe.AddIngredient(ItemType<Lumenyl>(), 5);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<Necrostone>(), 200);
				recipe.AddIngredient(ItemType<CalamityMod.Items.TreasureBags.FleshyGeode>());
				recipe.AddIngredient(ItemID.StoneBlock, 200);
				recipe.AddTile(TileID.MythrilAnvil);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<Necrostone>(), 200);
				recipe.AddIngredient(ItemType<CalamityMod.Items.TreasureBags.NecromanticGeode>());
				recipe.AddIngredient(ItemID.StoneBlock, 200);
				recipe.AddTile(TileID.MythrilAnvil);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<PhantowaxBlock>(), 50);
				recipe.AddIngredient(ItemID.ClayBlock, 50);
				recipe.AddIngredient(ItemType<Phantoplasm>());
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<PolishedAstralMonolith>());
				recipe.AddIngredient(ItemType<AstralMonolith>());
				recipe.AddTile(TileID.Sawmill);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<PolishedXenomonolith>());
				recipe.AddIngredient(ItemType<AstralTreeWood>());
				recipe.AddTile(TileID.Sawmill);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<ShadowBrick>(), 300);
				recipe.AddIngredient(ItemType<AshesofAnnihilation>());
				recipe.AddIngredient(ItemType<ExoPrism>());
				recipe.AddIngredient(ItemID.StoneBlock, 300);
				recipe.AddTile(TileType<DraedonsForge>());
				recipe.Register();
			}
			//Plushies
			PlushRecipe(ItemType<AnahitaPlushThrowable>(), ItemType<AnahitaPlush>());
			PlushRecipe(ItemType<ApolloPlushThrowable>(), ItemType<ApolloPlush>());
			PlushRecipe(ItemType<AquaticScourgePlushThrowable>(), ItemType<AquaticScourgePlush>());
			PlushRecipe(ItemType<AresPlushThrowable>(), ItemType<AresPlush>());
			PlushRecipe(ItemType<ArtemisPlushThrowable>(), ItemType<ArtemisPlush>());
			PlushRecipe(ItemType<AstrageldonPlushThrowable>(), ItemType<AstrageldonPlush>());
			PlushRecipe(ItemType<AstrumAureusPlushThrowable>(), ItemType<AstrumAureusPlush>());
			PlushRecipe(ItemType<AstrumDeusPlushThrowable>(), ItemType<AstrumDeusPlush>());
			PlushRecipe(ItemType<BrimstoneElementalPlushThrowable>(), ItemType<BrimstoneElementalPlush>());
			PlushRecipe(ItemType<BumblefuckPlushThrowable>(), ItemType<BumblefuckPlush>());
			PlushRecipe(ItemType<CalaFumoYeetable>(), ItemType<CalamitasFumo>());
			PlushRecipe(ItemType<CeaselessVoidPlushThrowable>(), ItemType<CeaselessVoidPlush>());
			PlushRecipe(ItemType<ClonePlushThrowable>(), ItemType<ClonePlush>());
			PlushRecipe(ItemType<CrabulonPlushThrowable>(), ItemType<CrabulonPlush>());
			PlushRecipe(ItemType<CryogenPlushThrowable>(), ItemType<CryogenPlush>());
			PlushRecipe(ItemType<DesertScourgePlushThrowable>(), ItemType<DesertScourgePlush>());
			PlushRecipe(ItemType<DevourerofGodsPlushThrowable>(), ItemType<DevourerofGodsPlush>());
			PlushRecipe(ItemType<DraedonPlushThrowable>(), ItemType<DraedonPlush>());
			PlushRecipe(ItemType<GiantClamPlushThrowable>(), ItemType<GiantClamPlush>());
			PlushRecipe(ItemType<SandSharkPlushThrowable>(), ItemType<SandSharkPlush>());
			PlushRecipe(ItemType<HiveMindPlushThrowable>(), ItemType<HiveMindPlush>());
			PlushRecipe(ItemType<JaredPlushThrowable>(), ItemType<JaredPlush>());
			PlushRecipe(ItemType<LeviathanPlushThrowable>(), ItemType<LeviathanPlush>());
			PlushRecipe(ItemType<MaulerPlushThrowable>(), ItemType<MaulerPlush>());
			PlushRecipe(ItemType<MirePlushThrowableP1>(), ItemType<MirePlushP1>());
			PlushRecipe(ItemType<MirePlushThrowableP1>(), ItemType<MirePlushThrowableP2>());
			PlushRecipe(ItemType<MirePlushThrowableP2>(), ItemType<MirePlushP2>());
			PlushRecipe(ItemType<MirePlushThrowableP2>(), ItemType<MirePlushThrowableP1>());
			PlushRecipe(ItemType<MirePlushP1>(), ItemType<MirePlushP2>());
			PlushRecipe(ItemType<MirePlushP2>(), ItemType<MirePlushP1>());
			PlushRecipe(ItemType<NuclearTerrorPlushThrowable>(), ItemType<NuclearTerrorPlush>());
			PlushRecipe(ItemType<OldDukePlushThrowable>(), ItemType<OldDukePlush>());
			PlushRecipe(ItemType<PerforatorPlushThrowable>(), ItemType<PerforatorPlush>());
			PlushRecipe(ItemType<PlaguebringerGoliathPlushThrowable>(), ItemType<PlaguebringerGoliathPlush>());
			PlushRecipe(ItemType<PolterghastPlushThrowable>(), ItemType<PolterghastPlush>());
			PlushRecipe(ItemType<ProfanedGuardianPlushThrowable>(), ItemType<ProfanedGuardianPlush>());
			PlushRecipe(ItemType<ProvidencePlushThrowable>(), ItemType<ProvidencePlush>());
			PlushRecipe(ItemType<RavagerPlushThrowable>(), ItemType<RavagerPlush>());
			PlushRecipe(ItemType<SignusPlushThrowable>(), ItemType<SignusPlush>());
			PlushRecipe(ItemType<SlimeGodPlushThrowable>(), ItemType<SlimeGodPlush>());
			PlushRecipe(ItemType<StormWeaverPlushThrowable>(), ItemType<StormWeaverPlush>());
			PlushRecipe(ItemType<ThanatosPlushThrowable>(), ItemType<ThanatosPlush>());
			PlushRecipe(ItemType<YharonPlushThrowable>(), ItemType<YharonPlush>());
			//Blueprints
			BlueprintRecipe(ItemType<CalamityMod.Items.Potions.AureusCell>(), ItemType<AstrumAureusLog>());
			BlueprintRecipe(ItemType<EffulgentFeather>(), ItemType<BumblebirbLog>());
			BlueprintRecipe(ItemType<AshesofCalamity>(), ItemType<CalamitasLog>());
			BlueprintRecipe(ItemID.SoulofMight, ItemType<DestroyerLog>());
			BlueprintRecipe(ItemType<CosmiliteBar>(), ItemType<DogLog>());
			BlueprintRecipe(ItemID.HellstoneBar, ItemType<MurasamaLog>());
			BlueprintRecipe(ItemType<Help>(), ItemType<OrthoceraLog>());
			BlueprintRecipe(ItemType<InfectedArmorPlating>(), ItemType<PlagueLog>());
			BlueprintRecipe(ItemID.SoulofFright, ItemType<PrimeLog>());
			BlueprintRecipe(ItemID.SoulofSight, ItemType<TwinsLog>());
			BlueprintRecipe(ItemType <AuricBar>(), ItemType<YharmorLog>());
			//Cages
			CageRecipe(ItemType<AstJRItem>(), ItemID.Bottle, ItemType<AstJar>());
			CageRecipe(ItemType<BlightolemurItem>(), ItemType<Items.Tiles.Plants.AstralOldPurple>(), ItemType<BleamurPerch>());
			CageRecipe(ItemType<IsopodItem>(), ItemID.Terrarium, ItemType<IsopodTerrarium>(), ItemID.WaterBucket);
			CageRecipe(ItemType<BlinkerItem>(), ItemID.Bottle, ItemType<BlinkerInABottle>());
			CageRecipe(ItemType<CrystalFlyItem>(), ItemID.Bottle, ItemType<CrystalFlyJar>());
			CageRecipe(ItemType<EyedolItem>(), ItemID.Chain, ItemType<EyedolTerrarium>());
			CageRecipe(ItemType<GAstJRItem>(), ItemID.Bottle, ItemType<GAstJar>());
			CageRecipe(ItemType<GoldenIsopodItem>(), ItemID.Terrarium, ItemType<GoldenIsopodTerrarium>(), ItemID.WaterBucket);
			CageRecipe(ItemType<GoldEyedolItem>(), ItemID.Chain, ItemType<GoldEyedolTerrarium>());
			CageRecipe(ItemType<GoldViolemurItem>(), ItemType<Items.Tiles.Plants.MonolithPot>(), ItemType<GoldViolemurMonolith>());
			CageRecipe(ItemType<VaporoflyItem>(), ItemID.Bottle, ItemType<NukeJar>());
			CageRecipe(ItemType<OrthobabItem>(), ItemID.Bottle, ItemType<OrthoJar>());
			CageRecipe(ItemType<PlagueFrogItem>(), ItemID.Terrarium, ItemType<PlagueFrogTerrarium>());
			CageRecipe(ItemType<ProvFlyItem>(), ItemID.Bottle, ItemType<ProvFlyJar>());
			CageRecipe(ItemType<SandTurtleItem>(), ItemID.Terrarium, ItemType<SandTurtleCage>());
			CageRecipe(ItemType<GodSlayerSlugItem>(), ItemID.Terrarium, ItemType<SlugTerrarium>());
			CageRecipe(ItemType<SwearshroomItem>(), ItemID.Terrarium, ItemType<SwearshroomCage>());
			CageRecipe(ItemType<ViolemurItem>(), ItemType<Items.Tiles.Plants.MonolithPot>(), ItemType<ViolemurMonolith>());
			CageRecipe(ItemType<XerocodileItem>(), ItemID.Terrarium, ItemType<XerocodileCage>());
			//Statues
			StatueRecipe(ItemType<EyedolItem>(), ItemType<EyedolStatue>());
			StatueRecipe(ItemType<IsopodItem>(), ItemType<IsopodStatue>());
			StatueRecipe(ItemType<VaporoflyItem>(), ItemType<NukeFlyStatue>());
			StatueRecipe(ItemType<PlagueFrogItem>(), ItemType<PlagueFrogStatue>());
			StatueRecipe(ItemType<ViolemurItem>(), ItemType<ViolemurStatue>());
			//Monoliths
			MonolithRecipe(ItemType <CosmiliteBar>(), ItemType<DimensionalMonolith>(), TileID.LunarCraftingStation);
			MonolithRecipe(ItemType <DivineGeode>(), ItemType<UnholyMonolith>(), TileID.LunarCraftingStation);
			//MonolithRecipe(ItemType <YharonSoulFragment>(), ItemType<InfernalMonolith>(), TileID.LunarCraftingStation);
			MonolithRecipe(ItemType <InfectedArmorPlating>(), ItemType<PlagueMonolith>(), TileID.MythrilAnvil);
			MonolithRecipe(ItemType <AshesofCalamity>(), ItemType<CalamitousMonolith>(), TileID.MythrilAnvil);
			MonolithRecipe(ItemType<CryonicBar>(), ItemType<AuroraMonolith>(), TileID.MythrilAnvil);
			MonolithRecipe(ItemType<Termipebbles>(), ItemType<TerminusShrine>(), TileID.LunarCraftingStation);
			//Wall Block conversion
			WallRecipe(ItemType<AuricBrick>(), ItemType<AuricBrickWall>());
			WallRecipe(ItemType<BlightedEggBlock>(), ItemType<BlightedEggWall>());
			WallRecipe(ItemType<Items.Tiles.Blocks.Astral.AstralSandstone>(), ItemType<Items.Walls.Astral.AstralSandstoneWall>());
			WallRecipe(ItemType<Items.Tiles.Blocks.Astral.AstralDirt>(), ItemType<Items.Walls.Astral.AstralDirtWall>());
			WallRecipe(ItemType<AstralHardenedSand>(), ItemType<Items.Walls.Astral.AstralHardenedSandWall>());
			WallRecipe(ItemType<Items.Tiles.Blocks.Astral.AstralIce>(), ItemType<Items.Walls.Astral.AstralIceWall>());
			WallRecipe(ItemType<AstralTreeWood>(), ItemType<Items.Walls.Astral.XenomonolithWall>());
			WallRecipe(ItemType<Xenostone>(), ItemType<Items.Walls.Astral.XenostoneWall>());
			WallRecipe(ItemType<AstralPlating>(), ItemType<AstralPlatingWall>());
			WallRecipe(ItemType<AstralPearlBlock>(), ItemType<AstralPearlWall>());
			WallRecipe(ItemType<CalamityMod.Items.Materials.Bloodstone>(), ItemType<BloodstoneWall>());
			WallRecipe(ItemType<ChiseledBloodstone>(), ItemType<ChiseledBloodstoneBrickWall>());
			WallRecipe(ItemType<PhantowaxBlock>(), ItemType<PhantowaxWall>());
			WallRecipe(ItemType<EidolicSlab>(), ItemType<EidolicSlabWall>());
			WallRecipe(ItemType<ShadowBrick>(), ItemType<ShadowBrickWall>());
			WallRecipe(ItemType<PolishedAstralMonolith>(), ItemType<PolishedAstralMonolithWall>());
			WallRecipe(ItemType<PolishedXenomonolith>(), ItemType<PolishedXenomonolithWall>());
			WallRecipe(ItemType<Necrostone>(), ItemType<NecrostoneWall>());
			WallRecipe(ItemType<WulfrumPlating>(), ItemType<WulfrumPanelWall>());
			WallRecipe(ItemType<HallowedBrick>(), ItemType<HallowedBrickWall>());
			//SSS conversions
			AstralRecipe(ItemType<AstralTreeWood>(), ItemType<AstralMonolith>());
			AstralRecipe(ItemType<Items.Tiles.Blocks.Astral.AstralDirt>(), ItemType<CalamityMod.Items.Placeables.AstralDirt>());
			AstralRecipe(ItemType<Items.Tiles.Blocks.Astral.AstralClay>(), ItemType<CalamityMod.Items.Placeables.AstralClay>());
			AstralRecipe(ItemType<Items.Tiles.Blocks.Astral.AstralSand>(), ItemType<CalamityMod.Items.Placeables.AstralSand>());
			AstralRecipe(ItemType<Items.Tiles.Blocks.Astral.AstralSandstone>(), ItemType<CalamityMod.Items.Placeables.AstralSandstone>());
			AstralRecipe(ItemType<Items.Tiles.Blocks.Astral.AstralHardenedSand>(), ItemType<CalamityMod.Items.Placeables.HardenedAstralSand>());
			AstralRecipe(ItemType<Items.Tiles.Blocks.Astral.Xenostone>(), ItemType<CalamityMod.Items.Placeables.AstralStone>());
			AstralRecipe(ItemType<Items.Tiles.Blocks.Astral.AstralSnow>(), ItemType<CalamityMod.Items.Placeables.AstralSnow>());
			AstralRecipe(ItemType<Items.Tiles.Blocks.Astral.AstralIce>(), ItemType<CalamityMod.Items.Placeables.AstralIce>());
			AstralRecipe(ItemType<Items.Tiles.Blocks.BlightedEggBlock>(), ItemType<AstralPearlBlock>());
			AstralRecipe(ItemType<Items.Walls.Astral.AstralDirtWall>(), ItemType<CalamityMod.Items.Placeables.Walls.AstralDirtWall>());
			AstralRecipe(ItemType<Items.Walls.Astral.AstralHardenedSandWall>(), ItemType<CalamityMod.Items.Placeables.Walls.HardenedAstralSandWall>());
			AstralRecipe(ItemType<Items.Walls.Astral.AstralIceWall>(), ItemType<CalamityMod.Items.Placeables.Walls.AstralIceWall>());
			AstralRecipe(ItemType<Items.Walls.Astral.XenostoneWall>(), ItemType<CalamityMod.Items.Placeables.Walls.AstralStoneWall>());
			AstralRecipe(ItemType<Items.Walls.BlightedEggWall>(), ItemType<AstralPearlWall>());
			AstralRecipe(ItemType<OldAstralBathtubItem>(), ItemType<MonolithBathtub>());
			AstralRecipe(ItemType<OldAstralBedItem>(), ItemType<MonolithBed>());
			AstralRecipe(ItemType<OldAstralBookshelfItem>(), ItemType<MonolithBookcase>());
			AstralRecipe(ItemType<OldAstralCandelabraItem>(), ItemType<MonolithCandelabra>());
			AstralRecipe(ItemType<OldAstralCandleItem>(), ItemType<MonolithCandle>());
			AstralRecipe(ItemType<OldAstralChandelierItem>(), ItemType<MonolithChandelier>());
			AstralRecipe(ItemType<OldAstralLanternItem>(), ItemType<MonolithLantern>());
			AstralRecipe(ItemType<OldAstralLampItem>(), ItemType<MonolithLamp>());
			AstralRecipe(ItemType<OldAstralDoorItem>(), ItemType<MonolithDoor>());
			AstralRecipe(ItemType<OldAstralDresserItem>(), ItemType<MonolithDresser>());
			AstralRecipe(ItemType<OldAstralSinkItem>(), ItemType<MonolithSink>());
			AstralRecipe(ItemType<OldAstralSofaItem>(), ItemType<MonolithBench>());
			AstralRecipe(ItemType<OldAstralChestItem>(), ItemType<MonolithChest>());
			AstralRecipe(ItemType<OldAstralClockItem>(), ItemType<MonolithClock>());
			AstralRecipe(ItemType<OldAstralWorkbenchItem>(), ItemType<MonolithWorkBench>());
			AstralRecipe(ItemType<OldAstralPianoItem>(), ItemType<MonolithPiano>());
			AstralRecipe(ItemType<PolishedXenomonolith>(), ItemType<PolishedAstralMonolith>());
			AstralRecipe(ItemType<PolishedXenomonolithWall>(), ItemType<PolishedAstralMonolithWall>());
			AstralRecipe(ItemType<BlinkerItem>(), ItemType<CalamityMod.Items.Critters.TwinklerItem>());
			AstralRecipe(ItemType<BlinkerInABottle>(), ItemType<CalamityMod.Items.Placeables.Furniture.TwinklerInABottle>());
			AstralRecipe(ItemType<BlightolemurItem>(), ItemType<ViolemurItem>());
			AstralRecipe(ItemType<BleamurPerch>(), ItemType<ViolemurMonolith>());
			AstralRecipe(ItemType<XenoSolution>(), ItemType<CalamityMod.Items.Ammo.AstralSolution>());
			//Misc furniture
			{
				Recipe recipe = Recipe.Create(ItemType<AuricTrashCan>());
				recipe.AddIngredient(ItemID.TrashCan);
				recipe.AddIngredient(ItemType<AuricBar>(), 5);
				recipe.AddTile(TileType<CosmicAnvil>());
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<InactivePowerFactory>());
				recipe.AddIngredient(ItemType<PowerCellFactoryItem>());
				recipe.AddTile(TileID.Anvils);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<HallowedBrick>(), 50);
				recipe.AddIngredient(ItemType<CalamityMod.Items.Placeables.Ores.HallowedOre>());
				recipe.AddIngredient(ItemID.StoneBlock, 50);
				recipe.AddTile(TileID.MythrilAnvil);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<CosmiliteChairEX>());
				recipe.AddIngredient(ItemType<CalamityMod.Items.Placeables.FurnitureCosmilite.CosmiliteChair>(), 2);
				recipe.AddIngredient(ItemType<CosmiliteBar>(), 4);
				recipe.AddTile(TileType<CosmicAnvil>());
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<Hesfine>());
				recipe.AddIngredient(ItemType<Help>());
				recipe.AddIngredient(ItemType<CalamityMod.Items.Placeables.Banners.OrthoceraBanner>(), 2);
				recipe.AddIngredient(ItemType<NuclearFumes>(), 50);
				recipe.AddTile(TileID.MythrilAnvil);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<MoulderingAltarItem>());
				recipe.AddIngredient(ItemID.DemoniteBar, 20);
				recipe.AddIngredient(ItemID.SoulofNight, 15);
				recipe.AddIngredient(ItemType<CalamityMod.Items.Materials.RottenMatter>(), 6);
				recipe.AddTile(TileID.DemonAltar);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<SchematicDisplay>());
				recipe.AddIngredient(ItemType<MysteriousCircuitry>(), 20);
				recipe.AddIngredient(ItemID.Wire, 20);
				recipe.AddTile(TileID.Anvils);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<TerminusShrine2>());
				recipe.AddIngredient(ItemType<TerminusShrine>());
				recipe.AddIngredient(ItemType<CalamityMod.Items.SummonItems.Terminus>());
				recipe.AddTile(TileType<DraedonsForge>());
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<TerminusShrine3>());
				recipe.AddIngredient(ItemType<TerminusShrine2>());
				recipe.AddIngredient(ItemType<Rock>());
				recipe.AddTile(TileType<DraedonsForge>());
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<VisceralAltarItem>());
				recipe.AddIngredient(ItemID.CrimtaneBar, 20);
				recipe.AddIngredient(ItemID.SoulofNight, 15);
				recipe.AddIngredient(ItemType<CalamityMod.Items.Materials.BloodSample>(), 6);
				recipe.AddTile(TileID.DemonAltar);
				recipe.Register();
			}
			//Astral furniture
			{
				Recipe recipe = Recipe.Create(ItemType<OldAstralBathtubItem>());
				recipe.AddIngredient(ItemType<AstralTreeWood>(), 14);
				recipe.AddTile(TileType<StarstruckSynthesizerPlaced>());
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<OldAstralBedItem>());
				recipe.AddIngredient(ItemType<AstralTreeWood>(), 15);
				recipe.AddTile(TileType<StarstruckSynthesizerPlaced>());
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<OldAstralSofaItem>());
				recipe.AddIngredient(ItemType<AstralTreeWood>(), 5);
				recipe.AddTile(TileType<StarstruckSynthesizerPlaced>());
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<OldAstralBookshelfItem>());
				recipe.AddIngredient(ItemType<AstralTreeWood>(), 20);
				recipe.AddIngredient(ItemID.Book, 10);
				recipe.AddTile(TileType<StarstruckSynthesizerPlaced>());
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<OldAstralCandelabraItem>());
				recipe.AddIngredient(ItemType<AstralTreeWood>(), 5);
				recipe.AddTile(TileType<StarstruckSynthesizerPlaced>());
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<OldAstralCandleItem>());
				recipe.AddIngredient(ItemType<AstralTreeWood>(), 4);
				recipe.AddTile(TileType<StarstruckSynthesizerPlaced>());
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<OldAstralChairItem>());
				recipe.AddIngredient(ItemType<AstralTreeWood>(), 5);
				recipe.AddTile(TileType<StarstruckSynthesizerPlaced>());
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<OldAstralChandelierItem>());
				recipe.AddIngredient(ItemType<AstralTreeWood>(), 4);
				recipe.AddIngredient(ItemID.Chain, 1);
				recipe.AddTile(TileType<StarstruckSynthesizerPlaced>());
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<OldAstralChestItem>());
				recipe.AddIngredient(ItemType<AstralTreeWood>(), 8);
				recipe.AddTile(TileType<StarstruckSynthesizerPlaced>());
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<OldAstralClockItem>());
				recipe.AddIngredient(ItemType<AstralTreeWood>(), 10);
				recipe.AddRecipeGroup(RecipeGroupID.IronBar, 3);
				recipe.AddTile(TileType<StarstruckSynthesizerPlaced>());
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<OldAstralDoorItem>());
				recipe.AddIngredient(ItemType<AstralTreeWood>(), 6);
				recipe.AddTile(TileType<StarstruckSynthesizerPlaced>());
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<OldAstralDresserItem>());
				recipe.AddIngredient(ItemType<AstralTreeWood>(), 16);
				recipe.AddTile(TileType<StarstruckSynthesizerPlaced>());
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<OldAstralLampItem>());
				recipe.AddIngredient(ItemType<AstralTreeWood>(), 3);
				recipe.AddTile(TileType<StarstruckSynthesizerPlaced>());
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<OldAstralLanternItem>());
				recipe.AddIngredient(ItemType<AstralTreeWood>(), 6);
				recipe.AddTile(TileType<StarstruckSynthesizerPlaced>());
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<OldAstralPianoItem>());
				recipe.AddIngredient(ItemType<AstralTreeWood>(), 15);
				recipe.AddIngredient(ItemID.Bone, 4);
				recipe.AddIngredient(ItemID.Book, 1);
				recipe.AddTile(TileType<StarstruckSynthesizerPlaced>());
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<OldAstralSinkItem>());
				recipe.AddIngredient(ItemType<AstralTreeWood>(), 6);
				recipe.AddIngredient(ItemID.EmptyBucket, 1);
				recipe.AddTile(TileType<StarstruckSynthesizerPlaced>());
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<OldAstralTableItem>());
				recipe.AddIngredient(ItemType<AstralTreeWood>(), 8);
				recipe.AddTile(TileType<StarstruckSynthesizerPlaced>());
				recipe.Register();
			}
			//Auric
			{
				Recipe recipe = Recipe.Create(ItemType<AuricManufacturer>());
				recipe.AddIngredient(ItemType<AuricBrick>(), 20);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<AuricBathtubItem>());
				recipe.AddIngredient(ItemType<AuricBrick>(), 14);
				recipe.AddTile(TileType<AuricManufacturerPlaced>());
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<AuricBedItem>());
				recipe.AddIngredient(ItemType<AuricBrick>(), 15);
				recipe.AddTile(TileType<AuricManufacturerPlaced>());
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<AuricSofaItem>());
				recipe.AddIngredient(ItemType<AuricBrick>(), 5);
				recipe.AddTile(TileType<AuricManufacturerPlaced>());
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<AuricBookshelfItem>());
				recipe.AddIngredient(ItemType<AuricBrick>(), 20);
				recipe.AddIngredient(ItemID.Book, 10);
				recipe.AddTile(TileType<AuricManufacturerPlaced>());
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<AuricCandelabraItem>());
				recipe.AddIngredient(ItemType<AuricBrick>(), 5);
				recipe.AddTile(TileType<AuricManufacturerPlaced>());
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<AuricCandleItem>());
				recipe.AddIngredient(ItemType<AuricBrick>(), 4);
				recipe.AddTile(TileType<AuricManufacturerPlaced>());
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<AuricChairItem>());
				recipe.AddIngredient(ItemType<AuricBrick>(), 5);
				recipe.AddTile(TileType<AuricManufacturerPlaced>());
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<AuricChandelierItem>());
				recipe.AddIngredient(ItemType<AuricBrick>(), 4);
				recipe.AddIngredient(ItemID.Chain, 1);
				recipe.AddTile(TileType<AuricManufacturerPlaced>());
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<AuricChestItem>());
				recipe.AddIngredient(ItemType<AuricBrick>(), 8);
				recipe.AddTile(TileType<AuricManufacturerPlaced>());
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<AuricClockItem>());
				recipe.AddIngredient(ItemType<AuricBrick>(), 10);
				recipe.AddRecipeGroup(RecipeGroupID.IronBar, 3);
				recipe.AddTile(TileType<AuricManufacturerPlaced>());
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<AuricDoorItem>());
				recipe.AddIngredient(ItemType<AuricBrick>(), 6);
				recipe.AddTile(TileType<AuricManufacturerPlaced>());
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<AuricDresserItem>());
				recipe.AddIngredient(ItemType<AuricBrick>(), 16);
				recipe.AddTile(TileType<AuricManufacturerPlaced>());
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<AuricLampItem>());
				recipe.AddIngredient(ItemType<AuricBrick>(), 3);
				recipe.AddTile(TileType<AuricManufacturerPlaced>());
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<AuricLanternItem>());
				recipe.AddIngredient(ItemType<AuricBrick>(), 6);
				recipe.AddTile(TileType<AuricManufacturerPlaced>());
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<AuricPianoItem>());
				recipe.AddIngredient(ItemType<AuricBrick>(), 15);
				recipe.AddIngredient(ItemID.Bone, 4);
				recipe.AddIngredient(ItemID.Book, 1);
				recipe.AddTile(TileType<AuricManufacturerPlaced>());
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<AuricSinkItem>());
				recipe.AddIngredient(ItemType<AuricBrick>(), 6);
				recipe.AddIngredient(ItemID.EmptyBucket, 1);
				recipe.AddTile(TileType<AuricManufacturerPlaced>());
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<AuricTableItem>());
				recipe.AddIngredient(ItemType<AuricBrick>(), 8);
				recipe.AddTile(TileType<AuricManufacturerPlaced>());
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<AuricPlatformItem>(), 2);
				recipe.AddIngredient(ItemType<AuricBrick>());
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<AuricBrick>());
				recipe.AddIngredient(ItemType<AuricPlatformItem>(), 2);
				recipe.Register();
			}
            //Override Auric Toilet recipe
            {
				List<Recipe> rec = Main.recipe.ToList();
				rec.Where(x => x.createItem.type == ItemType<CalamityMod.Items.Placeables.Furniture.AuricToilet>()).ToList().ForEach(s =>
				{
					s.requiredItem = new List<Item>();
					for (int i = 0; i < 5; i++)
						s.requiredItem.Add(new Item());
					s.requiredItem[0].SetDefaults(ItemType<CalamityMod.Items.Placeables.FurnitureBotanic.BotanicChair>(), false);
					s.requiredItem[0].stack = 1;
					s.requiredItem[1].SetDefaults(ItemType<BloodstoneChairItem>(), false);
					s.requiredItem[1].stack = 1;
					s.requiredItem[2].SetDefaults(ItemType<CalamityMod.Items.Placeables.FurnitureCosmilite.CosmiliteChair>(), false);
					s.requiredItem[2].stack = 1;
					s.requiredItem[3].SetDefaults(ItemType<CalamityMod.Items.Placeables.FurnitureSilva.SilvaChair>(), false);
					s.requiredItem[3].stack = 1;
					s.requiredItem[4].SetDefaults(ItemType<AuricBrick>(), false);
					s.requiredItem[4].stack = 50;

					s.requiredTile[0] = ModContent.TileType<AuricManufacturerPlaced>();
					s.createItem.SetDefaults(ItemType<CalamityMod.Items.Placeables.Furniture.AuricToilet>(), false);
					s.createItem.stack = 1;
				});
			}
			//Bloodstone
			{
				Recipe recipe = Recipe.Create(ItemType<BloodstoneBathtubItem>());
				recipe.AddIngredient(ItemType<ChiseledBloodstone>(), 14);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<BloodstoneBedItem>());
				recipe.AddIngredient(ItemType<ChiseledBloodstone>(), 15);
				recipe.AddIngredient(ItemType<BloodOrb>(), 5);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<BloodstoneSofaItem>());
				recipe.AddIngredient(ItemType<ChiseledBloodstone>(), 5);
				recipe.AddIngredient(ItemType<BloodOrb>(), 2);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<BloodstoneBookshelfItem>());
				recipe.AddIngredient(ItemType<ChiseledBloodstone>(), 20);
				recipe.AddIngredient(ItemID.Book, 10);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<BloodstoneCandelabraItem>());
				recipe.AddIngredient(ItemType<ChiseledBloodstone>(), 5);
				recipe.AddIngredient(ItemType<BloodOrb>(), 3);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<BloodstoneCandleItem>());
				recipe.AddIngredient(ItemType<ChiseledBloodstone>(), 4);
				recipe.AddIngredient(ItemType<BloodOrb>(), 1);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<BloodstoneChairItem>());
				recipe.AddIngredient(ItemType<ChiseledBloodstone>(), 5);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<BloodstoneChandelierItem>());
				recipe.AddIngredient(ItemType<ChiseledBloodstone>(), 4);
				recipe.AddIngredient(ItemType<BloodOrb>(), 4);
				recipe.AddIngredient(ItemID.Chain, 1);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<BloodstoneChestItem>());
				recipe.AddIngredient(ItemType<ChiseledBloodstone>(), 8);
				recipe.AddIngredient(ItemType<BloodOrb>(), 2);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<BloodstoneClockItem>());
				recipe.AddIngredient(ItemType<ChiseledBloodstone>(), 10);
				recipe.AddRecipeGroup(RecipeGroupID.IronBar, 3);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<BloodstoneDoorItem>());
				recipe.AddIngredient(ItemType<ChiseledBloodstone>(), 6);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<BloodstoneDresserItem>());
				recipe.AddIngredient(ItemType<ChiseledBloodstone>(), 16);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<BloodstoneLampItem>());
				recipe.AddIngredient(ItemType<ChiseledBloodstone>(), 3);
				recipe.AddIngredient(ItemType<BloodOrb>(), 1);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<BloodstoneLanternItem>());
				recipe.AddIngredient(ItemType<ChiseledBloodstone>(), 6);
				recipe.AddIngredient(ItemType<BloodOrb>(), 1);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<BloodstonePianoItem>());
				recipe.AddIngredient(ItemType<ChiseledBloodstone>(), 15);
				recipe.AddIngredient(ItemID.Bone, 4);
				recipe.AddIngredient(ItemID.Book, 1);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<BloodstoneSinkItem>());
				recipe.AddIngredient(ItemType<ChiseledBloodstone>(), 6);
				recipe.AddIngredient(ItemType<BloodOrb>(), 1);
				recipe.AddIngredient(ItemID.EmptyBucket, 1);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<BloodstoneTableItem>());
				recipe.AddIngredient(ItemType<ChiseledBloodstone>(), 8);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<BloodstonePlatformItem>(), 2);
				recipe.AddIngredient(ItemType<ChiseledBloodstone>());
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<ChiseledBloodstone>());
				recipe.AddIngredient(ItemType<BloodstonePlatformItem>(), 2);
				recipe.Register();
			}
			//Phantowax
			{
				Recipe recipe = Recipe.Create(ItemType<PhantowaxBathtubItem>());
				recipe.AddIngredient(ItemType<PhantowaxBlock>(), 14);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<PhantowaxBedItem>());
				recipe.AddIngredient(ItemType<PhantowaxBlock>(), 15);
				recipe.AddIngredient(ItemType<Phantoplasm>(), 5);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<PhantowaxSofaItem>());
				recipe.AddIngredient(ItemType<PhantowaxBlock>(), 5);
				recipe.AddIngredient(ItemType<Phantoplasm>(), 2);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<PhantowaxBookshelfItem>());
				recipe.AddIngredient(ItemType<PhantowaxBlock>(), 20);
				recipe.AddIngredient(ItemID.Book, 10);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<PhantowaxCandelabraItem>());
				recipe.AddIngredient(ItemType<PhantowaxBlock>(), 5);
				recipe.AddIngredient(ItemType<Phantoplasm>(), 3);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<PhantowaxCandleItem>());
				recipe.AddIngredient(ItemType<PhantowaxBlock>(), 4);
				recipe.AddIngredient(ItemType<Phantoplasm>(), 1);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<PhantowaxChairItem>());
				recipe.AddIngredient(ItemType<PhantowaxBlock>(), 5);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<PhantowaxChandelierItem>());
				recipe.AddIngredient(ItemType<PhantowaxBlock>(), 4);
				recipe.AddIngredient(ItemType<Phantoplasm>(), 4);
				recipe.AddIngredient(ItemID.Chain, 1);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<PhantowaxChestItem>());
				recipe.AddIngredient(ItemType<PhantowaxBlock>(), 8);
				recipe.AddIngredient(ItemType<Phantoplasm>(), 2);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<PhantowaxClockItem>());
				recipe.AddIngredient(ItemType<PhantowaxBlock>(), 10);
				recipe.AddRecipeGroup(RecipeGroupID.IronBar, 3);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<PhantowaxDoorItem>());
				recipe.AddIngredient(ItemType<PhantowaxBlock>(), 6);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<PhantowaxDresserItem>());
				recipe.AddIngredient(ItemType<PhantowaxBlock>(), 16);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<PhantowaxLampItem>());
				recipe.AddIngredient(ItemType<PhantowaxBlock>(), 3);
				recipe.AddIngredient(ItemType<Phantoplasm>(), 1);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<PhantowaxLanternItem>());
				recipe.AddIngredient(ItemType<PhantowaxBlock>(), 6);
				recipe.AddIngredient(ItemType<Phantoplasm>(), 1);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<PhantowaxPianoItem>());
				recipe.AddIngredient(ItemType<PhantowaxBlock>(), 15);
				recipe.AddIngredient(ItemID.Bone, 4);
				recipe.AddIngredient(ItemID.Book, 1);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<PhantowaxSinkItem>());
				recipe.AddIngredient(ItemType<PhantowaxBlock>(), 6);
				recipe.AddIngredient(ItemType<Phantoplasm>(), 1);
				recipe.AddIngredient(ItemID.EmptyBucket, 1);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<PhantowaxTableItem>());
				recipe.AddIngredient(ItemType<PhantowaxBlock>(), 8);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<PhantowaxPlatformItem>(), 2);
				recipe.AddIngredient(ItemType<PhantowaxBlock>());
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<PhantowaxBlock>());
				recipe.AddIngredient(ItemType<PhantowaxPlatformItem>(), 2);
				recipe.Register();
			}
			//Orthocera torture
			{
				Recipe recipe = Recipe.Create(ItemType<BloodOrb>(), 10);
				recipe.AddIngredient(ItemType<Help>());
				recipe.AddTile(TileID.MeatGrinder);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(ItemType<CalamityMod.Items.Potions.HadalStew>());
				recipe.AddIngredient(ItemType<Help>());
				recipe.AddTile(TileID.CookingPots);
				recipe.Register();
			}
		}

		void PlushRecipe(int throwplush, int placeplush)
        {
            {
				Recipe recipe = Recipe.Create(throwplush);
				recipe.AddIngredient(placeplush);
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(placeplush);
				recipe.AddIngredient(throwplush);
				recipe.Register();
			}
		}
		void BlueprintRecipe(int ingredient, int result)
		{
			{
				Recipe recipe = Recipe.Create(result);
				recipe.AddIngredient(ingredient);
				recipe.AddIngredient(ItemID.Wire, 50);
				recipe.AddTile(TileID.Anvils);
				recipe.Register();
			}
		}

		void CageRecipe(int critter, int container, int result, int extra = 0, int extramt = 1)
		{
			Recipe recipe = Recipe.Create(result);
			recipe.AddIngredient(critter);
			recipe.AddIngredient(container);
			if (extra != 0)
			{
				recipe.AddIngredient(extra, extramt);
			}				
			recipe.Register();
		}

		void StatueRecipe(int critter, int result)
        {
			Recipe recipe = Recipe.Create(result);
			recipe.AddIngredient(critter, 5);
			recipe.AddIngredient(ItemID.StoneBlock, 50);
			recipe.Register();
		}

		void MonolithRecipe(int ingredient, int result, int station)
		{
			Recipe recipe = Recipe.Create(result);
			recipe.AddIngredient(ingredient, 15);
			recipe.AddTile(station);
			recipe.Register();
		}
		void WallRecipe(int block, int wall)
		{
			{
				Recipe recipe = Recipe.Create(wall, 4);
				recipe.AddIngredient(block);
				recipe.Register();
			}
            {
				Recipe recipe = Recipe.Create(block);
				recipe.AddIngredient(wall, 4);
				recipe.Register();
			}
		}

		void AstralRecipe(int blight, int normal)
        {
			{
				Recipe recipe = Recipe.Create(normal);
				recipe.AddIngredient(blight);
				recipe.AddTile(TileType<StarstruckSynthesizerPlaced>());
				recipe.Register();
			}
			{
				Recipe recipe = Recipe.Create(blight);
				recipe.AddIngredient(normal);
				recipe.AddTile(TileType<StarstruckSynthesizerPlaced>());
				recipe.Register();
			}
		}
	}
}