using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Tiles.Astral
{
	public class AstralPalm : ModPalmTree
	{
		public override Texture2D GetTexture() => ModContent.GetTexture("CalValEX/Items/Tiles/Astral/AstralPalm");

		public override Texture2D GetTopTextures() => ModContent.GetTexture("CalValEX/Items/Tiles/Astral/AstralPalmTop");

		public override int DropWood() => ModContent.ItemType<AstralTreeWood>(); // TODO
	}
}