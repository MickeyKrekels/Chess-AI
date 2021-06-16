using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Chest_Game
{
   public class ChessLog
    {
        public Queue<string> logQueue = new Queue<string>();
        public ListBox listBox;
        private Color defaultColor;

        public ChessLog(ListBox listBox)
        {
            this.listBox = listBox;
            defaultColor = listBox.BackColor;
        }

        public void AddLogQue(string input)
        {
            logQueue.Enqueue(input);
        }

        public string GetDataString()
        {
            string output = "";
            foreach (string log in logQueue)
            {
                output += log;
            }
            return output;
        }

        public void DisplayOnListBox(string input)
        {
            listBox.Items.Add(input);
            int visibleItems = listBox.ClientSize.Height / listBox.ItemHeight;
            listBox.TopIndex = Math.Max(listBox.Items.Count - visibleItems + 1, 0);
        }

        public void RecetBackColor()
        {
            listBox.BackColor = defaultColor;
        }
    }
}
