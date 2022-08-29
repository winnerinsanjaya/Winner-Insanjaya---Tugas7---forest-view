using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    public float upForce = 1f;
    public float sideForce = .1f;


    private MushroomSpawner spawner;
    private float countdown = 3;
    void Start()
    {
        float xForce = Random.Range(-sideForce, sideForce);
        float yForce = Random.Range(upForce/2f, upForce);
        float zForce = Random.Range(-sideForce, sideForce);

        Vector3 force = new Vector3 (xForce, yForce, zForce);

        GetComponent<Rigidbody>().velocity = force;
    }

    private void Update()
    {
        countdown -= Time.deltaTime;
        if(countdown < 0)
        {
            spawner.AddDead(gameObject);
            gameObject.SetActive(false);
        }
    }

    public void SetSpawner(GameObject obj)
    {
        spawner = obj.GetComponent<MushroomSpawner>();
    }

    public void SetStart()
    {
        countdown = 3;
        gameObject.SetActive(true);
    }
}
