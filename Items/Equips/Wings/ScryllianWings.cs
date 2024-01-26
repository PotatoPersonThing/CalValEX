using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace CalValEX.Items.Equips.Wings
{
    [AutoloadEquip(EquipType.Wings)]
    public class ScryllianWings : ModItem
    {
        public override void SetStaticDefaults()
        {
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            ArmorIDs.Wing.Sets.Stats[Item.wingSlot] = new Terraria.DataStructures.WingStats(60, 6.5f, 1f);
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 42;
            Item.height = 26;
            Item.rare = ItemRarityID.Orange;
            Item.accessory = true;
            Item.value = Item.sellPrice(0, 1, 0, 0);
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