/*using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using CalValEX.Buffs.PetComboBuffs;
using CalValEX.Items.Pets;
using CalValEX.Items.LightPets;
using CalValEX.Projectiles.Pets;
using CalValEX.Projectiles.Pets.LightPets;

namespace CalValEX.Items.PetComboItems.Hardmode
{
    public class HarbingerOfWork : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Harbinger Of Work");
            Tooltip.SetDefault("Robot love");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.UseSound = SoundID.NPCHit4;
            Item.value = Item.sellPrice(0, 10, 30, 0);
            Item.rare = 7;
            Item.buffType = ModContent.BuffType<HarbingerOfWorkBuff>();
        }

        public override void UseStyle(Player player, Rectangle heldItemFrame)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(Item.buffType, 3600, true);
            }
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            //Æ: Kill me*/
            /*string[] summonedPets = new string[] {"RoverSpindlePet", "DiggerPet", "Androomba", "AstPhage", "PBGMini", "SeerS", "SeerM", "SeerL"};
            foreach (string pet in summonedPets)
            {
            }*/
            /*type = ModContent.ProjectileType<RoverSpindlePet>();
            type = ModContent.ProjectileType<DiggerPet>();
            type = ModContent.ProjectileType<Androomba>();
            type = ModContent.ProjectileType<AstPhage>();
            type = ModContent.ProjectileType<PBGmini>();
            type = ModContent.ProjectileType<SeerS>();
            type = ModContent.ProjectileType<SeerM>();
            type = ModContent.ProjectileType<SeerL>();
            return base.Shoot(player, source, position, velocity, type, damage, knockback);
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<RoverSpindle>())
                .AddIngredient(ModContent.ItemType<DiggerRemote>())
                .AddIngredient(ModContent.ItemType<SuspiciousLookingGBC>())
                .AddIngredient(ModContent.ItemType<AstralInfectedIcosahedron>())
                .AddIngredient(ModContent.ItemType<PlaguebringerPowerCell>())
                .AddIngredient(ModContent.ItemType<AstralBinoculars>())
                .AddTile(TileID.AdamantiteForge)
                .Register();
        }
    }
}*/