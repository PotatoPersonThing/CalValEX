using Terraria;
using Terraria.ModLoader;
using CalamityMod.CalPlayer;

namespace CalValEX
{
    public class Bumble : GlobalNPC
    {
        public override bool InstancePerEntity => true;

        public override void SetDefaults(NPC npc)
        {
            if (CalValEX.Bumble && !CalValEXConfig.Instance.DragonballName)
            {
                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.Bumblebirb.Bumblefuck>())
                {
                    if (Main.rand.NextFloat() < 0.01f)
                    {
                        npc.GivenName = "Bumblebirb";
                    }
                    else
                    {
                        npc.GivenName = "Blunderbird";
                    }
                }

                if (npc.type == ModContent.NPCType<CalamityMod.NPCs.Bumblebirb.Bumblefuck2>())
                {
                    if (Main.rand.NextFloat() < 0.01f)
                    {
                        npc.GivenName = "Bumblebirb";
                    }
                    else
                    {
                        npc.GivenName = "Blunderling";
                    }
                }
            }
        }
    }
}