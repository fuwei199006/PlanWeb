using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using Newtonsoft.Json;

namespace Framework.Contract
{
    [Serializable]
    public class WcfContext : Dictionary<string, object>
    {
        private const string CallContextKey = "__CallContext";
        private const string ContextHeaderLocalName = "__CallContext";
        private const string ContextHeaderNameSpace = "plain";

        private void EnsureSerializable(object value)
        {
            if (value == null)
            {
                throw new ArgumentException("value");
            }
            if (!value.GetType().IsSerializable)
            {
                throw new ArgumentException(string.Format("The argument of the type \"{0}\" is not serializable!",
                    value.GetType().FullName));
            }
        }

        public new object this[string key]
        {
            get { return base[key]; }
            set
            {
                this.EnsureSerializable(value);
                base[key] = value;
            }
        }

        public Operater Operater
        {
            get { return JsonConvert.DeserializeObject<Operater>(this["__Operater"].ToString()); }
            set { this["__Operater"] = JsonConvert.SerializeObject(value); }
        }

        public static WcfContext Current
        {
            get
            {
                if (CallContext.GetData(CallContextKey) == null)
                {
                    CallContext.SetData(CallContextKey,new WcfContext());
                }
                return CallContext.GetData(CallContextKey) as WcfContext;
            }
            set
            {
                CallContext.SetData(CallContextKey, value);
            }
        }
    
}
}