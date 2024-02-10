using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalGems.Services;
    
public class AuthService
{
    public async Task<bool> IsAuth()
    {
        await Task.Delay(1000);
        return false;
    }
}

