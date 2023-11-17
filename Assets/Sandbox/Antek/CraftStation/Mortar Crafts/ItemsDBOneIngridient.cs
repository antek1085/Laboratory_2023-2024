using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class ItemsDBOneIngridient : ScriptableObject
{
    public List<RecipeOneIngridient> itemList = new List<RecipeOneIngridient>();
}
