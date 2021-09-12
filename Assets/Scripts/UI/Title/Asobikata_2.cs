using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asobikata_2 : MonoBehaviour
{
    [SerializeField] private GameObject asobikata_1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            asobikata_1.SetActive(true);
        }
    }
}
