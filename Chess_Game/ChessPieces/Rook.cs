using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chest_Game.ChestPieces
{
    class Rook : ChessPiece
    {
        public Rook(string pieceName , int team, Point startPos, Image chessImage) : base(team, startPos, chessImage)
        {
            name = "Rook_" + pieceName;
            //looper kan niet vooruit slaan
            hitMoves = new HitMoves();

            hitMoves.Top = new Point[]
            {
                new Point(0,1),
                new Point(0,2),
                new Point(0,3),
                new Point(0,4),
                new Point(0,5),
                new Point(0,6),
                new Point(0,7),
                new Point(0,8),
            };
            hitMoves.Bot = new Point[]
            {
                new Point(0,-1),
                new Point(0,-2),
                new Point(0,-3),
                new Point(0,-4),
                new Point(0,-5),
                new Point(0,-6),
                new Point(0,-7),
                new Point(0,-8),
            };
            hitMoves.Right = new Point[]
            {
                new Point(1,0),
                new Point(2,0),
                new Point(3,0),
                new Point(4,0),
                new Point(5,0),
                new Point(6,0),
                new Point(7,0),
                new Point(8,0),
            };
            hitMoves.Left = new Point[]
            {
                new Point(-1,0),
                new Point(-2,0),
                new Point(-3,0),
                new Point(-4,0),
                new Point(-5,0),
                new Point(-6,0),
                new Point(-7,0),
                new Point(-8,0),
            };
        }
    }
}
