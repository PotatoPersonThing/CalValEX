/*using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX
{
	public class CalValEXGlobalTile : GlobalTile
	{
        public override void KillTile(int i, int j, int type, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            if (type == (mod.TileType("UnholyMonolith")) || type == (mod.TileType("CalamitousMonolith")) || type == (mod.TileType("DimensionalMonolith")) || type == (mod.TileType("InfernalMonolith")) || type == (mod.TileType("PlagueMonolith")) || type == (mod.TileType("AquaticMonolith")))
            {
                if (CalValEXWorld.TwoMonolith && Main.tile[i, j].frameY >= 56)
                {
                    CalValEXWorld.TwoMonolith = false;
                }
                //If one monolith is active and this one is active
                else if (!CalValEXWorld.TwoMonolith && Main.tile[i, j].frameY >= 56)
                {
                    CalValEXWorld.OneMonolith = false;
                }
            }
        }
    }
}*/