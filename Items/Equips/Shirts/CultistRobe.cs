using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Shirts
{
    [AutoloadEquip(EquipType.Body)]
    public class CultistRobe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cultist Assassin Robe");
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 14;
            Item.rare = 4;
            Item.vanity = true;
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Terraria.ID.ArmorIDs.Body.Sets.HidesArms[Item.bodySlot] = true;
        }
    }
}