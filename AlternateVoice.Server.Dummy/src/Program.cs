﻿using System;
using AlternateVoice.Server.Wrapper.Exceptions;
using NLog;

namespace AlternateVoice.Server.Dummy
{
    public class Program
    {

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private static ServerHandler _serverHandler;
        
        
        public static void Main(string[] arguments)
        {
            Logger.Info(new string('=', Console.WindowWidth / 2));
            Logger.Info("AlternateVoice DummyServer");
            Logger.Info(new string('=', Console.WindowWidth / 2));
            Logger.Info("Available Commands:");
            Logger.Info("start - Start a new AlternateVoice Server");
            Logger.Info("exit - Stop the AlternateVoice Server");
            Logger.Info("dispose - Dispose the AlternateVoice Server");
            

            while (true)
            {
                ProcessInputLine(Console.ReadLine());
            }
        }

        private static void ProcessInputLine(string input)
        {
            switch (input)
            {
                case "start":
                {
                    if (_serverHandler == null)
                    {
                        _serverHandler = new ServerHandler("localhost", 23332, 20);
                    }
                    
                    Logger.Info("Starting AlternateVoice DummyServer...");

                    try
                    {
                        _serverHandler.StartServer();
                    }
                    catch (VoiceServerAlreadyStartedException)
                    {
                        Logger.Info("Server is already started!");
                        return;
                    }
            
                    Logger.Info("AlternateVoice DummyServer started!");
                    break;
                }
                case "stop":
                {
                    try
                    {
                        _serverHandler.StopServer();
                    }
                    catch (VoiceServerNotStartedException)
                    {
                        Logger.Info("Server has not been started");                        
                    }
                    break;
                }
                case "dispose":
                {
                    _serverHandler.Dispose();
                    _serverHandler = null;
                    
                    Logger.Info("Server has been disposed");      
                    break;
                }
            }
        }
    }
}
