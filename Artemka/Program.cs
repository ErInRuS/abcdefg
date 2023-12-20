using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artemka
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Version 1.3.2";
            //исходная информация для случайной генерации студентов
            string[] names = {"Александр", "Алексей", "Андрей", "Антон", "Артем", "Виталий", "Владимир", "Владислав","Вячеслав", "Геннадий" };
            string[] secondNames = { "Иванов", "Кузнецов", "Попов", "Смирнов", "Соколов", "Васильев", "Петров", "Волков", "Зайцев", "Новиков" };
            string[] lastNames = { "Александрович", "Алексеевич", "Андреевич", "Антонович", "Артемович", "Витальевич", "Владимирович", "Вячеславович", "Геннадьевич" };

            string[] nameGroups = { "Правоохранительная деятельность","Судебное право","Информационные системы и программирование"};
            string[] prefix = { "ПД","СУД","ИС"};
            //иниациализация рандома
            Random r = new Random(); 
            //генерация случайных студентов
            for(int i = 0; i < 10; i++)
            {
                //создание нового студента
                Student student = new Student(names[r.Next(names.Length)], secondNames[r.Next(secondNames.Length)], lastNames[r.Next(lastNames.Length)]);
                //добавление свойств
                student.Group.Prefix = prefix[r.Next(prefix.Length)];
                student.Group.Name = nameGroups[r.Next(nameGroups.Length)];
                //генерация оценок
                for(int j = 0; j < r.Next(2, 5); j++)
                {
                    student.Marks.Add(Math.Round(r.Next(2,5) + r.NextDouble()));
                }
                //добавление студента в список
                Student.students.Add(student);
                //вывод информации
                student.Show();
                Console.WriteLine();
            }
            //выбираем случайного студента и выводим информацию его средние оценки
            var stud = Student.students[r.Next(Student.students.Count)];
            Console.WriteLine("Статистика случайного студента: ");
            stud.Calculate();

            Console.ReadKey();
        }
    }
}
