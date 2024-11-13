using UnityEngine;

public class EnemyScript_YouTube : MonoBehaviour
{
    public GameObject topG,midG,botG;
    public Transform topT,midT,botT;
    public GameObject apple;
    public LogicScript logic;
    

    private GameObject[] destroyed; 
    private Transform[] destroyedT;
    private Transform planeVector;
    private GameObject player;
    
    

    private float timer=0;
    private float spawnRate=2;
    private float health;
    
    void Start(){
        health = 40;

        destroyed = new GameObject[] { topG, midG, botG };
        destroyedT = new Transform[] { topT, midT, botT };

        GameObject player = GameObject.FindWithTag("Player");
        logic = GameObject.FindWithTag("Logic").GetComponent<LogicScript>();

        planeVector = player.transform;

    }

    void Update(){
        

        if (timer < spawnRate){
            timer += Time.deltaTime;
        } else {
            
            Instantiate(apple, new Vector2 (transform.position.x, transform.position.y+5),transform.rotation);
            timer=0;
        }

        if (transform.position.x < planeVector.position.x - 8){
            Destroy(gameObject);
        }
    }

    public void EnemyDamage(float damage){
        if (health < 0){
            logic.addScore();
            for (int i=0; i<destroyed.Length; i++){
                
                Destroy(gameObject);
                Instantiate(destroyed[i], transform.position, transform.rotation);
            }
        } else {
            health -= damage;
        }
    }
}
