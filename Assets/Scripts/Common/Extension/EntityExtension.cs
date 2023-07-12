// *************************************************************************************
// FileName: EntityExtension.cs
// Description:
// 
// Version: v1.0.0
// Creator: Jacky(jackylvm@foxmail.com)
// CreationTime: 2023-07-12 23:23
// Copyright: 2021 - 2023 咔丘互娱（上海）网络科技有限公司
// ==============================================================
// History update record:
// 
// ==============================================================
// *************************************************************************************

using UnityEngine;

namespace Common.Extension
{
    public static partial class EntityExtension
    {
        /// <summary>
        /// adjusts x and y so that the length of the vector does not exceed max
        /// 调整x和y，使向量的长度不超过max
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public static Vector3 Truncate(this Vector3 lhs, float val)
        {
            if (lhs.magnitude > val)
            {
                lhs.Normalize();
                lhs *= val;
            }

            return lhs;
        }

        /// <summary>
        /// Returns a vector perpendicular to this vector
        /// 返回垂直于此向量的向量,二维操作,z无效
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public static Vector3 Perp(this Vector3 lhs)
        {
            return new Vector3(-lhs.y, lhs.x, lhs.z);
        }
    }
}