using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Buffs.PetComboBuffs;
using CalValEX.Projectiles.Pets;
using CalValEX.Items.PetComboItems.PreHardmode;
using CalValEX.Items.PetComboItems.Hardmode;
using CalValEX.Items.Pets.ExoMechs;
using CalValEX.Projectiles.Pets.Wulfrum;
using CalValEX.Projectiles.Pets.LightPets;
using CalValEX.Projectiles.Pets.ExoMechs;
using static Terraria.ModLoader.ModContent;

namespace CalValEX.Items.PetComboItems.PostMoonLord {
    public class ScratchedGong : ModItem {
        public override void SetDefaults() {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCHit4;
            Item.value = Item.sellPrice(1, 6, 6, 9);
            Item.rare = ItemRarityID.Purple;
            Item.buffType = BuffType<ScratchedGongBuff>();
        }

        public override void UseStyle(Player player, Rectangle heldItemFrame) {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
                player.AddBuff(Item.buffType, 3600, true);
        }
        
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            ProjectileType<WulfrumPylon>();
            ProjectileType<WulfrumDrone>();
            ProjectileType<WulfrumRover>();
            ProjectileType<WulfrumHover>();
            ProjectileType<WulfrumOrb>();
            ProjectileType<RepairBot>();
            ProjectileType<RoverSpindlePet>();
            ProjectileType<DiggerPet>();
            ProjectileType<Androomba>();
            ProjectileType<AstPhage>();
            ProjectileType<PBGmini>();
            ProjectileType<SeerS>();
            ProjectileType<SeerM>();
            ProjectileType<SeerL>();
            ProjectileType<ThanatosPet>();
            ProjectileType<AresBody>();
            ProjectileType<TwinsPet>();
            return base.Shoot(player, source, position, velocity, type, damage, knockback);
        }
    }
}