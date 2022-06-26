using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Hats
{
    [AutoloadEquip(EquipType.Head)]
    public class Calacirclet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Calamity Circlet");
            Tooltip.SetDefault("Ring of Fire!");
            SacrificeTotal = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 14;
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = ItemRarityID.Lime;
            Item.vanity = true;
            Terraria.ID.ArmorIDs.Head.Sets.DrawHatHair[Item.headSlot] = true;
        }
    }
}