using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Artemka
{
    public class Student
    {
        //статический список студентов класса Student
        public static List<Student> students = new List<Student>();
        //конструктор класса Student
        public Student(string name = "none",string secondName = "none",string lastName = "none")
        {
            Name = name; 
            SecondName = secondName;
            LastName = lastName;
            Group = new Group();
            Marks = new List<double>();
        }
        //задаём свойства
        public string Name {  get; set; }
        public string SecondName {  get; set; }
        public string LastName {  get; set; }
        public Group Group { get; set; }
        public List<double> Marks { get; set; }
        //переопределение метода ToString()
        public override string ToString()
        {
            return $"{SecondName} {Name} {LastName}\n{Group.Prefix}";
        }
        //вывод информации
        public void Show()
        {
            Console.WriteLine($"Имя: {Name}\nФамилия: {SecondName}\nОтчество: {LastName}\nСредная оценка: {Math.Round(Marks.Average(),2)}\nПрефикс группы: {Group.Prefix}");
        }
        //расчёт средних оценок предметов и среди студентов
        public void Calculate()
        {
            string fileName = "Results.txt";
            //Проверка существует ли файл
            if (!File.Exists(fileName))
            {
                File.Create(fileName);
            }
            //вычисление средних оценок
            double averageCurrentScore = this.Marks.Average();
            double averageScore = 0;
            int tempCount = students.Count;
            double tempAverage = 0;
            //перебираем студентов
            foreach(var t in students)
            {
                tempAverage += t.Marks.Average();
            }
            averageScore = tempAverage / tempCount;
            string info = $"ФИО: {SecondName} {Name} {LastName}\nПрефикс: {Group.Prefix}\nОбщая успеваемость: {Math.Round(averageScore,2)}\nКачественная успеваемость: {Math.Round(averageCurrentScore,2)}\n";

            Console.WriteLine(info);
            //запись в файл
            using (StreamWriter sw = new StreamWriter(fileName,true))
            {
                sw.WriteLine(info);
            }
        }
    }
}
