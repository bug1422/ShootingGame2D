using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyScript : MonoBehaviour
{
    private float speed;
    private GameObject cursor;
    public Tank tank;
    public LogicScript logic;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(20, 50);
        cursor = GameObject.Find("Cursor");
        /*   tank = GameObject.Find("Tank");*/
        tank = GameObject.FindGameObjectWithTag("Tank").GetComponent<Tank>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tank.isAlive)
        {
            Vector3 difference = transform.position - tank.transform.position;
            float ang = Mathf.Atan(difference.x / difference.y) * (180 / Mathf.PI);
            Vector3 deg = new Vector3(0, 0, difference.y > 0 ? 180 - ang : -ang);
            transform.localEulerAngles = deg;
            transform.position = Vector2.MoveTowards(transform.position, tank.transform.position, speed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Bullet") 
        {
            logic.addScore(1);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        };
        if (collision.gameObject.name == "Tank")
        {
            logic.subHealth(50);
            Destroy(gameObject);
        };
    }
}
