using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.Pets
{
    public class PolterChan : ModFlyingPet
    {
        public override bool FacesLeft => false;

        public override float TeleportThreshold => 1440f;

        public override Vector2 FlyingOffset => new Vector2(68f * -Main.player[Projectile.owner].direction, -50f);

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            DisplayName.SetDefault("Polter-Chan");
            Main.projFrames[Projectile.type] = 8;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            Projectile.width = 82;
            Projectile.height = 64;
            Projectile.ignoreWater = true;
        }

        public override void Animation(int state)
        {
            /*Mod master = ModLoader.GetMod("MasterMode");
            Mod armasortof = ModLoader.GetMod("EfficientNohits");
            Mod infernum = ModLoader.GetMod("InfernumMode");
            Mod cplus = ModLoader.GetMod("CalValPlus");
            Mod calamityMod = ModLoader.GetMod("CalamityMod");

            //MAID mode
            if (!CalValEXConfig.Instance.Polterskin && ((master != null && (bool)calamityMod.Call("DifficultyActive", "death") && (infernum != null && (bool)infernum.Call("GetInfernumActive")) && (armasortof != null && (bool)armasortof.Call("GetModifier", "instantdeathalways"))) || cplus != null))
            {
                if (Projectile.frameCounter++ > 8)
                {
                    Projectile.frameCounter = 0;
                    Projectile.frame++;
                    if (Projectile.frame >= 8)
                        Projectile.frame = 4;
                }
            }
            else
            {*/
                if (Projectile.frameCounter++ % 8 == 7)
                {
                    Projectile.frame++;
                }
                if (Projectile.frame >= 4)
                {
                    Projectile.frame = 0;
                }
            //}
        }

        public override void PostDraw(Color lightColor)
        {
            Player player = Main.player[Projectile.owner];
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
            string glowmaskTexture = (modPlayer.signutTrans || modPlayer.signutForce) && !CalValEXConfig.Instance.Polterskin ? "CalValEX/Projectiles/Pets/EvilPolterChan_Glow" : "CalValEX/Projectiles/Pets/PolterChan_Glow";
            //SimpleGlowmask(spriteBatch, glowmaskTexture);
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();


            if (player.dead)
                modPlayer.mChan = false;

            if (modPlayer.mChan)
                Projectile.timeLeft = 2;
        }
    }
}