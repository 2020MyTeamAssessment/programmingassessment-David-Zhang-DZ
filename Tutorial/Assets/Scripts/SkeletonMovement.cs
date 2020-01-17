using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMovement : MonoBehaviour
{
    Rigidbody2D skeletonRB;
    public Rigidbody2D projectilePrefab;
    public Animator animator;
    int arrowsShot;
    float jumpForce = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        //
        arrowsShot = 0;
        skeletonRB = gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine(SkeletonMove());
    }

    // Update is called once per frame
    void Update()
    {
    }

    //Cause skeleton to jump
    void Jump()
    {
        Vector2 movement = new Vector2(0f, jumpForce);
        skeletonRB.AddForce(movement, ForceMode2D.Impulse);
    }

    //Helper function for shooting with time delay
    void ShootArrow()
    {

        StartCoroutine(ShootArrowTask());
        arrowsShot++;
    }

    //Play the shooting animation and creates another arrow 
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


    //contains all of the actions performed by the skeleton
    IEnumerator SkeletonMove()
    {
        for (; ; )
        {

            Jump();
            yield return new WaitForSeconds(2);
            ShootArrow();
            yield return new WaitForSeconds(2);
            if (arrowsShot > 2)
            {
                animator.SetTrigger("Death");
                yield return new WaitForSeconds(1.5f);
                Destroy(gameObject);
            }
        }
    }
}
 
