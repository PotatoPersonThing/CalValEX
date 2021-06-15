using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Buffs.Transformations
{
	public class SandTransformationBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Sand Elemental Transformation");
			Description.SetDefault("heh.");
			Main.debuff[Type] = true;
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
			canBeCleared = false;
		}
	}
}