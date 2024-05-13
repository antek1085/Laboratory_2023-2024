using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "GameObject List",menuName = "SO Scripts/GameObject List")]
public class SOGameObjectList : ScriptableObject
{
    public List<GameObject> SymptomsSprites = new List<GameObject>();
}
