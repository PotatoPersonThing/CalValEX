using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;
using System.Linq;

namespace CalValEX.Boi.BaseClasses
{
    public class BoiEntity
    {
        public Vector2 OldPosition;
        public Vector2 Position;
        public Vector2 Velocity;
        public List<BoiItem> Inventory = new List<BoiItem>();
        public virtual void OnSpawn() { }
        public virtual void Update() { }

        public Vector2 ScreenPosition()
        {
            return Position + BoiHandler.ScreenOffset;
        }

        public BoiEntity Clone()
        {
            BoiEntity clone = new BoiEntity();
            clone.Position = Position;
            clone.Velocity = Velocity;
            clone.OldPosition = OldPosition;

            return clone;
        }
    }

    public class BoiRoom
    {
        public int MapX;
        public int MapY;

        public static readonly List<Vector2> Walls = new List<Vector2>() { Vector2.UnitX, -Vector2.UnitX, Vector2.UnitY, -Vector2.UnitY };

        public List<BoiEntity> Entities; //A list of entities spawned on entry of the room.

        public BoiRoom(int X, int Y, BoiRoom ComingFrom, bool ForcedDeadEnd = false)
        {
            Dictionary<Vector2, BoiDoor> Doors = new Dictionary<Vector2, BoiDoor>();
            Entities = new List<BoiEntity>();

            //Place the room on the map
            MapX = X;
            MapY = Y;

            //If we are coming from an already existing room, create a door that leads back to it.
            if (ComingFrom != null)
            {
                Vector2 doorPos = new Vector2(ComingFrom.MapX - X, ComingFrom.MapY - Y);
                doorPos.Normalize();
                Doors.Add(doorPos, new BoiDoor(this, doorPos, ComingFrom));

                //Additionally, lower the count of open doors of the handler, as entering the room means that there is one less door that is unexplored.
                BoiHandler.UnexploredDoors -= 1;
            }

            //Generate random doors. We want at least ONE door if there are no unexplored doors in the map, to avoid to entirely close off the map.
            int minDoors = BoiHandler.UnexploredDoors <= 0 ? 1 : 0;

            //If we are coming from anotehr room , we can only get 3 more doors at max. If we aren't, we can have up to 4 more doors.
            int maxDoors = ComingFrom != null ? 3 : 4;

            int generatedNewDoors = 0;
            bool stop = false;

            //In the case of boss rooms, where we don't really care if the floor ends up "complete", we don't need any doors at all (minus the one to come back to the rest of the level, of course.
            if (!ForcedDeadEnd)
            {
                while (!stop)
                {
                    foreach (Vector2 wall in Walls)
                    {
                        //Don't add doors on walls that already have doors.
                        if (Doors.ContainsKey(wall))
                            continue;

                        if (Main.rand.NextBool(3))
                        {
                            Doors[wall] = new BoiDoor(this, wall);
                            generatedNewDoors++;
                        }
                    }

                    stop = Main.rand.NextBool(2);

                    //Don't stop the generation if not enough doors exist.
                    if (generatedNewDoors < minDoors)
                        stop = false;

                    //Do stop the generation if too many doors exist
                    if (generatedNewDoors >= maxDoors)
                        stop = true;
                }
            }

            Entities.AddRange(Doors.Values.ToList());

            BoiHandler.UnexploredDoors += generatedNewDoors;
        }
    }

    public class BoiItem
    {
        Entity Owner;

        public void UpdateEffect() { }
    }
}
