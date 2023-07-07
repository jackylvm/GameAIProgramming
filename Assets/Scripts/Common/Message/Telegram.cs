// *************************************************************************************
// FileName: Telegram.cs
// Description:
// 
// Version: v1.0.0
// Creator: Jacky(jackylvm@foxmail.com)
// CreationTime: 2023-07-07 23:18
// Copyright: 2021 - 2023 咔丘互娱（上海）网络科技有限公司
// ==============================================================
// History update record:
// 
// ==============================================================
// *************************************************************************************

namespace Common.Message
{
    public class Telegram
    {
        public int Sender;
        public int Receiver;
        public EmMsgType MsgType;
        public double DispatchTime;

        public Telegram(double time, int sender, int receiver, EmMsgType msg)
        {
            DispatchTime = time;
            Sender = sender;
            Receiver = receiver;
            MsgType = msg;
        }
    }
}