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
            // DisplayName.SetDefault("Bejeweled Spike");
            // Tooltip.SetDefault("'A blend of every flavor combined into one package'\n" + "Summons a rainbow Bejeweled Scuttler");
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCHit31;
            Item.shoot = ModContent.ProjectileType<Projectiles.Pets.Scuttlers.BejeweledScuttler>();
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = ItemRarityID.LightRed;
            Item.width = 26;
            Item.height = 32;
            Item.buffType = ModContent.BuffType<Buffs.Pets.Scuttlers.BejeweledBuff>();
        }

        public override void UseStyle(Player player, Microsoft.Xna.Framework.Rectangle heldItemFrame)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(Item.buffType, 3600, true);
            }
        }
        public override void PostDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            Texture2D texture = ModContent.Request<Texture2D>("CalValEX/Items/Pets/Scuttlers/BejeweledSpike").Value;
            spriteBatch.Draw(texture, position, frame, new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB, 109), 0f, origin, scale, SpriteEffects.None, 0);
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAm)
        {
            Texture2D texture = ModContent.Request<Texture2D>("CalValEX/Items/Pets/Scuttlers/BejeweledSpike").Value;
            spriteBatch.Draw(texture, Item.position - Main.screenPosition, new Rectangle(0, 0, Item.width, Item.height), new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB, 139), 0f, Vector2.Zero, 1f, SpriteEffects.None, 0);
        }
    }
}