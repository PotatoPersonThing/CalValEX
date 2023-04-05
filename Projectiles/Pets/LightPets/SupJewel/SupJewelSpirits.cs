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

	    public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D texture = ModContent.GetTexture("CalValEX/Projectiles/Pets/LightPets/SupJewel/NWings_Glow");
            int frameHeight = texture.Height / Main.projFrames[Projectile.type];
            int hei = frameHeight * Projectile.frame;
            spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition, new Microsoft.Xna.Framework.Rectangle?(new Rectangle(0, hei, texture.Width, frameHeight)), Color.Transparent, Projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), Projectile.scale, SpriteEffects.None, 0f);
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
            // DisplayName.SetDefault("Dark Sun Elemental");
            Main.projFrames[Projectile.type] = 4;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            Projectile.width = 100;
            Projectile.height = 174;
            Projectile.ignoreWater = true;
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.SupJ = false;

            if (modPlayer.SupJ)
                Projectile.timeLeft = 2;
        }

        public override void CustomBehaviour(Player player, ref int state, float flyingSpeed, float flyingInertia)
        {
            AddLight(new Color(207, 117, 56), 2f, 5);
        }

        public override void PostDraw(Color lightColor)
        {
            SimpleGlowmask(Main.spriteBatch);
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

        public override Vector2 FlyingOffset => new Vector2(100f * - Main.player[Projectile.owner].direction, -60f);

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: true);
            // DisplayName.SetDefault("Phantoshark");
            Main.projFrames[Projectile.type] = 8;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            Projectile.width = 76;
            Projectile.height = 36;
            Projectile.ignoreWater = true;
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.SupJ = false;

            if (modPlayer.SupJ)
                Projectile.timeLeft = 2;
        }

        public override void PostDraw(Color lightColor)
        {
            SimpleGlowmask(Main.spriteBatch);
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

        public override bool PreDraw(ref Color lightColor)
        {
            /*
            Player player = Main.player[Projectile.owner];
            Texture2D texture = ModContent.GetTexture("CalValEX/Projectiles/Pets/LightPets/SupJewel/EndoAura");
            Texture2D texture2 = ModContent.GetTexture("CalValEX/Projectiles/Pets/LightPets/SupJewel/EndoAura_Glow");
            Rectangle sourceRectangle = new Rectangle(0, 0, texture.Width, texture.Height);
            Vector2 origin = new Vector2(texture.Width, texture.Height);
            Lighting.AddLight(player.position, new Vector3(1.01470588f, 0.573529411f, 0.274509804f));
            spriteBatch.Draw(texture, player.Center - Main.screenPosition, sourceRectangle, lightColor, rotation, origin / 2f, 1f + extraScale, SpriteEffects.None, 0);
            spriteBatch.Draw(texture2, player.Center - Main.screenPosition, sourceRectangle, Color.White, rotation, origin / 2f, 1f + extraScale, SpriteEffects.None, 0);
            */
            return base.PreDraw(ref lightColor);
        }
    }

    public class SpookSmall : ModFlyingPet
    {
        public override float TeleportThreshold => 3400f;

        public override Vector2 FlyingOffset => new Vector2(80f * -Main.player[Projectile.owner].direction, -20f);

        public override float FlyingSpeed => 15f;

        public override float SpeedupThreshold => 640f;

        public override float FlyingInertia => 80f;

        public override void SetStaticDefaults()
        {
            PetSetStaticDefaults(lightPet: true);
            // DisplayName.SetDefault("Phantofish");
            Main.projFrames[Projectile.type] = 1;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            Projectile.width = 40;
            Projectile.height = 22;
            Projectile.ignoreWater = true;
        }

        public override void PostDraw(Color lightColor)
        {
            SimpleGlowmask(Main.spriteBatch);
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.SupJ = false;

            if (modPlayer.SupJ)
                Projectile.timeLeft = 2;
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
            // DisplayName.SetDefault("Endo Runes");
            Main.projFrames[Projectile.type] = 1;
        }

        public override void SetDefaults()
        {
            PetSetDefaults();
            Projectile.width = 200;
            Projectile.height = 200;
            Projectile.ignoreWater = true;
        }

        public override void PostDraw(Color lightColor)
        {
            SimpleGlowmask(Main.spriteBatch);
        }

        public override void PetFunctionality(Player player)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.SupJ = false;

            if (modPlayer.SupJ)
                Projectile.timeLeft = 2;
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