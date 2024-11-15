using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerAI : MonoBehaviour
{
    [SerializeField] public ClientAI AIGO;
    public SkillManager SkillManager;
    
   

    private void SetPul()
    {
        for (int i = 0; i <= SkillManager._maxClients; i++)
        {
            
                SkillManager._maxClients--;
                
                ClientAI clientAI = Instantiate(AIGO, transform);
                clientAI.SetAI(SkillManager._maxProductsTaken, SkillManager._pullProducts, SkillManager._pullShelf);
            
        }
        
    }

    private void Update()
    {
        if (SkillManager._maxClients > 0)
        {
            
            SetPul();
        }
    }

}
