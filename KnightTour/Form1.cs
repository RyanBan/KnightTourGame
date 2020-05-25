using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* 
 * File:   Form1.cs
 * Author: Seunghyun Ban
 * Created on May 13, 2019, 12:31 PM
 */

namespace Assignment1
{
    public partial class Form1 : Form
    {
        static string path;
        //initial cell does not cahnge untill we click another position
        Cell initialCell;
        Cell newCell;

        public Form1()
        {
            InitializeComponent();
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
        }
        private void tableLayoutPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            tableLayoutPanel1.Controls.Clear();
            button1.Enabled = true;
            button2.Enabled = true;

            //get position of cell that user click on the table
            int x = 0;
            int verticalOffset = 0;
            foreach (int h in tableLayoutPanel1.GetRowHeights())
            {
                int y = 0;
                int horizontalOffset = 0;
                foreach (int w in tableLayoutPanel1.GetColumnWidths())
                {
                    Rectangle rectangle = new Rectangle(horizontalOffset, verticalOffset, w, h);
                    if (rectangle.Contains(e.Location))
                    {                       
                        MessageBox.Show ("You select" + " ("+ x +", "+ y +") " + "!! Let's start game!" );

                        initialCell = new Cell(x, y);                
                    }
                    horizontalOffset += w;
                    y++;
                }
                verticalOffset += h;
                x++;
            }
        }
        //button for nonInterlligent method
        private void button1_Click(object sender, EventArgs e)
        {
            path = @"..\..\SeunghyunBanNonIntelligentMethod.txt";
            File.WriteAllText(path, "");

            int time = Int32.Parse(textBox1.Text);
        
            int valueOnTable = 0;
            while (time > 0) {
                int count = 0;

                Cell[,] board = new Cell[8, 8];
                NonIntellegentMode nonIN = new NonIntellegentMode();

                board = nonIN.Initialize();
                if (count == 0)
                    newCell = initialCell;

                board[newCell.X, newCell.Y].value = ++count;
                tableLayoutPanel1.Controls.Clear();

                displayValue(count);
                ArrayList list;

                do
                {
                    list = nonIN.PossibleRoutes(newCell.X, newCell.Y);
                    Random r = new Random();
                    int way = r.Next(list.Count);
                    if (list.Count > 0)
                    {
                        //Console.WriteLine("Random: " + a);
                        newCell = (Cell)list[way];
                        board[newCell.X, newCell.Y].value = ++count;
                        if (time == 1)
                        {
                            displayValue(count);
                        }
                    }
                    else
                        break;           
                } while (list.Count > 0);
                valueOnTable++;               
                writeTotxt(path, valueOnTable, count);     
                time--;
            }
            button3.Enabled = true;    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            path = @"..\..\SeunghyunBanHeuristicsMethod.txt";
            File.WriteAllText(path, "");
            int time = Int32.Parse(textBox1.Text);
            int valueOnTable = 0;
            while (time > 0)
            {
                int count = 0;
                
                Cell[,] board = new Cell[8, 8];
                HeuristicMode IN = new HeuristicMode();

                board = IN.Initialize();
                if (count == 0)
                    newCell = initialCell;
               
                board[newCell.X, newCell.Y].value = ++count;

                tableLayoutPanel1.Controls.Clear();
                displayValue(count);

                ArrayList list;
                do
                {
                    list = IN.PossibleRoutes(newCell.X, newCell.Y);
                    Random r = new Random();
                    int way = r.Next(list.Count);

                    if (list.Count > 0)
                    {
                        //Console.WriteLine("Random: " + a);
                        newCell = (Cell)list[way];
                        board[newCell.X, newCell.Y].value = ++count;
                        if (time == 1)
                        {
                            displayValue(count);
                        }
                    }
                    else
                        break;
                    
                } while (list.Count > 0);
                valueOnTable++;
                writeTotxt(path, valueOnTable, count);
                time--;
            }
            //string textFile = ""
            button3.Enabled = true;
        }

        public void displayValue(int count)
        {
            Label tour_number = new Label();

            if (count.GetType().Equals(typeof(int)))
                tour_number.Text = count.ToString();
            else
                MessageBox.Show("Please enter Integer");

            tour_number.AutoSize = true;
            tour_number.BackColor = Color.Transparent;
            tour_number.Anchor = AnchorStyles.None;
            tableLayoutPanel1.Controls.Add(tour_number, newCell.Y, newCell.X);
        }

        public void writeTotxt(string path, int count, int cou)
        {
            if (File.Exists(path))
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine("Trial {0}: The knight was able to successfully touch {1} squares.", count, cou);
                }
            }
            else
                MessageBox.Show("File does not exit", "File IO error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start("notepad.exe", path);
        }

        private void tableLayoutPanel1_CellPaint_1(object sender, TableLayoutCellPaintEventArgs e)
        {
            if ((e.Column + e.Row) % 2 == 1)
                e.Graphics.FillRectangle(Brushes.Beige, e.CellBounds);
            else
                e.Graphics.FillRectangle(Brushes.White, e.CellBounds);
        }
    }
}
