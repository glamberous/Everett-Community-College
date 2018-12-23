// Lesson 10 - Assignment
// Author - Mike Orsega

using System;
using TimeNamespace;

public class UsingTime
{
  public static void Main()
  {
      Time myTime = new Time();
      Time yourTime = new Time();

      myTime.SetHour(25);
      myTime.SetMinute(59);
      myTime.SetSecond(59);

      myTime.DisplayCivilian();

      myTime.AddSecond();

      myTime.DisplayCivilian();

      yourTime.DisplayMilitary();
  }
} 
