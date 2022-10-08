using Microsoft.Xna.Framework;
using Terraria;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework.Graphics;
using CalamityMod.Items.Weapons.Summon;

namespace CalValEX.Projectiles.Pets {
    public class BrimberryPet : ModFlyingPet {
        public override float TeleportThreshold => 1440f;
        public override string Texture => "CalValEX/Projectiles/Pets/Brimberry";

        public override void SetStaticDefaults() {
            PetSetStaticDefaults(lightPet: false);
            DisplayName.SetDefault("Brimberry");
            Main.projFrames[Projectile.type] = 4;
        }

        public override void SetDefaults() {
            PetSetDefaults();
            Projectile.width = 20;
            Projectile.height = 22;
            Projectile.ignoreWater = true;
            Projectile.GetGlobalProjectile<CalValEXGlobalProjectile>().isCalValPet = true;
        }

        public override bool PreDraw(ref Color lightColor) {
            Texture2D tex;
            if (Main.LocalPlayer.HasItem(ItemType<DormantBrimseeker>()))
                tex = Request<Texture2D>("CalValEX/Projectiles/Pets/BrimberrySeek").Value;
            else
                tex = Request<Texture2D>("CalValEX/Projectiles/Pets/Brimberry").Value;
            Rectangle frame = tex.Frame(1, Main.projFrames[Projectile.type], 0, Projectile.frame);
            frame.Height -= 1;
            float originOffsetX = (tex.Width - Projectile.width) * 0.5f + Projectile.width * 0.5f + DrawOriginOffsetX;
            Main.EntitySpriteDraw(tex, Projectile.position - Main.screenPosition + new Vector2(originOffsetX + DrawOffsetX, Projectile.height / 2 + Projectile.gfxOffY),
                frame, Color.White, Projectile.rotation, new Vector2(originOffsetX, Projectile.height / 2 - DrawOriginOffsetY), Projectile.scale,
                Projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);

            return false;
        }

        public override void Animation(int state) => SimpleAnimation(speed: 8);

        public override void PetFunctionality(Player player) {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();

            if (player.dead)
                modPlayer.brimberry = false;

            if (modPlayer.brimberry)
                Projectile.timeLeft = 2;
        }
    }
}