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
            Tooltip.SetDefault("Extremely faulty\n" + "Horizontal speed: 0.8\n" + "Acceleration multiplier: 0.8\n" + "Flight time: 4");
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
            if (hideVisual)
            {
                player.GetModPlayer<CalValEXPlayer>().wulfrumjam = false;
            }
            if (player.wingTime == 0)
            {
                player.wingTimeMax = 0;
                player.GetModPlayer<CalValEXPlayer>().wulfrumjam = true;
            }
            else
            {
                player.wingTimeMax = 4;
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
                ascentWhenFalling = 0.35f;
                ascentWhenRising = 0.02f;
                maxCanAscendMultiplier = 0.2f;
                maxAscentMultiplier = 0.5f;
                constantAscend = 0.07f;
            }            
        }

        public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
        {
            speed = 0.8f;
            acceleration *= 0.8f;
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