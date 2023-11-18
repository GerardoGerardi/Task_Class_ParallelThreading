using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Labaratornya_1_Saad_Ali
{
    internal class Program
    {
        private static string Start_to_process(string Name_of_file, string args)
        {
            string outputstring = string.Empty;
            string outputError = string.Empty;
            using (Process process = new Process())
            {
                process.StartInfo.FileName = Name_of_file;
                process.StartInfo.Arguments = args;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.RedirectStandardError = true;

                process.Start();
                process.WaitForExit();

                outputstring= process.StandardOutput.ReadToEnd();
                outputError = process.StandardError.ReadToEnd();
            }

            if (!string.IsNullOrEmpty(outputError))
            {
                throw new Exception(outputError);
            }

            return outputstring;
        }
    

    class Matrix4x4
        {
            public int[,] elements { get; set; }


            public Matrix4x4()
               
            {
                this.elements = GenerationMatrix();

                
            }

            public int[,] GenerationMatrix()
            {
                 Random random = new Random();

                 int[,] elements = new int[4,4];

                 for (int i = 0; i < elements.GetLength(0); i++)
                 {
                     for (int j = 0; j < elements.GetLength(1); j++)

                         elements[i, j] = random.Next(1000);
                 }
                 //если хотим посмотреть 1 матрицу, то достаточно откоментить этот массив и метод ShowOneMatrix а так же уменьшить кол-во матриц в цикле до 1
             /*   int[,] elements =
              { { 1,1,2,4},
                { 1,1,3,54},
                { 1,0,3,4},
                { 1,6,3,4} };

                ShowOneMatrix(elements);*/

                return elements;

            }
            /* public void ShowOneMatrix(int[,] elements)
             {
                 for (int i = 0; i < elements.GetLength(0); i++)
                 {
                     for (int j = 0; j < elements.GetLength(1); j++)
                     {

                         Console.Write("{0}\t", elements[i, j]);
                     }
                     Console.WriteLine();


                 }
                 Console.ReadLine();
             }*/



        }

        
        static void Main(string[] args)
        {
            DateTime pered = DateTime.Now;
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Proccess_DlYa_Podcheta.exe"); //указываем путь и запускаем exe файл из директории
            List <Matrix4x4> matrix = new();

            //определяем сколько матриц 4х4 будем проверять . Меняем для этого i< номер матриц
            for (int i=0; i < 10; i++)
            {
                matrix.Add(new Matrix4x4());
               
            }

            foreach (var item in matrix)
            {
                int detMatrix = item.elements[0, 0] * item.elements[1, 1] * item.elements[2, 2] * item.elements[3, 3] +
             item.elements[0, 0] * item.elements[1, 2] * item.elements[2, 3] * item.elements[3, 1] +
             item.elements[0, 0] * item.elements[1, 3] * item.elements[2, 1] * item.elements[3, 2] +
             item.elements[0, 1] * item.elements[1, 0] * item.elements[2, 3] * item.elements[3, 2] +
             item.elements[0, 1] * item.elements[1, 2] * item.elements[2, 0] * item.elements[3, 3] +
             item.elements[0, 1] * item.elements[1, 3] * item.elements[2, 2] * item.elements[3, 0] +
             item.elements[0, 2] * item.elements[1, 0] * item.elements[2, 1] * item.elements[3, 3] +
             item.elements[0, 2] * item.elements[1, 1] * item.elements[2, 3] * item.elements[3, 0] +
             item.elements[0, 2] * item.elements[1, 3] * item.elements[2, 0] * item.elements[3, 1] +
             item.elements[0, 3] * item.elements[1, 0] * item.elements[2, 2] * item.elements[3, 1] +
             item.elements[0, 3] * item.elements[1, 1] * item.elements[2, 0] * item.elements[3, 2] +
             item.elements[0, 3] * item.elements[1, 2] * item.elements[2, 1] * item.elements[3, 0] -
             item.elements[0, 0] * item.elements[1, 1] * item.elements[2, 3] * item.elements[3, 2] -
             item.elements[0, 0] * item.elements[1, 2] * item.elements[2, 1] * item.elements[3, 3] -
             item.elements[0, 0] * item.elements[1, 3] * item.elements[2, 2] * item.elements[3, 1] -
             item.elements[0, 1] * item.elements[1, 0] * item.elements[2, 2] * item.elements[3, 3] -
             item.elements[0, 1] * item.elements[1, 2] * item.elements[2, 3] * item.elements[3, 0] -
             item.elements[0, 1] * item.elements[1, 3] * item.elements[2, 0] * item.elements[3, 2] -
             item.elements[0, 2] * item.elements[1, 0] * item.elements[2, 3] * item.elements[3, 1] -
             item.elements[0, 2] * item.elements[1, 1] * item.elements[2, 0] * item.elements[3, 3] -
             item.elements[0, 2] * item.elements[1, 3] * item.elements[2, 1] * item.elements[3, 0] -
             item.elements[0, 3] * item.elements[1, 0] * item.elements[2, 1] * item.elements[3, 2] -
             item.elements[0, 3] * item.elements[1, 1] * item.elements[2, 2] * item.elements[3, 0] -
             item.elements[0, 3] * item.elements[1, 2] * item.elements[2, 0] * item.elements[3, 1];

                /* Console.WriteLine("Определитель матрицы при вызове метода ShowOneMatrix равен =" + detMatrix);
                 Console.ReadLine();*/
            }

            DateTime First_posle = DateTime.Now;
            //последовательный подсчёт матриц
            foreach (var item in  matrix)
            {
                int iteration_line1 =  Convert.ToInt32(Start_to_process(path,$"1 {item.elements[0, 0]} {item.elements[1, 1]} {item.elements[2, 2]} {item.elements[3, 3]}").Split(" ")[1]);
                int iteration_line2 =  Convert.ToInt32(Start_to_process(path,$"2 {item.elements[0, 0]} {item.elements[1, 2]} {item.elements[2, 3]} {item.elements[3, 1]}").Split(" ")[1]);
                int iteration_line3 =  Convert.ToInt32(Start_to_process(path,$"3 {item.elements[0, 0]} {item.elements[1, 3]} {item.elements[2, 1]} {item.elements[3, 2]}").Split(" ")[1]);
                int iteration_line4 =  Convert.ToInt32(Start_to_process(path,$"4 {item.elements[0, 1]} {item.elements[1, 0]} {item.elements[2, 3]} {item.elements[3, 2]}").Split(" ")[1]);
                int iteration_line5 =  Convert.ToInt32(Start_to_process(path,$"5 {item.elements[0, 1]} {item.elements[1, 2]} {item.elements[2, 0]} {item.elements[3, 3]}").Split(" ")[1]);
                int iteration_line6 =  Convert.ToInt32(Start_to_process(path,$"6 {item.elements[0, 1]} {item.elements[1, 3]} {item.elements[2, 2]} {item.elements[3, 0]}").Split(" ")[1]);
                int iteration_line7 =  Convert.ToInt32(Start_to_process(path,$"7 {item.elements[0, 2]} {item.elements[1, 0]} {item.elements[2, 1]} {item.elements[3, 3]}").Split(" ")[1]);
                int iteration_line8 =  Convert.ToInt32(Start_to_process(path,$"8 {item.elements[0, 2]} {item.elements[1, 1]} {item.elements[2, 3]} {item.elements[3, 0]}").Split(" ")[1]);
                int iteration_line9 =  Convert.ToInt32(Start_to_process(path,$"9 {item.elements[0, 2]} {item.elements[1, 3]} {item.elements[2, 0]} {item.elements[3, 1]}").Split(" ")[1]);
                int iteration_line10 = Convert.ToInt32(Start_to_process(path,$"10 {item.elements[0, 3]} {item.elements[1, 0]} {item.elements[2, 2]} {item.elements[3, 1]}").Split(" ")[1]);
                int iteration_line11 = Convert.ToInt32(Start_to_process(path,$"11 {item.elements[0, 3]} {item.elements[1, 1]} {item.elements[2, 0]} {item.elements[3, 2]}").Split(" ")[1]);
                int iteration_line12 = Convert.ToInt32(Start_to_process(path,$"12 {item.elements[0, 3]} {item.elements[1, 2]} {item.elements[2, 1]} {item.elements[3, 0]}").Split(" ")[1]);
                int iteration_line13 = Convert.ToInt32(Start_to_process(path,$"13 {item.elements[0, 0]} {item.elements[1, 1]} {item.elements[2, 3]} {item.elements[3, 2]}").Split(" ")[1]);
                int iteration_line14 = Convert.ToInt32(Start_to_process(path,$"14 {item.elements[0, 0]} {item.elements[1, 2]} {item.elements[2, 1]} {item.elements[3, 3]}").Split(" ")[1]);
                int iteration_line15 = Convert.ToInt32(Start_to_process(path,$"15 {item.elements[0, 0]} {item.elements[1, 3]} {item.elements[2, 2]} {item.elements[3, 1]}").Split(" ")[1]);
                int iteration_line16 = Convert.ToInt32(Start_to_process(path,$"16 {item.elements[0, 1]} {item.elements[1, 0]} {item.elements[2, 2]} {item.elements[3, 3]}").Split(" ")[1]);
                int iteration_line17 = Convert.ToInt32(Start_to_process(path,$"17 {item.elements[0, 1]} {item.elements[1, 2]} {item.elements[2, 3]} {item.elements[3, 0]}").Split(" ")[1]);
                int iteration_line18 = Convert.ToInt32(Start_to_process(path,$"18 {item.elements[0, 1]} {item.elements[1, 3]} {item.elements[2, 0]} {item.elements[3, 2]}").Split(" ")[1]);
                int iteration_line19 = Convert.ToInt32(Start_to_process(path,$"19 {item.elements[0, 2]} {item.elements[1, 0]} {item.elements[2, 3]} {item.elements[3, 1]}").Split(" ")[1]);
                int iteration_line20 = Convert.ToInt32(Start_to_process(path,$"20 {item.elements[0, 2]} {item.elements[1, 1]} {item.elements[2, 0]} {item.elements[3, 3]}").Split(" ")[1]);
                int iteration_line21 = Convert.ToInt32(Start_to_process(path,$"21 {item.elements[0, 2]} {item.elements[1, 3]} {item.elements[2, 1]} {item.elements[3, 0]}").Split(" ")[1]);
                int iteration_line22 = Convert.ToInt32(Start_to_process(path,$"22 {item.elements[0, 3]} {item.elements[1, 0]} {item.elements[2, 1]} {item.elements[3, 2]}").Split(" ")[1]);
                int iteration_line23 = Convert.ToInt32(Start_to_process(path,$"23 {item.elements[0, 3]} {item.elements[1, 1]} {item.elements[2, 2]} {item.elements[3, 0]}").Split(" ")[1]);
                int iteration_line24 = Convert.ToInt32(Start_to_process(path,$"24 {item.elements[0, 3]} {item.elements[1, 2]} {item.elements[2, 0]} {item.elements[3, 1]}").Split(" ")[1]);

                int result = iteration_line1 + iteration_line2 + iteration_line3 + iteration_line4 + iteration_line5
                    + iteration_line6 + iteration_line7 + iteration_line8 + iteration_line9 + iteration_line10 + iteration_line11 + iteration_line12
                    - iteration_line13 - iteration_line14 - iteration_line15 - iteration_line16 - iteration_line17 - iteration_line18 - iteration_line19
                    - iteration_line20 - iteration_line21 - iteration_line22 - iteration_line23 - iteration_line24;

                /*Console.WriteLine(result);*/
            }
            DateTime Second_posle = DateTime.Now;
            //параллельный подсчёт матриц
            foreach (var item in matrix)
            {
                List<Task<string[]>> tasks = new(24);
                tasks.Add(Task.Run(() => 
                {
                    return Start_to_process(path, $"1 {item.elements[0, 0]} {item.elements[1, 1]} {item.elements[2, 2]} {item.elements[3, 3]}").Split(" ");
                    
                 }));

                tasks.Add(Task.Run(() =>
                {
                    return Start_to_process(path, $"2 {item.elements[0, 0]} {item.elements[1, 2]} {item.elements[2, 3]} {item.elements[3, 1]}").Split(" ");

                }));

                tasks.Add(Task.Run(() =>
                {
                    return Start_to_process(path, $"3 {item.elements[0, 0]} {item.elements[1, 3]} {item.elements[2, 1]} {item.elements[3, 2]}").Split(" ");

                }));

                tasks.Add(Task.Run(() =>
                {
                    return Start_to_process(path, $"4 {item.elements[0, 1]} {item.elements[1, 0]} {item.elements[2, 3]} {item.elements[3, 2]}").Split(" ");

                }));

                tasks.Add(Task.Run(() =>
                {
                    return Start_to_process(path, $"5 {item.elements[0, 1]} {item.elements[1, 2]} {item.elements[2, 0]} {item.elements[3, 3]}").Split(" "); 

                }));

                tasks.Add(Task.Run(() =>
                {
                    return Start_to_process(path, $"6 {item.elements[0, 1]} {item.elements[1, 3]} {item.elements[2, 2]} {item.elements[3, 0]}").Split(" "); 

                }));

                tasks.Add(Task.Run(() =>
                {
                    return Start_to_process(path, $"7 {item.elements[0, 2]} {item.elements[1, 0]} {item.elements[2, 1]} {item.elements[3, 3]}").Split(" "); 

                }));

                tasks.Add(Task.Run(() =>
                {
                    return Start_to_process(path, $"8 {item.elements[0, 2]} {item.elements[1, 1]} {item.elements[2, 3]} {item.elements[3, 0]}").Split(" ");

                }));
                
                tasks.Add(Task.Run(() =>
                {
                    return Start_to_process(path, $"9 {item.elements[0, 2]} {item.elements[1, 3]} {item.elements[2, 0]} {item.elements[3, 1]}").Split(" ");

                }));

                tasks.Add(Task.Run(() =>
                {
                    return Start_to_process(path, $"10 {item.elements[0, 3]} {item.elements[1, 0]} {item.elements[2, 2]} {item.elements[3, 1]}").Split(" ");

                }));

                tasks.Add(Task.Run(() =>
                {
                    return Start_to_process(path, $"11 {item.elements[0, 3]} {item.elements[1, 1]} {item.elements[2, 0]} {item.elements[3, 2]}").Split(" ");

                }));
               
                tasks.Add(Task.Run(() =>
                {
                    return Start_to_process(path, $"12 {item.elements[0, 3]} {item.elements[1, 2]} {item.elements[2, 1]} {item.elements[3, 0]}").Split(" ");

                }));

                tasks.Add(Task.Run(() =>
                {
                    return Start_to_process(path, $"13 {item.elements[0, 0]} {item.elements[1, 1]} {item.elements[2, 3]} {item.elements[3, 2]}").Split(" ");

                }));

                tasks.Add(Task.Run(() =>
                {
                    return Start_to_process(path, $"14 {item.elements[0, 0]} {item.elements[1, 2]} {item.elements[2, 1]} {item.elements[3, 3]}").Split(" ");

                }));

                tasks.Add(Task.Run(() =>
                {
                    return Start_to_process(path, $"15 {item.elements[0, 0]} {item.elements[1, 3]} {item.elements[2, 2]} {item.elements[3, 1]}").Split(" ");

                }));

                tasks.Add(Task.Run(() =>
                {
                    return Start_to_process(path, $"16 {item.elements[0, 1]} {item.elements[1, 0]} {item.elements[2, 2]} {item.elements[3, 3]}").Split(" ");

                }));

                tasks.Add(Task.Run(() =>
                {
                    return Start_to_process(path, $"17 {item.elements[0, 1]} {item.elements[1, 2]} {item.elements[2, 3]} {item.elements[3, 0]}").Split(" ");

                }));

                tasks.Add(Task.Run(() =>
                {
                    return Start_to_process(path, $"18 {item.elements[0, 1]} {item.elements[1, 3]} {item.elements[2, 0]} {item.elements[3, 2]}").Split(" ");

                }));

                tasks.Add(Task.Run(() =>
                {
                    return Start_to_process(path, $"19 {item.elements[0, 2]} {item.elements[1, 0]} {item.elements[2, 3]} {item.elements[3, 1]}").Split(" ");

                }));

                tasks.Add(Task.Run(() =>
                {
                    return Start_to_process(path, $"20 {item.elements[0, 2]} {item.elements[1, 1]} {item.elements[2, 0]} {item.elements[3, 3]}").Split(" ");

                }));

                tasks.Add(Task.Run(() =>
                {
                    return Start_to_process(path, $"21 {item.elements[0, 2]} {item.elements[1, 3]} {item.elements[2, 1]} {item.elements[3, 0]}").Split(" ");

                }));

                tasks.Add(Task.Run(() =>
                {
                    return Start_to_process(path, $"22 {item.elements[0, 3]} {item.elements[1, 0]} {item.elements[2, 1]} {item.elements[3, 2]}").Split(" ");

                }));

                tasks.Add(Task.Run(() =>
                {
                    return Start_to_process(path, $"23 {item.elements[0, 3]} {item.elements[1, 1]} {item.elements[2, 2]} {item.elements[3, 0]}").Split(" ");

                }));

                tasks.Add(Task.Run(() =>
                {
                    return Start_to_process(path, $"24 {item.elements[0, 3]} {item.elements[1, 2]} {item.elements[2, 0]} {item.elements[3, 1]}").Split(" ");

                }));


                Task.WaitAll(tasks.ToArray());

                int result = 0;

                foreach (Task<string[]> task in tasks)
                {
                    int number_of_string = Convert.ToInt32(task.Result[0]); //номер строки из проекта 2
                    int proizvedenie = Convert.ToInt32(task.Result[1]); // произведение из проекта 2
                    if (number_of_string <= 12)
                        result += proizvedenie;
                    else result -= proizvedenie;

                }

               /*  Console.WriteLine(result);*/
            }

           

                /* Parallel.ForEach(matrix, item =>
                 {
                 int detMatrix = item.elements[0, 0] * item.elements[1, 1] * item.elements[2, 2] * item.elements[3, 3] +
                 item.elements[0, 0] * item.elements[1, 2] * item.elements[2, 3] * item.elements[3, 1] +
                 item.elements[0, 0] * item.elements[1, 3] * item.elements[2, 1] * item.elements[3, 2] +
                 item.elements[0, 1] * item.elements[1, 0] * item.elements[2, 3] * item.elements[3, 2] +
                 item.elements[0, 1] * item.elements[1, 2] * item.elements[2, 0] * item.elements[3, 3] +
                 item.elements[0, 1] * item.elements[1, 3] * item.elements[2, 2] * item.elements[3, 0] +
                 item.elements[0, 2] * item.elements[1, 0] * item.elements[2, 1] * item.elements[3, 3] +
                 item.elements[0, 2] * item.elements[1, 1] * item.elements[2, 3] * item.elements[3, 0] +
                 item.elements[0, 2] * item.elements[1, 3] * item.elements[2, 0] * item.elements[3, 1] +
                 item.elements[0, 3] * item.elements[1, 0] * item.elements[2, 2] * item.elements[3, 1] +
                 item.elements[0, 3] * item.elements[1, 1] * item.elements[2, 0] * item.elements[3, 2] +
                 item.elements[0, 3] * item.elements[1, 2] * item.elements[2, 1] * item.elements[3, 0] -
                 item.elements[0, 0] * item.elements[1, 1] * item.elements[2, 3] * item.elements[3, 2] -
                 item.elements[0, 0] * item.elements[1, 2] * item.elements[2, 1] * item.elements[3, 3] -
                 item.elements[0, 0] * item.elements[1, 3] * item.elements[2, 2] * item.elements[3, 1] -
                 item.elements[0, 1] * item.elements[1, 0] * item.elements[2, 2] * item.elements[3, 3] -
                 item.elements[0, 1] * item.elements[1, 2] * item.elements[2, 3] * item.elements[3, 0] -
                 item.elements[0, 1] * item.elements[1, 3] * item.elements[2, 0] * item.elements[3, 2] -
                 item.elements[0, 2] * item.elements[1, 0] * item.elements[2, 3] * item.elements[3, 1] -
                 item.elements[0, 2] * item.elements[1, 1] * item.elements[2, 0] * item.elements[3, 3] -
                 item.elements[0, 2] * item.elements[1, 3] * item.elements[2, 1] * item.elements[3, 0] -
                 item.elements[0, 3] * item.elements[1, 0] * item.elements[2, 1] * item.elements[3, 2] -
                 item.elements[0, 3] * item.elements[1, 1] * item.elements[2, 2] * item.elements[3, 0] -
                 item.elements[0, 3] * item.elements[1, 2] * item.elements[2, 0] * item.elements[3, 1];

                 });*/

            DateTime Third_posle = DateTime.Now;
            
            Console.WriteLine($"{"Время работы программы с помощью обычного цикла"} {First_posle-pered} ");
            Console.WriteLine($"{"Время работы программы с помощью запуска 24 процессов последовательно "} {Second_posle - First_posle} ");
            Console.WriteLine($"{"Время работы программы с помощью запуска 24 процессов параллельно"} {Third_posle - Second_posle} ");
            Console.ReadLine();

        }

    }
}

