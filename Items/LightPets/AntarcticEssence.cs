using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.LightPets
{
    public class AntarcticEssence : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.ItemNoGravity[Item.type] = true;
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            //Item.UseSound = SoundID.NPCHit5;
            //Item.shoot = ModContent.ProjectileType<Lightshield>();
            Item.value = Item.sellPrice(0, 2, 0, 0);
            //Item.buffType = ModContent.BuffType<Buffs.LightPets.LightshieldBuff");
            Item.rare = ItemRarityID.Pink;
        }

        /*public override void UseStyle(Player player, Rectangle heldItemFrame)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(Item.buffType, 3600, true);
            }
        }*/
    }
}