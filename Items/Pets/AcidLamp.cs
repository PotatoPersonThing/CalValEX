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
            DisplayName.SetDefault("Acid Lamp");
            Tooltip.SetDefault("'There seems to be an egg inside'\n" + "Summons a Sulphurous Skater Nymph");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.Item112;
            Item.shoot = ModContent.ProjectileType<Projectiles.Pets.SkaterPet>();
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = 5;
            Item.buffType = ModContent.BuffType<Buffs.Pets.SkaterBuff>();
        }

        public override void UseStyle(Player player, Microsoft.Xna.Framework.Rectangle heldItemFrame)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(Item.buffType, 3600, true);
            }
        }
    }
}