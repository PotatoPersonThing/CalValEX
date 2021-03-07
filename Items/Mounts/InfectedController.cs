using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Mounts
{
    public class InfectedController : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Diseased Joystick");
            Tooltip.SetDefault("It emits 8 bit buzzing");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 30;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 1;
            item.value = Item.sellPrice(0, 20, 50, 0);
            item.rare = 7;
            //item.UseSound = SoundID.Item23;
            item.noMelee = true;
            item.mountType = mod.MountType("PBGMount");
        }
    }
}