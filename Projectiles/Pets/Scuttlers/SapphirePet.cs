using Terraria;

namespace CalValEX.Projectiles.Pets.Scuttlers
{
    public class SapphirePet : ScuttlerBase
    {
        public override string ScuttlerName => "Sapphire";

        public override void SetDefaults()
        {
            base.SetDefaults();
            DrawOriginOffsetY = -2;
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.mSap = false;

            if (modPlayer.mSap)
                Projectile.timeLeft = 2;
        }
    }
}