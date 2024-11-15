using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProductsPanel : MonoBehaviour
{
    public SkillManager skillManager;
    public ProiductSlot productSlotPrefab;
    public GameObject panel;
    public void UpdateProductsPanel()
    {
        if (!panel.activeSelf)
        {
            panel.SetActive(!panel.activeSelf);
            for (int i = 0; i < skillManager._pullProducts.Count; i++)
            {
                ProiductSlot productSlot = Instantiate(productSlotPrefab, panel.transform);
                productSlot.SetUpProduct(skillManager._pullProducts[i]);
            }
        }
        else
        {
            panel.SetActive(!panel.activeSelf);

            foreach (Transform child in panel.transform)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
