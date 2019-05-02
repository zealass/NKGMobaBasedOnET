/** This is an automatically generated class by FairyGUI plugin FGUI2ET. Please do not modify it. **/

using System.Threading.Tasks;
using FairyGUI;
using ETModel;
using ETHotfix;

namespace ETHotfix.FUILobby
{
    [ObjectSystem]
    public class ActityHeadAwakeSystem : AwakeSystem<ActityHead, GObject>
    {
        public override void Awake(ActityHead self, GObject go)
        {
            self.Awake(go);
        }
    }
	
	public sealed class ActityHead : FUI
	{	
		public const string UIPackageName = "FUILobby";
		public const string UIResName = "ActityHead";
		
		/// <summary>
        /// ActityHead的组件类型(GComponent、GButton、GProcessBar等)，它们都是GObject的子类。
        /// </summary>
		public GButton self;
		
		public Controller button;
		public GImage n0;

		private static GObject CreateGObject()
        {
            return UIPackage.CreateObject(UIPackageName, UIResName);
        }
		
		private static void CreateGObjectAsync(UIPackage.CreateObjectCallback result)
        {
            UIPackage.CreateObjectAsync(UIPackageName, UIResName, result);
        }

        public static ActityHead CreateInstance()
		{			
			return ComponentFactory.Create<ActityHead, GObject>(CreateGObject());
		}

        public static Task<ActityHead> CreateInstanceAsync()
        {
            TaskCompletionSource<ActityHead> tcs = new TaskCompletionSource<ActityHead>();

            CreateGObjectAsync((go) =>
            {
                tcs.SetResult(ComponentFactory.Create<ActityHead, GObject>(go));
            });

            return tcs.Task;
        }

        public static ActityHead Create(GObject go)
		{
			return ComponentFactory.Create<ActityHead, GObject>(go);
		}
		
        /// <summary>
        /// 通过此方法获取的FUI，在Dispose时不会释放GObject，需要自行管理（一般在配合FGUI的Pool机制时使用）。
        /// </summary>
        public static ActityHead GetFormPool(GObject go)
        {
            var fui = go.Get<ActityHead>();

            if(fui == null)
            {
                fui = Create(go);
            }

            fui.isFromFGUIPool = true;

            return fui;
        }
						
		public void Awake(GObject go)
		{
			if(go == null)
			{
				return;
			}
			
			GObject = go;	
			
			if (string.IsNullOrWhiteSpace(Name))
            {
				Name = Id.ToString();
            }
			
			self = (GButton)go;
			
			self.Add(this);
			
			var com = go.asCom;
				
			if(com != null)
			{	
				button = com.GetController("button");
				n0 = (GImage)com.GetChild("n0");
			}
		}
		
		public override void Dispose()
		{
			if(IsDisposed)
			{
				return;
			}
			
			base.Dispose();
			
			self.Remove();
			self = null;
			button = null;
			n0 = null;
		}
	}
}