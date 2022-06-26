using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Mounts.LimitedFlight
{
    public class FloatyCarpetItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Floaty Carpet");
            Tooltip.SetDefault("A floating carpet made out of a Floaty!\n" + "Summons a floaty carpet that prevents fall damage when hovering");
            SacrificeTotal = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 30;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = 1;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = 2;
            //Item.UseSound = SoundID.Item23;
            Item.noMelee = true;
            Item.mountType = ModContent.MountType<FloatyCarpet>();
        }
    }
}