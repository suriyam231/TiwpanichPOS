using RegisterManange.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListStatusJob.API.Interface
{
    public interface ListStatusJobInterface
    {
        List<PositionDTO> GetDataPosition();//get
        List<ListOfValueDTO> GetPositionMaster(); //get data from table position. 
        string AddRegisterPosition(PositionDTO position); //add postion for applicant register (List Status Job).
        string EditRegisterPosition(PositionDTO position); //edit position for applicant register (List Status Job).
        string DeleteRegisterPosition(int positionId); // delete position for applicant register (List Status Job).
    }
}
