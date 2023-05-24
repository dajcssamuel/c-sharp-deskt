using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vizsga_desk
{
    public partial class Form1 : Form
    {
        List<Seged> sorsolas_list = new List<Seged>();
        List<Szam> szamok = new List<Szam>();
        public Form1()
        {
            InitializeComponent();
            string[] lines = File.ReadAllLines("sorsolas.txt");
            foreach (var item in lines)
            {
                string[] values = item.Split(';');
                Seged sorsolas_object = new Seged(values[0], values[1], values[2], values[3], values[4], values[5]);
                sorsolas_list.Add(sorsolas_object);
            }
            label1.Visible = false;

            //3. feladat

            int db = 0;
            for (int i = 1; i < 91; i++)
            {
                foreach (var item in sorsolas_list)
                {
                    if (i == item.sz1 || i == item.sz2 || i == item.sz3 || i == item.sz4 || i == item.sz5)
                        db++;
                }
                Szam szam_object = new Szam(i, db);
                szamok.Add(szam_object);
                db = 0;
            }

            int max = int.MinValue;
            int legnagyobb = 0;
            foreach (var item in szamok)
            {
                if (max < item.db)
                {
                    max = item.db;
                    legnagyobb = item.szam;
                }
            }
            label2.Text = $"Legtöbbet kihúzott szám: {legnagyobb}";


            foreach (var item in szamok)
            {
                dataGridView1.Rows.Add(item.szam, item.db);
            }

        }
        //1.feladat
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var item in sorsolas_list)
            {
                if (numericUpDown1.Value == item.het)
                {
                    label1.Visible = true;
                    label1.Text = $" {item.het}. hét nyerőszámai: {item.sz1},{item.sz2},{item.sz3},{item.sz4},{item.sz5}";

                }
            }
        }
    }
}
