using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdaterCanvas : MonoBehaviour
{
    public List<GameObject> buttonsShelfs;
   
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit) && hit.collider != null)
        {
            if (hit.collider.CompareTag("Shelf"))
            {
                for (int i = 0; i < hit.collider.GetComponent<ShelfLogic>().shelfSlots.Count; i++) 
                {
                    buttonsShelfs[i].SetActive(true);
                } 
            }
            else
            {
                for(int i = 0;i < buttonsShelfs.Count; i++)
                {
                    buttonsShelfs[i].SetActive(false);
                }
            }
        }
    }
    



}
