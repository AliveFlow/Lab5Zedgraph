using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using ZedGraph;

namespace Lab_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Левая граница, Правая граница, Количество точек, Шаг.
        double RBord = 0.0, LBord = 0.0, step_ = 0.0;
        int dots_ = 0;

        // Степень полинома
        int PowerPol = 0;

        // Точки функции
        PointPairList LIST = new PointPairList();

        // Исходная функция
        public double calcFun(double x)
        {
            return (x * Math.Sin(x) + Math.Exp(-x) * x * x * Math.Cos(x));
     
        }

        LineItem curve1;
        GraphPane pane;

        // Вспомогательный массив с коэффициентами
        double[] ArrKoef = null;


        // Функция построения прямой, где A - это массив с коэффициентами
        private double Y(double x, double[] A)
        {
            double y = 0.0;
            for (int i = 0; i < A.Length; i++)
                y += A[i] * Math.Pow(x, i);
            return y;
        }
        // Определим систему по МНК
        double[] MNK(PointPairList list)
        {
            double[] A = new double[PowerPol + 1]; // Матрица коэффициентов многочлена
            double[,] arr = new double[PowerPol + 1, PowerPol + 2]; // Расширенная матрица
            for (int i = 0; i < PowerPol + 1; i++)
            {
                for (int j = 0; j < PowerPol + 1; j++)
                {
                    arr[i, j] = 0;
                    for (int z = 0; z < list.Count; z++)
                        arr[i, j] += Math.Pow(list[z].X, i + j); //заполняем левую часть системы
                }
                for (int j = 0; j < list.Count; j++)
                    arr[i, PowerPol + 1] += list[j].Y * Math.Pow(list[j].X, i); //заполняем правую часть системы
            }
            M_Gauss(arr, ref A);
            return A;
        }
        //Оперделим решение системы по методу Гаусса через ведущий элемент
        private void M_Gauss(double[,] arr, ref double[] a)
        {
            try
            {
                int n = a.Length; // Размер несовместной матрицы
                double diag_el = 0.0, x = 0;
                // Преобразуем матрицу к ступенчатому виду
                for (int i = 0; i < n; i++)
                {
                    Max_elem(arr, n, i);
                    diag_el = arr[i, i];
                    // Преобразуем i-ю строку  
                    if (diag_el != 0)
                        for (int j = 0; j < n + 1; j++)
                            arr[i, j] /= diag_el;  //ключевые коэффициенты i-му по столбцу вниз
                    // Сделаем под элементом главной диагонали i-го столбца нули
                    for (int j = i + 1; j < n; j++)
                    {
                        double temp = arr[j, i]; //
                        for (int k = 0; k < n + 1; k++)
                            arr[j, k] -= temp * arr[i, k]; //последовательно вычитаем из первых элементов первого столбца(начиная со второй строки) ключевые коэффициенты домноженные на первые элементы итд.
                    }
                }
                // Найдём значения коэффициентов
                for (int i = n - 1; i >= 0; i--) //идем с конца системы
                {
                    // Начальное значение i-ой переменной (идем с конца)
                    x = arr[i, n];
                    // Корректировка начального значения
                    for (int j = i + 1; j < n; j++)
                        x -= a[j] * arr[i, j];  //применение реккурентной формулы
                    a[i] = x;
                    if (Double.IsNaN(x) || Double.IsInfinity(x))
                    throw new Exception("Ошибка расчетов. Полученные значения не являются числами. Попробуйте изменить степень полинома и проверьте входные данные.");
                    
                }
            }
            catch (Exception m)
            {
                MessageBox.Show(m.Message);
            }
        }
        // Поиск максимального элемента массива в i-м столбце; arr - совмещенная матрица, n - размер несовмещенной матрицы, i - индекс стобца
        private void Max_elem(double[,] arr, int n, int i)
        {
            int inx_max = i;
            for (int j = i + 1; j < n; j++)
            {
                if (Math.Abs(arr[inx_max, i]) < Math.Abs(arr[j, i]))
                    inx_max = j;
            }
            if (inx_max != i)
                Swap(arr, n, i, inx_max);
        }
        // Меняем строки местами. n - размер несовмещенной матрицы, int row1, row2 - номера строк
        private void Swap(double[,] arr, int n, int row1, int row2)
        {
            double temp = 0;
            for (int i = 0; i < n + 1; i++)
            {
                temp = arr[row1, i];
                arr[row1, i] = arr[row2, i];
                arr[row2, i] = temp;
            }
        }

        private void CreateGraph(ZedGraphControl zgc)
        {
            // Зададим панель для графика
            pane = zgc.GraphPane;
            zgc.AutoSize = false; pane.XAxis.Scale.MaxAuto = true;
            pane.XAxis.Scale.MinAuto = true;
            pane.YAxis.Scale.MaxAuto = true;
            pane.YAxis.Scale.MinAuto = true;
            // Установка масштаба 
            pane.XAxis.Scale.Min = LBord;
            pane.XAxis.Scale.Max = RBord;
            pane.XAxis.Scale.Format = "F2";
            pane.XAxis.Scale.FontSpec.Size = 12;
            pane.YAxis.Scale.FontSpec.Size = 12;
            // Очистим список кривых на тот случай, если до этого что-то уже было нарисовано
            pane.CurveList.Clear();
            // Заголовки
            pane.Title.Text = "График";
            pane.XAxis.Title.Text = pane.XAxis.Title.Text = "Ось X";
            pane.YAxis.Title.Text = pane.YAxis.Title.Text = "Ось Y";
        }

        private void but_Enter_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Вводим и проверяем данные
                RBord = double.Parse(tb_RightBorder.Text);
                LBord = double.Parse(tb_LeftBorder.Text);
                dots_ = int.Parse(tb_Step.Text);
                PowerPol = int.Parse(tb_PolPow.Text);

                double step_ = (RBord - LBord ) / (dots_ - 1);


                if (LBord > RBord)
                    throw new Exception("Значение правой границы не должно быть меньше значения левой границы!");
                if (RBord - LBord < 0.0001)
                    throw new Exception("Значение правой границы не должно быть равно значению левой границы!");

               /* if (PowerPol > 7600)
                    throw new Exception("Слишком большая степень полинома!");*/

                if (dots_- (int)dots_ != 0)
                    throw new Exception("Кол-во точек должно быть целым числом!");
                if (dots_ >10000)
                    throw new Exception("Слишком большое кол-во точек.");
                if (PowerPol <= 0)
                    throw new Exception("Cтепень полинома должна быть больше нуля!");

                StreamWriter SW = new StreamWriter("points.txt");
 
                double y;
                double x = LBord;
                int k = 0;
                while (x <= RBord)
                {
                    y = calcFun(x);
                    if (Double.IsNaN(calcFun(x)) || Double.IsInfinity(calcFun(x)))
                        throw new Exception("Ошибка расчетов. Полученные значения не являются числами. Попробуйте изменить степень полинома и проверьте входные данные.");
                    SW.WriteLine(x + " " + y);

                    x += step_;
                    k++;
                }
                if (k != dots_)
                {
                    y = calcFun(RBord);
                    SW.WriteLine(RBord + " " + y);
                }

                /*for (double x = LBord; x <= RBord; x += step_)
                {
                    SW.WriteLine(x + " " + calcFun(x));
                    if (Double.IsNaN(calcFun(x)) || Double.IsInfinity(calcFun(x)))
                    throw new Exception("Ошибка расчетов. Полученные значения не являются числами. Попробуйте изменить степень полинома и проверьте входные данные.");
                 
                }*/

                SW.Close();
            }
            catch (Exception mes)
            {
                MessageBox.Show(mes.Message);
            }
           

        }

        private void but_Build_Click(object sender, EventArgs e)
        {
            tb_X.Clear();
            tb_Y.Clear();
            try
            {
                
                LIST.Clear();
                pane = zedGraphControl1.GraphPane;
                pane.CurveList.Clear();
                zedGraphControl1.AxisChange();
                zedGraphControl1.Invalidate();
                
                // Считываем значение функции из файла
                StreamReader SR_ = new StreamReader("points.txt");
                string rawData = SR_.ReadToEnd();
                SR_.Close();

                // Записываем данные в массив DataSave
                string[] DataSave = rawData.Split(' ', '\n', '\r');

                // Заполняем массив точек
                LIST.Clear();
                for (int i = 0; i < DataSave.Length - 1; i++)
                {
                    if (DataSave[i] != "")
                    {
                        Convert.ToDouble(DataSave[i]);
                    }
                    if (DataSave[i] != "" && DataSave[i + 1] != "")
                    {
                        LIST.Add(Convert.ToDouble(DataSave[i]), Convert.ToDouble(DataSave[i + 1]));
                    }
                }

                // Проверяем входные данные
                if (LIST.Count < 2)
                {
                    throw new Exception("Невозможно построить график по одной точке");
                }
               
                LIST.Sort();
                for (int i = 0; i < LIST.Count - 1; i++)
                {
                    if (LIST[i].X == LIST[i + 1].X && LIST[i].Y != LIST[i + 1].Y) throw new ApplicationException("Обнаружены одинаковые X для разных Y");
                }

                if (LIST.Count == 1)
                {
                    throw new Exception("Невозможно построить график по одной точке");
                }
                PowerPol = int.Parse(tb_PolPow.Text);
                if (PowerPol == 0)
                {
                    throw new Exception("Выберите степень интерполяции");
                }
                if (PowerPol > LIST.Count)
                {
                    throw new Exception("Степень интерполяции должна быть мeньше количества точек");
                }
                
                //Проверим границы графика
                RBord = LIST[LIST.Count - 1].X;
                LBord = LIST[0].X;
                
                CreateGraph(zedGraphControl1);
                //Строим график
                Draw(LIST);
                ArrKoef = MNK(LIST);
                //Построим полученную прямую
                Draw_line(ArrKoef);
            }
            catch (Exception mes)
            {
                MessageBox.Show(mes.Message);
            }
        }

        private void but_Calc_Click(object sender, EventArgs e)
        {
            try
            {
                PointPairList PPL_ = new PointPairList();
                double x = double.Parse(tb_X.Text);
                if (x < LBord || x > RBord)
                    throw new Exception("Значение Х не входит в введённый интервал!");
                double y = Y(x, ArrKoef);
                tb_Y.Text = string.Format("{0:F6}", y);
                //Строим прямые к найденной точке
                
                curve1.Clear();
                Draw(LIST);
                Draw_line(ArrKoef);

                /*line.Add(LBord, y);
                line.Add(x, y);
                line.Add(x, 0);
                curve1 = pane.AddCurve("", line, Color.DeepSkyBlue, SymbolType.Circle);
                curve1.Line.Width = 3;*/

                PPL_.Add(x, y);
                LineItem graph = zedGraphControl1.GraphPane.AddCurve("", PPL_, Color.Blue, SymbolType.Circle);
                graph.Symbol.Border.Width = 2;

                // Вызываем метод AxisChange(), чтобы обновить данные об осях.
                zedGraphControl1.AxisChange();
                // Обновляем график
                zedGraphControl1.Invalidate();
            }
            catch (Exception mes)
            {
                MessageBox.Show(mes.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void tb_Y_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("C:\\Users\\Боженька\\Desktop\\labvm4my\\WindowsFormsApp1\\bin\\Debug\\points.txt");
        }

        private void zedGraphControl1_Load(object sender, EventArgs e)
        {

        }

        private void tb_X_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Draw(PointPairList list)
        {
            //Готовим массив с точками
            list.TrimExcess();
            list.Sort();
            try
            {
                pane.CurveList.Clear();
                //Подписываем график
                curve1 = pane.AddCurve("y(x)", list, Color.Green, SymbolType.None);
                curve1.Line.Width = 2;
                // Вызываем метод AxisChange(), чтобы обновить данные об осях.
                zedGraphControl1.AxisChange();
                // Обновляем график
                zedGraphControl1.Invalidate();
            }
            catch (Exception m)
            {
                MessageBox.Show(m.Message);
            }
        }
        private void Draw_line(double[] A)
        {
            try
            {
                PointPairList list = new PointPairList();//Создаём лист с точками
                //Вычисляем значение прямой
                for (double x = LBord; x < RBord; x += (RBord - LBord) / 100)
                    list.Add(x, Y(x, A));
                list.Sort();
                //Подписываем график
                curve1 = pane.AddCurve("Аппроксимация", list, Color.OrangeRed, SymbolType.None);
                curve1.Line.Width = 2;
                // Вызываем метод AxisChange(), чтобы обновить данные об осях.
                zedGraphControl1.AxisChange();
                // Обновляем график
                zedGraphControl1.Invalidate();
            }
            catch (Exception m)
            {
                MessageBox.Show(m.Message);
            }
        }
    }
}
