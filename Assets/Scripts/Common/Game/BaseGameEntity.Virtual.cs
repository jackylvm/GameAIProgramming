// *************************************************************************************
// FileName: BaseGameEntity.Virtual.cs
// Description:
// 
// Version: v1.0.0
// Creator: Jacky(jackylvm@foxmail.com)
// CreationTime: 2023-07-04 14:58:56
// ==============================================================
// History update record:
// 
// ==============================================================
// *************************************************************************************

using System;
using Common.Message;

namespace Common.Game
{
    public partial class BaseGameEntity
    {
        public virtual void DoStart()
        {
            throw new NotImplementedException();
        }

        public virtual void DoUpdate(float deltaTime)
        {
            throw new NotImplementedException();
        }

        public virtual bool HandleMessage(Telegram telegram)
        {
            throw new NotImplementedException();
        }
    }
}