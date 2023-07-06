// *************************************************************************************
// FileName: IL.cs
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
    public static class IL
    {
        // private class Nested
        // {
        //     internal static readonly IL ClassInstance = Activator.CreateInstance(typeof(IL), true) as IL;
        //
        //     public static Nested CreateInstance()
        //     {
        //         return new Nested();
        //     }
        // }
        //
        // public static IL Inst => Nested.ClassInstance;

        public static readonly ULogger UL = LogFactory.GetLogger();
    }
}