using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Items.Pets;
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
            item.CloneDefaults(ItemID.ZephyrFish);
            item.UseSound = SoundID.NPCHit4;
            item.shoot = mod.ProjectileType("WulfrumPylon");
            item.value = Item.sellPrice(0, 6, 50, 0);
            item.rare = 5;
            item.buffType = mod.BuffType("AlarmClockBuff");
        }

        public override void UseStyle(Player player)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(item.buffType, 3600, true);
            }
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            string[] summonedPets = new string[] { "WulfrumPylon", "WulfrumDrone", "WulfrumRover", "WulfrumHover", "WulfrumOrb", "RepairBot" };
            foreach (string pet in summonedPets)
            {
                Projectile.NewProjectile(player.Center, new Vector2(speedX, speedY), mod.ProjectileType(pet), 0, 0, player.whoAmI);
            }
            return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }
        public override void AddRecipes()
        {
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            if (calamityMod != null)
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ModContent.ItemType<WulfrumController>());
                recipe.AddIngredient(ModContent.ItemType<PylonRemote>());
                recipe.AddIngredient(ModContent.ItemType<RepurposedMonitor>());
                recipe.AddTile(calamityMod.TileType("LaboratoryConsole"));
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }
    }
}