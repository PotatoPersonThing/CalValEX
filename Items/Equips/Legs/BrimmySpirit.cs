using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Legs
{
    [AutoloadEquip(EquipType.Legs)]
    public class BrimmySpirit : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Brimstone Flames");
            SacrificeTotal = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 14;
            Item.rare = 5;
            Item.vanity = true;
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Terraria.ID.ArmorIDs.Legs.Sets.OverridesLegs[Item.legSlot] = true;
        }
    }
}