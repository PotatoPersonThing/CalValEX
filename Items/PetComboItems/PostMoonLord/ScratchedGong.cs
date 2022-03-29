using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Items.Pets;
using CalValEX.Items.PetComboItems.PreHardmode;
using CalValEX.Items.PetComboItems.Hardmode;
using CalValEX.Items.Pets.ExoMechs;

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
            item.CloneDefaults(ItemID.ZephyrFish);
            item.UseSound = SoundID.NPCHit4;
            item.shoot = mod.ProjectileType("WulfrumPylon");
            item.value = Item.sellPrice(0, 16, 6, 9);
            item.rare = 12;
            item.buffType = mod.BuffType("ScratchedGongBuff");
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
            string[] summonedPets = new string[] {"WulfrumPylon", "WulfrumDrone", "WulfrumRover", "WulfrumHover", "WulfrumOrb", "RepairBot", "RoverSpindlePet", "DiggerPet", "Androomba", "AstPhage", "PBGMini", "SeerS", "SeerM", "SeerL", "ThanatosPet", "AresBody", "TwinsPet" };
            foreach (string pet in summonedPets)
            {
                Projectile.NewProjectile(player.Center, new Vector2(speedX, speedY), mod.ProjectileType(pet), 0, 0, player.whoAmI);
            }
            return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<AlarmClock>());
            recipe.AddIngredient(ModContent.ItemType<HarbingerOfWork>());
            recipe.AddIngredient(ModContent.ItemType<ExoGemstone>());
            recipe.AddTile(ModLoader.GetMod("CalamityMod").TileType("DraedonsForge"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}