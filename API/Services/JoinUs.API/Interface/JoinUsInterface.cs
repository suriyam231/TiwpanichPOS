using ListApplicant.API.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegisterManange.API.DTOs;
using RegisterManange.API.Models;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace JoinUs.API.Interface
{
    public interface JoinUsInterface
    {
        List<ApplicantProfile> GetDataProfile(); //get
        Task<string> SaveApplicant(ApplicantDTO data); //post
        ApplicantDTO GetDataProfileByID(int empID);
        string UpdateProfileStatus(UpdateStatusDTO status);
        List<ApplicantProfile> GetDataProfileByHR(string name, string date, string type); // get data profile by name and date.
        List<ApplicantProfile> GetDataCheckProgress(string IDcard);// get data profile by IDcard and date.
        List<AddressDTO> GetAddress(string type, int value);
        string updateStatus(UpdateStatusDTO status);
        string UploadFiles(string empID, IFormFileCollection files);
        string[] GetFileName(string empID);
        MemoryStream GetFiles(string empID, string fileName, ref string contentType);
    }
}
