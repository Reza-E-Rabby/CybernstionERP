using CSERP.DATA.Infrastructure;
using CSERP.DATA.Infrastructure.HRM.Commands;
using CSERP.DATA.Infrastructure.HRM.Queries;
using CSERP.MODELS.Models.HRM;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CSERP.WEB.Areas.HRM.Controllers
{
    public class MasterDataController : HRMBaseController
    {
        private readonly ICommandHandler<CreateHRMCompanyCommand> _createHRMCompanyCommand;
        private readonly ICommandHandler<UpdateHRMCompanyCommand> _updateHRMCompanyCommand;
        private readonly IQueryHandler<GetAllHRMCompanyQuery, IEnumerable<HRMCompanyInfo>> _GetAllCompanyQuerHandler;
        private readonly ICommandHandler<DeleteHRMCompanyCommand> _deleteHRMCompanyCommand;
        private readonly IQueryHandler<GetSingleHRMCompanyQuery, HRMCompanyInfo> _getSingleCompanyQuerHandler;

        public MasterDataController(ICommandHandler<CreateHRMCompanyCommand> createHRMCompanyCommand, ICommandHandler<UpdateHRMCompanyCommand> updateHRMCompanyCommand, ICommandHandler<DeleteHRMCompanyCommand> deleteHRMCompanyCommand, IQueryHandler<GetAllHRMCompanyQuery, IEnumerable<HRMCompanyInfo>> getAllCompanyQuerHandler, IQueryHandler<GetSingleHRMCompanyQuery, HRMCompanyInfo> getSingleCompanyQuerHandler)
        {
            this._createHRMCompanyCommand = createHRMCompanyCommand;
            this._updateHRMCompanyCommand = updateHRMCompanyCommand;
            this._GetAllCompanyQuerHandler = getAllCompanyQuerHandler;
            this._deleteHRMCompanyCommand = deleteHRMCompanyCommand;
            this._getSingleCompanyQuerHandler = getSingleCompanyQuerHandler;
        }

        #region Company Information
        public IActionResult CreateCompany()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CreateUpdateNewCompany(HRMCompanyInfo obj)
        {
            try
            {
                string Message = "Something Went Wrong!";
                if (obj.ID == Guid.Empty)
                {
                    _createHRMCompanyCommand.Execute(new CreateHRMCompanyCommand
                    {
                        CompanyName = obj.CompanyName,
                        LocationDescription = obj.LocationDescription,
                        CreatedBy = "Reza",
                        CreateDateTime = DateTime.Now
                    });
                    Message = "Company added successfully";
                }
                else
                {
                    _updateHRMCompanyCommand.Execute(new UpdateHRMCompanyCommand
                    {
                        CompanyName = obj.CompanyName,
                        LocationDescription = obj.LocationDescription,
                        ID = obj.ID,
                        UpdatedDateTime = DateTime.Now
                    });
                    Message = "Company updated successfully";
                }
                return Json(Message);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        [HttpPost]
        public JsonResult DeleteCompany([FromBody] HRMCompanyInfo obj)
        {
            try
            {
                string Message = "Something Went Wrong!!";
                if (!string.IsNullOrEmpty(obj.ID.ToString()))
                {
                    _deleteHRMCompanyCommand.Execute(new DeleteHRMCompanyCommand
                    {
                        ID = obj.ID
                    });
                    Message = "Deleted successfully";
                }

                return Json(Message);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }


        [HttpPost]
        public JsonResult GetCompanyById([FromBody] HRMCompanyInfo obj)
        {
            try
            {
                HRMCompanyInfo hRMCompanyInfo = new HRMCompanyInfo();
                if (!string.IsNullOrEmpty(obj.ID.ToString()))
                {
                    hRMCompanyInfo = _getSingleCompanyQuerHandler.Query(new GetSingleHRMCompanyQuery
                    {
                        ID = obj.ID
                    });
                }
                return Json(hRMCompanyInfo);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }


        [HttpPost]
        public JsonResult CompanyList()
        {
            try
            {
                List<HRMCompanyInfo> companyList = new List<HRMCompanyInfo>();
                companyList = _GetAllCompanyQuerHandler.Query(new GetAllHRMCompanyQuery()) as List<HRMCompanyInfo>;
                return Json(companyList);
            }
            catch (Exception ez)
            {
                return Json(new { Success = false, Message = ez.Message });
            }

        }
        #endregion
    }
}