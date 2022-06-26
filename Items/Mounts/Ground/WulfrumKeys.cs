using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Mounts.Ground

{
    public class WulfrumKeys : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wulfrum Keys");
            SacrificeTotal = 1;
            Tooltip.SetDefault("Gives you access to a Wulfrum Tank\nThe keys wield dark energy which will lay a fatal curse on your health and damage if a powerful entity is near\nYou already know how to operate it... somehow...");
        }

        public override void SetDefaults()
        {
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = 1;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = 1;
            Item.UseSound = SoundID.Item23;
            Item.noMelee = true;
            Item.mountType = ModContent.MountType<WulfrumTractor>();
        }
    }
}