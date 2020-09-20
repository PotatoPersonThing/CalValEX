using Terraria.ModLoader;
using Terraria;

namespace CalValEX.Oracle
{
    public class OraclePlayer : ModPlayer
    {
        public override void UpdateDead()
        {
            OracleGlobalNPC.playerTargetTimer = -1;
        }

        public int PlayerBag = 0;

        public override void Initialize()
        {
            PlayerBag = 0;
        }
  
        public override void PostUpdateMiscEffects()
        {
            if (Main.dayTime && Main.time == 16200)
            {
                PlayerBag++;
            }
            if (PlayerBag > 1)
            {
                PlayerBag = 1;
            }
        }
    }
}
