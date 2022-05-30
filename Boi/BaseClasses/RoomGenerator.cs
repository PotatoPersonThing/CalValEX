using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;
using CalValEX.Boi;
using System.Linq;

namespace CalValEX.Boi.BaseClasses
{
	public static class RoomGenerator
	{
		public static List<BoiEntity> GetClone(this List<BoiEntity> source)
		{
			return source.Select(item => item.Clone())
						.ToList();
		}

		public static void PopulateRoomEnemies(BoiRoom room, bool bossRoom = false)
        {
			room.Entities.AddRange(Main.rand.NextFromCollection(Layouts).Population.GetClone());
        }

		public static void Populate(this BoiRoom room)
        {
			PopulateRoomEnemies(room);
        }

		public static readonly List<RoomLayout> Layouts = new List<RoomLayout>()
		{
			new RoomLayout(new List<BoiEntity>()
			{
				//Entities




			}),

			new RoomLayout(new List<BoiEntity>()
			{
				//Entities




			}),

			new RoomLayout(new List<BoiEntity>()
			{
				//Entities.. Etc. You got me




			})
		};
	}


	


	//Very barebones.
	public struct RoomLayout
    {
		public List<BoiEntity> Population;

		public RoomLayout(List<BoiEntity> population )
        {
			Population = population;
        }
    }
}
