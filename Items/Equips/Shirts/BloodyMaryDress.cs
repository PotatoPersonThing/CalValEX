using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace CalValEX.Items.Equips.Shirts
{
    [AutoloadEquip(EquipType.Body, EquipType.Legs)]
    public class BloodyMaryDress : ModItem
    {
        public override void SetStaticDefaults() => Item.ResearchUnlockCount = 1;

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 14;
            Item.rare = CalamityID.CalRarityID.Turquoise;
            Item.vanity = true;
            Item.value = Item.sellPrice(0, 3, 0, 0);
            ArmorIDs.Body.Sets.HidesArms[Item.bodySlot] = false;
        }
        public override void UpdateEquip(Player player)
        {
            var p = player.GetModPlayer<CalValEXPlayer>();
            p.maryTrans = true;
        }

        public override void UpdateVanity(Player player)
        {
            var p = player.GetModPlayer<CalValEXPlayer>();
            p.maryHide = true;
        }
    }
}