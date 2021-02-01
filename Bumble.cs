using Terraria;
using Terraria.ModLoader;
using static CalValEX.CalValEXGlobalitem;
using CalValEX.Items.Mounts;
using CalValEX.Buffs.Pets;
using CalValEX.Buffs.LightPets;

namespace CalValEX
{
	public class Bumble : GlobalNPC
    {
	
        public override bool InstancePerEntity => true;

        public override void NPCLoot(NPC npc)
        {
        }

         public override void SetDefaults(NPC npc)
        {
            Mod clam = ModLoader.GetMod("CalamityMod");
            if (mod != null && CalValEX.Bumble && !CalValEXConfig.Instance.DragonballName)
            {
                if (npc.type == clam.NPCType("Bumblefuck"))
                { 
                    if (Utils.NextFloat(Main.rand) < 0.01f)
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
                    if (Utils.NextFloat(Main.rand) < 0.01f)
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
            }
        }
    }
}
