using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;

namespace CalValEX.Items.Equips.Hats.Draedon
{
    public class DraedonHelmetTextureCache
    {
        public static Texture2D melee;
        public static Texture2D ranger;
        public static Texture2D magic;
        public static Texture2D rogue;
        public static Texture2D summoner;
        public static Texture2D none;
        public static void Load(Mod mod)
        {
            string path = "Items/Equips/Hats/Draedon/DraedonHelmet_Head";
            none = mod.GetTexture(path);
            melee = mod.GetTexture(path + "_Melee");
            ranger = mod.GetTexture(path + "_Ranger");
            rogue = mod.GetTexture(path + "_Rogue");
            magic = mod.GetTexture(path + "_Magic");
            summoner = mod.GetTexture(path + "_Summoner");
        }

        public static void Unload(Mod mod)
        {
            none = null;
            melee = null;
            rogue = null;
            magic = null;
            summoner = null;
        }
    }
}
