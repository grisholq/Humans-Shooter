using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float period;

    public bool Passed { get; set; }

    private void Awake()
    {
        Passed = true;
    }

    public void Restart()
    {
        StartCoroutine(StartTimer());
    }

    private IEnumerator StartTimer()
    {
        Passed = false;
        yield return new WaitForSeconds(period);
        Passed = true;
    }
}