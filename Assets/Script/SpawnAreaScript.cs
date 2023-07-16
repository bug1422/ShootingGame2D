using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAreaScript : MonoBehaviour
{
    private MeshCollider mesh;
    public int numberToSpawn;
    public GameObject toSpawn;
    public float spawnRate = 3;
    private float timer = 0;
    public Tank tank;
    // Start is called before the first frame update
    void Start()
    {
        tank = GameObject.FindGameObjectWithTag("Tank").GetComponent<Tank>();
        mesh = gameObject.GetComponent<MeshCollider>();
        InvokeRepeating("spawnObject", 0, spawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void spawnObject()
    {
        if (tank.isAlive)
        {
            float posX, posY;
            Vector2 pos;
            posX = Random.Range(mesh.bounds.min.x, mesh.bounds.max.x);
            posY = Random.Range(mesh.bounds.min.y, mesh.bounds.max.y);
            pos = new Vector2(posX, posY);
            Debug.Log(pos);
            Instantiate(toSpawn, pos, toSpawn.transform.rotation);
        }
    }
}
