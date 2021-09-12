using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explanation_1 : MonoBehaviour
{
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
            asobikata_2.SetActive(true);
        }
    }
}
