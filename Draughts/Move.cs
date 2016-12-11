using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draughts
{
	public class Move
	{
		public int from { get; }
		public int to { get; }
		public Move(int from, int to)
		{
			this.from = from;
			this.to = to;
		}
	}
}
