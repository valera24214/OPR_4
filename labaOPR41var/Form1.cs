using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace labaOPR41var
{
    public partial class Form1 : Form
    {
        Form2 Form2;

        public Form1()
        {
            InitializeComponent();
        }

        public void no_delay(int MDS, int ExpectoPotronum, int SrokRashoda, int zakaz, out List<int> zapasi)
        {
            List<int> zapas = new List<int>();
            int time = SrokRashoda;

            dataGridView1.RowCount = 91;
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Width = 50;
            for (int i = 1; i <= 3; i++)
            {
                dataGridView1.Columns[i].Width = 70;
            }
            dataGridView1.Columns[0].HeaderText = "День";
            dataGridView1.Columns[1].HeaderText = "Запас";
            dataGridView1.Columns[2].HeaderText = "Расход";
            dataGridView1.Columns[3].HeaderText = "Приход";

            for (int i = 0; i < 90; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = Convert.ToString(i + 1);
                dataGridView1.Rows[i].Cells[2].Value = Convert.ToString(ExpectoPotronum);

                if (i == 0)
                {
                    zapas.Add(MDS);
                    dataGridView1.Rows[i].Cells[1].Value = Convert.ToString(zapas.Last());
                    time -= 1;
                }
                else 
                {
                    zapas.Add(zapas.Last() - ExpectoPotronum);
                    dataGridView1.Rows[i].Cells[1].Value = Convert.ToString(zapas.Last());
                    if (time == 0)
                    {
                        int temp = zapas.Last();
                        zapas.RemoveAt(i);
                        zapas.Add(temp + zakaz);
                        dataGridView1.Rows[i].Cells[3].Value = zakaz;
                        dataGridView1.Rows[i].Cells[1].Value = Convert.ToString(zapas.Last());
                        time = SrokRashoda;
                    }
                    time -= 1;
                }

            }
            zapasi = zapas;
        }

        public void one_delay(int MDS, int ExpectoPotronum, int SrokRashoda, int zakaz, int zader, out List<int> zapasi)
        {
            List<int> zapas = new List<int>();

            int time = SrokRashoda;
            int one = 0;

            dataGridView2.RowCount = 91;
            dataGridView2.ColumnCount = 4;
            dataGridView2.Columns[0].Width = 50;
            for (int i = 1; i <= 3; i++)
            {
                dataGridView2.Columns[i].Width = 70;
            }
            dataGridView2.Columns[0].HeaderText = "День";
            dataGridView2.Columns[1].HeaderText = "Запас";
            dataGridView2.Columns[2].HeaderText = "Расход";
            dataGridView2.Columns[3].HeaderText = "Приход";

            for (int i = 0; i < 90; i++)
            {
                dataGridView2.Rows[i].Cells[0].Value = Convert.ToString(i + 1);
                dataGridView2.Rows[i].Cells[2].Value = Convert.ToString(ExpectoPotronum);

                if (i == 0)
                {
                    zapas.Add(MDS);
                    dataGridView2.Rows[i].Cells[1].Value = Convert.ToString(zapas.Last());
                    time -= 1;
                }
                else
                {
                    zapas.Add(zapas.Last() - ExpectoPotronum);
                    dataGridView2.Rows[i].Cells[1].Value = Convert.ToString(zapas.Last());
                    if (time == 0)
                    {
                        int temp = zapas.Last();
                        zapas.RemoveAt(i);
                        zapas.Add(temp + zakaz);
                        dataGridView2.Rows[i].Cells[3].Value = zakaz;
                        dataGridView2.Rows[i].Cells[1].Value = Convert.ToString(zapas.Last());
                        if (one == 0)
                        {
                            time = SrokRashoda + zader;
                            one -= 1;
                        }
                        else 
                        {
                            time = SrokRashoda;
                        }
                        
                        
                    }
                    time -= 1;
                }

            }

            zapasi = zapas;
        }

        public void delay_delay(int MDS, int ExpectoPotronum, int SrokRashoda, int zakaz, int zader, out List<int> zapasi) 
        {
            List<int> zapas = new List<int>();

            int time = SrokRashoda + zader;

            dataGridView3.RowCount = 91;
            dataGridView3.ColumnCount = 4;
            dataGridView3.Columns[0].Width = 50;
            for (int i = 1; i <= 3; i++)
            {
                dataGridView3.Columns[i].Width = 70;
            }
            dataGridView3.Columns[0].HeaderText = "День";
            dataGridView3.Columns[1].HeaderText = "Запас";
            dataGridView3.Columns[2].HeaderText = "Расход";
            dataGridView3.Columns[3].HeaderText = "Приход";

            for (int i = 0; i < 90; i++)
            {
                dataGridView3.Rows[i].Cells[0].Value = Convert.ToString(i + 1);
                dataGridView3.Rows[i].Cells[2].Value = Convert.ToString(ExpectoPotronum);

                if (i == 0)
                {
                    zapas.Add(MDS);
                    dataGridView3.Rows[i].Cells[1].Value = Convert.ToString(zapas.Last());
                    time -= 1;
                }
                else if(zapas.Last() == 0)
                {
                    zapas.Add(zapas.Last());
                    dataGridView3.Rows[i].Cells[1].Value = Convert.ToString(zapas.Last());
                    dataGridView3.Rows[i].Cells[2].Value = Convert.ToString(0);
                    if (time == 0)
                    {
                        int temp = zapas.Last();
                        zapas.RemoveAt(i);
                        zapas.Add(temp + zakaz);
                        dataGridView3.Rows[i].Cells[3].Value = zakaz;
                        dataGridView3.Rows[i].Cells[1].Value = Convert.ToString(zapas.Last());
                        time = SrokRashoda + zader;
                    }
                    time -= 1;
                }
                else
                {
                    zapas.Add(zapas.Last() - ExpectoPotronum);
                    dataGridView3.Rows[i].Cells[1].Value = Convert.ToString(zapas.Last());
                    if (time == 0)
                    {
                        int temp = zapas.Last();
                        zapas.RemoveAt(i);
                        zapas.Add(temp + zakaz);
                        dataGridView3.Rows[i].Cells[3].Value = zakaz;
                        dataGridView3.Rows[i].Cells[1].Value = Convert.ToString(zapas.Last());
                        time = SrokRashoda + zader;
                    }
                    time -= 1;
                }

            }

            zapasi = zapas;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            int potreb = Convert.ToInt32(textBoxRequirement.Text);//1
            int OptRazZakaza = Convert.ToInt32(Math.Round(Math.Sqrt((2 * Convert.ToDouble(textBoxOptSizeOrder.Text) * potreb) / ((Convert.ToDouble(textBox2.Text) * Convert.ToDouble(textBox3.Text)) / 100))));//2
            int VremPostavki = Convert.ToInt32(textBoxDeliveryTime.Text);//3
            int ZaderZakaza = Convert.ToInt32(textBoxDelayDelivery.Text);//4
            int PotrebDay = Convert.ToInt32(Math.Round(Convert.ToDouble(potreb) / Convert.ToDouble(textBoxWorkDay.Text)));//5
            int SrokRashoda = Convert.ToInt32(Math.Round(Convert.ToDouble(OptRazZakaza) / Convert.ToDouble(PotrebDay)));//6
            int OzhidPotreb = VremPostavki * PotrebDay;//7
            int MaxPotreb = (VremPostavki + ZaderZakaza) * PotrebDay;//8
            int safety_stock = MaxPotreb - OzhidPotreb;//9
            int PorogZapasa = safety_stock + OzhidPotreb;//10
            int MDS = safety_stock + OptRazZakaza;//11
            int SrokRasxodZapsa = (MDS - PorogZapasa) / PotrebDay;//12

            textBox1.Text += "Потребность,шт. - " + potreb + Environment.NewLine +
                "Оптимальный размер заказа, единиц - " + OptRazZakaza + Environment.NewLine +
                "Время поставки, дни - " + VremPostavki + Environment.NewLine +
                "Возможная задержка поставки, дни - " + ZaderZakaza + Environment.NewLine +
                "Ожидаемое дневное потребление, шт./день - " + PotrebDay + Environment.NewLine +
                "Срок расходования заказа, дни - " + SrokRashoda + Environment.NewLine +
                "Ожидаемое потребление за время по-ставки, шт. - " + OzhidPotreb + Environment.NewLine +
                "Максимальное потребление за время поставки, шт. - " + MaxPotreb + Environment.NewLine +
                "Страховой запас, шт. - " + safety_stock + Environment.NewLine +
                "Пороговый уровень запаса, шт. - " + PorogZapasa + Environment.NewLine +
                "Максимальный желательный запас, шт. - " + MDS + Environment.NewLine +
                "Срок расходования запаса до порогово-го уровня, дни, шт. - " + SrokRasxodZapsa + Environment.NewLine;

            no_delay(MDS, PotrebDay, SrokRashoda, OptRazZakaza, out List<int> zapasi1);
            one_delay(MDS, PotrebDay, SrokRashoda, OptRazZakaza, ZaderZakaza, out List<int> zapasi2);
            delay_delay(MDS, PotrebDay, SrokRashoda, OptRazZakaza, ZaderZakaza, out List<int> zapasi3);

            Form2 = new Form2(zapasi1, zapasi2, zapasi3, safety_stock, MDS, PorogZapasa);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2.ShowDialog();
        }
    }
}
