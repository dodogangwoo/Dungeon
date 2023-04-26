using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Time : MonoBehaviour
{
    [SerializeField]
    private Slider sliderHp;
    [SerializeField]
    private SpriteRenderer starRenderer;
    [SerializeField]
    private TextMeshProUGUI text;
    public string sceneName;
    public float maxHp = 5;
    public float hp;
    // Start is called before the first frame update
    void Start()
    {
        text.text = $"{hp / maxHp:P0}";
        hp = maxHp;
        StartCoroutine("HpDamage");
        StartCoroutine("ColorAnimation");
    }

    // Update is called once per frame
    void Update()
    {
        if (hp == 0)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
    
    
    private IEnumerator HpDamage()
    {
        while (true)
        {
            hp -= 1;
            sliderHp.value = hp / maxHp;
            text.text = $"{hp / maxHp :P0}";
            yield return new WaitForSeconds(3);
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
