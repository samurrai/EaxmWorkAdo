using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamWork
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppContext())
            {

                while (true)
                {
                    Console.WriteLine("С чем вы хотите работать?");
                    Console.WriteLine("1)Страны");
                    Console.WriteLine("2)Города");
                    Console.WriteLine("3)Улицы");
                    Console.WriteLine("0 чтобы выйти");
                    if (int.TryParse(Console.ReadLine(), out int choice))
                    {
                        if (choice == 1)
                        {
                            CountriesMenu(context);
                        }
                        if (choice == 2)
                        {
                            Cities(context);
                        }
                        if (choice == 3)
                        {
                            StreetsMenu(context);
                        }
                        if (choice == 0)
                        {
                            Environment.Exit(0);
                        }
                    }
                }
            }
        }

        private static void StreetsMenu(AppContext context)
        {
            while (true)
            {
                Console.WriteLine("Что вы хотите сделать?");
                Console.WriteLine("1)Просмотреть улицы");
                Console.WriteLine("2)Добавить улицу");
                Console.WriteLine("3)Изменить улицу");
                Console.WriteLine("4)Удалить улицу");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    if (choice == 1)
                    {
                        if (context.Streets.Count() > 0)
                        {

                            foreach (var street in context.Streets)
                            {
                                Console.WriteLine($"Улица - {street.Name}");
                                Console.WriteLine($"Город - {street.City.Name}");
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Улицы отсутствуют");
                            break;
                        }
                    }
                    if (choice == 2)
                    {
                        Street street = new Street();
                        while (true)
                        {
                            Console.WriteLine("Введите название");
                            street.Name = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(street.Name))
                            {
                                break;
                            }
                        }
                        while (true)
                        {
                            Console.WriteLine("Введите город");
                            string cityName = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(cityName))
                            {
                                foreach (var city in context.Cities)
                                {
                                    if (city.Name == cityName)
                                    {
                                        street.City = city;
                                        context.Streets.Add(street);
                                        context.SaveChanges();
                                        break;
                                    }
                                }
                                Console.WriteLine("Город не найден");
                                break;
                            }
                        }
                        break;
                    }
                    if (choice == 3)
                    {
                        while (true)
                        {
                            Console.WriteLine("Введите название улицы");
                            string streetName = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(streetName))
                            {
                                while (true)
                                {
                                    Console.WriteLine("Введите новое название");
                                    string newStreetName = Console.ReadLine();
                                    if (!string.IsNullOrWhiteSpace(newStreetName))
                                    {
                                        foreach (var street in context.Streets)
                                        {
                                            if (street.Name == streetName)
                                            {
                                                street.Name = newStreetName;
                                                context.SaveChanges();
                                                break;
                                            }
                                        }
                                        Console.WriteLine("Улица не найдена");
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                    }
                    if (choice == 4)
                    {
                        while (true)
                        {
                            Console.WriteLine("Введите название улицы");
                            string streetName = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(streetName))
                            {
                                foreach (var street in context.Streets)
                                {
                                    if (street.Name == streetName)
                                    {
                                        street.DeletedDate = DateTime.Now;
                                        context.SaveChanges();
                                        break;
                                    }
                                }
                                Console.WriteLine("Улица не найдена");
                                break;
                            }
                        }
                    }
                    break;
                }
            }
        }

        private static void Cities(AppContext context)
        {
            while (true)
            {
                Console.WriteLine("Что вы хотите сделать?");
                Console.WriteLine("1)Просмотреть города");
                Console.WriteLine("2)Добавить города");
                Console.WriteLine("3)Изменить города");
                Console.WriteLine("4)Удалить города");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    if (choice == 1)
                    {
                        if (context.Cities.Count() > 0)
                        {
                            foreach (var city in context.Cities)
                            {
                                Console.WriteLine($"Город - {city.Name}");
                                foreach (var street in city.Streets)
                                {
                                    Console.WriteLine($"Улица - {street.Name}");
                                }
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Улицы отсутствуют");
                            break;
                        }
                    }
                    if (choice == 2)
                    {
                        Country country = new Country();
                        while (true)
                        {
                            Console.WriteLine("Введите название");
                            country.Name = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(country.Name))
                            {
                                break;
                            }
                        }
                    }
                    if (choice == 3)
                    {
                        while (true)
                        {
                            Console.WriteLine("Введите название страны");
                            string countryName = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(countryName))
                            {
                                while (true)
                                {
                                    Console.WriteLine("Введите новое название");
                                    string newCountryName = Console.ReadLine();
                                    if (!string.IsNullOrWhiteSpace(newCountryName))
                                    {
                                        foreach (var country in context.Countries)
                                        {
                                            if (country.Name == newCountryName)
                                            {
                                                country.Name = newCountryName;
                                                context.SaveChanges();
                                                break;
                                            }
                                        }
                                        Console.WriteLine("Страна не найдена");
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                    }
                    if (choice == 4)
                    {
                        while (true)
                        {
                            Console.WriteLine("Введите название страны");
                            string countryName = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(countryName))
                            {
                                foreach (var country in context.Countries)
                                {
                                    if (country.Name == countryName)
                                    {
                                        country.DeletedDate = DateTime.Now;
                                        context.SaveChanges();
                                        break;
                                    }
                                }
                                Console.WriteLine("Страна не найдена");
                                break;
                            }
                        }
                    }
                    break;
                }

            }
        }
            private static void CountriesMenu(AppContext context) {
                while (true)
                {
                    Console.WriteLine("Что вы хотите сделать?");
                    Console.WriteLine("1)Просмотреть страны");
                    Console.WriteLine("2)Добавить страну");
                    Console.WriteLine("3)Изменить страну");
                    Console.WriteLine("4)Удалить страну");
                    if (int.TryParse(Console.ReadLine(), out int choice))
                    {
                        if (choice == 1)
                        {
                            if (context.Streets.Count() > 0)
                            {
                                foreach (var country in context.Countries)
                                {
                                    Console.WriteLine($"Страна - {country.Name}");
                                    foreach (var city in country.Cities)
                                    {
                                        Console.WriteLine($"Город - {city.Name}");
                                    }
                                    Console.WriteLine();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Страны отсутствуют");
                                break;
                            }
                        }
                        if (choice == 2)
                        {
                            Country country = new Country();
                            while (true)
                            {
                                Console.WriteLine("Введите название");
                                country.Name = Console.ReadLine();
                                if (!string.IsNullOrWhiteSpace(country.Name))
                                {
                                    break;
                                }
                            }
                        }
                        if (choice == 3)
                        {
                            while (true)
                            {
                                Console.WriteLine("Введите название страны");
                                string countryName = Console.ReadLine();
                                if (!string.IsNullOrWhiteSpace(countryName))
                                {
                                    while (true)
                                    {
                                        Console.WriteLine("Введите новое название");
                                        string newCountryName = Console.ReadLine();
                                        if (!string.IsNullOrWhiteSpace(newCountryName))
                                        {
                                            foreach (var country in context.Countries)
                                            {
                                                if (country.Name == newCountryName)
                                                {
                                                    country.Name = newCountryName;
                                                    context.SaveChanges();
                                                    break;
                                                }
                                            }
                                            Console.WriteLine("Страна не найдена");
                                            break;
                                        }
                                    }
                                    break;
                                }
                            }
                        }
                        if (choice == 4)
                        {
                            while (true)
                            {
                                Console.WriteLine("Введите название страны");
                                string countryName = Console.ReadLine();
                                if (!string.IsNullOrWhiteSpace(countryName))
                                {
                                    foreach (var country in context.Countries)
                                    {
                                        if (country.Name == countryName)
                                        {
                                            country.DeletedDate = DateTime.Now;
                                            context.SaveChanges();
                                            break;
                                        }
                                    }
                                    Console.WriteLine("Страна не найдена");
                                    break;
                                }
                            }
                        }
                        break;
                    }
                }
            }
        }
    }