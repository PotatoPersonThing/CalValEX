using Terraria;

namespace CalValEX.Projectiles.Pets.Scuttlers
{
    public class CrystalPet : ScuttlerBase
    {
        public override string ScuttlerName => "Crystal";

        public override void SetDefaults()
        {
            base.SetDefaults();
            drawOriginOffsetY = 0;
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.mCry = false;

            if (modPlayer.mCry)
                projectile.timeLeft = 2;
        }
    }
}