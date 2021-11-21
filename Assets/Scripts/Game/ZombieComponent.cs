using UnityEngine;

namespace Game
{
    public class ZombieComponent : MonoBehaviour
    {
        [SerializeField] private GameObject _aliveView;

        [SerializeField] private GameObject _diedView;
        
        /*
        private Vector3 _initPosition;

        private void Awake()
        {
            _initPosition = transform.position;
        }
        */

        private void OnEnable()
        {
            SetState(true);
        }
        
        public void SetState(bool alive)
        {
            _aliveView.SetActive(alive);
            _diedView.SetActive(!alive);
        }

        public bool IsAlive => _aliveView.activeInHierarchy;
    }
}