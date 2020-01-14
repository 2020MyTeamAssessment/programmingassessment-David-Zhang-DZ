using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMovement : MonoBehaviour
{
    Rigidbody2D skeletonRB;
    int timer = 151;
    float speed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        skeletonRB = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Jump()
    {
        Vector2 movement = new Vector2(0f, 5.0f);
        skeletonRB.AddForce(movement, ForceMode2D.Impulse);
    }


    private void FixedUpdate()
    {
        if ((timer % 150) == 1)
        {
            Jump();
        }
        timer++;
    }
}
