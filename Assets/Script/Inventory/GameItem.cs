using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameItem : MonoBehaviour, IBeginDragHandler, IPointerDownHandler, IEndDragHandler, IDragHandler
{
    private ItemGameobject _itemGameobject;
    public Item Item { get; private set; }


    private Camera _camera;
    [SerializeField]
    private Image _image;

    private Vector2 _offset;
    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _camera = Camera.main;
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Setup(ItemGameobject itemGameobject, Item item)
    {
        this.Item = item;
        this._itemGameobject = itemGameobject;
        _image.sprite = _itemGameobject.Sprite;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _offset = new Vector2(transform.position.x, transform.position.y) - eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = true;
        transform.localPosition = Vector3.zero;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position + _offset;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = false;
    }
}
