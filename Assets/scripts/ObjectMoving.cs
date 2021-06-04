using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMoving : MonoBehaviour
{
    float k; // angle
    float c; // const

    float a = 0.20f; // acceleration

    float v = 0.2f; // velocity y/s

    float y1 = 2.8f;

    bool revers = true;

    float scal;

    //for start
    float func2(float y)
    {
        return -(y - y1) * 0.5f;
    }

    float trajectory(float y)
    {
        return (y - c) * k;
    }

    float funcRandX(float deltaY)
    {
        return func2(transform.position.y - deltaY) / func2(transform.position.y);
    }

    SpriteRenderer _srre;

    private void Start()
    {


        if (GetComponent<SpriteRenderer>() != null)
        {
            _srre = GetComponent<SpriteRenderer>();
        }

        else if (GetComponentInChildren<SpriteRenderer>() != null)
            _srre = GetComponentInChildren<SpriteRenderer>();



        c = y1;

        float x2 = transform.position.x;
        float y2 = transform.position.y;

        if (x2 == 0)
            k = 0;
        else
            k = x2 / (y2 - c);

        scal = transform.localScale.y;

        v *= func2(y2) / func2(CONSTANT.horizon);
        scal *= func2(y2) / func2(CONSTANT.horizon);

        transform.localScale = new Vector3(scal, scal, scal);


    }


    public float z = 0;
    float timer = 0;

    private void Update()
    {


        if (!CONSTANT.hite)
            z -= 0.001f;


        float deltaY = 0;


        deltaY = v * Time.deltaTime * CONSTANT.speed;


        float randX = funcRandX(Mathf.Abs(deltaY));


        v *= Mathf.Abs(randX);

        scal *= Mathf.Abs(randX);


            transform.position = new Vector3(
               trajectory(transform.position.y - deltaY),

               transform.position.y - deltaY,
               z

           );

        transform.localScale = new Vector3(scal, scal, scal);

        timer += Time.deltaTime;
        if (timer > 2)
        {
            Chek();
            timer -= 2;
        }

    }

    public float checkY = 0;
    void Chek()
    {
        checkY = Mathf.Abs(transform.position.y) - _srre.size.y * transform.localScale.y;

        //Debug.Log(Mathf.Abs(transform.position.x) - _srre.size.x * transform.localScale.x);
        if (Mathf.Abs(transform.position.x) - _srre.size.x * transform.localScale.x > CONSTANT.widthCamera)
        {
            Destroy(this.gameObject);
        }
        if (Mathf.Abs(transform.position.y) - 10 > CONSTANT.heightCamera)
        {
            Destroy(this.gameObject);
        }
    }


}
