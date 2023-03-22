using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


namespace DZ_shop
{
    internal class MyShop
    {
        public MyShop() { }
        private string name;
        private string address;
        private string description;
        private string phone_number;
        private string mail;

        public double square { get; set; }
        public MyShop(string name, string address, string description, string phone_number, string mail, double square)
        {
            this.name = name;
            this.address = address;
            this.description = description;
            this.phone_number = phone_number;
            this.mail = mail;
            this.square = square;
        }

        public string Name { get { return name; } protected set { this.name = value; } }
        public string Address { get { return address; } protected set { this.address = value; } }
        public string Description { get { return description; } protected set { this.description = value; } }
        public string Phone_number { get { return phone_number; } protected set { this.phone_number = value; } }
        public string Mail { get { return mail; } protected set { this.mail = value; } }

        public void View()
        {
            Console.WriteLine($"Название магазина: {Name}\nАдрес магазина: {Address}\nОписание магазина: {Description}\nКонтактный номер телефона: {phone_number}\nКонтактный E-mail: {mail}\nПлощадь магазина: {square}");
        }

        public override string ToString()
        {
            return $"Площадь магазина {square} кв.м";
        }

        public static MyShop operator +(MyShop counter1, int counter2)
        {
            return new MyShop { square = counter1.square + counter2 };
        }
        public static MyShop operator -(MyShop counter1, int counter2)
        {
            return new MyShop { square = counter1.square - counter2 };
        }
        public static bool operator ==(MyShop a, int b)
        {
            return a.square == b;
        }
        public static bool operator !=(MyShop a, int b)
        {
            return a.square != b;
        }
        public static bool operator <(MyShop a, int b)
        {
            return a.square < b;
        }
        public static bool operator >(MyShop a, int b)
        {
            return a.square > b;
        }

        public override int GetHashCode()
        {
            return square.GetHashCode();
        }
        public override bool Equals(object a)
        {
            if (a is MyShop b) return square == b.square;
            else return false;
        }

        public void EditSite(ref MyShop shop)
        {
            string query;
            while (true)
            {
                Write("Что нужно изменить на сайте?\n1 - имя \n2 - адрес,\n3 - описание," +
               " \n4 - телефон, \n5 - почтовый адрес, \n6 - площадь магазина, \n7 - выход => ");
                query = ReadLine();

                switch (query)
                {
                    case "1":
                        Console.Write("Введите название магазина - ");
                        shop.name = ReadLine(); break;
                    case "2":
                        Console.Write("Введите адрес магазина - ");
                        shop.address = ReadLine(); break;
                    case "3":
                        Console.Write("Введите описание магазина - ");
                        shop.Description = ReadLine(); break;
                    case "4":
                        Console.Write("Введите контактный телефон - ");
                        shop.phone_number = ReadLine(); break;
                    case "5":
                        Console.Write("Введите электронную почту - ");
                        shop.mail = ReadLine(); break;
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
        static void Main(string[] args)
        {

            string query;
            bool flag = true;
            MyShop shop = new MyShop("Eldorado", "Lenin street, 18", "Бытовая техника, электроника",
               "84996478585", "eldorado@mail.ru", 65.9);
            MyShop shop2 = new MyShop("Eldorado", "Lenin street, 18", "Бытовая техника, электроника",
                "84996478585", "eldorado@mail.ru", 89.5);
            while (flag)
            {
                WriteLine("Выберите действие:\n1 - вывести данные о магазине. \n2 - изменить данные о магазине," +
                " \n3 - изменение площади магазина \n4 выход.");
                query = ReadLine();
                switch (query)
                {
                    case "1": shop.View(); break;
                    case "2": shop.EditSite(ref shop); break;
                    case "3": Square(shop, shop2); break;
                    case "4": flag = false; break;
                    default:
                        Console.WriteLine("Сделайте правильный выбор!!!");
                        break;
                }
            }
        }
        static void Square(MyShop a, MyShop b)
        {

            Console.WriteLine(a);
            a = a+ 10;
            Console.WriteLine($"a.square+10=>использование перегруженного оператора + \n{a}\n");

            Console.WriteLine(b);
            b = b - 20;
            Console.WriteLine($"b-20=>использование перегруженного оператора - \n{b}\n");

            WriteLine();
            Console.WriteLine($"b>20=>использование перегруженного оператора > \n{b > 20}\n");
            Console.WriteLine($"a<20=>использование перегруженного оператора < \n{a < 20}\n");

            Console.WriteLine($"a.Equals(b)=>использование перегруженного метода < \n{a.Equals(b)}\n");
            a = a - 8; Console.WriteLine("a=a-8=>a=67.9 и b=67.9");
            Console.WriteLine($"a.Equals(b)=>использование перегруженного метода < \n{a.Equals(b)}\n");

            Console.WriteLine($"a==20 =>использование перегруженного метода < \n{a == 20}\n");
            Console.WriteLine($"a!20 =>использование перегруженного метода < \n{a != 20}\n");
        }
   
    }
}
