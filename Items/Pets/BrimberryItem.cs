using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Projectiles.Pets;
using CalValEX.Buffs.Pets;
using Microsoft.Xna.Framework.Graphics;
using static Terraria.ModLoader.ModContent;
using CalamityMod.Items.Weapons.Summon;
using System;

namespace CalValEX.Items.Pets {
    public class BrimberryItem : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Brimstone Berry");
            Tooltip.SetDefault(CalValEX.month == 6 ? "I can double jump!" : "Summons an ancient fruit" +
                "\nOften used as offering to the Brimstone Goddess");
            SacrificeTotal = 1;
        }

        public override void SetDefaults() {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCHit1;
            Item.shoot = ProjectileType<BrimberryPet>();
            Item.value = Item.sellPrice(0, 2, 9, 0);
            Item.rare = ItemRarityID.LightRed;
            Item.buffType = BuffType<BrimberryBuff>();
        }

        public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale) {
            spriteBatch.Draw(Assets().Item1, position, new Rectangle(Assets().Item2 ? 22 : 0, 0, 20, 22), drawColor, 0f, Vector2.Zero, 1, SpriteEffects.None, 0f);

            return false;
        }

        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI) {
            var pos = new Vector2(Item.position.X, Item.position.Y);
            spriteBatch.Draw(Assets().Item1, pos - Main.screenPosition, new Rectangle(Assets().Item2 ? 22 : 0, 0, 20, 22),
                alphaColor, rotation, Vector2.Zero, 1, SpriteEffects.None, 0f);

            return false;
        }

        private Tuple<Texture2D, bool> Assets() {
            return Tuple.Create(Request<Texture2D>("CalValEX/Items/Pets/BrimberryItem").Value, Main.LocalPlayer.HasItem(ItemType<DormantBrimseeker>()));
        }

        public override void UseStyle(Player player, Rectangle heldItemFrame) {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
                player.AddBuff(Item.buffType, 3600, true);
        }
    }
}