using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Buffs.PetComboBuffs;
using CalValEX.Items.Pets;
using CalValEX.Items.LightPets;
using CalValEX.Items.Pets.Scuttlers;
using CalValEX.Projectiles.Pets;
using CalValEX.Projectiles.Pets.LightPets;
using CalValEX.Projectiles.Pets.Scuttlers;

namespace CalValEX.Items.PetComboItems.PreHardmode
{
    public class NurseryBell : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nursery Bell");
            Tooltip.SetDefault("Our best friends...");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCHit4;
            Item.value = Item.sellPrice(0, 3, 0, 0);
            Item.rare = 3;
            Item.buffType = ModContent.BuffType<NurseryBellBuff>();
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
            type = ModContent.ProjectileType<Buppy>();
            type = ModContent.ProjectileType<Catfish>();
            type = ModContent.ProjectileType<Angrypup>();
            type = ModContent.ProjectileType<RedPanda>();
            type = ModContent.ProjectileType<Puppo>();
            type = ModContent.ProjectileType<BabyCnidrion>();
            return base.Shoot(player, source, position, velocity, type, damage, knockback);
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<RottenHotdog>())
                .AddIngredient(ModContent.ItemType<DecayingFishtail>())
                .AddIngredient(ModContent.ItemType<TundraBall>())
                .AddIngredient(ModContent.ItemType<BambooStick>())
                .AddIngredient(ModContent.ItemType<DoggoCollar>())
                .AddIngredient(ModContent.ItemType<SunDriedShrimp>())
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}