using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMovement : MonoBehaviour
{
    Rigidbody2D skeletonRB;
    public Rigidbody2D projectilePrefab;
    public Animator animator;
    int counter;
    float speed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        skeletonRB = gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine(SkeletonMove());
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
 
        StartCoroutine(ShootArrowTask());
        counter++;
        Debug.Log(counter);
    }

    IEnumerator ShootArrowTask()
    {
        animator.SetBool("IsShooting", true);
        yield return new WaitForSeconds(1f);
        Vector2 movement = new Vector2(2.0f, 0f);
        Vector2 position = new Vector2(transform.position.x, transform.position.y);
        Rigidbody2D projectile = Instantiate(projectilePrefab, position, Quaternion.identity);
        projectile.velocity = movement;
        animator.SetBool("IsShooting", false);

    }

    private void FixedUpdate()
    {
        
    }

    IEnumerator SkeletonMove()
    {
        for (; ; )
        {
            
            Jump();
            yield return new WaitForSeconds(2);
            ShootArrow();
            yield return new WaitForSeconds(2);
            if (counter > 2)
            {
                animator.SetTrigger("Death");
                yield return new WaitForSeconds(1.5f);
                Destroy(gameObject);
            }
        }
    }

    IEnumerator PlayDeadAnimation()
    {
        if(counter > 2)
        {
            animator.SetBool("IsDead", true);
            yield return new WaitForSeconds(.98f);
            Destroy(gameObject);
        }
        yield return new WaitForSeconds(0);
    }

}
