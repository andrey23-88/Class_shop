using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


namespace journal
{

    class MyJournal
    {
        public MyJournal() { }
        private string name;
        private DateTime yearOfFound;
        private string description;
        private string phone;
        private string emailbox;

        public int staff { get; set; }
        public MyJournal(string name, int yearOfFounds, string description, string phone, string emailbox, int staff)
        {
            this.name = name;
            this.yearOfFound = new DateTime(yearOfFounds, 1, 1);
            this.description = description;
            this.phone = phone;
            this.emailbox = emailbox;
            this.staff = staff;
        }

        public string Name { get { return name; } protected set { this.name = value; } }
        public DateTime YearOfFound { get { return yearOfFound; } protected set { this.yearOfFound = value; } }
        public string Description { get { return description; } protected set { this.description = value; } }
        public string Phone { get { return phone; } protected set { this.phone = value; } }
        public string Email { get { return emailbox; } protected set { this.emailbox = value; } }

        public void View()
        {
            Console.WriteLine();
            WriteLine($"Имя - {Name}");
            WriteLine($"Год основания - {YearOfFound.Year}");
            WriteLine($"Описание - {Description}");
            WriteLine($"Контактный телефон - {phone}");
            WriteLine($"Электронная почта - {Email}");
            WriteLine($"Количество сотрудников - {staff}");
            WriteLine();
        }
        /// <summary>
        /// переопределение ToString() 
        /// </summary>
        public override string ToString()
        {
            return $"В журале {staff} сотрудников";
        }
        /// <summary>
        /// Перегрузка оператора +  
        /// </summary>
        public static MyJournal operator +(MyJournal counter1, int counter2)
        {
            return new MyJournal { staff = counter1.staff + counter2 };
        }
        /// <summary>
        /// Перегрузка оператора -  
        /// </summary>
        public static MyJournal operator -(MyJournal counter1, int counter2)
        {
            return new MyJournal { staff = counter1.staff - counter2 };
        }
        /// <summary>
        /// Перегрузка оператора ==  
        /// </summary>
        public static bool operator ==(MyJournal a, int b)
        {
            return a.staff == b;
        }
        /// <summary>
        /// Перегрузка оператора !=  
        /// </summary>
        public static bool operator !=(MyJournal a, int b)
        {
            return a.staff != b; ;
        }
        /// <summary>
        /// Перегрузка оператора <  
        /// </summary>
        public static bool operator <(MyJournal a, int b)
        {
            return a.staff < b; ;
        }
        /// <summary>
        /// Перегрузка оператора >  
        /// </summary>
        public static bool operator >(MyJournal a, int b)
        {
            return a.staff > b; ;
        }
        /// <summary>
        /// Переопределение метода  GetHashCode() 
        /// </summary>
        public override int GetHashCode()
        {
            return staff.GetHashCode();
        }
        /// <summary>
        /// Переопределение метода  Equals(object a) 
        /// </summary>
        public override bool Equals(object a)
        {
            if (a is MyJournal b) return staff == b.staff;
            else return false;
        }


        public void EditSite(ref MyJournal journal)
        {
            string query;
            while (true)
            {
                Write("Что нужно изменить на сайте?\n1 - имя \n2 - год основания,\n3 - описание," +
               " \n4 - телефон, \n5 - почтовый адрес, \n6 - работа с сотрудниками, \n7 - выход => ");
                query = ReadLine();

                switch (query)
                {
                    case "1":
                        Console.Write("Введите название журнала - ");
                        journal.name = ReadLine(); break;
                    case "2":
                        Console.Write("Введите год основания журнала - ");
                        string tempAge = ReadLine();
                        int temp = Convert.ToInt32(tempAge);
                        if (temp < 1900 || temp > 2023) { Console.WriteLine("Введен неправильный год!!!"); break; }
                        tempAge += " 01 01";
                        journal.YearOfFound = Convert.ToDateTime(tempAge); break;
                    case "3":
                        Console.Write("Введите описание журнала - ");
                        journal.Description = ReadLine(); break;
                    case "4":
                        Console.Write("Введите контактный телефон - ");
                        journal.phone = ReadLine(); break;
                    case "5":
                        Console.Write("Введите электронную почту - ");
                        journal.emailbox = ReadLine(); break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Сделайте правильный выбор!!!");
                        break;
                }
            }
        }
    }


    internal class Program
    {
        //        Ранее в одном из практических заданий вы создавали
        //класс «Журнал». Добавьте к уже созданному классу информацию о количестве сотрудников.
        //Выполните перегрузку
        //+ (для увеличения количества сотрудников на указанную величину),
        //— (для уменьшения количества сотрудников на указанную величину),
        //== (проверка на равенство количества сотрудников),
        //< и > (проверка на меньше или  //больше количества сотрудников),
        //!= и Equals.
        //Используйте механизм свойств для полей класса
        static void Main(string[] args)
        {

            string query;
            bool flag = true;
            MyJournal journal = new MyJournal("Бурда Морден", 2003, "Журнал, который рассказывает обо мне",
                "87777778899", "journal@journal.ru", 10);
            MyJournal journal2 = new MyJournal("Бурда Морден", 2003, "Журнал, который рассказывает обо мне",
                "87777778899", "journal1@journal1.ru", 20);
            while (flag)
            {
                WriteLine("Выберите действие:\n1 - вывести данные о журнале. \n2 - изменить данные о журнале," +
                " \n3 - работа с сотрудниками \n4 выход.");
                query = ReadLine();
                switch (query)
                {
                    case "1": journal.View(); break;
                    case "2": journal.EditSite(ref journal); break;
                    case "3": Staff(journal, journal2); break;
                    case "4": flag = false; break;
                    default:
                        Console.WriteLine("Сделайте правильный выбор!!!");
                        break;
                }
            }
        }
        static void Staff(MyJournal a, MyJournal b)
        {
            Console.WriteLine(a);
            a = a + 5;

            Console.WriteLine($"a + 5 => использование перегруженного оператора + \n{a}\n");

            Console.WriteLine(b);
            b = b - 8;
            Console.WriteLine($"b - 8 => использование перегруженного оператора - \n{b}");

            WriteLine();
            Console.WriteLine($"b > 8 => использование перегруженного оператора > \n{b > 8}\n");
            Console.WriteLine($"a < 8 => использование перегруженного оператора < \n{a < 8}\n");

            Console.WriteLine($"a.Equals(b) => использование переопределенного метода  < \n{a.Equals(b)}\n");

            a = a - 3; Console.WriteLine("a = a - 3 => a = 12 и b = 12");
            Console.WriteLine($"a.Equals(b) => использование переопределенного метода  < \n{a.Equals(b)}\n");

            Console.WriteLine($"a == 8 => использование перегруженного оператора < \n{a == 8}\n");
            Console.WriteLine($"a != 8 => использование перегруженного оператора < \n{a != 8}\n");
            WriteLine();
        }
    }
}

