using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RegisterManange.API.DTOs;
using RegisterManange.API.Models;

namespace ListOfValue.API.Interface
{
    public interface ListOfValueInterface
    {
        List<ListOfValueDTO> GetDataListOfValue();                      // get 
        int GetLastSeqNo(string groupCode);                             // get last seq no of group.
        List<ListOfValueGroups> GetAllGroup();                          // get all group.
        string AddListOfValue(ListOfValueDTO value);                    // add List of value.
        string EditListOfValue(ListOfValueDTO value);                   // edit List of value.
        string DeleteListOfValue(ListOfValueDTO value);                 // delete List of value.
        List<ListOfValueDTO> GetDataListOfValue(ListOfValueDTO value);  // search List of value.

        List<ListOfValueDTO> GetListofValue(string groupcode);
    }
}
