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
			mainForm.moves.Add(new Move(10, 14));
			mainForm.moves.Add(new Move(24, 20));
			mainForm.moves.Add(new Move(6, 10));
			mainForm.moves.Add(new Move(28, 24));
			mainForm.moves.Add(new Move(14, 17));
			mainForm.moves.Add(new Move(22, 13));
			mainForm.moves.Add(new Move(13, 6));
			Application.Run(mainForm);
		}
	}
}
