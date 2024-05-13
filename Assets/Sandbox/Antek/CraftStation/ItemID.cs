using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class ItemID : MonoBehaviour
{
     public Item _item;
     public itemCategory mainItemCategory;
     public List<itemSymptoms> symptoms = new List<itemSymptoms>();
   //  public Dictionary<itemSymptoms, Sprite> symptoms = new Dictionary<itemSymptoms, Sprite>();
     public List<Sprite> SpritesSymptoms = new List<Sprite>();
     [SerializeField] List<Sprite> allSpritesSymptoms = new List<Sprite>();
     public int moneyValue;

      void Awake()
     {
          for (int i = 0; i < symptoms.Count -1; i++)
          {
               switch (symptoms[i])
               {
                    case itemSymptoms.nothing:
                         SpritesSymptoms.Add(allSpritesSymptoms[0]);
                         break;
                    case itemSymptoms.cought:
                         SpritesSymptoms.Add(allSpritesSymptoms[1]);
                         break;
                    case itemSymptoms.pain:
                         SpritesSymptoms.Add(allSpritesSymptoms[2]);
                         break;
                    case itemSymptoms.insomnia:
                         SpritesSymptoms.Add(allSpritesSymptoms[3]);
                         break;
                    case itemSymptoms.fever:
                         SpritesSymptoms.Add(allSpritesSymptoms[4]);
                         break;
                    case itemSymptoms.cuts:
                         SpritesSymptoms.Add(allSpritesSymptoms[5]);
                         break;
                    case itemSymptoms.indigestion:
                         SpritesSymptoms.Add(allSpritesSymptoms[6]);
                         break;
                    case itemSymptoms.cold:
                         SpritesSymptoms.Add(allSpritesSymptoms[7]);
                         break;
                    case itemSymptoms.impotence:
                         SpritesSymptoms.Add(allSpritesSymptoms[8]);
                         break;
                    default:
                         Debug.Log("Sprite nie podpięty");
                         break;
               }
          }
     }
}

     public enum itemCategory
     { 
          materials, 
          syrup,
          pills,
          ointment
     }
     public enum itemSymptoms
     {
          nothing ,
          cought ,
          pain,
          insomnia,
          fever,
          cuts,
          indigestion,
          cold,
          impotence,
          
     }
