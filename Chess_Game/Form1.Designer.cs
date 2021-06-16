namespace Chest_Game
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.chessImageList = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chessImageList
            // 
            this.chessImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("chessImageList.ImageStream")));
            this.chessImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.chessImageList.Images.SetKeyName(0, "Pawn_White.svg.png");
            this.chessImageList.Images.SetKeyName(1, "Knight_White.svg.png");
            this.chessImageList.Images.SetKeyName(2, "Rook_White.svg.png");
            this.chessImageList.Images.SetKeyName(3, "Bishop_White.svg.png");
            this.chessImageList.Images.SetKeyName(4, "Queen_White.svg.png");
            this.chessImageList.Images.SetKeyName(5, "King_White.svg.png");
            this.chessImageList.Images.SetKeyName(6, "Pawn_Black.svg.png");
            this.chessImageList.Images.SetKeyName(7, "Knight_Black.svg.png");
            this.chessImageList.Images.SetKeyName(8, "Rook_Black.svg.png");
            this.chessImageList.Images.SetKeyName(9, "Bishop_Black.svg.png");
            this.chessImageList.Images.SetKeyName(10, "Queen_Black.svg.png");
            this.chessImageList.Images.SetKeyName(11, "King_Black.svg.png");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(589, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(842, 509);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Chess";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList chessImageList;
        private System.Windows.Forms.Label label1;
    }
}

