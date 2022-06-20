using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Hats.Draedon
{
    [AutoloadEquip(EquipType.Head)]
    public class DraedonHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Arsenal Soldier Helmet");
            Tooltip.SetDefault("Changes appearance depending on held item damage type\nCURRENTLY UNSTABLE");
            ArmorIDs.Head.Sets.DrawHead[Item.headSlot] = false;
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