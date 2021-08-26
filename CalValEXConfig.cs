using Microsoft.Xna.Framework;
using System;
using System.ComponentModel;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader.Config;

namespace CalValEX
{
    [Label("Config")]
    [BackgroundColor(192, 54, 64, 192)]
    public class CalValEXConfig : ModConfig
    {
        public static CalValEXConfig Instance;
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Header("Drops")]
        [Label("Disable All Drops")]
        [BackgroundColor(192, 54, 64, 192)]
        [DefaultValue(false)]
        [Tooltip("Disables all of the mod's direct drops")]
        public bool DisableVanityDrops { get; set; }

        [Label("Disable Boss Block Drops")]
        [BackgroundColor(192, 54, 64, 192)]
        [DefaultValue(false)]
        [Tooltip("Makes it so that bosses and their bags no longer drop blocks")]
        public bool ConfigBossBlocks { get; set; }

        [Header("Pets")]
        [Label("True Size")]
        [BackgroundColor(192, 54, 64, 192)]
        [DefaultValue(false)]
        [Tooltip("Makes a certain pet a lot larger when true")]
        public bool FatDog { get; set; }

        [Label("Superstitious Spirit Parade")]
        [BackgroundColor(192, 54, 64, 192)]
        [DefaultValue(false)]
        [Tooltip("Allows the Superstitious Jewel to summon the 11 ingredient pets used to craft it")]
        public bool SupCombo { get; set; }

        [Label("Disable Dragonball Easter Egg")]
        [BackgroundColor(192, 54, 64, 192)]
        [DefaultValue(false)]
        [Tooltip("Disables the easter egg caused by the Dragonball pet")]
        public bool DragonballName { get; set; }

        [Header("NPCs")]
        [Label("Disable Town NPCs")]
        [BackgroundColor(192, 54, 64, 192)]
        [DefaultValue(false)]
        [Tooltip("Prevents the Oracle and Jelly Priestess from spawning")]
        public bool TownNPC { get; set; }

        [Label("Disable Violemur Invincibility")]
        [BackgroundColor(192, 54, 64, 192)]
        [DefaultValue(false)]
        [Tooltip("Makes it so that Violemurs can be damaged at all times")]
        public bool ViolemurDefense { get; set; }

        [Label("Disable Isopod Bait Scaling")]
        [BackgroundColor(192, 54, 64, 192)]
        [DefaultValue(false)]
        [Tooltip("Makes it so that Abyssal Isopods have max bait power at all times")]
        public bool IsopodBait { get; set; }

        [Label("Disable Critter Spawns")]
        [BackgroundColor(192, 54, 64, 192)]
        [DefaultValue(false)]
        [Tooltip("Makes it so that all Calamity's Vanities critters no longer spawn naturally")]
        public bool CritterSpawns { get; set; }

        [Header("Other")]
        [Label("Disable Mount Nerf")]
        [BackgroundColor(192, 54, 64, 192)]
        [DefaultValue(false)]
        [Tooltip("Disables the stat cripple which ground mounts give")]
        public bool GroundMountLol { get; set; }

        [Label("Disable Vanity Elementals")]
        [BackgroundColor(192, 54, 64, 192)]
        [DefaultValue(false)]
        [Tooltip("Disables Heart of the Elements from spawning its Elementals while in vanity slots")]
        public bool HeartVanity { get; set; }

        [Header("Config Access")]
        [Label("Enable Server Owner Exclusive Config Access")]
        [BackgroundColor(192, 54, 64, 192)]
        [DefaultValue(false)]
        [Tooltip("Recommended for Host & Play or hosting server on same machine you play on.\n" +
            "If not enabled, all users can make changes to the config")]
        public bool OwnerOnly { get; set; }

        [Label("Enable Hero's Mod Config Changes via Permission System")]
        [BackgroundColor(192, 54, 64, 192)]
        [DefaultValue(false)]
        [Tooltip("For those that use Heros Mod in multiplayer.\n" +
            "If not enabled, all users can make changes to the config")]
        public bool HerosPerm { get; set; }

        /// <summary>
        /// Checks to see if the player is the current server host. Thanks Jopojelly.
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static bool IsPlayerLocalServerOwner(Player player)
        {
            if (Main.netMode == 1)
            {
                return Netplay.Connection.Socket.GetRemoteAddress().IsLocalHost();
            }

            for (int plr = 0; plr < Main.maxPlayers; plr++)
                if (Netplay.Clients[plr].State == 10 && Main.player[plr] == player && Netplay.Clients[plr].Socket.GetRemoteAddress().IsLocalHost())
                    return true;
            return false;
        }

        public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message)
        {
            string accept = "Your changes have been accepted.";

            if (OwnerOnly && IsPlayerLocalServerOwner(Main.player[whoAmI]))
            {
                message = accept;
                return true;
            }
            else if (OwnerOnly && CalValEX.instance.herosmod == null)
            {
                message = "Only the server host can change the config.";
                return false;
            }

            if (HerosPerm && CalValEX.instance.herosmod != null)
            {
                if (CalValEX.instance.herosmod.Call("HasPermission", whoAmI, CalValEX.heropermission) is bool result && result)
                {
                    message = accept;
                    return true;
                }
                message = "You do not have proper the permission assigned.";
                return false;
            }

            message = accept;
            return true;
        }
    }
}