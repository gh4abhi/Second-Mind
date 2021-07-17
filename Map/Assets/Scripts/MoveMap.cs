using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMap : MonoBehaviour
{
    private Vector3 TouchPosition;
    private Rigidbody rb;
    private Vector3 direction;
    private float moveSpeed = 10f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount>0)
        {
            Touch touch = Input.GetTouch(0);
            TouchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            direction = (TouchPosition - transform.position);
            rb.velocity = new Vector3(direction.x, direction.y, direction.z) * moveSpeed;
            if(touch.phase==TouchPhase.Ended)
            {
                rb.velocity = Vector3.zero;
            }
        }
    }
}
