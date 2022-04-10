using Terraria;

namespace CalValEX.Projectiles.Pets.Scuttlers
{
    public class AmberPet : ScuttlerBase
    {
        public override string ScuttlerName => "Amber";

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.mAmb = false;

            if (modPlayer.mAmb)
                projectile.timeLeft = 2;
        }
    }
}