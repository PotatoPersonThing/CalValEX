using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Mounts.LimitedFlight
{
    public class InfectedController : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Diseased Joystick");
            Tooltip.SetDefault("It emits 8 bit buzzing\n" + "Summons a rideable Plaguebringer");
            SacrificeTotal = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 30;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = 1;
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = 7;
            //Item.UseSound = SoundID.Item23;
            Item.noMelee = true;
            Item.mountType = ModContent.MountType<PBGMount>();
        }
    }
}