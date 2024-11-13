using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
   public GameObject enemy;
   public Transform planeVector;
   public float xOffset;

   private float timer=0, timer2;
   private float spawnRate;
   private float min, max;
   private float count;

    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        planeVector = player.transform;
        spawnRate = 4; min = 1; max=4;
        count = 0;
    }

    // Update is called once per frame
    
    void Update()
    {
        if (timer < spawnRate){
            timer += Time.deltaTime;
        } else {
            Instantiate(enemy, new Vector3(planeVector.position.x + xOffset, -3),transform.rotation);
            timer=0;
            spawnRate = Random.Range(min, max);
        }

        if (timer2 < 30){
            timer2 += Time.deltaTime; 
        } else if (max != 0){
            max -= 1;
            timer2 = 0;
        }

    }
}
