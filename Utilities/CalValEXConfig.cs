using Microsoft.Xna.Framework;
using System;
using System.ComponentModel;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader.Config;

namespace CalValEX
{
    [BackgroundColor(49, 32, 36, 216)]
    public class CalValEXConfig : ModConfig
    {
        public static CalValEXConfig Instance;
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Header("$Mods.CalValEX.Config.Drops")]
        [Label("$Mods.CalValEX.Config.Dr0ps.Label")]
        [BackgroundColor(192, 54, 64, 192)]
        [DefaultValue(false)]
        [Tooltip("DropsGenTip")]
        public bool DisableVanityDrops { get; set; }

        [Label("$Mods.CalValEX.Config.Bl0cks.Label")]
        [BackgroundColor(192, 54, 64, 192)]
        [DefaultValue(false)]
        [Tooltip("Makes it so that bosses and their bags no longer drop blocks")]
        public bool ConfigBossBlocks { get; set; }


        [BackgroundColor(192, 54, 64, 192)]
        [DefaultValue(false)]
        [Tooltip("Makes a certain pet a lot larger when true")]
        public bool FatDog { get; set; }

        [Label("$Mods.CalValEX.Config.Sup.Label")]
        [BackgroundColor(192, 54, 64, 192)]
        [DefaultValue(false)]
        [Tooltip("Allows the Superstitious Jewel to summon the 11 ingredient pets used to craft it")]
        public bool SupCombo { get; set; }

        [Label("$Mods.CalValEX.Config.Birb.Label")]
        [BackgroundColor(192, 54, 64, 192)]
        [DefaultValue(false)]
        [Tooltip("Disables the easter egg caused by the Dragonball pet")]
        public bool DragonballName { get; set; }

        [Label("$Mods.CalValEX.Config.Polt.Label")]
        [BackgroundColor(192, 54, 64, 192)]
        [DefaultValue(false)]
        [Tooltip("Makes it so that the Toy Scythe's pet always uses its default skin")]
        public bool Polterskin { get; set; }

        [Label("$Mods.CalValEX.Config.Bark.Label")]
        [BackgroundColor(192, 54, 64, 192)]
        [DefaultValue(false)]
        [Tooltip("Makes it so that the Pitbull pet doesn't bark at rare enemies")]
        public bool Pitbul { get; set; }

        [BackgroundColor(192, 54, 64, 192)]
        [DefaultValue(false)]
        [Tooltip("Prevents the Oracle and Jelly Priestess from spawning")]
        public bool TownNPC { get; set; }

        [Label("$Mods.CalValEX.Config.Isopod.Label")]
        [BackgroundColor(192, 54, 64, 192)]
        [DefaultValue(false)]
        [Tooltip("Makes it so that Abyssal Isopods have max bait power at all times")]
        public bool IsopodBait { get; set; }

        [Label("$Mods.CalValEX.Config.Critters.Label")]
        [BackgroundColor(192, 54, 64, 192)]
        [DefaultValue(false)]
        [Tooltip("Makes it so that all Calamity's Vanities critters no longer spawn naturally")]
        public bool CritterSpawns { get; set; }

        [Label("Disable Mount Nerf")]
        [BackgroundColor(192, 54, 64, 192)]
        [DefaultValue(false)]
        [Tooltip("Disables the stat cripple which ground mounts give")]
        public bool GroundMountLol { get; set; }

        [Label("$Mods.CalValEX.Config.DRP.Label")]
        [BackgroundColor(192, 54, 64, 192)]
        [DefaultValue(true)]
        [ReloadRequired()]
        [Tooltip("Whether or not to initialize the Discord Rich Presence addons for the Discord Rich Presence mod by Purplefin Neptuna.\nRequires that mod to be active in order to do anything.")]
        public bool DiscordRichPresence { get; set; }

        [BackgroundColor(192, 54, 64, 192)]
        [DefaultValue(false)]
        [Tooltip("Recommended for Host & Play or hosting server on same machine you play on.\n" +
            "If not enabled, all users can make changes to the config")]
        public bool OwnerOnly { get; set; }

        [Label("$Mods.CalValEX.Config.HerosPerm.Label")]
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
