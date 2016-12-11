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
			mainForm.moves.Add(new Move(21, 17));
			mainForm.moves.Add(new Move(14, 21));
			Application.Run(mainForm);
		}
	}
}
