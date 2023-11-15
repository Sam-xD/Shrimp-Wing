using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jump : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject g;


    //Button Logic
    public void StartButton()
    {
        //Button for start
        SceneManager.LoadScene(1);
    }
    public void ExitButton()
    {
        //Button for exit
        Application.Quit();
    }


    
    private void Update()
    {
        //deactivating and resetting object in the pool when it gets bolow one point
        if (transform.position.y < -15)
        {
            transform.gameObject.SetActive(false);
            Animator a = transform.gameObject.GetComponent<Animator>();

            a.SetBool("h", false);
            transform.position = g.transform.position;
        }

        
        

    }
}
