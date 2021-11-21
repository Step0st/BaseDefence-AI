using System.Linq;
using Game;
using UnityEngine;

namespace Search
{
    public class AStarBotZombie : ZombieInput
    {
        [SerializeField] private LevelMap _levelMap;
        [SerializeField] private GameObject _base;
        
        private int[,] _terrainMap;
        private int _deltaX;
        private int _deltaZ;

        public override (Vector3 moveDirection, Quaternion viewDirection, bool shoot) CurrentInput()
        {
            
            var targetPosition = _base.transform.position;
            var zombiePosition = transform.position;
            var from = ToInt(zombiePosition);
            var to = ToInt(targetPosition);

            var path = AStarFromGoogle.FindPath(_terrainMap, @from, to);
            var nextPathPoint = path.Count >= 2 ? path[1] : to;
            nextPathPoint = new Vector2Int(nextPathPoint.x - _deltaX, nextPathPoint.y - _deltaZ);
            
            var moveDirection = new Vector3(nextPathPoint.x, transform.position.y,nextPathPoint.y) - transform.position;
            var directVector = targetPosition - transform.position;
            
            return (moveDirection, Quaternion.LookRotation(directVector), false);
        }

        private void Awake()
        {
            var maxX = _levelMap.Points.Max(p => Mathf.RoundToInt(p.x));
            var minX = _levelMap.Points.Min(p => Mathf.RoundToInt(p.x));
            var maxZ = _levelMap.Points.Max(p => Mathf.RoundToInt(p.z));
            var minZ = _levelMap.Points.Min(p => Mathf.RoundToInt(p.z));

            _deltaX = minX < 0 ? -minX : 0;
            _deltaZ = minZ < 0 ? -minZ : 0;
            _terrainMap = new int[maxX + _deltaX + 1, maxZ + _deltaZ + 1];
            
            foreach (var point in _levelMap.Points)
            {
                _terrainMap[_deltaX + Mathf.RoundToInt(point.x), _deltaZ + Mathf.RoundToInt(point.z)] = -1;
            }
        }

        private Vector2Int ToInt(Vector3 vector3) =>
            new Vector2Int(_deltaX + Mathf.RoundToInt(vector3.x), _deltaZ + Mathf.RoundToInt(vector3.z));
    }
}