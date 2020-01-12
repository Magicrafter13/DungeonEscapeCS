using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DungeonEscapeCS.Levels;

namespace DungeonEscapeCS {
	public partial class GameWindow : Form {
		private Game currentGame;

		public GameWindow() {
			InitializeComponent();

		}

		private void Title_Load(object sender, EventArgs e) {

		}

		private void StartButton_Click(object sender, EventArgs e) {
			Program.chapter = 0;
			Program.lvl = 0;
			Program.player1.Reset();
			Program.player1.texture = Properties.Resources.player;
			int temp = 0, tempX = 0, tempY = 0;
			Program.currentLevel = LevelData.GetLevel(0, 0);
			while (Program.player1.x == -1) {
				if (Program.currentLevel.rooms[temp].HasObject(Level.RoomItems.START)) {
					Program.player1.x = tempX;
					Program.player1.y = tempY;
					Program.player1.location = temp;
				} else {
					temp++;
					tempX++;
					if (tempX >= Program.currentLevel.width) {
						tempX = 0;
						tempY++;
					}
				}
			}
			int tempCount = Program.currentLevel.rooms.Count;
			Program.player1.hiddenMap = new List<bool>();
			for (int i = 0; i < Program.currentLevel.rooms.Count; i++)
				Program.player1.hiddenMap.Add(true);
			Program.player1.hiddenMap[Program.player1.location] = false;
			Program.currentState = "game_running";
			Program.bottomScreenText = 0;
			TitleImage.Visible = false;
			DebugButton.Visible = false;
			BottomScreenBlank.Visible = true;
			currentGame = new Game(this, Program.currentLevel, Program.player1) {
				paused = false,
				inventory = false,
				debug = Program.debug,
				pausedSelection = 0,
				inventorySelection = 0,
				pausedLevel = "top"
			};
			currentGame.RunGame(string.Empty);
		}

		private void DebugButton_Click(object sender, EventArgs e) {
			Program.debug = true;
		}

		private void keyisdown(object sender, KeyEventArgs e) {

		}

		private void keyisup(object sender, KeyEventArgs e) {

		}

		private void gameStartCheck_Tick(object sender, EventArgs e) {

		}

		public void DrawTexture(Image texture, int x, int y) {
			Graphics g = CreateGraphics();
			g.DrawImageUnscaled(texture, x, y);
		}

		public void SetTopBlind(bool set) {
			/*topScreenBlock.Visible = set;
			if (set)
				topScreenBlock.BringToFront();
			else
				topScreenBlock.SendToBack();*/
			//Update();
		}

		private void StartButton_KeyDown(object sender, KeyEventArgs e) {
			
		}

		private void StartButton_KeyUp(object sender, KeyEventArgs e) {
			if (currentGame != null) {
				switch (e.KeyCode) {
					case Keys.Escape:
						currentGame.RunGame("escape");
						break;
					case Keys.Back:
						currentGame.RunGame("backspace");
						break;
					case Keys.I:
						currentGame.RunGame("inventory");
						break;
					case Keys.Enter:
						currentGame.RunGame("enter");
						break;
					case (Keys.Shift & Keys.Left) | Keys.Left:
						currentGame.RunGame("left");
						break;
					case (Keys.Shift & Keys.Right) | Keys.Right:
						currentGame.RunGame("right");
						break;
					case (Keys.Shift & Keys.Up) | Keys.Up:
						currentGame.RunGame("up");
						break;
					case (Keys.Shift & Keys.Down) | Keys.Down:
						currentGame.RunGame("down");
						break;
				}
			}
		}
	}
}
