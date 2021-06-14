using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Buffs.Transformations
{
	public class ProtoRingBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Proto-Andromeda");
			Description.SetDefault("Still working out the kinks");
			Main.debuff[Type] = true;
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
			canBeCleared = false;
		}
	}
}