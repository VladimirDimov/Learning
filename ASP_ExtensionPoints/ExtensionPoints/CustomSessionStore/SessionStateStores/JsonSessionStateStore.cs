using System;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Web;
using System.Web.SessionState;

namespace CustomSessionStore.SessionStateStores
{
    public class JsonSessionStateStore : SessionStateStoreProviderBase
    {
        private SessionStateStoreData sessionSateStoreData;
        private SessionStateStoreProviderBase _store;

        public override void Initialize(string name, NameValueCollection config)
        {
            base.Initialize(name, config);

            var storeType = typeof(SessionStateStoreProviderBase).Assembly.GetType("System.Web.SessionState.InProcSessionStateStore");
            _store = (SessionStateStoreProviderBase)Activator.CreateInstance(storeType);
            _store.Initialize(name, config);
        }

        public override SessionStateStoreData CreateNewStoreData(HttpContext context, int timeout)
        {
            return null;
        }

        public override void CreateUninitializedItem(HttpContext context, string id, int timeout)
        {
        }

        public override void Dispose()
        {
        }

        public override void EndRequest(HttpContext context)
        {
        }

        public override SessionStateStoreData GetItem(HttpContext context, string id, out bool locked, out TimeSpan lockAge, out object lockId, out SessionStateActions actions)
        {
            locked = false;
            lockAge = new TimeSpan();
            lockId = false;
            actions = SessionStateActions.None;

            return this.sessionSateStoreData;
        }

        public override SessionStateStoreData GetItemExclusive(HttpContext context, string id, out bool locked, out TimeSpan lockAge, out object lockId, out SessionStateActions actions)
        {
            locked = false;
            lockAge = new TimeSpan();
            lockId = false;
            actions = SessionStateActions.None;

            return this.sessionSateStoreData;
        }

        public override void InitializeRequest(HttpContext context)
        {
            this.sessionSateStoreData = new SessionStateStoreData(new CustomSessionSateItemCollection(), new HttpStaticObjectsCollection(), 1000);
        }

        public override void ReleaseItemExclusive(HttpContext context, string id, object lockId)
        {

        }

        public override void RemoveItem(HttpContext context, string id, object lockId, SessionStateStoreData item)
        {
        }

        public override void ResetItemTimeout(HttpContext context, string id)
        {
        }

        public override void SetAndReleaseItemExclusive(HttpContext context, string id, SessionStateStoreData item, object lockId, bool newItem)
        {
        }

        public override bool SetItemExpireCallback(SessionStateItemExpireCallback expireCallback)
        {
            throw new NotImplementedException();
        }
    }
}