using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Buffs.PetComboBuffs;
using CalValEX.Items.Pets;
using CalValEX.Projectiles.Pets;
using CalValEX.Projectiles.Pets.Wulfrum;
using CalValEX.Items.LightPets;

namespace CalValEX.Items.PetComboItems.PreHardmode
{
    public class AlarmClock : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Alarm Clock");
            Tooltip.SetDefault("Spare parts for your travels");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCHit4;
            Item.value = Item.sellPrice(0, 6, 50, 0);
            Item.rare = 5;
            Item.buffType = ModContent.BuffType<AlarmClockBuff>();
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
            return base.Shoot(player, source, position, velocity, type, damage, knockback);
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<WulfrumController>())
                .AddIngredient(ModContent.ItemType<PylonRemote>())
                .AddIngredient(ModContent.ItemType<RepurposedMonitor>())
                //.AddTile(ModLoader.GetMod("CalamityMod").TileType<LaboratoryConsole>())
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}