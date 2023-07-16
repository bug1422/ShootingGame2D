using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float thrust = 70;
    private GameObject cursor;
    public Rigidbody2D rb;
    public Tank tank;
    // Start is called before the first frame update
    void Start()
    {
        name = "Bullet";
        cursor = GameObject.Find("Cursor");
        tank = GameObject.FindGameObjectWithTag("Tank").GetComponent<Tank>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tank.isAlive)
        {
            transform.Translate(Vector2.right * thrust * Time.deltaTime, Space.Self);
        }
    }
}
