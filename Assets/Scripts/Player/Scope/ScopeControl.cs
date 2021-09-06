using UnityEngine;

namespace Player.Scope
{
    public class ScopeControl : MonoBehaviour
    {
        [SerializeField]
        private Canvas canvas;
        [SerializeField]
        private RectTransform scopeRect;
        private RectTransform canvasRect;

        [SerializeField]
        private GameObject scope;
        private bool isShow = false;

        private void Start()
        {
            Cursor.visible = false;
            canvasRect = canvas.GetComponent<RectTransform>();
            scope.gameObject.SetActive(false);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (scope.gameObject.activeSelf == false)
                {
                    isShow = true;
                    scope.gameObject.SetActive(isShow);
                }
                else
                {
                    isShow = false;
                    scope.gameObject.SetActive(isShow);
                }
            }

            if (isShow)
            {
                scopeRect.anchoredPosition = CalcScopePosition();
            }
        }

        private Vector2 CalcScopePosition()
        {
            RectTransformUtility
                        .ScreenPointToLocalPointInRectangle(
                            canvasRect,
                            Input.mousePosition,
                            canvas.worldCamera,
                            out Vector2 mousePos);
            return new Vector2(mousePos.x, mousePos.y);
        }
    }
}