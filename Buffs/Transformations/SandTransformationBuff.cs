using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Buffs.Transformations
{
    public class SandTransformationBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Sand Transformation");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (!player.GetModPlayer<CalValEXPlayer>().sandTPrevious)
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
        }
    }
}
