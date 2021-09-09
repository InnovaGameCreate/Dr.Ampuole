using UnityEngine;
using UniRx;
using Player;
using Bullets;

public class ExampleBulletChoice : MonoBehaviour
{
    private RectTransform rectTransform;
    [SerializeField]
    private PlayerChoiceBullet choiceBullet;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        choiceBullet.CurrentBulletType
            .Subscribe(bt =>
            {
                switch (bt)
                {
                    case BulletType.Alpha:
                        UpdateRectPosY(125.0f);
                        return;
                    case BulletType.Beta:
                        UpdateRectPosY(75.0f);
                        return;
                    case BulletType.Gamma:
                        UpdateRectPosY(25.5f);
                        return;
                    case BulletType.Delta:
                        UpdateRectPosY(-25.0f);
                        return;
                    case BulletType.Epsilon:
                        UpdateRectPosY(-75.0f);
                        return;
                    case BulletType.Zeta:
                        UpdateRectPosY(-125.0f);
                        return;
                    default:
                        return;
                }
            }).AddTo(this);
    }

    private void UpdateRectPosY(float y)
    {
        var pos = rectTransform.anchoredPosition;
        rectTransform.anchoredPosition = new Vector2(pos.x, y);
    }
}
