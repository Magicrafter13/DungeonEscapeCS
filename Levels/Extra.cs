using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonEscapeCS.Levels {
	class Extra {
		public List<bool> extraBool;

		public List<int> extraInt;

		public List<string> extraString;

		public Extra(List<bool> fBool) {
			extraBool = fBool;
		}

		public Extra(List<int> fInt) {
			extraInt = fInt;
		}

		public Extra(List<string> fString) {
			extraString = fString;
		}
	}
}
