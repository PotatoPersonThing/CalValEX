using Terraria;

namespace CalValEX.Projectiles.Pets.Scuttlers
{
    public class SapphirePet : ScuttlerBase
    {
        public override string ScuttlerName => "Sapphire";

        public override void SetDefaults()
        {
            base.SetDefaults();
            drawOriginOffsetY = -2;
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.mSap = false;

            if (modPlayer.mSap)
                projectile.timeLeft = 2;
        }
    }
}