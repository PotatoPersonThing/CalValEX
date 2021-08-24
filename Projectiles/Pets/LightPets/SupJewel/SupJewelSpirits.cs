using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace CalValEX.Projectiles.Pets.LightPets.SupJewel
{
   /*
    public class NWings : ModProjectile
    {
       
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nightmare Fuel Wings");
            Main.projFrames[projectile.type] = 4;
            Main.projPet[projectile.type] = true;
        }

        public override void SetDefaults()
        {
            projectile.damage = 0;
            projectile.friendly = true;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.hostile = false;
            projectile.width = 154;
            projectile.height = 184;
            projectile.netImportant = true;
            projectile.scale = 1f;
            projectile.alpha = 20;
        }

        public override bool? CanCutTiles()
        {
            return false;
        }

	    public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D texture = ModContent.GetTexture("CalValEX/Projectiles/Pets/LightPets/SupJewel/NWings_Glow");
            int frameHeight = texture.Height / Main.projFrames[projectile.type];
            int hei = frameHeight * projectile.frame;
            spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, new Microsoft.Xna.Framework.Rectangle?(new Rectangle(0, hei, texture.Width, frameHeight)), Color.Transparent, projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), projectile.scale, SpriteEffects.None, 0f);
        }

        public override void AI()
        {
            Player player = Main.player[projectile.owner];

            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.SupJ = false;
            if (modPlayer.SupJ)
                projectile.timeLeft = 2;

            Vector2 idlePosition = player.Center;
            idlePosition.Y -= projectile.height / 2;
            idlePosition.X -= projectile.width / 2;

            projectile.position = idlePosition;
            projectile.spriteDirection = 1;

            projectile.frameCounter++;
            if (projectile.frameCounter > 22)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame == 3)
            {
                projectile.frame = 0;
            }

            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            if (calamityMod != null)
            {
                calamityMod.Call("AddAbyssLightStrength", projectile.owner, 2);
            }
        }
       
    }
   */

    public class Bishop : FlyingPet
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dark Sun Elemental");
            Main.projFrames[projectile.type] = 4;
            Main.projPet[projectile.type] = true;
        }

        public override void SafeSetDefaults()
        {
            projectile.width = 100;
            projectile.height = 174;
            projectile.ignoreWater = true;
            facingLeft = true;
            spinRotation = false;
            shouldFlip = false;
            usesAura = false;
            usesGlowmask = true;
            auraUsesGlowmask = false;
        }

        public override void SetUpFlyingPet()
        {
            distance[0] = 1600f; //teleport distance
            distance[1] = 640f; //faster speed distance
            speed = 10;
            inertia = 80f;
            animationSpeed = 6; //how fast the animation should play
            spinRotationSpeedMult = 0f;
            offSetX = -120f;
            offSetY = -70f; //how much higher from the center the pet should float
        }

        public override void SetUpAuraAndGlowmask()
        {
            glowmaskTexture = "Projectiles/Pets/LightPets/SupJewel/Bishop_Glow";
        }

        public override void SetUpLight()
        {
            shouldLightUp = true;
            RGB = new Vector3(207, 117, 56);
            intensity = 2f;
            abyssLightLevel = 5;
        }

        public override void SafeAI(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.SupJ = false;
            if (modPlayer.SupJ)
                projectile.timeLeft = 2;
        }
    }

    public class SpookShark : FlyingPet
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Phantoshark");
            Main.projFrames[projectile.type] = 8;
            Main.projPet[projectile.type] = true;
        }

        public override void SafeSetDefaults()
        {
            projectile.width = 76;
            projectile.height = 36;
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
            offSetX = 100f * -Main.player[projectile.owner].direction; //this is needed so it's always behind the player.
            offSetY = -60f; //how much higher from the center the pet should float
        }
        public override void SetUpAuraAndGlowmask()
        {
            glowmaskTexture = "Projectiles/Pets/LightPets/SupJewel/SpookShark_Glow";
        }

        public override void SetUpLight()
        {
            shouldLightUp = true;
            RGB = new Vector3(200, 111, 145);
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
                modPlayer.SupJ = false;
            if (modPlayer.SupJ)
                projectile.timeLeft = 2;

            /*
            rotation += 0.22f;
            if (extraScale > 0f && !yep)
                yep = true;
            if (extraScale < -0.5f && yep)
                yep = false;

            if (!yep)
                extraScale += 0.005f;
            if (yep)
                extraScale -= 0.005f;
            */
        }

        /*
        public override void SafePreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Player player = Main.player[projectile.owner];
            Texture2D texture = ModContent.GetTexture("CalValEX/Projectiles/Pets/LightPets/SupJewel/EndoAura");
            Texture2D texture2 = ModContent.GetTexture("CalValEX/Projectiles/Pets/LightPets/SupJewel/EndoAura_Glow");
            Rectangle sourceRectangle = new Rectangle(0, 0, texture.Width, texture.Height);
            Vector2 origin = new Vector2(texture.Width, texture.Height);
            Lighting.AddLight(player.position, new Vector3(1.01470588f, 0.573529411f, 0.274509804f));
            spriteBatch.Draw(texture, player.Center - Main.screenPosition, sourceRectangle, lightColor, rotation, origin / 2f, 1f + extraScale, SpriteEffects.None, 0);
            spriteBatch.Draw(texture2, player.Center - Main.screenPosition, sourceRectangle, Color.White, rotation, origin / 2f, 1f + extraScale, SpriteEffects.None, 0);
        }
        */
    }

    public class SpookSmall : FlyingPet
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Phantofish");
            Main.projFrames[projectile.type] = 1;
            Main.projPet[projectile.type] = true;
        }

        public override void SafeSetDefaults()
        {
            projectile.width = 40;
            projectile.height = 22;
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
            speed = 15f;
            inertia = 80f;
            animationSpeed = 12; //how fast the animation should play
            spinRotationSpeedMult = 0.2f;
            offSetX = 80f * -Main.player[projectile.owner].direction; //this is needed so it's always behind the player.
            offSetY = -20f; //how much higher from the center the pet should float
        }

        public override void SetUpAuraAndGlowmask()
        {
            glowmaskTexture = "Projectiles/Pets/LightPets/SupJewel/SpookSmall_Glow";
        }

        public override void SetUpLight()
        {
            shouldLightUp = true;
            RGB = new Vector3(200, 111, 145);
            intensity = 1.25f;
            abyssLightLevel = 5;
        }

        public override void SafeAI(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.SupJ = false;
            if (modPlayer.SupJ)
                projectile.timeLeft = 2;
        }
    }

    public class EndoRune : FlyingPet
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Endo Runes");
            Main.projFrames[projectile.type] = 1;
            Main.projPet[projectile.type] = true;
        }

        public override void SafeSetDefaults()
        {
            projectile.width = 200;
            projectile.height = 200;
            projectile.ignoreWater = true;
            facingLeft = true;
            spinRotation = false;
            shouldFlip = false;
            usesAura = false;
            usesGlowmask = true;
            auraUsesGlowmask = false;
        }

        public override void SetUpFlyingPet()
        {
            distance[0] = 3400f; //teleport distance
            distance[1] = 640f; //faster speed distance
            speed = 20f;
            inertia = 20f;
            animationSpeed = 12; //how fast the animation should play
            spinRotationSpeedMult = 0f;
            offSetX = 1f; //this is needed so it's always behind the player.
            offSetY = 1f; //how much higher from the center the pet should float
        }

        public override void SetUpAuraAndGlowmask()
        {
            glowmaskTexture = "Projectiles/Pets/LightPets/SupJewel/EndoRune_Glow";
        }

        public override void SetUpLight()
        {
            shouldLightUp = true;
            RGB = new Vector3(171, 255, 231);
            intensity = 1.25f;
            abyssLightLevel = 5;
        }

        public override void SafeAI(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.SupJ = false;
            if (modPlayer.SupJ)
                projectile.timeLeft = 2;
        }
    }
}