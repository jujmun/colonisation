using UnityEngine;

public class DestroyedTreeScript : MonoBehaviour
{

    private GameObject player;
    private Transform planeVector;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        

        planeVector = player.transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < planeVector.position.x - 8){
            Destroy(gameObject);
        }
    }
}
