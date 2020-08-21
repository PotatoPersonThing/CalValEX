using CalValEX.Buffs.Pets;
using CalValEX.Projectiles.Pets;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{
    public class YharexsLetter : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Yharex's Letter");
            Tooltip.SetDefault("Hope you like my BABY version as a cute pet, also I recommend you have a Astral Slimy as companion");
        }

        public override void SetDefaults()
        {
            item.width = 44;
            item.height = 32;
            item.shoot = ModContent.ProjectileType<CalamityBABY>();
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.rare = ItemRarityID.Red;
            item.buffType = ModContent.BuffType<CalamityBABYBuff>();
            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = ItemUseStyleID.HoldingUp;
        }

        public override bool UseItem(Player player)
        {
            for (int i = 0; i < Main.maxPlayers; i++)
            {
                Player myPlayer = Main.player[i];
                if (myPlayer.active)
                {
                    myPlayer.GetModPlayer<CalValEXPlayer>().CalamityBabyGotHit = false;
                }
            }
            return true;
        }

        public override void UseStyle(Player player)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(item.buffType, 3600, true);
                Main.PlaySound(new LegacySoundStyle(4, 13), player.position);
            }
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            position.Y -= 50f;
            return true;
        }

        public override void AddRecipes()
        {
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(calamityMod.ItemType("AstralSlimeBanner"), 30);
            recipe.AddIngredient(ModContent.ItemType<Termipebbles>(), 999);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(calamityMod.ItemType("Rock"));
            recipe.AddIngredient(calamityMod.ItemType("AstralSlimeBanner"), 30);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
