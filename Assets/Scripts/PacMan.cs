using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacMan : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody RigidbodyPacman;
    Vector3 _right = new Vector3(0, 90, 0);
    Vector3 _left = new Vector3(0, 270, 0);
    Vector3 _down = new Vector3(0, 180, 0);
    Vector3 _up = Vector3.zero;
    Vector3 _moveDirection = Vector3.zero;

   
    void Initialize()
    {
        _moveDirection = Vector3.zero;
    }


    void MoveCharacter()
    {
        RigidbodyPacman.velocity = transform.forward * moveSpeed;
        transform.rotation = Quaternion.Euler(_moveDirection);
        

        if (Input.GetAxis("Horizontal") < 0) 
        {
            _moveDirection = _left;
           
        }
        if (Input.GetAxis("Horizontal") > 0) 
        {
            _moveDirection = _right;
      
        }
        if (Input.GetAxis("Vertical") > 0) 
        {
            _moveDirection = _up;
        }
        if (Input.GetAxis("Vertical") < 0) 
        {
            _moveDirection = _down;
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
