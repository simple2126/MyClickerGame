using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class PlayerController : MonoBehaviour
{
    private float autoClickTime = 1f;
    
    public float power;
    public EnemyGenerator enemyGenerator;
    public UIMAnager uiManager;
    public Enemy enemy;
    public int clickGold = 1;
    public bool isAutoClick = false;

    public void Awake()
    {
        enemy = enemyGenerator.child.GetComponent<Enemy>();
    }

    public void OnAttack()
    {
        Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        if (Input.GetMouseButtonDown(0) && isInBox(mouse))
        {
            Debug.Log("OnAttack");
            enemy.ChangeHealth(power);
            uiManager.UpdateGold(clickGold);
        }
    }

    private bool isInBox(Vector2 inputPos)
    {
        RaycastHit2D hit = Physics2D.Raycast(inputPos, Vector2.zero, 0f);
        if(hit.collider != null)
        {
            return true;
        }
        return false;
    }

    private IEnumerator AutoClickCoroutine()
    {
        yield return new WaitForSeconds(autoClickTime);
        enemy.ChangeHealth(power);
        StartCoroutine(AutoClickCoroutine());
    }
}