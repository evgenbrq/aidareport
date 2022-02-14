using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_aidareport
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"Введите путь txt файла для сохранения списка ПК. Пример:C:\Users\admin\Desktop\base\base.txt");
            string path2 = Console.ReadLine();
            Console.WriteLine(@"Введите путь папки с отчетами. Файлы отчетов формата <number>.htm");
            string path = Console.ReadLine();
            path = path.IndexOf("\\", (path.Length - 1)) != -1 ? path : path+="\\";

            string[] pa = Directory.GetFiles(path);
            foreach(string s in pa)
            {
                Console.WriteLine(s);
            }


            for (int i = 1; i < 300; i++)
            {
                string path3 = path + $"{i}.htm";
                //bool b = TryBool(path);

                try
                {
                    var encoding = Encoding.GetEncoding(1251);
                    using (StreamReader sr = new StreamReader(path3, encoding: encoding))
                    {
                        string str = sr.ReadToEnd();
                        //Console.WriteLine(str);
                        int x = str.IndexOf("<TD>Компьютер&nbsp;&nbsp;<TD>");
                        int cv = str.IndexOf("<TR><TD><TD><TD>Генератор&nbsp;");
                        string df = str.Substring(x+29, cv-x-29);
                        using (StreamWriter sw = new StreamWriter(path2, true, Encoding.Default))
                        {
                            sw.Write($"u{i}:" + "    " + df);
                        }
                    }
                }
                catch (Exception ex)
                {
                    using (StreamWriter sw = new StreamWriter(path2, true, Encoding.Default))
                    {
                        sw.Write("");
                        sw.WriteLine($"u{i} отсутствует");
                    }
                }
            }

        }
    }
}
