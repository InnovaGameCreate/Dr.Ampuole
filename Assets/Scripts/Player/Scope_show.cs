using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scope_show : MonoBehaviour
{
    [SerializeField] GameObject sprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {    
            if (sprite.gameObject.activeSelf == false)
                {
                    sprite.gameObject.SetActive(true);
                }
            else    
                {
                    sprite.gameObject.SetActive(false);
                }
        }
    }
}
