﻿using System;
using System.Collections.Concurrent;
using AlternateVoice.Server.GTMP.Elements;
using AlternateVoice.Server.GTMP.Exceptions;
using AlternateVoice.Server.GTMP.Interfaces;

namespace AlternateVoice.Server.GTMP
{
    public class GtmpVoiceFactory
    {

        private static ConcurrentDictionary<Type, IGtmpVoiceElement> _dependencies;

        public static T Create<T>() where T : class, IGtmpVoiceElement
        {
            var type = typeof(T);

            if (type == typeof(IVoiceToClientMapper))
            {
                return new VoiceToClientMapper() as T;
            }

            return default(T);
        }

        public static T GetOrCreate<T>() where T : class, IGtmpVoiceElement
        {
            if (_dependencies == null)
            {
                _dependencies = new ConcurrentDictionary<Type, IGtmpVoiceElement>();
            }

            var elemenType = typeof(T);
            IGtmpVoiceElement result;
            
            if (_dependencies.TryGetValue(elemenType, out result))
            {
                return (T) result;
            }

            result = Create<T>();
            if (!_dependencies.TryAdd(elemenType, result))
            {
                throw new GtmpElementCreationException(elemenType);
            }

            return (T) result;
        }
    }
}