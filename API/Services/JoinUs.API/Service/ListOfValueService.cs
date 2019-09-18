using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RegisterManange.API.DTOs;
using ListOfValue.API.Interface;
using RegisterManange.API.DTOs;
using RegisterManange.API.Models;

namespace ListOfValue.API.Service
{
    public class ListOfValueService : ListOfValueInterface
    {
        private readonly SRM_DEVContext Context;
        private object ctx;

        public ListOfValueService(SRM_DEVContext context)
        {
            Context = context;
        }

        public string AddListOfValue(ListOfValueDTO value)
        {
            RegisterManange.API.Models.ListOfValue ListOfValue = new RegisterManange.API.Models.ListOfValue();

            ListOfValue.GroupCode = value.GroupCode;
            ListOfValue.SeqNo = value.SeqNo.GetValueOrDefault();
            ListOfValue.Value = value.Value;
            ListOfValue.Description = value.Description;
            ListOfValue.CrBy = value.CrBy;
            ListOfValue.CrDate = DateTime.Now;
            ListOfValue.UpdBy = value.CrBy;
            ListOfValue.UpdDate = DateTime.Now;
            ListOfValue.Active = value.Active;

            Context.ListOfValue.Add(ListOfValue);
            Context.SaveChanges();

            return "success";
        }

        public string DeleteListOfValue(ListOfValueDTO value)
        {
            RegisterManange.API.Models.ListOfValue ListOfValue = new RegisterManange.API.Models.ListOfValue();

            ListOfValue = Context.ListOfValue.Where(x => x.GroupCode == value.GroupCode && x.SeqNo == value.SeqNo).FirstOrDefault();

            Context.ListOfValue.Remove(ListOfValue);
            Context.SaveChanges();

            return "success";
        }

        public string EditListOfValue(ListOfValueDTO value)
        {
            RegisterManange.API.Models.ListOfValue ListOfValue = new RegisterManange.API.Models.ListOfValue();

            ListOfValue = Context.ListOfValue.Where(x => x.GroupCode == value.GroupCode && x.SeqNo == value.SeqNo).FirstOrDefault();

            ListOfValue.Value = value.Value;
            ListOfValue.Description = value.Description;
            ListOfValue.UpdBy = value.UpdBy;
            ListOfValue.UpdDate = DateTime.Now;
            ListOfValue.Active = value.Active;
            Context.ListOfValue.Update(ListOfValue);
            Context.SaveChanges();

            return "success";
        }

        public List<ListOfValueDTO> GetDataListOfValue()
        {
            List<ListOfValueDTO> values = (from Values in Context.ListOfValue
                                           select new ListOfValueDTO
                                           {
                                               GroupCode = Values.GroupCode,
                                               SeqNo = Values.SeqNo,
                                               Value = Values.Value,
                                               Description = Values.Description,
                                               CrBy = Values.CrBy,
                                               CrDate = Values.CrDate,
                                               UpdBy = Values.UpdBy,
                                               UpdDate = Values.UpdDate,
                                               Active = Values.Active
                                           }).ToList();
            return values;
        }

        public List<ListOfValueDTO> GetDataListOfValue(ListOfValueDTO value)
        {
            List<ListOfValueDTO> values = (from Values in Context.ListOfValue
                                           where (value.GroupCode == null || Values.GroupCode == value.GroupCode) &&
                                                 (value.SeqNo == null || Values.SeqNo == value.SeqNo) &&
                                                 (value.Value == null || Values.Value == value.Value) &&
                                                 (value.Description == null || Values.Description.Contains(value.Description))
                                           select new ListOfValueDTO
                                           {
                                               GroupCode = Values.GroupCode,
                                               SeqNo = Values.SeqNo,
                                               Value = Values.Value,
                                               Description = Values.Description,
                                               CrBy = Values.CrBy,
                                               CrDate = Values.CrDate,
                                               UpdBy = Values.UpdBy,
                                               UpdDate = Values.UpdDate,
                                               Active = Values.Active
                                           }).ToList();
            return values;
        }

        public int GetLastSeqNo(string groupCode)
        {
            int lastSeq = 0;
            IEnumerable<int> result = (from Values in Context.ListOfValue
                                       where Values.GroupCode == groupCode
                                       select Values.SeqNo);

            if (result.Any())
            {
                lastSeq = result.Max();
            }

            return lastSeq;
        }

        public List<ListOfValueGroups> GetAllGroup()
        {
            List<ListOfValueGroups> result = new List<ListOfValueGroups>();
            result = (
                from groups in Context.ListOfValueGroups
                select new ListOfValueGroups
                {
                    GroupCode = groups.GroupCode,
                    Value = groups.Value,
                    Active = groups.Active
                }).ToList();

            return result;
        }

        public List<ListOfValueDTO> GetListofValue(string groupcode)
        {
            List<ListOfValueDTO> values = (from Values in Context.ListOfValue
                                           where Values.GroupCode == groupcode &&  Values.Active == "Y"
                                           select new ListOfValueDTO
                                           {
                                               GroupCode = Values.GroupCode,
                                               SeqNo = Values.SeqNo,
                                               Value = Values.Value,
                                               Description = Values.Description,
                                               CrBy = Values.CrBy,
                                               CrDate = Values.CrDate,
                                               UpdBy = Values.UpdBy,
                                               UpdDate = Values.UpdDate,
                                               Active = Values.Active
                                           }).ToList();
            return values;
        }
    }
}
