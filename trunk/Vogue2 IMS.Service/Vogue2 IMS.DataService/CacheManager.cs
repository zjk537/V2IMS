using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Vogue2_IMS.Service.Business.Model;

namespace Vogue2_IMS.DataService
{
    class CacheManager
    {
        private static object lockObj = new object();
        private static Dictionary<string, User> onlineUsers = new Dictionary<string, User>();

        internal static void OnlineUserAdd(User user)
        {
            lock (lockObj)
            {
                onlineUsers[user.SessionID] = user;
            }            
        }

        internal static void OnlineUserRemove(string sessionId)
        {
            lock (lockObj)
            {
                onlineUsers.Remove(sessionId);
            }
        }

        internal static User GetUser(string sessionId)
        {
            lock (lockObj)
            {
                return onlineUsers.Keys.Contains(sessionId) ? onlineUsers[sessionId] : null;
            }
        }

        internal static void UserTimeOutValidator()
        {
            Task task = new Task(() =>
            {
                while (true)
                {
                    try
                    {
                        lock (lockObj)
                        {
                            List<string> timeOutUserId = new List<string>();
                            DateTime dateNow = DateTime.Now;
                            var timeoutTicks = 1000 * 60 * 60 * 5;

                            foreach (var user in onlineUsers.Values)
                            {
                                if ((dateNow - user.LastRequestTime) > new TimeSpan(timeoutTicks))
                                {
                                    timeOutUserId.Add(user.SessionID);
                                    user.Dispose();
                                }
                            }

                            timeOutUserId.ForEach(sessionId => { onlineUsers.Remove(sessionId); });

                            timeOutUserId.Clear();
                        }
                    }
                    finally
                    {
                        Thread.Sleep(1000 * 60 * 60);
                    }
                }
            });

            task.Start();
        }
    }
}
