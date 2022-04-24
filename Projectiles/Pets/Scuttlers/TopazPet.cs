using Terraria;

namespace CalValEX.Projectiles.Pets.Scuttlers
{
    public class TopazPet : ScuttlerBase
    {
        public override string ScuttlerName => "Topaz";

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.mTop = false;

            if (modPlayer.mTop)
                Projectile.timeLeft = 2;
        }
    }
}