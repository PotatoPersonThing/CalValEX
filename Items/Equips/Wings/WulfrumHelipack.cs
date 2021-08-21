using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace CalValEX.Items.Equips.Wings
{
    [AutoloadEquip(EquipType.Wings)]
    public class WulfrumHelipack : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Extremely faulty\n" + "Horizontal speed: 1\n" + "Acceleration multiplier: 1\n" + "Flight time: 20");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 20;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = 1;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (player.wingTime == 0 && player.velocity.Y > 0)
            {
                player.wingTimeMax = 0;
                player.GetModPlayer<CalValEXPlayer>().wulfrumjam = true;
            }
            else
            {
                player.wingTimeMax = 20;
                player.GetModPlayer<CalValEXPlayer>().wulfrumjam = false;
            }
        }

        public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
            ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
        {
            if (player.wingTime == 0)
            {
                ascentWhenFalling = 0f;
                ascentWhenRising = 0f;
                maxCanAscendMultiplier = 0f;
                maxAscentMultiplier = 0f;
                constantAscend = 0f;
            }
            else
            {
                ascentWhenFalling = 0.45f;
                ascentWhenRising = 0.05f;
                maxCanAscendMultiplier = 0.5f;
                maxAscentMultiplier = 0.7f;
                constantAscend = 0.11f;
            }            
        }

        public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
        {
            speed = 1f;
            acceleration *= 1.0f;
        }
        public override void AddRecipes()
        {
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(calamityMod.ItemType("WulfrumShard"), 12);
            recipe.AddIngredient(calamityMod.ItemType("EnergyCore"), 3);
            recipe.AddIngredient(ItemID.LuckyHorseshoe, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}