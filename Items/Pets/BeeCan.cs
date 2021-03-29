using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{
    public class BeeCan : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Plaguebringer Power Cell");
            Tooltip.SetDefault("Full of vitamin Bee!");
        }

        public override void SetDefaults()
        {
            item.UseSound = SoundID.NPCHit4;
            item.shoot = mod.ProjectileType("PBGmini");
            item.value = Item.sellPrice(0, 0, 50, 0);
            item.rare = 5;
            item.buffType = mod.BuffType("BeeBuff");
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