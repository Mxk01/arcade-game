using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDownTimer : MonoBehaviour
{
    float currentTime;
    float startingTime;


    // Start is called before the first frame update
    void Start()
    {
     currentTime = startingTime;    
    }

    // Update is called once per frame
    void Update()
    {
        currentTime-=1*Time.deltaTime;
        print(currentTime);
    }
}
