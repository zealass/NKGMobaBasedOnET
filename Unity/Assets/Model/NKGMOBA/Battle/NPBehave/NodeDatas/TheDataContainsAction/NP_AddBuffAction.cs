//------------------------------------------------------------
// Author: 烟雨迷离半世殇
// Mail: 1778139321@qq.com
// Data: 2020年1月19日 11:06:39
//------------------------------------------------------------

using System;
using Sirenix.OdinInspector;

namespace ETModel
{
    [Title("添加一个Buff",TitleAlignment = TitleAlignments.Centered)]
    public class NP_AddBuffAction: NP_ClassForStoreAction
    {
        [LabelText("要执行的Buff数据ID")]
        public VTD_Id BuffDataID;

        public override Action GetActionToBeDone()
        {
            this.Action = this.AddBuff;
            return this.Action;
        }

        public void AddBuff()
        {
            //Log.Info("行为树添加Buff");
            Unit unit = Game.Scene.GetComponent<UnitComponent>().Get(this.Unitid);
            Game.Scene.GetComponent<BuffPoolComponent>().AcquireBuff((unit.GetComponent<NP_RuntimeTreeManager>()
                    .GetTreeByRuntimeID(this.RuntimeTreeID)
                    .BelongNP_DataSupportor
                    .SkillDataDic[this.BuffDataID.Value] as NodeDataForSkillBuff).BuffData, unit, unit);
            //Log.Info("Buff添加完成");
        }
    }
}