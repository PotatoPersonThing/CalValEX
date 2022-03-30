using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX.Tiles.FurnitureSets.Necrotic;
using CalValEX.Items.Tiles.Blocks;

namespace CalValEX.Items.Tiles.FurnitureSets.Necrotic
{
    public class NecroticTorch : ModItem
    {
        public override void SetStaticDefaults()
        {
        }

        public override void SetDefaults()
        {
            Item.width = 10;
            Item.height = 12;
            Item.maxStack = 99;
            Item.holdStyle = 1;
            Item.noWet = true;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.createTile = TileType<NecroticTorchPlaced>();
            Item.flame = true;
            Item.value = 50;
        }

        public override void HoldItem(Player player)
        {
            Vector2 position = player.RotatedRelativePoint(new Vector2(player.itemLocation.X + 12f * player.direction + player.velocity.X, player.itemLocation.Y - 14f + player.velocity.Y), true);
            Lighting.AddLight(position, 1f, 1f, 1f);
        }

        public override void PostUpdate()
        {
            if (!Item.wet)
            {
                Lighting.AddLight((int)((Item.position.X + Item.width / 2) / 16f), (int)((Item.position.Y + Item.height / 2) / 16f), 1f, 1f, 1f);
            }
        }

        public override void AutoLightSelect(ref bool dryTorch, ref bool wetTorch, ref bool glowstick)
        {
            dryTorch = true;
        }

        /*public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Torch, 5);
            recipe.AddIngredient(ItemType<Necrostone>(), 1);
            recipe.SetResult(this, 5);
            recipe.AddRecipe();
        }*/
    }
}