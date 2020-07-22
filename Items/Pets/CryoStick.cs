using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Utilities;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets
{
    public class CryoStick : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cool Shades");
            Tooltip.SetDefault("Rad");
        }

        public override void SetDefaults()
        {
             item.UseSound = SoundID.NPCHit5;
            item.shoot = mod.ProjectileType("MiniCryo");
            item.buffType = mod.BuffType("ChilledOut");
            item.value = Item.sellPrice(0, 0, 10, 0);
            item.rare = 5;
            
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