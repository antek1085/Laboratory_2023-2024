using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class RecipeTwoIngridient : ScriptableObject
{
    [SerializeField] private Item firstItem;
    [SerializeField] private Item secondItem;

    [SerializeField] private Item result;

    public Item FirstItem => firstItem;
    public Item SeconItem => secondItem;
    public Item Result => result;
}
