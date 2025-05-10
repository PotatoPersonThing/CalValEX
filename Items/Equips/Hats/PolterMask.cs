using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace CalValEX.Items.Equips.Hats
{
    [AutoloadEquip(EquipType.Head)]
    public class PolterMask : ModItem
    {
        public override void SetStaticDefaults() => Item.ResearchUnlockCount = 1;

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 20;
            Item.rare = CalamityID.CalRarityID.PureGreen;
            Item.vanity = true;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            ArmorIDs.Head.Sets.DrawHead[Item.headSlot] =  false;
        }

        public override void UpdateEquip(Player player)
        {
            player.GetModPlayer<CalValEXPlayer>().poltermask = true;
        }

        public override void UpdateVanity(Player player)
        {
            player.GetModPlayer<CalValEXPlayer>().poltermask = true;
        }
    }
}