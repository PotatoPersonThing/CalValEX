using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using CalValEX.Boi.BaseClasses;

namespace CalValEX.Boi
{
    public class BoiDoor : BoiEntity, IInteractable, BaseClasses.IDrawable
    {
        public BoiRoom RoomImIn;
        public BoiRoom RoomILeadTo;
        Vector2 Wall;
        public float CollisionCircleRadius => 10;

        public bool Interact(BoiPlayer player)
        {
            //Unload the player from the room we are in
            RoomImIn.Entities.Remove(player);


            if (RoomILeadTo != null)
            {
                player.RoomImIn = RoomILeadTo;
            }

            else
            {
                player.RoomImIn = BoiHandler.NewRoom(RoomImIn.MapX + (int)Wall.X, RoomImIn.MapY + (int)Wall.Y, RoomImIn);
            }

            player.Position = BoiHandler.playingField - Position + Wall * 11;
            player.RoomImIn.Entities.Add(player);

            player.RoomCooldown = 30;

            return false;
        }

        public BoiDoor(BoiRoom room, Vector2 attachedWall)
        {
            RoomImIn = room;
            Wall = attachedWall;
            Position = BoiHandler.playingField / 2f + attachedWall * BoiHandler.playingField / 2f;
        }

        public BoiDoor(BoiRoom room, Vector2 attachedWall, BoiRoom roomTo)
        {
            RoomImIn = room;
            Wall = attachedWall;
            Position = BoiHandler.playingField / 2f + attachedWall * BoiHandler.playingField / 2f;
            RoomILeadTo = roomTo;
        }

        public bool CanBeInteractedWith
        {
            get
            {
                //Can't go through the door if theres any enemy left unkilled
                if (RoomImIn.Entities.FindAll(n => n is IDamageable ouch && ouch.Faction == Factions.enemy).Count > 0)
                    return false;

                if (BoiHandler.Ana.RoomCooldown > 0)
                    return false;
                return true;
            }
        }

        public int Layer => 0;

        public void Draw(SpriteBatch spriteBatch, Vector2 offset)
        {
            Texture2D DoorTexture = ModContent.Request<Texture2D>("CalValEX/Boi/Door").Value;
            Vector2 drawPosition = Position + offset;

            float drawRot = Wall.ToRotation() + MathHelper.PiOver2;

            spriteBatch.Draw(DoorTexture, drawPosition, null, Color.White, drawRot, DoorTexture.Size() / 2f, 1f, 0, 0);

        }
    }
}