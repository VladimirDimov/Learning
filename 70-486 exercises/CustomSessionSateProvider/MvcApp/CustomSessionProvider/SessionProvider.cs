namespace MvcApp.CustomSessionProvider
{
    using System;
    using System.Web;
    using System.Web.SessionState;

    public class SessionProvider : SessionStateStoreProviderBase
    {
        public override SessionStateStoreData CreateNewStoreData(HttpContext context, int timeout)
        {
            var itemsCollection = new SessionStateItemCollection();
            itemsCollection["secret1"] = 42;
            var storeData = new SessionStateStoreData(itemsCollection, null, timeout);

            return storeData;
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

            return null;
        }

        public override SessionStateStoreData GetItemExclusive(HttpContext context, string id, out bool locked, out TimeSpan lockAge, out object lockId, out SessionStateActions actions)
        {
            locked = false;
            lockAge = new TimeSpan();
            lockId = false;
            actions = SessionStateActions.None;

            return null;
        }

        public override void InitializeRequest(HttpContext context)
        {
            
        }

        public override void ReleaseItemExclusive(HttpContext context, string id, object lockId)
        {
            throw new NotImplementedException();
        }

        public override void RemoveItem(HttpContext context, string id, object lockId, SessionStateStoreData item)
        {
            throw new NotImplementedException();
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