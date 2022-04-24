using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Buffs.PetComboBuffs;
using CalValEX.Projectiles.Pets;
using CalValEX.Items.PetComboItems.PreHardmode;
using CalValEX.Items.PetComboItems.Hardmode;
using CalValEX.Items.Pets.ExoMechs;
using CalValEX.Projectiles.Pets.Wulfrum;
using CalValEX.Projectiles.Pets.LightPets;
using CalValEX.Projectiles.Pets.ExoMechs;

namespace CalValEX.Items.PetComboItems.PostMoonLord
{
    public class ScratchedGong : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Scratched Gong");
            Tooltip.SetDefault("Desire for creation");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCHit4;
            Item.value = Item.sellPrice(1, 6, 6, 9);
            Item.rare = 9;// 12;
            Item.buffType = ModContent.BuffType<ScratchedGongBuff>();
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
            type = ModContent.ProjectileType<WulfrumPylon>();
            type = ModContent.ProjectileType<WulfrumDrone>();
            type = ModContent.ProjectileType<WulfrumRover>();
            type = ModContent.ProjectileType<WulfrumHover>();
            type = ModContent.ProjectileType<WulfrumOrb>();
            type = ModContent.ProjectileType<RepairBot>();
            type = ModContent.ProjectileType<RoverSpindlePet>();
            type = ModContent.ProjectileType<DiggerPet>();
            type = ModContent.ProjectileType<Androomba>();
            type = ModContent.ProjectileType<AstPhage>();
            type = ModContent.ProjectileType<PBGmini>();
            type = ModContent.ProjectileType<SeerS>();
            type = ModContent.ProjectileType<SeerM>();
            type = ModContent.ProjectileType<SeerL>();
            type = ModContent.ProjectileType<ThanatosPet>();
            type = ModContent.ProjectileType<AresBody>();
            type = ModContent.ProjectileType<TwinsPet>();
            return base.Shoot(player, source, position, velocity, type, damage, knockback);
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<AlarmClock>())
                .AddIngredient(ModContent.ItemType<HarbingerOfWork>())
                .AddIngredient(ModContent.ItemType<ExoGemstone>())
                //.AddTile(ModLoader.GetMod("CalamityMod").TileType<DraedonsForge>())
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }
    }
}