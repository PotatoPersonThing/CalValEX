using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{
    public class Minihote : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Miniature Elemental Heart");
            Tooltip.SetDefault("Its like you're running a daycare or something...");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 4));
            ItemID.Sets.AnimatesAsSoul[item.type] = true;
            ItemID.Sets.ItemIconPulse[item.type] = false;
            ItemID.Sets.ItemNoGravity[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.UseSound = SoundID.NPCHit5;
            item.shoot = mod.ProjectileType("rarebrimling");
            item.value = Item.sellPrice(0, 4, 0, 0);
            item.expert = true;
            item.rare = 10;
            item.buffType = mod.BuffType("minihotebuff");
        }

        public override void UseStyle(Player player)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(item.buffType, 3600, true);
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("WetBubble"));
            recipe.AddIngredient(mod.ItemType("cloudcandy"));
            recipe.AddIngredient(mod.ItemType("brimtulip"));
            recipe.AddIngredient(mod.ItemType("SandBottle"));
            recipe.AddIngredient(mod.ItemType("SandPlush"));
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}