using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public static Point lastTrig;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<runner>() != null) {
            collision.GetComponent<runner>().Stop();
        }

        lastTrig = this;
    }
}
