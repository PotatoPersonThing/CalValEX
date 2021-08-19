using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CalValEX.Items.Pets.Scuttlers
{
    public class BejeweledSpike : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bejeweled Spike");
            Tooltip.SetDefault("'A blend of every flavor combined into one package'");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.ZephyrFish);
            item.UseSound = SoundID.NPCHit31;
            item.shoot = mod.ProjectileType("BejeweledScuttler");
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = 4;
            item.width = 26;
            item.height = 32;
            item.buffType = mod.BuffType("BejeweledBuff");
        }

        public override void UseStyle(Player player)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(item.buffType, 3600, true);
            }
        }
        public override void PostDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            Texture2D texture = ModContent.GetTexture("CalValEX/Items/Pets/Scuttlers/BejeweledSpike");
            spriteBatch.Draw(texture, position, frame, new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB, 109), 0f, origin, scale, SpriteEffects.None, 0);
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAm)
        {
            Texture2D texture = ModContent.GetTexture("CalValEX/Items/Pets/Scuttlers/BejeweledSpike");
            spriteBatch.Draw(texture, item.position - Main.screenPosition, new Rectangle(0, 0, item.width, item.height), new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB, 139), 0f, Vector2.Zero, 1f, SpriteEffects.None, 0);
        }
        public override void AddRecipes()
        {
            Mod CalValEX = ModLoader.GetMod("CalamityMod");
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ModLoader.GetMod("CalamityMod").ItemType("ScuttlersJewel"), 1);
                recipe.AddIngredient(ModContent.ItemType<AmberStone>(), 1);
                recipe.AddIngredient(ModContent.ItemType<AmethystStone>(), 1);
                recipe.AddIngredient(ModContent.ItemType<SapphireStone>(), 1);
                recipe.AddIngredient(ModContent.ItemType<EmeraldStone>(), 1);
                recipe.AddIngredient(ModContent.ItemType<TopazStone>(), 1);
                recipe.AddIngredient(ModContent.ItemType<RubyStone>(), 1);
                recipe.AddIngredient(ModContent.ItemType<DiamondStone>(), 1);
                recipe.AddIngredient(ModContent.ItemType<CrystalStone>(), 1);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }
    }
}