using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class Ballon : MonoBehaviour
{
    [SerializeField]
    private Slider sliderHp;
    
    [SerializeField]
    private TextMeshProUGUI text;
    
    public float maxHp = 30;
    public float hp;
    public string targetObjectName;
    public string targetObjectName2;
    public float speed = 1;
    public string sceneName;

    
    GameObject targetObject;
    Rigidbody2D rb;
    // Start is called before the first frame update

    private void Awake()
    {
        hp = maxHp;
        text.text = $"{hp / maxHp:P0}";
    }

    void Start()
    {
        targetObject = GameObject.Find(targetObjectName);
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    private void FixedUpdate()
    {
        Vector3 dir = (targetObject.transform.position - this.transform.position).normalized;
        float vx = dir.x * speed;
        float vy = dir.y * speed;
        rb.velocity = new Vector2(vx, vy);
        this.GetComponent<SpriteRenderer>().flipX = (vx < 0);
    }

    // Update is called once per frame
    void Update()
    {
       
        if (hp == 0)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag(targetObjectName2))
        {
            hp -= 1;
            sliderHp.value = hp / maxHp;
            text.text = $"{hp / maxHp :P0}";

            if (hp == 0)
            {
                SceneManager.LoadScene(sceneName);
            }
        }
    }
}

