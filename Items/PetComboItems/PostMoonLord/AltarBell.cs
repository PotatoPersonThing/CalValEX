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

namespace CalValEX.Items.PetComboItems.PostMoonLord
{
    public class AltarBell : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Altar Bell");
            Tooltip.SetDefault("The gods from the heavens on the palm of your hand");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCHit4;
            Item.value = Item.sellPrice(0, 25, 80, 15);
            Item.rare = 9;// 16;
            Item.buffType = ModContent.BuffType<AltarBellBuff>();
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
            type = ModContent.ProjectileType<Dragonball>();
            type = ModContent.ProjectileType<Godrge>();
            type = ModContent.ProjectileType<Avalon>();
            type = ModContent.ProjectileType<YharimSquid>();
            type = ModContent.ProjectileType<TerminalRock>();
            type = ModContent.ProjectileType<BejeweledScuttler>();
            type = ModContent.ProjectileType<ProGuard1>();
            type = ModContent.ProjectileType<ProGuard2>();
            type = ModContent.ProjectileType<ProGuard3>();
            type = ModContent.ProjectileType<ProviPet>();
            return base.Shoot(player, source, position, velocity, type, damage, knockback);
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<TheDragonball>())
                .AddIngredient(ModContent.ItemType<DivineFly>())
                .AddIngredient(ModContent.ItemType<FlareRune>())
                .AddIngredient(ModContent.ItemType<AuricBottle>())
                .AddIngredient(ModContent.ItemType<Finality>())
                .AddIngredient(ModContent.ItemType<BejeweledSpike>())
                .AddIngredient(ModContent.ItemType<ProfanedHeart>())
                //.AddTile(ModLoader.GetMod("CalamityMod").TileType("DraedonsForge"));
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }
    }
}