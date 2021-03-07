using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace CalValEX.Oracle
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

        public override TagCompound Save()
        {
            return new TagCompound
            {
                {"playerHasGottenBag", playerHasGottenBag }
            };
        }

        public override void Load(TagCompound tag)
        {
            playerHasGottenBag = tag.GetBool("playerHasGottenBag");
        }

        public override void clientClone(ModPlayer clientClone)
        {
            OraclePlayer clone = clientClone as OraclePlayer;
            clone.playerHasGottenBag = playerHasGottenBag;
        }

        public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
        {
            ModPacket packet = mod.GetPacket();
            packet.Write((byte)CalValEX.MessageType.SyncOraclePlayer);
            packet.Write((byte)player.whoAmI);
            packet.Write(playerHasGottenBag);
            packet.Send(toWho, fromWho);
        }

        public override void SendClientChanges(ModPlayer clientPlayer)
        {
            OraclePlayer clone = clientPlayer as OraclePlayer;
            if (clone.playerHasGottenBag != playerHasGottenBag)
            {
                var packet = mod.GetPacket();
                packet.Write((byte)CalValEX.MessageType.PlayerBagChanged);
                packet.Write((byte)player.whoAmI);
                packet.Write(playerHasGottenBag);
                packet.Send();
            }
        }
    }
}