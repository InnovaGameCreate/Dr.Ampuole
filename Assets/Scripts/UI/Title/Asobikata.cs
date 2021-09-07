using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asobikata : MonoBehaviour
{
    [SerializeField] private GameObject asobikata;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            asobikata.SetActive(false);
    }
    public void OnClick()
    {
        asobikata.SetActive(true);
    }
}
