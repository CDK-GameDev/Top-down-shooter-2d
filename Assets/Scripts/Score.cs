using System.Globalization;
using TMPro;
using UnityEngine;

namespace Assets.Scripts
{
    public class Score : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI score_text;
        [SerializeField] private int score;
        private void Start()
        {
            EnemyBase.OnEnemyDestroyed += UpdateScore;
        }

        private void UpdateScore(int scorePoints)
        {
            score += scorePoints;
            score_text.text = $"Score: {score.ToString(CultureInfo.InvariantCulture)}";
        }
    }
}
