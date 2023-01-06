using Terraria;
using Terraria.ModLoader;

namespace CalValEX
{
    public class Bumble : GlobalNPC
    {
        public override void SetDefaults(NPC npc)
        {
            if (!CalValEX.CalamityActive)
                return;

            if (CalValEX.Bumble && !CalValEXConfig.Instance.DragonballName)
            {
                if (npc.type == CalValEX.CalamityNPC("Bumblefuck"))
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

                if (npc.type == CalValEX.CalamityNPC("Bumblefuck2"))
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
                if (npc.type == CalValEX.CalamityNPC("WulfrumGryator"))
                {
                    npc.GivenName = "John Wulfrum";
                }
            }
        }
    }
}