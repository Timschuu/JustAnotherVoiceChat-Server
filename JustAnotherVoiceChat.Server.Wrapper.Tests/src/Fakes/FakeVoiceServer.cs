﻿using JustAnotherVoiceChat.Server.Wrapper.Elements.Server;
using JustAnotherVoiceChat.Server.Wrapper.Interfaces;

namespace JustAnotherVoiceChat.Server.Wrapper.Tests.Fakes
{
    public class FakeVoiceServer : VoiceServer<FakeVoiceClient, byte>
    {
        protected internal FakeVoiceServer(IVoiceClientFactory<FakeVoiceClient, byte> factory, IVoiceWrapper voiceWrapper, IVoiceWrapper3D voiceWrapper3D, string hostname, ushort port, int channelId, float globalRollOffScale = 1, float globalDistanceFactor = 1, double globalMaxDistance = 6) : base(factory, voiceWrapper, voiceWrapper3D, hostname, port, channelId, globalRollOffScale, globalDistanceFactor, globalMaxDistance)
        {
            
        }
        
    }
}
