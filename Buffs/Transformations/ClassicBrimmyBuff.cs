using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Buffs.Transformations
{
	public class ClassicBrimmyBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Brimstone Elemental Transformation");
			Description.SetDefault("Yes, you can touch Water");
			Main.debuff[Type] = true;
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
			
		}
	}
}