// Lesson 10 - Assignment
// Author - Mike Orsega

namespace TimeNamespace
{
  using System;

  class Time
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

      public Time(int h, int m, int s)
      {
    	if(h < 0 || h > 23)
           hour = 0;
    	else
           hour = h;

    	if (m < 0 || m > 59)
           minute = 0;
    	else
           minute = m;

    	if (s < 0 || s > 59)
           second = 0;
    	else
           second = s;
      }

      public void SetHour(int h)
      {
          if(h < 0 || h > 23)
          {
              Console.Out.Write("Invalid hour.");
              Console.Out.WriteLine(" Setting hour to 0.");
              hour = 0;
          }
          else
              hour = h;
      }
      
      public int GetHour()
      {
          return hour;
      }

      public void SetMinute(int m)
      {
	  if (m < 0 || m > 59)
	  {
	     Console.Out.Write("Invalid minute.");
	     Console.Out.WriteLine(" Setting minute to 0.");
	     minute = 0;
	  }
	  else
	     minute = m;
      }

      public int GetMinute()
      {
          return minute;
      }

      public void SetSecond(int s)
      {
	  if (s < 0 || s > 59)
	  {
	     Console.Out.Write("Invalid second.");
	     Console.Out.WriteLine(" Setting second to 0.");
	     second = 0;
	  }
	  else
	     second = s;
      }

      public int GetSecond()
      {
          return second;
      }

      public void AddSecond()
      {
	  second++;
	  if (second == 60)
	  {
	    second = 0;
	    AddMinute();
	  }
      }

      public void AddMinute()
      {
	  minute++;
	  if(minute == 60)
	  {
	    minute = 0;
	    AddHour();
	  }
      }

      public void AddHour()
      {
	  hour++;
	  if(hour == 24)
	     hour = 0;
      }

      public void DisplayCivilian()
      {
	  Console.Out.Write("The time is ");
	  if (hour <= 12)
	  {
	    Console.Out.Write(hour + ":");
	    Console.Out.WriteLine(minute + ":" + second);
	  }
	  else
	  {
	    Console.Out.Write(hour - 12 + ":");
	    Console.Out.WriteLine(minute + ":" + second);
	  }
      }

      public void DisplayMilitary()
      {
	  Console.Out.Write("The time is ");
	  Console.Out.Write(hour + ":");
	  Console.Out.WriteLine(minute + ":" + second);
      }

      public bool Equals(Time t)
      {
	if ( t.GetHour() == hour &&
	     t.GetMinute() == minute &&
	     t.GetSecond() == second)
	   return true;
	else
	   return false;
      }
  }
}
