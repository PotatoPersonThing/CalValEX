using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Buffs.PetComboBuffs;
using CalValEX.Items.Pets;
using CalValEX.Projectiles.Pets;

namespace CalValEX.Items.PetComboItems.PreHardmode
{
    public class DustChime : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dust Chime");
            Tooltip.SetDefault("The winds of progress");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCHit4;
            Item.value = Item.sellPrice(0, 5, 0, 0);
            Item.rare = 4;
            Item.buffType = ModContent.BuffType<DustChimeBuff>();
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
            type = ModContent.ProjectileType<AeroBaby>();
            type = ModContent.ProjectileType<AeroSlimePet>();
            type = ModContent.ProjectileType<RustyMimic>();
            type = ModContent.ProjectileType<TUB>();
            type = ModContent.ProjectileType<Blockaroz>();
            type = ModContent.ProjectileType<Euros>();
            return base.Shoot(player, source, position, velocity, type, damage, knockback);
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<AerialiteBubble>())
                .AddIngredient(ModContent.ItemType<CursedLockpick>())
                .AddIngredient(ModContent.ItemType<UglyTentacle>())
                .AddIngredient(ModContent.ItemType<Cube>())
                .AddIngredient(ModContent.ItemType<RuinedBandage>())
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}