using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class DeliveryList : ScriptableObject
{
    public List<Item> itemList = new List<Item>();
}
