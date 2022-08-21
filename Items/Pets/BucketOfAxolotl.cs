using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets {
    public class BucketOfAxolotl : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Zygote in a Bucket");
            Tooltip.SetDefault("Summons an ancient ghastly fetus");
            SacrificeTotal = 1;
        }

        public override void SetDefaults() {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.Item111;
            Item.shoot = ModContent.ProjectileType<Projectiles.Pets.GhastlyZygote>();
            Item.value = Item.sellPrice(0, 0, 0, 1);
            Item.rare = 11;
            Item.expert = true;
            Item.buffType = ModContent.BuffType<Buffs.Pets.ZygoteBuff>();
        }

        public override void UseStyle(Player player, Microsoft.Xna.Framework.Rectangle heldItemFrame) {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
                player.AddBuff(Item.buffType, 3600, true);
        }
    }
}