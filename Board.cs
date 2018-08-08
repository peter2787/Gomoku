using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Gomoku
{
    class Board
    {
        public static readonly int NODE_COUNT = 9;

        private static readonly Point NO_MATCH_NODE = new Point(-1, -1);

        //棋盤邊框到邊線的距離
        private static readonly int OFFSET = 75; 

        //棋盤交叉點的判定區域長度
        private static readonly int NODE_RADIUS = 10;

        private Point lastPlacedNode = NO_MATCH_NODE;
        public Point LastPlacedNode { get { return lastPlacedNode; } }

        //棋盤交叉點與交叉點之間的距離
        private static readonly int NODE_DISTANCE = 75;

        private static Piece[,] pieces = new Piece[NODE_COUNT, NODE_COUNT];

        public PieceType GetPieceType(int nodeIdX , int nodeIdY)
        {
            if (pieces[nodeIdX, nodeIdY] == null)
                return PieceType.NONE;
            else
                return pieces[nodeIdX, nodeIdY].GetPieceType();
        }


        public Piece PlaceAPiece(int x , int y ,PieceType type)
        {

            //找出離滑鼠最近的節點(Node)
            Point nodeId = findTheClosetNode(x, y);

            //如果沒有的話，回傳false
            if (nodeId == NO_MATCH_NODE)
                return null;

            //如果有的話，檢查是否已經有棋子存在在目標座標
            if (pieces[nodeId.X, nodeId.Y] != null)
                return null;


            //根據Type產生稱對應的棋子
            Point formPos = convertToFormPosition(nodeId);
            if (type == PieceType.BLACK)
                pieces[nodeId.X, nodeId.Y] = new BlackPiece(formPos.X, formPos.Y);
            else if (type == PieceType.WHITE)
                pieces[nodeId.X, nodeId.Y] = new WhitePiece(formPos.X, formPos.Y);


            lastPlacedNode = nodeId;

            return pieces[nodeId.X, nodeId.Y];
        }
        
        private Point convertToFormPosition(Point nodeId)
        {
            Point formPosition = new Point();
            formPosition.X = nodeId.X * NODE_DISTANCE + OFFSET;
            formPosition.Y = nodeId.Y * NODE_DISTANCE + OFFSET;
            return formPosition;
        }

        public bool CanBePlaced(int x, int y)
        //判斷現在的座標是否可以放置棋子
        //如果滑鼠在節點的指定區域範圍內，就改變滑鼠指標的圖示
        {

            //找出離滑鼠最近的節點(Node)
            Point nodeId = findTheClosetNode(x, y);

            //如果沒有的話，回傳false
            if (nodeId == NO_MATCH_NODE)
                return false;

            //如果有的話，檢查是否已經有棋子存在在目標座標
            if (pieces[nodeId.X,nodeId.Y] != null)
                return false;
            return true;
        }


        private Point findTheClosetNode(int x, int y) //二維陣列，找到最近的交叉點
        {

            //呼叫下方的一維陣列獲得X值
            int nodeIdX = findTheClosetNode(x);

            //如果X座標位置在棋盤外則不可放置棋子
            if (nodeIdX == -1|| nodeIdX >= NODE_COUNT)
                return NO_MATCH_NODE;

            int nodeIdY = findTheClosetNode(y);
            if (nodeIdY == -1|| nodeIdY >= NODE_COUNT)
                return NO_MATCH_NODE;

            //如果XY座標都正常則回傳XY座標位置
            return new Point(nodeIdX, nodeIdY);
        }

       
        private int findTheClosetNode(int pos)  //一維陣列(先判定X座標之後再判定二維陣列)
        {
            //判斷如果滑鼠座標在棋盤外的話，則不做任何事情
            if (pos < OFFSET - NODE_RADIUS)
                return -1;

            //利用除法獲得目前滑鼠座標在棋盤上的位置
            pos -= OFFSET;

            //商數，可獲得我的座標左邊是哪一個座標點
            int quotient = pos / NODE_DISTANCE; 

            //餘數，可獲的我的座標目前是靠近左邊的座標點還是右邊
            int remainder = pos % NODE_DISTANCE;


            //判斷該滑鼠座標在"左邊"交叉點的判定範圍內
            if (remainder <= NODE_RADIUS)
                return quotient;

            //判斷該滑鼠座標在"右邊"交叉點的判定範圍內
            else if (remainder >= NODE_DISTANCE - NODE_RADIUS)
                return quotient + 1;

            else
                return -1;
        }
        public void ReStart()
        { 
             for (int i = 0; i <= NODE_COUNT-1; i++)
             {
                 for (int j = 0; j <= NODE_COUNT-1; j++)
                 {  
                    pieces[i, j] = null;
                 }
             }
        }
        public void EndGame(int i)
        {

        }
    }
}
