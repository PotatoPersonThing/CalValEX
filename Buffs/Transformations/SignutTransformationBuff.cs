using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Buffs.Transformations
{
	public class SignutTransformationBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			Main.debuff[Type] = true;
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
			
		}
	}
}