using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundHandler : MonoBehaviour
{
    [SerializeField] ChapterColor background;
    void Start()
    {
        float s = GetComponentInParent<Camera>().orthographicSize * 2;
        transform.localScale = new(s,s,1);   

        GetComponent<SpriteRenderer>().color = background.color;
    }
}
