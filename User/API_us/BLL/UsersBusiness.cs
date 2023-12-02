using BusinessLogicLayer;
using DataAccessLayer;
using DataModel;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Sockets;
using System.Security.Claims;
using System.Text;

namespace BusinessLogicLayer
{
    public class UsersBusiness : IUsersBusiness
    {
        private IUsersRepository _res;
        private string secret;

        public UsersBusiness(IUsersRepository res, IConfiguration configuration)
        {
            _res = res;
            secret = configuration["AppSettings:Secret"];
        }
        /*        public UsersModel GetLoginbyId(string id)
                {
                    return _res.GetLoginbyId(id);
                }

                public bool Update(UsersModel model)
                {
                    return _res.Update(model);
                }*/
        public bool Create(UsersModel model)
        {
            return _res.Create(model);
        }
        public UsersModel Login(string taikhoan, string matkhau)
        {
            var user = _res.Login(taikhoan, matkhau);
            if (user == null)
                return null;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username.ToString()),
                    new Claim(ClaimTypes.Hash, user.Password),
                    new Claim("UserID", user.UserID.ToString(), ClaimValueTypes.Integer), // Chú ý thêm ClaimValueTypes.Integer cho trường int
                    new Claim("Role", user.Role.ToString(), ClaimValueTypes.Boolean)
                    
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.Aes128CbcHmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.token = tokenHandler.WriteToken(token);
            return user;
        }
    }
}