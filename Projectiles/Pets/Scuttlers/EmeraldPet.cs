using Terraria;

namespace CalValEX.Projectiles.Pets.Scuttlers
{
    public class EmeraldPet : ScuttlerBase
    {
        public override string ScuttlerName => "Emerald";

        public override void SetDefaults()
        {
            base.SetDefaults();
            DrawOriginOffsetY = -2;
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.mEme = false;

            if (modPlayer.mEme)
                Projectile.timeLeft = 2;
        }
    }
}