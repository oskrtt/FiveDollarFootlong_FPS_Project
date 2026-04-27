using Unity.FPS.AI;
using Unity.FPS.Game;
using UnityEngine;

public class Enemy_HoverBot_Shoot : MonoBehaviour
{
    public AK.Wwise.Event shootEvent;
    public DetectionModule DetectionModule { get; private set; }
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
        m_EnemyController.onAttack += OnAttack;
    }
    void OnAttack()
    {
        shootEvent.Post(gameObject);
    }
}