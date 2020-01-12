using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonEscapeCS.Levels;
using static DungeonEscapeCS.Levels.Level.RoomItems;

namespace DungeonEscapeCS {
	class Game {
		private int eventHandler;

		private bool gameRunning;

		private int tRoom;

		private int relX, relY;

		public bool paused, inventory, debug;

		//public char kHeld = '0';

		public static int[,] pauseArrow = new int[2, 4] {
			{ 60, 60, 49, 63 },
			{ 48, 93, 138, 183 },
		};

		public int pausedSelection = 0;

		public int inventorySelection = 0;

		public string pausedLevel = "top";

		private static System.Drawing.Image[] nxx = {
			Properties.Resources._0xx, Properties.Resources._1xx, Properties.Resources._2xx, Properties.Resources._3xx, Properties.Resources._4xx, Properties.Resources._5xx, Properties.Resources._6xx, Properties.Resources._7xx, Properties.Resources._8xx, Properties.Resources._9xx
		};

		private static System.Drawing.Image[] xnx = {
			Properties.Resources.x0x, Properties.Resources.x1x, Properties.Resources.x2x, Properties.Resources.x3x, Properties.Resources.x4x, Properties.Resources.x5x, Properties.Resources.x6x, Properties.Resources.x7x, Properties.Resources.x8x, Properties.Resources.x9x
		};

		private static System.Drawing.Image[] xxn = {
			Properties.Resources.xx0, Properties.Resources.xx1, Properties.Resources.xx2, Properties.Resources.xx3, Properties.Resources.xx4, Properties.Resources.xx5, Properties.Resources.xx6, Properties.Resources.xx7, Properties.Resources.xx8, Properties.Resources.xx9
		};

		private GameWindow form;

		private Level level;

		private Player player;

		public void PausedReturnLevel() {
			if (pausedLevel == "top") {
				paused = false;
				pausedSelection = 0;
			}
		}

		public int PausedAction(int action) {
			if (pausedLevel.Equals("top")) {
				if (action == 3)
					return 1;
				else {
					Program.error = true;
					Program.errorCode = "ps-act_top_act_invalid";
					Program.errorMessage = "Invalid pause menu action.";
					return 3;
				}
			} else {
				Program.error = true;
				Program.errorCode = "ps-act_lvl_invalid";
				Program.errorMessage = "Invalid pause menu level.";
				return 3;
			}
		}

		public void TryInventory(int selection) {
			Program.EchoDebug(true, "Testing available inventory.\n", debug);
			switch (selection) {
				case 0:
					if (player.inventory[0] > 0 && !player.isTiny) {
						player.inventory[0]--;
						player.isTiny = true;
					}
					break;
				default:
					if (player.inventory[selection] > 0)
						player.inventory[selection]--;
					break;
			}
		}


