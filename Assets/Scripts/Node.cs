using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{

    public Node parentNode;

    public int posX;
    public int posZ;
    public int state;

    public bool walkable;
    public Node(int posX, int posZ, int state,bool walkable)
    {
        this.posX = posX;
        this.posZ = posZ;
        this.state = state;
        this.walkable = walkable;

    }

}
