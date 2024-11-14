using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public PlayerController PlayerController { get; private set; }
    public ParticleSystem clickParticle;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
        }
        Instance = this;

        PlayerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        clickParticle = Instantiate(clickParticle);
        clickParticle.Stop();
    }

    public void PlayParticle(Vector2 position)
    {
        Debug.Log("ParticlePosition" + position);
        clickParticle.transform.position = position;
        clickParticle.Play();
    }
}
