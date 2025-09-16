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
    private Rigidbody2D rb;
    public float jumPower;
    private Vector3 touchingPoint;
    private bool touching;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate(){
        speed = velocity.magnitude;
        Vector2 gravAccel = new Vector2(0, -gravity*mass);

        velocity += acceleration;
        velocity += gravAccel;

        Vector2 resistance = new Vector2(velocity.x * drag, velocity.y *drag);
        velocity -= resistance*mass;

        if(isGrounded()){
            velocity.x = velocity.x * 0.95f;
        }

        //transform.Translate(velocity);
        //rb.MovePosition(rb.position + velocity);
        rb.velocity = velocity;
    }

    void OnCollisionEnter2D(Collision2D collision){

    }
    void OnCollisionStay2D(Collision2D collision){
        touching = true;
        touchingPoint = collision.transform.position - transform.position;
    }
    void OnCollisionExit2D(Collision2D collision){
        touching = false;
    }



    void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){
            Debug.Log(isGrounded());
            Debug.Log(touching);
            if(isGrounded()){
                velocity.y = jumPower;
            }
            
        }
        
        if(Input.GetKey(KeyCode.A)){
            acceleration.x = -1f;
        }
        if(Input.GetKeyUp(KeyCode.A)){
           
            acceleration.x = 0;
        }
        if(Input.GetKey(KeyCode.D)){
            acceleration.x = 1f;
        }
        if(Input.GetKeyUp(KeyCode.D)){
            
            acceleration.x = 0;
        }
        
    }

    bool isGrounded(){
        if(touching){
            if(touchingPoint.y < 0){
                return true;
            }
            else{
                return false;
            }
        }
        else{
            return false;
        }
    }
}
