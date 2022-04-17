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
    public class VaselineBell : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vaseline Bell");
            Tooltip.SetDefault("All at once I come alive, it's a rebirth!");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCHit4;
            Item.value = Item.sellPrice(0, 50, 50, 0);
            Item.rare = 9;
            Item.buffType = ModContent.BuffType<VaselineBuff>();
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
            type = ModContent.ProjectileType<GrandPet>();
            type = ModContent.ProjectileType<BuffReaper>();
            type = ModContent.ProjectileType<Smauler>();
            type = ModContent.ProjectileType<ScoriaDuke>();
            type = ModContent.ProjectileType<FollyPet>();
            type = ModContent.ProjectileType<BugDoge>();
            type = ModContent.ProjectileType<Headoge>();
            type = ModContent.ProjectileType<MiniDoge>();
            type = ModContent.ProjectileType<PolterChan>();
            return base.Shoot(player, source, position, velocity, type, damage, knockback);
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<HeartoftheSharks>())
                .AddIngredient(ModContent.ItemType<CharredChopper>())
                .AddIngredient(ModContent.ItemType<FollyWing>())
                .AddIngredient(ModContent.ItemType<FluffyFur>())
                .AddIngredient(ModContent.ItemType<ToyScythe>())
                //.AddTile(ModLoader.GetMod("CalamityMod").TileType<CosmicAnvil>())
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }
    }
}