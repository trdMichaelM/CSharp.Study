using System;

namespace _004_Enum;

public class Program
{
    enum WeekDays
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }

    static void Main(string[] args)
    {
        string[] WeekDaysRussianNames = { "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота", "Воскресенье" };

        WeekDays day = WeekDays.Thursday;

        Console.WriteLine($"Сегодня {day}");
        Console.WriteLine($"Сегодня {WeekDaysRussianNames[(int)day]}");
        int dayIndex = (int)day + 1;
        Console.WriteLine($"Номер дня {dayIndex}");

        if (day == WeekDays.Friday)
            Console.WriteLine($"Номер дня {dayIndex}");

        Console.ReadKey();
    }
}
