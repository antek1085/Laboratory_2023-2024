using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class RecipeThreeIngridients : ScriptableObject
{
    [SerializeField] private Item firstItem;
    [SerializeField] private Item secondItem;
    [SerializeField] private Item thirdItem;

    [SerializeField] private Item result;

    public Item FirstItem => firstItem;
    public Item SecondItem => secondItem;
    public Item ThirdItem => thirdItem;
    public Item Result => result;
}
