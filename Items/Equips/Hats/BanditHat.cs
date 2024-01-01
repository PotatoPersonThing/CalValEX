using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Hats
{
    [AutoloadEquip(EquipType.Head)]
    public class BanditHat : ModItem
    {
        public override void SetStaticDefaults() => Item.ResearchUnlockCount = 1;

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 12;
            Item.rare = ItemRarityID.Orange;
            Item.vanity = true;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            ArmorIDs.Head.Sets.DrawHatHair[Item.headSlot] = true;
        }
    }
}