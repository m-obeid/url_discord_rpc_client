using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using DiscordRpcDemo;
using System.Web;
using System.Windows.Forms;
using System.Diagnostics;

namespace Discord
{
    class Program
    {
        static void Main(string[] args)
        {
            // super mayo party
            // xd

            Program mayonaise = new Program();
            mayonaise.Mayonaise(args);
        }
        //--------------------------------------
        //-       start actual code            -
        //--------------------------------------

        // import discord shit
        private DiscordRpc.EventHandlers handlers;
        private DiscordRpc.RichPresence presence;
        public void Mayonaise(string[] args)
        {
            if (args.Length == 1)
            {
                if (args[0] == "discordrpc://stop")
                {
                    // bro stop its not funny
                    Process self = Process.GetCurrentProcess();
                    foreach (Process proc in Process.GetProcessesByName("discordrpc").Where(proc => proc.Id != self.Id))
                    {
                        proc.Kill();
                    }
                }
                else
                {
                    // Step 0: Nobody shoud distrub me D:
                    Process self = Process.GetCurrentProcess();
                    foreach (Process proc in Process.GetProcessesByName("discordrpc").Where(proc => proc.Id != self.Id))
                    {
                        proc.Kill();
                        // they ded
                    }

                    // Step 1: Parse URL into pieces
                    // First, turn String into URI
                    var myUri = new Uri(args[0]);

                    // then extract all in variables

                    var clientId = HttpUtility.ParseQueryString(myUri.Query).Get("clientId");
                    var details = HttpUtility.ParseQueryString(myUri.Query).Get("details");
                    var state = HttpUtility.ParseQueryString(myUri.Query).Get("state");
                    var largeImageKey = HttpUtility.ParseQueryString(myUri.Query).Get("largeImageKey");
                    var largeImageText = HttpUtility.ParseQueryString(myUri.Query).Get("largeImageText");
                    var smallImageKey = HttpUtility.ParseQueryString(myUri.Query).Get("smallImageKey");
                    var smallImageText = HttpUtility.ParseQueryString(myUri.Query).Get("smallImageText");

                    // Step 2: Apply!

                    this.handlers = default(DiscordRpc.EventHandlers);
                    DiscordRpc.Initialize(clientId, ref this.handlers, true, null);
                    this.handlers = default(DiscordRpc.EventHandlers);
                    DiscordRpc.Initialize(clientId, ref this.handlers, true, null);
                    this.presence.details = details;
                    this.presence.state = state;
                    this.presence.largeImageKey = largeImageKey;
                    this.presence.largeImageText = largeImageText;
                    this.presence.smallImageText = smallImageText;
                    this.presence.smallImageKey = smallImageKey;
                    DiscordRpc.UpdatePresence(ref this.presence);
                    while (true)
                    {
                        Console.Read();
                    }
                }
            }
        }
    }
}
