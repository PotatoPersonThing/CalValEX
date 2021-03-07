using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{
    public class JellyBottle : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Space Junk");
            Tooltip.SetDefault("Summons the forgotten blob of the astral meteor");
            ItemID.Sets.ItemNoGravity[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.UseSound = SoundID.Item117;
            item.shoot = mod.ProjectileType("StarJelly");
            item.value = Item.sellPrice(0, 4, 0, 0);
            item.rare = 6;
            item.buffType = mod.BuffType("JellyBuff");
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