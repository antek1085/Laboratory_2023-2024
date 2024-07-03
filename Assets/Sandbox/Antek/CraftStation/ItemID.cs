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

     public string lore;

     private void Awake()
     {
          SaveSystemEvents.current.OnMakeItemSave += OnMakeItemSave;
     }

     void OnMakeItemSave()
     {
          SaveSystemEvents.current.ItemSave(_item.itemToSpawn, transform.position);
     }

     void OnDestroy()
     {
          SaveSystemEvents.current.OnMakeItemSave -= OnMakeItemSave;
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
