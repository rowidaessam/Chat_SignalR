using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using signalrchatDay1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace signalrchatDay1
{
    [HubName("chat")]
    public class ChatHub : Hub
    {
        chatContext db = new chatContext();
      public void sendmessage(string name ,string mes)
        {
            Clients.All.newmessage(name, mes);

            //save db
            message m = new message() { name = name, message1 = mes, date = DateTime.Now };
            db.messages.Add(m);
            db.SaveChanges();

        }


        public void joingroup(string group ,string name)
        {
            Groups.Add(Context.ConnectionId, group);
            Clients.OthersInGroup(group).newmebemer(name, group);
        }


        public void sendtogroup(string group ,string name ,string message)
        {
            Clients.Group(group).messagegroup(group, name, message);
        }



        public override Task OnConnected()
        {

    //   string id=     Context.ConnectionId;

            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            return base.OnDisconnected(stopCalled);
        }



    }
}