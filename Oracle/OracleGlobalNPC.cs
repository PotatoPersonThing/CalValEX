using Terraria.ModLoader;

namespace CalValEX.Oracle
{
    public class OracleGlobalNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;
        public static int oracleNPC = -1;
        public static int playerTarget = -1;
        public static int playerTargetTimer = -1;
    }
}