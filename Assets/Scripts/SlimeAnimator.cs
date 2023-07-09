using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class SlimeAnimator : MonoBehaviour
{
    public AnimationCurve occilator;
    public List<float> timers;
    public List<Vector2> directions;
    public Transform animBase;
    public float timeScale;
    public float amplitudeScale;
    public float maxTime;

    void Start()
    {
        maxTime = occilator.keys[^1].time * timeScale;
        timers = new();
        directions = new();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPos = Vector2.zero;
        for (int i = timers.Count - 1; i >= 0; i--)
        {
            timers[i] += Time.deltaTime;
            if (timers[i] > maxTime)
            {
                timers.RemoveAt(i);
                directions.RemoveAt(i);
                continue;
            }
            Vector2 vectorToAdd = directions[i] * occilator.Evaluate(timers[i] * timeScale) * amplitudeScale;
            newPos += vectorToAdd;
        }
        transform.localPosition = newPos;
    }

    public void AddAngle(Vector2 dir)
    {
        timers.Add(0);
        directions.Add(dir);
    }
}
