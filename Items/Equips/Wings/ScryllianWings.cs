using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Wings
{
    [AutoloadEquip(EquipType.Wings)]
    public class ScryllianWings : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Scryllian Wings");
            Tooltip.SetDefault("RISE!\n" + "Inflicts intense burns when worn before the flesh wall falls\n" + "Horizontal speed: 6.5\n" + "Acceleration multiplier: 1\n" + "Flight time: 60");
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            Terraria.ID.ArmorIDs.Wing.Sets.Stats[Item.wingSlot] = new Terraria.DataStructures.WingStats(60, 6.5f, 1f);
        }

        public override void SetDefaults()
        {
            Item.width = 42;
            Item.height = 26;
            Item.rare = 3;
            Item.accessory = true;
            Item.value = Item.sellPrice(0, 1, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {           
            if (!Main.hardMode)
                player.AddBuff(Terraria.ID.BuffID.CursedInferno, 2);
        }

        public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising, ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
        {
            ascentWhenFalling = 0.5f;
            ascentWhenRising = 0.1f;
            maxCanAscendMultiplier = 0.5f;
            maxAscentMultiplier = 1.5f;
            constantAscend = 0.1f;
        }
    }
}