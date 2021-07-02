using CalValEX.Projectiles.Pets.LightPets;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.LightPets
{
    public class AntarcticEssence : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Antarctic Essence");
            Tooltip.SetDefault("Summons a cosmetic shield of Cryogen's ice around you");
            ItemID.Sets.ItemNoGravity[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.UseSound = SoundID.NPCHit5;
            item.shoot = ModContent.ProjectileType<Lightshield>();
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.buffType = mod.BuffType("LightshieldBuff");
            item.rare = ItemRarityID.Pink;
        }

        public override void UseStyle(Player player)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(item.buffType, 3600, true);
            }
        }
    }
}