using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using AIO.BackendServer.Constants;
using AIO.BackendServer.Data;
using AIO.BackendServer.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AIO.BackendServer.Services
{
    public class IdentityProfileService : IProfileService
    {
        private readonly IUserClaimsPrincipalFactory<User> _claimsFactory;
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;

        public IdentityProfileService(IUserClaimsPrincipalFactory<User> claimsFactory,
            UserManager<User> userManager,
            ApplicationDbContext context,
           RoleManager<IdentityRole> roleManager)
        {
            _claimsFactory = claimsFactory;
            _userManager = userManager;
            _context = context;
            _roleManager = roleManager;
        }

        //Thực hiện gán thêm claime cho user. trong đó có danh sách quyền(Permissions) mà user này được phép truy cập
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            //GetSubjectId ID user
            var sub = context.Subject.GetSubjectId();
            var user = await _userManager.FindByIdAsync(sub);
            if (user == null)
            {
                throw new ArgumentException("");
            }

            var principal = await _claimsFactory.CreateAsync(user);
            var claims = principal.Claims.ToList();
            var quyenTruyCaps = await _userManager.GetRolesAsync(user);

            var query = from t in _context.TaiKhoanChucNangs
                        join q in _context.QuyenThaoTacs
                        on t.ID_QuyenThaoTac equals q.ID_QuyenThaoTac
                        join c in _context.ChucNangs
                        on t.ID_ChucNang equals c.ID_ChucNang
                        select c.ID_ChucNang + "_" + q.ID_QuyenThaoTac;
            //Lấy danh sách permistion của user
            var permissions = await query.Distinct().ToListAsync();

            //Add more claims like this, gán claims
            claims.Add(new Claim(ClaimTypes.Name, user.UserName));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
            //claims.Add(new Claim(ClaimTypes.Role, string.Join(";", roles)));
            claims.Add(new Claim(SystemConstants.Claims.Permissions, JsonConvert.SerializeObject(permissions)));

            //trả về claims để gán vào cho user
            context.IssuedClaims = claims;
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var sub = context.Subject.GetSubjectId();
            var user = await _userManager.FindByIdAsync(sub);
            context.IsActive = user != null;
        }
    }
}