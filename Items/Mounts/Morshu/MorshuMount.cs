using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CalValEX.Items.Mounts.Morshu
{
    public class MorshuMount : ModMountData
    {
        public override void SetDefaults()
        {
            mountData.buff = ModContent.BuffType<MorshuBuff>();
            mountData.heightBoost = 94;
            mountData.flightTimeMax = 0;
            mountData.fallDamage = 0.5f;
            mountData.runSpeed = 8f;
            mountData.dashSpeed = 8f;
            mountData.acceleration = 0.35f;
            mountData.jumpHeight = 18;
            mountData.jumpSpeed = 8.25f;
            mountData.constantJump = true;
            mountData.totalFrames = 4;
            int[] array = new int[mountData.totalFrames];
            for (int l = 0; l < array.Length; l++)
            {
                array[l] = 94;
            }
            mountData.playerYOffsets = array;
            mountData.xOffset = 30;
            mountData.bodyFrame = 3;
            mountData.yOffset = 0;
            mountData.playerHeadOffset = 94;
            mountData.standingFrameCount = 1;
            mountData.standingFrameDelay = 12;
            mountData.standingFrameStart = 0;
            mountData.runningFrameCount = 4;
            mountData.runningFrameDelay = 60;
            mountData.runningFrameStart = 0;
            mountData.flyingFrameCount = 0;
            mountData.flyingFrameDelay = 0;
            mountData.flyingFrameStart = 0;
            mountData.inAirFrameCount = 1;
            mountData.inAirFrameDelay = 12;
            mountData.inAirFrameStart = 3;
            mountData.idleFrameCount = 0;
            mountData.idleFrameDelay = 0;
            mountData.idleFrameStart = 0;

            if (Main.netMode == NetmodeID.Server)
            {
                return;
            }

            mountData.textureWidth = mountData.backTexture.Width;
            mountData.textureHeight = mountData.backTexture.Height;
        }

        public override void UpdateEffects(Player player)
        {
            if (player.wet)
            {
                if (player.velocity.Y >= 0)
                    player.velocity.Y = -4.5f;
            }

            MorshuConsumeCoinAI(player, 5);
        }

        /// <param name="time">Time in seconds</param>
        private void MorshuConsumeCoinAI(Player player, int time)
        {
            CalValEXPlayer modPlayer = player.GetModPlayer<CalValEXPlayer>();
            if (++modPlayer.morshuTimer >= time * 60)
            {
                modPlayer.morshuTimer = 0;
                bool consumed = false;

                for (int i = 50; i < 53; i++)
                {
                    if (player.inventory[i].type == ItemID.CopperCoin) //there are copper coins in the inventory. great!
                    {
                        player.inventory[i].stack -= 1;
                        if (player.inventory[i].stack == 0)
                            player.inventory[i].SetDefaults(ItemID.None);
                        consumed = true;
                        break;
                    }
                }

                #region silver

                if (!consumed)
                {
                    bool placedDownCopper = false;
                    for (int i = 50; i < 53; i++)
                    {
                        if (player.inventory[i].type == ItemID.SilverCoin)
                        {
                            player.inventory[i].stack -= 1;
                            if (player.inventory[i].stack == 0)
                                player.inventory[i].SetDefaults(ItemID.None);
                            if (player.inventory[i].type == ItemID.None) //easy solution, its already empty.
                            {
                                player.inventory[i].SetDefaults(ItemID.CopperCoin);
                                player.inventory[i].stack = 99;
                                placedDownCopper = true;
                                break;
                            }
                            consumed = true;
                        }
                    }

                    if (consumed)
                    {
                        if (!placedDownCopper)
                        {
                            PlaceCoinsDown(player, 99, ItemID.CopperCoin, ref placedDownCopper);
                        }
                    }
                }

                #endregion silver

                #region gold

                if (!consumed)
                {
                    bool placedDownSilver = false;
                    bool placedDownCopper = false;
                    for (int i = 50; i < 53; i++)
                    {
                        if (player.inventory[i].type == ItemID.GoldCoin)
                        {
                            player.inventory[i].stack -= 1;
                            if (player.inventory[i].stack == 0)
                                player.inventory[i].SetDefaults(ItemID.None);
                            if (player.inventory[i].type == ItemID.None)
                            {
                                player.inventory[i].SetDefaults(ItemID.SilverCoin);
                                player.inventory[i].stack = 99;
                                placedDownSilver = true;
                            }
                            consumed = true;
                            break;
                        }
                    }

                    if (!placedDownSilver && consumed)
                    {
                        PlaceCoinsDown(player, 99, ItemID.SilverCoin, ref placedDownSilver);
                    }

                    if (!placedDownCopper && consumed)
                    {
                        PlaceCoinsDown(player, 99, ItemID.CopperCoin, ref placedDownCopper);
                    }
                }

                #endregion gold

                #region platinum

                if (!consumed)
                {
                    bool placedDownGold = false;
                    bool placedDownSilver = false;
                    bool placedDownCopper = false;
                    for (int i = 50; i < 53; i++)
                    {
                        if (player.inventory[i].type == ItemID.PlatinumCoin)
                        {
                            player.inventory[i].stack -= 1;
                            if (player.inventory[i].stack == 0)
                                player.inventory[i].SetDefaults(ItemID.None);
                            if (player.inventory[i].type == ItemID.None)
                            {
                                player.inventory[i].SetDefaults(ItemID.GoldCoin);
                                player.inventory[i].stack = 99;
                                placedDownGold = true;
                            }
                            consumed = true;
                            break;
                        }
                    }

                    if (!placedDownGold && consumed)
                    {
                        PlaceCoinsDown(player, 99, ItemID.GoldCoin, ref placedDownGold);
                    }

                    if (!placedDownSilver && consumed)
                    {
                        PlaceCoinsDown(player, 99, ItemID.SilverCoin, ref placedDownSilver);
                    }

                    if (!placedDownCopper && consumed)
                    {
                        PlaceCoinsDown(player, 99, ItemID.CopperCoin, ref placedDownCopper);
                    }
                }

                #endregion platinum

                //if no coin consumed, make the player slower.

                mountData.runSpeed = 8f;
                mountData.dashSpeed = 8f;
                mountData.acceleration = 0.35f;
                mountData.jumpHeight = 18;
                mountData.jumpSpeed = 8.25f;

                if (!consumed)
                {
                    mountData.runSpeed = 2f;
                    mountData.dashSpeed = 2f;
                    mountData.acceleration = 0.05f;
                    mountData.jumpHeight = 4;
                    mountData.jumpSpeed = 8.25f;
                }
            }
        }

        private void PlaceCoinsDown(Player player, int coinCount, int coinType, ref bool coinBool)
        {
            for (int i = 50; i < 53; i++) //Try to find a new coin slot.
            {
                if (player.inventory[i].type == ItemID.None)
                {
                    player.inventory[i].SetDefaults(coinType);
                    player.inventory[i].stack = coinCount;
                    coinBool = true;
                    break;
                }
            }

            if (!coinBool)
            {
                for (int i = 0; i < 49; i++) //no coin slots empty, try to put it in the inventory.
                {
                    if (player.inventory[i].type == ItemID.None)
                    {
                        player.inventory[i].SetDefaults(coinType);
                        player.inventory[i].stack = coinCount;
                        coinBool = true;
                        break;
                    }
                }
            }

            if (!coinBool) //if all else fails, spawn the coins outside.
                player.QuickSpawnItem(coinType, coinCount);
        }
    }
}