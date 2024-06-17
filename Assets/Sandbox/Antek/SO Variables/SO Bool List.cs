using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Bool List",menuName = "SO Scripts/Bool List")]
public class SOBoolList : ScriptableObject
{
    public bool[] Bools = new bool[3];
}
