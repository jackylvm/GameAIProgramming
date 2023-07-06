// *************************************************************************************
// FileName: Chapter02_02.cs
// Description:
// 
// Version: v1.0.0
// Creator: Jacky(jackylvm@foxmail.com)
// CreationTime: 2023-07-06 23:40:27
// ==============================================================
// History update record:
// 
// ==============================================================
// *************************************************************************************

using Chapter02.Runtime.Entity;
using Chapter02.Runtime.Enum;
using UnityEngine;

namespace Chapter02.Runtime.Main
{
    public class Chapter02_02 : MonoBehaviour
    {
        [SerializeField] private Miner m_Bob;
        [SerializeField] private MinersWife m_Elsa;

        private void Awake()
        {
            m_Bob = new Miner((int) EmEntity.EntMinerBob);
            m_Elsa = new MinersWife((int) EmEntity.EntElsa);
        }

        private void Start()
        {
            m_Bob.DoStart();
            m_Elsa.DoStart();
        }

        private void Update()
        {
            m_Bob.DoUpdate(Time.deltaTime);
            m_Elsa.DoUpdate(Time.deltaTime);
        }

        private void FixedUpdate()
        {
        }
    }
}