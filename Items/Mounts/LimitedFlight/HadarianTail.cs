using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Mounts.LimitedFlight
{
    public class HadarianTail : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hadarian Egg");
            Tooltip.SetDefault("Contains an infected scavenger to let you soar to new heights");
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
            Item.mountType = ModContent.MountType<HadarianMount>();
        }
    }
}