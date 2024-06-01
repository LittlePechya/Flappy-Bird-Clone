using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BirdScript : MonoBehaviour
{  
    public Rigidbody2D myRigidBody;
    private Controls controls;
    public float flapStrength;
    public LogicScript logic;
    private bool birdIsAlive = true;
    public float boundaryOffset = 20;
    private Animator anim;
    private AudioSource deathSound;

    void Awake()
    {
        anim = GetComponent<Animator>();
        deathSound = GetComponent<AudioSource>();

        controls = new Controls();
        controls.Main.Jump.performed += context => Jump();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        transform.position = Vector3.zero;
    }

    void OnEnable()
    {
        controls.Enable();
    }

    void OnDisable()
    {
        controls.Disable();
    }

   void Start()
    {
        if (myRigidBody == null) {
            Debug.Log("No rigidbody object");
        } else {
            Debug.Log("Rigid body succesfully attached");
        }

        gameObject.name = "Bob Birdington Jhonson";
    }

    void Jump() 
    {
        if (birdIsAlive) 
        {
            Debug.Log("Jump");
            myRigidBody.velocity = Vector2.up * flapStrength;
            anim.SetTrigger("Flap");
        }
    }

    void endGame() {
        if (birdIsAlive) {
            deathSound.Play();
            logic.gameOver();
            birdIsAlive = false;
        }
    }

    void Update()
    {
        if (transform.position.y > boundaryOffset || transform.position.y < -boundaryOffset) {
            endGame();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected witch " + collision.gameObject.name);
        endGame();
    }
}
