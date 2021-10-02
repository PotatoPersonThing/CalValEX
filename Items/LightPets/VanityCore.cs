using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.LightPets
{
    public class VanityCore : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Core of Vanity");
            Tooltip.SetDefault("Summons pet Heat Sprits, Cryogen's Shield, and a Sunskater to follow you\n" + "Provides a large amount of light in the abyss");
            ItemID.Sets.ItemNoGravity[item.type] = true;
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6, 6));
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.ZephyrFish);
            item.UseSound = SoundID.Item45;
            item.shoot = mod.ProjectileType("HeatPet");
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = ItemRarityID.Red;
            item.buffType = mod.BuffType("VanityCoreBuff");
            item.noUseGraphic = true;
        }

        public override void UseStyle(Player player)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(item.buffType, 3600, true);
            }
        }

        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            type = mod.ProjectileType("HeatBaby");
            return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            if (calamityMod != null)
            {
                recipe.AddIngredient(ModContent.ItemType<SkeetCrest>());
                recipe.AddIngredient(ModContent.ItemType<ChaosEssence>());
                recipe.AddIngredient(ModContent.ItemType<AntarcticEssence>());
                recipe.AddIngredient(calamityMod.ItemType("CoreofCalamity"));
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }
    }
}