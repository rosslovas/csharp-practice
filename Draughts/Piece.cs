using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draughts
{
	public enum PieceColour { white, black };
	public enum PieceType { man, king };

	public class Piece
	{
		public PieceColour colour { get; }
		public PieceType type { get; private set; }

		public Piece(PieceColour initialColour, PieceType initialType = PieceType.man)
		{
			this.colour = initialColour;
			this.type = initialType;
		}

		public void Promote()
		{
			if (type == PieceType.man)
			{
				type = PieceType.king;
			} else
			{
				throw new PromotionException();
			}
		}

	}

	class PromotionException : System.Exception
	{
	}
}
