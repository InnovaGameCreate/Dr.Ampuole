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
                        UpdateRectPosY(108.8f);
                        return;
                    case BulletType.Beta:
                        UpdateRectPosY(66.6f);
                        return;
                    case BulletType.Gamma:
                        UpdateRectPosY(24.6f);
                        return;
                    case BulletType.Delta:
                        UpdateRectPosY(-17.8f);
                        return;
                    case BulletType.Epsilon:
                        UpdateRectPosY(-59.5f);
                        return;
                    case BulletType.Zeta:
                        UpdateRectPosY(-101.1f);
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
