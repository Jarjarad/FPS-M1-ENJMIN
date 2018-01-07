using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnerammochest : MonoBehaviour
{
    public Transform Pickup;
    public float waterLevel = 0.0f;
    public const int MaxNumberContainer = 10;

    private int NumberContainer = 0;
    private const float maxDistanceRayCast = 300.0f;
    private const float topY = 200.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (NumberContainer < MaxNumberContainer)
        {
            bool foundGoodPos = false;
            float randomX = 0.0f;
            float randomZ = 0.0f;

            Vector3 newPickupPos = new Vector3(randomX, topY, randomZ);

            while (!foundGoodPos)
            {
                randomZ = Random.Range(-100.0f, 100.0f);
                randomX = Random.Range(-100.0f, 100.0f);
                newPickupPos = new Vector3(randomX, topY, randomZ);

                RaycastHit hit;

                if (Physics.Raycast(newPickupPos, -Vector3.up, out hit, maxDistanceRayCast))
                {
                    if (hit.collider.name == "Terrain") // Pas sur que ca soit très propre
                    {
                        newPickupPos.y = topY - hit.distance;
                        foundGoodPos = true;
                    }
                }
            }

            Instantiate(Pickup, newPickupPos, Quaternion.identity);

            NumberContainer++;
        }
    }
}
