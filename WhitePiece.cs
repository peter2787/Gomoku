using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    class WhitePiece : Piece//被呼叫之後直接回傳資料給Piece
    {
        public WhitePiece(int x, int y) : base(x, y)//收到X,Y值之後，回傳(base)值給Piece
        {
            this.Image = Properties.Resources.white;
        }
        public override PieceType GetPieceType()
        {
            return PieceType.WHITE;
        }
}
}
