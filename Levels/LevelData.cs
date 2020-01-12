using System.Collections.Generic;
using static DungeonEscapeCS.Levels.Level.PowerupEnum;
using static DungeonEscapeCS.Levels.Level.RoomItems;

namespace DungeonEscapeCS.Levels {
	internal class LevelData {
		public static Level returnData = new Level(0, 0, new Extra(new List<bool>() { false }), new List<Room>() { new Room(new[] { WALL }) }, false, 0);

		public static Level GetLevel(int chapter, int lvl) {
			switch (chapter) {
				case 0:
					switch (lvl) {
						case 0:
							returnData.width = 8;
							returnData.height = 10;
							returnData.rooms = new List<Room>() {
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { START, WALL_L, WALL_U, WALL_R }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }), //row 1
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { EMPTY, WALL_L, WALL_R }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }), //row 2
								new Room(new [] { EMPTY, WALL_L, WALL_U }),
								new Room(new [] { EMPTY, WALL_U, WALL_D }),
								new Room(new [] { EMPTY, SMALL_RIGHT }),
								new Room(new [] { EMPTY, CRAWL_LR }),
								new Room(new [] { EMPTY, CRAWL_LD }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }), //row 3
								new Room(new [] { EMPTY, WALL_L, WALL_R }),
								new Room(new [] { WALL }),
								new Room(new [] { EMPTY, WALL_L, WALL_R }),
								new Room(new [] { WALL }),
								new Room(new [] { EMPTY, WALL_L, SMALL_UP, WALL_D }),
								new Room(new [] { EMPTY, WALL_U, LOCK_R, SMALL_DOWN }, new [] { EMPTY, WALL_U, /*UNLOCK_R,*/ SMALL_DOWN }, false),
								new Room(new [] { EXIT, WALL_U, WALL_D, LOCK_L, WALL_R }, new [] { EXIT, WALL_U, WALL_D, WALL_R }, false),
								new Room(new [] { WALL }), //row 4
								new Room(new [] { EMPTY, WALL_L, WALL_R }),
								new Room(new [] { WALL }),
								new Room(new [] { EMPTY, WALL_L, WALL_D }, new [] { EMPTY, WALL_L }, true),
								new Room(new [] { EMPTY, WALL_U, WALL_D }),
								new Room(new [] { TELEPORT, WALL_U, WALL_R, WALL_D }, 49),
								new Room(new [] { EMPTY, CRAWL_UD }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }), //row 5
								new Room(new [] { EMPTY, WALL_L, WALL_R }),
								new Room(new [] { WALL }, new [] { EMPTY, WALL_U, WALL_L, WALL_D }, true),
								new Room(new [] { WALL }, new [] { EMPTY, WALL_R, WALL_D }, true), //room 43 (42 + 1)
								new Room(new [] { WALL_U, WALL_L, PRESSURE_PLATE }, new int[] { 34, 41, 42 }),
								new Room(new [] { EMPTY, WALL_U, WALL_D, SMALL_RIGHT }),
								new Room(new [] { CRAWL_LU, PRESSURE_PLATE }, new int[] { 29, 30 }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }), //row 6
								new Room(new [] { EMPTY, WALL_L, WALL_R }),
								new Room(new [] { WALL_U, WALL_L, WALL_D, TELEPORT }, 36),
								new Room(new [] { EMPTY, WALL_U, WALL_D }),
								new Room(new [] { EMPTY, WALL_R, WALL_D }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL_U, WALL_L, WALL_R, FORCE_D }), //row 7
								new Room(new [] { EMPTY, WALL_L, WALL_R }),
								new Room(new [] { WALL }),
								new Room(new [] { TELEPORT, WALL_L, WALL_U, WALL_R }, 55),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { PRESSURE_PLATE, WALL_L, WALL_R }, new int[] { 64, 65, 66 }), //row 8
								new Room(new [] { EMPTY, WALL_L, WALL_D }, new [] { EMPTY, WALL_L, WALL_D, WALL_R }, true),
								new Room(new [] { EMPTY, WALL_U, WALL_D }, new [] { EMPTY, WALL }, true),
								new Room(new [] { EMPTY }, new [] { EMPTY, WALL_L }, true),
								new Room(new [] { HIDDEN, KILL, WALL_U, WALL_R, WALL_D }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { TELEPORT, WALL_L, WALL_D, WALL_R }, 10), //row 9
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL_L, WALL_D, WALL_R, POWERUP }, new int[] { (int)TINY, 3 }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }) //row 10
							};
							returnData.hasCustomFunction = false;
							break;
						case 1:
							returnData.width = 9;
							returnData.height = 9;
							returnData.rooms = new List<Room>() {
								new Room(new [] { START, WALL_U, WALL_L, WALL_D }),
								new Room(new [] { EMPTY, WALL_U, SMALL_DOWN, SMALL_RIGHT }),
								new Room(new [] { EMPTY, CRAWL_LR }),
								new Room(new [] { EMPTY, SMALL_LEFT, WALL_U, WALL_D, SMALL_RIGHT }),
								new Room(new [] { EMPTY, CRAWL_LD }),
								new Room(new [] { POWERUP, WALL_U, CRAWL_UD }, new int[2] { (int)CROUCH, 3 }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }), //row 1
								new Room(new [] { WALL }),
								new Room(new [] { EMPTY, CRAWL_UD }),
								new Room(new [] { EMPTY, WALL_U, WALL_L }),
								new Room(new [] { EMPTY, WALL_U, WALL_D }),
								new Room(new [] { EMPTY, SMALL_DOWN, SMALL_UP, SMALL_RIGHT }),
								new Room(new [] { EMPTY, CRAWL_LU }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }), //row 2
								new Room(new [] { HIDDEN, WALL_U, WALL_L, WALL_R, KILL }),
								new Room(new [] { WALL_L, WALL_D, WALL_R, SMALL_UP, POWERUP }, new int[2] { (int)TINY, 3 }),
								new Room(new [] { EMPTY, WALL_L, WALL_R }),
								new Room(new [] { HIDDEN, TELEPORT, WALL_L, WALL_U, WALL_R }, 24),
								new Room(new [] { SMALL_UP, WALL_L, WALL_D, SPIKES }),
								new Room(new [] { WALL_U, WALL_R, WALL_D, POWERUP }, new int[2] { (int)KEY, 1 }),
								new Room(new [] { WALL_U, WALL_L, WALL_D, NULL_TELEPORT }),
								new Room(new [] { WALL_U, WALL_D, SPIKES }),
								new Room(new [] { WALL_U, WALL_R, CHEST }), //row 3
								new Room(new [] { WALL_L, WALL_D, EMPTY }),
								new Room(new [] { HIDDEN, PRESSURE_PLATE, WALL_U, WALL_R }, new int[] { 36, 37 }),
								new Room(new [] { EMPTY, WALL_L, WALL_D }),
								new Room(new [] { EMPTY }),
								new Room(new [] { HIDDEN, WALL_U, WALL_R, WALL_D, KILL }),
								new Room(new [] { EMPTY, WALL_L, WALL_U }),
								new Room(new [] { EMPTY, WALL_U, WALL_D }),
								new Room(new [] { EMPTY, WALL_U, WALL_R }),
								new Room(new [] { EMPTY, WALL_L, WALL_R }, new [] { EMPTY, WALL_L, WALL_R, WALL_D }, true), //row 4
								new Room(new [] { HIDDEN, WALL }, new [] { HIDDEN, EXIT, WALL_U, WALL_L, WALL_D }, true),
								new Room(new [] { EMPTY, WALL_L }, new [] { EMPTY }, true),
								new Room(new [] { EMPTY, WALL_U, WALL_R }),
								new Room(new [] { HIDDEN, WALL_L, WALL_D, WALL_R, KILL }),
								new Room(new [] { WALL }),
								new Room(new [] { EMPTY, WALL_L, WALL_R }),
								new Room(new [] { WALL }),
								new Room(new [] { SPIKE_WALL_L, SPIKE_WALL_D, PRESSURE_PLATE }, new [] { SPIKE_WALL_L, SPIKE_WALL_D, PRESSURE_PLATE, WALL_R }, true, new List<int>() { 43, 44, 35 }),
								new Room(new [] { EMPTY, WALL_R, WALL_D }, new [] { WALL }, true), //row 5
								new Room(new [] { WALL }),
								new Room(new [] { HIDDEN, WALL_L, WALL_D, WALL_R, PRESSURE_PLATE }, new int[] { 36, 37 }),
								new Room(new [] { EMPTY, WALL_L, WALL_D }),
								new Room(new [] { EMPTY, WALL_U, WALL_D }),
								new Room(new [] { SPIKE_WALL_U, WALL_D }, new int[2] { (int)COINS, 2 }),
								new Room(new [] { WALL_D }, new [] { WALL_D, POWERUP }, new int[2] { (int)LIFE, 1 }, false),
								new Room(new [] { HIDDEN, WALL_U, WALL_D, TELEPORT, SPIKE_WALL_R }, 60),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }), //row 6
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }, new [] { WALL }, true),
								new Room(new [] { WALL_U, WALL_L, WALL_R, TELEPORT }, 51),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }), //row 7
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL_U, WALL_L, WALL_D, HIDDEN, PRESSURE_PLATE }, new int[] { 50, 59 }),
								new Room(new [] { EMPTY }),
								new Room(new [] { HIDDEN, WALL_U, WALL_D, WALL_R, POWERUP }, new int[2] { (int)COINS, 50 }),
								new Room(new [] { WALL }), //row 8
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL_L, WALL_D, WALL_R, HIDDEN, POWERUP }, new int[2] { (int)TINY, 3 }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }) //row 9
							};
							returnData.hasCustomFunction = false;
							break;
						case 2:
							returnData.width = 6;
							returnData.height = 10;
							returnData.rooms = new List<Room>() {
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }), //row 1
								new Room(new [] { WALL }),
								new Room(new [] { WALL_L, WALL_U, EMPTY }),
								new Room(new [] { WALL_U, WALL_D, EMPTY }),
								new Room(new [] { WALL_U, WALL_D, EMPTY }),
								new Room(new [] { SPIKE_WALL_U, SPIKE_WALL_R, EMPTY }),
								new Room(new [] { WALL }), //row 2
								new Room(new [] { WALL }),
								new Room(new [] { WALL_L, WALL_R, EMPTY }), //originally had an "easy bossfight"
								new Room(new [] { WALL_U, WALL_L, WALL_D, POWERUP }, new int[2] { (int)COINS, 80 }),
								new Room(new [] { WALL_U, WALL_D, SPIKES, EMPTY }),
								new Room(new [] { WALL_R }),
								new Room(new [] { WALL }), //row 3
								new Room(new [] { WALL }),
								new Room(new [] { WALL_L, WALL_R, EMPTY }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL_L, WALL_U, WALL_R, TELEPORT }, 51),
								new Room(new [] { WALL_L, SPIKE_WALL_R, EMPTY }),
								new Room(new [] { WALL }), //row 4
								new Room(new [] { WALL_L, WALL_U, EMPTY, WAY1OUTR }),
								new Room(new [] { WALL_R, EMPTY, WAY1INL, WAY1IND }),
								new Room(new [] { HIDDEN, WALL_U, WALL_L, WALL_D, KILL }),
								new Room(new [] { EMPTY }),
								new Room(new [] { NULL_TELEPORT, WALL_R, WALL_D }),
								new Room(new [] { WALL }), //row 5
								new Room(new [] { WALL_L, WALL_R, EMPTY }), //originally called you a loser for taking the pussy route
								new Room(new [] { WALL_L, WALL_R, HIDDEN, WAY1OUTU }), //originally had a "hard bossfight"
								new Room(new [] { WALL_L, WALL_U, WALL_D, START }),
								new Room(new [] { EMPTY, SMALL_RIGHT, SMALL_DOWN }),
								new Room(new [] { CRAWL_LD, HIDDEN }),
								new Room(new [] { WALL }), //row 6
								new Room(new [] { WALL_L, WALL_R, EMPTY }),
								new Room(new [] { WALL_L, WALL_R, WAY1IND, POWERUP }, new int[2] { (int)COINS, 4 }),
								new Room(new [] { WALL_L, WALL_U, WALL_R, HIDDEN, POWERUP }, new int[2] { (int)COINS, 50 }),
								new Room(new [] { HIDDEN, CRAWL_UD }),
								new Room(new [] { WALL_L, WALL_R, HIDDEN, POWERUP }, new int[2] { (int)COINS, 2 }),
								new Room(new [] { WALL }), //row 7
								new Room(new [] { WALL_L, WALL_D, EMPTY, WAY1INR }),
								new Room(new [] { WAY1OUTL, WAY1OUTU, WALL_D, WALL_R, EXIT }),
								new Room(new [] { WALL_L, WALL_D, POWERUP }, new int[2] { (int)COINS, 10 }),
								new Room(new [] { EMPTY, WALL_R, WALL_D, SMALL_UP }),
								new Room(new [] { HIDDEN, TELEPORT, WALL_L, WALL_D, WALL_R }, 28),
								new Room(new [] { WALL }), //row 8
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL_L, WALL_R, WALL_U, NULL_TELEPORT }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }), //row 9              MISSING ROOM BETWEEN ROW 9 AND 10
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL_L, WALL_D, WALL_R, KILL, HIDDEN }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }) //row 10
							};
							returnData.hasCustomFunction = false;
							break;
						case 3:
							returnData.width = 9;
							returnData.height = 11;
							returnData.rooms = new List<Room>() {
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }), //row 0
								new Room(new [] { WALL }),
								new Room(new [] { WALL_U, WALL_L, WALL_D, START, WAY1INR }),
								new Room(new [] { WALL_U, WAY1OUTL, WAY1INR, EMPTY }),
								new Room(new [] { WAY1OUTL, WALL_U, WALL_D, EMPTY}, new [] { WAY1INL, WALL_U, WALL_D, EMPTY, WALL_R }, true),
								new Room(new [] { WALL_U, EMPTY, WAY1OUTR}, new [] { WALL_U, WALL_L, WALL_D, EMPTY, WAY1OUTR }, true),
								new Room(new [] { WALL_U, EMPTY, WALL_R, WAY1INL, WAY1IND }),
								new Room(new [] { WALL_U, WALL_L, SPIKE_WALL_R, SPIKE_WALL_D, NULL_TELEPORT }),
								new Room(new [] { SPIKE_WALL_L, SPIKE_WALL_D, WALL_U, WALL_R, NULL_TELEPORT }),
								new Room(new [] { WALL }), //row 1
								new Room(new [] { WALL }),
								new Room(new [] { HIDDEN, WALL_L, WALL_U, WALL_D, WAY1OUTR, TELEPORT }, 66),
								new Room(new [] { WAY1INL, WAY1IND, WALL_R, EMPTY }),
								new Room(new [] { WALL_L, WALL_U, HIDDEN, WALL_R, WAY1OUTD, POWERUP }, new int[2] { (int)COINS, 10 }),
								new Room(new [] { WALL_L, WALL_D, HIDDEN, PRESSURE_PLATE, WAY1INR }, new [] { WALL_L, WALL_D, HIDDEN, PRESSURE_PLATE, WAY1OUTR, WALL_U }, true),
								new Room(new [] { WAY1OUTL, WAY1OUTU, WALL_R, WALL_D, EMPTY }),
								new Room(new [] { WALL_L, WALL_D, SPIKE_WALL_U, SPIKE_WALL_R, NULL_TELEPORT }),
								new Room(new [] { WALL_D, WALL_R, SPIKE_WALL_L, SPIKE_WALL_U, NULL_TELEPORT }),
								new Room(new [] { WALL }), //row 2
								new Room(new [] { WALL }),
								new Room(new [] { HIDDEN, WALL_L, WALL_U, WALL_D, TELEPORT, WAY1OUTR }, 15),
								new Room(new [] { EMPTY, WAY1INL, WAY1INR, WAY1OUTU, WAY1OUTD }),
								new Room(new [] { EMPTY, WAY1OUTL, WAY1INR, WAY1INU }),
								new Room(new [] { HIDDEN, WAY1OUTL, WAY1INR, WALL_U, WALL_D, POWERUP }, new int[2] { (int)TINY, 3 }),
								new Room(new [] { EMPTY, WAY1OUTL, WALL_R, WALL_U }),
								new Room(new [] { TELEPORT, WALL_L, WALL_R, WALL_U, WAY1OUTD }, 25),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }), //row 3
								new Room(new [] { WALL }),
								new Room(new [] { HIDDEN, WALL_L, WAY1OUTR, WALL_U, WAY1IND }), //originally had a "Monster Fight"
								new Room(new [] { EMPTY, WAY1INL, WALL_R, WAY1INU }),
								new Room(new [] { EMPTY, WALL_L, WALL_D }),
								new Room(new [] { EMPTY, WALL_U }),
								new Room(new [] { EMPTY, WALL_R, WALL_D }, new [] { EMPTY, WALL_D }, true),
								new Room(new [] { EMPTY, WALL_L, WAY1INU}, new [] { EMPTY, WAY1INU }, true),
								new Room(new [] { EMPTY, WALL_R, SPIKE_WALL_U }),
								new Room(new [] { WALL }), //row 4
								new Room(new [] { WALL }),
								new Room(new [] { HIDDEN, POWERUP, WALL_L, WALL_R, WAY1OUTU, WAY1IND }, new int[2] { (int)LIFE, 1 }),
								new Room(new [] { PRESSURE_PLATE, WALL_L, WALL_D }), //originally this pressure plate was labeled as 'secret', but uh... if there was a secret, I forgot what it was years ago. I'll put it here anyway to fuck with the players mind :p
								new Room(new [] { EMPTY, WALL_R, WALL_U, WAY1OUTD }),
								new Room(new [] { EMPTY, WALL_L }),
								new Room(new [] { HIDDEN, PRESSURE_PLATE, WALL_R, WALL_U, WALL_D }, new int[] { 41, 42 }),
								new Room(new [] { HIDDEN, TELEPORT, WALL_L, WALL_R, WALL_U }, 16),
								new Room(new [] { EMPTY, WALL_L, WALL_R }),
								new Room(new [] { WALL }), //row 5
								new Room(new [] { WALL }),
								new Room(new [] { EMPTY, WALL_L, WAY1OUTU, WALL_D }),
								new Room(new [] { EMPTY, WALL_U, SPIKE_WALL_D }),
								new Room(new [] { EMPTY, WAY1INU, WALL_D }),
								new Room(new [] { EMPTY, WALL_R, WAY1OUTD }),
								new Room(new [] { EMPTY, WALL_L, WALL_U }),
								new Room(new [] { EMPTY }),
								new Room(new [] { EMPTY, WALL_R, WALL_D }),
								new Room(new [] { WALL }), //row 6
								new Room(new [] { WALL }),
								new Room(new [] { EXIT, WALL_L, WALL_R, WALL_U, WALL_D }, new [] { EXIT, WALL_L, WALL_R, WALL_U }, false),
								new Room(new [] { WALL }),
								new Room(new [] { HIDDEN, NULL_TELEPORT, WALL_L, WAY1INR, WALL_U, WALL_D }),
								new Room(new [] { HIDDEN, POWERUP, WAY1OUTL, WALL_R, WAY1INU, WALL_D }, new int[2] { (int)LIFE, 1 }),
								new Room(new [] { HIDDEN, WALL_L, WALL_R }), //also originally had a monster fight
								new Room(new [] { HIDDEN, POWERUP, WALL_L, WALL_R, WALL_D }, new int[2] { (int)COINS, 2 }),
								new Room(new [] { TELEPORT, WALL_L, WALL_R, WALL_U }, 24),
								new Room(new [] { WALL }), //row 7
								new Room(new [] { WALL }),
								new Room(new [] { EMPTY, WALL_L, WALL_U, WAY1OUTD }, new [] { EMPTY, WALL_L, WAY1OUTD }, false), //originally had a "retry clock" based off of the retry clock from Mario & Luigi: Bowser's Inside Story, it functioned the same way
								new Room(new [] { PRESSURE_PLATE, WALL_R, WALL_U, WALL_D }, new int[] { 64, 73 }), //originally had a boss fight, but now it's just a pressure_plate :/
								new Room(new [] { EMPTY, WALL_L, WAY1OUTR, WALL_U, WAY1IND }),
								new Room(new [] { EMPTY, WAY1INL, WALL_U }),
								new Room(new [] { EMPTY, WAY1IND }),
								new Room(new [] { EMPTY, WAY1INR, WALL_U, WAY1IND }),
								new Room(new [] { HIDDEN, EMPTY, WAY1OUTL, WALL_R, WALL_D }),
								new Room(new [] { WALL }), //row 8
								new Room(new [] { WALL }),
								new Room(new [] { EMPTY, WALL_L, WAY1OUTR, WAY1INU, WALL_D }),
								new Room(new [] { EMPTY, WAY1INL, WAY1OUTR, WALL_U, WALL_D }),
								new Room(new [] { EMPTY, WAY1INL, WALL_R, WAY1OUTU, WALL_D }),
								new Room(new [] { HIDDEN, KILL, WALL_L, WALL_R, WALL_D }),
								new Room(new [] { HIDDEN, KILL, WALL_L, WALL_R, WAY1OUTU, WALL_D }),
								new Room(new [] { EMPTY, WALL_L, WAY1OUTU, WALL_D }), //originally had another one of those 'lol' rooms that would call you a loser
								new Room(new [] { KILL, WALL_R, WALL_U, WALL_D }),
								new Room(new [] { WALL }), //row 9
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }) //row 10
							};
							returnData.hasCustomFunction = false;
							break;
						case 4:
							returnData.width = 8;
							returnData.height = 8;
							returnData.extraData = new Extra(new List<bool>() { true, false, false });
							returnData.rooms = new List<Room>() {
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }), //row 0
								new Room(new [] { WALL }),
								new Room(new [] { EMPTY, WALL_L, WALL_U }),
								new Room(new [] { EMPTY, WALL_U, WALL_D }),
								new Room(new [] { EMPTY, WALL_U }),
								new Room(new [] { EMPTY, WAY1OUTR, WALL_U }),
								new Room(new [] { START, WAY1INL, WALL_R, WALL_U, WALL_D }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }), //row 1
								new Room(new [] { WALL }),
								new Room(new [] { EMPTY, WALL_L, WALL_R }),
								new Room(new [] { WALL }),
								new Room(new [] { EMPTY, SPIKE_WALL_L, WALL_R }),
								new Room(new [] { HIDDEN, WALL_L, WALL_R, WALL_D, UBER }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }), //row 2
								new Room(new [] { WALL }),
								new Room(new [] { EMPTY, WALL_L, WALL_D }),
								new Room(new [] { EMPTY, WALL_R, WALL_U }),
								new Room(new [] { EMPTY, WALL_L, WALL_D }),
								new Room(new [] { EMPTY, WAY1INR, WALL_U, WAY1IND }),
								new Room(new [] { EMPTY, WAY1OUTL, WALL_R, WALL_U }),
								new Room(new [] { PRESSURE_PLATE, WALL_L, WALL_R, WALL_U }, new Special(2)),
								new Room(new [] { WALL }), //row 3
								new Room(new [] { WALL }),
								new Room(new [] { PRESSURE_PLATE, WALL_L, WALL_R, WALL_U }, new [] { PRESSURE_PLATE, WALL_L, WALL_R, WALL_U, WALL_D }, true, new List<int>() { 33, 41, 49 }),
								new Room(new [] { EMPTY, WALL_L, SPIKE_WALL_R }),
								new Room(new [] { WALL }),
								new Room(new [] { HIDDEN, WALL_L, WALL_R, WAY1OUTU, WALL_D, KILL }),
								new Room(new [] { EMPTY, WALL_L, WALL_D }, new [] { EMPTY, WALL_L }, true),
								new Room(new [] { WALL_R, WALL_D }),
								new Room(new [] { WALL }), //row 4
								new Room(new [] { WALL }),
								new Room(new [] { PRESSURE_PLATE, WALL_L, WALL_R }, new [] { WALL }, new Special(1), true),
								new Room(new [] { EMPTY, WALL_L, SPIKE_WALL_R }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }, new [] { EMPTY, SPIKE_WALL_L, WALL_R }, true),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }), //row 5
								new Room(new [] { WALL }),
								new Room(new [] { EMPTY, WALL_L, WALL_D }, new [] { EMPTY, WALL_L, WALL_U, WALL_D }, true),
								new Room(new [] { EMPTY, WALL_D }),
								new Room(new [] { PRESSURE_PLATE, SPIKE_WALL_R, SPIKE_WALL_U, WALL_D }, new int[] { 33, 41, 49 }),
								new Room(new [] { WALL }),
								new Room(new [] { EXIT, WALL_L, WALL_R, WALL_U, WALL_D }, new [] { EXIT, WALL_L, WALL_R, WALL_D }, true),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }), //row 6
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }),
								new Room(new [] { WALL }) //row 7
							};
							returnData.hasCustomFunction = true;
							returnData.customFunction = 0;
							break;
					}
					break;
			}
			if (returnData.width == 0)
				Program.error = true;
			return returnData;
		}

		public static void CustomLevelFunction(Level currentLevel) {
			switch (currentLevel.customFunction) {
				case 0:
					if (currentLevel.extraData.extraBool[1] && currentLevel.extraData.extraBool[2]) {
						currentLevel.rooms[37].Activate();
						currentLevel.rooms[45].Activate();
						currentLevel.rooms[53].Activate();
						currentLevel.extraData.extraBool[1] = false;
						currentLevel.extraData.extraBool[2] = false;
					}
					break;
			}
		}
	}
}
