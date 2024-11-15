using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectToBox : MonoBehaviour
{
    [SerializeField]public GameObject gmInBox;
    
    public void SpawnObject()
    {
        Instantiate(gmInBox, transform.position, gmInBox.transform.rotation);
    }

}
