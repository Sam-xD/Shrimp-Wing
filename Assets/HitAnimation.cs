using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HitAnimation : MonoBehaviour
{

    public Text s;
    public Text w;
    Animator a;
    int sh = 0;
    int wi = 0;
  
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            //raycast to detect mouse click and obj collision

            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit)
            {
                //playing animation of the object
                a = hit.collider.gameObject.GetComponent<Animator>();
                //Debug.Log(a);
                a.SetBool("h", true);

                if (hit.collider.tag == "Shrimp")
                {
                    //updating score
                    sh += 1;
                    s.text = "Shrimp:" + sh;


                }
                else
                {
                    wi += 1;
                    w.text = "Wings:" + wi;

                }

            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
