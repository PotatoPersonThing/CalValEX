using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets.Elementals
{
    public class WetBubble : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Strange Music Note");
            Tooltip.SetDefault("An elemental's favorite sound!\n" + "Summons a Vibrant Siren Child");
            ItemID.Sets.ItemNoGravity[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.ZephyrFish);
            item.UseSound = SoundID.NPCHit5;
            item.shoot = mod.ProjectileType("babywaterclone");
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = 4;
            item.buffType = mod.BuffType("MoistBuff");
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