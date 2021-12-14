using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalamityMod.CalPlayer;

namespace CalValEX.NPCs.JellyPriest
{
    public class JellyPriestBound : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bound Jelly Priestess");
            Main.npcFrameCount[npc.type] = 1;
        }

        public override void SetDefaults()
        {
            npc.friendly = true;
            npc.npcSlots = 5f;
            npc.width = 18;
            npc.height = 34;
            npc.aiStyle = 0;
            npc.damage = 10;
            npc.defense = 15;
            npc.lifeMax = 250;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.5f;
            npc.rarity = 1;
            npc.dontTakeDamageFromHostiles = true;
        }

        public override bool CanChat()
        {
            return true;
        }

        public override void AI()
        {
            npc.breath += 2;
            for (int i = 0; i < 255; i++)
            {
                if (Main.player[i].active && Main.player[i].talkNPC == npc.whoAmI)
                {
                    CalValEXWorld.rescuedjelly = true;
                    CalValEXWorld.UpdateWorldBool();
                    npc.Transform(ModContent.NPCType<JellyPriestNPC>());
                    npc.netUpdate = true;
                    if (!NPC.AnyNPCs(ModContent.NPCType<JellyPriestNPC>()))
                    {
                        NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, ModContent.NPCType<JellyPriestNPC>());
                        npc.active = false;
                    }
                    return;
                }
            }
        }

        public override string GetChat()
        {
            return "Greetings, land creature! I rise from this old sea in hopes of traveling and finding a certain deity from the old times, from when the sea was a beautiful reign for many. Do you have any hint about where I could find them?";         
        }

        /*void Awaken()
        {
            for (int blah = 0; blah <= 20; blah++)
            {
                npc.ai[3]++;
            }
            if (npc.ai[3] >= 4)
            {
                npc.Transform(ModContent.NPCType<JellyPriestNPC>());
            }
        }*/

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            Mod clamMod = ModLoader.GetMod("CalamityMod"); //this is to get calamity mod, you have to add 'weakReferences = CalamityMod@1.4.4.4' (without the '') in your build.txt for this to work
            if (spawnInfo.player.GetModPlayer<CalamityPlayer>().ZoneSulphur && (bool)clamMod.Call("GetBossDowned", "acidrain") && !CalValEXWorld.rescuedjelly && !NPC.AnyNPCs(ModContent.NPCType<JellyPriestBound>()) && !NPC.AnyNPCs(ModContent.NPCType<JellyPriestNPC>()) && !CalValEXConfig.Instance.TownNPC)
            {
                return 0.5f;
            }
            else
            {
                return 0f;
            }
        }

        public override bool? CanBeHitByItem(Player player, Item item)
        {
            return true;
        }

        public override bool? CanBeHitByProjectile(Projectile projectile)
        {
            if (projectile.friendly)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool StrikeNPC(ref double damage, int defense, ref float knockback, int hitDirection, ref bool crit)
        {
            damage = 1;
            crit = false;
            knockback = 0;
            npc.Transform(ModContent.NPCType<JellyPriestNPC>());
            return false;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/JellyPriest"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/JellyPriest2"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/JellyPriest3"), 1f);
            }
        }
    }
}