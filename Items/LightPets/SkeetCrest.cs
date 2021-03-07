using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.LightPets
{
    public class SkeetCrest : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Essence of Yeet");
            Tooltip.SetDefault("Sunfish gang, sunfish gang.");
            ItemID.Sets.ItemNoGravity[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.UseSound = SoundID.NPCHit51;
            item.shoot = mod.ProjectileType("Skeetyeet");
            item.value = Item.sellPrice(0, 0, 0, 10);
            item.rare = 2;
            item.buffType = mod.BuffType("YeetBuff");
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