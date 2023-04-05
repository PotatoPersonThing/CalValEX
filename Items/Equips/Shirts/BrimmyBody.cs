using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Shirts
{
    [AutoloadEquip(EquipType.Body)]
    public class BrimmyBody : ModItem {
        public override void SetStaticDefaults() => Item.ResearchUnlockCount = 1;

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 14;
            Item.rare = 5;
            Item.vanity = true;
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Terraria.ID.ArmorIDs.Body.Sets.HidesArms[Item.bodySlot] = true;
        }
    }
}