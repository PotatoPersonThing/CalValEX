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
            DraedonDefaultChest = ModContent.Request<Texture2D>(Path).Value;
            DraedonMeleeChest = ModContent.Request<Texture2D>($"{Path}_Melee").Value;
            DraedonRangerChest = ModContent.Request<Texture2D>($"{Path}_Ranger").Value;
            DraedonRogueChest = ModContent.Request<Texture2D>($"{Path}_Rogue").Value;
            DraedonMagicChest = ModContent.Request<Texture2D>($"{Path}_Magic").Value;
            DraedonSummonerChest = ModContent.Request<Texture2D>($"{Path}_Summoner").Value;
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