using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonEscapeCS.Levels {
	class Level {
		public enum RoomItems : int {
			WALL = 0,
			EMPTY = 1,
			UBER = 2,
			KILL = 3,
			WAY1INL = 4, WAY1INR = 5, WAY1INU = 6, WAY1IND = 7,
			WAY1OUTL = 8, WAY1OUTR = 9, WAY1OUTU = 10, WAY1OUTD = 11,
			WALL_L = 12, WALL_R = 13, WALL_U = 14, WALL_D = 15,
			START = 16,
			SMALL_RIGHT = 17, SMALL_LEFT = 18, SMALL_UP = 19, SMALL_DOWN = 20,
			CRAWL_LR = 21, CRAWL_UD = 22, // - |
			CRAWL_LU = 23, CRAWL_LD = 24, // -^ -.
			CRAWL_RU = 25, CRAWL_RD = 26, // ^- .-
			CRAWL_T_D = 27, CRAWL_T_U = 28, CRAWL_T_L = 29, CRAWL_T_R = 30, //This means Up Right and Down (middle is right)
			CRAWL_4 = 31, // +
			LOCK_L = 32, LOCK_R = 33, LOCK_U = 34, LOCK_D = 35,
			PRESSURE_PLATE = 36,
			UNLOCK_L = 37, UNLOCK_R = 38, UNLOCK_U = 39, UNLOCK_D = 40,
			TELEPORT = 41, NULL_TELEPORT = 42,
			FORCE_U = 43, FORCE_D = 44, FORCE_L = 45, FORCE_R = 46,
			EXIT = 47, POWERUP = 48, HIDDEN = 49,
			SPIKES = 50, CHEST = 51,
			SPIKE_WALL_L = 52, SPIKE_WALL_R = 53, SPIKE_WALL_U = 54, SPIKE_WALL_D = 55
		};

		public enum PowerupEnum : int {
			TINY = 0,
			CROUCH = 1,
			LIFE = 24,
			COINS = 25,
			KEY = 26
		};

		public int width, height;

		public Extra extraData = new Extra(new List<int>() { 0 });

		public List<Room> rooms;

		public bool hasCustomFunction;

		public int customFunction;

		public Level(int fWidth, int fHeight, Extra fExtra, List<Room> fData, bool fHasCustomFunction, int fCustomFunction) {
			width = fWidth;
			height = fHeight;
			extraData = fExtra;
			rooms = fData;
			hasCustomFunction = fHasCustomFunction;
			customFunction = fCustomFunction;
		}
	}
}
