using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asobikata : MonoBehaviour
{
    [SerializeField] GameObject asobikata;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            
    }
    public void OnClick()
    {
        asobikata.SetActive(false);
    }
}
