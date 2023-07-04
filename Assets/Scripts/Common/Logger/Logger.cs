// *************************************************************************************
// FileName: Logger.cs
// Description:
// 
// Version: v1.0.0
// Creator: Jacky(jackylvm@foxmail.com)
// CreationTime: 2023-07-04 15:53:16
// ==============================================================
// History update record:
// 
// ==============================================================
// *************************************************************************************

using MS.Log4Unity;

namespace Common.Logger
{
    public static class Logger
    {
        // private class Nested
        // {
        //     internal static readonly Logger ClassInstance = Activator.CreateInstance(typeof(Logger), true) as Logger;
        //
        //     public static Nested CreateInstance()
        //     {
        //         return new Nested();
        //     }
        // }
        //
        // public static Logger Inst => Nested.ClassInstance;

        public static readonly ULogger UL = LogFactory.GetLogger();
    }
}