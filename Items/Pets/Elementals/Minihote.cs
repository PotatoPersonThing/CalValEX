using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets.Elementals
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
            item.CloneDefaults(ItemID.ZephyrFish);
            item.UseSound = SoundID.NPCHit5;
            item.shoot = mod.ProjectileType("rarebrimling");
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.expert = true;
            item.rare = 10;
            item.buffType = mod.BuffType("minihotebuff");
            item.noUseGraphic = true;
        }

        public override void UseStyle(Player player)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(item.buffType, 3600, true);
            }
        }
        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            type = mod.ProjectileType("rarebrimling");
            return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
            type = mod.ProjectileType("cloudmini");
            return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
            type = mod.ProjectileType("babywaterclone");
            return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
            type = mod.ProjectileType("sandmini");
            return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
            type = mod.ProjectileType("raresandmini");
            return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("SandBottle"));
            recipe.AddIngredient(mod.ItemType("SandPlush"));
            recipe.AddIngredient(mod.ItemType("WetBubble"));
            recipe.AddIngredient(mod.ItemType("cloudcandy"));
            recipe.AddIngredient(mod.ItemType("brimtulip"));
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}