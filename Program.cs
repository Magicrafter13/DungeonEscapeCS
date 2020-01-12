using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DungeonEscapeCS.Levels;

namespace DungeonEscapeCS {
	static class Program {
		public const string buildNumber = "18.12.21.2355";

		public const int chapterCount = 1;

		public static string currentState = "menu";

		public static string errorCode = string.Empty, errorMessage = string.Empty;

		public static List<string> debugLog = new List<string>() {
			"Debugger started:\n",
			string.Empty,
		};

		public static bool error = false, debug = false, updateDebugScreen = true;

		public static List<int> ps_arrow = new List<int>(4);

		public static Level currentLevel = LevelData.GetLevel(0, 0);

		public static Player player1 = new Player(-1, -1, Properties.Resources.player);

		public static int lvl = 0;

		public static int chapter = 0;

		public enum Consoles : int {
			BottomScreen = 0,
			DebugBox = 1,
		};

		public static int CurrentConsole = 0;

		public static int[] levelCount = new int[8] {
			8,
			0,
			0,
			0,
			0,
			0,
			0,
			0
		};

		public static int bottomScreenText;

		public static void WriteConsole(string text) {
			//do stuff
		}

		public static void EchoDebug(bool mainWindow, string output, bool debuggerIsActive) {
			if (debuggerIsActive) {
				CurrentConsole = (int)(mainWindow ? Consoles.BottomScreen : Consoles.DebugBox);
				WriteConsole(output);
				debugLog[mainWindow ? 0 : 1] += output;
			}
		}

		public static System.Drawing.Image GetTex(Level.RoomItems item) {
			switch (item) {
				case Level.RoomItems.WALL:
					return Properties.Resources.wall;
				case Level.RoomItems.KILL:
					return Properties.Resources.kill;
				case Level.RoomItems.WAY1INL:
					return Properties.Resources.way1inl;
				case Level.RoomItems.WAY1INR:
					return Properties.Resources.way1inr;
				case Level.RoomItems.WAY1INU:
					return Properties.Resources.way1inu;
				case Level.RoomItems.WAY1IND:
					return Properties.Resources.way1ind;
				case Level.RoomItems.WAY1OUTL:
					return Properties.Resources.way1outl;
				case Level.RoomItems.WAY1OUTR:
					return Properties.Resources.way1outr;
				case Level.RoomItems.WAY1OUTU:
					return Properties.Resources.way1outu;
				case Level.RoomItems.WAY1OUTD:
					return Properties.Resources.way1outd;
				case Level.RoomItems.WALL_L:
					return Properties.Resources.wall_l;
				case Level.RoomItems.WALL_R:
					return Properties.Resources.wall_r;
				case Level.RoomItems.WALL_U:
					return Properties.Resources.wall_u;
				case Level.RoomItems.WALL_D:
					return Properties.Resources.wall_d;
				case Level.RoomItems.CRAWL_4:
					return Properties.Resources.crawl_4;
				case Level.RoomItems.CRAWL_LR:
					return Properties.Resources.crawl_lr;
				case Level.RoomItems.CRAWL_UD:
					return Properties.Resources.crawl_ud;
				case Level.RoomItems.CRAWL_LU:
					return Properties.Resources.crawl_lu;
				case Level.RoomItems.CRAWL_LD:
					return Properties.Resources.crawl_ld;
				case Level.RoomItems.CRAWL_RU:
					return Properties.Resources.crawl_ru;
				case Level.RoomItems.CRAWL_RD:
					return Properties.Resources.crawl_rd;
				case Level.RoomItems.LOCK_L:
					return Properties.Resources.lock_l;
				case Level.RoomItems.LOCK_R:
					return Properties.Resources.lock_r;
				case Level.RoomItems.LOCK_U:
					return Properties.Resources.lock_u;
				case Level.RoomItems.LOCK_D:
					return Properties.Resources.lock_d;
				case Level.RoomItems.PRESSURE_PLATE:
					return Properties.Resources.pressure_plate;
				case Level.RoomItems.TELEPORT:
				case Level.RoomItems.NULL_TELEPORT:
					return Properties.Resources.teleport;
				case Level.RoomItems.EXIT:
					return Properties.Resources.exit;
				case Level.RoomItems.POWERUP:
					return Properties.Resources.temp_powerup;
				case Level.RoomItems.HIDDEN:
					return Properties.Resources.black_80x80;
				case Level.RoomItems.SPIKE_WALL_L:
					return Properties.Resources.spike_wall_l;
				case Level.RoomItems.SPIKE_WALL_R:
					return Properties.Resources.spike_wall_r;
				case Level.RoomItems.SPIKE_WALL_U:
					return Properties.Resources.spike_wall_u;
				case Level.RoomItems.SPIKE_WALL_D:
					return Properties.Resources.spike_wall_d;
				default:
					return Properties.Resources.error_50x50;
			}
		}

		public static System.Drawing.Image GetTex(Level.PowerupEnum item) {
			switch (item) {
				case Level.PowerupEnum.TINY:
					return Properties.Resources.small_inv;
				case Level.PowerupEnum.CROUCH:
					return Properties.Resources.invincible_inv;
				default:
					return Properties.Resources.error_50x50;
			}
		}
		
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]

		static void Main() {
			bottomScreenText = 0;
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new GameWindow());
		}
	}
}
