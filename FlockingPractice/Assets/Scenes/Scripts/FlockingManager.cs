using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockingManager : MonoBehaviour
{
    public GameObject FishPrefab;
    public int NumFish;
    public GameObject[] AllFish;
    public Vector3 SwimLimits;
    public bool Bounded = false;
    public bool Randomize = false;
    public bool FollowLider = false;
    public GameObject Lider;
    //Fish Settings
    [Header("Fish Settings")]
    [Range(0.0f, 5.0f)]
    public float MinSpeed;
    [Range(0.0f, 5.0f)]
    public float MaxSpeed;
    [Range(0.0f, 12.0f)]
    public float NeighbourDistance;
    [Range(0.0f, 5.0f)]
    public float RotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        NumFish = 50;
        SwimLimits.Set(7, 5, 7);
        MinSpeed = 1.41f;
        MaxSpeed = 3.89f;
        NeighbourDistance = 4.2f;
        RotationSpeed = 0.4f;

        AllFish = new GameObject[NumFish];
        for(int i= 0; i < NumFish; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-SwimLimits.x, SwimLimits.x), Random.Range(-SwimLimits.y, SwimLimits.y), Random.Range(-SwimLimits.z, SwimLimits.z));
            Vector3 randomDirection = new Vector3(Random.value, Random.value, Random.value);

            Vector3 pos = this.transform.position + randomPosition; // + random position
            Vector3 randomize = randomDirection; ; //= random vector direction
            AllFish[i] = (GameObject)Instantiate(FishPrefab, pos, Quaternion.LookRotation(randomize));
            AllFish[i].GetComponent<Flock>().myManager = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
