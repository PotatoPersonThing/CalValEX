using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX.NPCs.Critters;

namespace CalValEX.Items.Critters
{
    public class PlagueFrogItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Plagued Frog");
        }

        public override void SetDefaults()
        {
            Item.useStyle = 1;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.maxStack = 999;
            Item.consumable = true;
            Item.width = 22;
            Item.height = 18;
            Item.noUseGraphic = true;
            Item.rare = 8;

            /*Mod mod = ModLoader.GetMod("CalamityMod");
            if (mod == null)
            {
                return;
            }*/
            Item.makeNPC = (short)NPCType<PlagueFrog>();
        }
    }
}