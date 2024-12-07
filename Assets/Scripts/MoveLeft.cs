using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRb;
    private float xDestroy = -50.0f;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyRb.AddForce(Vector3.left * speed);

        if(transform.position.x < xDestroy)
        {
            Destroy(gameObject);
        }

    }
}
