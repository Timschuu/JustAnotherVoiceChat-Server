﻿#region copyright 
/*
 * File: VoiceServer.Wrapper.cs
 * Date: 29.29.2018,
 *
 * MIT License
 *
 * Copyright (c) 2018 AlternateVoice
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */
#endregion
using System.Runtime.InteropServices;

namespace AlternateVoice.Server.Wrapper.Elements.Server
{
    internal partial class VoiceServer
    {

#if LINUX
        private const string AlternateVoiceLib = "AlternateVoice.so";
#else
        private const string AlternateVoiceLib = "AlternateVoice.dll";
#endif

        private delegate void ClientCallback(ushort handle);

        [DllImport(AlternateVoiceLib)]
        private static extern void AL_StartServer(string hostname, ushort port, int channelId);
        
        [DllImport(AlternateVoiceLib)]
        private static extern void AL_StopServer();
        
        [DllImport(AlternateVoiceLib)]
        [return:MarshalAs(UnmanagedType.I1)]
        private static extern bool AL_IsServerRunning();
        
        [DllImport(AlternateVoiceLib)]
        private static extern int AL_GetNumberOfClients();
        
        [DllImport(AlternateVoiceLib)]
        private static extern unsafe void AL_GetClientIds(ushort* list, int maxlength);
        
        [DllImport(AlternateVoiceLib)]
        private static extern void AL_RemoveClient(ushort handle);
        
        [DllImport(AlternateVoiceLib)]
        private static extern void AL_MuteClientFor(ushort listenerId, ushort clientId, bool muted);
        
        [DllImport(AlternateVoiceLib)]
        private static extern void AL_RegisterNewClientCallback([MarshalAs(UnmanagedType.FunctionPtr)] ClientCallback callback);
        
        [DllImport(AlternateVoiceLib)]
        private static extern void AL_UnregisterNewClientCallback();
        
        [DllImport(AlternateVoiceLib)]
        private static extern void ALTest_CallNewClientCallback();

    }
}