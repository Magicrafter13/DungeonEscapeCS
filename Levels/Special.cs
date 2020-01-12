using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonEscapeCS.Levels {
	class Special {
		public string type;

		public int varId;

		public string action;

		public int intValue;

		public string stringValue;

		public Special(int fvarId) {
			type = "bool";
			varId = fvarId;
		}

		public Special(int fvarId, string faction, int value) {
			type = "int";
			varId = fvarId;
			intValue = value;
		}

		public Special(int fvarId, string faction, string value) {
			type = "string";
			varId = fvarId;
			action = faction;
			stringValue = value;
		}
	}
}
