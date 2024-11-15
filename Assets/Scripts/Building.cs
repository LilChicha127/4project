using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Building : MonoBehaviour
{
    public List<Renderer> MainRenderer;
    public Vector2Int Size = Vector2Int.one;

    public void SetTransparent(bool available)
    {
        if (available)
        {
            SetColor(Color.green);

        }
        else
        {
            SetColor(Color.red);
        }
    }

    public void SetNormal()
    {
        SetColor(Color.white);
    }
    private void SetColor(Color color)
    {
        for (int i = 0; i < MainRenderer.Count; i++)
        {

            MainRenderer[i].material.color = color;
        }
    }
    private void OnDrawGizmos()
    {
        for (int x = 0; x < Size.x; x++)
        {
            for (int y = 0; y < Size.y; y++)
            {
                if ((x + y) % 2 == 0) Gizmos.color = new Color(0.88f, 0f, 1f, 0.3f);
                else Gizmos.color = new Color(1f, 0.68f, 0f, 0.3f);

                Gizmos.DrawCube(transform.position + new Vector3(x, 0, y), new Vector3(1, .1f, 1));
            }
        }
    }
}
