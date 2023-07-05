// *************************************************************************************
// FileName: Chapter02_01.cs
// Description:
// 
// Version: v1.0.0
// Creator: Jacky(jackylvm@foxmail.com)
// CreationTime: 2023-07-05 00:19:08
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
    public class Chapter02_01 : MonoBehaviour
    {
        [SerializeField] private Miner m_Miner;

        private void Awake()
        {
            m_Miner = new Miner((int) EmEntity.EntMinerBob);
        }

        private void Start()
        {
            m_Miner.DoStart();
        }

        private void Update()
        {
            m_Miner.DoUpdate(Time.deltaTime);
        }

        private void FixedUpdate()
        {
        }
    }
}