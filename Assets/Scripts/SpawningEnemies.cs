using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningEnemies : MonoBehaviour
{
    // getting a reference to our prefab 
    [SerializeField]
    GameObject prefab;
    bool gameOver = false;
    int  numberOfEnemies = 0;

    // THE INSTANTIATE method helps us create gameObjects 
     public void SpawnObjects () {
     if(prefab!=null){
     Instantiate(prefab,new Vector3(Random.Range(-12f,12f),6f,0f),Quaternion.identity);
     }
    } 
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // void OnCollisionEnter2D(Collision2D collider)
    //  {
                 
   
    //             Debug.Log(numberOfEnemies);
    //         // we can use the collider variable to get a reference to the object spawning enemy hit
    //         if(collider.gameObject.tag=="Player")
    //         {
 
         

    //              Destroy(collider.gameObject);
    //                gameOver = true;
               
    //             Debug.Log("Game OVER,YOU LOSE!!!");
    //             return;

    //         }
    //         // else if(collider.gameObject.tag=="Ground"){
    //         //      SpawnObjects();
               
    //         //  }
    //  }   
    // Update is called once per frame
    void Update()
    {
     
    }
}
