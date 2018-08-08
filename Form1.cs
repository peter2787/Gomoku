using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gomoku
{
    public partial class Form1 : Form
    {
        private Game game = new Game();
        private Board board = new Board();
        private static DialogResult result;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)//MouseEventArgs e 滑鼠按下後的位置資訊存取區
        {
            Piece piece = game.PlaceAPiece(e.X, e.Y);
            if (piece != null)
            {
                this.Controls.Add(piece);

                if (game.Winner == PieceType.BLACK)
                {
                    result = MessageBox.Show("黑色獲勝","遊戲結束", MessageBoxButtons.OK);
                }
                else if (game.Winner == PieceType.WHITE)
                {
                    result = MessageBox.Show("白色獲勝","遊戲結束", MessageBoxButtons.OK);
                }
                if (result == DialogResult.OK)
                {
                    GameRestart();
                    board.ReStart();
                    game.ReStart();
                    result = new DialogResult();
                }
            }
            
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if(game.CanBePlaced(e.X,e.Y))
            {
                this.Cursor = Cursors.Hand;
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void GameRestart()
        {
            for (int i = 0; i < this.Controls.Count; i++)
            {
                if (this.Controls[i] is Gomoku.BlackPiece)
                {
                    this.Controls.RemoveAt(i);
                    i--;
                }
                if (this.Controls[i] is Gomoku.WhitePiece)
                {
                    this.Controls.RemoveAt(i);
                    i--;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GameRestart();
            board.ReStart();
            game.ReStart();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
