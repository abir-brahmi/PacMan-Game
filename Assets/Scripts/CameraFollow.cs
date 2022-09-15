using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform pacMan;
    public float smoothSpeed;
    public Vector3 offset;
    float moveUp;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = pacMan.position + offset;
        moveUp = pacMan.transform.position.y;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveCamera = new Vector3(pacMan.transform.position.x, moveUp, pacMan.transform.position.z);
        transform.position = Vector3.Lerp(transform.position, moveCamera + offset, smoothSpeed * Time.deltaTime);
    }
}
