using System;
using CalamityFables.Content.Tiles.Graves;
using Terraria;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Reflection;
using CalamityFables.Core;
using Terraria.ModLoader;
using CalValEX.Dusts;
using MonoMod.Cil;
using static CalamityFables.Core.CustomGravesPlayer;
using CalValEX.Biomes;
using MonoMod.RuntimeDetour;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Audio;
using Terraria.ID;
using CalamityFables.Helpers;
using Terraria.GameContent;
using CalValEX.Projectiles.Plushies;

namespace CalValEX.Tiles
{
    [ExtendsFromMod("CalamityFables")]
    public class BlightGrave : BaseGrave
    {
        public override string Texture => "CalValEX/Items/Tiles/AstralGraves";

        public readonly static List<int> ProjectileTypes = new List<int>();
        protected readonly static List<AutoloadedGravestoneProjectile> ProjectileInstances = new();
        protected readonly static List<AutoloadedGravestoneItem> ItemInstances = new();

        public override string DirectoryPath => "CalValEX/Items/Tiles/";

        public override Color MapColor => new Color(104, 100, 126);
        public override string MapName => "Blighted Grave";
        public override int BreakDust => ModContent.DustType<AstralDust>();

        public override string[] GravestoneNames => new string[] { "AstralHeadstone", "AstralGravestone", "AstralTombstone", "AstralGraveMarker" };
        public override List<int> ProjectilePool => ProjectileTypes;
        public override List<AutoloadedGravestoneProjectile> Projectiles => ProjectileInstances;
        public override List<AutoloadedGravestoneItem> Items => ItemInstances;

        public override void NearbyEffects(int i, int j, bool closer)
        {
            Vector2 pos = new Vector2(i, j) * 16f;

            if (Main.rand.NextBool(50) && Main.tile[new Point(i, j)].TileFrameY % 36 == 18)
            {
                Dust.NewDustPerfect(pos + new Vector2(Main.rand.NextFloat(0, 16), Main.rand.NextFloat(8, 16)), 43, Vector2.UnitY * -Main.rand.NextFloat(0.08f, 0.2f), 0, Color.Lavender, Main.rand.NextFloat(0.5f, 1f));
            }
        }
    }
    //[ExtendsFromMod("CalamityFables")]

    /*public class XenoGrave : CorruptGrave
    {
        public override string Texture => "CalValEX/Items/Tiles/AstralGraves";

        public readonly static new List<int> ProjectileTypes = new List<int>();
        protected readonly static new List<AutoloadedGravestoneProjectile> ProjectileInstances = new();
        protected readonly static new List<AutoloadedGravestoneItem> ItemInstances = new();
        public override Color MapColor => new Color(120, 99, 197);
        public override string MapName => "Xenostone Grave";
        public override int BreakDust => ModContent.DustType<AstralDust>();
        public override bool Gilded => true;

        public override List<int> ProjectilePool => ProjectileTypes;
        public override List<AutoloadedGravestoneProjectile> Projectiles => ProjectileInstances;
        public override List<AutoloadedGravestoneItem> Items => ItemInstances;
        public override string[] GravestoneNames => new string[] { "AstralHeadstone", "AstralGravestone", "AstralTombstone", "AstralGraveMarker" };


        public override void NearbyEffects(int i, int j, bool closer)
        {
            Vector2 pos = new Vector2(i, j) * 16f;

            if (Main.rand.NextBool(50) && Main.tile[new Point(i, j)].TileFrameY % 36 == 18)
            {
                Dust.NewDustPerfect(pos + new Vector2(Main.rand.NextFloat(0, 16), Main.rand.NextFloat(8, 16)), 43, Vector2.UnitY * -Main.rand.NextFloat(0.08f, 0.2f), 0, Color.Lavender, Main.rand.NextFloat(0.5f, 1f));
            }
        }
    }*/

    [ExtendsFromMod("CalamityFables")]
    internal sealed class AstralGraveHijack : ModSystem
    {
        MethodInfo nextTypeMethod = null;
        
        public override void Load()
        {
            base.Load();

            typeHook = new Hook(getTypeField, NextValidGraveType);
            drawHook = new Hook(drawField, DrawGraveIcon);

        }

        public override void Unload()
        {
            typeHook = null;
            drawHook = null;
        }

        public static MethodInfo getTypeField = typeof(CustomGravesPlayer).GetMethod("NextValidGraveType", BindingFlags.Instance | BindingFlags.Public);
        public static MethodInfo drawField = typeof(CustomGravesPlayer).GetMethod("DrawTombstoneStyleIcon", BindingFlags.Instance | BindingFlags.NonPublic);
        public delegate CustomGraveSelectionType orig_Grave(CustomGravesPlayer self, int direction = 1);
        public delegate bool orig_Draw(CustomGravesPlayer self, int toggleType, Vector2 position);
        public static Hook typeHook;
        public static Hook drawHook;

