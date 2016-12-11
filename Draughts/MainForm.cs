using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Draughts
{
	public partial class MainForm : Form
	{
		private Bitmap buffer = new Bitmap(800, 800);
		public DraughtsGame game;
		public List<Move> moves = new List<Move>();

		public MainForm(DraughtsGame game)
		{
			this.game = game;
			InitializeComponent();
		}

		private void RedrawBoard()
		{
			using (Graphics graphics = Graphics.FromImage(buffer))
			{
				RenderGrid(graphics);
				RenderBoard(graphics);
			}
		}

		public void RedrawBoardEventHandler(object sender, EventArgs e)
		{
			OutputBox.AppendText("Game state changed, redrawing board.\n");
			RedrawBoard();
			this.Refresh();
		}

		private void OnLoad(object sender, EventArgs e)
		{
			RedrawBoard();
		}

		private void PaintDraughts(object sender, PaintEventArgs e)
		{
			e.Graphics.DrawImageUnscaled(buffer, Point.Empty);
		}

		private void RenderGrid(Graphics graphics)
		{
			for (int x = 0; x < 8; ++x)
			{
				for (int y = 0; y < 8; ++y)
				{
					if ((y % 2 == 1 && x % 2 == 0) || (y % 2 == 0 && x % 2 == 1))
					{
						graphics.FillRectangle(new SolidBrush(Color.DarkGray), x * 100, y * 100, 100, 100);
					}
					else
					{
						graphics.FillRectangle(new SolidBrush(Color.LightGray), x * 100, y * 100, 100, 100);
					}
				}
			}
		}

		private void RenderBoard(Graphics graphics)
		{
			for (int x = 0; x < 8; ++x)
			{
				for (int y = 0; y < 8; ++y)
				{
					var piece = game.board.board[x, y];
					if (piece != null)
					{
						if (piece.colour == PieceColour.black)
						{
							if (piece.type == PieceType.man)
							{
								graphics.FillEllipse(new SolidBrush(Color.Black), x * 100 + 20, y * 100 + 20, 60, 60);
							} else
							{
								graphics.FillEllipse(new SolidBrush(Color.DarkSlateGray), x * 100 + 10, y * 100 + 10, 80, 80);
							}
						}
						else
						{
							if (piece.type == PieceType.man)
							{
								graphics.FillEllipse(new SolidBrush(Color.White), x * 100 + 20, y * 100 + 20, 60, 60);
							}
							else
							{
								graphics.FillEllipse(new SolidBrush(Color.LightSkyBlue), x * 100 + 10, y * 100 + 10, 80, 80);
							}
						}
					}
				}
			}
		}

		private void ClickBoard(object sender, EventArgs e)
		{
			if (moves.Count > 0)
			{
				var move = moves.First();
				OutputBox.AppendText("Performing move from " + move.from + " to " + move.to + "\n");
				game.PerformMove(new Move(move.from, move.to));
				moves.RemoveAt(0);
			} else
			{
				OutputBox.AppendText("Out of moves.\n");
			}
		}
	}
}
