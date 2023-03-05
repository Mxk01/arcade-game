using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningCoins : MonoBehaviour
{
    [SerializeField]
    GameObject prefab; 
    // Start is called before the first frame update
    void Start()
    {
    }

    public void SpawnCoins() {
                Instantiate(prefab,new Vector3(Random.Range(-7f,7f),7f,0f),Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // void OnCollisionEnter2D(Collision2D collider){
        
    //         SpawnCoins();
        
    // }
}
