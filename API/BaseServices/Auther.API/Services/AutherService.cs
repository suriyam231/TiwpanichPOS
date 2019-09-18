using Auther.API.Interfaces;
using Auther.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;
using System.DirectoryServices;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using Auther.API.DTOs;
using System.Threading;

namespace Auther.API.Services
{
    public class AutherService : IAutherService
    {
        private ISRMContext Context;
        private ILDAPService LDAPService;
        private IRunningNoService RunningNoService;
        private IEncryptionService EncryptionService;
        TokenDTO tokens = new TokenDTO();
        public AutherService(ISRMContext _Context, ILDAPService _LDAPService, IRunningNoService _runningNoService, IEncryptionService _encryptionService)
        {
            Context = _Context;
            LDAPService = _LDAPService;
            RunningNoService = _runningNoService;
            EncryptionService = _encryptionService;
        }

        public TokenDTO Login(string Username, string Password)
        {
            try
            {
                Task<TokenDTO> data = LoginAsync(Username, Password);
                return data.Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TokenDTO> LoginAsync(string Username, string Password)
        {
            try
            {
                Employee user = Context.Employee.Where(x => x.Username == Username).FirstOrDefault();
                if (user == null)
                {
                    EmployeeDTO ADUser = LDAPService.LDAP_Authenticate(Username, Password);
                    if (ADUser.Username == null)
                    {
                        tokens.Message = "ไม่พบข้อมูลผู้ใช้งาน";
                        return tokens;
                    }
                    else
                    {
                        string SystemCode = await CreateNewUserAsync(ADUser);
                        tokens.empCode = SystemCode;
                        tokens.Message = "Login Success";
                        return tokens;
                    }
                }
                else
                {
                    Password = EncryptionService.HashToMD5(Password + user.Passwordsalt);
                    Employee users = Context.Employee.Where(x => x.Username == Username && x.Password == Password).FirstOrDefault();
                    EmployeeProfile employeeProfile = Context.EmployeeProfile.Where(x => x.Empcode == user.Empcode).FirstOrDefault();
                    DbPosition dbPosition = Context.DbPosition.Where(x => x.PositonCode == employeeProfile.PositionCode).FirstOrDefault();
                    if (users == null)
                    {
                        //user.UpdDate = DateTime.Now;
                        //Context.Employee.Update(user);
                        //Context.SaveChanges();
                        tokens.Message = "ชื่อผู้ใช้ และ รหัสผ่านไม่ถูกต้อง";
                        return tokens;
                    }
                    else
                    {
                        //TOKEN
                        tokens.empCode = user.Empcode;
                        tokens.Username = users.Username;
                        tokens.Firstname = employeeProfile.FirstnameEn;
                        tokens.Lastname = employeeProfile.LastnameEn;
                        tokens.PositionCode = dbPosition.PositonCode;
                        tokens.Token = GenerateToken(user.Empcode);
                        tokens.Message = "Login Success";
                        return tokens;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> CreateNewUserAsync(EmployeeDTO ADUser)
        {
            try
            {
                Employee user = new Employee();
                EmployeeProfile employeeProfile = Context.EmployeeProfile.Where(x => x.Empcode == ADUser.Empcode).FirstOrDefault();
                DbPosition dbPosition = Context.DbPosition.Where(x => x.PositionName == ADUser.Position).FirstOrDefault();

                user.Empcode = ADUser.Empcode;
                user.Username = ADUser.Username;
                user.Passwordsalt = EncryptionService.GeneratePasswordSalt();
                user.Password = EncryptionService.HashToMD5(ADUser.Password + user.Passwordsalt);

                user.Active = true;
                user.CrBy = "LDAP";
                user.CrDate = DateTime.Now;

                Context.Employee.Add(user);
                Context.SaveChanges();

                if (employeeProfile == null)
                {
                    employeeProfile.Empcode = ADUser.Empcode;
                    employeeProfile.FirstnameTh = ADUser.FirstnameEn;
                    employeeProfile.LastnameEn = ADUser.LastnameEn;
                    employeeProfile.Tel = ADUser.Tel;
                    employeeProfile.Email = ADUser.Email;
                    employeeProfile.Position = ADUser.Position;

                    if (dbPosition != null)
                    {
                        employeeProfile.PositionCode = dbPosition.PositonCode;
                    }

                    Context.EmployeeProfile.Add(employeeProfile);
                    Context.SaveChanges();
                }


                //TOKEN 
                tokens.empCode = ADUser.Empcode;
                tokens.Username = ADUser.Username;
                tokens.Firstname = ADUser.FirstnameEn;
                tokens.Lastname = ADUser.LastnameEn;
                tokens.PositionCode = dbPosition.PositonCode;
                tokens.Token = GenerateToken(user.Empcode);

                return user.Empcode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GenerateToken(string SystemCode)
        {
            try
            {
                int exp = 5;
                DateTime dateTimeNow = DateTime.Now;
                var claims = new[]
                {
                        new Claim("SystemCode", SystemCode.ToString()),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, dateTimeNow.ToUniversalTime().ToString(), ClaimValueTypes.Integer64),
                };
                var token = new JwtSecurityToken
                (
                    issuer: Authers.Issuer,
                    audience: Authers.Audience,
                    claims: claims,
                    expires: dateTimeNow.AddHours(exp),
                    notBefore: dateTimeNow,
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Authers.SigningKey)), SecurityAlgorithms.HmacSha256Signature)
                );
                tokens.ExpiresDate = dateTimeNow.AddHours(exp);
                tokens.CreatedDate = dateTimeNow;
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Employee> GetAuther()
        {
            return Context.Employee.ToList();
        }
    }
}