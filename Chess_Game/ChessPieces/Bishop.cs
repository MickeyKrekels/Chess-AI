using System.Drawing;

namespace Chest_Game.ChestPieces
{
    public class Bishop : ChessPiece
    {
        public Bishop(string pieceName,int team,Point startPos, Image chessImage) : base(team ,startPos, chessImage)
        {
            name = "Bishop_" + pieceName;

            //looper kan niet vooruit slaan
            hitMoves = new HitMoves();

            hitMoves.TopRight = new Point[]
            {
              new Point(1,1),
              new Point(2,2),
              new Point(3,3),
              new Point(4,4),
              new Point(5,5),
              new Point(6,6),
              new Point(7,7),
              new Point(8,8),
            };
            hitMoves.TopLeft = new Point[]
           {
               new Point(-1,1),
               new Point(-2,2),
               new Point(-3,3),
               new Point(-4,4),
               new Point(-5,5),
               new Point(-6,6),
               new Point(-7,7),
               new Point(-8,8),
           };
            hitMoves.BotRight = new Point[]
{
               new Point(1,-1),
               new Point(2,-2),
               new Point(3,-3),
               new Point(4,-4),
               new Point(5,-5),
               new Point(6,-6),
               new Point(7,-7),
               new Point(8,-8),
};
            hitMoves.BotLeft = new Point[]
{
               new Point(-1,-1),
               new Point(-2,-2),
               new Point(-3,-3),
               new Point(-4,-4),
               new Point(-5,-5),
               new Point(-6,-6),
               new Point(-7,-7),
               new Point(-8,-8),
        };
        }
    }
}
