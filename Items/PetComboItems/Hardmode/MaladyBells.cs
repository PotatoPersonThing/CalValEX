using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Buffs.PetComboBuffs;
using CalValEX.Items.Pets;
using CalValEX.Projectiles.Pets;

namespace CalValEX.Items.PetComboItems.Hardmode
{
    public class MaladyBells : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Malady Bells");
            Tooltip.SetDefault("Start anew");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCHit4;
            Item.value = Item.sellPrice(0, 8, 40, 15);
            Item.rare = 6;
            Item.buffType = ModContent.BuffType<MaladyBellsBuff>();
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
            type = ModContent.ProjectileType<Cryokid>();
            type = ModContent.ProjectileType<PhantomPet>();
            type = ModContent.ProjectileType<Hoodieidolist>();
            type = ModContent.ProjectileType<FathomEelHead>();
            type = ModContent.ProjectileType<MoistScourgePet>();
            type = ModContent.ProjectileType<BoldLizard>();
            type = ModContent.ProjectileType<SkaterPet>();
            return base.Shoot(player, source, position, velocity, type, damage, knockback);
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<coopershortsword>())
                .AddIngredient(ModContent.ItemType<HauntedPebble>())
                .AddIngredient(ModContent.ItemType<Eidolistthingy>())
                .AddIngredient(ModContent.ItemType<DeepseaLantern>())
                .AddIngredient(ModContent.ItemType<SandTooth>())
                .AddIngredient(ModContent.ItemType<BoldEgg>())
                .AddIngredient(ModContent.ItemType<SkaterEgg>())
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}