using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Buffs.Transformations
{
	public class CloudTransformationBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Cloud Elemental Transformation");
			Description.SetDefault("Feelin' Cloudy");
			Main.debuff[Type] = true;
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
			canBeCleared = false;
		}
	}
}