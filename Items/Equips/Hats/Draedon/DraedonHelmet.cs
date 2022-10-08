using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Hats.Draedon
{
    [AutoloadEquip(EquipType.Head)]
    public class DraedonHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            ArmorIDs.Head.Sets.DrawHead[Item.headSlot] = false;
            SacrificeTotal = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.rare = ItemRarityID.Blue;
            Item.vanity = true;
        }
    }
}