using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chest_Game.ChestPieces
{
    public class King : ChessPiece
    {
        public King(string pieceName , int team ,Point startPos, Image chessImage) : base(team,startPos, chessImage)
        {
            name = "King_" + pieceName;
            //looper kan niet vooruit slaan
            hitMoves = new HitMoves();

            hitMoves.Top = new Point[]
            {
                 new Point(0,1)
            };
            hitMoves.TopRight = new Point[]
            {
                 new Point(1,1)
            };
            hitMoves.Right = new Point[]
            {
                 new Point(1,0)
            };
            hitMoves.BotRight = new Point[]
            {
                 new Point(1,-1)
            };
            hitMoves.Bot = new Point[]
            {
                 new Point(0,-1)
            };
            hitMoves.BotLeft = new Point[]
            {

                 new Point(-1,-1)
            };
            hitMoves.Left = new Point[]
            {
                 new Point(-1,0)
            };
            hitMoves.TopLeft = new Point[]
            {
                 new Point(-1,1)
                 
            };
        }
    }
}
