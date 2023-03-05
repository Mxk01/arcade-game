using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyPlayer : MonoBehaviour
{
        public  Text UIText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collider)
     {
                 
     
             if(collider.gameObject.tag=="Player")
            {

                UIText.text = "Damn man,Charizard drank your beer!";
                             Destroy(collider.gameObject);

                       
            }
   
     }   

}
