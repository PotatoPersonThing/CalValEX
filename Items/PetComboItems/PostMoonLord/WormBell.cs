using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Items.Pets;
using CalValEX.Items.LightPets;

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
            item.CloneDefaults(ItemID.ZephyrFish);
            item.UseSound = SoundID.NPCHit4;
            item.shoot = mod.ProjectileType("SWPet");
            item.value = Item.sellPrice(0, 20, 30, 60);
            item.rare = 14;
            item.buffType = mod.BuffType("WormBellBuff");
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
            string[] summonedPets = new string[] {"SWPet", "StasisNaked", "AquaPet", "DesertPet", "DeusPetSmall", "DeusPet", "DogHead", "JaredHead", "SepulcherHeadNeo"};
            foreach (string pet in summonedPets)
            {
                Projectile.NewProjectile(player.Center, new Vector2(speedX, speedY), mod.ProjectileType(pet), 0, 0, player.whoAmI);
            }
            return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<WeaverFlesh>());
            recipe.AddIngredient(ModContent.ItemType<SeaCoin>());
            recipe.AddIngredient(ModContent.ItemType<AstralStar>());
            recipe.AddIngredient(ModContent.ItemType<DogPetItem>());
            recipe.AddIngredient(ModContent.ItemType<SoulShard>());
            recipe.AddIngredient(ModContent.ItemType<CalamitousSoulArtifact>());
            recipe.AddTile(ModLoader.GetMod("CalamityMod").TileType("DraedonsForge"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}