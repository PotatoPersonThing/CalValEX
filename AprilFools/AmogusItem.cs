using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.AprilFools
{
    public class AmogusItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            if (CalValEX.month == 4)
            {
                DisplayName.SetDefault("Stratus Astronaut");
                Tooltip.SetDefault("'amogus'");
                Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(4, 4));
            }
            else
            {
                DisplayName.SetDefault("Polus Communicator");
                Tooltip.SetDefault("'summons a Stratus Astronaut'");
            }
            
        }

        public override string Texture => (CalValEX.month == 4 ? "CalValEX/AprilFools/AmogusItem" : "CalValEX/AprilFools/AmogusItemReal");

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 36;
            item.CloneDefaults(ItemID.ZephyrFish);
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "AprilFools/AmogusScream");
            item.shoot = mod.ProjectileType("Amogus");
            item.value = Item.sellPrice(0, 0, 0, 0);
            item.rare = 10;
            item.buffType = mod.BuffType("AmogusBuff");
            item.noUseGraphic = true;
            item.expert = true;
        }

        public override void UseStyle(Player player)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(item.buffType, 3600, true);
            }
        }
    }
}