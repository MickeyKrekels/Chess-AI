using Chest_Game.ChestPieces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Chest_Game
{
    public partial class Form1 : Form
    {
        public Cell[,] board;
        public Player[] players;
        public int currentTeam = 0;

        public ChessLog chessLog;
        private TextBox textBox;
        private FlowLayoutPanel flowLayoutPanel;

        public Form1()
        {
            SpawnBoard();
            InitializeComponent();
            SpawnChessPieces();
            //MoveChessPiece("");
        } 

        private void SpawnBoard()
        {
            int buttonWidth = 55;
            int buttonHeight = 55;
            int distance = 20;
            int start_x = 10;
            int start_y = 10;

            int boardSizeX = 8;
            int boardSizeY = 8;

            int listboxSizeX = 3;
            int listboxSizeY = 5;


            board = new Cell[boardSizeX, boardSizeY];

            for (int x = 0; x < boardSizeX; x++)
            {
                for (int y = 0; y < boardSizeY; y++)
                {
                    Button tmpButton = new Button();
                    tmpButton.Left = start_x + (x * buttonHeight + distance);
                    tmpButton.Top = start_y + (y * buttonWidth + distance);
                    tmpButton.Width = buttonWidth;
                    tmpButton.Height = buttonHeight;
                    tmpButton.BackColor = default(Color);
                    //add button to array 
                    board[x, y] = new Cell(new Point(x, y), tmpButton);
               
                    this.Controls.Add(tmpButton);

                }
            }


            ListBox listbox = new ListBox();
            listbox.Width = buttonWidth * (listboxSizeX * 2);
            listbox.Height = buttonHeight * listboxSizeY;
            listbox.Left = 15 + (boardSizeX * buttonHeight + distance);
            listbox.Top = 30;

            textBox = new TextBox();
            textBox.Width = listbox.Width;
            textBox.Height = listbox.Height;
            textBox.Left = listbox.Left;
            textBox.Top = listbox.Top *10;

            flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.BackColor = Color.LightGray;
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.Width = listbox.Width;
            flowLayoutPanel.Height = listbox.Height/2;
            flowLayoutPanel.Left = listbox.Left;
            flowLayoutPanel.Top = listbox.Top * 11 + 2;


            this.Controls.Add(textBox);
            this.Controls.Add(listbox);
            this.Controls.Add(flowLayoutPanel);
            chessLog = new ChessLog(listbox);

            textBox.KeyDown += new KeyEventHandler(OnTextBoxEnter);

            foreach (Cell cell in board)
            {
                cell.cellButton.Click += new System.EventHandler((obj, args) =>
                {
                    OnbuttonPressed(cell);
                });
            }
        }

        private void OnTextBoxEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            MoveChessPiece(textBox.Text);
            textBox.Text = "";

        }

        private void MoveChessPiece(string inputCommand)
        {
            
            //if input is correct command
            chessLog.AddLogQue(inputCommand);

            Regex regex = new Regex(@"\d");

            MatchCollection matches = regex.Matches(inputCommand);

            if (matches.Count < 4)
                return;

            int[] pointValues = new int[matches.Count];
            for (int i = 0; i < matches.Count; i++)
            {
                pointValues[i] = int.Parse(matches[i].Value);
            }

            Cell firstMove = GetCell(new Point(pointValues[0], pointValues[1]));
            OnbuttonPressed(firstMove);

            Cell secondMove = GetCell(new Point(pointValues[2], pointValues[3]));
            OnbuttonPressed(secondMove);
        }
        
        private void SpawnChessPieces()
        {
            //SpawnPlayers
            players = new Player[2];
            players[0] = new Player("Team White", 0);
            players[1] = new Player("Team Black", 1);

            //spawn white pieces
            for (int i = 0; i < 8; i++)
            {
                Pawn pawn_1 = new Pawn($"White_{i}", 0, new Point(i, 1), chessImageList.Images[0]);
                Pawn pawn_2 = new Pawn($"Black_{i}", 1, new Point(i, 6), chessImageList.Images[6]);
                DisplayOnBoard(pawn_2);
                DisplayOnBoard(pawn_1);
                players[0].activeChessPieces.Add(pawn_1);
                players[1].activeChessPieces.Add(pawn_2);
            }
            //Rooks
            Rook rook_1 = new Rook("White_1", 0, new Point(0, 0), chessImageList.Images[2]);
            DisplayOnBoard(rook_1);
            players[0].activeChessPieces.Add(rook_1);

            Rook rook_2 = new Rook("White_2", 0, new Point(7, 0), chessImageList.Images[2]);
            DisplayOnBoard(rook_2);
            players[0].activeChessPieces.Add(rook_2);

            Rook rook_3 = new Rook("Black_1", 1, new Point(0, 7), chessImageList.Images[8]);
            DisplayOnBoard(rook_3);
            players[1].activeChessPieces.Add(rook_3);

            Rook rook_4 = new Rook("Black_2", 1, new Point(7, 7), chessImageList.Images[8]);
            DisplayOnBoard(rook_4);
            players[1].activeChessPieces.Add(rook_4);

            //Knighs 
            Knight Knight_1 = new Knight("White_2", 0, new Point(1, 0), chessImageList.Images[1]);
            DisplayOnBoard(Knight_1);
            players[0].activeChessPieces.Add(Knight_1);

            Knight Knight_2 = new Knight("White_2", 0, new Point(6, 0), chessImageList.Images[1]);
            DisplayOnBoard(Knight_2);
            players[0].activeChessPieces.Add(Knight_2);

            Knight Knight_3 = new Knight("Black_1", 1, new Point(1, 7), chessImageList.Images[7]);
            DisplayOnBoard(Knight_3);
            players[1].activeChessPieces.Add(Knight_3);

            Knight Knight_4 = new Knight("Black_2", 1, new Point(6, 7), chessImageList.Images[7]);
            DisplayOnBoard(Knight_4);
            players[1].activeChessPieces.Add(Knight_4);

            //Bishop
            Bishop Bishop_1 = new Bishop("White_2", 0, new Point(2, 0), chessImageList.Images[3]);
            DisplayOnBoard(Bishop_1);
            players[0].activeChessPieces.Add(Bishop_1);

            Bishop Bishop_2 = new Bishop("White_2", 0, new Point(5, 0), chessImageList.Images[3]);
            DisplayOnBoard(Bishop_2);
            players[0].activeChessPieces.Add(Bishop_2);

            Bishop Bishop_3 = new Bishop("Black_1", 1, new Point(2, 7), chessImageList.Images[9]);
            DisplayOnBoard(Bishop_3);
            players[1].activeChessPieces.Add(Bishop_3);

            Bishop Bishop_4 = new Bishop("Black_2", 1, new Point(5, 7), chessImageList.Images[9]);
            DisplayOnBoard(Bishop_4);
            players[1].activeChessPieces.Add(Bishop_4);

            //Queen
            Queen Queen_1 = new Queen("White_2", 0, new Point(4, 0), chessImageList.Images[4]);
            DisplayOnBoard(Queen_1);
            players[0].activeChessPieces.Add(Queen_1);

            Queen Queen_2 = new Queen("Black_1", 1, new Point(4, 7), chessImageList.Images[10]);
            DisplayOnBoard(Queen_2);
            players[1].activeChessPieces.Add(Queen_2);

            //King
            King king_1 = new King("White_2", 0, new Point(3, 0), chessImageList.Images[5]);
            DisplayOnBoard(king_1);
            players[0].activeChessPieces.Add(king_1);

            King king_2 = new King("Black_1", 1, new Point(3, 7), chessImageList.Images[11]);
            DisplayOnBoard(king_2);
            players[1].activeChessPieces.Add(king_2);
        }

        private void DisplayOffBoardPieces()
        {
            flowLayoutPanel.Controls.Clear();
            List<ChessPiece> nonActivePieces = new List<ChessPiece>();
            nonActivePieces.AddRange(players[0].nonActiveChessPieces);
            nonActivePieces.AddRange(players[1].nonActiveChessPieces);

            foreach (var piece in nonActivePieces)
            {             
                Button tmpButton = new Button();
                tmpButton.Image = piece.chessImage;
                tmpButton.BackColor = Color.White;
                tmpButton.Width = 55;
                tmpButton.Height = 55;

                flowLayoutPanel.Controls.Add(tmpButton);
            }
            
        }

        private void DisplayOnBoard(ChessPiece chessPiece)
        {
            board[chessPiece.currentPosition.X, chessPiece.currentPosition.Y].cellButton.Image = chessPiece.chessImage;
        }

        private void ResetDisplayOnBoard(ChessPiece chessPiece)
        {
            board[chessPiece.currentPosition.X, chessPiece.currentPosition.Y].cellButton.Image = null;
        }

        private void ResetBoardColor()
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    board[x, y].cellButton.BackColor = default(Color);
                }
            }
        }
        
        private void NextTeam()
        {
            if (currentTeam == 0)
            {
                currentTeam = 1;
            }
            else
            {
                currentTeam = 0;
            }

            chessLog.DisplayOnListBox($"{players[currentTeam].Name} turn");
        }

        private void OnbuttonPressed(Cell cell)
        {
            //for second player move
            if (players[currentTeam].currentSelected != null)
            {
                //check and get if its button in PosibleHitMoves 
                var isSelected = players[currentTeam]
                    .PosibleHitMoves
                    .Where(x => x == cell.cellPos)
                    .FirstOrDefault()
                    .IfDefaultGiveMe(new Point(-1, -1)); //if its defaullt it return a point outside the grid

 
                if (isSelected == cell.cellPos)
                {
                    //Removes te second move from the pawn 
                    if (players[currentTeam].currentSelected is Pawn)
                    {
                        if (players[currentTeam].currentSelected.hitMoves.Walk.Length == 2)
                        {
                            players[currentTeam].currentSelected.hitMoves.Walk
                            = new Point[] { players[currentTeam].currentSelected.hitMoves.Walk[0] };
                        }
                    }
                    //if player is check ownly king can move 
                    if (players[currentTeam].IsChecked)
                    {
                        if (!(players[currentTeam].currentSelected is King))
                            return;

                    }
 
                    //check if GetChessPiece is not null before making selectedChessPiece
                    if (GetChessPiece(isSelected) != null)
                    {
                        //save the value in a variable 
                        var selectedChessPiece = GetChessPiece(isSelected);
                        //check if other team
                        if (selectedChessPiece is King)
                            return;

                        if (selectedChessPiece.team != currentTeam)
                        {
                            players[selectedChessPiece.team].nonActiveChessPieces.Add(selectedChessPiece);
                            players[selectedChessPiece.team].activeChessPieces.Remove(selectedChessPiece);
                        }

                    }
                    //displays info in log
                    chessLog.DisplayOnListBox($"{players[currentTeam].currentSelected.name}" +
                        $" Moved from [ {players[currentTeam].currentSelected.currentPosition.X.ToString()}" +
                        $"," +
                        $"{players[currentTeam].currentSelected.currentPosition.Y.ToString()} ]" +
                        $" to [ {isSelected.X}" +
                        $"," +
                        $"{isSelected.Y} ]");

                    //remove from board display 
                    ResetDisplayOnBoard(players[currentTeam].currentSelected);
                    //reset currentPosition in chesspiece 
                    players[currentTeam].currentSelected.currentPosition = isSelected;
                    //update board display
                    DisplayOnBoard(players[currentTeam].currentSelected);
                    //reset board colors 
                    ResetBoardColor();
                    //check for win
                    for (int i = 0; i < players.Length; i++)
                    {
                        players[i].IsChecked = Checkmate(i);
                    }
                    //reset hitmove values 
                    players[currentTeam].currentSelected = null;
                    players[currentTeam].PosibleHitMoves = null;
                    //change team
                    NextTeam();
                    // Display Off Board Pieces
                    DisplayOffBoardPieces();
                    return;
                }
            }
            //reset the backcolor 
            ResetBoardColor();
            //get all active chesspieces 
            var combinedLists = players[0].activeChessPieces.Concat(players[1].activeChessPieces);
            //get the current selected chesspiece
            var result = combinedLists
                .Where(x => x.currentPosition == cell.cellPos)
                .FirstOrDefault();
            //if there no chesspiece return
            if (result == null)
                return;

            //check if current chesspiece is correct team
            if (result.team != currentTeam)
                return;
            //check all walk and hit moves possibilities 
            var PosibleHitMoves = new List<Point>();

            PosibleHitMoves.AddRange(CheckHitmoves(result.hitMoves.Walk, result));

            PosibleHitMoves.AddRange(CheckHitmoves(result.hitMoves.TopLeft, result));
            PosibleHitMoves.AddRange(CheckHitmoves(result.hitMoves.Top, result));
            PosibleHitMoves.AddRange(CheckHitmoves(result.hitMoves.TopRight, result));
            PosibleHitMoves.AddRange(CheckHitmoves(result.hitMoves.Right, result));
            PosibleHitMoves.AddRange(CheckHitmoves(result.hitMoves.BotRight, result));
            PosibleHitMoves.AddRange(CheckHitmoves(result.hitMoves.Bot, result));
            PosibleHitMoves.AddRange(CheckHitmoves(result.hitMoves.BotLeft, result));
            PosibleHitMoves.AddRange(CheckHitmoves(result.hitMoves.Left, result));

            //set hitmove values
            DisplayHitmoves(PosibleHitMoves.ToArray(), result);
            players[currentTeam].currentSelected = result;
            players[currentTeam].PosibleHitMoves = PosibleHitMoves;

        }

        private bool Checkmate(int currentTeam)
        {
            //get other team
            int otherTeam = 0;
            if (currentTeam == 0)
            {
                otherTeam = 1;
            }
            //get currentTeam team king 
            var otherKing = players[currentTeam].activeChessPieces.Where(x => x is King).FirstOrDefault();

            List<Point> hitCheckmates = new List<Point>(); 
            for (int i = 0; i < players[otherTeam].activeChessPieces.Count; i++)
            {
                //for every chesspiece check hitmoves
                var chesspiece = players[otherTeam].activeChessPieces[i];
                var hitmoves = new List<Point>();

                hitmoves.AddRange(CheckHitmoves(chesspiece.hitMoves.TopLeft, chesspiece));
                hitmoves.AddRange(CheckHitmoves(chesspiece.hitMoves.Top, chesspiece));
                hitmoves.AddRange(CheckHitmoves(chesspiece.hitMoves.TopRight, chesspiece));
                hitmoves.AddRange(CheckHitmoves(chesspiece.hitMoves.Right, chesspiece));
                hitmoves.AddRange(CheckHitmoves(chesspiece.hitMoves.BotRight, chesspiece));
                hitmoves.AddRange(CheckHitmoves(chesspiece.hitMoves.Bot, chesspiece));
                hitmoves.AddRange(CheckHitmoves(chesspiece.hitMoves.BotLeft, chesspiece));
                hitmoves.AddRange(CheckHitmoves(chesspiece.hitMoves.Left, chesspiece));


                for (int j = 0; j < hitmoves.Count; j++)
                {
                    // check if position is other king      
                    if (hitmoves[j] == otherKing.currentPosition)
                    {
                        hitCheckmates.Add(hitmoves[j]);
                    }
                }
            }
            //if there are no hitmoves with other king position return false
            if (hitCheckmates.Count == 0)
                return false;

            //else other team is checkmate and return true
            chessLog.DisplayOnListBox($"{players[currentTeam].Name} is CheckMate");
            //chessLog.RecetBackColor();
            return true;
        }

        private List<Point> CheckHitmoves(Point[] hitMoves, ChessPiece chessPiece)
        {

            if (hitMoves == null)
                return new List<Point>();

            var result = new List<Point>();

            bool keepLooping = true;
            foreach (Point Hitpos in hitMoves)
            {
                if (!keepLooping)
                    break;

                //light this positions on board
                for (int x = 0; x < 8; x++)
                {
                    for (int y = 0; y < 8; y++)
                    {
                        Point NewHitpos = chessPiece.currentPosition + (Size)Hitpos;

                        //if team is black turn steps 
                        if (chessPiece.team == 1)
                            NewHitpos = chessPiece.currentPosition + new Size(-Hitpos.X, -Hitpos.Y);

                        if (CheckIfPosIsOccupied(NewHitpos))
                        {
                            keepLooping = false;
                            //if is walk hitmove than break
                            if (chessPiece.hitMoves.Walk == hitMoves)
                                break;
                            if (GetChessPiece(NewHitpos).team == chessPiece.team)
                                break;
                        }

                        if (board[x, y].cellPos == NewHitpos)
                        {
                            if (chessPiece is Pawn)
                            {
                                if (chessPiece.hitMoves.TopLeft == hitMoves && !CheckIfPosIsOccupied(NewHitpos))
                                {
                                    break;
                                }
                                if (chessPiece.hitMoves.TopRight == hitMoves && !CheckIfPosIsOccupied(NewHitpos))
                                {
                                    break;
                                }
                            }
                            result.Add(NewHitpos);
                        }

                    }
                }
            }
            return result;
        }

        private void DisplayHitmoves(Point[] hitMoves, ChessPiece chessPiece)
        {
            foreach (Point Hitpos in hitMoves)
            {
                for (int x = 0; x < 8; x++)
                {
                    for (int y = 0; y < 8; y++)
                    {

                        if (board[x, y].cellPos == Hitpos)
                        {
                            board[x, y].cellButton.BackColor = Color.DarkGreen;
                            if (GetChessPiece(Hitpos) is King)
                                board[x, y].cellButton.BackColor = Color.DarkRed;
                        }

                    }
                }
            }
        }

        private bool CheckIfPosIsOccupied(Point pos)
        {
            var combinedLists = players[0].activeChessPieces.Concat(players[1].activeChessPieces);

            var result = combinedLists
                .Where(x => x.currentPosition == pos)
                .FirstOrDefault();

            return (result != null);
        }

        private ChessPiece GetChessPiece(Point pos)
        {
            var combinedLists = players[0].activeChessPieces.Concat(players[1].activeChessPieces);

            var result = combinedLists
                .Where(x => x.currentPosition == pos)
                .FirstOrDefault();

            if (result == null)
                return null;

            return result;
        }

        private Cell GetCell(Point pos)
        {
            var result = from Cell cell in board
                        where cell.cellPos == pos
                         select cell;

            if (result == null)
                return null;

            return result.First();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
