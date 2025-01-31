using CalValEX.CalamityID;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;


namespace CalValEX
{
    public class CalValEXConditions
    {
        public static Condition calamity = new(Language.GetTextValue("Mods.CalValEX.Conditions.CalamityActive"), () => CalValEX.CalamityActive);
        // Boss downed conditions
        public static Condition clam = new(Language.GetTextValue("Mods.CalValEX.Conditions.ClamDefeated"), () => CalValEX.CalamityActive ? (bool)CalValEX.Calamity.Call("GetBossDowned", "giantclam") : NPC.downedBoss1);
        public static Condition ds = new(Language.GetTextValue("Mods.CalValEX.Conditions.Scourge1Defeated"), () => CalValEX.CalamityActive ? (bool)CalValEX.Calamity.Call("GetBossDowned", "desertscourge") : NPC.downedBoss1);
        public static Condition crab = new(Language.GetTextValue("Mods.CalValEX.Conditions.CrabulonDefeated"), () => CalValEX.CalamityActive ? (bool)CalValEX.Calamity.Call("GetBossDowned", "crabulon") : NPC.downedBoss2);
        public static Condition hive = new(Language.GetTextValue("Mods.CalValEX.Conditions.HiveMindDefeated"), () => CalValEX.CalamityActive ? (bool)CalValEX.Calamity.Call("GetBossDowned", "hivemind") : NPC.downedBoss2);
        public static Condition perf = new(Language.GetTextValue("Mods.CalValEX.Conditions.PerfsDefeated"), () => CalValEX.CalamityActive ? (bool)CalValEX.Calamity.Call("GetBossDowned", "perforators") : NPC.downedBoss2);
        public static Condition sg = new(Language.GetTextValue("Mods.CalValEX.Conditions.SlimeGodDefeated"), () => CalValEX.CalamityActive ? (bool)CalValEX.Calamity.Call("GetBossDowned", "slimegod") : NPC.downedBoss3);
        public static Condition cirno = new(Language.GetTextValue("Mods.CalValEX.Conditions.CirnogenDefeated"), () => CalValEX.CalamityActive ? (bool)CalValEX.Calamity.Call("GetBossDowned", "cryogen") : Main.hardMode);
        public static Condition aqua = new(Language.GetTextValue("Mods.CalValEX.Conditions.Scourge2Defeated"), () => CalValEX.CalamityActive ? (bool)CalValEX.Calamity.Call("GetBossDowned", "aquaticscourge") : Main.hardMode);
        public static Condition brim = new(Language.GetTextValue("Mods.CalValEX.Conditions.BrimEleDefeated"), () => CalValEX.CalamityActive ? (bool)CalValEX.Calamity.Call("GetBossDowned", "brimstoneelemental") : Main.hardMode);
        public static Condition cala = new(Language.GetTextValue("Mods.CalValEX.Conditions.CalCloneDefeated"), () => CalValEX.CalamityActive ? (bool)CalValEX.Calamity.Call("GetBossDowned", "calamitasclone") : NPC.downedMechBossAny);
        public static Condition oreo = new(Language.GetTextValue("Mods.CalValEX.Conditions.AureusDefeated"), () => CalValEX.CalamityActive ? (bool)CalValEX.Calamity.Call("GetBossDowned", "astrumaureus") : NPC.downedPlantBoss);
        public static Condition lev = new(Language.GetTextValue("Mods.CalValEX.Conditions.LevAnaDefeated"), () => CalValEX.CalamityActive ? (bool)CalValEX.Calamity.Call("GetBossDowned", "leviathan") : NPC.downedPlantBoss);
        public static Condition pb = new(Language.GetTextValue("Mods.CalValEX.Conditions.GoliathDefeated"), () => CalValEX.CalamityActive ? (bool)CalValEX.Calamity.Call("GetBossDowned", "plaguebringergoliath") : NPC.downedGolemBoss);
        public static Condition rav = new(Language.GetTextValue("Mods.CalValEX.Conditions.RavagerDefeated"), () => CalValEX.CalamityActive ? (bool)CalValEX.Calamity.Call("GetBossDowned", "ravager") : NPC.downedGolemBoss);
        public static Condition deus = new(Language.GetTextValue("Mods.CalValEX.Conditions.DeusDefeated"), () => CalValEX.CalamityActive ? (bool)CalValEX.Calamity.Call("GetBossDowned", "astrumdeus") : NPC.downedAncientCultist);
        public static Condition donut = new(Language.GetTextValue("Mods.CalValEX.Conditions.GuardsDefeated"), () => CalValEX.CalamityActive ? (bool)CalValEX.Calamity.Call("GetBossDowned", "profanedguardians") : NPC.downedQueenSlime);
        public static Condition birb = new(Language.GetTextValue("Mods.CalValEX.Conditions.FollyDefeated"), () => CalValEX.CalamityActive ? (bool)CalValEX.Calamity.Call("GetBossDowned", "dragonfolly") : NPC.downedGolemBoss);
        public static Condition prov = new(Language.GetTextValue("Mods.CalValEX.Conditions.ProviDefeated"), () => CalValEX.CalamityActive ? (bool)CalValEX.Calamity.Call("GetBossDowned", "providence") : NPC.downedEmpressOfLight);
        public static Condition weavie = new(Language.GetTextValue("Mods.CalValEX.Conditions.WeaverDefeated"), () => CalValEX.CalamityActive ? (bool)CalValEX.Calamity.Call("GetBossDowned", "stormweaver") : NPC.downedMechBoss2);
        public static Condition toaster = new(Language.GetTextValue("Mods.CalValEX.Conditions.VoidDefeated"), () => CalValEX.CalamityActive ? (bool)CalValEX.Calamity.Call("GetBossDowned", "ceaselessvoid") : NPC.downedMechBoss1);
        public static Condition siggy = new(Language.GetTextValue("Mods.CalValEX.Conditions.SignusDefeated"), () => CalValEX.CalamityActive ? (bool)CalValEX.Calamity.Call("GetBossDowned", "signus") : NPC.downedMechBoss3);
        public static Condition polt = new(Language.GetTextValue("Mods.CalValEX.Conditions.PolterDefeated"), () => CalValEX.CalamityActive ? (bool)CalValEX.Calamity.Call("GetBossDowned", "polterghast") : NPC.downedPlantBoss);
        public static Condition boomer = new(Language.GetTextValue("Mods.CalValEX.Conditions.OldDukeDefeated"), () => CalValEX.CalamityActive ? (bool)CalValEX.Calamity.Call("GetBossDowned", "oldduke") : NPC.downedFishron);
        public static Condition dog = new(Language.GetTextValue("Mods.CalValEX.Conditions.DogDefeated"), () => CalValEX.CalamityActive ? (bool)CalValEX.Calamity.Call("GetBossDowned", "devourerofgods") : NPC.downedMoonlord);
        public static Condition yharon = new(Language.GetTextValue("Mods.CalValEX.Conditions.YharonDefeated"), () => CalValEX.CalamityActive ? (bool)CalValEX.Calamity.Call("GetBossDowned", "yharon") : NPC.downedFishron);
        public static Condition exo = new(Language.GetTextValue("Mods.CalValEX.Conditions.ExosDefeated"), () => CalValEX.CalamityActive ? (bool)CalValEX.Calamity.Call("GetBossDowned", "draedon") : NPC.downedMechBossAny);
        public static Condition scal = new(Language.GetTextValue("Mods.CalValEX.Conditions.SCalDefeated"), () => CalValEX.CalamityActive ? (bool)CalValEX.Calamity.Call("GetBossDowned", "scal") : NPC.downedAncientCultist);
        // Misc downed conditions
        public static Condition acid = new(Language.GetTextValue("Mods.CalValEX.Conditions.AcidGeneral"), () => CalValEX.CalamityActive ? (CalValEX.InCalamityBiome(Main.LocalPlayer, "SulphurousSeaBiome") || (bool)CalValEX.Calamity.Call("GetBossDowned", "acidrainscourge")) : false);
        public static Condition evil = new(Language.GetTextValue("Mods.CalValEX.Conditions.Evil2Defeated"), () => CalValEX.CalamityActive ? ((bool)CalValEX.Calamity.Call("GetBossDowned", "hivemind") || (bool)CalValEX.Calamity.Call("GetBossDowned", "perforators")) : false);
        public static Condition nugget = new(Language.GetTextValue("Mods.CalValEX.Conditions.NuggetsSpawn"), () => CalValEX.CalamityActive ? ((Main.BestiaryDB.GetCompletedPercentByMod(CalValEX.Calamity) > 0.365 && Main.GetBestiaryProgressReport().CompletionPercent > 0.324) || (bool)CalValEX.Calamity.Call("GetBossDowned", "dragonfolly")) : (Main.GetBestiaryProgressReport().CompletionPercent > 0.324));
        // Biome conditions
        public static Condition dungeon = new(Language.GetTextValue("Mods.CalValEX.Conditions.DungeonBiome"), () => CalValEXWorld.dungeontiles > 22 || Main.LocalPlayer.ZoneDungeon);
        public static Condition ass = new(Language.GetTextValue("Mods.CalValEX.Conditions.BlightBiome"), () => Main.LocalPlayer.InModBiome<Biomes.AstralBlight>());
        public static Condition sammy = new(Language.GetTextValue("Mods.CalValEX.Conditions.UnderLabBiome"), () => CalValEXWorld.hellTiles > 20 && Main.LocalPlayer.ZoneUnderworldHeight);
        public static Condition jun = new(Language.GetTextValue("Mods.CalValEX.Conditions.JungleLabBiome"), () => CalValEXWorld.jungleTiles > 20 && Main.LocalPlayer.ZoneJungle);
        public static Condition sulph = new(Language.GetTextValue("Mods.CalValEX.Conditions.SulphurousSeaBiome"), () => CalValEX.CalamityActive ? CalValEX.InCalamityBiome(Main.LocalPlayer, "SulphurousSeaBiome") : false);
        // NPC conditions
        public static Condition bandit = new(Language.GetTextValue("Mods.CalValEX.Conditions.BanditReal"), () => CalValEX.CalamityActive ? NPC.AnyNPCs(CalNPCID.THIEF) : NPC.AnyNPCs(NPCID.Golfer));
        public static Condition perma = new(Language.GetTextValue("Mods.CalValEX.Conditions.ArchmageReal"), () => CalValEX.CalamityActive ? NPC.AnyNPCs(CalNPCID.DILF) : NPC.AnyNPCs(NPCID.Wizard));
    }
}