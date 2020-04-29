﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

using Bondage.Tier.Entities.Classes;

using Microsoft.IdentityModel.Tokens;

namespace Bondage.Tier.Services.Interfaces
{
    public interface ITokenService : IBaseService
    {
        JwtSecurityToken GenerateJwtToken(ApplicationUser @applicationUser);

        string WriteJwtToken(JwtSecurityToken @jwtSecurityToken);

        SymmetricSecurityKey GenerateSymmetricSecurityKey();

        SigningCredentials GenerateSigningCredentials(SymmetricSecurityKey @symmetricSecurityKey);

        DateTime GenerateTokenExpirationDate();

        List<Claim> GenerateJwtClaims(ApplicationUser @applicationUser);
    }
}
