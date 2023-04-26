using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderExercise : MonoBehaviour
{
    [SerializeField]
    private Slider sliderHp;

    [SerializeField]
    private TextMeshProUGUI text;

    [SerializeField]
    private SpriteRenderer ballonRenderer;

 
    private float maxHp = 100;
    private float currentHp;
    private float damage = 12;
    public string targetObjectName;


    /*private void Awake()
    {
        currentHp = maxHp;
        text.text = $"{currentHp / maxHp:P0}";
    }*/


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("dddd");
        if (collision.gameObject.name == targetObjectName)
        {
            if (currentHp > 0)
            {
                currentHp -= damage;
                currentHp = Mathf.Max(currentHp, 0);
                Debug.Log($"currentHp : {currentHp}");

                sliderHp.value = currentHp / maxHp;
                text.text = $"{currentHp / maxHp:P0}";

                StartCoroutine("ColorAnimation");
            }
        }
    }
        
    private IEnumerator ColorAnimation()
    {
        ballonRenderer.color = Color.red;
        //0.1초 쉰다.
        yield return new WaitForSeconds(0.1f);
        ballonRenderer.color = Color.white;
    }


    public void OnValueChanged(float value)
    {
        text.text = $"Volume : {value * 100:F1}%";
    }

   /* public void OnValueChangedAlpha(float value)
    {
        Color color = ballonRenderer.color;
        color.a = value;
        ballonRenderer.color = color;

        text.text = $"Alpha : {value * 255:F0}";
    }*/

   
}

