using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chest_Game
{
    public class Player
    {
        public int Team { get; set; }
        public string Name { get; set; }
        public List<ChessPiece> activeChessPieces;
        public List<ChessPiece> nonActiveChessPieces;
        public List<Point> PosibleHitMoves = new List<Point>();

        public ChessPiece currentSelected;
        public bool IsChecked = false;


        public Player(string name, int team)
        {
            this.Name = name;
            this.Team = team;
            activeChessPieces = new List<ChessPiece>();
            nonActiveChessPieces = new List<ChessPiece>();
        }

        public void SwitchPieceToNonActive(ChessPiece chessPiece)
        {
            activeChessPieces.Remove(chessPiece);
            nonActiveChessPieces.Add(chessPiece);
        }
        public void SwitchPieceToActive(ChessPiece chessPiece)
        {
            activeChessPieces.Add(chessPiece);
            nonActiveChessPieces.Remove(chessPiece);
        }
        public void AddToActiveList(ChessPiece chessPiece)
        {

        }



    }
}
