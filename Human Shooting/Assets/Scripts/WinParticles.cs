using UnityEngine;

public class WinParticles : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] winParticles;

    public void PlayWinParticles()
    {
        foreach (var particles in winParticles)
        {
            particles.Play();
        }
    }
}