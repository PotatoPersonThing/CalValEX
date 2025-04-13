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

namespace CalValEX.Tiles
{
    [ExtendsFromMod("CalamityFables")]
    public class BlightGrave : BaseGrave
    {
        public override string Texture => "CalValEX/Items/Tiles/AstralGraves";

        public readonly static List<int> ProjectileTypes = new List<int>();
        protected readonly static List<AutoloadedGravestoneProjectile> ProjectileInstances = new();
        protected readonly static List<AutoloadedGravestoneItem> ItemInstances = new();

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
    [ExtendsFromMod("CalamityFables")]

    public class XenoGrave : CorruptGrave
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
    }

    [ExtendsFromMod("CalamityFables")]
    internal sealed class AstralGraveHijack : ModSystem
    {
        private static Mod currentMod;
        
        public override void Load()
        {
            base.Load();

            MonoModHooks.Add(
                typeof(BaseGrave).GetMethod(nameof(BaseGrave.Load), BindingFlags.Public | BindingFlags.Instance),
                (Action<BaseGrave> orig, BaseGrave self) =>
                {
                    currentMod = self.Mod;
                    orig(self);
                }
            );

            MonoModHooks.Modify(
                typeof(GravestoneLoader).GetMethod(nameof(GravestoneLoader.LoadGravestone), BindingFlags.Public | BindingFlags.Static),
                il =>
                {
                    var c = new ILCursor(il);
                    
                    while (c.TryGotoNext(MoveType.After, x => x.MatchCall<GravestoneLoader>("get_Fables")))
                    {
                        c.EmitPop();
                        c.EmitLdsfld(GetType().GetField(nameof(currentMod), BindingFlags.NonPublic | BindingFlags.Static)!);
                    }
                }
            );
        }
    }
}