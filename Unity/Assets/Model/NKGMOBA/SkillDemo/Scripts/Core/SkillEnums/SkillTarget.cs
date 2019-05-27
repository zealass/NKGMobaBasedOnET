//------------------------------------------------------------
// Author: 烟雨迷离半世殇
// Mail: 1778139321@qq.com
// Data: 2019年5月15日 17:09:38
//------------------------------------------------------------

using System;
using Sirenix.OdinInspector;

namespace ETModel
{
    [Flags]
    public enum SkillTarget
    {
        /// <summary>
        /// 自己
        /// </summary>
        [LabelText("自己")] Self = 1 << 1,

        /// <summary>
        /// 别人
        /// </summary>
        [LabelText("别人")]  Others = 1 << 2,

        /// <summary>
        /// 自己和别人
        /// </summary>
        [LabelText("自己和别人")] All = Self|Others
    }
}