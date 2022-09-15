using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathSearch : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody RigidbodyPacman;
    Node pacmanNode;
    Node FantomeNode;
    public Rigidbody Fantome;
    public Grid grid;
    Vector3 _right = new Vector3(0, 90, 0);
    Vector3 _left = new Vector3(0, 270, 0);
    Vector3 _down = new Vector3(0, 180, 0);
    Vector3 _up = Vector3.zero;
    Vector3 _moveDirection = Vector3.zero;


    void Initialize()
    {
        _moveDirection = Vector3.zero;
        pacmanNode = grid.NodePosition(RigidbodyPacman.transform.position);
        FantomeNode = grid.NodePosition(Fantome.transform.position);

    }

    

    void MoveCharacter()
    {
        pacmanNode = grid.NodePosition(RigidbodyPacman.transform.position);
        FantomeNode = grid.NodePosition(Fantome.transform.position);

        Fantome.velocity = transform.forward * moveSpeed;
        Fantome.transform.rotation = Quaternion.Euler(_moveDirection);

        if (pacmanNode.posX < FantomeNode.posX && grid.isWalkable(FantomeNode.posX - 1, FantomeNode.posZ) )
        {
            
            _moveDirection = _left;

        }
        else if (pacmanNode.posX > FantomeNode.posX && grid.isWalkable(FantomeNode.posX + 1, FantomeNode.posZ))
        {
            _moveDirection = _right;

        }
        else if (pacmanNode.posZ < FantomeNode.posZ && grid.isWalkable(FantomeNode.posX, FantomeNode.posZ - 1))
        {
            _moveDirection = _down;

        }
        else if (pacmanNode.posZ > FantomeNode.posZ && grid.isWalkable(FantomeNode.posX, FantomeNode.posZ + 1))
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
