using UnityEngine;
using UnityEngine.Tilemaps;
[RequireComponent(typeof(Tilemap))]
public class EditTileWorld : MonoBehaviour
{
    [SerializeField]
    private TileBase tileToSet;
    private Tilemap _tilemap;

    private Camera _camera;
    // Start is called before the first frame update
    void Start()
    {
        _tilemap = GetComponent<Tilemap>();
        _camera = Camera.main;
    }

    void Hit(Vector3 position, TileBase objTileBase)
    {
        var grid = _tilemap.GetComponentInParent<Grid>();

        var vint = grid.WorldToCell(position);
        _tilemap.SetTile(vint, objTileBase);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Hit(_camera.ScreenToWorldPoint(Input.mousePosition), null);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            Hit(_camera.ScreenToWorldPoint(Input.mousePosition), tileToSet);
        }
    }
}
