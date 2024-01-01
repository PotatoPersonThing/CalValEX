using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace CalValEX.Items.Pets
{

    [LegacyName("SkaterEgg")]
    public class AcidLamp : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Acid Lamp");
            // Tooltip.SetDefault("'There seems to be an egg inside'\n" + "Summons a Sulphurous Skater Nymph");
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.Item112;
            Item.shoot = ModContent.ProjectileType<Projectiles.Pets.SkaterPet>();
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = ItemRarityID.Pink;
            Item.buffType = ModContent.BuffType<Buffs.Pets.SkaterBuff>();
        }

        public override void UseStyle(Player player, Microsoft.Xna.Framework.Rectangle heldItemFrame)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                //CalamityMod.World.Planets.LuminitePlanet.GenerateLuminitePlanetoids();
                //CalamityMod.World.BrimstoneCrag.GenAllCragsStuff();

                /*{
                    string mapKey = "Sunken Sea Laboratory";
                    bool hasPlacedLogAndSchematic = false;
                    CalamityMod.Schematics.SchematicManager.PlaceSchematic(mapKey, new Point((int)Main.MouseWorld.X / 16, (int)Main.MouseWorld.Y / 16), SchematicAnchor.TopLeft, ref hasPlacedLogAndSchematic, new Action<Chest, int, bool>(FillSunkenSeaLaboratoryChest));
                }*/
                player.AddBuff(Item.buffType, 3600, true);
            }
        }
    }
}