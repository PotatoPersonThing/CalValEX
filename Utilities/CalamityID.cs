using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace CalValEX.CalamityID
{
	public class CalamityID
	{
        public static int NPCRelation(string calamity, int vanilla)
        {
            if (CalValEX.CalamityActive)
            {
                return CalValEX.Calamity.Find<ModNPC>(calamity).Type;
            }
            return vanilla;
        }
        public static int ItemRelation(string calamity, int vanilla)
        {
            if (CalValEX.CalamityActive)
            {
                return CalValEX.Calamity.Find<ModItem>(calamity).Type;
            }
            return vanilla;
        }
    }
}

namespace CalValEX.CalamityID
{
    public class CalNPCID
    {
        #region Minibosses
        public static int GiantClam => CalamityID.NPCRelation("GiantClam", NPCID.EyeofCthulhu);
        #endregion

        #region Bosses
        public static int DesertScourge => CalamityID.NPCRelation("DesertScourgeHead", NPCID.EyeofCthulhu);
        public static int Crabulon => CalamityID.NPCRelation("Crabulon", NPCID.BrainofCthulhu);
        public static int HiveMind => CalamityID.NPCRelation("HiveMind", NPCID.EaterofWorldsHead);
        public static int Perforators => CalamityID.NPCRelation("PerforatorHive", NPCID.BrainofCthulhu);
        public static int SlimeGod => CalamityID.NPCRelation("SlimeGodCore", NPCID.SkeletronHead);
        public static int Cryogen => CalamityID.NPCRelation("Cryogen", NPCID.TheDestroyer);
        public static int AquaticScourge => CalamityID.NPCRelation("AquaticScourgeHead", NPCID.Spazmatism);
        public static int BrimstoneElemental => CalamityID.NPCRelation("BrimstoneElemental", NPCID.SkeletronPrime);
        public static int CalamitasClone => CalamityID.NPCRelation("CalamitasClone", NPCID.Retinazer);
        public static int Anahita => CalamityID.NPCRelation("Anahita", NPCID.Plantera);
        public static int Leviathan => CalamityID.NPCRelation("Leviathan", NPCID.Plantera);
        public static int AstrumAureus => CalamityID.NPCRelation("AstrumAureus", NPCID.Plantera);
        public static int PlaguebringerGoliath => CalamityID.NPCRelation("PlaguebringerGoliath", NPCID.Golem);
        public static int Ravager => CalamityID.NPCRelation("RavagerBody", NPCID.Golem);
        public static int AstrumDeus => CalamityID.NPCRelation("AstrumDeusHead", NPCID.CultistBoss);
        public static int GuardianCommander => CalamityID.NPCRelation("ProfanedGuardianCommander", NPCID.QueenSlimeBoss);
        public static int GuardianHealer => CalamityID.NPCRelation("ProfanedGuardianHealer", NPCID.QueenSlimeBoss);
        public static int GuardianDefender => CalamityID.NPCRelation("ProfanedGuardianDefender", NPCID.QueenSlimeBoss);
        public static int Bumblebirb => CalamityID.NPCRelation("Bumblefuck", NPCID.DD2Betsy);
        public static int Providence => CalamityID.NPCRelation("Providence", NPCID.HallowBoss);
        public static int StormWeaver => CalamityID.NPCRelation("StormWeaverHead", NPCID.TheDestroyer);
        public static int CeaselessVoid => CalamityID.NPCRelation("CeaselessVoid", NPCID.Spazmatism);
        public static int Signus => CalamityID.NPCRelation("Signus", NPCID.SkeletronPrime);
        public static int Polterghast => CalamityID.NPCRelation("Polterghast", NPCID.Plantera);
        public static int OldDuke => CalamityID.NPCRelation("OldDuke", NPCID.DukeFishron);
        public static int DevourerofGods => CalamityID.NPCRelation("DevourerofGodsHead", NPCID.MoonLordCore);
        public static int Yharon => CalamityID.NPCRelation("Yharon", NPCID.DukeFishron);
        public static int Ares => CalamityID.NPCRelation("AresBody", NPCID.SkeletronPrime);
        public static int Apollo => CalamityID.NPCRelation("Apollo", NPCID.Spazmatism);
        public static int Artemis => CalamityID.NPCRelation("Artemis", NPCID.Retinazer);
        public static int Thanatos => CalamityID.NPCRelation("ThanatosHead", NPCID.TheDestroyer);
        public static int SupremeCalamitas => CalamityID.NPCRelation("SupremeCalamitas", NPCID.CultistBoss);
        public static int PrimordialWyrm => CalamityID.NPCRelation("PrimordialWyrmHead", NPCID.MoonLordCore);
        #endregion
    }
    public class CalItemID
    {
        #region Bags
        public static int StarterBag => CalamityID.ItemRelation("StarterBag", ItemID.KingSlimeBossBag);
        public static int DesertScourgeBag => CalamityID.ItemRelation("DesertScourgeBag", ItemID.EyeOfCthulhuBossBag);
        public static int CrabulonBag => CalamityID.ItemRelation("CrabulonBag", ItemID.BrainOfCthulhuBossBag);
        public static int HiveMindBag => CalamityID.ItemRelation("HiveMindBag", ItemID.EaterOfWorldsBossBag);
        public static int PerforatorBag => CalamityID.ItemRelation("PerforatorBag", ItemID.BrainOfCthulhuBossBag);
        public static int SlimeGodBag => CalamityID.ItemRelation("SlimeGodBag", ItemID.SkeletronBossBag);
        public static int CryogenBag => CalamityID.ItemRelation("CryogenBag", ItemID.DestroyerBossBag);
        public static int AquaticScourgeBag => CalamityID.ItemRelation("AquaticScourgeBag", ItemID.TwinsBossBag);
        public static int BrimstoneElementalBag => CalamityID.ItemRelation("BrimstoneWaifuBag", ItemID.SkeletronPrimeBossBag);
        public static int CalamitasCloneBag => CalamityID.ItemRelation("CalamitasCloneBag", ItemID.TwinsBossBag);
        public static int LeviathanBag => CalamityID.ItemRelation("LeviathanBag", ItemID.PlanteraBossBag);
        public static int AstrumAureusBag => CalamityID.ItemRelation("AstrumAureusBag", ItemID.PlanteraBossBag);
        public static int PlaguebringerGoliathBag => CalamityID.ItemRelation("PlaguebringerGoliathBag", ItemID.GolemBossBag);
        public static int RavagerBag => CalamityID.ItemRelation("RavagerBag", ItemID.GolemBossBag);
        public static int AstrumDeusBag => CalamityID.ItemRelation("AstrumDeusBag", ItemID.BossBagBetsy);
        public static int BumbleBag => CalamityID.ItemRelation("DragonfollyBag", ItemID.BossBagBetsy);
        public static int ProvidenceBag => CalamityID.ItemRelation("ProvidenceBag", ItemID.FairyQueenBossBag);
        public static int StormWeaverBag => CalamityID.ItemRelation("StormWeaverBag", ItemID.DestroyerBossBag);
        public static int CeaselessVoidBag => CalamityID.ItemRelation("CeaselessVoidBag", ItemID.TwinsBossBag);
        public static int SignusBag => CalamityID.ItemRelation("SignusBag", ItemID.SkeletronPrimeBossBag);
        public static int PolterghastBag => CalamityID.ItemRelation("PolterghastBag", ItemID.PlanteraBossBag);
        public static int OldDukeBag => CalamityID.ItemRelation("OldDukeBag", ItemID.FishronBossBag);
        public static int DevourerofGodsBag => CalamityID.ItemRelation("DevourerofGodsBag", ItemID.MoonLordBossBag);
        public static int YharonBag => CalamityID.ItemRelation("YharonBag", ItemID.FishronBossBag);
        public static int DraedonBox => CalamityID.ItemRelation("DraedonBag", ItemID.MoonLordBossBag);
        public static int SupremeCalamitasCoffer => CalamityID.ItemRelation("CalamitasCoffer", ItemID.MoonLordBossBag);
        #endregion

        #region Crates
        public static int SulphurousCrate => CalamityID.ItemRelation("SulphurousCrate", ItemID.OceanCrateHard);
        public static int SunkenCrate => CalamityID.ItemRelation("SunkenCrate", ItemID.OasisCrateHard);
        public static int AstralCrate => CalamityID.ItemRelation("AstralCrate", ItemID.FloatingIslandFishingCrateHard);
        #endregion
    }
}