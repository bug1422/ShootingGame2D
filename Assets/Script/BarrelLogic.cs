using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelLogic : MonoBehaviour
{
    public GameObject cursor;
    public GameObject bullet;
    public Tank tank;
    // Start is called before the first frame update
    void Start()
    {
        tank = GameObject.FindGameObjectWithTag("Tank").GetComponent<Tank>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tank.isAlive)
        {
            Vector3 v1 = transform.position;
            Vector3 v2 = cursor.transform.position;
            Vector3 difference = v1 - v2;
            float ang = Mathf.Atan(difference.x / difference.y) * (180 / Mathf.PI);
            Vector3 deg = new Vector3(0, 0, difference.y > 0 ? 180 - ang : -ang);
            transform.localEulerAngles = deg;
            if (Input.GetButtonDown("Fire1"))
            {
                Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.Euler(0, 0, (difference.y > 0 ? 180 - ang : -ang) + 90));
            }
        }
    }
}
