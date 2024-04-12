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

   public event Action onMiniGameEnd;

   public void StartCraft()
   {
      if (onMiniGameEnd != null)
      {
         onMiniGameEnd();
      }
   }

   public event Action onMiniGameStart;

   public void MiniGameStart()
   {
      if (onMiniGameStart != null)
      {
         onMiniGameStart();
      }
   }
}
