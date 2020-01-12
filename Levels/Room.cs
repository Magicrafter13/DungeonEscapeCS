using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonEscapeCS.Levels {
	class Room {
		private readonly List<Level.RoomItems> dObjects;

		private readonly List<Level.RoomItems> dBeforeActivation, dAfterActivation;

		private readonly int[] dPowerup = new int[2];

		public List<Level.RoomItems> objects;

		public int activatesRoom;

		public List<Level.RoomItems> beforeActivation;

		public List<Level.RoomItems> afterActivation;

		public bool hasBeforeAndAfter = false;

		public string currentObjectSet = "before";

		public int teleportTo;

		public int[] powerup = new int[2];

		public bool activatesMultiple;

		public List<int> roomsActivated;

		public bool hasSpecial = false;

		public Special specialData = new Special(0);

		public void Reset() {
			objects = dObjects;
			beforeActivation = dBeforeActivation;
			afterActivation = dAfterActivation;
			currentObjectSet = "before";
			powerup[0] = dPowerup[0]; powerup[1] = dPowerup[1];
		}

		public bool HasObject(Level.RoomItems obj) {
			return objects.Contains(obj);
		}

		public bool HasObjectsAnd(List<Level.RoomItems> obj) {
			bool itDoes = true;
			for (int i = 0; i < obj.Count; i++)
				if (!HasObject(obj[i]))
					itDoes = false;
			return itDoes;
		}

		public bool HasObjectsOr(List<Level.RoomItems> obj) {
			bool hasOne = false;
			for (int i = 0; i < obj.Count; i++)
				if (HasObject(obj[i]))
					hasOne = true;
			return hasOne;
		}

		public void Activate() {
			if (hasBeforeAndAfter) {
				if (currentObjectSet == "before")
					objects = afterActivation;
				else if (currentObjectSet == "after")
					objects = beforeActivation;
				else {
					Program.errorCode = "rm_chng_obj-set";
					Program.errorMessage = "Could not determinte which object\nset the room needed.";
					Program.error = true;
				}
				currentObjectSet = currentObjectSet == "before" ? "after" : "before";
			} else {
				if (currentObjectSet == "before") {
					currentObjectSet = "after";
					objects = afterActivation;
				}
			}
		}

		public void AddObject(Level.RoomItems obj) {
			objects.Add(obj);
		}

		public void RemoveObject(Level.RoomItems obj) {
			List<Level.RoomItems> tempObjects = objects;
			objects.Clear();
			for (int i = 0; i < tempObjects.Count; i++)
				if (tempObjects[i] != obj)
					objects.Add(tempObjects[i]);
		}

		public Room(IEnumerable<Level.RoomItems> fObjects) {
			objects = fObjects.ToList();
			dObjects = fObjects.ToList();
		}

		public Room(IEnumerable<Level.RoomItems> fObjects, int linked) {
			objects = fObjects.ToList();
			dObjects = fObjects.ToList();
			if (objects.Contains(Level.RoomItems.TELEPORT))
				teleportTo = linked;
			if (objects.Contains(Level.RoomItems.PRESSURE_PLATE)) {
				activatesRoom = linked;
				activatesMultiple = false;
			}
		}

		public Room(IEnumerable<Level.RoomItems> fObjectsB, IEnumerable<Level.RoomItems> fObjectsA, bool hbaa) {
			objects = fObjectsB.ToList();
			dObjects = fObjectsB.ToList();
			beforeActivation = fObjectsB.ToList();
			dBeforeActivation = fObjectsB.ToList();
			afterActivation = fObjectsA.ToList();
			dAfterActivation = fObjectsA.ToList();
			hasBeforeAndAfter = hbaa;
			activatesMultiple = false;
		}
		
		public Room(IEnumerable<Level.RoomItems> fObjects, int[] powerups) {
			objects = fObjects.ToList();
			dObjects = fObjects.ToList();
			powerup[0] = powerups[0];
			dPowerup[0] = powerups[0];
			powerup[1] = powerups[1];
			dPowerup[1] = powerups[1];
		}

		public Room(IEnumerable<Level.RoomItems> fObjects, List<int> roomsToActivate) {
			activatesMultiple = true;
			roomsActivated = roomsToActivate;
			objects = fObjects.ToList();
			dObjects = fObjects.ToList();
		}

		public Room(IEnumerable<Level.RoomItems> fObjectsB, IEnumerable<Level.RoomItems> fObjectsA, bool hbaa, List<int> roomsToActivate) {
			objects = fObjectsB.ToList();
			dObjects = fObjectsB.ToList();
			beforeActivation = fObjectsB.ToList();
			dBeforeActivation = fObjectsB.ToList();
			afterActivation = fObjectsA.ToList();
			dAfterActivation = fObjectsA.ToList();
			hasBeforeAndAfter = hbaa;
			activatesMultiple = true;
			roomsActivated = roomsToActivate;
		}

		public Room(IEnumerable<Level.RoomItems> fObjectsB, IEnumerable<Level.RoomItems> fObjectsA, int[] powerups, bool hbaa) {
			objects = fObjectsB.ToList();
			dObjects = fObjectsB.ToList();
			beforeActivation = fObjectsB.ToList();
			dBeforeActivation = fObjectsB.ToList();
			afterActivation = fObjectsA.ToList();
			dAfterActivation = fObjectsA.ToList();
			hasBeforeAndAfter = hbaa;
			activatesMultiple = false;
			powerup[0] = powerups[0];
			dPowerup[0] = powerups[0];
			powerup[1] = powerups[1];
			dPowerup[1] = powerups[1];
		}

		public Room(IEnumerable<Level.RoomItems> fObjects, Special fSpecial) {
			objects = fObjects.ToList();
			dObjects = fObjects.ToList();
			specialData = fSpecial;
			hasSpecial = true;
		}

		public Room(IEnumerable<Level.RoomItems> fObjectsA, IEnumerable<Level.RoomItems> fObjectsB, Special fSpecial, bool hbaa) {
			objects = fObjectsA.ToList();
			dObjects = fObjectsA.ToList();
			beforeActivation = fObjectsA.ToList();
			dBeforeActivation = fObjectsA.ToList();
			afterActivation = fObjectsB.ToList();
			dAfterActivation = fObjectsB.ToList();
			hasBeforeAndAfter = hbaa;
			activatesMultiple = false;
			specialData = fSpecial;
			hasSpecial = true;
		}
	}
}
