using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Hats
{
    [AutoloadEquip(EquipType.Head)]
    public class OlTrashtooth : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ol Trashtooth");
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 12;
            Item.rare = ItemRarityID.Orange;
            Item.vanity = true;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Terraria.ID.ArmorIDs.Head.Sets.DrawHatHair[Item.headSlot] = true;
        }
    }
}