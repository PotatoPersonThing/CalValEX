using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX.NPCs.Critters;

namespace CalValEX.Items.Critters
{
    public class GoldEyedolItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gold Eyedol");
        }

        public override void SetDefaults()
        {
            Item.useStyle = 1;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.maxStack = 999;
            Item.consumable = true;
            Item.width = 22;
            Item.height = 22;
            Item.noUseGraphic = true;
            Item.rare = 3;

            /*Mod mod = ModLoader.GetMod("CalamityMod");
            if (mod == null)
            {
                return;
            }*/
            Item.makeNPC = (short)NPCType<GoldEyedol>();
            Item.value = Item.sellPrice(0, 10, 0, 0);
        }

        /*public override void AddRecipes()
        {
            Mod mod = ModLoader.GetMod("FargowiltasSouls");
            if (mod == null)
            {
                return;
            }
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ModContent.ItemType<EyedolItem>());
                recipe.AddIngredient((ItemID.GoldDust), 100);
                recipe.AddTile(mod.TileType("GoldenDippingVatSheet"));
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }*/
    }
}