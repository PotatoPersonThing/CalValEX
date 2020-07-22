using System;
using System.IO;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;

namespace CalValEX
{
	public class CalValEX : Mod
	{
		//public override void PostSetupContent()
		//{	Mod CalValEX = ModLoader.GetMod("CalamityMod");
		//{
			//Main.ItemName(ModLoader.GetMod("CalamityMod").ItemType("StreamGouge") = "Soul Piercer");
		//}
		//}
		public override void PostSetupContent()
	{
		Mod cal = ModLoader.GetMod("CalamityMod");
			cal.GetItem("StreamGouge").DisplayName.AddTranslation(GameCulture.English, "Soul Piercer");
			cal.GetItem("SoulPiercer").DisplayName.AddTranslation(GameCulture.English, "True Soul Piercer");
		
	}
	}
	
	
		
}