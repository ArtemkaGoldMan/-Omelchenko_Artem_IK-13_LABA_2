using Newtonsoft.Json;
using System;
using System.IO;

namespace laba2
{
    class Time
    {
        // поля
        string hh;
        string mm;
        string ss;


        // властивості 
        public string HH
        {
            get { return hh; }
            set { hh = value; }
        }
        public string MM
        {
            get { return mm; }
            set { mm = value; }
        }
        public string SS
        {
            get { return ss; }
            set { ss = value; }
        }

        // Конструктор
        public Time(string hh, string mm, string ss)
        {
            HH = hh;
            MM = mm;
            SS = ss;

        }

        public Time()
        {
            HH = "00";
            MM = "00";
            SS = "00";

        }

        public static void Hh(Time time1)//метод зміни годин
        {
            Console.WriteLine("hour");
            WriteHH(time1);//визов методу для введення годин
            if (Convert.ToInt32(time1.HH) < 0 || Convert.ToInt32(time1.HH) > 24)//перевірка на правильність вводу
            {
                do//в разі помилки цикл буде виводиди вказівку та змогу ввести час заново доки не виконається умова  
                {
                    Console.WriteLine("Error");
                    Console.WriteLine("hours can not be more 24 and less 0");
                    WriteHH(time1);
                }
                while (Convert.ToInt32(time1.HH) > 0 && Convert.ToInt32(time1.HH) < 24);
            }


        }
        public static void Mm(Time time1)//метод зміни хвилин
        {
            Console.WriteLine("minutes");
            WriteMM(time1);
            if (Convert.ToInt32(time1.MM) < 0 || Convert.ToInt32(time1.MM) > 59)
            {

                do
                {
                    Console.WriteLine("Error");
                    Console.WriteLine("minutes can not be more 59 and less 0");
                    WriteMM(time1);
                }
                while (Convert.ToInt32(time1.MM) > 0 && Convert.ToInt32(time1.MM) < 59);

            }


        }
        public static void Ss(Time time1)//метод зміни секунд
        {
            Console.WriteLine("secunds");
            WriteSS(time1);
            if (Convert.ToInt32(time1.SS) < 0 || Convert.ToInt32(time1.SS) > 59)
            {
                do
                {
                    Console.WriteLine("Error");
                    Console.WriteLine("secunds can not be more 59 and less 0");
                    WriteSS(time1);
                }
                while (Convert.ToInt32(time1.SS) > 0 && Convert.ToInt32(time1.SS) < 59);
            }

        }
        public static void WriteHH(Time time1)// метод вводу годин
        {
            time1.HH = Console.ReadLine();//
        }
        public static void WriteMM(Time time1)// метод вводу хвилин
        {
            time1.MM = Console.ReadLine();
        }
        public static void WriteSS(Time time1)//метод вводу секунд
        {
            time1.SS = Console.ReadLine();
        }
        public static void Choose(Time time1)//метод вибору, щоб змінити певну частину часу
        {
            Console.WriteLine("1-HH,2-MM,3-SS");
            int choose = Int32.Parse(Console.ReadLine());// змінна, при вводі якої значення переводимо зі стрінг в інт, адже змінна інт
            if (choose == 1)
            {
                Hh(time1);
            }
            else if (choose == 2)
            {
                Mm(time1);
            }
            else if (choose == 3)
            {
                Ss(time1);
            }
        }
        public static void Serialize(Time time1)                    // метод для збереження обєкта в json файл
        {
            var JSON = JsonConvert.SerializeObject(time1);  //серіалізація даних 

            File.WriteAllText("C:/work/text.json", JSON);     // записуємо дані до файлу, шлях до файлу вказуємо власноруч
        }

        public static Time Deserialize()  // виклик методу для десеріалізація обєкту
        {
            string filePath = @"C:/work/text.json"; //створюємо строку, в яку записуємо шлях до файлу
            if (File.Exists(filePath))   // перевіряємо на існування файлу
            {
                var Deserial = JsonConvert.DeserializeObject<Time>(File.ReadAllText(filePath)); // десеріалізуємо дані


                return Deserial;
            }
            else // якщо файлу немає, то повертаємо пустоту
            {
                return null;
            }
        }


    }
    class Program
    {
       
        static void Main(string[] args)
        {

            Time time1 = new Time();//створюємо обєкт
            Console.WriteLine("Time now");

            Console.WriteLine($"Time: {time1.HH}:{time1.MM}:{time1.SS}");//вивід часу

            Console.WriteLine("Do you want to choose your time?");//зміна часу
            Time.Hh(time1);//виклик методу для зміни годин
            Time.Mm(time1);//виклик методу для зміни хвилин
            Time.Ss(time1);//виклик методу для зміни секунд

            Console.WriteLine($"Time: {time1.HH}:{time1.MM}:{time1.SS}");//вивід нового часу

            Console.WriteLine("do you want to chose any part of time?");//запит на зміну якоїсь частини часу
            Time.Choose(time1);//визов методу для вибору зміни часу

            Console.WriteLine($"Time: {time1.HH}:{time1.MM}:{time1.SS}");//вивід часу
            Time.Serialize(time1);// визов методу для серіалізації
            Time.Deserialize();//визов методу для десеріалізації

        }
        
    }

}