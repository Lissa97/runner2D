using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runner : MonoBehaviour
{
    public static List<runner> runs;

    Rigidbody2D _rgb;

    Animator _anim;
    
    // Start is called before the first frame update
    void Start()
    {
        runs = new List<runner>();
        runs.Add(this);

        _rgb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();

        _anim.speed = CONSTANT.speed;

    }

    // Update is called once per frame
    void Update()
    {
        if (stop)
        {
            Debug.Log(Mathf.Abs(transform.position.x - Point.lastTrig.transform.position.x));
            if (Mathf.Abs(transform.position.x - Point.lastTrig.transform.position.x) < 0.08)
            {

                _rgb.velocity = Vector2.zero;
                stop = false;
            }
        }
       
    }

    public void Move(Vector2 vecM) {

        if(vecM == new Vector2 (0, -1))
            _anim.SetBool("roll", true);

        _rgb.AddForce(vecM * 300);
    }

    bool stop = false;
    public void Stop()
    {
        stop = true;
        //_rgb.velocity = Vector2.zero;
    }

}
