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

        public override Vector2 FlyingOffset => new Vector2(68f * -Main.player[projectile.owner].direction, -50f);

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: false);
            DisplayName.SetDefault("Polter-Chan");
            Main.projFrames[projectile.type] = 8;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            projectile.width = 82;
            projectile.height = 64;
            projectile.ignoreWater = true;
        }

        public override void Animation(int state)
        {
            Mod master = ModLoader.GetMod("MasterMode");
            Mod armasortof = ModLoader.GetMod("EfficientNohits");
            Mod infernum = ModLoader.GetMod("InfernumMode");
            Mod cplus = ModLoader.GetMod("CalValPlus");
            Mod calamityMod = ModLoader.GetMod("CalamityMod");

            //MAID mode
            if (!CalValEXConfig.Instance.Polterskin && ((master != null && (bool)calamityMod.Call("DifficultyActive", "death") && (infernum != null && (bool)infernum.Call("GetInfernumActive")) && (armasortof != null && (bool)armasortof.Call("GetModifier", "instantdeathalways"))) || cplus != null))
            {
                if (projectile.frameCounter++ > 8)
                {
                    projectile.frameCounter = 0;
                    projectile.frame++;
                    if (projectile.frame >= 8)
                        projectile.frame = 4;
                }
            }
            else
            {
                if (projectile.frameCounter++ % 8 == 7)
                {
                    projectile.frame++;
                }
                if (projectile.frame >= 4)
                {
                    projectile.frame = 0;
                }
            }
        }

        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Player player = Main.player[projectile.owner];
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
            string glowmaskTexture = (modPlayer.signutTrans || modPlayer.signutForce) && !CalValEXConfig.Instance.Polterskin ? "CalValEX/Projectiles/Pets/EvilPolterChan_Glow" : "CalValEX/Projectiles/Pets/PolterChan_Glow";
            SimpleGlowmask(spriteBatch, glowmaskTexture);
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();


            if (player.dead)
                modPlayer.mChan = false;

            if (modPlayer.mChan)
                projectile.timeLeft = 2;
        }
    }
}