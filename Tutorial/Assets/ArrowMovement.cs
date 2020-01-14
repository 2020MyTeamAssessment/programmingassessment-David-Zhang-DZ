using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    // Start is called before the first frame update
    int timer;
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer == 150)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        timer++;
    }
}
