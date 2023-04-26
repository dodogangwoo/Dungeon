using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
  {
      [SerializeField]
      private SpriteRenderer starRenderer;
      [SerializeField]
      private Slider sliderHp;
      [SerializeField]
      private TextMeshProUGUI text;
      
    public string targetObjectName;
    public string sceneName;
    public float maxHp = 5;
    public float hp;
    public GameObject shootObj;
    public Transform shootPosTf;
    public KeyCode shootKey;

    public float speed = 3;
    public float jumppower = 8;

    float vx = 0;
    bool leftFlag = false;
    bool pushFlag = false;
    bool jumpFlag = false;
    bool groundFlag = false;
    Rigidbody2D rbody;

    private void Awake()
    {
        hp = maxHp;
        text.text = $"{hp / maxHp:P0}";
    }

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        rbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        
    }

    void Update()
    {
        if (Input.GetKeyDown(shootKey))
        {
            Instantiate(shootObj, shootPosTf.position, Quaternion.identity);
        }
        vx = 0;
        if (Input.GetKey("right"))
        {
            vx = speed;
            leftFlag = false;
        }
        if (Input.GetKey("left"))
        {
            vx = -speed;
            leftFlag = true;
        }

        if (Input.GetKey("space") && groundFlag)
        {
            if (pushFlag == false)
            {
                jumpFlag = true;
                pushFlag = true;
            }
        }
        else
        {
            pushFlag = false;
        }
    }
    void FixedUpdate()
    {

        rbody.velocity = new Vector2(vx, rbody.velocity.y);

        this.GetComponent<SpriteRenderer>().flipX = leftFlag;

        if (jumpFlag)
        {
            jumpFlag = false;
            rbody.AddForce(new Vector2(0, jumppower), ForceMode2D.Impulse);
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        groundFlag = true;
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        groundFlag = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == targetObjectName)
        {
            hp -= 1;
            sliderHp.value = hp / maxHp;
            text.text = $"{hp / maxHp :P0}";
            StartCoroutine("ColorAnimation");
            if (hp == 0)
            {
                SceneManager.LoadScene(sceneName);
            }
        }
    }
    private IEnumerator ColorAnimation()
    {
        starRenderer.color = Color.red;
        //0.1초 쉰다.
        yield return new WaitForSeconds(0.1f);
        starRenderer.color = Color.white;
    }
  }