using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemID : MonoBehaviour
{
    [SerializeField] SOMaterials soMaterials;
     public float iD;
     public Item _item;
     public float time;
     public bool isTimeFlowing = false;

     void Awake()
     {
         // iD = soMaterials.iD;
     }

     private void Update()
     {
         // if (isTimeFlowing == true)
         // {
         //     time -= Time.deltaTime;
         //     Debug.Log(time + gameObject.name);
         // }
     }
}
