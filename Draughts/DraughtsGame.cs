using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draughts
{
	public class DraughtsGame
	{
		public Board board { get; private set; }
		public PieceColour turn { get; private set; }

		public event EventHandler GameStateChanged = delegate { };

		public DraughtsGame()
		{
			board = new Board();
			turn = PieceColour.black;
		}

		public void PerformMove(Move move)
		{
			var movingPiece = board.PieceAt(move.from);
			if (movingPiece == null)
			{
				throw new InvalidMoveException();
			}
			if (movingPiece.colour != turn)
			{
				throw new WrongTurnException();
			}

			var fromIndeces = Board.NumberingToIndeces(move.from);
			var toIndeces = Board.NumberingToIndeces(move.to);

			// Simple check if the move is a jump (moves more than 1 row).
			bool isCaptureMove = false;
			if (Math.Abs(fromIndeces.Item2 - toIndeces.Item2) > 1)
			{
				isCaptureMove = true;
			}

			// Ensure a non-capture move goes exactly 1 square in each direction.
			if (!isCaptureMove &&
				(Math.Abs(fromIndeces.Item1 - toIndeces.Item1) != 1
				|| Math.Abs(fromIndeces.Item2 - toIndeces.Item2) != 1))
			{
				throw new InvalidMoveException();
			}

			// Ensure a capture move goes exactly 2 squares in each direction.
			if (isCaptureMove &&
				(Math.Abs(fromIndeces.Item1 - toIndeces.Item1) != 2
				|| Math.Abs(fromIndeces.Item2 - toIndeces.Item2) != 2))
			{
				throw new InvalidMoveException();
			}

			// If any capture opportunity is present, this move MUST be capturing something.
			if (!isCaptureMove && PlayerCouldCapture(turn))
			{
				throw new InvalidMoveException();
			}

			// Let the board decide the details of the move from here.
			board.PerformMove(move.from, move.to, isCaptureMove);

			// If a capture happened, turn only ends if there are no available jumps remaining.
			if (!isCaptureMove || !PlayerCouldCapture(turn)) {
				if (turn == PieceColour.black)
				{
					turn = PieceColour.white;
				} else
				{
					turn = PieceColour.black;
				}
			}

			// Notify observers that something happened.
			GameStateChanged(this, EventArgs.Empty);
		}

		private bool PlayerCouldCapture(PieceColour player)
		{
			for (int i = 1; i <= 32; ++i)
			{
				var piece = board.PieceAt(i);
				if (piece != null && piece.colour == player && board.PieceAtCouldCapture(i))
				{
					return true;
				}
			}
			return false;
		}
	}

	public class InvalidMoveException : Exception
	{
	}

	public class WrongTurnException : Exception
	{
	}
}
