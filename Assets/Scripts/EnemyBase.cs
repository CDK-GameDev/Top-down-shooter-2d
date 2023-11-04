using UnityEngine;

namespace Assets.Scripts
{
    public class EnemyBase : MonoBehaviour
    {
        [SerializeField] private int enemyScoreValue = 10;
        public static event System.Action<int> OnEnemyDestroyed;

        void OnDestroy()
        {
            OnEnemyDestroyed?.Invoke(enemyScoreValue);
        }
    }
}
