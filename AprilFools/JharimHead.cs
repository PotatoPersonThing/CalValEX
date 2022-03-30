using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.AprilFools;

namespace CalValEX.AprilFools
{
	public class JharimHead : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Jungle Tyrant Jharim's Decapitated Head");
			Tooltip.SetDefault("Summons the Jungle Tyrant\nDoes not work outside of April Fools");
		}
		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 18;
			Item.maxStack = 1;
			Item.rare = 9;
			Item.useAnimation = 45;
			Item.useTime = 45;
			Item.useStyle = 4;
			Item.UseSound = SoundID.Item44;
			Item.consumable = true;
		}
		
		public override bool? UseItem(Player player)
		{
			Terraria.Audio.SoundEngine.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
			if (Main.netMode != 1)
			{
				NPC.SpawnOnPlayer(player.whoAmI, (ModContent.NPCType<AprilFools.Jharim.Jharim>()));
			}
			return true;
		}

		public override bool CanUseItem(Player player)
        {
			//Mod orthoceraDLC = ModLoader.GetMod("CalValPlus");
            if (CalValEX.month != 4/* && orthoceraDLC == null*/)
            {
            return false;
            }
			else if (NPC.AnyNPCs(ModContent.NPCType<AprilFools.Jharim.Jharim>()))
			{
				return false;
			}
            else
            {
                return true;
            }
		}

		/*public override void AddRecipes()
		{
			Mod orthoceraDLC = ModLoader.GetMod("CalValPlus");
            if (CalValEX.month != 4 && orthoceraDLC == null)
            {
            return;
            }
			else
			{
			Mod CalValEX = ModLoader.GetMod("CalamityMod");
            {
                ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient(ItemID.GoldOre, 1);
                recipe.AddTile(TileID.WorkBenches);
                recipe.SetResult(this);
                recipe.AddRecipe();
			}
			}
		}*/
	}
}