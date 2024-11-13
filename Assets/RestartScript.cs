using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScript : MonoBehaviour
{

    public void Setup(){
        gameObject.SetActive(true);
    }

    public void ResetGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("Button is working!");
    }
}
