using UnityEngine;

[CreateAssetMenu(fileName = "parameter", menuName = "shoot")]
public class ShootParameters : ScriptableObject
{
    public bool focusTarget;

    public int proyectilPerBurst;
    public float burstAngle;

    public float timeDelay;
    public float startingDistance;
    public float timeBetweenBurst;
}