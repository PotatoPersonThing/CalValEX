using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Wings
{
    [AutoloadEquip(EquipType.Wings)]
    public class TerminalWings : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wings of Termina");
            Tooltip.SetDefault("Through death and destruction new heights are attained, \non wings of a pandemonic butterfly ");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(10, 6));
           /// ItemID.Sets.AnimatesAsSoul[item.type] = true;
            ItemID.Sets.ItemIconPulse[item.type] = false;
            ItemID.Sets.ItemNoGravity[item.type] = false;

        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 28;
            item.value = Item.sellPrice(1, 0, 0, 0);
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            item.rare = 10;
            item.expert = true;
            item.accessory = true;
            //item.vanity = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual) {
			player.wingTimeMax = 300;
		}

		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend) {
			ascentWhenFalling = 1.85f;
			ascentWhenRising = 0.95f;
			maxCanAscendMultiplier = 1.5f;
			maxAscentMultiplier = 3f;
			constantAscend = 0.535f;
		}

		public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration) {
			speed = 14f;
			acceleration *= 3.0f;
		}
        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            if (calamityMod != null)
            {
		recipe.AddIngredient(ModContent.ItemType<Termipebbles>(), 5);
                recipe.AddIngredient(calamityMod.ItemType("Rock"));
                recipe.AddTile(calamityMod.TileType("DraedonsForge"));  
			    recipe.SetResult(this);
			    recipe.AddRecipe();
            }
        }
    }
}
