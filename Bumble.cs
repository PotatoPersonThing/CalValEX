using Terraria;
using Terraria.ModLoader;

namespace CalValEX
{
    public class Bumble : GlobalNPC
    {
        public override bool InstancePerEntity => true;

        public override void SetDefaults(NPC npc)
        {
            //ModLoader.TryGetMod("CalamityMod", out Mod clam);
            /*if (clam != null && CalValEX.Bumble && !CalValEXConfig.Instance.DragonballName)
            {
                if (npc.type == clam.GetContent<NPC>("Bumblefuck").Value)
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

                if (npc.type == clam.NPCType("Bumblefuck2"))
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

            if (CalValEX.WulfrumsetReal)
            {
                if (npc.type == clam.NPCType("WulfrumGyrator"))
                {
                    npc.GivenName = "John Wulfrum";
                }
            }*/
        }
    }
}