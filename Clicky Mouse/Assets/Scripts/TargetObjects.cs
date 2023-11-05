using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetObjects : MonoBehaviour
{
    private Rigidbody targetRB;
    private GameManager gameManager;

    public int pointValue;
    public ParticleSystem explosionParticle;

    public float minSpeed = 12;
    public float maxSpeed = 16;
    public float minRotation = -5;
    public float maxRotation = 5;
    public float minPosition = -4;
    public float maxPosition = 4;
    private float ySpawnPos = -2;



    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        targetRB = GetComponent<Rigidbody>();
        //determine position
        transform.position = SpawnPos();
        //determine force
        targetRB.AddForce(AddForce(), ForceMode.Impulse);
        //determin rotation
        targetRB.AddTorque(AddRotation(), AddRotation(), AddRotation(), ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        gameManager.UpdateScore(pointValue);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    Vector3 AddForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float AddRotation()
    {
        return Random.Range(minRotation, maxRotation);
    }

    Vector3 SpawnPos()
    {
        return new Vector3(Random.Range(minPosition, maxPosition), ySpawnPos);
    }



}
