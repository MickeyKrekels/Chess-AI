using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chest_Game.ChestPieces
{
    public class Pawn : ChessPiece
    {
   
        public Pawn(string pieceName, int team, Point startPos, Image chessImage) : base(team,startPos, chessImage)
        {
            name = "Pawn_" + pieceName;
            //looper kan niet vooruit slaan
            hitMoves = new HitMoves();

            hitMoves.TopLeft = new Point[]
            {
                new Point(-1,1)
            };
            hitMoves.TopRight = new Point[]
            {
                new Point(1,1),
            };
            hitMoves.Walk = new Point[]
            {
                new Point(0,1),
                new Point(0,2)
            };


        }
    }
}
