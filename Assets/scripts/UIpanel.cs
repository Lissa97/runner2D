using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIpanel : MonoBehaviour, IPointerDownHandler, IPointerUpHandler   
{

    Vector2 pos;

    public void OnPointerDown(PointerEventData e) {
        pos = e.position;
    }

    public void OnPointerUp(PointerEventData e)
    {
        Vector2 vecM = new Vector2(0, 0);

        float x = e.position.x - pos.x;
        float y = e.position.y - pos.y;

        if (Math.Abs(x) > Math.Abs(y))
        {

            if (x > 0)
                vecM.x = 1;// (1, 0)
            else
                vecM.x = -1;// (-1, 0)

        }
        else
        {
            if (y > 0)
                vecM.y = 1;//(0, 1)
            else
                vecM.y = -1;//(0, -1)
        }

        foreach (runner r in runner.runs) {
            r.Move(vecM);
         }

        
    }
}
