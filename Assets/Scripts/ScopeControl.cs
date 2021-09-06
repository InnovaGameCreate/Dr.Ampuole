using UnityEngine;

public class ScopeControl : MonoBehaviour
{
    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private RectTransform scopeRect;
    private RectTransform canvasRect;

    private void Start()
    {
        Cursor.visible = false;
        canvasRect = canvas.GetComponent<RectTransform>();
    }

    private void FixedUpdate()
    {
        scopeRect.anchoredPosition = CalcScopePosition();
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
