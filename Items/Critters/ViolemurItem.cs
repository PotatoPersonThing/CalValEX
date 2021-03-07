using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CalValEX.Items.Critters
{
    internal class ViolemurItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Violemur");
        }

        public override void SetDefaults()
        {
            item.useStyle = 1;
            item.autoReuse = true;
            item.useTurn = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.maxStack = 999;
            item.consumable = true;
            item.width = 22;
            item.height = 18;
            item.noUseGraphic = true;
            item.rare = 4;

            Mod mod = ModLoader.GetMod("CalamityMod");
            if (mod == null)
            {
                return;
            }
            item.makeNPC = (short)NPCType<Violemur>();
        }
    }
}