using Database.API.Interface;
using Database.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.API.Models;

namespace Database.API.Service
{
    public class DBBranchService : DBBranchInterface
    {
        private readonly SRM_DEVContext Context;
        public DBBranchService(SRM_DEVContext context)
        {
            Context = context;
        }
        public List<TestName> GetName()
        {
            List<TestName> result = (from data in Context.TestName
                                     select new TestName
                                     {
                                         Firstname = data.Firstname,
                                         Lastname = data.Lastname,
                                         Nickname = data.Nickname

                                     }).ToList();
            return result;
        }
        //public string AddBranchValue(DbBranch value)
        //{
        //    //DbBranch BranchValue = new DbBranch();
        //    //BranchValue.BranchCode = value.BranchCode;
        //    //BranchValue.BranchName = value.BranchName;
        //    //BranchValue.Active = value.Active;
        //    //BranchValue.CrBy = value.CrBy;
        //    //BranchValue.CrDate = DateTime.Now;

        //    Context.DbBranch.Add(value);
        //    Context.SaveChanges();
        //    return "success";

        //}

        //public string EditBranchValue(EditBranchDTO value)
        //{
        //    DbBranch DbBranchs = new DbBranch();

        //    DbBranchs = Context.DbBranch.Where(x => x.BranchCode == value.OldBranchCode && x.BranchName == value.OldBranchName).FirstOrDefault();


        //    DbBranchs.BranchCode = value.BranchCode;
        //    DbBranchs.BranchName = value.BranchName;
        //    DbBranchs.Active = value.Active;
        //    DbBranchs.UpdBy = value.UpdBy;
        //    DbBranchs.UpdDate = DateTime.Now;
        //    Context.DbBranch.Update(DbBranchs);
        //    Context.SaveChanges();

        //    return "success";
        //}

        //public string DeleteBranchValue(string BranchCode, string BranchName)
        //{
        //    DbBranch DbBranchs = new DbBranch();
        //    DbBranchs = Context.DbBranch.Where(x => x.BranchCode == BranchCode || x.BranchName == BranchName).FirstOrDefault();

        //    Context.DbBranch.Remove(DbBranchs);
        //    Context.SaveChanges();

        //    return "success";
        //}

    }
}
