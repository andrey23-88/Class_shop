using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


namespace DZ_shop
{
    internal class shop
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string phone_number { get; set; }
        public string mail { get; set; }

        public shop()
        {
            Name = "Podsolnooh";
            Address = "Kirov city, Lenin Street, 7";
            Description = "Магазин продуктов и товаров для дома";
            phone_number = "(8332)-46-67-78";
            mail = "podsolnooh43.mail.ru";
        }

        public shop(string name, string address, string description, string phone_number, string mail)
        {
            Name = name;
            Address = address;
            Description = description;
            phone_number = phone_number;
            mail = mail;
        }

        public void PrintShop()
        {
            Console.WriteLine($"Название магазина: {Name}\nАдрес магазина: {Address}\nОписание магазина: {Description}\nКонтактный номер телефона: {phone_number}\nКонтактный E-mail: {mail}\n");
        }
        public void DataEntry()
        {
            Write("Введите название магазина: ");
            Name = ReadLine();
            Write("Введите адрес магазина: ");
            Address = ReadLine();
            Write("Введите описание магазина: ");
            Description = ReadLine();
            Write("Введите контактный номер магазина: ");
            phone_number = ReadLine();
            Write("Введите контактный E-mail магазина: ");
            mail = ReadLine();
        }
    }

    internal class Shop
    {
        static void Main(string[] args)
        {
            shop sh1;
            sh1=new shop();
            sh1.PrintShop();

            shop emptyness=new shop();
            emptyness.DataEntry();
            emptyness.PrintShop();

        }
    }
}
