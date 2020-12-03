using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VirtualJoystick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
    // Спрайт, перемещаемый по экрану
    public RectTransform thumb;
    // Местоположение пальца и джойстика, когда
    // происходит перемещение
    [SerializeField]
    private Vector3 originalPosition;
    [SerializeField]
    private Vector2 originalThumbPosition;
    // Расстояние, на которое сместился палец относительно
    // исходного местоположения
    public Vector2 delta;

    private RectTransform _rectTransform; 
    
    void Start () {
        _rectTransform = GetComponent<RectTransform>();
        // В момент запуска запомнить исходные
        // координаты
        originalPosition = _rectTransform.anchoredPosition;
        originalThumbPosition = thumb.localPosition;
        // Выключить площадку, сделав ее невидимой
        thumb.gameObject.SetActive(false);
        // Сбросить величину смещения в ноль
        delta = Vector2.zero;
    }
    
    // Вызывается, когда начинается перемещение
    public void OnBeginDrag (PointerEventData eventData) {
        // Сделать площадку видимой
        thumb.gameObject.SetActive(true);
        // Зафиксировать мировые координаты, откуда начато перемещение
        Vector3 worldPoint = new Vector3();
        RectTransformUtility.ScreenPointToWorldPointInRectangle(this.transform as RectTransform, eventData.position, eventData.enterEventCamera, out worldPoint);
        // Поместить джойстик в эту позицию
        _rectTransform.position = worldPoint;
        // Поместить площадку в исходную позицию
        // относительно джойстика
        thumb.localPosition = originalThumbPosition;
    }
    
    // Вызывается в ходе перемещения
    public void OnDrag (PointerEventData eventData) {
        // Определить текущие мировые координаты точки контакта пальца с экраном
        Vector3 worldPoint = new Vector3();
        RectTransformUtility.ScreenPointToWorldPointInRectangle(this.transform as RectTransform, eventData.position, eventData.enterEventCamera, out worldPoint);
        // Поместить площадку в эту точку
        thumb.position = worldPoint;
        // Вычислить смещение от исходной позиции
        var size = _rectTransform.rect.size;
        delta = thumb.localPosition;
        delta.x /= size.x / 2.0f;
        delta.y /= size.y / 2.0f;
        delta.x = Mathf.Clamp(delta.x, -1.0f, 1.0f);
        delta.y = Mathf.Clamp(delta.y, -1.0f, 1.0f);
    }
    
    // Вызывается по окончании перемещения
    public void OnEndDrag (PointerEventData eventData) {
        // Сбросить позицию джойстика
        _rectTransform.anchoredPosition = originalPosition;
        // Сбросить величину смещения в ноль
        delta = Vector2.zero;
        // Скрыть площадку
        thumb.gameObject.SetActive(false);
    }
}