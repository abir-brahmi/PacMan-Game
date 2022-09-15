using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathSearch : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody rigidbodyPacman;
    public Rigidbody rigidbodyGhost;
    Node pacmanNode;
    Node GhostNode;
   
    public Grid grid;
    Vector3 _right = new Vector3(0, 90, 0);
    Vector3 _left = new Vector3(0, 270, 0);
    Vector3 _down = new Vector3(0, 180, 0);
    Vector3 _up = Vector3.zero;
    Vector3 _moveDirection = Vector3.zero;


    void Initialize()
    {
        _moveDirection = Vector3.zero;
        pacmanNode = grid.NodePosition(rigidbodyPacman.transform.position);
        GhostNode = grid.NodePosition(rigidbodyGhost.transform.position);

    }

    

    void MoveCharacter()
    {
        pacmanNode = grid.NodePosition(rigidbodyPacman.transform.position);
        GhostNode = grid.NodePosition(rigidbodyGhost.transform.position);

        rigidbodyGhost.velocity = transform.forward * moveSpeed;
        rigidbodyGhost.transform.rotation = Quaternion.Euler(_moveDirection);

        if (pacmanNode.posX < GhostNode.posX && grid.isWalkable(GhostNode.posX - 1, GhostNode.posZ) )
        {
            
            _moveDirection = _left;

        }
        else if (pacmanNode.posX > GhostNode.posX && grid.isWalkable(GhostNode.posX + 1, GhostNode.posZ))
        {
            _moveDirection = _right;

        }
        else if (pacmanNode.posZ < GhostNode.posZ && grid.isWalkable(GhostNode.posX, GhostNode.posZ - 1))
        {
            _moveDirection = _down;

        }
        else if (pacmanNode.posZ > GhostNode.posZ && grid.isWalkable(GhostNode.posX, GhostNode.posZ + 1))
        {
            _moveDirection = _up;
        }


       

    }
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveCharacter();
    }
}
