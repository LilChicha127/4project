using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public Vector2Int GridSize = new Vector2Int(10, 10);

    private Building[,] grid;
    private Building flyingBuilding;

    public GameObject interfaceBuild;

    private void Awake()
    {
        grid = new Building[GridSize.x, GridSize.y];

        
    }

    public void StartPlacingBuilding(Building buildingPrefab)
    {
        if (flyingBuilding != null)
        {
            Destroy(flyingBuilding.gameObject);
        }

        flyingBuilding = Instantiate(buildingPrefab);
        interfaceBuild.SetActive(true);
    }

    public void MoveBuildingLeft()
    {
        MoveBuilding(-1, 0);
    }

    public void MoveBuildingRight()
    {
        MoveBuilding(1, 0);
    }

    public void MoveBuildingUp()
    {
        MoveBuilding(0, 1);
    }

    public void MoveBuildingDown()
    {
        MoveBuilding(0, -1);
    }

    private void MoveBuilding(int deltaX, int deltaZ)
    {
        if (flyingBuilding == null) return;

       
        Vector2Int currentPosition = new Vector2Int((int)flyingBuilding.transform.position.x, (int)flyingBuilding.transform.position.z);
        Vector2Int newPosition = new Vector2Int(currentPosition.x + deltaX, currentPosition.y + deltaZ);

        
        if (newPosition.x >= 0 && newPosition.x < GridSize.x &&
            newPosition.y >= 0 && newPosition.y < GridSize.y && !IsPlaceTaken(newPosition.x, newPosition.y))
        {
            // Перемещаем flyingBuilding
            flyingBuilding.transform.position = new Vector3(newPosition.x, flyingBuilding.transform.position.y, newPosition.y);
        }
    }


    private bool IsPlaceTaken(int placeX, int placeY)
    {
        for (int x = 0; x < flyingBuilding.Size.x; x++)
        {
            for (int y = 0; y < flyingBuilding.Size.y; y++)
            {
                if (grid[placeX + x, placeY + y] != null) return true;
            }
        }

        return false;
    }

    public void PlaceFlyingBuilding()
    {
        

        flyingBuilding.SetNormal();
        flyingBuilding = null;
    }
}
