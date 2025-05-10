using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.Pets.LightPets
{
    public class DarksunSpirit_Fish : ModFlyingPet
    {
        public override float TeleportThreshold => 3400f;

        public override float SpeedupThreshold => 640;

        private float extraScale;
        private float rotation;
        private bool growing;

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: true);
            // DisplayName.SetDefault("Darksun Fish");
            Main.projFrames[Projectile.type] = 4;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            Projectile.width = 30;
            Projectile.height = 20;
            Projectile.ignoreWater = true;
            extraScale = 0.10f;
            rotation = 0f;
            growing = false;
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.darksunSpirits = false;

            if (modPlayer.darksunSpirits)
                Projectile.timeLeft = 2;
        }

        public override void CustomBehaviour(Player player, ref int state, float flyingSpeed, float flyingInertia)
        {
            AddLight(new Color(207, 117, 56), 1.25f, 5);

            AddLight(player.position, new Color(207, 117, 56), 1.25f, 0);

            rotation = MathHelper.WrapAngle(rotation + (MathHelper.TwoPi / (60 * 2)));

            if (extraScale > 0.25f && growing)
                growing = false;
            if (extraScale < -0.10f && !growing)
                growing = true;

            if (growing)
                extraScale += 0.01f;
            if (!growing)
                extraScale -= 0.01f;
        }

        public override void Animation(int state)
        {
            SimpleAnimation(speed: 12);
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Player player = Main.player[Projectile.owner];

            Texture2D texture = ModContent.Request<Texture2D>("CalValEX/Projectiles/Pets/LightPets/DarksunSpirit_Aura").Value;
            Texture2D texture2 = ModContent.Request<Texture2D>("CalValEX/Projectiles/Pets/LightPets/DarksunSpirit_Aura_Glowmask").Value;

            Rectangle sourceRectangle = new(0, 0, texture.Width, texture.Height);

            Vector2 origin = new(texture.Width, texture.Height);

            Main.EntitySpriteDraw(texture, player.Center - Main.screenPosition, sourceRectangle, lightColor, rotation, origin / 2f, 1f + extraScale, SpriteEffects.None, 0);
            Main.EntitySpriteDraw(texture2, player.Center - Main.screenPosition, sourceRectangle, Color.White, rotation, origin / 2f, 1f + extraScale, SpriteEffects.None, 0);

            return base.PreDraw(ref lightColor);
        }

        public override void PostDraw(Color lightColor)
        {
            string glowmaskTexture = CalValEX.month == 12 ? "CalValEX/ExtraTextures/ChristmasPets/DarksunSpiritFishGlow" : "CalValEX/Projectiles/Pets/LightPets/DarksunSpirit_Fish_Glow";

            SimpleGlowmask(Main.spriteBatch, glowmaskTexture);
        }
    }

    public class DarksunSpiritSkull_1 : ModFlyingPet
    {
        public override float TeleportThreshold => 3400f;

        public override float FlyingSpeed => 20f;

        public override float SpeedupThreshold => 640;

        public override Vector2 FlyingOffset => new(16f * Main.player[Projectile.owner].direction, 0f);

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: true);
            // DisplayName.SetDefault("Darksun Skull");
            Main.projFrames[Projectile.type] = 4;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            Projectile.width = 26;
            Projectile.height = 20;
            Projectile.ignoreWater = true;
        }

        public override void Animation(int state)
        {
            SimpleAnimation(speed: 12);
        }

        public override void PostDraw(Color lightColor)
        {
            string glowmaskTexture = CalValEX.month == 12 ? "CalValEX/ExtraTextures/ChristmasPets/DarksunSpiritSkull1Glow" : "CalValEX/Projectiles/Pets/LightPets/DarksunSpiritSkull_1_Glow";

            SimpleGlowmask(Main.spriteBatch, glowmaskTexture);
        }

        public override void CustomBehaviour(Player player, ref int state, float flyingSpeed, float flyingInertia)
        {
            AddLight(new Color(207, 117, 56), 1.25f, 5);
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.darksunSpirits = false;
            if (modPlayer.darksunSpirits)
                Projectile.timeLeft = 2;
        }
    }

    public class DarksunSpiritSkull_2 : ModFlyingPet
    {
        public override float TeleportThreshold => 3400f;

        public override float FlyingSpeed => 18f;

        public override float SpeedupThreshold => 640;

        public override Vector2 FlyingOffset => new(16f * -Main.player[Projectile.owner].direction, 0f);

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: true);
            // DisplayName.SetDefault("Darksun Small Skull");
            Main.projFrames[Projectile.type] = 4;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            Projectile.width = 14;
            Projectile.height = 10;
            Projectile.ignoreWater = true;
        }

        public override void Animation(int state)
        {
            SimpleAnimation(speed: 12);
        }

        public override void PostDraw(Color lightColor)
        {
            string glowmaskTexture = CalValEX.month == 12 ? "CalValEX/ExtraTextures/ChristmasPets/DarksunSpiritSkull2Glow" : "CalValEX/Projectiles/Pets/LightPets/DarksunSpiritSkull_2_Glow";

            SimpleGlowmask(Main.spriteBatch, glowmaskTexture);
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.darksunSpirits = false;

            if (modPlayer.darksunSpirits)
                Projectile.timeLeft = 2;
        }

        public override void CustomBehaviour(Player player, ref int state, float flyingSpeed, float flyingInertia)
        {
            AddLight(new Color(207, 117, 56), 1.25f, 5);
        }
    }
}