using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace CalValEX
{
    public class CalValEXConditions
    {
        public static Condition calamity = new("While the Calamity Mod is active", () => CalValEX.CalamityActive);
        // Boss downed conditions
        public static Condition clam = new("After Giant Clam has been defeated", () => CalValEX.CalamityActive ? (bool)CalValEX.Calamity.Call("GetBossDowned", "giantclam") : NPC.downedBoss1);
        public static Condition ds = new("After Desert Scourge has been defeated", () => CalValEX.CalamityActive ? (bool)CalValEX.Calamity.Call("GetBossDowned", "desertscourge") : NPC.downedBoss1);
        public static Condition crab = new("After Crabulon has been defeated", () => CalValEX.CalamityActive ? (bool)CalValEX.Calamity.Call("GetBossDowned", "crabulon") : NPC.downedBoss2);
        public static Condition hive = new("After The Hive Mind has been defeated", () => CalValEX.CalamityActive ? (bool)CalValEX.Calamity.Call("GetBossDowned", "hivemind") : NPC.downedBoss2);
        public static Condition perf = new("After The Perforators have been defeated", () => CalValEX.CalamityActive ? (bool)CalValEX.Calamity.Call("GetBossDowned", "perforators") : NPC.downedBoss2);
        public static Condition sg = new("After Slime God has been defeated", () => CalValEX.CalamityActive ? (bool)CalValEX.Calamity.Call("GetBossDowned", "slimegod") : NPC.downedBoss3);
        public static Condition cirno = new("After Cryogen has been defeated", () => CalValEX.CalamityActive ? (bool)CalValEX.Calamity.Call("GetBossDowned", "cryogen") : Main.hardMode);
        public static Condition aqua = new("After Aquatic Scourge has been defeated", () => CalValEX.CalamityActive ? (bool)CalValEX.Calamity.Call("GetBossDowned", "aquaticscourge") : Main.hardMode);
        public static Condition brim = new("After Brimstone Elemental has been defeated", () => CalValEX.CalamityActive ? (bool)CalValEX.Calamity.Call("GetBossDowned", "brimstoneelemental") : Main.hardMode);
        public static Condition cala = new("After Calamitas Clone has been defeated", () => CalValEX.CalamityActive ? (bool)CalValEX.Calamity.Call("GetBossDowned", "calamitasclone") : NPC.downedMechBossAny);
        public static Condition oreo = new("After Astrum Aureus has been defeated", () => CalValEX.CalamityActive ? (bool)CalValEX.Calamity.Call("GetBossDowned", "astrumaureus") : NPC.downedPlantBoss);
        public static Condition lev = new("After Leviathan and Anahita have been defeated", () => CalValEX.CalamityActive ? (bool)CalValEX.Calamity.Call("GetBossDowned", "leviathan") : NPC.downedPlantBoss);
        public static Condition pb = new("After Calamitas has been defeated", () => CalValEX.CalamityActive ? (bool)CalValEX.Calamity.Call("GetBossDowned", "plaguebringergoliath") : NPC.downedGolemBoss);
        public static Condition rav = new("After Ravager has been defeated", () => CalValEX.CalamityActive ? (bool)CalValEX.Calamity.Call("GetBossDowned", "ravager") : NPC.downedGolemBoss);
        public static Condition deus = new("After Astrum Deus has been defeated", () => CalValEX.CalamityActive ? (bool)CalValEX.Calamity.Call("GetBossDowned", "astrumdeus") : NPC.downedAncientCultist);
        public static Condition donut = new("After the Profaned Guardians have been defeated", () => CalValEX.CalamityActive ? (bool)CalValEX.Calamity.Call("GetBossDowned", "profanedguardians") : NPC.downedQueenSlime);
        public static Condition birb = new("After The Dragonfolly has been defeated", () => CalValEX.CalamityActive ? (bool)CalValEX.Calamity.Call("GetBossDowned", "dragonfolly") : NPC.downedGolemBoss);
        public static Condition prov = new("After Providence has been defeated", () => CalValEX.CalamityActive ? (bool)CalValEX.Calamity.Call("GetBossDowned", "providence") : NPC.downedEmpressOfLight);
        public static Condition weavie = new("After Storm Weaver has been defeated", () => CalValEX.CalamityActive ? (bool)CalValEX.Calamity.Call("GetBossDowned", "stormweaver") : NPC.downedMechBoss2);
        public static Condition toaster = new("After Ceaseless Void has been defeated", () => CalValEX.CalamityActive ? (bool)CalValEX.Calamity.Call("GetBossDowned", "ceaselessvoid") : NPC.downedMechBoss1);
        public static Condition siggy = new("After Signus has been defeated", () => CalValEX.CalamityActive ? (bool)CalValEX.Calamity.Call("GetBossDowned", "signus") : NPC.downedMechBoss3);
        public static Condition polt = new("After Polterghast has been defeated", () => CalValEX.CalamityActive ? (bool)CalValEX.Calamity.Call("GetBossDowned", "polterghast") : NPC.downedPlantBoss);
        public static Condition boomer = new("After The Old Duke has been defeated", () => CalValEX.CalamityActive ? (bool)CalValEX.Calamity.Call("GetBossDowned", "oldduke") : NPC.downedFishron);
        public static Condition dog = new("After The Devourer of Gods has been defeated", () => CalValEX.CalamityActive ? (bool)CalValEX.Calamity.Call("GetBossDowned", "devourerofgods") : NPC.downedMoonlord);
        public static Condition yharon = new("After Yharon has been defeated", () => CalValEX.CalamityActive ? (bool)CalValEX.Calamity.Call("GetBossDowned", "yharon") : NPC.downedFishron);
        public static Condition exo = new("After the Exo Mechs have been defeated", () => CalValEX.CalamityActive ? (bool)CalValEX.Calamity.Call("GetBossDowned", "draedon") : NPC.downedMechBossAny);
        public static Condition scal = new("After Calamitas has been defeated", () => CalValEX.CalamityActive ? (bool)CalValEX.Calamity.Call("GetBossDowned", "scal") : NPC.downedAncientCultist);
        // Misc downed conditions
        public static Condition acid = new("After Acid Rain tier 2 has been cleared or in the Sulphurous Sea", () => CalValEX.CalamityActive ? (CalValEX.InCalamityBiome(Main.LocalPlayer, "SulphurousSeaBiome") || (bool)CalValEX.Calamity.Call("GetBossDowned", "acidrainscourge")) : false);
        public static Condition evil = new Condition("If either the Hive Mind or The Perforators have been defeated", () => CalValEX.CalamityActive ? ((bool)CalValEX.Calamity.Call("GetBossDowned", "hivemind") || (bool)CalValEX.Calamity.Call("GetBossDowned", "perforators")) : false);
        public static Condition nugget = new Condition("If the Calamity and Calamity's Vanities bestiaries are more than 36.5% complete or if The Dragonfolly has been defeated", () => CalValEX.CalamityActive ? ((Main.BestiaryDB.GetCompletedPercentByMod(CalValEX.Calamity) > 0.365 && Main.GetBestiaryProgressReport().CompletionPercent > 0.324) || (bool)CalValEX.Calamity.Call("GetBossDowned", "dragonfolly")) : (Main.GetBestiaryProgressReport().CompletionPercent > 0.324));
        // Biome conditions
        public static Condition dungeon = new("While in the Dungeon", () => Main.LocalPlayer.GetModPlayer<CalValEXPlayer>().ZoneMockDungeon || Main.LocalPlayer.ZoneDungeon);
        public static Condition ass = new("While in the Astral Blight biome", () => Main.LocalPlayer.InModBiome<Biomes.AstralBlight>());
        public static Condition sammy = new("While in the Underworld Lab", () => CalValEXWorld.hellTiles > 20 && Main.LocalPlayer.ZoneUnderworldHeight);
        public static Condition jun = new("While in the Jungle Lab", () => CalValEXWorld.jungleTiles > 20 && Main.LocalPlayer.ZoneJungle);
        // NPC conditions
        public static Condition bandit = new("If the Bandit is present", () => CalValEX.CalamityActive ? NPC.AnyNPCs(CalValEX.Calamity.Find<ModNPC>("THIEF").Type) : NPC.AnyNPCs(NPCID.Golfer));
        public static Condition perma = new("If the Archmage is present", () => CalValEX.CalamityActive ? NPC.AnyNPCs(CalValEX.Calamity.Find<ModNPC>("DILF").Type) : NPC.AnyNPCs(NPCID.Wizard));
    }
}