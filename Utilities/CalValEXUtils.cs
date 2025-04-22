using CalamityMod.NPCs.NormalNPCs;
using CalValEX.CalamityID;
using MonoMod.ModInterop;
using System.Collections;
using Terraria;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX
{
    public class CVUtils
    {
        public const string AstrageldonRarity = "SuperbossRarity";
        public const string AvatarRarity = "AvatarRarity";
        public const string NamelessRarity = "NamelessDeityRarity";
        public const string MarsRarity = "GenesisComponentRarity";


        public static int SetRarity(int Rarity, string modRarity = "")
        {
            if (modRarity != "")
            {
                return CrossmodRarity(modRarity);
            }
            int ret = Rarity;
            // CalRarityID isn't done by load time, so unfortunately, this has to be done like this
            if (Rarity > 11)
            {
                ret = CalRarityID.Turquoise;
                switch (Rarity)
                {
                    case 13:
                        ret = CalRarityID.PureGreen;
                        break;
                    case 14:
                        ret = CalRarityID.DarkBlue;
                        break;
                    case 15:
                        ret = CalRarityID.Violet;
                        break;
                    case 16:
                        ret = CalRarityID.HotPink;
                        break;
                }
            }
            return ret;
        }


        // Gives the plush a rarity from another mod
        public static int CrossmodRarity(string rarity)
        {
            string modName = "";
            switch (rarity)
            {
                case AstrageldonRarity:
                    modName = "CatalystMod";
                    break;
                case MarsRarity:
                case NamelessRarity:
                case AvatarRarity:
                    modName = "NoxusBoss";
                    break;
            }

            if (ModLoader.TryGetMod(modName, out Mod modInstance))
            {
                return modInstance.Find<ModRarity>(rarity).Type;
            }
            return ItemRarityID.Gray;
        }


        public static void PetBuff(Player player, int buffIndex, int projType, int amount = 1)
        {
            bool petProjectileNotSpawned = player.ownedProjectileCounts[projType] < amount;
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, projType, 0, 0f, player.whoAmI, 0f, 0f);
            }
        }

        public static void CritterBestiary(NPC n, int NPCType)
        {
            for (int i = 0; i < Main.maxPlayers; i++)
            {
                Player player = Main.player[i];
                if (player is null || !player.active)
                    continue;

                if (n.Hitbox.Intersects(player.HitboxForBestiaryNearbyCheck))
                {
                    NPC nPC = new NPC();
                    nPC.SetDefaults(NPCType);
                    Main.BestiaryTracker.Kills.RegisterKill(nPC);
                    break;
                }
            }
        }
    }
}