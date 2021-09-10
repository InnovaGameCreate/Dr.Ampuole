using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;
using Patient;
using Bullets;

namespace UI.Main.Presenter
{
    public class FormulationPresenter : MonoBehaviour
    {
        [SerializeField]
        private List<BulletView> views;
        private Image clone;

        private void Start()
        {
            var eventTrigger = gameObject.AddComponent<ObservableEventTrigger>();

            var canvas = GetComponentInParent<Canvas>();
            var canvasRect = GetComponentInParent<RectTransform>();

            views[0].Image.OnBeginDragAsObservable()
                .Subscribe(_ => clone = CloneSmallImage(views[0].Image)).AddTo(this);
            views[0].Image.OnDragAsObservable()
                .Subscribe(d =>
                {
                    RectTransformUtility
                        .ScreenPointToLocalPointInRectangle(
                            canvasRect,
                            d.position,
                            canvas.worldCamera,
                            out Vector2 mousePos);
                    clone.rectTransform.localPosition = mousePos;
                }).AddTo(this);
            views[0].Image.OnEndDragAsObservable()
                .Subscribe(d => PourLiquid(d, PatientType.Alpha)).AddTo(this);


            views[1].Image.OnBeginDragAsObservable()
                .Subscribe(_ => clone = CloneSmallImage(views[1].Image)).AddTo(this);
            views[1].Image.OnDragAsObservable()
                .Subscribe(d =>
                {
                    RectTransformUtility
                        .ScreenPointToLocalPointInRectangle(
                            canvasRect,
                            d.position,
                            canvas.worldCamera,
                            out Vector2 mousePos);
                    clone.rectTransform.localPosition = mousePos;
                }).AddTo(this);
            views[1].Image.OnEndDragAsObservable()
                .Subscribe(d => PourLiquid(d, PatientType.Beta)).AddTo(this);


            views[2].Image.OnBeginDragAsObservable()
                .Subscribe(_ => clone = CloneSmallImage(views[2].Image)).AddTo(this);
            views[2].Image.OnDragAsObservable()
                .Subscribe(d =>
                {
                    RectTransformUtility
                        .ScreenPointToLocalPointInRectangle(
                            canvasRect,
                            d.position,
                            canvas.worldCamera,
                            out Vector2 mousePos);
                    clone.rectTransform.localPosition = mousePos;
                }).AddTo(this);
            views[2].Image.OnEndDragAsObservable()
                .Subscribe(d => PourLiquid(d, PatientType.Gamma)).AddTo(this);
        }

        private Image CloneSmallImage(Image image)
        {
            var clone = Instantiate(image, image.transform.parent, true);
            clone.rectTransform.localScale = image.transform.localScale * 0.50f;
            clone.raycastTarget = false;    // rayCastのターゲットにならないようにする
            return clone;
        }

        private void PourLiquid(PointerEventData data, PatientType patientType)
        {
            var g = data.pointerCurrentRaycast.gameObject;

            // rayCastのターゲットがnullなら破棄
            if (g == null)
            {
                Destroy(clone);
                clone = null;
                return;
            }

            var a = g.GetComponent<Ampuole>();
            if (a != null)
            {
                a.Pour(patientType);
            }
            Destroy(clone);
            clone = null;
        }
    }
}