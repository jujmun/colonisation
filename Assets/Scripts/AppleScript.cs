using UnityEngine;

public class AppleScript : MonoBehaviour
{

    private Rigidbody2D rb; 
    private Transform planeVector;
    private float upX, lowX, upY, lowY;
    private float randomY, randomX;
    private float timer2, max;

    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        planeVector = player.transform;
        max = 2;



        rb = GetComponent<Rigidbody2D>();
        randomY = Random.Range(2f,8f); randomX = Random.Range(-6f, -1f);
        rb.linearVelocity = new Vector2 (randomX, randomY);
    }

    // Update is called once per frame
    void Update(){

        if (transform.position.y < -10){
            Destroy(gameObject);
        }

        if (planeVector.position.x == 200){
            randomY = Random.Range(1f,4f); randomX = Random.Range(-max, -1f);
            rb.linearVelocity = new Vector2 (randomX, randomY);
        }

        if (timer2 < 30){
            timer2 += Time.deltaTime; 
        } else if (max != 0){
            max += 0.5f;
            timer2 = 0;
        }


    }

    // private void OnCollisionEnter2D(Collision2D collision){
    //     if (collision.gameObject.CompareTag("Player")){
    //         PlaneScript pscript = collision.gameObject.GetComponent<PlaneScript>();
    //         Debug.Log("Yupppp1");
            
    //         if (pscript != null){
    //             Debug.Log("Yupppp");

    //             pscript.PlaneDamage(20);
    //             Destroy(gameObject);
    //         }

    //     }

    // }
    // private void OnTriggerEnter2D(Collider2D collision){

    //     if (collision.gameObject.layer==LayerMask.NameToLayer("Player")){
    //         PlaneScript pscript = collision.gameObject.GetComponent<PlaneScript>();
            
            
    //         if (pscript != null){
    //             pscript.PlaneDamage(20);
    //             Destroy(gameObject);
    //             Debug.Log("Yupppp");
    //         }
    //         if (pscript == null){
    //             Debug.Log("wuh oh");
    //         }
    //     }

    // }
}
