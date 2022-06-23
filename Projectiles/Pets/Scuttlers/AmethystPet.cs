using Terraria;

namespace CalValEX.Projectiles.Pets.Scuttlers
{
    public class AmethystPet : ScuttlerBase
    {
        public override string ScuttlerName => "Amethyst";

        public override void SetDefaults()
        {
            base.SetDefaults();
            DrawOriginOffsetY = 0;
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.mAme = false;

            if (modPlayer.mAme)
                Projectile.timeLeft = 2;
        }
    }
}