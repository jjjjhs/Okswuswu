using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeEffect : MonoBehaviour
{
    private Image image; //페이드 효과에 사용되는 검은 이미지
    
    private void Awake()
    {
        image = GetComponent<Image>();
    }

    private void Update()
    {
  
        Color color = image.color;

        if (color.a > 0)
        {
            color.a -= Time.deltaTime;
        }

        image.color = color;
    }
}
