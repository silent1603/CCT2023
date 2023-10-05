
using UnityEngine;

public interface IDamageable
{
    void TakeDamage(float value);
    void Heal(float value);
    GameObject GetGameObject();
}
