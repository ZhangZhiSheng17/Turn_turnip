using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UI系统
/// </summary>
    public class UIsystem : IUserInterface,IObserver
{
    private Button m_Thatcard = null;
    private Image card = null;
    private Text Theycount = null;
    private bool istime=false;
    private float m_time=0;
    public int count = 0;
    private Notification _notification;
    public UIsystem(Facade facade) : base(facade)
        {
            MessageCenterByObserver.Instance().AddMessage(listNotification(),this);
            Initialize();
        }

        public override void Initialize()
        {
            m_Thatcard = UITool.GetUIComponent<Button>("Thatcard");
            card = UITool.GetUIComponent<Image>("item");
            Theycount = UITool.GetUIComponent<Text>(card.gameObject,"Text");
            card.gameObject.SetActive(false);
            m_Thatcard.onClick.AddListener(() =>
            {
                Startdrawingcards();
            });
        }

        public void Startdrawingcards()
        {
            MessageCenterByObserver.Instance().NotifyObserver(EventOrder.That_card,_notification);
            card.gameObject.SetActive(true);
            istime = true;
        }

        public override void Update()
        {
            if (istime)
            {
                m_time += Time.deltaTime;
                if (m_time>=3)
                {
                    
                    card.gameObject.SetActive(false);
                    istime = false;
                    m_time = 0;
                }
            } 
        }

        public List<string> listNotification()
        {
            List<string> list=new List<string>()
            {
                EventOrder.Figures_forward,
                EventOrder.Turn_turnip
            };
            return list;
        }

        public void HandleNotification(string key, Notification notification)
        {
            if (key=="forward")
            {
                Theycount.text = "前进" + notification.count;
                notification.index = 4;
                MessageCenterByObserver.Instance().NotifyObserver(EventOrder.Player_Forward,notification);
            }
            else
            {
                MessageCenterByObserver.Instance().NotifyObserver(EventOrder.Map_trap,notification);
                Theycount.text = "转萝卜";
            }
        }
}
