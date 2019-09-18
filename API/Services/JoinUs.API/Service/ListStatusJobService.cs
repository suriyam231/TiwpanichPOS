using ListStatusJob.API.Interface;
using RegisterManange.API.DTOs;
using RegisterManange.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListStatusJob.API.Service
{
    public class ListStatusJobService : ListStatusJobInterface
    {
        private readonly SRM_DEVContext Context;
        private object ctx;

        public ListStatusJobService(SRM_DEVContext context)
        {
            Context = context;
        }

        public List<PositionDTO> GetDataPosition()
        {
            List<PositionDTO> position = (from Position in Context.ManageRegisterPosition
                                          join ListOfValue in Context.ListOfValue on Position.PositionId equals ListOfValue.SeqNo
                                          join ListOfValueGroups in Context.ListOfValueGroups on ListOfValue.GroupCode equals ListOfValueGroups.GroupCode
                                          where ListOfValue.GroupCode == "POS"
                                          orderby ListOfValue.Value
                                          select new PositionDTO
                                          {
                                              id = Position.Id,
                                              PositionId = Position.PositionId,
                                              Position = ListOfValue.Value,
                                              NumberOfPosition = Position.NumberOfPosition,
                                              ActiveStatus = Position.ActiveStatus,
                                              Type_Employee = Position.TypeEmployee,
                                              Address = ListOfValue.Description
                                          }
                                          ).ToList();

            return position;
        }

        public List<ListOfValueDTO> GetPositionMaster()
        {
            List<ListOfValueDTO> position = (from groups in Context.ListOfValue
                                             select new ListOfValueDTO
                                             {
                                                 GroupCode = groups.GroupCode,
                                                 Value = groups.Value,
                                                 Description = groups.Description,
                                                 Active = groups.Active,
                                                 SeqNo = groups.SeqNo
                                             }).ToList();
            return position;
        }

        public string AddRegisterPosition(PositionDTO position)
        {
            try
            {
                List<PositionDTO> data = (
                                        from typeEmployee in Context.ManageRegisterPosition
                                        where typeEmployee.PositionId == position.PositionId
                                         select new PositionDTO
                                         {
                                             Type_Employee = typeEmployee.TypeEmployee
                                         }).ToList();
                for(int i = 0;i < data.Count; i++)
                {
                    if(data[i].Type_Employee == position.Type_Employee)
                    {
                        return "warning";
                    }
                }
                ManageRegisterPosition MRegisterPosition = new ManageRegisterPosition();

                MRegisterPosition.PositionId = position.PositionId;
                MRegisterPosition.NumberOfPosition = position.NumberOfPosition;
                MRegisterPosition.ActiveStatus = position.Active;
                MRegisterPosition.CrBy = position.Username;
                MRegisterPosition.CrDate = DateTime.Now;
                MRegisterPosition.UpdBy = position.Username;
                MRegisterPosition.UpdDate = DateTime.Now;
                MRegisterPosition.TypeEmployee = position.Type_Employee;

                Context.ManageRegisterPosition.Add(MRegisterPosition);
                Context.SaveChanges();

                return "success";
            }
            catch(Exception e) { throw e; }
        }

        public string EditRegisterPosition(PositionDTO position)
        {
            try
            {
                ManageRegisterPosition MRegisterPosition = new ManageRegisterPosition();
                MRegisterPosition = Context.ManageRegisterPosition.Where(x => x.Id == position.id).FirstOrDefault();

                MRegisterPosition.NumberOfPosition = position.NumberOfPosition;
                MRegisterPosition.ActiveStatus = position.Active;
                MRegisterPosition.UpdBy = position.Username;
                MRegisterPosition.UpdDate = DateTime.Now;
                MRegisterPosition.TypeEmployee = position.Type_Employee;

                Context.ManageRegisterPosition.Update(MRegisterPosition);
                Context.SaveChanges();

                return "success";
            }
            catch (Exception e) { throw e; }
        }

        public string DeleteRegisterPosition(int id)
        {
            try
            {
                ManageRegisterPosition MRegisterPosition = new ManageRegisterPosition();
                MRegisterPosition = Context.ManageRegisterPosition.Where(x => x.Id == id).FirstOrDefault();

                Context.ManageRegisterPosition.Remove(MRegisterPosition);
                Context.SaveChanges();

                return "success";
            }
            catch (Exception e) { throw e; }
        }
    }
}
