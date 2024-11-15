using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ProiductSlot : MonoBehaviour
{
    public Item thisProduct;
    public Image image;
    public string nameProduct;
    public TextMeshProUGUI _valueText, _nameText, _priceText;
    public int value;
    public int price;
   

    public void BuyProduct()
    {
       Instantiate(thisProduct.item.prefab);
    }
    public void SetUpProduct(Item _product)
    {
        thisProduct = _product;
        image.sprite = _product.item.sprite;
        nameProduct = _product.item.nameItem;
        value = _product.Itemamount;
        price = _product.ItemPrice;
        _nameText.text = nameProduct.ToString();
        _valueText.text = value.ToString();
        _priceText.text = price.ToString() + "$"; 
    }
}
