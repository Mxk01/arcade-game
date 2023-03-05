using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{  
    private int score =0;

     //This is supposedly how I get the text
    public  Text UIText;
  SpriteRenderer spriteRenderer;
    //The Color to be assigned to the Renderer’s Material
    Color newColor;
   
    //These are the values that the Color Sliders return
    float m_Red, m_Blue, m_Green;
    public GameObject bulletToRight,bulletToLeft;
    Vector2 bulletPosition;
    public float fireRate = 0.5f;
    float nextFire = 0.0f;
   // starting by declaring the rigidbody variable
   Rigidbody2D rb2D;
    [SerializeField]
    private float speed;
    
    [SerializeField]
    private float jumpHeight;
    
    [SerializeField]
    private bool isJumping;
    
    [SerializeField]
    private float moveHorizontal;
    public bool facingRight = false;
    [SerializeField]
    private float moveVertical;
   
    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private SpawningEnemies spawningEnemies;
    [SerializeField]
    private SpawningCoins spawningCoins;
    [SerializeField]
    CapsuleCollider2D colliderRef;
    
    // use properties b/c when we assign something to those fields
    // we can do restrictions
    // we can remove the set part if we only want to read the value
    public float Speed {
        get { return speed; }
        set { speed = value; }
    }

    // using a property to show percentage
    public string ShowSpeed {
        get {
            string health = Speed.ToString() + "%";
            return health;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //Fetch the SpriteRenderer from the GameObject
        spriteRenderer = GetComponent<SpriteRenderer>();
          spriteRenderer.color = Color.white;
        
        colliderRef =  gameObject.GetComponent<CapsuleCollider2D>();
        int blobsCount  = 8;
      
        spawningCoins.SpawnCoins();
       
           while(blobsCount>0) {
        spawningEnemies.SpawnObjects();
          blobsCount--;
        }
        Speed = 100;
        Debug.Log(ShowSpeed);
        
        // because rb2D is empty we assign it 
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        speed = 3f;
        jumpForce = 60f;
        isJumping = false;
    }

     void fire() {
        
                bulletPosition = transform.position;
            if(facingRight) {
        // bulletPosition will be equal to our character 
        // position
        // if(facingRight){
         bulletPosition += new Vector2(+1f,-0.42f);
         Instantiate(bulletToRight,bulletPosition,Quaternion.identity);
        // }
        // else {
        //     bulletPosition += new Vector2(-1f,-0.42f);
        //     Instantiate(bulletToLeft,bulletPosition,Quaternion.identity);

        // }}
            }
      }
    // Update is called once per frame
    void Update()
    {

        UIText.text ="Your drank  "+score.ToString() + " beers today!";
        if(score>4)
        {
            UIText.text+=" Take it easy bro";
        }
        if(score>=9)
        {
            UIText.text = "Achievement Unlocked! Drunk Man!";
        }
        if(Input.GetButtonDown("Fire1") && Time.time > nextFire)
         {
            facingRight = true;
            nextFire = Time.time + fireRate;
            fire();
         }
       moveHorizontal = Input.GetAxisRaw("Horizontal");
       moveVertical = Input.GetAxisRaw("Vertical"); 
        // if space keyboard was pressed
       if(Input.GetKeyDown("space")){
        // making a collider switch
        colliderRef.enabled = !colliderRef.enabled;
       }
    }
    // Same as update but has to do with physics
    void FixedUpdate(){
       
        // this means player is on the positive side of the X axis
        // or on the negative side of the x axis
       if(moveHorizontal > 0.1f || moveHorizontal < -0.1f){
        // Vector2 is the same shit as an XoY plane 
        // we don't want to move player vertically so second parameter is 0f
        // moveHorizonotal * speed makes player move faster
        rb2D.AddForce(new Vector2(moveHorizontal * speed,0f),ForceMode2D.Impulse);           
       }
       // almost same shit as on x axis
       if(moveVertical > 0.1f) {
        rb2D.AddForce(new Vector2(0f,speed*moveVertical),ForceMode2D.Impulse);
       }
    }

      void OnTriggerEnter2D(Collider2D collider)
    {
        
        // if player reaches the ground for example then set 
        // isJumping false,b/c player isn't jumping anymore
        if(collider.gameObject.tag=="Ground"){
            isJumping = false; 
        }
        if(collider.gameObject.tag=="Coins"){
           Destroy(collider.gameObject);
        }
    }
 void OnCollisionEnter2D(Collision2D collider)
     {
                 
      if(collider.gameObject.tag=="Enemy")
            {
               UIText.text = "Damn bro the enemy fucked u e.e  Here's a consolation present!";
                   
                       spawningEnemies.SpawnObjects();
                       
            }
             
   
            // we can use the collider variable to get a reference to the object spawning enemy hit
            if(collider.gameObject.tag=="Beer")
            {
   
               score++;
              Destroy(collider.gameObject);
            //   BulletScript.velX-=.10f;                 
                
         //Set the GameObject's Color quickly to a set Color (blue)
        spriteRenderer.color = Color.blue;

            }
            else {
            spriteRenderer.color = Color.white;
            }
            // else if(collider.gameObject.tag=="Ground"){
            //      SpawnObjects();
               
            //  }
     }   

        void OnTriggerExit2D(Collider2D collider)
     {
            if(collider.gameObject.tag=="Ground"){
            isJumping = true; 
        } 
     }
}
