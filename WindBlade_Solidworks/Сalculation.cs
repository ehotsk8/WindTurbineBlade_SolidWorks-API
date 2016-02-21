using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SolidWorks.Interop.sldworks;
using System.Reflection;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private double i = 0.00385,
         E = 0.45,//Коэффициент E берётся равным 0,48 по теории Жуковского для двухлопастных ветроколёс.
         Z = 7,//быстроходность ветроколеса (для двухлопастного принимаем равным 7)
         Pi = Math.PI,//pi — математическая константа, равная отношению длины окружности к длине её диаметра
         L, //длинна окружности
         W,//  частота вращения винта
         H,// Шаг винта 
         alpha, D;
        private double[] YVMet = new double[12];
        private double Bi = 0; //ширина лопасти в каждом сечении
        private List<double> BiList = new List<double>();
        private List<double> alphaList = new List<double>();

        private List<double> YV = new List<double>();
        private List<double> YH = new List<double>();
        private double[] r = { 0, 0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9, 1 };
        private double[] b = { 9, 7, 6.3d, 6.5d, 7, 8, 8, 7.5d, 7, 6, 5 };
        private double[] Y10V = { 3, 5.5, 6.63, 8.05, 9.57, 10, 9.83, 9.28, 8.29, 6.84, 5.21, 3.37, 0 };
        private double[] Y10H = { 0, 0, 0, 0, 0, 0, 0, 0, 0.08, 0.58, 0.81, 1.28, 3 };
        private double[] c1 = { 22, 21, 20, 18, 15, 13, 11, 9, 8, 7.5, 7 };
        private int kk = 0;
        private double[] percent = { 0, .025, .05, .1, .2, .3, 0.4, .5, .6, .7, .8, .9, 1 };
        private double[] percentDown = { 1, .9, .8, .7, .6, .5, .4, .3, .2, .1, .05, 0.025, 0 };
        private List<double> Rx = new List<double>();
        private int kkk = 1;
        private int kkkkk = 0;
        double[] BiPerc = new double[13];

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            D = Math.Sqrt(Convert.ToDouble(textBox1.Text) / (i * Convert.ToDouble(textBox2.Text) * Math.Pow(Convert.ToDouble(textBox3.Text), 3) * E)); //Находим диаметр ветроколеса 
            Result1.Text = D.ToString();
            L = Math.PI * D;//длина окружности (окружность, которую очерчивают концы лопастей ветроколеса)
            Result2.Text = L.ToString();
            W = (Convert.ToDouble(textBox3.Text) / L) * Z * 60;
            Result3.Text = W.ToString();
            H = 30 * ((Convert.ToDouble(textBox3.Text) / W));
            Result4.Text = H.ToString();
            dataGridView1.Rows.Add(b.Length - 1);
            dataGridView3.Rows.Add(Y10H.Length - 1);
            dataGridView4.Rows.Add(Y10V.Length - 1);

            for (double II = 0; II <= 1; II += .1)
                Rx.Add(D / 2 * II);

            //Rx
            foreach (var rxx in Rx)
            {
                dataGridView1.Rows[kk].Cells[3].Value = rxx.ToString("F4");
                kk++;
            }

            //BI 
            kk = 0;
            foreach (var bb in b)
            {
                Bi = (bb * D) / 100;
                BiList.Add(Bi);
                dataGridView1.Rows[kk].Cells[0].Value = r[kk];
                dataGridView1.Rows[kk].Cells[1].Value = Bi.ToString("F4");
                kk++;
            }

            //alpha
            kk = 0;
            foreach (var rr in r)
            {
                alpha = Math.Atan((2 * H) / (Pi * rr * D));
                alphaList.Add(alpha);
                dataGridView1.Rows[kk].Cells[2].Value = (alpha * (180 / Math.PI) + 90).ToString("F4");
                kk++;
            }

            //расчет точек
            for (int count = 0; count < 11; count++)
            {
                Y10Data(dataGridView4, Y10V, true, count, false, percent);
                Y10Data(dataGridView3, Y10H, false, count, true, percentDown);
            }
        }

        private double[] BiPercent(double[] percent, int count)
        {
            int ll = 0;
            foreach (var p in percent)
            {
                BiPerc[ll] = BiList[count] * p;
                ll++;
            }
            return BiPerc;
        }

        private void Y10Data(DataGridView dg, double[] Y10, bool newSketch, int count, bool down, double[] percent)
        {
            kk = 0;

            foreach (var array in Y10)
            {
                //заполнение таблиц
                dg.Rows[kk].Cells[kkkkk].Value = BiPercent(percent, count)[kk].ToString("F4");
                dg.Rows[kk].Cells[kkk].Value = Y10Method(array, c1, BiList, alphaList)[count].ToString("F4");
                kk++;
            }

            if (down)
            {
                kkkkk += 2;
                kkk += 2;
                kk = 0;
            }
        }

        private double[] Y10Method(double Y10, double[] c1, List<double> Bi, List<double> alpha)
        {
            for (int counter = 0; counter < 11; counter++)
                YVMet[counter] = (Y10 * c1[counter] * Bi[counter]) / (1000 * Math.Cos(alpha[counter]));
            return YVMet;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Form2() { Visible = true }; //Создаем экземпляр формы
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new WindSpeed() { Visible = true }; //Создаем экземпляр формы
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Density() { Visible = true }; //Создаем экземпляр формы
        }

        private async void drawButton_Click(object sender, EventArgs e)
        {
            await Task.Run(() => DrawBladeAsync());
        }

        //построение
        private async Task DrawBladeAsync()
        {
            var draw = new DrawBlade();
            draw.CreateDoc();
            var planeNum = 0;
            var coordinatesUp = GetCoordFromTable(dataGridView4);
            var coordinatesDown = GetCoordFromTable(dataGridView3);

            for (var column = 2; column < 22; column += 2)
            {
                draw.AddPlane(planeNum + 4, Rx[planeNum]);
                foreach (var coord in coordinatesUp)
                    draw.PointList(draw.AddPoint(coord[column], coord[column + 1]));
                foreach (var coord in coordinatesDown)
                    draw.PointList(draw.AddPoint(coord[column], coord[column + 1]));
                draw.DrawSpline(draw.GetPoints());
                draw.AddCenterLine(draw.GetPoints());
                draw.AddCoinsident();
                draw.ClearPoints();
                draw.DeleteVertical();
                draw.RotateToDegree(alphaList[planeNum], planeNum);
                draw.RemoveCoincident();
                draw.SketchToCenter(planeNum);
                planeNum++;
            }
            draw.CreateBlend(Rx.ToArray());

            draw.CenterCircle(coordinatesUp[12][0]);

            draw.SelectFront();
            foreach (var coord in coordinatesUp)
                draw.PointList(draw.AddPoint(coord[2], coord[2 + 1]));
            foreach (var coord in coordinatesDown)
                draw.PointList(draw.AddPoint(coord[2], coord[2 + 1]));
            draw.DrawSpline(draw.GetPoints());
            draw.AddCenterLine(draw.GetPoints());
            draw.AddCoinsident();
            draw.ClearPoints();
            draw.DeleteVertical();
            draw.RotateToDegree(alphaList[0], 12);
            draw.RemoveCoincident();
            draw.SketchToCenter(12);
            draw.ConnectOnCircle();

            draw.AddMirror(int.Parse(CountTextBox.Text));
            draw.AddChamfer();
            await Task.Delay(1);
        }

        //вытаскиваем координаты точек из таблицы для построения
        private List<List<double>> GetCoordFromTable(DataGridView dg)
        {
            var rowValue = new List<double>();
            var coordinates = new List<List<double>>();
            foreach (DataGridViewRow row in dg.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                    rowValue.Add(Double.Parse(cell.Value.ToString()));
                coordinates.Add(rowValue);
                rowValue = new List<double>();
            }
            return coordinates;
        }
    }
}



