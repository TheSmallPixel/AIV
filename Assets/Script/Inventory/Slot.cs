using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    public int Id { get; private set; }
    private Action<int, GameItem, Slot> _onDrop;

    public void Setup(int id, Action<int, GameItem, Slot> onDrop)
    {
        this.Id = id;
        this._onDrop = onDrop;
    }


    public void OnDrop(PointerEventData eventData)
    {
        var gi = eventData.pointerDrag.GetComponent<GameItem>();
        if (gi != null)
        {
            _onDrop?.Invoke(Id, gi, this);
        }
    }
}
