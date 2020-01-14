using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMovement : MonoBehaviour
{
    Rigidbody2D skeletonRB;
    public Rigidbody2D projectilePrefab;
    int timer;
    float speed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        int timer = 1;
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
    
    void ShootArrow()
    {
        Vector2 movement = new Vector2(2.0f, 0f);
        Vector2 position = new Vector2(transform.position.x, transform.position.y);
        Rigidbody2D projectile = Instantiate(projectilePrefab, position, Quaternion.identity);
        projectile.velocity = movement;
    }

    private void FixedUpdate()
    {
        if ((timer % 150) == 1)
        {
            ShootArrow();
            Jump();
        }
        timer++;
    }
}
