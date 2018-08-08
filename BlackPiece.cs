using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    class BlackPiece : Piece//被呼叫之後直接回傳資料給Piece
    {

        public BlackPiece(int x, int y) : base(x, y)//收到X,Y值之後，回傳(base)值給Piece
        {
            this.Image = Properties.Resources.black;
        }
        public override PieceType GetPieceType()
        {
            return PieceType.BLACK;
        }
    }
}
