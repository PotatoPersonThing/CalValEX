using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Hats.Draedon
{
    public class DraedonHelmetTextureCache
    {
        private const string Path = "CalValEX/Items/Equips/Hats/Draedon/DraedonHelmet_Head";

        public static Texture2D DraedonMeleeHelm { get; private set; }

        public static Texture2D DraedonRangerHelm { get; private set; }

        public static Texture2D DraedonMagicHelm { get; private set; }

        public static Texture2D DraedonRogueHelm { get; private set; }

        public static Texture2D DraedonSummonerHelm { get; private set; }

        public static Texture2D DraedonDefaultHelm { get; private set; }

        public static void Load()
        {
            DraedonDefaultHelm = ModContent.GetTexture(Path);
            DraedonMeleeHelm = ModContent.GetTexture($"{Path}_Melee");
            DraedonRangerHelm = ModContent.GetTexture($"{Path}_Ranger");
            DraedonRogueHelm = ModContent.GetTexture($"{Path}_Rogue");
            DraedonMagicHelm = ModContent.GetTexture($"{Path}_Magic");
            DraedonSummonerHelm = ModContent.GetTexture($"{Path}_Summoner");
        }

        public static void Unload()
        {
            DraedonDefaultHelm = null;
            DraedonMeleeHelm = null;
            DraedonRogueHelm = null;
            DraedonMagicHelm = null;
            DraedonSummonerHelm = null;
        }
    }
}