
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

    private bool m_bAskConnecting = false;      // �Ƿ�������ѯ�ʶ���״̬
    void Awake()
    {
        if (m_netManager != null)
        {
            Destroy(this.gameObject);
        }

        m_netManager = this;
        DontDestroyOnLoad(this.gameObject);

        //ע��ص�
        //  Application.RegisterLogCallback(LogModule.Log);
        //����ص�
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
    /// ���ӷ����� 
    /// </summary>
    /// <param name="_ip"></param>
    /// <param name="_port"></param>
    /// <param name="delConnect"></param>
    public void ConnectToServer(string _ip, int _port, NetWorkLogic.ConnectDelegate delConnect)
    {
        Debug.Log("Connect to Server... ip:" + _ip + " port :" + _port.ToString());
        NetWorkLogic.SetConcnectDelegate(delConnect);
        NetWorkLogic.GetMe().ConnectToServer(_ip, _port, 100); //����
    }


    public static void SendUserLogin(LoginData.LoginRet retFun, bool bForce, bool bReconnect = false)
    {
        if (!LoginData.accountData.m_bInit)
        {
            Debug.LogError("account data is not init");
            return;
        }
        //�ʻ�������
        LoginData.retLogin = retFun;

        //pb��¼ �˺�����  �����ж�
        
      
    }
    /// <summary>
    /// ѡ��
    /// </summary>
    /// <param name="roleGUID"></param>
    /// <param name="funRet"></param>

    public static void SendChooseRole(ulong roleGUID, GC_SELECTROLE_RETHandler.SelectRoleFailRet funRet)
    {

        /// ѡ���˺�pb SendPacket
      
    }
    /// <summary>
    /// �˳���Ϸ
    /// </summary>
    public static void SendUserLogout()
    {
        /// �˳���Ϸpb SendPacket
    }
    /// <summary>
    /// ����
    /// </summary>
    public void ConnectLost()
    {

      
    }

    public static void OnWaitPacketTimeOut()
    {
       // MessageBoxLogic.OpenOKBox(1292, 1000, OnReturnServerChoose);
    }
    /// <summary>
    /// ��ѡ������
    /// </summary>
    private static void OnReturnServerChoose()
    {
        //����Ͽ�
        NetWorkLogic.GetMe().DisconnectServer();
        //������ѡ��
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
            // ���µ�¼
            Debug.Log("relogining....");
           // NetManager.SendUserLogin(Ret_Login, true, true);
            //NetManager.SendUserLogin(PlayerPreferenceData.LastAccount, PlayerPreferenceData.LastPsw, Ret_Login);
        }
        else
        {
            // ����ʧ�ܣ����ȷ�����µ�¼
           // MessageBoxLogic.OpenOKBox(1295, 1000, EnterLoginScene);

        }
    }
    /// <summary>
    /// ���µ�¼
    /// </summary>
    /// <param name="result">��¼���</param>
    /// <param name="validateResult"></param>
    void Ret_Login()//GC_LOGIN_RET.LOGINRESULT result, int validateResult
    {
    }
    /// <summary>
    /// ѡ���ɫ
    /// </summary>
    void OnChooseRole()
    {
        // ���ڵȴ����볡��
      //  MessageBoxLogic.OpenWaitBox(2352, GameDefines.CONNECT_TIMEOUT, 0, OnWaitPacketTimeOut);
        
        //NetManager.SendChooseRole(PlayerPreferenceData.LastRoleGUID, RetSelectRoleFail);
    }
    /// <summary>
    /// �����·����
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
        // �������ӻ�ȡ��ɫʧ�ܣ����ȷ�����µ�¼
       // MessageBoxLogic.OpenOKBox(1294, 1000, OnSelectRoleFail);
    }

    void OnSelectRoleFail()
    {
        
      
    }
}
