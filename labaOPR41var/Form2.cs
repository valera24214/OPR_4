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
    public partial class Form2 : Form
    {
        List<int> zapas1 = new List<int>();
        List<int> zapas2 = new List<int>();
        List<int> zapas3 = new List<int>();
        int porog = 0;
        int safety = 0;
        int MDS = 0;

        public Form2(List<int> zapas1, List<int> zapas2,List<int> zapas3, int safety_stock, int MDS, int porog)
        {
            InitializeComponent();
            this.zapas1 = zapas1;
            this.zapas2 = zapas2;
            this.zapas3 = zapas3;
            this.safety = safety_stock;
            this.MDS = MDS;
            this.porog = porog;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            double[] days = new double[90];
            for (int i = 1; i <= 90; i++)
            {
                days[i - 1] = i;
            }

            double[] zap1 = new double[zapas1.Count];
            for (int i = 0; i < zapas1.Count; i++)
            {
                zap1[i] = (double)zapas1[i];
            }
            
            double[] zap2 = new double[zapas2.Count];
            for (int i = 0; i < zapas2.Count; i++)
            {
                zap2[i] = (double)zapas2[i];
            }
            
            double[] zap3 = new double[zapas3.Count];
            for (int i = 0; i < zapas3.Count; i++)
            {
                zap3[i] = (double)zapas3[i];
            }

            formsPlot1.Plot.Title("Движение запасов с фиксированным размером заказа");
            formsPlot1.Plot.XLabel("Дни");
            formsPlot1.Plot.YLabel("Запасы");

            var line = formsPlot1.Plot.AddHorizontalLine(MDS);
            line.LineStyle = ScottPlot.LineStyle.DashDotDot;
            line.LineWidth = 1;
            line.Color = Color.Black;

            var line2 = formsPlot1.Plot.AddHorizontalLine(safety);
            line2.LineStyle = ScottPlot.LineStyle.DashDotDot;
            line2.LineWidth = 1;
            line2.Color = Color.Black;

            var line3 = formsPlot1.Plot.AddHorizontalLine(porog);
            line3.LineStyle = ScottPlot.LineStyle.DashDotDot;
            line3.LineWidth = 1;
            line3.Color = Color.Black;

            var p1 = formsPlot1.Plot.AddScatter(days, zap1);
            p1.LineWidth = 4;
            p1.Color = Color.Green;
            p1.Label = "Без задержек";

            var p2 = formsPlot1.Plot.AddScatter(days, zap2);
            p2.LineWidth = 2;
            p2.Color = Color.Orange;
            p2.LineStyle = ScottPlot.LineStyle.Dash;
            p2.Label = "С однократными задержками";
            
            var p3 = formsPlot1.Plot.AddScatter(days, zap3);
            p3.LineWidth = 2;
            p3.Color = Color.Blue;
            p3.LineStyle = ScottPlot.LineStyle.Dot;
            p3.Label = "С многократными задержками";

            formsPlot1.Plot.Legend();
            formsPlot1.Refresh();
        }
    }
}
