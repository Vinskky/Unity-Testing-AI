using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Seek : MonoBehaviour
{
    public GameObject target;
    float angle;
    float maxVelocity = 0.25f;
    public float turnSpeed;
    Quaternion rotation;
    Vector3 movement;
    Vector3 direction;
    float freq = 0f;

    // Start is called before the first frame update
    void Start()
    { 
        
    }

    // Update is called once per frame
    void Update()
    {
        freq += Time.deltaTime;
        if(freq > 0.5)
        {
            freq -= 5;
            direction = target.transform.position - transform.position;
            direction.y = 0f;

            movement = direction.normalized * maxVelocity;

            angle = Mathf.Rad2Deg * Mathf.Atan2(movement.x, movement.z);
            rotation = Quaternion.AngleAxis(angle, Vector3.up); // up = y
            //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * turnSpeed);
            //transform.position = transform.forward.normalized * maxVelocity * Time.deltaTime;
        }
    }
}
