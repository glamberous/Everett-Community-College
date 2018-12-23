/*
Finish the Time class that was started in this lesson. Do this by completing the following methods:

SetMinute(int m)

SetSecond(int s)

GetMinute()

GetSecond()

AddSecond() - This method should add 1 to the second variable stored in the current object. If the second becomes 60, be sure to set the second equal to 0 and increment the minute by one.

AddMinute() - This method should add 1 to the minute variable stored in the current object. If the minute becomes 60, be sure to set the minute equal to 0 and increment the hour variable by one.

AddHour() - This method should add 1 to the hour variable stored in the current object. If the hour becomes 24, be sure to set the hour equal to 0.

DisplayCivilian() - This method should display the time stored in the object as civilian time.

DisplayMilitary() - This method should display the time stored in the object as military time.

Equals(Time t) - This method should compare the time stored in the current object to the time stored in the Time object t that is passed into the method.
*/

namespace TimeNamespace
{

    using System;

    public class Time
    {
        private int hour;
        private int minute;
        private int second;
        
        public Time()
        {
            DateTime current = DateTime.Now;
            hour = current.Hour;
            minute = current.Minute;
            second = current.Second;
        }

        public Time (int hour, int minute, int second)
        {
            this.Hour = hour;
            this.Minute = minute;
            this.Second = second;
        }

        public int Hour
        {
            get => hour; 
            set => hour = value % 24;
        }

        public int Minute
        {
            get => minute; 
            set => minute = value % 60;
        }

        public int Second
        {
            get => second; 
            set => second = value % 60;
        }

        public void AddHour() => this.Hour++;
        public void AddMinute() 
        { 
            this.Minute++;
            if(this.Minute == 0) 
                this.AddHour();
        }

        public void AddSecond() 
        {
            this.Second++;
            if(this.Second == 0)
                this.AddMinute();
        } 

        enum Meridiem {AM, PM};

        public void DisplayCivilian()
        {
            Meridiem MeridiemValue = Meridiem.AM;
            int civilHour = hour;
            
            if (civilHour >= 12)
            {
                MeridiemValue = Meridiem.PM;
                civilHour = civilHour - 12;
            } 
            else if (civilHour == 0)
            {
                MeridiemValue = Meridiem.AM;
                civilHour = 12;
            }

            string minuteOutput = minute.ToString("00");
            Console.WriteLine(civilHour + ":" + minuteOutput + MeridiemValue);
        }

        public void DisplayMilitary()
        {
            string minuteOutput = minute.ToString("00");
            string secondOutput = second.ToString("00");
            Console.WriteLine(hour + ":" + minuteOutput + ":" + secondOutput);
        }

        public bool Equals(Time TestEqualTo) => 
        (hour == TestEqualTo.hour && 
        minute == TestEqualTo.minute && 
        second == TestEqualTo.second);
    }
}