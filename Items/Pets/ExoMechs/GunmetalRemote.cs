using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Pets.ExoMechs
{
    public class GunmetalRemote : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Dark Gunmetal Remote");
            // Tooltip.SetDefault("T Hanos\n" + "Summons a shorter and friendlier version of the high-tech digger");
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCHit4;
            Item.shoot = ModContent.ProjectileType<Projectiles.Pets.ExoMechs.ThanatosPet>();
            Item.value = Item.sellPrice(0, 3, 0, 0);
            Item.rare = CalamityID.CalRarityID.Violet;
            Item.buffType = ModContent.BuffType<Buffs.Pets.ExoMechs.ThanatosBuff>();
        }

        public override void UseStyle(Player player, Rectangle heldItemFrame)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(Item.buffType, 3600, true);
            }
        }

        //Listen for the mouseworld & right click from the owner. This is for mp syncing
        [JITWhenModsEnabled("CalamityMod")]
        public override void HoldItem(Player player)
        {
            if (CalValEX.CalamityActive)
            {
                CalValEX.Calamity.Call("SetRightClickListener", player, true);
                CalValEX.Calamity.Call("SetMouseWorldListener", player, true);
            }
        }
    }
}