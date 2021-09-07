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
        public bool IsShow { get; private set; } = false;

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
                    IsShow = true;
                    scope.gameObject.SetActive(IsShow);
                }
                else
                {
                    IsShow = false;
                    scope.gameObject.SetActive(IsShow);
                }
            }

            if (IsShow)
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