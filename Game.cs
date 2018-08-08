using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    class Game
    {
        private PieceType currentPlayer = PieceType.BLACK;//用於讓棋子黑白交換，預設為黑色棋子
        private Board board = new Board();
        private PieceType winner = PieceType.NONE;
        public PieceType Winner { get { return winner; } }

        public bool CanBePlaced(int x , int y)
        {
            return board.CanBePlaced(x, y);
        }

        public Piece PlaceAPiece(int x, int y)
        {
            Piece piece = board.PlaceAPiece(x, y, currentPlayer);
            if (piece != null)
            {
                checkWinner();

                if (currentPlayer == PieceType.BLACK)
                    currentPlayer = PieceType.WHITE;
                else if (currentPlayer == PieceType.WHITE)
                    currentPlayer = PieceType.BLACK;

                return piece;
            }
            return null;
        }
        private void checkWinner()
        {
            int centerX = board.LastPlacedNode.X;
            int centerY = board.LastPlacedNode.Y;

            //檢查8個方向
            for (int xDir = -1; xDir <= 1; xDir++)
            {
                for (int yDir = -1; yDir <= 1; yDir++)
                {
                    //(0,0)是自己的位置所以不檢查
                    if (xDir == 0 && yDir == 0)
                        continue;

                    //紀錄在路徑上看到幾顆相同的棋子
                    int count = 1;
                    int count2 = 1;

                    //往同一方向檢查5顆棋子
                    while (count < 5)
                    {
                        int targetX = centerX + count*xDir;
                        int targetY = centerY + count*yDir;

                        //檢察顏色是否相同
                        if (targetX < 0 || targetX >= Board.NODE_COUNT ||
                           targetY < 0 || targetY >= Board.NODE_COUNT ||
                           board.GetPieceType(targetX, targetY) != currentPlayer)
                           break;


                        count++;
                    }
                    while (count2 < 5)
                    {
                        //檢查count的相反方向
                        int targetX = centerX - count2 * xDir;
                        int targetY = centerY - count2 * yDir;

                        if (targetX < 0 || targetX >= Board.NODE_COUNT ||
                        targetY < 0 || targetY >= Board.NODE_COUNT ||
                        board.GetPieceType(targetX, targetY) != currentPlayer)
                        {
                            break;
                        }
                        count2++;
                    }
                    //檢查是否有5顆棋子
                    if (count == 5|| count + count2 > 5)
                        winner = currentPlayer;
                }
            }
        }

        public void ReStart()
        {
            winner = PieceType.NONE;
            currentPlayer = PieceType.BLACK;
        }
    }
}
