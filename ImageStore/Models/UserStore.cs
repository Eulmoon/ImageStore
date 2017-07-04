using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ImageStore.Models
{
    public class UserStore
    {
        public const string UserSessionKey = "UserId";
        string UserStoreId { get; set; }
        public static UserStore GetCart(HttpContext context)
        {
            var User = new UserStore();
            User.UserStoreId = User.GetCartId(context);
            return User;
        }

        public string GetCartId(HttpContext context)
        {
            if (context.Session.GetString(UserSessionKey) == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session.SetString(UserSessionKey, context.User.Identity.Name); 
                }
                else
                {
                    Guid tempCartId = Guid.NewGuid();
                    context.Session.SetString(UserSessionKey, tempCartId.ToString());
                }
            }
            return context.Session.GetString(UserSessionKey);
        }
    }
}
