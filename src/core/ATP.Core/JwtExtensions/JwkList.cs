﻿using Microsoft.IdentityModel.Tokens;
using System;

namespace ATP.Core.JwtExtensions
{
    public sealed class JwkList
    {
        public JwkList(JsonWebKeySet jwkTaskResult)
        {
            Jwks = jwkTaskResult;
            When = DateTime.Now;
        }

        public DateTime When { get; set; }
        public JsonWebKeySet Jwks { get; set; }
    }
}