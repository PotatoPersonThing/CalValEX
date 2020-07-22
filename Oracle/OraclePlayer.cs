using Terraria.ModLoader;

namespace CalValEX.Oracle
{
    public class OraclePlayer : ModPlayer
    {
        public override void UpdateDead()
        {
            OracleGlobalNPC.playerTargetTimer = -1;
        }
    }
}
