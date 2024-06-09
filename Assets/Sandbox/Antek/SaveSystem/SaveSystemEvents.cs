using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class SaveSystemEvents : MonoBehaviour
{
   public static SaveSystemEvents current;

   public void Awake()
   {
      current = this;
   }
   
   
   public event Action<float, float, int> onSaveGame;
   
   public void SaveGame(float moneyEarned, float rent,int dayPassed)
   {
      if (onSaveGame != null)
      {
         onSaveGame(moneyEarned, rent,dayPassed);
      }
   }

   public event Action<int> onButtonClick;

   public void ButtonClick(int saveFileNumber)
   {
      if (onButtonClick != null)
      {
         onButtonClick(saveFileNumber);
      }
   }



}
