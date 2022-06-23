using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX.NPCs.Critters;

namespace CalValEX.Items.Critters
{
    public class ViolemurItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Violemur");
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
            Item.height = 18;
            Item.noUseGraphic = true;
            Item.rare = 4;

            /*Mod mod = ModLoader.GetMod("CalamityMod");
            if (mod == null)
            {
                return;
            }*/
            Item.makeNPC = (short)NPCType<Violemur>();
        }
        /*public override void AddRecipes()
        {
            Mod CalValEX = ModLoader.GetMod("CalamityMod");
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(mod.ItemType("BlightolemurItem"));
                recipe.AddTile(mod.TileType("StarstruckSynthesizerPlaced"));
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }*/
    }
}