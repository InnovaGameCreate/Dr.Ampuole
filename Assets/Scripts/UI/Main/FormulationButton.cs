using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class FormulationButton : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    private Button button;
    private bool isMixing = false;

    private void Start()
    {
        button = GetComponent<Button>();

        button.OnClickAsObservable()
            .Subscribe(_ =>
            {
                isMixing = !isMixing;
                animator.SetBool("isMixing", isMixing);
            }).AddTo(this);
    }
}
