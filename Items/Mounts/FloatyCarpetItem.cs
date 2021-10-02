using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Mounts
{
    public class FloatyCarpetItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Floaty Carpet");
            Tooltip.SetDefault("A floating carpet made out of a Floaty!\n" + "Summons a floaty carpet that prevents fall damage when hovering");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 30;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 1;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = 2;
            //item.UseSound = SoundID.Item23;
            item.noMelee = true;
            item.mountType = mod.MountType("FloatyCarpet");
        }
    }
}