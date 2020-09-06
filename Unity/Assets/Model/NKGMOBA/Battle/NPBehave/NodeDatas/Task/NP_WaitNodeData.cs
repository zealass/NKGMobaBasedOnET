//------------------------------------------------------------
// Author: 烟雨迷离半世殇
// Mail: 1778139321@qq.com
// Data: 2019年8月21日 7:13:45
//------------------------------------------------------------

using System.Collections.Generic;
using NPBehave;
using Sirenix.OdinInspector;

namespace ETModel
{
    [BoxGroup("等待结点数据")]
    [HideLabel]
    public class NP_WaitNodeData : NP_NodeDataBase
    {
        [HideInEditorMode] public Wait mWaitNode;
        
        public NP_BlackBoardRelationData NPBalckBoardRelationData = new NP_BlackBoardRelationData();
        
        public override Task CreateTask(long UnitId, long RuntimeTreeID)
        {
            mWaitNode = new Wait(this.NPBalckBoardRelationData.BBKey);
            return mWaitNode;
        }

        public override Node NP_GetNode()
        {
            return this.mWaitNode;
        }
    }
}