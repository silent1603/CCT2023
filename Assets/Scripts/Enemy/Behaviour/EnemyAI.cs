using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAI : MonoBehaviour, IDamageable
{
    public EnemySO enemySO;

    #region STAT
    int _health;

    #endregion STAT

    [SerializeField]
    private List<SteeringBehaviour> steeringBehaviours;

    [SerializeField]
    private List<Detector> detectors;

    [SerializeField]
    private AIData aiData;

    [SerializeField]
    private float detectionDelay = 0.05f, aiUpdateDelay = 0.06f, attackDelay = 1f;

    [SerializeField]
    private float attackDistance = 0.5f;

    //Inputs sent from the Enemy AI to the Enemy controller
    public UnityEvent OnAttackPressed;
    public UnityEvent<Vector2> OnMovementInput, OnPointerInput;

    [SerializeField]
    private Vector2 movementInput;

    [SerializeField]
    private ContextSolver movementDirectionSolver;

    bool following = false;

    private void Start()
    {
        //Detecting Player and Obstacles around
        Init();
        InvokeRepeating("PerformDetection", 0, detectionDelay);
    }

    public void Init()
    {
        _health = enemySO.health;
    }

    private void PerformDetection()
    {
        foreach (Detector detector in detectors)
        {
            detector.Detect(aiData);
        }
    }

    private void Update()
    {
        //Enemy AI movement based on Target availability
        if (aiData.currentTarget != null)
        {
            //Looking at the Target
            OnPointerInput?.Invoke(aiData.currentTarget.position);
            if (following == false)
            {
                following = true;
                StartCoroutine(ChaseAndAttack());
            }
        }
        else if (aiData.GetTargetsCount() > 0)
        {
            //Target acquisition logic
            aiData.currentTarget = aiData.targets[0];
        }
        //Moving the Agent
        OnMovementInput?.Invoke(movementInput);
    }

    private IEnumerator ChaseAndAttack()
    {
        if (aiData.currentTarget == null)
        {
            //Stopping Logic
            movementInput = Vector2.zero;
            following = false;
            yield break;
        }
        else
        {
            float distance = Vector2.Distance(aiData.currentTarget.position, transform.position);

            if (distance < attackDistance)
            {
                //Attack logic
                movementInput = Vector2.zero;
                OnAttackPressed?.Invoke();
                yield return new WaitForSeconds(attackDelay);
                StartCoroutine(ChaseAndAttack());
            }
            else
            {
                //Chase logic
                movementInput = movementDirectionSolver.GetDirectionToMove(steeringBehaviours, aiData);
                yield return new WaitForSeconds(aiUpdateDelay);
                StartCoroutine(ChaseAndAttack());
            }

        }

    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public void Heal(int value)
    {
        //TODO: maybe regain health?
    }

    public void TakeDamage(int value)
    {
        print("damage = " + value);

        if (_health <= 0)
        {
            //TODO: unsub from update behaviour event
            //TODO: call to the AIDirector to remove self from the list.

            _health = 0;
            Destroy(gameObject);
        }

        _health -= value;
    }
}
