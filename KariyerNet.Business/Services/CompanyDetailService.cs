using KariyerNet.Business.Interfaces;
using KariyerNet.Common.ViewModels;
using KariyerNet.Data.Domain;
using KariyerNet.Data.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace KariyerNet.Business.Services
{
    public class CompanyDetailService : ICompanyDetailService
    {

        private readonly ICompanyDetailRepository _companyDetailRepository;
        private readonly ISectorRepository _sectorRepository;
        private readonly ISectorService _sectorService;
        private readonly IUserService _userService;
        private readonly IMessageService _messageService;
        public CompanyDetailService(ICompanyDetailRepository companyDetailRepository, ISectorRepository sectorRepository, ISectorService sectorService, IUserService userService, IMessageService messageService)
        {
            _companyDetailRepository = companyDetailRepository;
            _sectorRepository = sectorRepository;
            _sectorService = sectorService;
            _userService = userService;
            _messageService = messageService;
        }


        public int EditCompanyDetail(EditCompanyDetailViewModel model)
        {
            //var userId = contextUser.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
            var user = _userService.GetUser();
            if(!_sectorService.isSectorValid(model.SectorId))
            {
                return 0;
            }
            CompanyDetail companyDetail = _companyDetailRepository.Get(x => x.UserId == user.UserId);
            if (companyDetail == null)
            {
                companyDetail = new CompanyDetail();
                _companyDetailRepository.Add(companyDetail);
                companyDetail.CreateDate = DateTime.Now;
            }
            else
            {
                companyDetail.UpdateDate = DateTime.Now;
            }
            if(model.ImagePath!=null)
            {
                companyDetail.ImageUrl = model.ImagePath;
            }

            companyDetail.UserId = user.UserId;
            companyDetail.SectorId = model.SectorId;
            companyDetail.CompanyName = model.CompanyName;
            companyDetail.FoundationYear = model.FoundationYear;
            companyDetail.Address = model.Address;
            companyDetail.NumberOfEmployees = model.NumberOfEmployees;
            companyDetail.WebSite = model.WebSite;
            companyDetail.About = model.About;
            //companyDetail.ImageUrl = model.ImageUrl;//?           

            try
            {
                _companyDetailRepository.SaveChanges();
                return companyDetail.Id;
            }
            catch (Exception ex)
            {
                var errorMessage = ex.Message;
                throw;
            }


        }


        public EditCompanyDetailViewModel GetCompanyDetail()
        {
            var user = _userService.GetUser();

            var model = new EditCompanyDetailViewModel();
            CompanyDetail companyDetail = _companyDetailRepository.Get(x => x.UserId == user.UserId);
            if (companyDetail != null)
            {
                model.ImagePath = companyDetail.ImageUrl;
                model.UserId = companyDetail.UserId;
                model.WebSite = companyDetail.WebSite;
                model.SectorId = companyDetail.SectorId;
                model.NumberOfEmployees = companyDetail.NumberOfEmployees;
                //model.ImageUrl = companyDetail.ImageUrl;
                model.FoundationYear = companyDetail.FoundationYear;
                model.CompanyName = companyDetail.CompanyName;
                model.Address = companyDetail.Address;
                model.About = companyDetail.About;
                model.NumberOfUnreadSendedMessages = _messageService.GetUnreadSendedMessageCount();
                model.ImageFileName = Path.GetFileName(model.ImagePath);
            }
            model.SectorList = _sectorService.GetSectorList();
            return model;
        }


        public GetCompanyDetailViewModel GetCompanyDetailByCompanyId(int Id)
        {
            var model = new GetCompanyDetailViewModel();
            CompanyDetail companyDetail = _companyDetailRepository.Get(x => x.Id == Id);
            if (companyDetail != null)
            {
                model.UserId = companyDetail.UserId;
                model.WebSite = companyDetail.WebSite;
                model.SectorId = companyDetail.SectorId;
                model.SectorName = _sectorService.GetSectorNameBySectorId(model.SectorId);
                model.NumberOfEmployees = companyDetail.NumberOfEmployees;
                model.ImageUrl = companyDetail.ImageUrl;
                model.FoundationYear = companyDetail.FoundationYear;
                model.CompanyName = companyDetail.CompanyName;
                model.Address = companyDetail.Address;
                model.About = companyDetail.About;
            }
            model.SectorList = _sectorService.GetSectorList();
            return model;
        }


        public GetCompanyDetailViewModel GetCompanyDetailByCompanyUserId(int companyUserId)
        {
            var model = new GetCompanyDetailViewModel();
            CompanyDetail companyDetail = _companyDetailRepository.Get(x => x.UserId == companyUserId);
            if (companyDetail != null)
            {
                model.UserId = companyDetail.UserId;
                model.WebSite = companyDetail.WebSite;
                model.SectorId = companyDetail.SectorId;
                model.SectorName = _sectorService.GetSectorNameBySectorId(model.SectorId);
                model.NumberOfEmployees = companyDetail.NumberOfEmployees;
                model.ImageUrl = companyDetail.ImageUrl;
                model.FoundationYear = companyDetail.FoundationYear;
                model.CompanyName = companyDetail.CompanyName;
                model.Address = companyDetail.Address;
                model.About = companyDetail.About;
            }
            model.SectorList = _sectorService.GetSectorList();
            return model;
        }




        public string GetCompanyDetailNameByCompanyUserId(int companyUserId)
        {
            return _companyDetailRepository.Get(x => x.UserId == companyUserId).CompanyName.ToString();
        }

        public int GetCompanyIdByCompanyUserId(int companyUserId)
        {
            return _companyDetailRepository.Get(x => x.UserId == companyUserId).Id;
        }

        public List<int> GetCompanyUserIdsBySectorId(List<int?> sectorId)
        {
            var returnList = new List<int>();
            if (sectorId != null)
            {
                //var companyList = _companyDetailRepository.GetAll(x => x.SectorId == sectorId).ToList();
                var companyList = _companyDetailRepository.GetAll(x => sectorId.Contains(x.SectorId)).ToList();
                var companyIdList = new List<int>();
                foreach (var item in companyList)
                {
                    companyIdList.Add(item.UserId);
                }
                return companyIdList;
            }
            return returnList;
        }

        public List<int> GetCompanyUserIdsByCompanyName(string companyName)
        {
            var returnList = new List<int>();
            if(companyName!=null)
            {
                var companyList = _companyDetailRepository.GetAll(x => x.CompanyName.Contains(companyName)).ToList();
                var companyIdList = new List<int>();
                foreach (var item in companyList)
                {
                    companyIdList.Add(item.UserId);
                }
                return companyIdList;
            }
            return returnList;
        }



    }
}
