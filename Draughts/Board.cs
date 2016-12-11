using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draughts
{
	public class Board
	{
		public Piece[,] board;

		public Board()
		{
			// Initialise board state.
			board = new Piece[8, 8];

			// Black pieces
			for (int position = 1; position <= 12; ++position)
			{
				var indeces = NumberingToIndeces(position);
				board[indeces.Item1, indeces.Item2] = new Piece(PieceColour.black);
			}
			// White pieces
			for (int position = 21; position <= 32; ++position)
			{
				var indeces = NumberingToIndeces(position);
				board[indeces.Item1, indeces.Item2] = new Piece(PieceColour.white);
			}
		}

		public Piece PieceAt(int number)
		{
			var indeces = NumberingToIndeces(number);
			return board[indeces.Item1, indeces.Item2];
		}

		public bool PieceAtCouldCapture(int number)
		{
			var indeces = NumberingToIndeces(number);
			return PieceAtCoordinatesCouldCapture(indeces.Item1, indeces.Item2);
		}

		public bool PieceAtCoordinatesCouldCapture(int x, int y)
		{
			var movingPiece = board[x, y];
			if (movingPiece == null)
			{
				return false;
			}

			if (movingPiece.type == PieceType.king || movingPiece.colour == PieceColour.black)
			{
				if (y < 6)
				{
					if (x > 1)
					{
						if (PieceAtCoordinatesCouldCaptureInDirection(x, y, -1, 1))
						{
							return true;
						}
					}
					if (x < 6)
					{
						if (PieceAtCoordinatesCouldCaptureInDirection(x, y, 1, 1))
						{
							return true;
						}
					}
				}
			}

			if (movingPiece.type == PieceType.king || movingPiece.colour == PieceColour.white)
			{
				if (y > 1)
				{
					if (x > 1)
					{
						if (PieceAtCoordinatesCouldCaptureInDirection(x, y, -1, -1))
						{
							return true;
						}
					}
					if (x < 6)
					{
						if (PieceAtCoordinatesCouldCaptureInDirection(x, y, 1, -1))
						{
							return true;
						}
					}
				}
			}

			return false;
		}

		// Assumes that there is a piece at (x, y), and there is room toward the board edge
		// such that it will not check out of bounds (2 spaces in the relevant directions).
		private bool PieceAtCoordinatesCouldCaptureInDirection(int x, int y, int dx, int dy)
		{
			if (dx == 0 || dy == 0 || Math.Abs(dx) > 1 || Math.Abs(dy) > 1)
			{
				throw new ArgumentOutOfRangeException();
			}

			var movingPiece = board[x, y];
			var pieceBeingCaptured = board[x + dx, y + dy];
			// Check if a piece is there, and is the right colour, to be captured.
			if (pieceBeingCaptured == null || pieceBeingCaptured.colour == movingPiece.colour)
			{
				return false;
			}
			// Check if the jump destination is empty.
			if (board[x + 2 * dx, y + 2 * dy] != null)
			{
				return false;
			}
			return true;
		}

		// Assumes a non-capture is moving 1 square in each direction & a capture is moving 2.
		public void PerformMove(int from, int to, bool isCapture)
		{
			var fromIndeces = NumberingToIndeces(from);
			var toIndeces = NumberingToIndeces(to);

			var movingPiece = PieceAt(from);
			if (movingPiece == null)
			{
				throw new InvalidMoveException();
			}

			// Can't move on top of another piece.
			if (board[toIndeces.Item1, toIndeces.Item2] != null)
			{
				throw new InvalidMoveException();
			}

			// If it's a capture, destroy the jumped piece.
			if (isCapture)
			{
				var x = (toIndeces.Item1 + fromIndeces.Item1) / 2;
				var y = (toIndeces.Item2 + fromIndeces.Item2) / 2;
				// Ensure a piece is actually being jumped.
				if (board[x, y] == null)
				{
					throw new InvalidMoveException();
				}
				board[x, y] = null;
			}

			board[toIndeces.Item1, toIndeces.Item2] = movingPiece;
			board[fromIndeces.Item1, fromIndeces.Item2] = null;

			// Promote the piece if it just reached the other end of the board.
			if (toIndeces.Item2 == 7
				&& movingPiece.type == PieceType.man
				&& movingPiece.colour == PieceColour.black)
			{
				movingPiece.Promote();
			} else if (toIndeces.Item2 == 0
				&& movingPiece.type == PieceType.man
				&& movingPiece.colour == PieceColour.white)
			{
				movingPiece.Promote();
			}
		}

		// Converts a reachable board position (1 - 32) from standardised notation to grid indeces.
		public static Tuple<int, int> NumberingToIndeces(int number)
		{
			if (number <= 0 || number > 32)
			{
				throw new IndexOutOfRangeException();
			}

			// Much easier to work with 0 to 31 instead of 1 to 32.
			--number;

			var row = number / 4;
			var column = (number % 4) * 2;
			if (row % 2 == 0)
			{
				++column;
			}
			return Tuple.Create(column, row);
		}
	}
}
