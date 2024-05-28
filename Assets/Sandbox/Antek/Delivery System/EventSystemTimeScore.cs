using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystemTimeScore : MonoBehaviour
{
    public static EventSystemTimeScore current;

    public void Awake()
    {
        current = this;
    }
    
    public event Action<float> onMoneyAdded;

    public void MoneyAdded(float money)
    {
        if (onMoneyAdded != null)
        {
            onMoneyAdded(money);
        }
    }

    public event Action<bool> onTimeEnd;

    public void TimeEnd(bool isTimeEnded)
    {
        if (onTimeEnd != null)
        {
            onTimeEnd(isTimeEnded);
        }
    }

    public event Action<bool> onTimeStart;

    public void TimeStart(bool isTimeStart)
    {
        if (onTimeStart != null)
        {
            onTimeStart(isTimeStart);
        }
    }

    public event Action<int> onGoingSleep;

    public void GoingSleep(int dayPassed)
    {
        if (onGoingSleep != null)
        {
            onGoingSleep(dayPassed);
        }
    }

    public event Action<float, float,int> onEndDay;

    public void EndDay(float moneyEarned, float rent,int rentPayDay)
    {
        if (onEndDay != null)
        {
            onEndDay(moneyEarned, rent,rentPayDay);
        }
    }
    
    public event Action<bool> onPayRent;

    public void PayRent(bool canHePay)
    {
        if (onPayRent != null)
        {
            onPayRent(canHePay);
        }
    }
}
