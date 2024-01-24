using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodeClass;


namespace NodeInserts.Models
{
    public class ReceiverList
    {
        private Node<ShabatRecievers> lst;
        private Node<ShabatRecievers> tail;

        public ReceiverList()
        {
            lst = null;
            tail = null;
        }

        public void AddReciever(ShabatRecievers reciever)
        {
            if (lst == null)
            {
                lst=new Node<ShabatRecievers>(reciever);
                tail = lst;
            }
            else
            {
                tail.SetNext(new Node<ShabatRecievers>(reciever));
                tail = tail.GetNext();
            }

        }
        public void DeleteReciever(string name)
        {
            //למצוא
            Node<ShabatRecievers> prv;//הקודם
            Node<ShabatRecievers> next;//החוליה לניתוק
            if (lst == null)
                return;
            if(lst.GetValue().GetParent2()==name|| lst.GetValue().GetParent1()==name)
            {
                if(tail==lst)
                    tail=tail.GetNext();
                lst=lst.GetNext();
            }
            else
            {
                prv = lst;
                next = prv.GetNext();
                ShabatRecievers r = next.GetValue();
                while(next!=null&&r.GetParent1()!=name&&r.GetParent2()!=name)
                {
                    prv = next;
                    next = next.GetNext();
                    r=next.GetValue();
                }
                if(next!=null)
                {
                    prv.SetNext(next.GetNext());//ניתוק משמאל
                    next.SetNext(null);//ניתוק מימין
                }

            }


        }

    }
}
