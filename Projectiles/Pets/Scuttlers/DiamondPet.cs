using Terraria;

namespace CalValEX.Projectiles.Pets.Scuttlers
{
    public class DiamondPet : ScuttlerBase
    {
        public override string ScuttlerName => "Diamond";

        public override void SetDefaults()
        {
            base.SetDefaults();
            DrawOriginOffsetY = 0;
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.mDia = false;

            if (modPlayer.mDia)
                Projectile.timeLeft = 2;
        }
    }
}