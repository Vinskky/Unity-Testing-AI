using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    // Start is called before the first frame update
    public FlockingManager myManager;
    public Vector3 direction;
    [Range(0,15)]
    public float speed;
    float freq = 0f;
    void Start()
    {
        //myManager = GetComponent<FlockingManager>();
        //speed = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        freq += Time.deltaTime;
        if(freq > 0.2)
        {
            freq -= 0.2f;

            Vector3 cohesion = Vector3.zero;
            Vector3 align = Vector3.zero;
            Vector3 separation = Vector3.zero;
            int num = 0;

            foreach (GameObject go in myManager.AllFish)
            {
                if (go != this.gameObject)
                {
                    float distance = Vector3.Distance(go.transform.position, transform.position);

                    if (distance <= myManager.NeighbourDistance)
                    {
                        cohesion += go.transform.position;
                        align += go.GetComponent<Flock>().direction;
                        separation -= (transform.position - go.transform.position) / (distance * distance);

                        num++;
                    }
                }
            }

            if (num > 0)
                cohesion = (cohesion / num - transform.position).normalized * myManager.MaxSpeed;

            if (num > 0)
            {
                align /= num;
                speed = Mathf.Clamp(align.magnitude, myManager.MinSpeed, myManager.MaxSpeed);
            }

            direction = (cohesion + align + separation).normalized * speed;

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), myManager.RotationSpeed * Time.deltaTime);

            transform.Translate(0.0f, 0.0f, Time.deltaTime * speed);
        }


    }
    Vector3 Flocking()
    {
        Vector3 cohesion = Vector3.zero;
        Vector3 align = Vector3.zero;
        Vector3 separation = Vector3.zero;
        int num = 0;

        foreach (GameObject go in myManager.AllFish)
        {
            if (go != this.gameObject)
            {
                float distance = Vector3.Distance(go.transform.position, transform.position);

                if (distance <= myManager.NeighbourDistance)
                {
                    cohesion += go.transform.position;
                    align += go.GetComponent<Flock>().direction;
                    separation -= (transform.position - go.transform.position) / (distance * distance);

                    num++;
                }
            }
        }

        if (num > 0)
            cohesion = (cohesion / num - transform.position).normalized * myManager.MaxSpeed;

        if (num > 0)
        {
            align /= num;
            speed = Mathf.Clamp(align.magnitude, myManager.MinSpeed, myManager.MaxSpeed);
        }

        direction = (cohesion + align + separation).normalized * speed;

        return direction;
    }

    /*void Cohesion()
    {
        Vector3 cohesion = Vector3.zero;
        int num = 0;

        foreach(GameObject go in myManager.AllFish)
        {
            if(go != this.gameObject)
            {
                float distance = Vector3.Distance(go.transform.position, transform.position);

                if(distance <= myManager.NeighbourDistance)
                {
                    cohesion += go.transform.position;
                    num++;
                }
            }
        }

        if (num > 0)
            cohesion = (cohesion / num - transform.position).normalized * myManager.MaxSpeed;
    }

    void VelAlign()
    {
        Vector3 align = Vector3.zero;
        int num = 0;

        foreach(GameObject go in myManager.AllFish)
        {
            if(go != this.gameObject)
            {
                float distance = Vector3.Distance(go.transform.position, transform.position);

                if(distance <= myManager.NeighbourDistance)
                {
                    align += go.GetComponent<Flock>().direction;
                    num++;
                }
            }
        }

        if(num > 0)
        {
            align /= num;
            speed = Mathf.Clamp(align.magnitude, myManager.MinSpeed, myManager.MaxSpeed);
        }
    }

    void Separation()
    {
        Vector3 separation = Vector3.zero;

        foreach (GameObject go in myManager.AllFish)
        {
            if(go != this.gameObject)
            {
                float distance = Vector3.Distance(go.transform.position, transform.position);

                if (distance <= myManager.NeighbourDistance)
                    separation -= (transform.position - go.transform.position) / (distance * distance);
            }
        }
    }*/

}
