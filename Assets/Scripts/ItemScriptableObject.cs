using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemScriptableObject", menuName = "Item")]
public class ItemScriptableObject : ScriptableObject
{
    public Sprite sprite;
    public GameObject prefab;
    public int amount;
    public string nameItem;
    
    public string typeProduct; //shelf, fridge, freazer
}
