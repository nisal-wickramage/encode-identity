﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Controllers
{
    public class LoginViewModel
    {
        public string Username { get; set; }

        public string  Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
