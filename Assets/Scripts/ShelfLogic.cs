using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfLogic : MonoBehaviour
{
    
    public List<ShelfSlot> shelfSlots;
    public int indexShelf;
    public string Type;
   
    public void chooseShelf(ItemScriptableObject product, int index, int _amount, int price, string type)
    {
        if (type == Type)
        {
            Debug.Log($"1 Choosing shelf with Type: {Type}, Product: {product}, Index: {index}, Amount: {_amount}, Price: {price}");
            if ((shelfSlots[index].Item == null || shelfSlots[index].amountPlace == 0) || (product == shelfSlots[index].Item))
            {

                Debug.Log($"2 Choosing shelf with Type: {Type}, Product: {product}, Index: {index}, Amount: {_amount}, Price: {price}");



                shelfSlots[index].productPrice = price;
                shelfSlots[index].Item = product;
                int i = shelfSlots[index].amountPlace - _amount;
                if (i < 0)
                {
                    Debug.Log($"3 Choosing shelf with Type: {Type}, Product: {product}, Index: {index}, Amount: {_amount}, Price: {price}");
                    shelfSlots[index].amountPlace = 0;
                }
                else
                {
                    Debug.Log($"4 Choosing shelf with Type: {Type}, Product: {product}, Index: {index}, Amount: {_amount}, Price: {price}");
                    shelfSlots[index].amountPlace = i;
                }
            }   
        }
    }

  

   
}
