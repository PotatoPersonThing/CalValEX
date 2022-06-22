/*using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Buffs.PetComboBuffs;
using CalValEX.Items.Pets;
using CalValEX.Projectiles.Pets;

namespace CalValEX.Items.PetComboItems.PreHardmode
{
    public class BestInstrument : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Best Instrument");
            Tooltip.SetDefault("Pieces of our journey");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCHit4;
            Item.value = Item.sellPrice(0, 4, 60, 0);
            Item.rare = 5;
            Item.buffType = ModContent.BuffType<BestInstrumentBuff>();
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
            type = ModContent.ProjectileType<ClamHermit>();
            type = ModContent.ProjectileType<SmolCrab>();
            type = ModContent.ProjectileType<Fistuloid>();
            type = ModContent.ProjectileType<Hiveling>();
            type = ModContent.ProjectileType<Dstone>();
            return base.Shoot(player, source, position, velocity, type, damage, knockback);
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<ClamHermitMedallion>())
                .AddIngredient(ModContent.ItemType<ClawShroom>())
                .AddIngredient(ModContent.ItemType<MeatyWormTumor>())
                .AddIngredient(ModContent.ItemType<RottenKey>())
                .AddIngredient(ModContent.ItemType<DespairMask>())
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
        }
    }
}*/