using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{

    public float _priceUp = 1f;
    public static int _maxProductsTaken = 4;
    public int _workers = 0;
    public int _maxClients = 3;
    public List<Item> _pullProducts;
    public  List<ShelfLogic> _pullShelf;
    public int SkillPoint {get;set;}

    public void UpgradePrice()
    {   
        if(SkillPoint > 0)
        { _priceUp += 0.15f; SkillPoint -= 1; }
    }
    public void UpgradeMaxProductsTaken()
    {
        if (SkillPoint > 0)
        { _maxProductsTaken += 1; SkillPoint -= 1; }
    }
    public void UpgradeWorkers()
    {
        if (SkillPoint > 0)
        { _workers += 1; SkillPoint -= 1; }
    }
    public void UpgradePullProducts(List<Item> _products)
    {
        _pullProducts.AddRange(_products);
    }


}
