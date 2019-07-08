using System;
using System.Collections.Generic;
using System.Text;

namespace Recipe.CreatorApiKey.Abstract
{
    public interface IApiKeyCreator
    {
        string GetApiKey();
        string GetApiKey(int length);
    }
}
