using UnityEngine;

public abstract class ZombieInput : MonoBehaviour
{
    public  abstract (Vector3 moveDirection, Quaternion viewDirection, bool shoot) CurrentInput();
}