using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileSpawner : MonoBehaviour
{
    public GameObject Missile;
    public float spawnRate = 1;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            SpawnMissile();
            timer = 0;
        }
    }

    void SpawnMissile()
    {
        Instantiate(Missile, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
    }
}
