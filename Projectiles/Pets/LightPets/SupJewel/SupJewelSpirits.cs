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

    public class Bishop : ModFlyingPet
    {
        public override bool ShouldFlip => false;

        public override float TeleportThreshold => 1600f;

        public override Vector2 FlyingOffset => new Vector2(-120f, -70f);

        public override float FlyingSpeed => 10f;

        public override float FlyingInertia => 80f;

        public override float SpeedupThreshold => 640f;

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: true);
            DisplayName.SetDefault("Dark Sun Elemental");
            Main.projFrames[projectile.type] = 4;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            projectile.width = 100;
            projectile.height = 174;
            projectile.ignoreWater = true;
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.SupJ = false;

            if (modPlayer.SupJ)
                projectile.timeLeft = 2;
        }

        public override void CustomBehaviour(Player player, ref int state, float flyingSpeed, float flyingInertia)
        {
            AddLight(new Color(207, 117, 56), 2f, 5);
        }

        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            SimpleGlowmask(spriteBatch);
        }

        public override void Animation(int state)
        {
            SimpleAnimation(speed: 6);
        }
    }

    public class SpookShark : ModFlyingPet
    {
        public override float TeleportThreshold => 3400f;

        public override float SpeedupThreshold => 640f;

        public override Vector2 FlyingOffset => new Vector2(100f * - Main.player[projectile.owner].direction, -60f);

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: true);
            DisplayName.SetDefault("Phantoshark");
            Main.projFrames[projectile.type] = 8;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            projectile.width = 76;
            projectile.height = 36;
            projectile.ignoreWater = true;
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.SupJ = false;

            if (modPlayer.SupJ)
                projectile.timeLeft = 2;
        }

        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            SimpleGlowmask(spriteBatch);
        }

        public override void Animation(int state)
        {
            SimpleAnimation(speed: 6);
        }

        //private float extraScale;
        //private float rotation;
        //private bool yep = false;

        public override void CustomBehaviour(Player player, ref int state, float flyingSpeed, float flyingInertia)
        {
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

            AddLight(new Color(200, 111, 145), 1.25f, 5);
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            /*
            Player player = Main.player[projectile.owner];
            Texture2D texture = ModContent.GetTexture("CalValEX/Projectiles/Pets/LightPets/SupJewel/EndoAura");
            Texture2D texture2 = ModContent.GetTexture("CalValEX/Projectiles/Pets/LightPets/SupJewel/EndoAura_Glow");
            Rectangle sourceRectangle = new Rectangle(0, 0, texture.Width, texture.Height);
            Vector2 origin = new Vector2(texture.Width, texture.Height);
            Lighting.AddLight(player.position, new Vector3(1.01470588f, 0.573529411f, 0.274509804f));
            spriteBatch.Draw(texture, player.Center - Main.screenPosition, sourceRectangle, lightColor, rotation, origin / 2f, 1f + extraScale, SpriteEffects.None, 0);
            spriteBatch.Draw(texture2, player.Center - Main.screenPosition, sourceRectangle, Color.White, rotation, origin / 2f, 1f + extraScale, SpriteEffects.None, 0);
            */
            return base.PreDraw(spriteBatch, lightColor);
        }
    }

    public class SpookSmall : ModFlyingPet
    {
        public override float TeleportThreshold => 3400f;

        public override Vector2 FlyingOffset => new Vector2(80f * -Main.player[projectile.owner].direction, -20f);

        public override float FlyingSpeed => 15f;

        public override float SpeedupThreshold => 640f;

        public override float FlyingInertia => 80f;

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: true);
            DisplayName.SetDefault("Phantofish");
            Main.projFrames[projectile.type] = 1;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            projectile.width = 40;
            projectile.height = 22;
            projectile.ignoreWater = true;
        }

        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            SimpleGlowmask(spriteBatch);
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.SupJ = false;

            if (modPlayer.SupJ)
                projectile.timeLeft = 2;
        }

        public override void Animation(int state)
        {
        }

        public override void CustomBehaviour(Player player, ref int state, float flyingSpeed, float flyingInertia)
        {
            AddLight(new Color(200, 111, 145), 1.25f, 5);
        }
    }

    public class EndoRune : ModFlyingPet
    {
        public override float TeleportThreshold => 3400f;

        public override bool ShouldFlip => false;

        public override Vector2 FlyingOffset => Vector2.One;

        public override float FlyingSpeed => 20f;

        public override float FlyingInertia => 20f;

        public override float SpeedupThreshold => 640f;

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: true);
            DisplayName.SetDefault("Endo Runes");
            Main.projFrames[projectile.type] = 1;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            projectile.width = 200;
            projectile.height = 200;
            projectile.ignoreWater = true;
        }

        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            SimpleGlowmask(spriteBatch);
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.SupJ = false;

            if (modPlayer.SupJ)
                projectile.timeLeft = 2;
        }

        public override void Animation(int state)
        {
        }

        public override void CustomBehaviour(Player player, ref int state, float flyingSpeed, float flyingInertia)
        {
            AddLight(new Color(171, 255, 231), 1.25f, 5);
        }
    }
}