		public void RunGame(string action) {
			form.SetTopBlind(true);
			eventHandler = 0;
			tRoom = 0;

			for (int y = 0; y < level.height; y++) {
				for (int x = 0; x < level.width; x++) {
					relX = 2 - (player.x - x);
					relY = 1 - (player.y - y);
					if (relX >= 0 && relY >= 0 && relX <= level.width && relY <= level.height && !level.rooms[tRoom].HasObject(WALL) && !player.hiddenMap[tRoom])
						form.DrawTexture(Properties.Resources.floor, relX * 80, relY * 80);
					if (player.hiddenMap[tRoom]) {
						List<Level.RoomItems> itemArr = new List<Level.RoomItems>() {
							WALL_L, WALL_R, WALL_U, WALL_D, WALL,
							CRAWL_LR, CRAWL_UD, CRAWL_LU, CRAWL_LD, CRAWL_RU, CRAWL_RD,
							PRESSURE_PLATE,
							WAY1OUTL, WAY1OUTR, WAY1OUTU, WAY1OUTD,
							WAY1INL, WAY1INR, WAY1INU, WAY1IND,
							SPIKE_WALL_L, SPIKE_WALL_R, SPIKE_WALL_U, SPIKE_WALL_D,
							TELEPORT, NULL_TELEPORT,
							POWERUP, KILL, EXIT
						};
						for (int i = 0; i < itemArr.Count; i++) {
							if (level.rooms[tRoom].HasObject(itemArr[i])) {
								int posAddX = itemArr[i] == WALL_R ? 70 : 0;
								int posAddY = itemArr[i] == WALL_D ? 70 : 0;
								form.DrawTexture(Program.GetTex(itemArr[i]), relX * 80 + posAddX, relY * 80 + posAddY);
							}
						}
						if (level.rooms[tRoom].HasObject(WALL)) {
							if (level.rooms[tRoom].HasObjectsOr(new List<Level.RoomItems> { WALL_L, SPIKE_WALL_L })) {
								if (level.rooms[tRoom].HasObjectsOr(new List<Level.RoomItems> { WALL_U, SPIKE_WALL_U }))
									form.DrawTexture(Properties.Resources.wall_corner_lu, relX * 80, relY * 80);
								if (level.rooms[tRoom].HasObjectsOr(new List<Level.RoomItems> { WALL_D, SPIKE_WALL_D }))
									form.DrawTexture(Properties.Resources.wall_corner_ld, relX * 80, relY * 80 + 70);
							}
							if (level.rooms[tRoom].HasObjectsOr(new List<Level.RoomItems> { WALL_R, SPIKE_WALL_R })) {
								if (level.rooms[tRoom].HasObjectsOr(new List<Level.RoomItems> { WALL_U, SPIKE_WALL_U }))
									form.DrawTexture(Properties.Resources.wall_corner_ru, relX * 80 + 70, relY * 80);
								if (level.rooms[tRoom].HasObjectsOr(new List<Level.RoomItems> { WALL_D, SPIKE_WALL_D }))
									form.DrawTexture(Properties.Resources.wall_corner_rd, relX * 80 + 70, relY * 80 + 70);
							}
							if (level.rooms[tRoom].HasObject(WALL_L)) {
								if (level.rooms[tRoom].HasObject(WALL_U))
									form.DrawTexture(Properties.Resources.corner_lu, relX * 80 + 10, relY * 80 + 10);
								if (level.rooms[tRoom].HasObject(WALL_D))
									form.DrawTexture(Properties.Resources.corner_ld, relX * 80 + 10, relY * 80 + 60);
							}
							if (level.rooms[tRoom].HasObject(WALL_R)) {
								if (level.rooms[tRoom].HasObject(WALL_U))
									form.DrawTexture(Properties.Resources.corner_ru, relX * 80 + 60, relY * 80 + 10);
								if (level.rooms[tRoom].HasObject(WALL_D))
									form.DrawTexture(Properties.Resources.corner_rd, relX * 80 + 60, relY * 80 + 60);
							}
						}
						if (level.rooms[tRoom].HasObject(LOCK_L)) {
							form.DrawTexture(Properties.Resources.lock_l, 80 * relX, 80 * relY);
							form.DrawTexture(Properties.Resources.lock_r, 80 * (relX - 1), 80 * relY);
						}
						if (level.rooms[tRoom].HasObject(LOCK_R)) {
							form.DrawTexture(Properties.Resources.lock_r, 80 * relX, 80 * relY);
							form.DrawTexture(Properties.Resources.lock_l, 80 * (relX + 1), 80 * relY);
						}
						if (level.rooms[tRoom].HasObject(LOCK_U)) {
							form.DrawTexture(Properties.Resources.lock_u, 80 * relX, 80 * relY);
							form.DrawTexture(Properties.Resources.lock_d, 80 * relX, 80 * (relY - 1));
						}
						if (level.rooms[tRoom].HasObject(LOCK_D)) {
							form.DrawTexture(Properties.Resources.lock_d, 80 * relX, 80 * relY);
							form.DrawTexture(Properties.Resources.lock_u, 80 * relX, 80 * (relY + 1));
						}
					}
					if (level.rooms[tRoom].HasObject(WALL) && !player.hiddenMap[tRoom])
						form.DrawTexture(Properties.Resources.wall, 80 * relX, 80 * relY);
					tRoom++;
				}
			}
			tRoom = 0;
			for (int y = 0; y < level.height; y++) {
				for (int x = 0; x < level.width; x++) {
					int relX = 2 - (player.x - x);
					int relY = 1 - (player.y - y);
					if (player.hiddenMap[tRoom])
						form.DrawTexture(Properties.Resources.black_80x80, 80 * relX, 80 * relY);
					tRoom++;
				}
			}
			form.DrawTexture(player.isTiny ? Properties.Resources.player_tiny : Properties.Resources.player, 2 * 80, 1 * 80);
			if (paused) {
				form.DrawTexture(Properties.Resources.pausescreen, 100, 0);
				form.DrawTexture(Properties.Resources.cursor, pauseArrow[0, pausedSelection] + 100, pauseArrow[1, pausedSelection]);
			}
			if (inventory) {
				form.DrawTexture(Properties.Resources.inventory, 0, 0);
				int selector = 0;
				for (int y = 0; y < 4; y++) {
					for (int x = 0; x < 6; x++) {
						form.DrawTexture(Program.GetTex((Level.PowerupEnum)selector), x * 50, y * 50 + 40);
						if (selector == inventorySelection)
							form.DrawTexture(Properties.Resources.inventory_selector, x * 50, y * 50 + 40);
						if (player.inventory[selector] == 0)
							if (selector < 2)
								form.DrawTexture(Properties.Resources.none_left, x * 50, y * 50 + 40);
						selector++;
					}
				}
				List<int> sideValues = new List<int> { player.lives, player.coins, player.inventory[inventorySelection] };
				List<System.Drawing.Image> sideSprites = new List<System.Drawing.Image> { Properties.Resources.life_inv, Properties.Resources.coins_inv, null, Program.GetTex((Level.PowerupEnum)inventorySelection) };
				for (int counter = 0; counter < sideValues.Count; counter++) {
					if (counter != 2) {
						int first = sideValues[counter] / 100 % 10;
						int second = sideValues[counter] / 10 % 10;
						int third = sideValues[counter] % 10;
						form.DrawTexture(Properties.Resources.counter, 7 * 50, counter * 50 + 40);
						form.DrawTexture(nxx[sideValues[counter] / 100 % 10], 7 * 50, counter * 50 + 40);
						form.DrawTexture(xnx[sideValues[counter] / 10 % 10], 7 * 50, counter * 50 + 40);
						form.DrawTexture(xxn[sideValues[counter] % 10], 7 * 50, counter * 50 + 40);
						form.DrawTexture(sideSprites[counter], 6 * 50, counter * 50 + 40);
					}
				}
			}

			if (debug) {
				//draw to bottom screen
			}

			bool triggerKill = false;

			if (action.Equals("escape")) {
				if (!inventory) {
					paused = paused ? false : true;
					if (!paused) {
						pausedSelection = 0;
						pausedLevel = "top";
					}
					Program.EchoDebug(true, "Pause menu opened.\n", debug);
				}
			}

			bool hasMoved = false;
			bool invalidMove = false;

			if (paused) {
				if (action.Equals("up")) {
					pausedSelection--;
					if (pausedSelection == -1)
						pausedSelection = 3;
				} else
					if (action.Equals("down")) {
					pausedSelection++;
					if (pausedSelection == 4)
						pausedSelection = 0;
				} else
					if (action.Equals("enter")) {
					eventHandler = PausedAction(pausedSelection);
					Program.EchoDebug(true, "Pause Menu Option Selected\n", debug);
					Program.EchoDebug(false, $"PausedAction returned: {eventHandler.ToString()}\n", debug);
				} else
					if (action.Equals("backspace"))
					PausedReturnLevel();
				if (action.Equals("up") || action.Equals("down") || action.Equals("left") || action.Equals("right"))
					Program.EchoDebug(false, $"sel: {pausedSelection.ToString()}\n", debug);
			} else
				if (inventory) {
				if (action.Equals("backspace"))
					inventory = false;
				else if (action.Equals("up"))
					inventorySelection -= 6;
				else if (action.Equals("down"))
					inventorySelection += 6;
				else if (action.Equals("left"))
					inventorySelection--;
				else if (action.Equals("right"))
					inventorySelection++;
				else if (action.Equals("enter"))
					TryInventory(inventorySelection);
				if (inventorySelection <= -1)
					inventorySelection = 0;
				if (inventorySelection >= player.inventory.Count - 4)
					inventorySelection = player.inventory.Count - 5;
				if (action.Equals("up") || action.Equals("down") || action.Equals("left") || action.Equals("right"))
					Program.EchoDebug(false, $"sel: {inventorySelection.ToString()}\n", debug);
			} else {
				Room room = level.rooms[player.location];
				if (action.Equals("left")) {
					if (!room.HasObjectsOr(new List<Level.RoomItems> { WALL_L, CRAWL_UD, CRAWL_RU, CRAWL_RD, WAY1OUTL, LOCK_L })) {
						if (room.HasObject(SPIKE_WALL_L))
							triggerKill = true;
						if (room.HasObject(SMALL_LEFT)) {
							if (player.isTiny) {
								player.x--;
								player.location -= 1;
								hasMoved = true;
								player.enteredSmall = true;
							} else
								invalidMove = true;
						} else {
							player.x--;
							player.location -= 1;
							hasMoved = true;
						}
					} else
						invalidMove = true;
				} else
					if (action.Equals("right")) {
					if (!room.HasObjectsOr(new List<Level.RoomItems> { WALL_R, CRAWL_UD, CRAWL_LU, CRAWL_LD, WAY1OUTR, LOCK_R })) {
						if (room.HasObject(SPIKE_WALL_R))
							triggerKill = true;
						if (room.HasObject(SMALL_RIGHT)) {
							if (player.isTiny) {
								player.x++;
								player.location += 1;
								hasMoved = true;
								player.enteredSmall = true;
							} else
								invalidMove = true;
						} else {
							player.x++;
							player.location += 1;
							hasMoved = true;
						}
					} else
						invalidMove = true;
				} else
					if (action.Equals("up")) {
					if (!room.HasObjectsOr(new List<Level.RoomItems> { WALL_U, CRAWL_LR, CRAWL_LD, CRAWL_RD, WAY1OUTU, LOCK_U })) {
						if (room.HasObject(SPIKE_WALL_U))
							triggerKill = true;
						if (room.HasObject(SMALL_UP)) {
							if (player.isTiny) {
								player.y--;
								player.location -= level.width;
								hasMoved = true;
								player.enteredSmall = true;
							} else
								invalidMove = true;
						} else {
							player.y--;
							player.location -= level.width;
							hasMoved = true;
						}
					} else
						invalidMove = true;
				} else
					if (action.Equals("down")) {
					if (!room.HasObjectsOr(new List<Level.RoomItems> { WALL_D, CRAWL_LR, CRAWL_LU, CRAWL_RU, WAY1OUTD, LOCK_D })) {
						if (room.HasObject(SPIKE_WALL_D))
							triggerKill = true;
						if (room.HasObject(SMALL_DOWN)) {
							if (player.isTiny) {
								player.y++;
								player.location += level.width;
								hasMoved = true;
								player.enteredSmall = true;
							} else
								invalidMove = true;
						} else {
							player.y++;
							player.location += level.width;
							hasMoved = true;
						}
					} else
						invalidMove = true;
				} else
					if (action.Equals("debug_tiny")) {
					player.isTiny = player.isTiny ? false : true;
				} else
					if (action.Equals("inventory")) {
					inventory = true;
				}
				if (invalidMove) {
					//play sound
					Program.EchoDebug(true, "Invalid Move\n", debug);
				}
			}

			int location = player.location;
			player.hiddenMap[location] = false;
			if (location - level.width >= 0)
				if (!level.rooms[location].HasObjectsOr(new List<Level.RoomItems> { WALL_U, WAY1OUTU }) || level.rooms[location - level.width].HasObject(WALL))
					if (!level.rooms[location - level.width].HasObject(HIDDEN))
						player.hiddenMap[location - level.width] = false;
			if (location + level.width < level.rooms.Count)
				if (!level.rooms[location].HasObjectsOr(new List<Level.RoomItems> { WALL_D, WAY1OUTD }) || level.rooms[location + level.width].HasObject(WALL))
					if (!level.rooms[location + level.width].HasObject(HIDDEN))
						player.hiddenMap[location + level.width] = false;
			if (location - 1 >= 0)
				if (!level.rooms[location].HasObjectsOr(new List<Level.RoomItems> { WALL_L, WAY1OUTL }) || level.rooms[location - 1].HasObject(WALL))
					if (!level.rooms[location - 1].HasObject(HIDDEN))
						player.hiddenMap[location - 1] = false;
			if (location + 1 < level.rooms.Count)
				if (!level.rooms[location].HasObjectsOr(new List<Level.RoomItems> { WALL_R, WAY1OUTR }) || level.rooms[location + 1].HasObject(WALL))
					if (!level.rooms[location + 1].HasObject(HIDDEN))
						player.hiddenMap[location + 1] = false;

			int fo = player.forceU || player.forceD || player.forceL || player.forceR ? player.forceU || player.forceD ? player.forceU ? 1 : 2 : player.forceL ? 3 : 4 : 0;
			if (fo > 0) {
				if (level.rooms[player.location].HasObjectsOr(fo == 1 || fo == 2 ? fo == 1 ? new List<Level.RoomItems> { WALL_U, SMALL_UP, LOCK_U, WAY1OUTU } : new List<Level.RoomItems> { WALL_D, SMALL_DOWN, LOCK_D, WAY1OUTD } : fo == 3 ? new List<Level.RoomItems> { WALL_L, SMALL_LEFT, LOCK_L, WAY1OUTL } : new List<Level.RoomItems> { WALL_R, SMALL_RIGHT, LOCK_R, WAY1OUTR }))
					player.ResetForce();
				else {
					if (level.rooms[player.location].HasObject(fo == 1 || fo == 2 ? fo == 1 ? SPIKE_WALL_U : SPIKE_WALL_D : fo == 3 ? SPIKE_WALL_L : SPIKE_WALL_R))
						triggerKill = true;
					else {
						hasMoved = true;
						player.location += fo == 1 || fo == 2 ? fo == 1 ? -level.width : level.width : fo == 3 ? -1 : 1;
						player.x += fo == 3 || fo == 4 ? fo == 3 ? -1 : 1 : 0;
						player.y += fo == 1 || fo == 2 ? fo == 1 ? -1 : 1 : 0;
					}
				}
			}
			if (hasMoved) {
				Room room = level.rooms[player.location];
				Program.EchoDebug(false, "Objects:", debug);
				for (int i = 0; i < room.objects.Count; i++)
					Program.EchoDebug(false, $" {room.objects[i].ToString()}", debug);
				Program.EchoDebug(false, "\n", debug);
				if (room.HasObject(TELEPORT)) {
					Program.EchoDebug(true, "Teleportint Player From A to B\n", debug);
					Program.EchoDebug(false, $"A = {player.location.ToString()}\n", debug);
					int teleportTo = room.teleportTo;
					int tempPosition = -1;
					player.ResetForce();
					for (int y = 0; y < level.height; y++) {
						for (int x = 0; x < level.width; x++) {
							tempPosition++;
							if (tempPosition == teleportTo) {
								player.x = x;
								player.y = y;
								player.location = teleportTo;
							}
						}
					}
					Program.EchoDebug(false, $"B = {player.location.ToString()}\n", debug);
				}
				room = level.rooms[player.location];
				if (room.HasObject(PRESSURE_PLATE)) {
					Program.EchoDebug(true, "Pressure Plate activated\n", debug);
					if (room.hasSpecial) {
						Special specialData = room.specialData;
						Extra extraData = level.extraData;
						int varId = room.specialData.varId;
						Program.EchoDebug(true, "Room has Special Action\n", debug);
						Program.EchoDebug(false, $"Special Type: {room.specialData.type}\n", debug);
						if (specialData.type.Equals("bool")) {
							Program.EchoDebug(false, $"extraBool[{varId.ToString()}]\n From: {(extraData.extraBool[varId] ? "true" : "false")}\n", debug);
							extraData.extraBool[varId] = !extraData.extraBool[varId];
							Program.EchoDebug(false, $" To: {(extraData.extraBool[varId] ? "true" : "false")}\n", debug);
						}
						if (specialData.type.Equals("int")) {
							Program.EchoDebug(false, $"Action: {specialData.action}\n", debug);
							if (specialData.action == "add") {
								Program.EchoDebug(false, $"extraInt[{varId.ToString()}]\n From: {extraData.extraInt[varId].ToString()}\n", debug);
								extraData.extraInt[varId] += specialData.intValue;
								Program.EchoDebug(false, $" To: {extraData.extraInt[varId].ToString()}\n", debug);
							} else
								if (specialData.action.Equals("set")) {
								Program.EchoDebug(false, $"extraInt[{varId.ToString()}]\n From: {extraData.extraInt[varId].ToString()}\n", debug);
								extraData.extraInt[varId] = specialData.intValue;
								Program.EchoDebug(false, $" To: {extraData.extraInt[varId].ToString()}\n", debug);
							}
						}
						if (specialData.type.Equals("string")) {
							if (specialData.action == "add") {
								Program.EchoDebug(false, $"extraString[{varId.ToString()}]\n From: {extraData.extraString[varId]}\n", debug);
								extraData.extraInt[varId] += specialData.intValue;
								Program.EchoDebug(false, $" To: {extraData.extraInt[varId].ToString()}\n", debug);
							} else
								if (specialData.action.Equals("set")) {
								Program.EchoDebug(false, $"extraString[{varId.ToString()}]\n From: {extraData.extraString[varId]}\n", debug);
								extraData.extraInt[varId] = specialData.intValue;
								Program.EchoDebug(false, $" To: {extraData.extraInt[varId].ToString()}\n", debug);
							}
						}
					} else {
						if (room.activatesMultiple) {
							Program.EchoDebug(false, "Rooms:", debug);
							for (int i = 0; i < room.roomsActivated.Count; i++) {
								level.rooms[room.roomsActivated[i]].Activate();
								Program.EchoDebug(false, $" {room.roomsActivated[i].ToString()}", debug);
							}
						} else {
							level.rooms[room.activatesRoom].Activate();
							Program.EchoDebug(false, $"Room: {room.activatesRoom.ToString()}", debug);
						}
						Program.EchoDebug(false, "\n", debug);
					}
				}
				if (room.HasObject(POWERUP)) {
					player.AddInventory(room.powerup);
					Program.EchoDebug(true, "Powerup added\n", debug);
					Program.EchoDebug(false, $"Added {room.powerup[1].ToString()} of power-{room.powerup[0].ToString()}\n", debug);
					room.RemoveObject(POWERUP);
				}
				if (!room.HasObjectsOr(new List<Level.RoomItems> { CRAWL_4, CRAWL_LR, CRAWL_UD, CRAWL_LU, CRAWL_LD, CRAWL_RU, CRAWL_RD }) && player.enteredSmall) {
					player.enteredSmall = false;
					player.isTiny = false;
				}
				if (level.hasCustomFunction) {
					LevelData.CustomLevelFunction(level);
					Program.EchoDebug(true, $"Running Custom Function {level.customFunction.ToString()}\n", debug);
				}
				if (room.HasObjectsOr(new List<Level.RoomItems> { FORCE_U, FORCE_D, FORCE_L, FORCE_R })) {
					player.forceL = room.HasObject(FORCE_L);
					player.forceR = room.HasObject(FORCE_R);
					player.forceD = room.HasObject(FORCE_D);
					player.forceU = room.HasObject(FORCE_U);
					Program.EchoDebug(true, "Player forced in [D]irection\n", debug);
					Program.EchoDebug(false, $"D = {(player.forceL ? "Left" : player.forceR ? "Right" : player.forceU ? "Up" : "Down")}\n", debug);
				}
				if (player.inventory[24] > 0) {
					Program.EchoDebug(true, "Moving Lives\n", debug);
					Program.EchoDebug(false, $"Player had {player.inventory[24].ToString()}\nLives in Inv'", debug);
					player.lives += player.inventory[24];
					player.inventory[24] = 0;
				}
				if (player.inventory[25] > 0) {
					Program.EchoDebug(true, "Moving Coins\n", debug);
					Program.EchoDebug(false, $"Player had {player.inventory[25].ToString()}\nCoins in Inv'", debug);
					player.coins += player.inventory[25];
					player.inventory[25] = 0;
				}
				if (player.inventory[26] > 0) {
					Program.EchoDebug(true, "Moving Keys\n", debug);
					Program.EchoDebug(false, $"Player had {player.inventory[26].ToString()}\nKeys in Inv'", debug);
					player.keys += player.inventory[26];
					player.inventory[26] = 0;
				}
				if (room.HasObject(KILL) || triggerKill) {
					int lives = player.lives - 1;
					Program.EchoDebug(true, $"Lives Remaining: {lives.ToString()}\n", debug);
					List<int> inventory = player.inventory;
					player.Reset();
					player.lives = lives;
					player.inventory = inventory;
					int temp = 0, tempX = 0, tempY = 0;
					while (player.x == -1) {
						if (level.rooms[temp].HasObject(START)) {
							player.x = tempX;
							player.y = tempY;
							player.location = temp;
						} else {
							temp++;
							tempX++;
							if (tempX >= level.width) {
								tempX = 0;
								tempY++;
							}
						}
					}
				}
				if (room.HasObject(EXIT)) {
					int lives = player.lives;
					List<int> inventory = player.inventory;
					player.Reset();
					player.lives = lives;
					player.inventory = inventory;
					Program.lvl++;
					if (Program.lvl == Program.levelCount[Program.chapter]) {
						Program.lvl = 0;
						Program.chapter++;
						if (Program.chapter == Program.chapterCount) {
							//game win or whatever
							eventHandler = 1;
						}
					}
					level = LevelData.GetLevel(Program.chapter, Program.lvl);
					Program.EchoDebug(true, $"Loaded:\n    Chapter {Program.chapter.ToString()}\n    Level {Program.lvl.ToString()}\n", debug);
					int temp = 0, tempX = 0, tempY = 0;
					while (player.x == -1) {
						if (level.rooms[temp].HasObject(START)) {
							player.x = tempX;
							player.y = tempY;
							player.location = temp;
						} else {
							temp++;
							tempX++;
							if (tempX >= level.width) {
								tempX = 0;
								tempY++;
							}
						}
					}
					player.hiddenMap = new List<bool>(level.rooms.Count);
					for (int i = 0; i < level.rooms.Count; i++)
						player.hiddenMap[i] = true;
				}
			}

			location = player.location;
			player.hiddenMap[location] = false;

			if (player.lives <= 0)
				eventHandler = 1;

			if (Program.error)
				eventHandler = 2;

			switch (eventHandler) {
				case 0:
					break;
				case 1:
					Program.currentState = "main_menu";
					break;
				case 2:
					Program.currentState = "error";
					break;
				default:
					Program.currentState = "error";
					Program.error = true;
					Program.errorCode = "err_event-handler_unexpected_value";
					Program.errorMessage = "The game could not determine if the game should continue, game over, return to the main menu, or display the error screen. (Yes we are aware of the irony.)";
					break;
			}

			if (action.Equals("update"))
				form.SetTopBlind(false);
			else
				RunGame("update");
		}

		public Game(GameWindow form, Level level, Player player) {
			this.form = form;
			this.level = level;
			this.player = player;

			paused = false;
			inventory = false;
		}
	}
}
