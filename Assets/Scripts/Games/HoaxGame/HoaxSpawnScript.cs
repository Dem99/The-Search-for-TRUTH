using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoaxSpawnScript : MonoBehaviour
{
    public GameObject hoax;
    public float spawnRate = 2;
    private float timer = 0;
    public float minY;
    public float maxY;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        } else
        {
            spawn();
            timer = 0;
        }
    }

    void spawn()
    {
        float randomY = Random.Range(minY, maxY);

        Instantiate(hoax, new Vector3(transform.position.x, Random.Range(maxY, minY), 0), transform.rotation);
    }
}
