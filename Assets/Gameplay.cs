using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    

    public GameObject shrimp;
    public GameObject wing;
    Queue<GameObject> q;
    GameObject g;
    

    void Start()
    {
        
        //creating obj pool
        q = new Queue<GameObject>();
        while (q.Count < 8)
        {
            if (Random.Range(0, 2) % 2 == 0)
            {
                g = Instantiate(shrimp);
                g.SetActive(false);
                q.Enqueue(g);
            }

            else
            {
                g = Instantiate(wing);
                g.SetActive(false);
                q.Enqueue(g);
            }
                

        }
        StartCoroutine(Cor());
    }

    private void Update()
    {
        
    }
    IEnumerator Cor()
    {
        //coroutine for obj regeneration

        q.Peek().SetActive(true);

        //setting random angle to game object force
        Vector3 upDirSlightlyRandomized = new Vector3(Random.Range(-0.5f, 0.5f), 1, 0).normalized;
        
        q.Peek().GetComponent<Rigidbody2D>().AddForce(upDirSlightlyRandomized * 700);

        q.Enqueue(q.Dequeue());
        yield return new WaitForSeconds(0.8f);

        yield return Cor();

        
        

    }

    
  
}
