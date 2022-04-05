using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace CalValEX.Projectiles.Pets.LightPets.SupJewel
{
   /*
    public class NWings : ModProjectile
    {
       
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nightmare Fuel Wings");
            Main.projFrames[Projectile.type] = 4;
            Main.projPet[Projectile.type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.damage = 0;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.hostile = false;
            Projectile.width = 154;
            Projectile.height = 184;
            Projectile.netImportant = true;
            Projectile.scale = 1f;
            Projectile.alpha = 20;
        }

        public override bool? CanCutTiles()
        {
            return false;
        }

	    public override void PostDraw(Color lightColor)
        {
            Texture2D texture = ModContent.Request<Texture2D>("CalValEX/Projectiles/Pets/LightPets/SupJewel/NWings_Glow");
            int frameHeight = texture.Height / Main.projFrames[Projectile.type];
            int hei = frameHeight * Projectile.frame;
            Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition, new Microsoft.Xna.Framework.Rectangle?(new Rectangle(0, hei, texture.Width, frameHeight)), Color.Transparent, Projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), Projectile.scale, SpriteEffects.None, 0f);
        }

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];

            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.SupJ = false;
            if (modPlayer.SupJ)
                Projectile.timeLeft = 2;

            Vector2 idlePosition = player.Center;
            idlePosition.Y -= Projectile.height / 2;
            idlePosition.X -= Projectile.width / 2;

            Projectile.position = idlePosition;
            Projectile.spriteDirection = 1;

            Projectile.frameCounter++;
            if (Projectile.frameCounter > 22)
            {
                Projectile.frame++;
                Projectile.frameCounter = 0;
            }
            if (Projectile.frame == 3)
            {
                Projectile.frame = 0;
            }

            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            if (calamityMod != null)
            {
                calamityMod.Call("AddAbyssLightStrength", Projectile.owner, 2);
            }
        }
       
    }
   */

    public class Bishop : FlyingPet
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dark Sun Elemental");
            Main.projFrames[Projectile.type] = 4;
            Main.projPet[Projectile.type] = true;
            ProjectileID.Sets.LightPet[Projectile.type] = true;
        }

        public override void SafeSetDefaults()
        {
            Projectile.width = 100;
            Projectile.height = 174;
            Projectile.ignoreWater = true;
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
            glowmaskTexture = "CalValEX/Projectiles/Pets/LightPets/SupJewel/Bishop_Glow";
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
                Projectile.timeLeft = 2;
        }
    }

    public class SpookShark : FlyingPet
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Phantoshark");
            Main.projFrames[Projectile.type] = 8;
            Main.projPet[Projectile.type] = true;
            ProjectileID.Sets.LightPet[Projectile.type] = true;
        }

        public override void SafeSetDefaults()
        {
            Projectile.width = 76;
            Projectile.height = 36;
            Projectile.ignoreWater = true;
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
            offSetX = 100f * -Main.player[Projectile.owner].direction; //this is needed so it's always behind the player.
            offSetY = -60f; //how much higher from the center the pet should float
        }
        public override void SetUpAuraAndGlowmask()
        {
            glowmaskTexture = "CalValEX/Projectiles/Pets/LightPets/SupJewel/SpookShark_Glow";
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
                Projectile.timeLeft = 2;

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
        public override void SafePreDraw(Color lightColor)
        {
            Player player = Main.player[Projectile.owner];
            Texture2D texture = ModContent.Request<Texture2D>("CalValEX/Projectiles/Pets/LightPets/SupJewel/EndoAura");
            Texture2D texture2 = ModContent.Request<Texture2D>("CalValEX/Projectiles/Pets/LightPets/SupJewel/EndoAura_Glow");
            Rectangle sourceRectangle = new Rectangle(0, 0, texture.Width, texture.Height);
            Vector2 origin = new Vector2(texture.Width, texture.Height);
            Lighting.AddLight(player.position, new Vector3(1.01470588f, 0.573529411f, 0.274509804f));
            Main.EntitySpriteDraw(texture, player.Center - Main.screenPosition, sourceRectangle, lightColor, rotation, origin / 2f, 1f + extraScale, SpriteEffects.None, 0);
            Main.EntitySpriteDraw(texture2, player.Center - Main.screenPosition, sourceRectangle, Color.White, rotation, origin / 2f, 1f + extraScale, SpriteEffects.None, 0);
        }
        */
    }

    public class SpookSmall : FlyingPet
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Phantofish");
            Main.projFrames[Projectile.type] = 1;
            Main.projPet[Projectile.type] = true;
            ProjectileID.Sets.LightPet[Projectile.type] = true;
        }

        public override void SafeSetDefaults()
        {
            Projectile.width = 40;
            Projectile.height = 22;
            Projectile.ignoreWater = true;
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
            offSetX = 80f * -Main.player[Projectile.owner].direction; //this is needed so it's always behind the player.
            offSetY = -20f; //how much higher from the center the pet should float
        }

        public override void SetUpAuraAndGlowmask()
        {
            glowmaskTexture = "CalValEX/Projectiles/Pets/LightPets/SupJewel/SpookSmall_Glow";
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
                Projectile.timeLeft = 2;
        }
    }

    public class EndoRune : FlyingPet
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Endo Runes");
            Main.projFrames[Projectile.type] = 1;
            Main.projPet[Projectile.type] = true;
            ProjectileID.Sets.LightPet[Projectile.type] = true;
        }

        public override void SafeSetDefaults()
        {
            Projectile.width = 200;
            Projectile.height = 200;
            Projectile.ignoreWater = true;
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
            glowmaskTexture = "CalValEX/Projectiles/Pets/LightPets/SupJewel/EndoRune_Glow";
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
                Projectile.timeLeft = 2;
        }
    }
}