using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Buffs.Transformations
{
	public class SignutTransformationBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Ethereal Assassin");
			//Description.SetDefault("Never been more edgy");
			Main.debuff[Type] = true;
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
			
		}
	}
}