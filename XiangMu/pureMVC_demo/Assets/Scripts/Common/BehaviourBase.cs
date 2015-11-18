using UnityEngine;
using System.Collections;
using PureMVC.Interfaces;

namespace SimpleFramework
{
    public class BehaviourBase : MonoBehaviour
    {
        private AppFacade m_Facade;
        private LuaScriptMgr m_LuaMgr;
        private ResourManager m_ResMgr;
        private NetWorkManager m_NetMgr;
        private MusicManager m_MusicMgr;
        private TimerManager m_TimerMgr;
        private ThreadManager m_ThreadMgr;

        protected AppFacade facade
        {
            get
            {
                if (m_Facade == null)
                    m_Facade = AppFacade.Instance;
                return m_Facade;
            }
        }
        protected LuaScriptMgr LuaManager
        {
            get
            {
                if (m_LuaMgr == null)
                    m_LuaMgr = facade.GetManager<LuaScriptMgr>(ManagerName.Lua);
                return m_LuaMgr;
            }
            set
            {
                m_LuaMgr = value;
            }
        }
        protected ResourManager ResManager
        {
            get
            {
                if (m_ResMgr == null)
                    m_ResMgr = facade.GetManager<ResourManager>(ManagerName.Resource);
                return m_ResMgr;
            }
        }
        protected NetWorkManager NetManager
        {
            get
            {
                if (m_NetMgr == null)
                    m_NetMgr = facade.GetManager<NetWorkManager>(ManagerName.NetWork);
                return m_NetMgr;
            }
        }
        protected MusicManager MusicManager
        {
            get
            {
                if (m_MusicMgr == null)
                    m_MusicMgr = facade.GetManager<MusicManager>(ManagerName.Music);
                return m_MusicMgr;
            }
        }
        protected TimerManager TimerManager
        {
            get
            {
                if (m_TimerMgr == null)
                    m_TimerMgr = facade.GetManager<TimerManager>(ManagerName.Timer);
                return m_TimerMgr;
            }
        }
        protected ThreadManager ThreadManager
        {
            get
            {
                if (m_ThreadMgr == null)
                    m_ThreadMgr = facade.GetManager<ThreadManager>(ManagerName.Thread);
                return m_ThreadMgr;
            }
        }
    }
}
