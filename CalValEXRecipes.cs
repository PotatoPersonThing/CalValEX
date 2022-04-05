using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
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
using CalValEX.Tiles.Plants;


namespace CalValEX
{
	public class CalValEXRecipes : ModSystem
	{

		public override void AddRecipes()
		{
			//April Fools
			if (CalValEX.month == 4 && (CalValEX.day == 1 || CalValEX.day == 2 || CalValEX.day == 3 || CalValEX.day == 4 || CalValEX.day == 5 || CalValEX.day == 6 || CalValEX.day == 7))
			{
				Recipe recipe = Mod.CreateRecipe(ModContent.ItemType<JharimHead>());
				recipe.AddIngredient(ItemID.GoldOre);
				recipe.AddTile(TileID.WorkBenches);
				recipe.Register();
			}
			//Misc
            {
				Recipe recipe = Mod.CreateRecipe(ModContent.ItemType<SparrowMeat>());
				recipe.AddIngredient(ModContent.ItemType<FluffyFeather>());
				recipe.AddIngredient(ModContent.ItemType<JunglePhoenixWings>());
				recipe.AddIngredient(ItemID.ChickenNugget);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Mod.CreateRecipe(ModContent.ItemType<YellowSolution>(), 2);
				recipe.AddIngredient(ModContent.ItemType<XenoSolution>());
				recipe.AddIngredient(ItemID.GreenSolution);
				recipe.Register();
			}
			//Critters
			{
				Recipe recipe = Mod.CreateRecipe(ModContent.ItemType<XerocodileItem>());
				recipe.AddIngredient(ItemID.BloodMoonStarter, 10);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			//Dyes
			{
				Recipe recipe = Mod.CreateRecipe(ModContent.ItemType<DraedonHologramDye>());
				recipe.AddIngredient(ItemID.BottledWater);
				recipe.AddRecipeGroup(RecipeGroupID.IronBar);
				recipe.AddTile(TileID.DyeVat);
				recipe.Register();
			}
			{
				Recipe recipe = Mod.CreateRecipe(ModContent.ItemType<BlightedAstralDye>());
				recipe.AddIngredient(ItemID.BottledWater);
				recipe.AddIngredient(ModContent.ItemType<XenoSolution>());
				recipe.AddTile(TileID.DyeVat);
				recipe.Register();
			}
			//Backpacks
			{
				Recipe recipe = Mod.CreateRecipe(ModContent.ItemType<BackpackServer>());
				recipe.AddRecipeGroup(RecipeGroupID.IronBar, 12);
				recipe.AddTile(TileID.Anvils);
				recipe.Register();
			}
			//Balloons
			{
				Recipe recipe = Mod.CreateRecipe(ModContent.ItemType<ApolloBalloon>());
				recipe.AddIngredient(ModContent.ItemType<ApolloBalloonSmall>());
				recipe.AddIngredient(ItemID.HallowedBar, 48);
				recipe.AddTile(TileID.MythrilAnvil);
				recipe.Register();
			}
			{
				Recipe recipe = Mod.CreateRecipe(ModContent.ItemType<ArtemisBalloon>());
				recipe.AddIngredient(ModContent.ItemType<ArtemisBalloonSmall>());
				recipe.AddIngredient(ItemID.HallowedBar, 48);
				recipe.AddTile(TileID.MythrilAnvil);
				recipe.Register();
			}
			{
				Recipe recipe = Mod.CreateRecipe(ModContent.ItemType<ExoTwinsBalloon>());
				recipe.AddIngredient(ModContent.ItemType<ApolloBalloon>());
				recipe.AddIngredient(ModContent.ItemType<ArtemisBalloon>());
				recipe.AddIngredient(ItemID.HallowedBar, 248);
				recipe.AddTile(TileID.MythrilAnvil);
				recipe.Register();
			}
			{
				Recipe recipe = Mod.CreateRecipe(ModContent.ItemType<BoB2>());
				recipe.AddIngredient(ModContent.ItemType<ChaosBalloon>());
				recipe.AddIngredient(ModContent.ItemType<Mirballoon>());
				recipe.AddIngredient(ModContent.ItemType<BoxBalloon>());
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			//Capes
			{
				Recipe recipe = Mod.CreateRecipe(ModContent.ItemType<YharimCape>());
				recipe.AddIngredient(ItemID.MysteriousCape);
				recipe.AddIngredient(ItemID.CrimsonCloak);
				recipe.AddIngredient(ItemID.WinterCape);
				recipe.AddIngredient(ItemID.RedCape);
				recipe.AddIngredient(ItemID.GoldBar, 20);
				recipe.AddTile(TileID.Loom);
				recipe.Register();
			}
			//Hats
			{
				Recipe recipe = Mod.CreateRecipe(ModContent.ItemType<Aestheticrown>());
				recipe.AddIngredient(ItemID.Cloud, 20);
				recipe.AddIngredient((ItemID.Glass), 7);
				recipe.AddIngredient((ItemID.Gel), 5);
				recipe.AddIngredient((ItemID.MeteoriteBar), 3);
				recipe.AddIngredient((ItemID.HellstoneBar), 3);
				recipe.AddIngredient((ItemID.FallenStar), 1);
				recipe.AddTile(TileID.Anvils);
				recipe.Register();
			}
			{
				Recipe recipe = Mod.CreateRecipe(ModContent.ItemType<BloodyMaryHat>());
				recipe.AddIngredient(ItemID.OrangeBloodroot, 1);
				recipe.AddIngredient((ItemID.TheBrideHat), 1);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Mod.CreateRecipe(ModContent.ItemType<FallenPaladinsHelmet>());
				recipe.AddIngredient(ItemID.PixieDust);
				recipe.AddIngredient(ItemID.Ectoplasm);
				recipe.AddIngredient(ItemID.HellstoneBar, 2);
				recipe.AddIngredient((ItemID.HallowedBar), 2);
				recipe.AddTile(TileID.MythrilAnvil);
				recipe.Register();
			}
			{
				Recipe recipe = Mod.CreateRecipe(ModContent.ItemType<TerminalMask>());
				recipe.AddIngredient(ModContent.ItemType<Termipebbles>(), 5);
				recipe.AddIngredient(ItemID.SolarFlareHelmet);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Mod.CreateRecipe(ModContent.ItemType<TrueCosmicCone>());
				recipe.AddIngredient(ModContent.ItemType<CosmicCone>());
				recipe.AddIngredient(ItemID.FragmentNebula, 50);
				recipe.AddIngredient(ItemID.LunarBar, 1);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Mod.CreateRecipe(ModContent.ItemType<Items.Equips.Hats.Draedon.DraedonHelmet>());
				recipe.AddRecipeGroup(RecipeGroupID.IronBar, 6);
				recipe.AddTile(TileID.Anvils);
				recipe.Register();
			}
			//Legs
			{
				Recipe recipe = Mod.CreateRecipe(ModContent.ItemType<Items.Equips.Legs.Draedon.DraedonLeggings>());
				recipe.AddRecipeGroup(RecipeGroupID.IronBar, 8);
				recipe.AddTile(TileID.Anvils);
				recipe.Register();
			}
			{
				Recipe recipe = Mod.CreateRecipe(ModContent.ItemType<FallenPaladinsGreaves>());
				recipe.AddIngredient(ItemID.PixieDust);
				recipe.AddIngredient(ItemID.Ectoplasm, 2);
				recipe.AddIngredient(ItemID.HellstoneBar, 2);
				recipe.AddIngredient((ItemID.HallowedBar), 2);
				recipe.AddTile(TileID.MythrilAnvil);
				recipe.Register();
			}
			//Scarves
			{
				Recipe recipe = Mod.CreateRecipe(ModContent.ItemType<UniversalWormScarf>());
				recipe.AddIngredient(ModContent.ItemType<RapturedWormScarf>());
				recipe.AddIngredient(ModContent.ItemType<CosmicWormScarf>());
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			//Shirts
			{
				Recipe recipe = Mod.CreateRecipe(ModContent.ItemType<BloodyMaryDress>());
				recipe.AddIngredient(ItemID.OrangeBloodroot, 1);
				recipe.AddIngredient((ItemID.TheBrideDress), 1);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Mod.CreateRecipe(ModContent.ItemType<FallenPaladinsPlateMail>());
				recipe.AddIngredient(ItemID.PixieDust, 2);
				recipe.AddIngredient(ItemID.Ectoplasm, 2);
				recipe.AddIngredient(ItemID.HellstoneBar, 3);
				recipe.AddIngredient((ItemID.HallowedBar), 3);
				recipe.AddTile(TileID.MythrilAnvil);
				recipe.Register();
			}
			{
				Recipe recipe = Mod.CreateRecipe(ModContent.ItemType<Items.Equips.Shirts.Draedon.DraedonChestplate>());
				recipe.AddRecipeGroup(RecipeGroupID.IronBar, 12);
				recipe.AddTile(TileID.Anvils);
				recipe.Register();
			}
			//Transformations
			{
				Recipe recipe = Mod.CreateRecipe(ModContent.ItemType<ProtoRing>());
				recipe.AddRecipeGroup(RecipeGroupID.IronBar, 12);
				recipe.AddIngredient(ItemID.Wire, 200);
				recipe.AddTile(TileID.Anvils);
				recipe.Register();
			}
			{
				Recipe recipe = Mod.CreateRecipe(ModContent.ItemType<Signus>());
				recipe.AddIngredient(ModContent.ItemType<SigCape>());
				recipe.AddIngredient(ModContent.ItemType<SignusEmblem>());
				recipe.AddIngredient(ItemID.FragmentNebula, 30);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			//Wings
			{
				Recipe recipe = Mod.CreateRecipe(ModContent.ItemType<TerminalWings>());
				recipe.AddIngredient(ModContent.ItemType<Termipebbles>(), 5);
				recipe.AddIngredient(ItemID.WingsSolar);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Mod.CreateRecipe(ModContent.ItemType<GodspeedBoosters>());
				recipe.AddIngredient(ModContent.ItemType<PlaguePack>());
				recipe.AddIngredient(ItemID.FragmentNebula, 20);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Mod.CreateRecipe(ModContent.ItemType<WulfrumHelipack>());
				recipe.AddIngredient(ItemID.LuckyHorseshoe);
				recipe.AddRecipeGroup(RecipeGroupID.IronBar, 12);
				recipe.AddIngredient(ItemID.Gel, 300);
				recipe.AddTile(TileID.Anvils);
				recipe.Register();
			}
			//Light pets
			{
				Recipe recipe = Mod.CreateRecipe(ModContent.ItemType<DarksunSigil>());
				recipe.AddIngredient(ModContent.ItemType<VanityCore>());
				recipe.AddIngredient(ItemID.Ectoplasm, 20);
				recipe.AddTile(TileID.MythrilAnvil);
				recipe.Register();
			}
			{
				Recipe recipe = Mod.CreateRecipe(ModContent.ItemType<NuclearFly>());
				recipe.AddIngredient(ModContent.ItemType<FROM>());
				recipe.AddIngredient(ModContent.ItemType<NukeFlyItem>());
				recipe.AddIngredient(ModContent.ItemType<NuclearFumes>(), 10);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Mod.CreateRecipe(ModContent.ItemType<PhantomJar>());
				recipe.AddIngredient(ItemID.WispinaBottle);
				recipe.AddIngredient(ItemID.FragmentNebula, 20);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Mod.CreateRecipe(ModContent.ItemType<SupJewel>());
				recipe.AddIngredient(ModContent.ItemType<DarksunSigil>());
				recipe.AddIngredient(ModContent.ItemType<HolyTorch>());
				recipe.AddIngredient(ModContent.ItemType<PhantomJar>());
				recipe.AddIngredient(ModContent.ItemType<CryoStick>());
				recipe.AddIngredient(ModContent.ItemType<ShuttleBalloon>());
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Mod.CreateRecipe(ModContent.ItemType<VanityCore>());
				recipe.AddIngredient(ModContent.ItemType<ChaosEssence>());
				recipe.AddIngredient(ModContent.ItemType<SkeetCrest>());
				recipe.AddIngredient(ItemID.Ectoplasm, 5);
				recipe.AddTile(TileID.MythrilAnvil);
				recipe.Register();
			}
			//Mounts
			{
				Recipe recipe = Mod.CreateRecipe(ModContent.ItemType<AuricCarKey>());
				recipe.AddIngredient(ModContent.ItemType<SilvaJeepItem>());
				recipe.AddIngredient(ModContent.ItemType<GodRiderItem>());
				recipe.AddIngredient(ModContent.ItemType<BloodstoneCarriageItem>());
				recipe.AddIngredient(ModContent.ItemType<ProfanedCycleItem>());
				recipe.AddIngredient(ItemID.LunarBar, 5);
				recipe.AddIngredient(ItemID.FragmentSolar, 20);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Mod.CreateRecipe(ModContent.ItemType<BloodstoneCarriageItem>());
				recipe.AddIngredient(ItemID.LawnMower);
				recipe.AddIngredient(ItemID.CarriageLantern);
				recipe.AddIngredient(ItemID.FragmentNebula, 20);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Mod.CreateRecipe(ModContent.ItemType<GodRiderItem>());
				recipe.AddIngredient(ItemID.PogoStick);
				recipe.AddIngredient(ItemID.FragmentNebula, 20);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Mod.CreateRecipe(ModContent.ItemType<ProfanedCycleItem>());
				recipe.AddIngredient(ModContent.ItemType<ProfanedFrame>());
				recipe.AddIngredient(ModContent.ItemType<ProfanedBattery>());
				recipe.AddIngredient(ModContent.ItemType<ProfanedWheels>());
				recipe.AddIngredient(ItemID.FragmentSolar, 5);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Mod.CreateRecipe(ModContent.ItemType<SilvaJeepItem>());
				recipe.AddIngredient(ItemID.GolfCart);
				recipe.AddIngredient(ItemID.FragmentVortex, 20);
				recipe.AddRecipeGroup(RecipeGroupID.IronBar, 20);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Mod.CreateRecipe(ModContent.ItemType<ShadowShedding>());
				recipe.AddIngredient(ItemID.DemoniteBar, 50);
				recipe.AddIngredient(ItemID.SoulofFlight, 20);
				recipe.AddTile(TileID.MythrilAnvil);
				recipe.Register();
			}
			{
				Recipe recipe = Mod.CreateRecipe(ModContent.ItemType<PopUpShop>());
				recipe.AddIngredient(ItemID.GoldCoin);
				recipe.AddIngredient(ItemID.LargeRuby);
				recipe.AddIngredient(ItemID.RopeCoil, 5);
				recipe.AddIngredient(ItemID.Bomb, 10);
				recipe.AddIngredient(ItemID.Gel, 20);
				recipe.AddTile(TileID.MythrilAnvil);
				recipe.Register();
			}
			//Pets
			{
				Recipe recipe = Mod.CreateRecipe(ModContent.ItemType<AuricBottle>());
				recipe.AddIngredient(ModContent.ItemType<InkyArtifact>());
				recipe.AddIngredient(ItemID.PlatinumCoin);
				recipe.AddIngredient(ItemID.GoldBar, 200);
				recipe.AddTile(TileID.Anvils);
				recipe.Register();
			}
			{
				Recipe recipe = Mod.CreateRecipe(ModContent.ItemType<InkyArtifact>());
				recipe.AddIngredient(ModContent.ItemType<Pollution>());
				recipe.AddIngredient(ItemID.SilverCoin, 50);
				recipe.AddIngredient(ItemID.LeadBar, 100);
				recipe.AddTile(TileID.Anvils);
				recipe.Register();
			}
			{
				Recipe recipe = Mod.CreateRecipe(ModContent.ItemType<CalamitousSoulArtifact>());
				recipe.AddIngredient(ModContent.ItemType<CalArtifact>());
				recipe.AddIngredient(ItemID.FragmentSolar, 50);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Mod.CreateRecipe(ModContent.ItemType<CalArtifact>());
				recipe.AddRecipeGroup(RecipeGroupID.IronBar, 40);
				recipe.AddIngredient(ItemID.Ectoplasm, 20);
				recipe.AddTile(TileID.MythrilAnvil);
				recipe.Register();
			}
			{
				Recipe recipe = Mod.CreateRecipe(ModContent.ItemType<CrushedCore>());
				recipe.AddIngredient(ItemID.HallowedBar, 20);
				recipe.AddIngredient(ItemID.AncientBattleArmorMaterial, 5);
				recipe.AddTile(ModContent.TileType<BelchingCoralPlaced>());
				recipe.Register();
			}
			{
				Recipe recipe = Mod.CreateRecipe(ModContent.ItemType<Ectogasm>());
				recipe.AddIngredient(ModContent.ItemType<SigCloth>());
				recipe.AddIngredient(ModContent.ItemType<ImpureStick>());
				recipe.AddIngredient(ItemID.Ectoplasm, 20);
				recipe.AddIngredient(ItemID.FragmentStardust, 20);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Mod.CreateRecipe(ModContent.ItemType<FluffyFur>());
				recipe.AddIngredient(ModContent.ItemType<SparrowMeat>());
				recipe.AddIngredient(ItemID.SolarEruption);
				recipe.AddIngredient(ItemID.OrichalcumHalberd);
				recipe.AddIngredient(ItemID.PalladiumSword);
				recipe.AddIngredient(ItemID.DeathSickle);
				recipe.AddIngredient(ItemID.SpectreStaff);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Mod.CreateRecipe(ModContent.ItemType<FROM>());
				recipe.AddIngredient(ModContent.ItemType<BubbleGum>());
				recipe.AddIngredient(ModContent.ItemType<PlagueFrogItem>());
				recipe.AddRecipeGroup(RecipeGroupID.IronBar, 40);
				recipe.AddTile(TileID.MythrilAnvil);
				recipe.Register();
			}
			{
				Recipe recipe = Mod.CreateRecipe(ModContent.ItemType<GoozmaPetItem>());
				recipe.AddIngredient(ModContent.ItemType<ImpureStick>());
				recipe.AddIngredient(ItemID.Gel, 600);
				recipe.AddTile(TileID.Solidifier);
				recipe.Register();
			}
			{
				Recipe recipe = Mod.CreateRecipe(ModContent.ItemType<Rember>());
				recipe.AddIngredient(ModContent.ItemType<CorrodedCleaver>());
				recipe.AddIngredient(ItemID.FragmentStardust, 40);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Mod.CreateRecipe(ModContent.ItemType<SeaCoin>());
				recipe.AddIngredient(ModContent.ItemType<DriedMandible>());
				recipe.AddIngredient(ModContent.ItemType<AquaticHide>());
				recipe.AddIngredient(ModContent.ItemType<NuclearFumes>(), 20);
				recipe.AddTile(TileID.MythrilAnvil);
				recipe.Register();
			}
			{
				Recipe recipe = Mod.CreateRecipe(ModContent.ItemType<TerminusStone>());
				recipe.AddIngredient(ModContent.ItemType<Termipebbles>(), 5);
				recipe.AddIngredient(ItemID.ZephyrFish);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Mod.CreateRecipe(ModContent.ItemType<SolarBun>());
				recipe.AddIngredient(ItemID.Bunny);
				recipe.AddIngredient(ItemID.FragmentSolar, 50);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Mod.CreateRecipe(ModContent.ItemType<VoodooGod>());
				recipe.AddIngredient(ModContent.ItemType<ShellScrap>());
				recipe.AddIngredient(ModContent.ItemType<VoidShard>());
				recipe.AddIngredient(ModContent.ItemType<SigCloth>());
				recipe.AddIngredient(ItemID.FragmentNebula, 50);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Mod.CreateRecipe(ModContent.ItemType<YharexsLetter>());
				recipe.AddIngredient(ModContent.ItemType<Termipebbles>(), 999);
				recipe.AddIngredient(ItemID.SlimeBanner, 30);
				recipe.AddIngredient(ItemID.FallenStar, 300);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Mod.CreateRecipe(ModContent.ItemType<Minihote>());
				recipe.AddIngredient(ModContent.ItemType<brimtulip>());
				recipe.AddIngredient(ModContent.ItemType<WetBubble>());
				recipe.AddIngredient(ModContent.ItemType<cloudcandy>());
				recipe.AddIngredient(ModContent.ItemType<SandBottle>());
				recipe.AddIngredient(ModContent.ItemType<SandPlush>());
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Mod.CreateRecipe(ModContent.ItemType<BejeweledSpike>());
				recipe.AddIngredient(ModContent.ItemType<AmberStone>());
				recipe.AddIngredient(ModContent.ItemType<AmethystStone>());
				recipe.AddIngredient(ModContent.ItemType<CrystalStone>());
				recipe.AddIngredient(ModContent.ItemType<DiamondStone>());
				recipe.AddIngredient(ModContent.ItemType<EmeraldStone>());
				recipe.AddIngredient(ModContent.ItemType<RubyStone>());
				recipe.AddIngredient(ModContent.ItemType<SapphireStone>());
				recipe.AddIngredient(ModContent.ItemType<TopazStone>());
				recipe.AddTile(TileID.MythrilAnvil);
				recipe.Register();
			}
			{
				Recipe recipe = Mod.CreateRecipe(ModContent.ItemType<ExoGemstone>());
				recipe.AddIngredient(ModContent.ItemType<OminousCore>());
				recipe.AddIngredient(ModContent.ItemType<GunmetalRemote>());
				recipe.AddIngredient(ModContent.ItemType<GeminiMarkImplants>());
				recipe.AddIngredient(ItemID.HallowedBar, 50);
				recipe.AddIngredient(ItemID.FragmentVortex, 50);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			//Plushies
			PlushRecipe(ModContent.ItemType<AnahitaPlushThrowable>(), ModContent.ItemType<AnahitaPlush>());
			PlushRecipe(ModContent.ItemType<ApolloPlushThrowable>(), ModContent.ItemType<ApolloPlush>());
			PlushRecipe(ModContent.ItemType<AquaticScourgePlushThrowable>(), ModContent.ItemType<AquaticScourgePlush>());
			PlushRecipe(ModContent.ItemType<AresPlushThrowable>(), ModContent.ItemType<AresPlush>());
			PlushRecipe(ModContent.ItemType<ArtemisPlushThrowable>(), ModContent.ItemType<ArtemisPlush>());
			PlushRecipe(ModContent.ItemType<AstrageldonPlushThrowable>(), ModContent.ItemType<AstrageldonPlush>());
			PlushRecipe(ModContent.ItemType<AstrumAureusPlushThrowable>(), ModContent.ItemType<AstrumAureusPlush>());
			PlushRecipe(ModContent.ItemType<AstrumDeusPlushThrowable>(), ModContent.ItemType<AstrumDeusPlush>());
			PlushRecipe(ModContent.ItemType<BrimstoneElementalPlushThrowable>(), ModContent.ItemType<BrimstoneElementalPlush>());
			PlushRecipe(ModContent.ItemType<BumblefuckPlushThrowable>(), ModContent.ItemType<BumblefuckPlush>());
			PlushRecipe(ModContent.ItemType<CalaFumoYeetable>(), ModContent.ItemType<CalamitasFumo>());
			PlushRecipe(ModContent.ItemType<CeaselessVoidPlushThrowable>(), ModContent.ItemType<CeaselessVoidPlush>());
			PlushRecipe(ModContent.ItemType<ClonePlushThrowable>(), ModContent.ItemType<ClonePlush>());
			PlushRecipe(ModContent.ItemType<CrabulonPlushThrowable>(), ModContent.ItemType<CrabulonPlush>());
			PlushRecipe(ModContent.ItemType<CryogenPlushThrowable>(), ModContent.ItemType<CryogenPlush>());
			PlushRecipe(ModContent.ItemType<DesertScourgePlushThrowable>(), ModContent.ItemType<DesertScourgePlush>());
			PlushRecipe(ModContent.ItemType<DevourerofGodsPlushThrowable>(), ModContent.ItemType<DevourerofGodsPlush>());
			PlushRecipe(ModContent.ItemType<DraedonPlushThrowable>(), ModContent.ItemType<DraedonPlush>());
			PlushRecipe(ModContent.ItemType<GiantClamPlushThrowable>(), ModContent.ItemType<GiantClamPlush>());
			PlushRecipe(ModContent.ItemType<HiveMindPlushThrowable>(), ModContent.ItemType<HiveMindPlush>());
			PlushRecipe(ModContent.ItemType<JaredPlushThrowable>(), ModContent.ItemType<JaredPlush>());
			PlushRecipe(ModContent.ItemType<LeviathanPlushThrowable>(), ModContent.ItemType<LeviathanPlush>());
			PlushRecipe(ModContent.ItemType<OldDukePlushThrowable>(), ModContent.ItemType<OldDukePlush>());
			PlushRecipe(ModContent.ItemType<PerforatorPlushThrowable>(), ModContent.ItemType<PerforatorPlush>());
			PlushRecipe(ModContent.ItemType<PlaguebringerGoliathPlushThrowable>(), ModContent.ItemType<PlaguebringerGoliathPlush>());
			PlushRecipe(ModContent.ItemType<PolterghastPlushThrowable>(), ModContent.ItemType<PolterghastPlush>());
			PlushRecipe(ModContent.ItemType<ProfanedGuardianPlushThrowable>(), ModContent.ItemType<ProfanedGuardianPlush>());
			PlushRecipe(ModContent.ItemType<ProvidencePlushThrowable>(), ModContent.ItemType<ProvidencePlush>());
			PlushRecipe(ModContent.ItemType<RavagerPlushThrowable>(), ModContent.ItemType<RavagerPlush>());
			PlushRecipe(ModContent.ItemType<SignusPlushThrowable>(), ModContent.ItemType<SignusPlush>());
			PlushRecipe(ModContent.ItemType<SlimeGodPlushThrowable>(), ModContent.ItemType<SlimeGodPlush>());
			PlushRecipe(ModContent.ItemType<StormWeaverPlushThrowable>(), ModContent.ItemType<StormWeaverPlush>());
			PlushRecipe(ModContent.ItemType<ThanatosPlushThrowable>(), ModContent.ItemType<ThanatosPlush>());
			PlushRecipe(ModContent.ItemType<YharonPlushThrowable>(), ModContent.ItemType<YharonPlush>());
			//Blueprints
			BlueprintRecipe(ItemID.PixieDust, ModContent.ItemType<AstrumAureusLog>());
			BlueprintRecipe(ItemID.BeetleHusk, ModContent.ItemType<BumblebirbLog>());
			BlueprintRecipe(ItemID.BrokenHeroSword, ModContent.ItemType<CalamitasLog>());
			BlueprintRecipe(ItemID.SoulofMight, ModContent.ItemType<DestroyerLog>());
			BlueprintRecipe(ItemID.FragmentNebula, ModContent.ItemType<DogLog>());
			BlueprintRecipe(ItemID.HellstoneBar, ModContent.ItemType<MurasamaLog>());
			BlueprintRecipe(ModContent.ItemType<Help>(), ModContent.ItemType<OrthoceraLog>());
			BlueprintRecipe(ItemID.ChlorophyteBar, ModContent.ItemType<PlagueLog>());
			BlueprintRecipe(ItemID.SoulofFright, ModContent.ItemType<PrimeLog>());
			BlueprintRecipe(ItemID.SoulofSight, ModContent.ItemType<TwinsLog>());
			BlueprintRecipe(ItemID.GoldBar, ModContent.ItemType<YharmorLog>());
			//Cages
			CageRecipe(ModContent.ItemType<AstJRItem>(), ItemID.Bottle, ModContent.ItemType<AstJar>());
			CageRecipe(ModContent.ItemType<BlightolemurItem>(), ModContent.ItemType<Items.Tiles.Plants.AstralOldPurple>(), ModContent.ItemType<BleamurPerch>());
			CageRecipe(ModContent.ItemType<IsopodItem>(), ItemID.Terrarium, ModContent.ItemType<IsopodTerrarium>(), ItemID.WaterBucket);
			CageRecipe(ModContent.ItemType<BlinkerItem>(), ItemID.Bottle, ModContent.ItemType<BlinkerInABottle>());
			CageRecipe(ModContent.ItemType<CrystalFlyItem>(), ItemID.Bottle, ModContent.ItemType<CrystalFlyJar>());
			CageRecipe(ModContent.ItemType<EyedolItem>(), ItemID.Chain, ModContent.ItemType<EyedolTerrarium>());
			CageRecipe(ModContent.ItemType<GAstJRItem>(), ItemID.Bottle, ModContent.ItemType<GAstJar>());
			CageRecipe(ModContent.ItemType<GoldenIsopodItem>(), ItemID.Terrarium, ModContent.ItemType<GoldenIsopodTerrarium>(), ItemID.WaterBucket);
			CageRecipe(ModContent.ItemType<GoldEyedolItem>(), ItemID.Chain, ModContent.ItemType<GoldEyedolTerrarium>());
			CageRecipe(ModContent.ItemType<GoldViolemurItem>(), ModContent.ItemType<Items.Tiles.Plants.MonolithPot>(), ModContent.ItemType<GoldViolemurMonolith>());
			CageRecipe(ModContent.ItemType<NukeFlyItem>(), ItemID.Bottle, ModContent.ItemType<NukeJar>());
			CageRecipe(ModContent.ItemType<OrthobabItem>(), ItemID.Bottle, ModContent.ItemType<OrthoJar>());
			CageRecipe(ModContent.ItemType<PlagueFrogItem>(), ItemID.Terrarium, ModContent.ItemType<PlagueFrogTerrarium>());
			CageRecipe(ModContent.ItemType<ProvFlyItem>(), ItemID.Bottle, ModContent.ItemType<ProvFlyJar>());
			CageRecipe(ModContent.ItemType<SandTurtleItem>(), ItemID.Terrarium, ModContent.ItemType<SandTurtleCage>());
			CageRecipe(ModContent.ItemType<GodSlayerSlugItem>(), ItemID.Terrarium, ModContent.ItemType<SlugTerrarium>());
			CageRecipe(ModContent.ItemType<SwearshroomItem>(), ItemID.Terrarium, ModContent.ItemType<SwearshroomCage>());
			CageRecipe(ModContent.ItemType<ViolemurItem>(), ModContent.ItemType<Items.Tiles.Plants.MonolithPot>(), ModContent.ItemType<ViolemurMonolith>());
			CageRecipe(ModContent.ItemType<XerocodileItem>(), ItemID.Terrarium, ModContent.ItemType<XerocodileCage>());
			//Statues
			StatueRecipe(ModContent.ItemType<EyedolItem>(), ModContent.ItemType<EyedolStatue>());
			StatueRecipe(ModContent.ItemType<IsopodItem>(), ModContent.ItemType<IsopodStatue>());
			StatueRecipe(ModContent.ItemType<NukeFlyItem>(), ModContent.ItemType<NukeFlyStatue>());
			StatueRecipe(ModContent.ItemType<PlagueFrogItem>(), ModContent.ItemType<PlagueFrogStatue>());
			StatueRecipe(ModContent.ItemType<ViolemurItem>(), ModContent.ItemType<ViolemurStatue>());
			//Monoliths
			MonolithRecipe(ItemID.FragmentNebula, ModContent.ItemType<DimensionalMonolith>(), TileID.LunarCraftingStation);
			MonolithRecipe(ItemID.FragmentSolar, ModContent.ItemType<UnholyMonolith>(), TileID.LunarCraftingStation);
			MonolithRecipe(ItemID.LunarBar, ModContent.ItemType<InfernalMonolith>(), TileID.LunarCraftingStation);
			MonolithRecipe(ItemID.ChlorophyteBar, ModContent.ItemType<PlagueMonolith>(), TileID.MythrilAnvil);
			MonolithRecipe(ItemID.Ectoplasm, ModContent.ItemType<CalamitousMonolith>(), TileID.MythrilAnvil);
			MonolithRecipe(ModContent.ItemType<Termipebbles>(), ModContent.ItemType<TerminusShrine>(), TileID.LunarCraftingStation);
			//Misc furniture
			{
				Recipe recipe = Mod.CreateRecipe(ModContent.ItemType<AuricTrashCan>());
				recipe.AddIngredient(ItemID.TrashCan);
				recipe.AddIngredient(ItemID.GoldBar, 50);
				recipe.AddIngredient(ItemID.FragmentSolar, 4);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Mod.CreateRecipe(ModContent.ItemType<CosmiliteChairEX>());
				recipe.AddIngredient(ItemID.NebulaChair, 2);
				recipe.AddIngredient(ItemID.FragmentStardust, 4);
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Mod.CreateRecipe(ModContent.ItemType<Hesfine>());
				recipe.AddIngredient(ModContent.ItemType<Help>());
				recipe.AddIngredient(ModContent.ItemType<NuclearFumes>(), 50);
				recipe.AddTile(TileID.MythrilAnvil);
				recipe.Register();
			}
			{
				Recipe recipe = Mod.CreateRecipe(ModContent.ItemType<SchematicDisplay>());
				recipe.AddRecipeGroup(RecipeGroupID.IronBar, 6);
				recipe.AddIngredient(ItemID.Wire, 20);
				recipe.AddTile(TileID.Anvils);
				recipe.Register();
			}
			{
				Recipe recipe = Mod.CreateRecipe(ModContent.ItemType<TerminusShrine2>());
				recipe.AddIngredient(ModContent.ItemType<TerminusShrine>());
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}
			{
				Recipe recipe = Mod.CreateRecipe(ModContent.ItemType<TerminusShrine3>());
				recipe.AddIngredient(ModContent.ItemType<TerminusShrine2>());
				recipe.AddTile(TileID.LunarCraftingStation);
				recipe.Register();
			}


		}

		void PlushRecipe(int throwplush, int placeplush)
        {
            {
				Recipe recipe = Mod.CreateRecipe(throwplush);
				recipe.AddIngredient(placeplush);
				recipe.Register();
			}
			{
				Recipe recipe = Mod.CreateRecipe(placeplush);
				recipe.AddIngredient(throwplush);
				recipe.Register();
			}
		}
		void BlueprintRecipe(int ingredient, int result)
		{
			{
				Recipe recipe = Mod.CreateRecipe(result);
				recipe.AddIngredient(ingredient);
				recipe.AddIngredient(ItemID.Wire, 50);
				recipe.AddTile(TileID.Anvils);
				recipe.Register();
			}
		}

		void CageRecipe(int critter, int container, int result, int extra = 0, int extramt = 1)
		{
			Recipe recipe = Mod.CreateRecipe(result);
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
			Recipe recipe = Mod.CreateRecipe(result);
			recipe.AddIngredient(critter, 5);
			recipe.AddIngredient(ItemID.StoneBlock, 50);
			recipe.Register();
		}

		void MonolithRecipe(int ingredient, int result, int station)
		{
			Recipe recipe = Mod.CreateRecipe(result);
			recipe.AddIngredient(ingredient, 15);
			recipe.AddTile(station);
			recipe.Register();
		}
	}
}