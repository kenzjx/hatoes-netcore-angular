using System.Text;
using System.Security.Claims;
using Beetsoft_Management_System.Data.Entities;
using Beetsoft_Management_System.Interface;
using Beetsoft_Management_System.Models.GoogleUser;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using static Google.Apis.Auth.GoogleJsonWebSignature;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using Beetsoft_Management_System.Option;

namespace Beetsoft_Management_System.Repository
{
    public class GoogleRepository : IGoogleRepository
    {
        private readonly UserManager<User> userManager;

        private readonly Authentication options;

        public GoogleRepository(UserManager<User> userManager, IOptions<Authentication> options)
        {
            this.options = options.Value;
            this.userManager = userManager;

        }

        public async Task<string> AuthenticateGooleUserAsync(GoogleRequest request)
        {
            Payload payload = await ValidateAsync(request.IdToken, new ValidationSettings
            {
                Audience = new[] { "557580645532-f2om83vuokm89evq4t70b722eq57rvtk.apps.googleusercontent.com" }
            });

            return await GetOrCreateExternalLoginUser(GoogleRequest.PROVIDER, payload.Subject, payload.Email, payload, payload.GivenName, payload.FamilyName, payload.Picture);
        }

        private async Task<string> GetOrCreateExternalLoginUser(string pROVIDER, string subject, string email, Payload payload, string givenName, string familyName, string pictrue)
        {
            var user = await userManager.FindByLoginAsync(pROVIDER, subject);
            if (user != null)
            {
                return await GenerateTokenJwt(user);
            }

            user = await userManager.FindByEmailAsync(email);

            if (user == null)
            {
                user = new User
                {
                    Email = email,
                    UserName = email,
                    FirstName = givenName,
                    LastName = familyName,
                    Id = subject,
                    DepartmentId = 1,
                    LevelId = 1,
                    ImagePath = !string.IsNullOrWhiteSpace(pictrue) ? pictrue : "https://dvdn247.net/cach-xoa-anh-dai-dien-tren-zalo-anh-dai-dien-zalo-dep/"

                };
                await userManager.CreateAsync(user);
            }

            await userManager.AddToRoleAsync(user, "member");

            var info = new UserLoginInfo(pROVIDER, subject, pROVIDER.ToUpperInvariant());

            await userManager.AddLoginAsync(user, info);

            return await GenerateTokenJwt(user);
        }

        private async Task<string> GenerateTokenJwt(User user)
        {
            var role = await userManager.GetRolesAsync(user);

            IdentityOptions _options = new IdentityOptions();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim("Id", user.Id.ToString()),
                    new Claim("Email", user.Email),
                    new Claim("firstName", user.FirstName),
                    new Claim("lastNamt", user.LastName),
                    new Claim(_options.ClaimsIdentity.RoleClaimType, role.FirstOrDefault())
                }),

                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Jwt.Secret)), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var securityToken = tokenHandler.CreateToken(tokenDescriptor);

            var token = tokenHandler.WriteToken(securityToken);

            return token;
        }
    }
}