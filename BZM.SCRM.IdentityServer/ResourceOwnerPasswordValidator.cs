using IdentityServer4.Models;
using IdentityServer4.Validation;
using SCRM.Application.System.Contracts;
using SCRM.Application.System.Dtos;
using SCRM.Domain.System.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BZM.SCRM.IdentityServer
{
    public class ResourceOwnerPasswordValidator: IResourceOwnerPasswordValidator
    {
        private readonly ISysUsrMstrService _sysUsrMstrService;
        private readonly ISysRoleMstrRepository _sysRoleMstrRepository;
        public ResourceOwnerPasswordValidator(ISysUsrMstrService sysUsrMstrService,
            ISysRoleMstrRepository sysRoleMstrRepository)
        {
            _sysUsrMstrService = sysUsrMstrService;
            _sysRoleMstrRepository = sysRoleMstrRepository;
        }


        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            SysUsrMstrDto dto = null;
            var scope = "";
            var bizType= context.Request.Raw["bizType"];
            var orgNo = context.Request.Raw["orgNo"];
            var bgNo= context.Request.Raw["bgNo"];
            if (string.IsNullOrEmpty(bizType) || string.IsNullOrEmpty(orgNo) || string.IsNullOrEmpty(bgNo))
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "invalid user credential");
            }
            else
            {
                dto = await _sysUsrMstrService.Login(context.UserName, context.Password, orgNo, bgNo, bizType);
                if (dto != null)
                {
                    var result = await _sysRoleMstrRepository.GetUserRoleScope(dto.Id);
                    if (result.Count != 0) scope = result[0];

                    context.Result = new GrantValidationResult(
                        subject: context.UserName,
                        authenticationMethod: "user",
                        claims: GetUserCliams(dto,scope)
                        );
                }
                else
                {
                    context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "invalid user credential");
                }
            }
            
        }
        private Claim[] GetUserCliams(SysUsrMstrDto dto,string scope)
        {
            return new Claim[]
                {
                   new Claim("USR_ID",dto.Id.ToString()),
                   new Claim("USR_NAME",dto.USR_NAME??""),
                   new Claim("ORG_NO",dto.ORG_NO??""),
                   new Claim("USR_REAL_NAME",dto.USR_REAL_NAME??""),
                   new Claim("USR_MOBILE",dto.USR_MOBILE??""),
                   new Claim("USR_AVATAR_PATH",dto.USR_AVATAR_PATH??""),
                   new Claim("ERP_EMP_ID",dto.ERP_EMP_ID??""),
                   new Claim("USR_TYPE",dto.USR_TYPE??""),
                   new Claim("USR_SCOPE",scope??"MD"),
                   new Claim("BG_NO",dto.BG_NO??""),
                   new Claim("OPEN_ID",dto.OPEN_ID??""),
                };
        }
    }
}
