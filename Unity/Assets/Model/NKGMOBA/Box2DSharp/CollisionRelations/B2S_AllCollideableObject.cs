//------------------------------------------------------------
// Author: 烟雨迷离半世殇
// Mail: 1778139321@qq.com
// Data: 2019年7月25日 16:16:32
//------------------------------------------------------------

using System;
using Sirenix.OdinInspector;

namespace ETMode
{
    [Flags]
    public enum B2S_AllCollideableObject
    {
        [LabelText("己方小兵")]
        FirendSoldier = 1 << 1,

        [LabelText("敌方小兵")]
        EnemySoldier = 1 << 2,

        [LabelText("小兵")]
        Soldier = FirendSoldier | EnemySoldier,

        [LabelText("自己")]
        Self = 1 << 3,

        [LabelText("队友（英雄）")]
        Teammate = 1 << 4,

        [LabelText("敌人（英雄）")]
        EnemyHeros = 1 << 5,

        [LabelText("英雄")]
        Hero = Self | Teammate | EnemyHeros,

        [LabelText("野怪（中立生物）")]
        Monsters = 1 << 6,

        [LabelText("友方建筑")]
        FriendBuildings = 1 << 7,

        [LabelText("敌方建筑")]
        EnemyBuildings = 1 << 9,

        [LabelText("建筑")]
        Buildings = FriendBuildings | EnemyBuildings,

        [LabelText("地形")]
        Barrier = 1 << 8,

        [LabelText("其他英雄的技能所创造的碰撞体")]
        OtherHeroCreateCollision = 1 << 15,

        //TODO:新增碰撞类型
    }
}