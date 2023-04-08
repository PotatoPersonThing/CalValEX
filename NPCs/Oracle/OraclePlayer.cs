using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace CalValEX.NPCs.Oracle
{
    public class OraclePlayer : ModPlayer
    {
        public override void UpdateDead()
        {
            OracleGlobalNPC.playerTargetTimer = -1;
        }

        public bool playerHasGottenBag;

        public override void Initialize()
        {
            playerHasGottenBag = false;
        }

        public override void PostUpdateMiscEffects()
        {
            if (!Main.dayTime && Main.time == 32398)
            {
                playerHasGottenBag = false;
            }
        }

        public override void SaveData(TagCompound tag)
        {
            new TagCompound
            {
                {"playerHasGottenBag", playerHasGottenBag }
            };
        }
        public override void LoadData(TagCompound tag)
        {
            playerHasGottenBag = tag.GetBool("playerHasGottenBag");
        }

        public override void CopyClientState(ModPlayer clientClone)/* tModPorter Suggestion: Replace Item.Clone usages with Item.CopyNetStateTo */
        {
            OraclePlayer clone = clientClone as OraclePlayer;
            clone.playerHasGottenBag = playerHasGottenBag;
        }

        public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
        {
            ModPacket packet = Mod.GetPacket();
            packet.Write((byte)CalValEX.MessageType.SyncOraclePlayer);
            packet.Write((byte)Player.whoAmI);
            packet.Write(playerHasGottenBag);
            packet.Send(toWho, fromWho);
        }

        public override void SendClientChanges(ModPlayer clientPlayer)
        {
            OraclePlayer clone = clientPlayer as OraclePlayer;
            if (clone.playerHasGottenBag != playerHasGottenBag)
            {
                var packet = Mod.GetPacket();
                packet.Write((byte)CalValEX.MessageType.PlayerBagChanged);
                packet.Write((byte)Player.whoAmI);
                packet.Write(playerHasGottenBag);
                packet.Send();
            }
        }
    }
}