        public CustomGraveSelectionType NextValidGraveType(orig_Grave orig, CustomGravesPlayer self, int direction = 1)
        {

            if (!self.UnlockedAnyGraveOption)
                return CustomGraveSelectionType.Regular;

            CustomGraveSelectionType currentGraveType = (CustomGraveSelectionType)(((int)self.graveMode + direction).ModulusPositive(15));
            while (true)
            {
                if (self.graveData[currentGraveType].Unlocked)
                    return currentGraveType;
                currentGraveType = (CustomGraveSelectionType)(((int)currentGraveType + direction).ModulusPositive(15));
            }
        }

        public bool DrawGraveIcon(orig_Draw grave, CustomGravesPlayer self, int toggleType, Vector2 position)
        {
            if (toggleType != DummyToggleType)
                return false;

            CustomGravesPlayer modPlayer = Main.LocalPlayer.GetModPlayer<CustomGravesPlayer>();

            if (TombstoneIcons == null)
                TombstoneIcons = ModContent.Request<Texture2D>(AssetDirectory.UI + "GravestoneSelection");

            Texture2D tex = (int)modPlayer.graveMode == 14 ? TextureAssets.Projectile[ModContent.ProjectileType<ItsReal>()].Value : TombstoneIcons.Value;
            Rectangle frame = (int)modPlayer.graveMode == 14 ? new Rectangle(0, 0, tex.Width, tex.Height) : tex.BetterFrame(GRAVE_TYPE_COUNT, 2, (int)modPlayer.graveMode);
            Rectangle hoverFrame = (int)modPlayer.graveMode == 14 ? new Rectangle(0, 0, tex.Width, tex.Height) : tex.BetterFrame(GRAVE_TYPE_COUNT, 2, (int)modPlayer.graveMode, 1);
            float iconScale = 0.9f;

            //Position is centered fsr
            position -= frame.Size() / 2f;
            position += Vector2.One * 2;

            bool hovered = false;
            if (Main.mouseX > position.X && (float)Main.mouseX < (float)position.X + (float)frame.Width * iconScale && Main.mouseY > position.Y && (float)Main.mouseY < (float)position.Y + (float)frame.Height * iconScale)
            {
                hovered = true;
                Main.LocalPlayer.mouseInterface = true;

                //Hover text
                Main.instance.MouseText(modPlayer.SelectedGrave.name, 0, 0);
                Main.mouseText = true;

                //On click, flip between modes
                if (Main.mouseLeft && Main.mouseLeftRelease)
                {
                    SoundEngine.PlaySound(SoundID.MenuTick);
                    modPlayer.graveMode = modPlayer.NextValidGraveType();
                    modPlayer.SyncSelectedGrave();
                }

                //On right click, go back
                else if (Main.mouseRight && Main.mouseRightRelease)
                {
                    SoundEngine.PlaySound(SoundID.MenuTick);
                    modPlayer.graveMode = modPlayer.NextValidGraveType(-1);
                    modPlayer.SyncSelectedGrave();
                }
            }

            //Draw the icons
            Main.spriteBatch.Draw(tex, position, frame, Color.White, 0f, Vector2.Zero, iconScale, SpriteEffects.None, 0f);
            if (hovered)
                Main.spriteBatch.Draw(tex, position, hoverFrame, Main.OurFavoriteColor, 0f, Vector2.Zero, iconScale, SpriteEffects.None, 0f);

            //Fuck gamepad i think. Nique ta mère
            //UILinkPointNavigator.SetPosition(6000 + gamepadPointOffset, vector + rectangle.Size() * 0.65f);
            return true;
        }

        public override void PostUpdateEverything()
        {
            if (!Main.gameMenu)
            {
                CustomGravesPlayer gravePlayer = Main.LocalPlayer.GetModPlayer<CustomGravesPlayer>();
                if (!gravePlayer.graveData.ContainsKey((CustomGraveSelectionType)14))
                {
                    CustomGraveData g = new CustomGraveData((CustomGraveSelectionType)14, "Astral", gravePlayer,
                        BlightGrave.ProjectileTypes, BlightGrave.ProjectileTypes, p => p.InModBiome<AstralBlight>(), 3f);
                    g.Unlocked = true;
                    gravePlayer.graveData.Add((CustomGraveSelectionType)14, g);
                }
            }
        }
    }
}