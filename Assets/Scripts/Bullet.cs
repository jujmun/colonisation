using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed; 
    private Transform planeVector;
    private Rigidbody2D rb;

    Animator myAnimator; 

    void Start(){ 

        GameObject player = GameObject.FindWithTag("Player");
        planeVector = player.transform;
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.right * speed;

        
        myAnimator = GetComponent<Animator>();

    }
    void Update(){
        
        if (transform.position.x>planeVector.position.x + 30){
            Destroy(gameObject);
        }

    }
    
    private void OnTriggerEnter2D(Collider2D collision){

        if (collision.gameObject.layer==LayerMask.NameToLayer("Enemy")){
            EnemyScript_YouTube enemy = collision.gameObject.GetComponent<EnemyScript_YouTube>();
            
            
            if (enemy != null){
                myAnimator.SetBool("StrikedOnce",true);
                enemy.EnemyDamage(20);
                Destroy(gameObject, 0.333f);
            }
        }

    }
}
