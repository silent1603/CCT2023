
using UnityEngine;

public interface IDamageable
{
    void TakeDamage(int value);
    void Heal(int value);
    GameObject GetGameObject();
}
