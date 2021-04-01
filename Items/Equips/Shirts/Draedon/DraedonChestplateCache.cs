using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Shirts.Draedon
{
    public class DraedonChestplateCache
    {
        private const string Path = "CalValEX/Items/Equips/Shirts/Draedon/DraedonChestplate_Body";

        public static Texture2D DraedonMeleeChest { get; private set; }

        public static Texture2D DraedonRangerChest { get; private set; }

        public static Texture2D DraedonMagicChest { get; private set; }

        public static Texture2D DraedonRogueChest { get; private set; }

        public static Texture2D DraedonSummonerChest { get; private set; }

        public static Texture2D DraedonDefaultChest { get; private set; }

        public static void Load()
        {
            DraedonDefaultChest = ModContent.GetTexture(Path);
            DraedonMeleeChest = ModContent.GetTexture($"{Path}_Melee");
            DraedonRangerChest = ModContent.GetTexture($"{Path}_Ranger");
            DraedonRogueChest = ModContent.GetTexture($"{Path}_Rogue");
            DraedonMagicChest = ModContent.GetTexture($"{Path}_Magic");
            DraedonSummonerChest = ModContent.GetTexture($"{Path}_Summoner");
        }

        public static void Unload()
        {
            DraedonDefaultChest = null;
            DraedonMeleeChest = null;
            DraedonRogueChest = null;
            DraedonMagicChest = null;
            DraedonSummonerChest = null;
        }
    }
}