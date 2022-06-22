/*using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Buffs.PetComboBuffs;
using CalValEX.Items.Pets;
using CalValEX.Projectiles.Pets;
using CalValEX.Projectiles.Pets.SepulcherNeo;

namespace CalValEX.Items.PetComboItems.PostMoonLord
{
    public class WormBell : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Slither Charm");
            Tooltip.SetDefault("But does it ring any bells?\nThat I don't mention the hell?");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCHit4;
            Item.value = Item.sellPrice(0, 20, 30, 60);
            Item.rare = 9;// 14;
            Item.buffType = ModContent.BuffType<WormBellBuff>();
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
            type = ModContent.ProjectileType<SWPet>();
            type = ModContent.ProjectileType<StasisNaked>();
            type = ModContent.ProjectileType<AquaPet>();
            type = ModContent.ProjectileType<DesertPet>();
            type = ModContent.ProjectileType<DeusPetSmall>();
            type = ModContent.ProjectileType<DeusPet>();
            type = ModContent.ProjectileType<DogHead>();
            type = ModContent.ProjectileType<JaredHead>();
            type = ModContent.ProjectileType<SepulcherHeadNeo>();
            return base.Shoot(player, source, position, velocity, type, damage, knockback);
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<StormMedal>())
                .AddIngredient(ModContent.ItemType<TheSeaKingsCoin>())
                .AddIngredient(ModContent.ItemType<Geminga>())
                .AddIngredient(ModContent.ItemType<CosmicRapture>())
                .AddIngredient(ModContent.ItemType<SoulShard>())
                .AddIngredient(ModContent.ItemType<CalamitousSoulArtifact>())
                //.AddTile(ModLoader.GetMod("CalamityMod").TileType<DraedonsForge>())
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }
    }
}*/