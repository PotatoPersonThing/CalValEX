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
            DraedonDefaultHelm = ModContent.Request<Texture2D>(Path).Value;
            DraedonMeleeHelm = ModContent.Request<Texture2D>($"{Path}_Melee").Value;
            DraedonRangerHelm = ModContent.Request<Texture2D>($"{Path}_Ranger").Value;
            DraedonRogueHelm = ModContent.Request<Texture2D>($"{Path}_Rogue").Value;
            DraedonMagicHelm = ModContent.Request<Texture2D>($"{Path}_Magic").Value;
            DraedonSummonerHelm = ModContent.Request<Texture2D>($"{Path}_Summoner").Value;
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