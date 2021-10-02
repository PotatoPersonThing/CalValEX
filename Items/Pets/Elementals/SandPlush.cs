using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets.Elementals
{
    public class SandPlush : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Small Sand Plushie");
            Tooltip.SetDefault("An elemental's favorite toy!\n" + "Summons a Rare Miniature Sand Elemental");
        }

        public override void SetDefaults()
        {
            item.UseSound = SoundID.NPCHit5;
            item.shoot = mod.ProjectileType("raresandmini");
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = 5;
            item.buffType = mod.BuffType("RareSsandBuff");
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