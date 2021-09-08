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
                        UpdateRectPosY(-55.0f);
                        return;
                    case BulletType.Beta:
                        UpdateRectPosY(-105.0f);
                        return;
                    case BulletType.Gamma:
                        UpdateRectPosY(-155.0f);
                        return;
                    case BulletType.Delta:
                        UpdateRectPosY(-205.0f);
                        return;
                    case BulletType.Epsilon:
                        UpdateRectPosY(-255.0f);
                        return;
                    case BulletType.Zeta:
                        UpdateRectPosY(-305.0f);
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
