using UnityEngine;
using UnityEngine.Tilemaps;

namespace Utils
{
    public class TileUtils : MonoBehaviour
    {
        [SerializeField]
        private Tilemap _tilemap;

        [SerializeField]
        private Tile _tile1;

        [SerializeField]
        private Tile _tile2;


        [ContextMenu("Randomize Tiles")]
        public void ReplaceTilesInTilemap()
        {
            for (int y = _tilemap.origin.y; y < (_tilemap.origin.y + _tilemap.size.y); y++)
            {
                for (int x = _tilemap.origin.x; x < (_tilemap.origin.x + _tilemap.size.x); x++)
                {
                    var position = new Vector3Int(x, y, 0);

                    var tile = _tilemap.GetTile(position);
                    if (tile != null)
                    {
                        Tile newTile = (Random.value > 0.5f) ? _tile1 : _tile2;

                        _tilemap.SetTile(position, newTile);
                    }
                }
            }
        }
    }
}