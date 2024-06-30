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
    float firstTriggerX = 1;
    float firstTriggerY = 5;
    float secondTriggerX = 1;
    float secondTriggerY = 5;
    float margin = 8;
    bool trigger1 = true;
    //public floats
    public float rotationSpeed = 2f;
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
    public GroundCheck gc;
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
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Menu();
        }
        if(Input.GetKeyDown(KeyCode.F))
        {
            
            Flips();
        }
        roll = Input.GetAxisRaw("Horizontal");    
        
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
            if (gc.isground == 1f)
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
        if(other.gameObject.CompareTag("Gate"))
        {
            if (trigger1 == false)
            {
                GetFirstTrigger();
            } 
            if (secondTriggerX !>= firstTriggerX+margin || secondTriggerX !<= firstTriggerX-margin | secondTriggerY !>= firstTriggerY+margin || secondTriggerY !<= firstTriggerY-margin){
            bm.charge += .5f;
            rm.gateTrigger = 1;
            rm.fill = 0;
            gm.comboTime = gm.comboTime - gm.comboTime;
            gm.comboCount++;
            gateCooldownTimer = gateCooldownTimer - gateCooldownTimer;
            }    
            if (trigger1 == true){
                GetSecondTrigger();
            }
        }
        void GetFirstTrigger(){
            firstTriggerX = rb.position.x;
            firstTriggerY = rb.position.y;
            Debug.Log("firsty" + firstTriggerY);
            Debug.Log("firstx" + firstTriggerX);
            trigger1 = true;
        }
        void GetSecondTrigger(){
            secondTriggerX = rb.position.x;
            secondTriggerY = rb.position.y;
            Debug.Log("secondy" + secondTriggerY);
            Debug.Log("secondx" + secondTriggerX);
            trigger1 = false;
        }
        //Checks if the object it is colliding with has the tag gate//
        if(other.gameObject.CompareTag("water"))
        {    
            water = .5f;  
            FindObjectOfType<SfxManager>().Play("WaterSplash");
            StartCoroutine("Splish");
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
           StopCoroutine("Splish");
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
    
}
