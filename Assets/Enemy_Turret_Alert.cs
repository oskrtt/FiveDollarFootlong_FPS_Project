using Unity.FPS.AI;
using Unity.FPS.Game;
using UnityEngine;

public class Enemy_Turret_Alert : MonoBehaviour
{
    public AK.Wwise.Event alertEvent;
    public enum AIState
    {
        Patrol,
        Follow,
        Attack,
    }
    public AIState AiState { get; private set; }
    EnemyController m_EnemyController;
    void Start()
    {
        m_EnemyController = GetComponent<EnemyController>();
        DebugUtility.HandleErrorIfNullGetComponent<EnemyController, EnemyMobile>(m_EnemyController, this,
            gameObject);
        m_EnemyController.onDetectedTarget += OnDetectedTarget;
    }
    void OnDetectedTarget()
    {
        alertEvent.Post(gameObject);
    }
}