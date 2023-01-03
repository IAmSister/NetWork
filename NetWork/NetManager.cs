
using System;
using UnityEngine;
using System.IO;
using SPacket.SocketInstance;
using System.Collections.Generic;
using GCGame.Table;

public class NetManager : MonoBehaviour
{

    public static bool IsReconnecting = false;

    static public NetManager m_netManager;

    private static NetManager m_instance = null;
    public static NetManager Instance()
    {
        return m_instance;
    }

    private bool m_bAskConnecting = false;      // 是否正处于询问断线状态
    void Awake()
    {
        if (m_netManager != null)
        {
            Destroy(this.gameObject);
        }

        m_netManager = this;
        DontDestroyOnLoad(this.gameObject);

        //注册回调
        //  Application.RegisterLogCallback(LogModule.Log);
        //网络回调
        //  NetWorkLogic.SetConnectLostDelegate(ConnectLost);
        m_instance = this;
    }

    void OnEnable()
    {
        m_bAskConnecting = false;
    }

    void Update()
    {
        NetWorkLogic.GetMe().Update();
    }
    /// <summary>
    /// 链接服务器 
    /// </summary>
    /// <param name="_ip"></param>
    /// <param name="_port"></param>
    /// <param name="delConnect"></param>
    public void ConnectToServer(string _ip, int _port, NetWorkLogic.ConnectDelegate delConnect)
    {
        Debug.Log("Connect to Server... ip:" + _ip + " port :" + _port.ToString());
        NetWorkLogic.SetConcnectDelegate(delConnect);
        NetWorkLogic.GetMe().ConnectToServer(_ip, _port, 100); //链接
    }


    public static void SendUserLogin(LoginData.LoginRet retFun, bool bForce, bool bReconnect = false)
    {
        if (!LoginData.accountData.m_bInit)
        {
            Debug.LogError("account data is not init");
            return;
        }
        //帐户和密码
        LoginData.retLogin = retFun;

        //pb登录 账号密码  进行判断
        
      
    }
    /// <summary>
    /// 选人
    /// </summary>
    /// <param name="roleGUID"></param>
    /// <param name="funRet"></param>

    public static void SendChooseRole(ulong roleGUID, GC_SELECTROLE_RETHandler.SelectRoleFailRet funRet)
    {

        /// 选择人后pb SendPacket
      
    }
    /// <summary>
    /// 退出游戏
    /// </summary>
    public static void SendUserLogout()
    {
        /// 退出游戏pb SendPacket
    }
    /// <summary>
    /// 重连
    /// </summary>
    public void ConnectLost()
    {

      
    }

    public static void OnWaitPacketTimeOut()
    {
       // MessageBoxLogic.OpenOKBox(1292, 1000, OnReturnServerChoose);
    }
    /// <summary>
    /// 重选服务器
    /// </summary>
    private static void OnReturnServerChoose()
    {
        //网络断开
        NetWorkLogic.GetMe().DisconnectServer();
        //服务器选择
        //LoginUILogic.Instance().EnterServerChoose();
    }

    public void OnReconnect()
    {

        m_bAskConnecting = false;
        NetWorkLogic.SetConcnectDelegate(Ret_Reconnect);
        NetWorkLogic.GetMe().ReConnectToServer();
    }
    void Ret_Reconnect(bool bSuccess, string strResult)
    {
        if (bSuccess)
        {
            // 重新登录
            Debug.Log("relogining....");
           // NetManager.SendUserLogin(Ret_Login, true, true);
            //NetManager.SendUserLogin(PlayerPreferenceData.LastAccount, PlayerPreferenceData.LastPsw, Ret_Login);
        }
        else
        {
            // 重连失败，点击确定重新登录
           // MessageBoxLogic.OpenOKBox(1295, 1000, EnterLoginScene);

        }
    }
    /// <summary>
    /// 重新登录
    /// </summary>
    /// <param name="result">登录结果</param>
    /// <param name="validateResult"></param>
    void Ret_Login()//GC_LOGIN_RET.LOGINRESULT result, int validateResult
    {
    }
    /// <summary>
    /// 选择角色
    /// </summary>
    void OnChooseRole()
    {
        // 正在等待进入场景
      //  MessageBoxLogic.OpenWaitBox(2352, GameDefines.CONNECT_TIMEOUT, 0, OnWaitPacketTimeOut);
        
        //NetManager.SendChooseRole(PlayerPreferenceData.LastRoleGUID, RetSelectRoleFail);
    }
    /// <summary>
    /// 进入等路场景
    /// </summary>
    void EnterLoginScene()
    {
       // LoadingWindow.LoadScene(Games.GlobeDefine.GameDefine_Globe.SCENE_DEFINE.SCENE_LOGIN);
    }

    void EnterOffline()
    {
       // GameManager.gameManager.OnLineState = false;
    }

    void RetSelectRoleFail()//GC_SELECTROLE_RET.SELECTROLE_RESULT result
    {
        // 重新连接获取角色失败，点击确定重新登录
       // MessageBoxLogic.OpenOKBox(1294, 1000, OnSelectRoleFail);
    }

    void OnSelectRoleFail()
    {
        
      
    }
}
