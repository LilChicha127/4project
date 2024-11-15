using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Animations;

public class Builder : MonoBehaviour
{
    public GameObject shelf;
    private bool isBuild;
    private Color originalColor;
    private MeshRenderer[] meshRenderers;
    public Vector3 vector;
    private bool isGround;
    public SkillManager skillManager;
    private bool exists;
    public void setShelf(GameObject _shelf)
    {
        shelf = _shelf;
        shelf.GetComponent<Collider>().enabled = false;
        
        isBuild = true;
        for (int i = 0; i < skillManager._pullShelf.Count; i++)
        {
            if (skillManager._pullShelf[i].gameObject == shelf.gameObject)
            {
               
                skillManager._pullShelf.RemoveAt(i);
                break;
            }
        }
        // �������� ������������ ���� ���� MeshRenderer
        meshRenderers = shelf.GetComponentsInChildren<MeshRenderer>();
        if (meshRenderers.Length > 0)
        {
            originalColor = meshRenderers[0].material.color; // ��������� ������������ ���� (����� ��������� � ������)
        }

       
    }
    public void RotateObj(int i)
    {
        shelf.transform.Rotate(0, i, 0);

    }
    public void PutShelf()
    {
        if (isGround)
        {
            shelf.GetComponent<Collider>().enabled = true;
            PullShelfLogic(skillManager._pullShelf, shelf.GetComponent<ShelfLogic>()); // ��������� ������ ����� ��� AI
            SetColor(originalColor); // ���������� ������������ ����


            isBuild = false;

            shelf = null;
        }
    }

    private void PullShelfLogic(List<ShelfLogic> pullShelf, ShelfLogic _shelf)
    {
        
        
        for (int i = 0; i < pullShelf.Count; i++)
        {
            if (pullShelf[i].gameObject == shelf.gameObject)
            {
                exists = true;
                Debug.Log("������� ��� ���������� � ������");
                break;
            }
        }

        if (!exists) // ���� ���� �������, ��� �������� ���
        {
            pullShelf.Add(_shelf);
            Debug.Log("������� �������� � ������");
        }

        if (pullShelf == null || pullShelf.Count < 1)
        {
            pullShelf.Add(_shelf);
        }
    }

    private void Update()
    {
        if (isBuild)
        {
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit))
            {
                shelf.transform.position = hit.point;
                if (hit.collider.CompareTag("Ground"))
                {
                    isGround = true;
                    SetColor(Color.green);
                    
                }
                else
                {
                    isGround = false;
                    SetColor(Color.red);
                }
            }
            
        }
    }
   
    private void SetColor(Color color)
    {
        foreach (var renderer in meshRenderers)
        {
            renderer.material.color = color; // ������ ���� ��� ������� MeshRenderer
        }
    }
}


