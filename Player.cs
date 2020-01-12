using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonEscapeCS {
	class Player {
		private readonly int defaultX, defaultY;

		private readonly int defaultLocation;

		private readonly System.Drawing.Image defaultTexture;

		public int coins = 0;

		public int keys = 0;

		public int x, y;

		public System.Drawing.Image texture;

		public int location;

		public bool isTiny = false;

		public List<int> objects;

		public List<int> inventory = new List<int>() {
			0, //TINY/SMALL
			0, //CRAWL - Probably change to an "invincibility" powerup
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0
		};

		public bool enteredSmall = false;

		public int lives = 3;

		public List<bool> hiddenMap = new List<bool>();

		public bool forceU, forceD, forceL, forceR;

		public void ResetForce() {
			forceU = false;
			forceD = false;
			forceL = false;
			forceR = false;
		}

		public void Reset() {
			x = defaultX;
			y = defaultY;
			texture = defaultTexture;
			location = defaultLocation;
			isTiny = false;
			for (int i = 0; i < inventory.Count; i++)
				inventory[i] = 0;
			for (int i = 0; i < hiddenMap.Count; i++)
				hiddenMap[i] = true;
			enteredSmall = false;
			lives = 3;
			ResetForce();
		}

		public void AddObject(int obj) {
			List<int> tempObjects = objects;
			objects.Clear();
			for (int i = 0; i < tempObjects.Count; i++)
				if (tempObjects[i] != obj)
					objects.Add(obj);
		}

		public void RemoveObject(int obj) {
			List<int> tempObjects = objects;
			objects.Clear();
			for (int i = 0; i < tempObjects.Count; i++)
				if (tempObjects[i] != obj)
					objects.Add(obj);
		}

		public bool HasObject(int obj) {
			return objects.Contains(obj);
		}

		public void AddInventory(int[] obj) {
			inventory[obj[0]] += obj[1];
		}

		public Player(int fx, int fy, System.Drawing.Image ftexture) {
			x = fx; defaultX = fx;
			y = fy; defaultY = fy;
			texture = ftexture; defaultTexture = ftexture;
			location = 0; defaultLocation = 0;
		}
	}
}
