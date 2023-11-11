using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemID : MonoBehaviour
{
    [SerializeField] SOMaterials soMaterials;
     public float iD;

    void Awake()
    {
        iD = soMaterials.iD;
    }
}
