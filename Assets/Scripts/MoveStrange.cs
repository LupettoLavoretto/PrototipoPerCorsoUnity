using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MoveStrange : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRb;
    private float zValue = Random.Range(-6, 6);

//DA FINIRE DI SISTEMARE

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyRb.AddForce(Vector3.left * speed);
        
    }

}
