using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Capture;
using Terraria.ModLoader;

namespace CalValEX.Biomes
{
	// Shows setting up two basic biomes. For a more complicated example, please request.
	public class AstralBlight : ModBiome
	{
		//public override bool IsPrimaryBiome => true; // Allows this biome to impact NPC prices

		// Select all the scenery
		public override ModWaterStyle WaterStyle => ModContent.Find<ModWaterStyle>("CalValEX/AstralWaterStyle"); // Sets a water style for when inside this biome
		public override ModSurfaceBackgroundStyle SurfaceBackgroundStyle => ModContent.Find<ModSurfaceBackgroundStyle>("CalValEX/AstralBG");
		public override ModUndergroundBackgroundStyle UndergroundBackgroundStyle => ModContent.Find<ModUndergroundBackgroundStyle>("CalValEX/AstralUndergroundBG");

		public override CaptureBiome.TileColorStyle TileColorStyle => CaptureBiome.TileColorStyle.Corrupt;

		// Select Music
		public override int Music => Main.LocalPlayer.ZoneRockLayerHeight ? MusicLoader.GetMusicSlot(Mod, "Sounds/Music/AstralUnderground") : MusicLoader.GetMusicSlot(Mod, "Sounds/Music/AstralBlight");

		// Populate the Bestiary Filter
		public override string BestiaryIcon => "CalValEX/Biomes/AstralBlightIcon";
		public override string BackgroundPath => "CalValEX/Biomes/AstralMap";
		public override Color? BackgroundColor => Color.Magenta;
		//public override string Name => "Astral Blight";

		// Use SetStaticDefaults to assign the display name
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Astral Blight");
		}

		// Calculate when the biome is active.
		public override bool IsBiomeActive(Player player)
		{
			return CalValEXWorld.astralTiles >= 200;
		}

		public override SceneEffectPriority Priority => SceneEffectPriority.BiomeHigh;

		public override void SpecialVisuals(Player player, bool isActive)
        {
			Terraria.Graphics.Effects.SkyManager.Instance.Activate("CalValEX:AstralBiome");
		}
    }
}