using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Biomes
{
    public class AstralBlightScene : ModSceneEffect
    {
        public override bool IsSceneEffectActive(Player player) => player.InModBiome(ModContent.GetInstance<AstralBlight>());

        public override string MapBackground => "CalValEX/Biomes/AstralMap";
    }
}