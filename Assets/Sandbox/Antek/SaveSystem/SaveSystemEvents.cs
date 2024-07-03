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
   
   
   public event Action<float, float, int,Dictionary<Quaternion,Vector3>> OnSaveGame;
   
   public void SaveGame(float moneyEarned, float rent,int dayPassed,Dictionary<Quaternion,Vector3> playerValueSaves)
   {
      if (OnSaveGame != null)
      {
         OnSaveGame(moneyEarned, rent,dayPassed,playerValueSaves);
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


   public event Action<float, int,Dictionary<Quaternion,Vector3>> OnLoadGame;

   public void LoadGame(float rentAmount, int dayCount,Dictionary<Quaternion,Vector3> playerValueSaves)
   {
      if (OnLoadGame != null)
      {
         OnLoadGame(rentAmount, dayCount,playerValueSaves);
      }
   }

   public event Action<GameObject, Vector3> OnItemSave;

   public void ItemSave(GameObject item, Vector3 itemTransform)
   {
      if (OnItemSave != null)
      {
         OnItemSave(item,itemTransform);
      }
   }

   public event Action OnMakeItemSave;

   public void MakeItemSave()
   {
      if (OnMakeItemSave != null)
      {
         OnMakeItemSave();
      }
   }

}
