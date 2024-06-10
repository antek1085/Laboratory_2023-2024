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
   
   
   public event Action<float, float, int> OnSaveGame;
   
   public void SaveGame(float moneyEarned, float rent,int dayPassed)
   {
      if (OnSaveGame != null)
      {
         OnSaveGame(moneyEarned, rent,dayPassed);
      }
   }

   public event Action<int> OnButtonClick;

   public void ButtonClick(int saveFileNumber)
   {
      if (OnButtonClick != null)
      {
         OnButtonClick(saveFileNumber);
      }
   }


   public event Action<float, int> OnLoadGame;

   public void LoadGame(float rentAmount, int dayCount)
   {
      if (OnLoadGame != null)
      {
         OnLoadGame(rentAmount, dayCount);
      }
   }



}
