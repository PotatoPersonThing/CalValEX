using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;
using System.Collections.Generic;

namespace CalValEX
{
    public class CalValEXGlobalProjectile : GlobalProjectile
    {
        /*public override bool PreDraw(Projectile projectile, SpriteBatch spriteBatch, Color drawColor)
        {
            if (CalValEXWorld.RockshrinEX)
            {
                //DEUS HEAD
                if (projectile.type == ModLoader.GetMod("CalamityMod").ProjectileType("BrimstoneMonster"))
                {
                    Texture2D deusheadsprite = (ModContent.GetTexture("CalValEX/Projectiles/BrimstoneMonster"));

                    float deusheadframe = 1f / (float)Main.npcFrameCount[projectile.type];
                    int deusheadheight = (int)((float)(1 / projectile.height) * deusheadframe) * (deusheadsprite.Height / 1);

                    Rectangle deusheadsquare = new Rectangle(0, deusheadheight, deusheadsprite.Width, deusheadsprite.Height / 1);
                    Color deusheadalpha = projectile.GetAlpha(drawColor);
                    spriteBatch.Draw(deusheadsprite, projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), deusheadsquare, deusheadalpha, projectile.rotation, Utils.Size(deusheadsquare) / 2f, projectile.scale, SpriteEffects.None, 0f);
                    return false;
                }
            }
            return true;
        }*/

        public override bool? CanHitNPC(Projectile projectile, NPC target)
        {
            if (projectile.type == Terraria.ID.ProjectileID.VortexBeaterRocket && target.type == ModContent.NPCType< AprilFools.Jharim.Jharim >())
            {
                return true;
            }
            else
            {
                return null;
            }
        }
    }
}
