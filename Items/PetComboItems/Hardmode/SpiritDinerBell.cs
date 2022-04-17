using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Buffs.PetComboBuffs;
using CalValEX.Items.Pets;
using CalValEX.Items.LightPets;
using CalValEX.Projectiles.Pets;
using CalValEX.Projectiles.Pets.LightPets;
using CalValEX.Projectiles.Pets.Elementals;
using CalValEX.Items.Pets.Elementals;

namespace CalValEX.Items.PetComboItems.Hardmode
{
    public class SpiritDinerBell : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spirit Diner Bell");
            Tooltip.SetDefault("Almost there");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCHit4;
            Item.value = Item.sellPrice(0, 12, 70, 0);
            Item.rare = 8;
            Item.buffType = ModContent.BuffType<SpiritDinerBuff>();
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
            type = ModContent.ProjectileType<Pillager>();
            type = ModContent.ProjectileType<SolarBunny>();
            type = ModContent.ProjectileType<rarebrimling>();
            type = ModContent.ProjectileType<cloudmini>();
            type = ModContent.ProjectileType<raresandmini>();
            type = ModContent.ProjectileType<sandmini>();
            type = ModContent.ProjectileType<babywaterclone>();
            type = ModContent.ProjectileType<StarJelly>();
            return base.Shoot(player, source, position, velocity, type, damage, knockback);
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<AncientChoker>())
                .AddIngredient(ModContent.ItemType<SolarBun>())
                .AddIngredient(ModContent.ItemType<Minihote>())
                .AddIngredient(ModContent.ItemType<JellyBottle>())
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }
    }
}