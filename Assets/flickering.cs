using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flickering : MonoBehaviour
{


    public Light _Light;

    public float MinTime;
    public float MaxTime;
    public float Timer;

    // Start is called before the first frame update
    void Start()
    {
        Timer = Random.Range(MinTime, MaxTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer > 0)
            Timer -= Time.deltaTime;

        if(Timer<=0){
            _Light.enabled = !_Light.enabled;
            Timer = Random.Range(MinTime, MaxTime);
        }
    }
}
