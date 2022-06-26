using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Legs.Draedon
{
    [AutoloadEquip(EquipType.Legs)]
    public class DraedonLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Arsenal Soldier Leggings\n"+"CURRENTLY UNSTABLE\n"+"Well, not really, only the other pieces are,\n"+"but why would you use these without them?");
            SacrificeTotal = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 36;
            Item.height = 24;
            Item.rare = ItemRarityID.Blue;
            Item.vanity = true;
        }
    }
}