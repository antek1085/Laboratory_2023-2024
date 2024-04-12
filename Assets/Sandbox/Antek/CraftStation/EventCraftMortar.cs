using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCraftMortar : MonoBehaviour
{
   public static EventCraftMortar current;

   public void Awake()
   {
      current = this;
   }

   public event Action<int> onMiniGameEnd;

   public void MiniGameEnd(int id)
   {
      if (onMiniGameEnd != null)
      {
         onMiniGameEnd(id);
      }
   }

   public event Action<int> onMiniGameStart;

   public void MiniGameStart(int id)
   {
      if (onMiniGameStart != null)
      {
         onMiniGameStart(id);
      }
   }
}
