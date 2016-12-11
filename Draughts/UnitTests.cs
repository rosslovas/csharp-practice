using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Draughts
{
	[TestFixture]
	public class UnitTests
	{
		DraughtsGame game;

		[SetUp]
		public void SetUp()
		{
			game = new DraughtsGame();
		}

		[Test]
		public void PromotingManSucceeds()
		{
			Piece manToPromote = new Piece(PieceColour.black);
			Assert.AreEqual(manToPromote.type, PieceType.man);
			manToPromote.Promote();
			Assert.AreEqual(manToPromote.type, PieceType.king);
		}

		[Test]
		public void PromotingKingFails()
		{
			Piece alreadyKing = new Piece(PieceColour.black, PieceType.king);
			Assert.Throws<PromotionException>(() => alreadyKing.Promote());
		}

		[Test]
		public void BoardNumbersToIndecesCorrectness()
		{
			// Row 1
			var indeces = Board.NumberingToIndeces(1);
			Assert.IsTrue(indeces.Equals(Tuple.Create(1, 0)));
			indeces = Board.NumberingToIndeces(2);
			Assert.IsTrue(indeces.Equals(Tuple.Create(3, 0)));
			indeces = Board.NumberingToIndeces(3);
			Assert.IsTrue(indeces.Equals(Tuple.Create(5, 0)));
			indeces = Board.NumberingToIndeces(4);
			Assert.IsTrue(indeces.Equals(Tuple.Create(7, 0)));

			// Row 2
			indeces = Board.NumberingToIndeces(5);
			Assert.IsTrue(indeces.Equals(Tuple.Create(0, 1)));
			indeces = Board.NumberingToIndeces(6);
			Assert.IsTrue(indeces.Equals(Tuple.Create(2, 1)));
			indeces = Board.NumberingToIndeces(7);
			Assert.IsTrue(indeces.Equals(Tuple.Create(4, 1)));
			indeces = Board.NumberingToIndeces(8);
			Assert.IsTrue(indeces.Equals(Tuple.Create(6, 1)));

			// Row 7
			indeces = Board.NumberingToIndeces(25);
			Assert.IsTrue(indeces.Equals(Tuple.Create(1, 6)));
			indeces = Board.NumberingToIndeces(26);
			Assert.IsTrue(indeces.Equals(Tuple.Create(3, 6)));
			indeces = Board.NumberingToIndeces(27);
			Assert.IsTrue(indeces.Equals(Tuple.Create(5, 6)));
			indeces = Board.NumberingToIndeces(28);
			Assert.IsTrue(indeces.Equals(Tuple.Create(7, 6)));

			// Row 8
			indeces = Board.NumberingToIndeces(29);
			Assert.IsTrue(indeces.Equals(Tuple.Create(0, 7)));
			indeces = Board.NumberingToIndeces(30);
			Assert.IsTrue(indeces.Equals(Tuple.Create(2, 7)));
			indeces = Board.NumberingToIndeces(31);
			Assert.IsTrue(indeces.Equals(Tuple.Create(4, 7)));
			indeces = Board.NumberingToIndeces(32);
			Assert.IsTrue(indeces.Equals(Tuple.Create(6, 7)));
		}

		[Test]
		public void InvalidBoardNumberFailsConversionToIndeces()
		{
			Assert.Throws<IndexOutOfRangeException>(() => Board.NumberingToIndeces(-1));
			Assert.Throws<IndexOutOfRangeException>(() => Board.NumberingToIndeces(0));
			Assert.Throws<IndexOutOfRangeException>(() => Board.NumberingToIndeces(33));
			Assert.Throws<IndexOutOfRangeException>(() => Board.NumberingToIndeces(34));
		}

		[Test]
		public void CapturingNothingThrows()
		{
			Assert.Throws<InvalidMoveException>(() => game.PerformMove(new Move(9, 18)));
		}

		[Test]
		public void TooFarMoveThrows()
		{
			game.PerformMove(new Move(9, 14));
			Assert.Throws<InvalidMoveException>(() => game.PerformMove(new Move(23, 9)));
		}

		[Test]
		public void WrongTurnThrows1()
		{
			Assert.Throws<WrongTurnException>(() => game.PerformMove(new Move(24, 20)));
		}

		[Test]
		public void WrongTurnThrows2()
		{
			//Assert.Throws<WrongTurnException>(() => game.PerformMove(new Move(24, 20)));
		}

		[Test]
		public void IgnoringCaptureOpportunityThrows()
		{
			Assert.DoesNotThrow(() => game.PerformMove(new Move(9, 14)));
			Assert.DoesNotThrow(() => game.PerformMove(new Move(21, 17)));
			// The black piece at 14 must take the white piece at 17.
			Assert.Throws<InvalidMoveException>(() => game.PerformMove(new Move(14, 18)));
		}

		[Test]
		public void CaptureTakesJumpedPiece()
		{
			game.PerformMove(new Move(9, 14));
			game.PerformMove(new Move(21, 17));
			// The black piece at 14 must take the white piece at 17.
			game.PerformMove(new Move(14, 21));
			// The white piece at 17 should now be gone.
			Assert.IsNull(game.board.PieceAt(17));
		}

		[Test]
		public void UncrownedMovingBackwardsThrows()
		{
			// Black valid turn one.
			Assert.DoesNotThrow(() => game.PerformMove(new Move(9, 14)));
			// White valid turn one.
			Assert.DoesNotThrow(() => game.PerformMove(new Move(24, 20)));
			// Black invalid turn (backwards moving piece).
			Assert.Throws<InvalidMoveException>(() => game.PerformMove(new Move(14, 9)));
		}
	}
}
