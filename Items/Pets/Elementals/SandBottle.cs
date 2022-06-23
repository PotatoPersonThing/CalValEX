using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets.Elementals
{
    public class SandBottle : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Small Sand Pail");
            Tooltip.SetDefault("An elemental's favorite pail!\n" + "Summons a Miniature Sand Elemental");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.ZephyrFish);
            item.UseSound = SoundID.NPCHit5;
            item.shoot = mod.ProjectileType("sandmini");
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = 4;
            item.buffType = mod.BuffType("SsandBuff");
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