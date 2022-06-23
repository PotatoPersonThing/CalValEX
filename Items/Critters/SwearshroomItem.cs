using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using CalValEX.NPCs.Critters;

namespace CalValEX.Items.Critters
{
    public class SwearshroomItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Swearshroom");
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
            Item.height = 22;
            Item.noUseGraphic = true;
            Item.rare = 2;

            /*Mod mod = ModLoader.GetMod("CalamityMod");
            if (mod == null)
            {
                return;
            }*/
            Item.makeNPC = (short)NPCType<Swearshroom>();
        }
    }
}