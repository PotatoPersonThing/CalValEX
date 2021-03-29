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
			Tooltip.SetDefault("Summons the Jungle Tyrant");
		}
		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 18;
			item.maxStack = 1;
			item.rare = 9;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = 4;
			item.UseSound = SoundID.Item44;
			item.consumable = true;
		}

		public override bool UseItem(Player player)
		{
			Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
			if (Main.netMode != 1)
			{
				NPC.SpawnOnPlayer(player.whoAmI, (ModContent.NPCType<Jharim>()));
			}
			return true;
		}

		public override bool CanUseItem(Player player)
        {
			Mod orthoceraDLC = ModLoader.GetMod("CalValPlus");
            if (CalValEX.month != 4 && orthoceraDLC == null)
            {
            return false;
            }
			else if (NPC.AnyNPCs(ModContent.NPCType<Jharim>()))
			{
				return false;
			}
            else
            {
                return true;
            }
		}

		public override void AddRecipes()
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
		}
	}
}