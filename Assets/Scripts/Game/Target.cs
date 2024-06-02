using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody rb;
    public ParticleSystem explosionParticle;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 6;
    private float xRange = 4;
    private float ySpawnPos = -2;
    private NewsNinjaGameManager gameManager;
    public int pointValue;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(RandomForce(), ForceMode.Impulse);
        rb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
        gameManager = GameObject.Find("NewsNinjaGameManager").GetComponent<NewsNinjaGameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    /*private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            gameManager.UpdateScore(pointValue);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            Destroy(gameObject);
        }
    }*/
    public void DestroyTarget()
    {
        if (gameManager.isGameActive)
        {
            if (gameObject.CompareTag("Bad") == true)
            {
                gameManager.UpdateLives(-1);
            }
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position,
            explosionParticle.transform.rotation);
            gameManager.UpdateScore(pointValue);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bad") == true && gameManager.isGameActive)
        {
            gameManager.UpdateLives(-1);
        }
        if (other.CompareTag("Sensor") && !gameObject.CompareTag("Bad") && gameManager.isGameActive)
        {
            gameManager.UpdateLives(-1);
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }
}
