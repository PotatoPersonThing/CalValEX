using System;
using System.IO;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;

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
            if (mod != null && CalValEX.Bumble)
            {
                if (npc.type == clam.NPCType("Bumblefuck"))
                { 
                    npc.GivenName = "Blunderbird";
                }
                if (npc.type == clam.NPCType("Bumblefuck2"))
                { 
                    npc.GivenName = "Blunderling";
                }
            }
        }
    }
}
