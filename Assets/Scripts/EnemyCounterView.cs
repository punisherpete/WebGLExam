using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyCounterView : MonoBehaviour
{
    [SerializeField] private Image _enemyIcon;
    [SerializeField] private TMP_Text _enemyCount;

    [SerializeField] private Sprite _idleEnemySprite;
    [SerializeField] private Sprite _decreaseEnemySprite;

    [SerializeField] private float _changeIconDelay;

    private Coroutine _returnIdleSprite;

    public void ShowCount(string count, bool isLastEnemy)
    {
        _enemyCount.SetText(count);
        _enemyIcon.sprite = _decreaseEnemySprite;

        if (_returnIdleSprite != null)
            StopCoroutine(_returnIdleSprite);

        if (isLastEnemy)
        {
            gameObject.SetActive(false);
        }
        else
        {
            _returnIdleSprite = StartCoroutine(ReturnIdleSprite());
        }
    }

    private IEnumerator ReturnIdleSprite()
    {
        yield return new WaitForSeconds(_changeIconDelay);
        _enemyIcon.sprite = _idleEnemySprite;
    }
}
