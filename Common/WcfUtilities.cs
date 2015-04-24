using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class WcfUtilities
    {
        private static readonly Dictionary<Type, ChannelFactory> _channels = new Dictionary<Type, ChannelFactory>();
        private static readonly object _lock = new object();

        public static T GetChannel<T>()
        {
            var type = typeof(T);

            if (!_channels.ContainsKey(type))
            {
                lock (_lock)
                {
                    if (!_channels.ContainsKey(type))
                    {
                        _channels.Add(type, new ChannelFactory<T>("*"));
                    }
                }
            }

            return ((ChannelFactory<T>)_channels[type]).CreateChannel();
        }
    }
}
