﻿using System.Collections.Generic;
using System.Threading;

namespace Sinric
{
    class Program
    {
        // identifies the account
        private static string AppKey = "your app key";

        // for validating messages sent to and from sinric
        private static string SecretKey = "your secret key";

        // for identifying a specific device in the account
        private static string DeviceId = "your device id";
        
        static void Main(string[] args)
        {


            var devices = new List<SinricDevice>();
            devices.Add(new SinricDevice() {DeviceId = DeviceId});

            var client = new SinricClient(AppKey, SecretKey, devices);

            client.Start();

            while (true)
            {
                if (client.IncomingMessages.TryDequeue(out var message))
                {
                    if (message.Payload != null)
                    {
                        var state = message.Payload.GetValue<string>("state");

                        var reply = message.CreateReply(true);
                        reply.Payload.SetValue("state", state.ToUpper() + "ED");

                        client.SendMessage(reply);
                    }

                }
                else
                    Thread.Sleep(100);
            }

            // example runs perpetually
            // client.Stop();
        }
    }
}
