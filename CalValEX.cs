using Terraria.ModLoader;
using Terraria.Localization;
using CalValEX.Oracle;

namespace CalValEX
{
	public class CalValEX : Mod
	{
		public override void PostSetupContent()
		{
		Mod cal = ModLoader.GetMod("CalamityMod");
			cal.GetItem("KnowledgeCrabulon").Tooltip.AddTranslation(GameCulture.English, "A crab and its mushrooms, a love story.\nIt's interesting how creatures can adapt given certain circumstances.\nFavorite this item to gain the Mushy buff while underground or in the mushroom biome.\nHowever, your movement speed will be decreased while in these areas due to you being covered in fungi.\nThe great crustacean's mushrooms may also grow angry when attacked, though they will also become harmless.");
		
 		Mod censusMod = ModLoader.GetMod("Census");
 	        if(censusMod != null)
    		{
                	censusMod.Call("TownNPCCondition", ModContent.NPCType<OracleNPC>(), "Equip a Pet or Light Pet");

            	}
		}
	}		
}
