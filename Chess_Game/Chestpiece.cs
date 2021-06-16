using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 namespace Chest_Game
{
    public class ChessPiece
    {
        public string name;
        public int team;
        public Image chessImage;
        public Point currentPosition;
        public HitMoves hitMoves;

        public ChessPiece(int team,Point startPos, Image chessImage)
        {
            currentPosition = startPos;
            this.chessImage = chessImage;
            this.team = team;
        }


    }
}
