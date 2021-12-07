using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace CalValEX.Projectiles.Pets.LightPets
{
    public class DarksunSpirit_Fish : FlyingPet
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Darksun Fish");
            Main.projFrames[projectile.type] = 4;
            Main.projPet[projectile.type] = true;
            ProjectileID.Sets.LightPet[projectile.type] = true;
        }

        public override void SafeSetDefaults()
        {
            projectile.width = 30;
            projectile.height = 20;
            projectile.ignoreWater = true;
            facingLeft = true;
            spinRotation = false;
            shouldFlip = true;
            usesAura = false;
            usesGlowmask = true;
            auraUsesGlowmask = false;
        }

        public override void SetUpFlyingPet()
        {
            distance[0] = 3400f; //teleport distance
            distance[1] = 640f; //faster speed distance
            speed = 12f;
            inertia = 60f;
            animationSpeed = 12; //how fast the animation should play
            spinRotationSpeedMult = 0.2f;
            offSetX = 48f * -Main.player[projectile.owner].direction; //this is needed so it's always behind the player.
            offSetY = -50f; //how much higher from the center the pet should float
        }
        public override void SetUpAuraAndGlowmask()
        {
            glowmaskTexture = CalValEX.month == 12 ? "ExtraTextures/ChristmasPets/DarksunSpiritFishGlow" : "Projectiles/Pets/DarksunSpirit_Fish_Glow";
        }

        public override void SetUpLight()
        {
            shouldLightUp = true;
            RGB = new Vector3(207, 117, 56);
            intensity = 1.25f;
            abyssLightLevel = 5;
        }

        private float extraScale;
        private float rotation;
        private bool yep = false;

        public override void SafeAI(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.darksunSpirits = false;
            if (modPlayer.darksunSpirits)
                projectile.timeLeft = 2;

            rotation += 0.1f;
            if (extraScale > 0.25f && !yep)
                yep = true;
            if (extraScale < -0.10f && yep)
                yep = false;

            if (!yep)
                extraScale += 0.01f;
            if (yep)
                extraScale -= 0.01f;
        }

        public override void SafePreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Player player = Main.player[projectile.owner];
            Texture2D texture = ModContent.GetTexture("CalValEX/Projectiles/Pets/LightPets/DarksunSpirit_Aura");
            Texture2D texture2 = ModContent.GetTexture("CalValEX/Projectiles/Pets/LightPets/DarksunSpirit_Aura_Glowmask");
            Rectangle sourceRectangle = new Rectangle(0, 0, texture.Width, texture.Height);
            Vector2 origin = new Vector2(texture.Width, texture.Height);
            Lighting.AddLight(player.position, new Vector3(1.01470588f, 0.573529411f, 0.274509804f));
            spriteBatch.Draw(texture, player.Center - Main.screenPosition, sourceRectangle, lightColor, rotation, origin / 2f, 1f + extraScale, SpriteEffects.None, 0);
            spriteBatch.Draw(texture2, player.Center - Main.screenPosition, sourceRectangle, Color.White, rotation, origin / 2f, 1f + extraScale, SpriteEffects.None, 0);
        }
    }

    public class DarksunSpiritSkull_1 : FlyingPet
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Darksun Skull");
            Main.projFrames[projectile.type] = 4;
            Main.projPet[projectile.type] = true;
            ProjectileID.Sets.LightPet[projectile.type] = true;
        }

        public override void SafeSetDefaults()
        {
            projectile.width = 26;
            projectile.height = 20;
            projectile.ignoreWater = true;
            facingLeft = true;
            spinRotation = false;
            shouldFlip = true;
            usesAura = false;
            usesGlowmask = true;
            auraUsesGlowmask = false;
        }

        public override void SetUpFlyingPet()
        {
            distance[0] = 3400f; //teleport distance
            distance[1] = 640f; //faster speed distance
            speed = 20f;
            inertia = 80f;
            animationSpeed = 12; //how fast the animation should play
            spinRotationSpeedMult = 0.2f;
            offSetX = 16f * Main.player[projectile.owner].direction; //this is needed so it's always behind the player.
            offSetY = 0f; //how much higher from the center the pet should float
        }

        public override void SetUpAuraAndGlowmask()
        {
            glowmaskTexture = CalValEX.month == 12 ? "ExtraTextures/ChristmasPets/DarksunSpiritSkull1Glow" : "Projectiles/Pets/DarksunSpiritSkull_1_Glow";
        }

        public override void SetUpLight()
        {
            shouldLightUp = true;
            RGB = new Vector3(207, 117, 56);
            intensity = 1.25f;
            abyssLightLevel = 5;
        }

        public override void SafeAI(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.darksunSpirits = false;
            if (modPlayer.darksunSpirits)
                projectile.timeLeft = 2;
        }
    }

    public class DarksunSpiritSkull_2 : FlyingPet
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Darksun Small Skull");
            Main.projFrames[projectile.type] = 4;
            Main.projPet[projectile.type] = true;
            ProjectileID.Sets.LightPet[projectile.type] = true;
        }

        public override void SafeSetDefaults()
        {
            projectile.width = 14;
            projectile.height = 10;
            projectile.ignoreWater = true;
            facingLeft = true;
            spinRotation = false;
            shouldFlip = true;
            usesAura = false;
            usesGlowmask = true;
            auraUsesGlowmask = false;
        }

        public override void SetUpFlyingPet()
        {
            distance[0] = 3400f; //teleport distance
            distance[1] = 640f; //faster speed distance
            speed = 18f;
            inertia = 70f;
            animationSpeed = 12; //how fast the animation should play
            spinRotationSpeedMult = 0.2f;
            offSetX = 16f * -Main.player[projectile.owner].direction; //this is needed so it's always behind the player.
            offSetY = 0f; //how much higher from the center the pet should float
        }

        public override void SetUpAuraAndGlowmask()
        {
		glowmaskTexture = CalValEX.month == 12 ? "ExtraTextures/ChristmasPets/DarksunSpiritSkull2Glow" : "Projectiles/Pets/DarksunSpiritSkull_2_Glow";
        }

        public override void SetUpLight()
        {
            shouldLightUp = true;
            RGB = new Vector3(207, 117, 56);
            intensity = 1.25f;
            abyssLightLevel = 5;
        }

        public override void SafeAI(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.darksunSpirits = false;
            if (modPlayer.darksunSpirits)
                projectile.timeLeft = 2;
        }
    }
}