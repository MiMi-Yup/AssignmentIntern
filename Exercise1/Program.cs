using System;

namespace Exercise1
{
    internal class Program
    {
        static (int hours, int minutes) ReadInput()
        {
            int hours = -1;
            int minutes = -1;

            do
            {
                Console.WriteLine("Please enter hour: ");
                //The 12-hour clock is most commonly represented on an analogue clock
            } while (!int.TryParse(Console.ReadLine(), out hours) || hours < 0 && hours > 12);

            do
            {
                Console.WriteLine("Please enter minute: ");
            } while (!int.TryParse(Console.ReadLine(), out minutes) || minutes < 0 && minutes > 60);

            return (hours, minutes);
        }

        static double CalLesserAngle(double hour, double minutes)
        {
            //(minute * 1.0 / 60) * 360 = minute * 6.0;
            double angleOfMinute = minutes * 6.0;
            //((hour + minute * 1.0 / 60) / 12) * 360 = hour * 30 + minute * 1.0 / 2
            double angleOfHour = hour * 30 + minutes * 1.0 / 2;

            double offsetAngle = Math.Abs(angleOfHour - angleOfMinute);
            //get lesser angle
            offsetAngle = offsetAngle > 180 ? 360 - offsetAngle : offsetAngle;

            return offsetAngle;
        }

        static void Main(string[] args)
        {
            (int hours, int minutes) = ReadInput();

            //formating input 
            hours = hours == 12 ? 0 : hours;
            minutes = minutes == 60 ? 0 : minutes;

            double offsetAngle = CalLesserAngle(hours, minutes);

            Console.WriteLine("Angle in degress between hours arrow and minutes: {0}", offsetAngle);
        }
    }
}
