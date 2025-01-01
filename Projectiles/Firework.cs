using CalamityMod.Particles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Projectiles
{
    public class Firework : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Type] = 4;
        }
        public override void SetDefaults()
        {
            Projectile.netImportant = true;
            Projectile.width = 20;
            Projectile.height = 20;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 30;
        }

        public override void AI()
        {
            Projectile.frameCounter++;
            if (Projectile.frameCounter > 4)
            {
                Projectile.frame++;
                Projectile.frameCounter = 0;
            }
            if (Projectile.frame > 3)
                Projectile.frame = 0;
        }

        [JITWhenModsEnabled("CalamityMod")]
        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.DD2_ExplosiveTrapExplode, Projectile.Center);
            SoundEngine.PlaySound(SoundID.Item14, Projectile.Center);
            if (!Main.dedServ)
            {
                int itemID = 1;
                while (Main.itemAnimations[itemID] != null || itemID == 1)
                {
                    itemID = Main.rand.Next(0, ContentSamples.ItemsByType.Count - 1);
                }
                Main.instance.LoadItem(itemID);
                Texture2D texy = TextureAssets.Item[itemID].Value;

                Color[,] colors = GetColorsFromTexture(texy);

                float divisor = (float)(texy.Width > texy.Height ? texy.Width : texy.Height);
                float spacing = 5f / divisor;
                int increment = (int)MathHelper.Lerp(1, 30, divisor / 500f);
                for (int i = 0; i < texy.Width; i += increment)
                {
                    if (i >= texy.Width)
                        continue;
                    for (int j = 0; j < texy.Height; j += increment)
                    {
                        if (colors[i, j].A == 0)
                            continue;
                        if (j >= texy.Height)
                            continue;
                        Vector2 spawnPos = Projectile.position + (new Vector2(i, j) * 16 - texy.Size() * 8) * Main.rand.NextFloat(spacing * 0.95f, spacing * 1.05f);
                        SpawnParticles(spawnPos, colors[i, j]);
                    }
                }
            }
        }

        [JITWhenModsEnabled("CalamityMod")]
        public void SpawnParticles(Vector2 spawnPos, Color color)
        {
            GeneralParticleHandler.SpawnParticle(new CalamityMod.Particles.GlowOrbParticle(spawnPos, (spawnPos - Projectile.position) * 0.2f, false, 60, 2.15f, color * 4, needed: true));
        }

        public static Color[,] GetColorsFromTexture(Texture2D texture)
        {
            Color[] array = new Color[texture.Width * texture.Height];
            texture.GetData(array);
            Color[,] array2 = new Color[texture.Width, texture.Height];
            for (int i = 0; i < texture.Width; i++)
            {
                for (int j = 0; j < texture.Height; j++)
                {
                    array2[i, j] = array[i + j * texture.Width];
                }
            }
            return array2;
        }
    }
}