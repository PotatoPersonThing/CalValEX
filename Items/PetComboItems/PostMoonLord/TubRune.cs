using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Buffs.PetComboBuffs;
using CalValEX.Items.Pets;
using CalValEX.Projectiles.Pets;

namespace CalValEX.Items.PetComboItems.PostMoonLord
{
    public class TubRune : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tub Rune");
            Tooltip.SetDefault("Change the world");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCHit4;
            Item.value = Item.sellPrice(7, 7, 7, 0);
            Item.rare = 9;// 15;
            Item.buffType = ModContent.BuffType<TubRuneBuff>();
        }

        public override void UseStyle(Player player, Rectangle heldItemFrame)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(Item.buffType, 3600, true);
            }
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            type = ModContent.ProjectileType<CalamityBABY>();
            type = ModContent.ProjectileType<CoolBlueSignut>();
            type = ModContent.ProjectileType<CoolBlueSlime>();
            type = ModContent.ProjectileType<GoozmaPet>();
            type = ModContent.ProjectileType<UngodlySerpent>();
            type = ModContent.ProjectileType<Sirember>();
            return base.Shoot(player, source, position, velocity, type, damage, knockback);
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<YharexsLetter>())
                .AddIngredient(ModContent.ItemType<Ectogasm>())
                .AddIngredient(ModContent.ItemType<GoozmaPetItem>())
                .AddIngredient(ModContent.ItemType<ChewyToy>())
                .AddIngredient(ModContent.ItemType<Rember>())
                //.AddTile(ModLoader.GetMod("CalamityMod").TileType<DraedonsForge>()) Æ:Cal port moment
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }
    }
}