using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class Dronegozoomy : MonoBehaviour
{
    //private floats
    private float roll = 2f; 
    [SerializeField] private float movementSpeed = 2f;
    [HideInInspector] public float water = 1f; 
    //public floats
    public float rotationSpeed = 2f;
    public float isground;
    public float LevelUp; 
    public float airMode;
    public float gateCooldownTimer;
    [HideInInspector] public float Power;
    //movement//
    private Rigidbody2D rb; 
    private Vector2 movementDirection;
    //other object ref// 
    public BatteryManager bm;
    public Animator animator;
    public GateManager gm;
    public RadialIndicator rm;
    //it makes exist//
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddRelativeForce(Vector2.up);
        rotationSpeed = SettingsMenu.RollSensitivity;
        Debug.Log(rotationSpeed); 
    }
    void Start()
    {

        FindObjectOfType<AudioManagerProps>().Play("PropNoise");
    }
    void Update(){
        
           if(Input.GetAxisRaw("Vertical") <= 0)
        {
            
            Power = 0f;  
            //stop propspin anim//
           animator.SetBool("Active", false);
            //calls the audiomanager to play the PropNoise sound//
            

        }
        else
        {
            
            Power = Mathf.Abs(Input.GetAxisRaw("Vertical"));
            Ups(); 
            
             //Prop spin animation start//
            animator.SetBool("Active", true);
            
        }
               //ow my ears//
        if (Input.GetKeyUp(KeyCode.W))
        {
            
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Menu();
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            
            Flips();
        }
        roll = Input.GetAxisRaw("Horizontal");    
        Debug.Log(water);
        
    }

    void FixedUpdate()
    {
        
        //spinneey//
        rb.rotation = (rb.rotation + -roll * rotationSpeed * Time.fixedDeltaTime);
        //Combo System//
        if (gm.comboCount != 0)
        {
            gm.comboTime += Time.fixedDeltaTime * .7f + (.00001f * gm.comboCount);
        }
        gateCooldownTimer += Time.fixedDeltaTime * 1;
     
    }


         //Exit To Main Menu//
    public void Menu()
        {
            FindObjectOfType<LevelLoader>().LoadMainMenu();  
        }
    //Flip//
        void Flips()
        {
            if (isground == 1f)
            {
             rb.rotation = 0f;
            }
        }
        //THROTTLE//
    void Ups()
        {
            //adds velocity to the
            rb.AddRelativeForce((Vector2.up * movementSpeed * Power * water * Time.deltaTime));
        }
           //GATE DETECTION//
//Checks if any collision with a trigger is exist//
     void OnTriggerEnter2D(Collider2D other)
    {
        //Checks if the object it is colliding with has the tag gate//
        if(other.gameObject.CompareTag("water"))
        {    
            water = .5f;  
            FindObjectOfType<SfxManager>().Play("WaterSplash");
            
        }
        
         
         
        if(other.gameObject.CompareTag("Gate"))
        {
            
            if (gateCooldownTimer >= 1f)
            {
            bm.charge += .5f;
            rm.gateTrigger = 1;
            rm.fill = 0;
            gm.comboTime = gm.comboTime - gm.comboTime;
            gm.comboCount++;
            gateCooldownTimer = gateCooldownTimer - gateCooldownTimer;
            }      
        }
         
    }
    //Detects if exits trigger//
       void OnTriggerExit2D(Collider2D other)
    {   
        //detects if trigger exited was water//
        if(other.gameObject.CompareTag("water"))
        {
            Debug.Log("Unsplish"); 
            water = 1f;
           
        }
         
    }

    //if you are in water for 2.5s you die// 

            IEnumerator Splish()
         {
                 yield return new WaitForSeconds(2);
            if (water < 1f)
            {
                Die();
            }
         }
    public void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    //GROUND DETECTION//
    //Checks if collision with a solid is exist and then checks if it has the tag floor//
     void OnCollisionEnter2D(Collision2D col)
     {
        if(col.gameObject.CompareTag("Floor")){
            isground = 1f; 
        }
     }
     void OnCollisionExit2D(Collision2D col)
     {
        if(col.gameObject.CompareTag("Floor")){
            isground = 0f; 
        }
     }
    
}
