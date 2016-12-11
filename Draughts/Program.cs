using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Draughts
{
	static class Program
	{

		static MainForm mainForm;

		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			DraughtsGame game = new DraughtsGame();
			mainForm = new MainForm(game);
			game.GameStateChanged += mainForm.RedrawBoardEventHandler;
			mainForm.moves.Add(new Move(9, 14));
			mainForm.moves.Add(new Move(23, 18));
			mainForm.moves.Add(new Move(14, 23));
			mainForm.moves.Add(new Move(27, 18));
			mainForm.moves.Add(new Move(5, 9));
			mainForm.moves.Add(new Move(26, 23));
			mainForm.moves.Add(new Move(12, 16));
			mainForm.moves.Add(new Move(30, 26));
			mainForm.moves.Add(new Move(16, 19));
			mainForm.moves.Add(new Move(24, 15));
			mainForm.moves.Add(new Move(10, 19));
			mainForm.moves.Add(new Move(23, 16));
			mainForm.moves.Add(new Move(11, 20));
			mainForm.moves.Add(new Move(22, 17));
			mainForm.moves.Add(new Move(7, 11));
			mainForm.moves.Add(new Move(18, 15));
			mainForm.moves.Add(new Move(11, 18));
			mainForm.moves.Add(new Move(28, 24));
			mainForm.moves.Add(new Move(20, 27));
			mainForm.moves.Add(new Move(32, 23));
			mainForm.moves.Add(new Move(23, 14));
			mainForm.moves.Add(new Move(14, 5));
			mainForm.moves.Add(new Move(8, 11));
			mainForm.moves.Add(new Move(26, 23));
			mainForm.moves.Add(new Move(4, 8));
			mainForm.moves.Add(new Move(25, 22));
			mainForm.moves.Add(new Move(11, 15));
			mainForm.moves.Add(new Move(17, 13));
			mainForm.moves.Add(new Move(8, 11));
			mainForm.moves.Add(new Move(21, 17));
			mainForm.moves.Add(new Move(11, 16));
			mainForm.moves.Add(new Move(23, 18));
			mainForm.moves.Add(new Move(15, 19));
			mainForm.moves.Add(new Move(17, 14));
			mainForm.moves.Add(new Move(19, 24));
			mainForm.moves.Add(new Move(14, 10));
			mainForm.moves.Add(new Move(6, 15));
			mainForm.moves.Add(new Move(18, 11));
			mainForm.moves.Add(new Move(24, 28));
			mainForm.moves.Add(new Move(22, 17));
			mainForm.moves.Add(new Move(28, 32));
			mainForm.moves.Add(new Move(17, 14));
			mainForm.moves.Add(new Move(32, 28));
			mainForm.moves.Add(new Move(31, 27));
			mainForm.moves.Add(new Move(16, 19));
			mainForm.moves.Add(new Move(27, 24));
			mainForm.moves.Add(new Move(19, 23));
			mainForm.moves.Add(new Move(24, 20));
			mainForm.moves.Add(new Move(23, 26));
			mainForm.moves.Add(new Move(29, 25));
			mainForm.moves.Add(new Move(26, 30));
			mainForm.moves.Add(new Move(25, 21));
			mainForm.moves.Add(new Move(30, 26));
			mainForm.moves.Add(new Move(14, 9));
			mainForm.moves.Add(new Move(26, 23));
			mainForm.moves.Add(new Move(20, 16));
			mainForm.moves.Add(new Move(23, 18));
			mainForm.moves.Add(new Move(16, 12));
			mainForm.moves.Add(new Move(18, 14));
			mainForm.moves.Add(new Move(11, 8));
			mainForm.moves.Add(new Move(28, 24));
			mainForm.moves.Add(new Move(8, 4));
			mainForm.moves.Add(new Move(24, 19));
			mainForm.moves.Add(new Move(4, 8));
			mainForm.moves.Add(new Move(19, 16));
			mainForm.moves.Add(new Move(9, 6));
			mainForm.moves.Add(new Move(1, 10));
			mainForm.moves.Add(new Move(5, 1));
			mainForm.moves.Add(new Move(10, 15));
			mainForm.moves.Add(new Move(1, 6));
			mainForm.moves.Add(new Move(2, 9));
			mainForm.moves.Add(new Move(13, 6));
			mainForm.moves.Add(new Move(16, 11));
			mainForm.moves.Add(new Move(8, 4));
			mainForm.moves.Add(new Move(15, 18));
			mainForm.moves.Add(new Move(6, 1));
			mainForm.moves.Add(new Move(18, 22));
			mainForm.moves.Add(new Move(1, 6));
			mainForm.moves.Add(new Move(22, 26));
			mainForm.moves.Add(new Move(6, 1));
			mainForm.moves.Add(new Move(26, 30));
			mainForm.moves.Add(new Move(1, 6));
			mainForm.moves.Add(new Move(30, 26));
			mainForm.moves.Add(new Move(6, 1));
			mainForm.moves.Add(new Move(26, 22));
			mainForm.moves.Add(new Move(1, 6));
			mainForm.moves.Add(new Move(22, 18));
			mainForm.moves.Add(new Move(6, 1));
			mainForm.moves.Add(new Move(14, 9));
			mainForm.moves.Add(new Move(1, 5));
			mainForm.moves.Add(new Move(9, 6));
			mainForm.moves.Add(new Move(21, 17));
			mainForm.moves.Add(new Move(18, 22));
			Application.Run(mainForm);
		}
	}
}
