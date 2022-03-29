using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using CalValEX.Projectiles.Pets;
using CalValEX.Projectiles.Pets.Elementals;
using CalValEX.Projectiles.Pets.LightPets;
using CalValEX.Projectiles.Pets.Scuttlers;
using CalValEX.Projectiles.Pets.ExoMechs;

namespace CalValEX.Buffs.PetComboBuffs
{
    public class PandoraBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Pandemonium Box");
            Description.SetDefault("Dream, it's all over\nWe've been waiting for another sight to see");
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<CalValEXPlayer>().Pandora = true;
       }
    }
}