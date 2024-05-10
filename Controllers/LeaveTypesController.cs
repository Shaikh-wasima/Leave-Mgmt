using AutoMapper;
using Leave_Management.Contracts;
using Leave_Management.Data;
using Leave_Management.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_Management.Controllers
{
    [Authorize(Roles = "Administrator, Manager")]
    public class LeaveTypesController : Controller
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public LeaveTypesController(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        #region API Calls

        public IActionResult GetAll()
        {
            var leaveType = _uow.LeaveType.GetAll().ToList();
            var model = _mapper.Map<List<LeaveType>, List<LeaveTypeVM>>(leaveType);
            return Json(new { data = model });
        }

        // GET: LeaveType/Delete/5
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var dataLeaveType = await _uow.LeaveType.Get(id);
            if (dataLeaveType == null)
                return Json(new { success = false, message = "Data Not Found!" });
            _uow.LeaveType.Delete(dataLeaveType);
            _uow.Save();
            return Json(new { success = true, message = "Delete Operation Successfully" });
        }
        #endregion

        // GET: LeaveType
        public ActionResult Index()
        {
            return View();
        }

        // GET: LeaveType/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var model = await _uow.LeaveType.GetFirstOrDefault(u => u.Id == id);
            if (model == null)
            {
                return NotFound();
            }

            var models = _mapper.Map<LeaveTypeVM>(model);

            return View(models);
        }

        // GET: LeaveType
        public async Task<IActionResult> Create(int? id)
        {
            if (id == null)
            {
                //Create
                return View(new LeaveTypeVM());
            }
            //Update

            var model = await _uow.LeaveType.GetFirstOrDefault(u => u.Id == id);
            var leaveTypeVm = _mapper.Map<LeaveTypeVM>(model);

            if (leaveTypeVm == null)
            {
                return NotFound();
            }
            return View(leaveTypeVm);
        }

        // POST: LeaveType/Create/Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(LeaveTypeVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                if (model.Id == 0) //Create
                {
                    TempData["result"] = "Create";
                    var leaveType = _mapper.Map<LeaveType>(model);
                    leaveType.DateCreated = DateTime.Now;
                    _uow.LeaveType.Create(leaveType);
                }
                else // Update
                {
                    TempData["result"] = "Update";
                    var leaveType = _mapper.Map<LeaveType>(model);
                    _uow.LeaveType.Update(leaveType);
                }
                _uow.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }


    //     public IActionResult DownloadLeaveTypes()
    //{
    //    var leaveTypes = _uow.LeaveType.GetAll(); // Retrieve all leave types from the database

    //    // Create a new Excel package
    //    using (var package = new ExcelPackage())
    //    {
    //        var worksheet = package.Workbook.Worksheets.Add("Leave Types"); // Create a worksheet

    //        // Add column headers
    //        worksheet.Cells["A1"].Value = "Leave Type Name";
    //        worksheet.Cells["B1"].Value = "Description";
    //        worksheet.Cells["C1"].Value = "Number of Days";

    //        // Populate data rows
    //        int row = 2;
    //        foreach (var leaveType in leaveTypes)
    //        {
    //            worksheet.Cells["A" + row].Value = leaveType.Name;
    //            zzworksheet.Cells["B" + row].Value = leaveType.Description;
    //            worksheet.Cells["C" + row].Value = leaveType.NumberOfDays;
    //            row++;
    //        }

    //        // Convert the Excel package to a byte array
    //        byte[] excelData = package.GetAsByteArray();

    //        // Return the Excel file as a downloadable file
    //        return File(excelData, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "LeaveTypes.xlsx");
    //    }
    //}






    }
}