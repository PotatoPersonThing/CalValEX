using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Mounts

{
    public class WulfrumKeys : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wulfrum Keys");
            Tooltip.SetDefault("Gives you access to a Wulfrum Tank\nThe keys wield dark energy which will lay a fatal curse on your health and damage if a powerful entity is near\nYou already know how to operate it... somehow...");
        }

        public override void SetDefaults()
        {
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 1;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = 1;
            item.UseSound = SoundID.Item23;
            item.noMelee = true;
            item.mountType = mod.MountType("WulfrumTractor");
        }
    }
}