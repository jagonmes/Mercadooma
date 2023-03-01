using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2D : MonoBehaviour
{
    private Vector3 CPos;

    public float CSpeed;
    // Start is called before the first frame update
    void Start()
    {
        CPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) 
        {
            CPos.y += CSpeed / 50;
        }
        if (Input.GetKey(KeyCode.S))
        {
            CPos.y -= CSpeed / 50;
        }
        if (Input.GetKey(KeyCode.A))
        {
            CPos.x += CSpeed / 50;
        }
        if (Input.GetKey(KeyCode.D))
        {
            CPos.x -= CSpeed / 50;
        }

        CPos.y += CSpeed;

        this.transform.position = CPos;
    }
}
