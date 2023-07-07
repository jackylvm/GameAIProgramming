// *************************************************************************************
// FileName: MsgType.cs
// Description:
// 
// Version: v1.0.0
// Creator: Jacky(jackylvm@foxmail.com)
// CreationTime: 2023-07-07 23:14:23
// ==============================================================
// History update record:
// 
// ==============================================================
// *************************************************************************************

namespace Common.Message
{
    public enum EmMsgType
    {
        Msg_HiHoneyImHome,
        Msg_StewReady,
    }

    public static class MsgUtils
    {
        public static string MsgToStr(EmMsgType msg)
        {
            return msg switch
            {
                EmMsgType.Msg_HiHoneyImHome => "HiHoneyImHome",
                EmMsgType.Msg_StewReady => "StewReady",
                _ => "Not recognized!"
            };
        }
    }
}