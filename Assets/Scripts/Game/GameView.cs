using System.Linq;
using UnityEngine;

namespace Game
{
    public class GameView : MonoBehaviour
    {
        [SerializeField] private BaseDefence _baseDefence;
        [SerializeField] private GameObject _winBlock;
        [SerializeField] private GameObject _gameOverBlock;

        private void Update()
        {
            if (_baseDefence._gameOver == true)
            {
                _gameOverBlock.SetActive(true);
            }
        }
    }
}