using UnityEngine;

public class CMCamScript : MonoBehaviour
{
    private float startPos, length;
    public GameObject cam; 
    public float parallaxEffect; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = cam.transform.position.x * parallaxEffect; // how much the background should shift
        float movement = cam.transform.position.x * (1-parallaxEffect); // how much the background should wrap back

        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z); //changing the position of the camera

    // wrapping around so that there's no empty space. the instant the camera is greater than the screen, it resets. 
        if (movement > startPos + length){
            startPos += length; 
        } else if (movement < startPos - length){
            startPos -= length; 
        }
    }
}
