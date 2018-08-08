using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Gomoku
{
    abstract class Piece : PictureBox
    {
        private static readonly int IMAGE_WIDTH = 50;

        public Piece(int x,int y)
        {
            //新建物件的背景設為透明
            this.BackColor = Color.Transparent;
           
            //新建物件的位置
            this.Location = new Point(x- IMAGE_WIDTH/2, y - IMAGE_WIDTH/2);

            //新建物件的大小
            this.Size = new Size(IMAGE_WIDTH, IMAGE_WIDTH);

        }
        public abstract PieceType GetPieceType();

    }
}
