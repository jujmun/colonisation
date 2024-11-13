using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlaneScript : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPrefab; 
    public float speed; 
    public Rigidbody2D rb; 
    public RestartScript RestartScreen;

    private float health = 100;
    private bool speeding = false;
    private int count;

    Animator myAnimator;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.right * speed; 

        myAnimator = GetComponent<Animator>();
    }

    void FixedUpdate(){

        if(Input.GetKey(KeyCode.DownArrow)){
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, -speed);
        } else if(Input.GetKey(KeyCode.UpArrow)){
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, speed);
        } else if (!speeding){
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
        }
        
        

        if (transform.position.y > 3){
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, -1f);
        } else if (transform.position.y < -3){
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 1f);
        }

    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.X)){
            count++;
        }
        if (count >= 5){
            Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
            count = 0;
        }
        
        if (Input.GetKeyDown(KeyCode.RightArrow)){
            StartCoroutine(speedTimer());
        }

        if (health < 0){
            GameOver();
        }
    }

    IEnumerator speedTimer(){
        speeding = true; 
        //myAnimator.SetTrigger("AccelTrigger");
        rb.linearVelocity = new Vector2(12, rb.linearVelocity.y);
        yield return new WaitForSeconds(.5f);

        rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y); 
        speeding = false;
    }


    // public void PlaneDamage(float damage){
    //     if (damage > 0){
    //         Debug.Log("PLANE DAMAGED!!!");
    //     }
    // }

    private void OnTriggerEnter2D(Collider2D collision){

        if (collision.CompareTag("Apple")){

            myAnimator.SetTrigger("GotHit");
            health -= 20; 
            Destroy(collision.gameObject);

            Debug.Log(health);
            
        }

    }

    public void GameOver(){
        Debug.Log("gameover called");
        RestartScreen.Setup();
    }
}
