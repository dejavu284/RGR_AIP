using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public int flag;
        public int Row, Col;
        public double[,] two_array;
        public Random rnd = new Random();
        public bool is_exist_array = false;
        public int number_start = -10;
        public int number_end = 10;
        public SaveFileDialog saveFileDialog1 = new SaveFileDialog();
        public OpenFileDialog openFileDialog1 = new OpenFileDialog();

        public Form1()
        {
            InitializeComponent();
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tb_rows_Click(object sender, EventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Range_random_values_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void count_columns_TextChanged(object sender, EventArgs e)
        {
            bool flag = int.TryParse(count_columns.Text, out Col);
        }

        private void number_start_TextChanged(object sender, EventArgs e)
        {
            bool flag = int.TryParse(Start.Text, out number_start);
        }

        private void End_TextChanged(object sender, EventArgs e)
        {
            bool flag = int.TryParse(End.Text, out number_end);
        }
        private void Exercise_1_CheckedChanged(object sender, EventArgs e)
        {
            string TaskText = "Найти строку с максимальным элементом и отсортировать её по возрастанию. " +
                              "Вывести номер строки с максимальным элементом (отсортированной строкой).";
            print_results.Text = TaskText;

            flag = 1;

        }
        private void Exercise_2_CheckedChanged(object sender, EventArgs e)
        {
            string TaskText = "Сгенерировать матрицу (N != M) и заполнить вещественными числами " +
                   "(положительными и отрицательными). Реализовать алгоритм нахождения обратной " +
                   "матрицы и вывести обратную матрицу.";
            print_results.Text = TaskText;

            flag = 2;
        }
        private void Exercise_3_24_CheckedChanged(object sender, EventArgs e)
        {
            string TaskText = "Сгенерировать квадратную (N≥5, M≥5) матрицу и заполнить вещественными числами " +
            "(положительными и отрицательными) в диапазоне от -2 до 2." +
            " Найти произведение элементов каждого столбца и вывести их в виде дополнительной строки матрицы.";
            print_results.Text = TaskText;

            flag = 3;
        }
        private void Exercise_4_33_CheckedChanged(object sender, EventArgs e)
        {
            string TaskText = "Сгенерировать матрицу и заполнить вещественными числами" +
                " (положительными и отрицательными). В матрицы найти минимальное" +
                " и максимальное значение и поменять их местами.";
            print_results.Text = TaskText;

            flag = 4;
        }
        private void Exercise_5_42_CheckedChanged(object sender, EventArgs e)
        {
            string TaskText = "Сгенерировать квадратную матрицу с четным количеством строк " +
                "и заполнить вещественными числами (положительными и отрицательными). " +
                "Поменять местами элементы главной и побочной диагонали в четных строках. ";
            print_results.Text = TaskText;

            flag = 5;
        }
        private void Create_array(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                dataGridView1.RowHeadersVisible = false;
                dataGridView1.ColumnHeadersVisible = false;
                dataGridView1.RowCount = Row;
                dataGridView1.ColumnCount = Col;

                for (int i = 0; i < Row; i++)
                {
                    dataGridView1.Rows[i].Height = 30;
                }
                for (int i = 0; i < Col; i++)
                {
                    dataGridView1.Columns[i].Width = 50;
                }
                if (count_rows.Text.Length > 0 && count_columns.Text.Length > 0)
                {
                    int number_between = number_end - number_start;
                    two_array = new double[Row, Col];
                    for (int i = 0; i < Row; i++)
                    {
                        for (int j = 0; j < Col; j++)
                        {
                            two_array[i, j] = number_start + rnd.NextDouble() * number_between;
                            dataGridView1.Rows[i].Cells[j].Value = string.Format("{0:0.00}", two_array[i, j]);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Вы не ввели количество строк и/или столбцов!",
                                "Внимание",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Asterisk,
                                MessageBoxDefaultButton.Button1);
            }
        }
        private void Complete_task_Click(object sender, EventArgs e)
        {

            switch (flag)
            {
                case 1:
                    try
                    {
                        int IndexRow = -1;
                        double MaxValue = double.MinValue;

                        for (int i = 0; i < Row; i++)
                        {
                            for (int j = 0; j < Col; j++)
                            {
                                if (two_array[i, j] > MaxValue)
                                {
                                    MaxValue = two_array[i, j];
                                    IndexRow = i;
                                }
                            }
                        }

                        for (int i = 0; i < Col; i++)
                        {
                            for (int j = 1; j < Col - i; j++)
                            {
                                if (two_array[IndexRow, j - 1] > two_array[IndexRow, j]) (two_array[IndexRow, j - 1], two_array[IndexRow, j]) = (two_array[IndexRow, j], two_array[IndexRow, j - 1]);
                            }
                        }

                        dataGridView1.Rows.Clear();
                        dataGridView1.Columns.Clear();
                        dataGridView1.RowCount = Row;
                        dataGridView1.ColumnCount = Col;

                        for (int i = 0; i < Row; i++)
                        {
                            dataGridView1.Rows[i].Height = 30;
                        }
                        for (int i = 0; i < Col; i++)
                        {
                            dataGridView1.Columns[i].Width = 50;
                        }

                        for (int i = 0; i < Row; i++)
                        {
                            for (int j = 0; j < Col; j++)
                            {
                                dataGridView1.Rows[i].Cells[j].Value = string.Format("{0:0.00}", two_array[i, j]);
                            }
                        }
                        print_results.Text = string.Format("Вывести номер строки с максимальным элементом = {0}", IndexRow);
                    }
                    catch
                    {
                        MessageBox.Show("Вы не ввели количество строк и/или столбцов!",
                                        "Внимание",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Asterisk,
                                        MessageBoxDefaultButton.Button1);
                    }
                    break;

                case 2:
                    //try
                    //{
                    //    if (Row == Col)
                    //    {
                    //        throw new AggregateException();
                    //    }
                    //    dataGridView1.Rows.Clear();
                    //    dataGridView1.Columns.Clear();
                    //    dataGridView1.RowHeadersVisible = false;
                    //    dataGridView1.ColumnHeadersVisible = false;
                    //    dataGridView1.RowCount = Row;
                    //    dataGridView1.ColumnCount = Col;

                    //    for (int i = 0; i < Row; i++)
                    //    {
                    //        dataGridView1.Rows[i].Height = 30;
                    //    }
                    //    for (int i = 0; i < Col; i++)
                    //    {
                    //        dataGridView1.Columns[i].Width = 50;
                    //    }

                    //    for (int i = 0; i < Row; i++)
                    //    {
                    //        for (int j = 0; j < Col; j++)
                    //        {
                    //            two_array[i, j] = (number_start + rnd.NextDouble() * 3) * Math.Pow(-1,j);
                    //            dataGridView1.Rows[i].Cells[j].Value = string.Format("{0:0.00}", two_array[i, j]);
                    //        }
                    //    }
                    //    print_results.Text = string.Format("Обратная матрица выведена на экране.");
                    //}
                    //catch (AggregateException)
                    //{
                    //    MessageBox.Show("Не удовлетворяет условию задания, повторите попытку",
                    //            "Внимание",
                    //        MessageBoxButtons.OK,
                    //        MessageBoxIcon.Asterisk,
                    //        MessageBoxDefaultButton.Button1);
                    //}
                    //catch
                    //{
                    //    MessageBox.Show("Вы не ввели количество строк и/или столбцов!",
                    //                    "Внимание",
                    //                    MessageBoxButtons.OK,
                    //                    MessageBoxIcon.Asterisk,
                    //                    MessageBoxDefaultButton.Button1);
                    //}

                    MessageBox.Show("Понятие обратной матрицы существует только для квадратных матриц, " +
                            "матриц «два на два», «три на три» и т. д. ",
                            "Внимание",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1);
                    break;

                case 3:
                    try
                    {
                        if (Row != Col || Row < 5)
                        {
                            throw new AggregateException();
                        }
                        double[,] NewArr = new double[Row + 1, Col];
                        for (int i = 0; i < Row; i++)
                        {
                            for (int j = 0; j < Col; j++)
                            {
                                NewArr[i, j] = two_array[i, j];
                            }
                        }

                        for (int i = 0; i < Col; i++)
                        {
                            NewArr[Row, i] = 1;
                            for (int j = 0; j < Row; j++)
                            {
                                NewArr[Row, i] *= NewArr[j, i];
                            }
                        }

                        dataGridView1.Rows.Clear();
                        dataGridView1.Columns.Clear();
                        dataGridView1.RowCount = Row+1;
                        dataGridView1.ColumnCount = Col;

                        for (int i = 0; i < Row+1; i++)
                        {
                            dataGridView1.Rows[i].Height = 30;
                        }
                        for (int i = 0; i < Col; i++)
                        {
                            dataGridView1.Columns[i].Width = 50;
                        }

                        for (int i = 0; i < Row+1; i++)
                        {
                            for (int j = 0; j < Col; j++)
                            {
                                dataGridView1.Rows[i].Cells[j].Value = string.Format("{0:0.00}", NewArr[i, j]);
                            }
                        }
                        print_results.Text = string.Format("Найти произведение элементов каждого столбца и вывести " +
                            "их в виде дополнительной строки матрицы.");
                    }
                    catch (AggregateException)
                    {
                        MessageBox.Show("Не удовлетворяет условию задания, повторите попытку",
                                "Внимание",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Asterisk,
                            MessageBoxDefaultButton.Button1);
                    }
                    catch
                    {
                        MessageBox.Show("Вы не ввели количество строк и/или столбцов!",
                                        "Внимание",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Asterisk,
                                        MessageBoxDefaultButton.Button1);
                    }
                    break;

                case 4:
                    try
                    {
                        int IndexMinRow = -1;
                        int IndexMinCol = -1;
                        int IndexMaxRow = -1;
                        int IndexMaxCol = -1;
                        double min = double.MaxValue;
                        double max = double.MinValue;



                        for (int i = 0; i < Row; i++)
                        {
                            for (int j = 0; j < Col; j++)
                            {
                                if (two_array[i, j] < min)
                                {
                                    min = two_array[i, j];
                                    IndexMinRow = i;
                                    IndexMinCol = j;
                                }
                                if (two_array[i, j] > max)
                                {
                                    max = two_array[i, j];
                                    IndexMaxRow = i;
                                    IndexMaxCol = j;
                                }
                            }
                        }
                        (two_array[IndexMinRow, IndexMinCol], two_array[IndexMaxRow, IndexMaxCol]) = 
                            (two_array[IndexMaxRow, IndexMaxCol], two_array[IndexMinRow, IndexMinCol]);

                        dataGridView1.Rows.Clear();
                        dataGridView1.Columns.Clear();
                        dataGridView1.RowCount = Row;
                        dataGridView1.ColumnCount = Col;

                        for (int i = 0; i < Row; i++)
                        {
                            dataGridView1.Rows[i].Height = 30;
                        }
                        for (int i = 0; i < Col; i++)
                        {
                            dataGridView1.Columns[i].Width = 50;
                        }

                        for (int i = 0; i < Row; i++)
                        {
                            for (int j = 0; j < Col; j++)
                            {
                                dataGridView1.Rows[i].Cells[j].Value = string.Format("{0:0.00}", two_array[i, j]);
                            }
                        }
                        print_results.Text = string.Format("В матрицы найти минимальное и максимальное значение и поменять их местами. ");
                        print_results.Text +=string.Format("Максимальное значение = {0:0.00}, минимальное значиние = {1:0.00}", max, min);
                    }
                    catch
                    {
                        MessageBox.Show("Вы не ввели количество строк и/или столбцов!",
                                        "Внимание",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Asterisk,
                                        MessageBoxDefaultButton.Button1);
                    }
                    break;

                case 5:
                    try
                    {
                        if (Row != Col || Row % 2 != 0)
                        {
                            throw new AggregateException();
                        }

                        for (int i = 1, j = Row - 2; i < Row; i += 2, j -= 2)
                        {
                            (two_array[i, i], two_array[i, j]) = (two_array[i, j], two_array[i, i]);
                        }

                        dataGridView1.Rows.Clear();
                        dataGridView1.Columns.Clear();
                        dataGridView1.RowCount = Row;
                        dataGridView1.ColumnCount = Col;

                        for (int i = 0; i < Row; i++)
                        {
                            dataGridView1.Rows[i].Height = 30;
                        }
                        for (int i = 0; i < Col; i++)
                        {
                            dataGridView1.Columns[i].Width = 50;
                        }

                        for (int i = 0; i < Row; i++)
                        {
                            for (int j = 0; j < Col; j++)
                            {
                                dataGridView1.Rows[i].Cells[j].Value = string.Format("{0:0.00}", two_array[i, j]);
                            }
                        }
                        print_results.Text = string.Format("Поменять местами элементы главной и побочной диагонали в четных строках. ");
                    }
                    catch (AggregateException)
                    {
                        MessageBox.Show("Не удовлетворяет условию задания, повторите попытку",
                                "Внимание",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Asterisk,
                            MessageBoxDefaultButton.Button1);
                    }
                    catch
                    {
                        MessageBox.Show("Вы не ввели количество строк и/или столбцов!",
                                        "Внимание",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Asterisk,
                                        MessageBoxDefaultButton.Button1);
                    }
                    break;


                default:
                    MessageBox.Show("Пипец ты чо делаешь, еще даже задание не выбрал, и массив не создал... ц ц ц ц ",
                                    "Чёёёёё",
                                    MessageBoxButtons.OKCancel,
                                    MessageBoxIcon.Stop,
                                    MessageBoxDefaultButton.Button1);

                    break;

            }
            
        }
        private void Clear_all_Click(object sender, EventArgs e)
        {
            Controls.Clear();
            InitializeComponent();
        }

        private void print_results_TextChanged(object sender, EventArgs e)
        {

        }

        private void Open_from_file_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Текстовый файл|*.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                StreamReader sr = new StreamReader(filePath);

                Row = int.Parse(sr.ReadLine());

                count_rows.Text = Row.ToString();

                Col = int.Parse(sr.ReadLine());

                count_columns.Text = Col.ToString();

                two_array = new double[Row, Col];

                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                dataGridView1.RowHeadersVisible = false;
                dataGridView1.ColumnHeadersVisible = false;
                dataGridView1.RowCount = Row;
                dataGridView1.ColumnCount = Col;

                for (int i = 0; i < Row; i++)
                {
                    dataGridView1.Rows[i].Height = 30;
                }
                for (int i = 0; i < Col; i++)
                {
                    dataGridView1.Columns[i].Width = 50;
                }

                for (int i = 0; i < Row; i++)
                {
                    string[] str_array = sr.ReadLine().Split('\t');
                    for (int j = 0; j < Col; j++)
                    {
                        two_array[i, j] = double.Parse(str_array[j]);
                    }
                }
                for (int i = 0; i < Row; i++)
                {
                    for (int j = 0; j < Col; j++)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = string.Format("{0:0.00}", two_array[i, j]);
                    }
                }

            }
        }

        private void Save_in_file_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Текстовый файл|*.txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog1.FileName;
                StreamWriter sw = new StreamWriter(filePath, false);

                sw.WriteLine(Row);

                sw.WriteLine(Col);

                for (int i = 0; i < Row; i++)
                {
                    for (int j = 0; j < Col; j++)
                    {
                        sw.Write("{0:0.00}\t", two_array[i, j]);
                    }
                    sw.WriteLine();

                }
                sw.Close();
            }
        }

        private void count_rows_TextChanged(object sender, EventArgs e)
        {
            bool flag = int.TryParse(count_rows.Text, out Row);
        }
    }
}
