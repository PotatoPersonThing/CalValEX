//using CalamityMod.UI;
using System.ComponentModel;
using System.Runtime.Serialization;
using Terraria;
using Terraria.ModLoader.Config;

namespace CalValEX
{
	[Label("Config")]
	[BackgroundColor(237, 31, 151, 237)]
	public class CalValEXConfig : ModConfig
	{
		public static CalValEXConfig Instance;
		public override ConfigScope Mode => ConfigScope.ClientSide;

		[Header("Drops")]

		[Label("Disable All Drops")]
		[BackgroundColor(201, 97, 68, 201)]
		[DefaultValue(false)]
		[Tooltip("Disables all of the mod's direct drops")]
		public bool DisableVanityDrops { get; set; }

		[Label("Disable Boss Block Drops")]
		[BackgroundColor(201, 97, 68, 201)]
		[DefaultValue(false)]
		[Tooltip("Makes it so that bosses and their bags no longer drop blocks")]
		public bool ConfigBossBlocks { get; set; }

		[Header("Critters")]

		[Label("Disable Violemur Invinsibility")]
		[BackgroundColor(98, 167, 196, 98)]
		[DefaultValue(false)]
		[Tooltip("Makes it so that Violemurs can be damaged at all times")]
		public bool ViolemurDefense { get; set; }

		[Label("Disable Isopod Bait Scaling")]
		[BackgroundColor(98, 167, 196, 98)]
		[DefaultValue(false)]
		[Tooltip("Makes it so that Abyssal Isopods have max bait power at all times")]
		public bool IsopodBait { get; set; }

		[Label("Disable Critter Spawns")]
		[BackgroundColor(98, 167, 196, 98)]
		[DefaultValue(false)]
		[Tooltip("Makes it so that all Calamity's Vanities critters no longer spawn naturally")]
		public bool CritterSpawns { get; set; }

		[Header("Other")]

		[Label("Disable Mount Nerf")]
		[BackgroundColor(155, 181, 53, 155)]
		[DefaultValue(false)]
		[Tooltip("Disables the stat cripple which ground mounts give")]
		public bool GroundMountLol { get; set; }

		[Label("Disable Dragonball Easter Egg")]
		[BackgroundColor(155, 181, 53, 155)]
		[DefaultValue(false)]
		[Tooltip("Disables the easter egg caused by the Dragonball pet")]
		public bool DragonballName { get; set; }

		public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message) => true;
	}
}