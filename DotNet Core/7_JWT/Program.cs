using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

//加密
string Encrypt() {
    var claims = new List<Claim> {
        new("Passport", "123456"),
        new(ClaimTypes.NameIdentifier, "111"),
        new(ClaimTypes.Name, "tom"),
        new(ClaimTypes.HomePhone, "999"),
        new(ClaimTypes.Role, "admin"),
        new(ClaimTypes.Role, "manager")
    };
    var key = "a$^csdcverfererfddwe#$@*(&Bccbvdvscsersdcvvd&^c3892";
    var expire = DateTime.Now.AddHours(1);

    var secBytes = Encoding.UTF8.GetBytes(key);
    var secKey = new SymmetricSecurityKey(secBytes);
    var credentials = new SigningCredentials(secKey,
        SecurityAlgorithms.HmacSha384Signature);
    var tokenDescriptor = new JwtSecurityToken(claims: claims,
        expires: expire, signingCredentials: credentials);
    var jwt = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

    return jwt;
}

//解密
string Decrypt(string s) {
    s = s.Replace('-', '+').Replace('_', '/');
    switch (s.Length % 4) {
        case 2:
            s += "==";
            break;
        case 3:
            s += "=";
            break;
    }
    var bytes = Convert.FromBase64String(s);
    return Encoding.UTF8.GetString(bytes);
}

var lockJwt = Encrypt();
var unLockJwt = Decrypt(lockJwt);
Console.WriteLine(lockJwt);
Console.WriteLine(unLockJwt);