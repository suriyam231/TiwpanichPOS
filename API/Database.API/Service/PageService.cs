using Database.API.Interface;
using Database.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database.API.Service
{
    public class PageService : PageInterface
    {
        private readonly SRM_DEVContext Context;

        public PageService(SRM_DEVContext context)
        {
            Context = context;
        }


        public List<Provinces> GetProvinces()
        {
            List<Provinces> res = (from data in Context.Provinces
                                   select new Provinces
                                   {
                                       Id = data.Id,
                                       Code = data.Code,
                                       NameInThai = data.NameInThai
                                   }).ToList();
            return res;
        }


        public List<Districts> GetDistricts(string District)
        {
            int value = Int32.Parse(District);
     
            List<Districts> res = (from data in Context.Districts
                                   where data.ProvinceId == value
                                   select new Districts
                                   {
                                       Id = data.Id,
                                       Code = data.Code,
                                       NameInThai = data.NameInThai,
                                   }).ToList();
            return res;
        }


        public List<Subdistricts> GetSubdistricts(string Subdistricts)
        {
            int value = Int32.Parse(Subdistricts);

            List<Subdistricts> res = (from data in Context.Subdistricts
                                   where data.DistrictId == value
                                   select new Subdistricts
                                   {
                                       Id = data.Id,
                                       Code = data.Code,
                                       NameInThai = data.NameInThai,
                                       ZipCode = data.ZipCode
                                   }).ToList();
            return res;
        }

        public string addRegister(ProfileUser value)
        {
            //Seq = Context.DbExam.Where(i => i.ExamType == value.ExamType).Max(i => i.Seq) + 1;

             int UserID;
           // UserID = Context.ProfileUser.Where(i => i.UserId == value).Max(i => i.UserId) + 1;

            return "UserID";
        }


        // หน้า Home 
        public List<Profile> CheckUser(string password , string username)
        {
            List<Profile> res = (from data in Context.Profile
                                 where data.Username == username && data.Password == password
                                 select new Profile
                                 {
                                     UserId = data.UserId,
                                     Username = data.Username,
                                     Password = data.Password,
                                     StoreName = data.StoreName,
                                     FirstName = data.FirstName,
                                     LastName = data.LastName,
                                     StoreOwner = data.StoreOwner,
                                     Position = data.Position
                                 }).ToList();

            return res;
        }
    }
}
