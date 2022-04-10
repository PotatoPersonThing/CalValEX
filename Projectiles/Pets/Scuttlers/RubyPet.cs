using Terraria;

namespace CalValEX.Projectiles.Pets.Scuttlers
{
    public class RubyPet : ScuttlerBase
    {
        public override string ScuttlerName => "Ruby";

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.mRub = false;

            if (modPlayer.mRub)
                projectile.timeLeft = 2;
        }
    }
}