using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] NPC;
    public GameObject[] power;

    [Header("Gestione posizione oggetti")]
    public float xEnemySpawn = 18.0f;
    public float zSpawnRange = 6.0f;
    public float xSpawnRange = 12.0f;
    public float xPower = 5.0f;
    public float ySpawn = 0.75f;

    [Header("Gestione tempo comparsa oggetti")]
    public float powerSpawnTime = 5.0f;
    public float NPCSpawnTime = 1.0f;
    private float startDelay = 1.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnNPC", startDelay, NPCSpawnTime);
        InvokeRepeating("SpwanPower", startDelay, powerSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void SpawnNPC()
    {
        float randomZ = Random.Range (-zSpawnRange, zSpawnRange );
        int randomIndex = Random.Range (0, NPC.Length);

        Vector3 spawnPos = new Vector3(xEnemySpawn, ySpawn, randomZ);

        Instantiate(NPC[randomIndex], spawnPos, NPC[randomIndex].gameObject.transform.rotation);

    }

    void SpwanPower()
    {
        float randomZ = Random.Range (-zSpawnRange, zSpawnRange );
        float randomX = Random.Range (-xSpawnRange, xSpawnRange );
        int randomIndex = Random.Range (0, power.Length);

        Vector3 spawnPower = new Vector3(randomX, ySpawn, randomZ);

        Instantiate(power[randomIndex], spawnPower, power[randomIndex].gameObject.transform.rotation);        


    }
}
