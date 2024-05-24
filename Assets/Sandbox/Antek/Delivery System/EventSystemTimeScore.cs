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
}
