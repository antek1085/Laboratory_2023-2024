using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemID : MonoBehaviour
{
     public Item _item;
     public itemCategory mainItemCategory;
     public List<itemSymptoms> symptoms = new List<itemSymptoms>();
     public int moneyValue;
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
