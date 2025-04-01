using Terraria.GameContent.UI;
using Terraria.ModLoader;

namespace CalValEX.Emotes
{
    public class JharimEmote : ModEmoteBubble
    {
        public override void SetStaticDefaults()
        {
            AddToCategory(EmoteID.Category.Town);
        }

        public override bool IsUnlocked()
        {
            return CalValEX.AprilFoolMonth || CalValEXWorld.jharim;
        }
    }
}
