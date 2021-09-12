using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplanationController : MonoBehaviour
{
    [SerializeField] private GameObject asobikata;
    [SerializeField] private GameObject asobikata_1;
    [SerializeField] private GameObject asobikata_2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            asobikata.SetActive(false);
            asobikata_1.SetActive(false);
            asobikata_2.SetActive(false);
        }
    }
}
