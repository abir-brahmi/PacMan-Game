using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public GameObject bottomLeft, topRight;
    Node[,] gridNode;
    public LayerMask unwalkable;

    //Grid info 
    int xbottomLeft, zbottomLeft;
    int xtopRight, ztopRight;

    //number of nodes in the grid
    int vCells = 0, hCells =0;

    int cellwith = 1;
    int cellHeight = 1;

    void InitializeGrid()
    {
        xbottomLeft = (int)bottomLeft.transform.position.x;
        zbottomLeft = (int)bottomLeft.transform.position.z;

        xtopRight = (int)topRight.transform.position.x;
        ztopRight = (int)topRight.transform.position.z;

        hCells = (int)((xtopRight - xbottomLeft) / cellwith);
        vCells = (int)((ztopRight - zbottomLeft) / cellHeight);
        gridNode = new Node[hCells +1 , vCells +1];
        UpdateGrid();

    }

    public void UpdateGrid()
    {
    for (int i = 0; i<=hCells; i++){
            for (int j = 0;j <= vCells; j++)
            {
                bool walkable = !(Physics.CheckSphere(new Vector3(xbottomLeft + i, 0, zbottomLeft + j), 0.4f, unwalkable));
                gridNode[i, j] = new Node(i, j, 0, walkable);
            }
        }
    }
    void Awake()
    {
        InitializeGrid();
    }
    void OnDrawGizmos()
    {
        if(gridNode != null)
        {
            foreach (Node node in gridNode)
            {
                Gizmos.color = (node.walkable) ? Color.white : Color.red;
                Gizmos.DrawWireCube(new Vector3(xbottomLeft + node.posX, 0, zbottomLeft + node.posZ), new Vector3(0.8f, 0.8f, 0.8f));
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
