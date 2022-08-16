using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using CalValEX.Projectiles.Plushies;

namespace CalValEX.Items.Plushies {
    public class MirePlushThrowableP1 : ModItem {
        public override string Texture => "CalValEX/Items/Tiles/Plushies/MirePlushP1";
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Shielded Cragmaw Mire Plushie (Throwable)");
            Tooltip.SetDefault("Can be thrown");
            SacrificeTotal = 1;
        }

        public override void SetDefaults() {
            Item.useStyle = 1;
            Item.width = 44;
            Item.height = 44;
            Item.consumable = true;
            Item.UseSound = SoundID.Item1;
            Item.rare = 6;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.value = 20;
            Item.shoot = ModContent.ProjectileType<MirePlushP1>();
            Item.shootSpeed = 6f;
            Item.maxStack = 99;
        }
    }

    public class MirePlushThrowableP2 : ModItem {
        public override string Texture => "CalValEX/Items/Tiles/Plushies/MirePlushP2";
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Slimy Cragmaw Mire Plushie (Throwable)");
            Tooltip.SetDefault("Can be thrown");
            SacrificeTotal = 1;
        }

        public override void SetDefaults() {
            Item.useStyle = 1;
            Item.width = 44;
            Item.height = 44;
            Item.consumable = true;
            Item.UseSound = SoundID.Item1;
            Item.rare = 6;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.value = 20;
            Item.shoot = ModContent.ProjectileType<MirePlushP2>();
            Item.shootSpeed = 6f;
            Item.maxStack = 99;
        }
    }
}