using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class PlayerController : MonoBehaviour
{
    public EnemyGenerator enemyGenerator;
    public UIMAnager uiManager;
    public Enemy enemy;

    public float autoClickTime;
    public bool isAutoClick = false;
    public float power;
    public int clickGold = 1;

    private Coroutine coroutine;

    public void Start()
    {
        enemy = enemyGenerator.child.GetComponent<Enemy>();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            ParticleSystem particle = GameManager.Instance.clickParticle;

            if (context.control == Mouse.current.leftButton)
            {
                Vector2 mouse = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
                if (!isInBox(mouse)) return;
                GameManager.Instance.PlayParticle(mouse);
            }
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
        if (coroutine != null) StopCoroutine(coroutine);
        coroutine = StartCoroutine(AutoClickCoroutine());
    }

    public void AutoClickStartCoroutine()
    {
        isAutoClick = true;
        coroutine = StartCoroutine(AutoClickCoroutine());
    }
}