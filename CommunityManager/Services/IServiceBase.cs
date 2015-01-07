using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityManager.Services
{
    public interface IServiceBase<T>
    {
        List<T> Todos();
    }
}