using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    [CreateAssetMenu(fileName = "New Map", menuName = "Map of terrain", order = 51)]
    public class TerrainForMap : ScriptableObject
    {
        [SerializeField] private List<Vector3> _wallpoints;

        public List<Vector3> WallPoints
        {
            get => _wallpoints;
            set => _wallpoints = value;
        }
    }
}   