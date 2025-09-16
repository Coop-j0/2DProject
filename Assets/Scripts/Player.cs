using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float gravity;
    public Vector2 velocity;
    public Vector2 acceleration;
    public float mass;
    public float speed;
    public float drag;
    public Vector2 normalForce;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate(){
        speed = velocity.magnitude;
        Vector2 gravAccel = new Vector2(0, -gravity*mass);

        velocity += acceleration;
        velocity += gravAccel;

        Vector2 resistance = new Vector2(velocity.x * drag, velocity.y *drag);
        velocity -= resistance;

        transform.Translate(velocity);
    }

    void OnCollisionEnter2D(Collision2D collision){

        Debug.Log("Collided");
        velocity.x=0;
        velocity.y=0;
        normalForce = -acceleration;
        acceleration += normalForce;
    }

    void OnCollisionStay2D(Collision2D collision){
        normalForce = -acceleration;
        acceleration += normalForce;
    }



    void Update(){
        if(Input.GetKeyDown(KeyCode.W)){
          
            acceleration.y = 0.1f;
        }
        if(Input.GetKeyUp(KeyCode.W)){
            
            acceleration.y = 0;
        }
        if(Input.GetKey(KeyCode.S)){
            acceleration.y = -0.1f;
        }
        if(Input.GetKeyUp(KeyCode.S)){
           
            acceleration.y = 0;
        }
        if(Input.GetKey(KeyCode.A)){
            acceleration.x = -0.1f;
        }
        if(Input.GetKeyUp(KeyCode.A)){
           
            acceleration.x = 0;
        }
        if(Input.GetKey(KeyCode.D)){
            acceleration.x = 0.1f;
        }
        if(Input.GetKeyUp(KeyCode.D)){
            
            acceleration.x = 0;
        }
        
    }
}
