using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Terraria.Audio;
using CalValEX.ExtraTextures.ChristmasPets;
using CalValEX.Biomes;
using Terraria.ModLoader;
using CalValEX.AprilFools.Meldosaurus;
using CalValEX.Items;
using CalValEX.Items.Dyes;
using CalValEX.Items.Equips.Balloons;
using CalValEX.Items.Equips.Capes;
using CalValEX.Items.Equips.Hats;
using CalValEX.Items.Equips.Hats.Draedon;
using CalValEX.Items.Equips.Legs;
using CalValEX.Items.Equips.Scarves;
using CalValEX.Items.Equips.Shields;
using CalValEX.Items.Equips.Shirts;
using CalValEX.Items.Equips.Shirts.Draedon;
using CalValEX.Items.Equips.Transformations;
using CalValEX.Items.Equips.Wings;
using CalValEX.Items.Equips.Blanks;
using CalValEX.Items.Hooks;
using CalValEX.Items.LightPets;
using CalValEX.Items.Mounts;
using CalValEX.Items.Mounts.LimitedFlight;
using CalValEX.Items.Mounts.InfiniteFlight;
using CalValEX.Walls;
using CalValEX.Items.Walls.Astral;
using CalValEX.Items.Walls;
using CalValEX.Items.Pets;
using CalValEX.Items.Plushies;
using CalValEX.Items.Pets.Elementals;
using CalValEX.Items.Tiles;
using CalValEX.Items.Tiles.Blocks;
using CalValEX.Items.Tiles.FurnitureSets.Bloodstone;
using CalValEX.Items.Tiles.Plushies;
using CalValEX.NPCs.Oracle;
using CalValEX.NPCs.JellyPriest;
using CalValEX.Items.Equips.Legs.Draedon;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Shaders;
using CalValEX.Tiles.MiscFurniture;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.Localization;
using ReLogic.Content;
using CalamityMod;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Placeables.Plates;
using CalamityMod.Items.Placeables;
using CalamityMod.Items.Placeables.FurnitureStatigel;
using CalamityMod.Items.Placeables.FurnitureOtherworldly;
using CalamityMod.Items.Placeables.FurnitureStratus;
using CalamityMod.Items.Placeables.FurniturePlagued;
using CalamityMod.Items.Placeables.FurnitureProfaned;
using CalamityMod.Items.Placeables.FurnitureSilva;
using CalValEX.NPCs.TownPets.Nuggets;
using CalValEX.Items.Pets.TownPets;

namespace CalValEX
{
    public partial class CalValEX : Mod
    {
        private Mod calamity;
        private bool calamityActive;
        public static bool CalamityActive => instance.calamityActive;
        public static Mod Calamity => CalamityActive ? instance.calamity : null;

        public static bool CalamityContent<T>(string name, out T content) where T : IModType
        {
            content = default(T);
            if (!CalamityActive)
                return false;
            return Calamity.TryFind(name, out content);
        }

        public static int CalamityProjectile(string name)
        {
            if (CalamityContent(name, out ModProjectile content))
                return content.Type;
            return -1;
        }

        public static int CalamityItem(string name)
        {
            if (CalamityContent(name, out ModItem content))
                return content.Type;
            return -1;
        }

        public static int CalamityNPC(string name)
        {
            if (CalamityContent(name, out ModNPC content))
                return content.Type;
            return -1;
        }

        public static int CalamityTile(string name)
        {
            if (CalamityContent(name, out ModTile content))
                return content.Type;
            return -1;
        }

        public static int CalamityWall(string name)
        {
            if (CalamityContent(name, out ModWall content))
                return content.Type;
            return -1;
        }

        public static int CalamityBuff(string name)
        {
            if (CalamityContent(name, out ModBuff content))
                return content.Type;
            return -1;
        }
    }
}