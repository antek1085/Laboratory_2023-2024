using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class RecipeOneIngridient : ScriptableObject
{
    [SerializeField] private Item firstItem;

    [SerializeField] private Item result;

    public Item FirstItem => firstItem;
    public Item Result => result;
}
