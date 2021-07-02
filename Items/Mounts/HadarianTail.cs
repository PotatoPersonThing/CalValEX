using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Mounts
{
    public class HadarianTail : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hadarian Egg");
            Tooltip.SetDefault("Contains an infected scavenger to let you soar to new heights");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 30;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 1;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = 7;
            //item.UseSound = SoundID.Item23;
            item.noMelee = true;
            item.mountType = mod.MountType("HadarianMount");
        }
    }
}