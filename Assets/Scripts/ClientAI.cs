using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClientAI : MonoBehaviour
{
    public NavMeshAgent agent;
    private List<ShelfLogic> shelfLogic;
    public List<Item> products;
    public int maxTaken;
    

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        MoveToRandomShelf();

    }

    private void Update()
    {
        // ���������, �������� �� �� �������� �����
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            // ���� ��������, ������ ����� ����
            MoveToRandomShelf();

            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit) && hit.collider != null && hit.collider == GetComponent<ShelfLogic>())
            {
                
                
            }
        }
    }
    public void SetAI(int maxTaken, List<Item> products, List<ShelfLogic> shelfLogic)
    {
        this.maxTaken = Random.Range(1, maxTaken+1);
        this.shelfLogic = shelfLogic;
        for(int i = 0; i < maxTaken; i++)
        {
            this.products.Add(products[Random.Range(0, products.Count)]);
        }
    }
    private void MoveToRandomShelf()
    {
        // �������� ��������� �����
        ShelfLogic randomShelf = shelfLogic[Random.Range(0, shelfLogic.Count-1)];
        // ������������� ����� ����
        agent.SetDestination(randomShelf.transform.position);
    }
}