using Terraria;
using Terraria.ModLoader;
using CalValEX.Projectiles.Pets;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using static Terraria.ModLoader.ModContent;
using CalamityMod.Items.Weapons.Summon;

namespace CalValEX.Buffs.Pets {
    public class BrimberryBuff : ModBuff {
        public override void SetStaticDefaults() {
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex) {
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CalValEXPlayer>().brimberry = true;
            bool petProjectileNotSpawned = player.ownedProjectileCounts[ProjectileType<BrimberryPet>()] <= 0;
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (player.width / 2),
                    player.position.Y + (player.height / 2), 0f, 0f, ProjectileType<BrimberryPet>(), 0, 0f, player.whoAmI, 0f, 0f);
        }

        public override bool PreDraw(SpriteBatch spriteBatch, int buffIndex, ref BuffDrawParams drawParams) {
            bool seek = Main.LocalPlayer.HasItem(ItemType<DormantBrimseeker>());
            Texture2D tex = Request<Texture2D>("CalValEX/Buffs/Pets/BrimberryBuff").Value;
            Rectangle frame = new Rectangle(seek ? 36 : 0, 0, 32, 32);
            Main.EntitySpriteDraw(tex, drawParams.Position, frame, drawParams.DrawColor, 0, Vector2.Zero, 1, SpriteEffects.None, 0);

            return false;
        }
    }
}