using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    bool leftFlag;
    public float damage = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        if (Input.GetKey("right"))
        {
            leftFlag = false;
        }
        if (Input.GetKey("left"))
        {
            leftFlag = true;
        }
    }
    void Update()
    {

        if (leftFlag == false)
        {
            gameObject.transform.Translate(0.3f, 0, 0);
        }
        if (leftFlag == true)
        {
            gameObject.transform.Translate(-0.3f, 0, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Ballon>())
        {
            collision.GetComponent<Ballon>().hp -= damage;
        }
    }
    // Update is called once per frame
}