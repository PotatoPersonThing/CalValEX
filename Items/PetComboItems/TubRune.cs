using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Items.Pets;
using CalValEX.Items.PetComboItems.PreHardmode;
using CalValEX.Items.PetComboItems.Hardmode;
using CalValEX.Items.PetComboItems.PostMoonLord;
using CalValEX.Items.Pets.ExoMechs;

namespace CalValEX.Items.PetComboItems
{
    public class TubRune : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tub Rune");
            Tooltip.SetDefault("Change the world");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.ZephyrFish);
            item.UseSound = SoundID.NPCHit4;
            item.shoot = mod.ProjectileType("");
            item.value = Item.sellPrice(7, 7, 7, 0);
            item.rare = 15;
            item.buffType = mod.BuffType("TubRuneBuff");
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
            string[] summonedPets = new string[] {"CalamityBABY", "CoolBlueSignut", "CoolBlueSlime", "GoozmaPet", "UngodlySerpent", "Sirember"};
            foreach (string pet in summonedPets)
            {
                Projectile.NewProjectile(player.Center, new Vector2(speedX, speedY), mod.ProjectileType(pet), 0, 0, player.whoAmI);
            }
            return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<YharexsLetter>());
            recipe.AddIngredient(ModContent.ItemType<Ectogasm>());
            recipe.AddIngredient(ModContent.ItemType<GoozmaPetItem>());
            recipe.AddIngredient(ModContent.ItemType<ChewyToy>());
            recipe.AddIngredient(ModContent.ItemType<Rember>());
            recipe.AddTile(ModLoader.GetMod("CalamityMod").TileType("DraedonsForge"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}