using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Game
{
    public class LevelMap : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;

        [SerializeField] private Transform _root;

        [SerializeField] private List<Vector3> _points;
        
        [SerializeField] private TerrainForMap _map1;
        [SerializeField] private TerrainForMap _map2;
        [SerializeField] private TerrainForMap _map3;
        

        public IReadOnlyList<Vector3> Points
        {
            get => _points;
            set => _points = value as List<Vector3>;
        }

        [MenuItem("CONTEXT/LevelMap/Instantiate Points")]
        private static void InstantiatePoints(MenuCommand command)
        {
            Clear(command);
            
            var levelMap = command.context as LevelMap;
            if (levelMap == null)
                return;

            foreach (var p in levelMap._points.Distinct())
            {
                var prefab = PrefabUtility.InstantiatePrefab(levelMap._prefab, levelMap._root) as GameObject;
                prefab.transform.position = p;
            }
        }
        
        [MenuItem("CONTEXT/LevelMap/Clear Points")]
        private static void Clear(MenuCommand command)
        {
            var levelMap = command.context as LevelMap;
            if (levelMap == null)
                return;
            
            var count = levelMap._root.childCount;
            for (var i = count - 1; i >= 0; i--)
            {
                DestroyImmediate(levelMap._root.GetChild(i).gameObject);
            }
        }

        [ContextMenu("LevelMap/Build Map1")]
        private void BuildMap1(MenuCommand command)
        {
            Clear(command);
            Points = _map1.WallPoints;
            var levelMap = command.context as LevelMap;
            if (levelMap == null)
                return;
            
            foreach (var p in _map1.WallPoints.Distinct())
            {
                var prefab = PrefabUtility.InstantiatePrefab(levelMap._prefab, levelMap._root) as GameObject;
                prefab.transform.position = p;
            }
        }
        
        [ContextMenu("LevelMap/Build Map2")]
        private void BuildMap2(MenuCommand command)
        {
            Clear(command);
            Points = _map2.WallPoints;
            var levelMap = command.context as LevelMap;
            if (levelMap == null)
                return;
            
            foreach (var p in _map2.WallPoints.Distinct())
            {
                var prefab = PrefabUtility.InstantiatePrefab(levelMap._prefab, levelMap._root) as GameObject;
                prefab.transform.position = p;
            }
        }
        
        [ContextMenu("LevelMap/Build Map3")]
        private void BuildMap3(MenuCommand command)
        {
            Clear(command);
            Points = _map3.WallPoints;
            var levelMap = command.context as LevelMap;
            if (levelMap == null)
                return;
            
            foreach (var p in _map3.WallPoints.Distinct())
            {
                var prefab = PrefabUtility.InstantiatePrefab(levelMap._prefab, levelMap._root) as GameObject;
                prefab.transform.position = p;
            }
        }
        
    }
}