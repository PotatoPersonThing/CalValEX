using MonoMod.Cil;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX.Items.Critters;

namespace CalValEX.NPCs.Critters
{
    public class PlagueFrog : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Plagued Frog");
            Main.npcFrameCount[NPC.type] = 11;
            Main.npcCatchable[NPC.type] = true;
        }

        public override void SetDefaults()
        {
            NPC.CloneDefaults(NPCID.Frog);
            NPC.catchItem = (short)ItemType<PlagueFrogItem>();
            NPC.lavaImmune = false;
            NPC.friendly = true;
            AIType = NPCID.Frog;
            AnimationType = NPCID.Frog;
            NPC.lifeMax = 20;
            for (int i = 0; i < NPC.buffImmune.Length; i++)
            {
                //NPC.buffImmune[(ModLoader.GetMod("CalamityMod").BuffType("Plague"))] = false;
            }
        }
        public override void SetBestiary(Terraria.GameContent.Bestiary.BestiaryDatabase database, Terraria.GameContent.Bestiary.BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new Terraria.GameContent.Bestiary.IBestiaryInfoElement[] {
                Terraria.GameContent.Bestiary.BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Jungle,
                new Terraria.GameContent.Bestiary.FlavorTextBestiaryInfoElement("The plague unleashed by the scientist didn't just infect the already hostile creatures. Peaceful lifeforms such as frogs were also unfortunate enough to fall victim to it."),
            });
        }

        public override void AI()
        {
            var thisRect = NPC.getRect();

            for (int i = 0; i < Main.maxProjectiles; i++)
            {
                var proj = Main.projectile[i];

                if (proj != null && proj.active && proj.getRect().Intersects(thisRect) & proj.type == ProjectileID.PurificationPowder)
                {
                    NPC.Transform(NPCID.Frog);
                }
            }
        }

        public override bool? CanBeHitByItem(Player player, Item item)
        {
            return true;
        }

        public override bool? CanBeHitByProjectile(Projectile projectile)
        {
            return true;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.playerSafe || !NPC.downedGolemBoss || CalValEXConfig.Instance.CritterSpawns)
            {
                return 0f;
            }
            return Terraria.ModLoader.Utilities.SpawnCondition.HardmodeJungle.Chance * 0.4f;
        }

        public override void OnCatchNPC(Player player, Item item)
        {
            item.stack = 1;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (NPC.life <= 0)
            {
                Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("PlagueFrog").Type, 1f);
                Gore.NewGore(NPC.position, NPC.velocity, Mod.Find<ModGore>("PlagueFrog2").Type, 1f);
            }
        }
    }
}