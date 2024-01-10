using System;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            int examHour = int.Parse(Console.ReadLine());
            int examMinute = int.Parse(Console.ReadLine());
            int arrivalHour = int.Parse(Console.ReadLine());
            int arrivalMinute = int.Parse(Console.ReadLine());

            int examTotalMinutes = examHour * 60 + examMinute;
            int arrivalTotalMinutes = arrivalHour * 60 + arrivalMinute;

            if (arrivalTotalMinutes > examTotalMinutes)
            {
                Console.WriteLine("Late");

                int delayMinutes = arrivalTotalMinutes - examTotalMinutes;
                int delayHours = delayMinutes / 60;
                delayMinutes %= 60;

                if (delayHours >= 1)
                {
                    Console.WriteLine($"{delayHours}:{delayMinutes:D2} hours after the start");
                }
                else
                {
                    Console.WriteLine($"{delayMinutes} minutes after the start");
                }
            }
            else if (arrivalTotalMinutes <= examTotalMinutes && arrivalTotalMinutes >= examTotalMinutes - 30)
            {
                Console.WriteLine("On time");

                int minutesDifference = examTotalMinutes - arrivalTotalMinutes;
                if (minutesDifference > 0)
                {
                    Console.WriteLine($"{minutesDifference} minutes before the start");
                }
            }
            else
            {
                Console.WriteLine("Early");

                int earlyMinutes = examTotalMinutes - arrivalTotalMinutes;
                int earlyHours = earlyMinutes / 60;
                earlyMinutes %= 60;

                if (earlyHours >= 1)
                {
                    Console.WriteLine($"{earlyHours}:{earlyMinutes:D2} hours before the start");
                }
                else
                {
                    Console.WriteLine($"{earlyMinutes} minutes before the start");
                }
            }
        }
    }
}