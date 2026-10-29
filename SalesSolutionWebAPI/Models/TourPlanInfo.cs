using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesSolutionWebAPI.Models
{
    public class TourPlanInfo
    {
        public int TourPlanId { get; set; }

        //public int? TerritoryId { get; set; }

        public int? MarketId { get; set; }

        //public int? SMId { get; set; }

        

        //public int? ShiftId { get; set; }

        //public int? TourTypeId { get; set; }

        public int? TPId { get; set; }

        //public string Comment { get; set; }

        public DateTime? TourPlanDate { get; set; }

        public int? EmpInfoId { get; set; }
        public int? SerialNo { get; set; }

        //public bool? IsMarketWise { get; set; }

        //public bool? IsApproved { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }

        public List<CustomerMasterDAO> aCustomerMasterList { get; set; }

    }

    public class CustomerMasterDAO
    {
        public int CustomerMasterId { get; set; }
    }
        public class TourPlanInfoMaster
    {
        public List<TourPlanInfo> aTourPlanInfo { get; set; }
    }



    public class TWWWPMaster
    {
        public string empId { get; set; }


        public   TWWWPMorning TwwpMorning { get; set; }
        public TWWWPEvening TwwpEvening { get; set; }
 
    }


    public class WSS_Master
    {
        public string empId { get; set; }
        public string date { get; set; }
        public string day { get; set; }
     


        public Wss_Morning morningList { get; set; }
        public Wss_Evening eveningList { get; set; }

    }


    public class WSS_Master_Update
    {
        public string empId { get; set; }
        public string MasterId { get; set; }
        public string Type { get; set; }
         public string date { get; set; }
        public string day { get; set; }



        public Wss_Morning_up WCABMMorning { get; set; }
        public Wss_Even_up WCABMEvening { get; set; }

    }





    public class WSMaster
    {
        public string empId { get; set; }


        public WSMorning WCABMMorning { get; set; }
        public WSEvening WCABMEvening { get; set; }

    }




    public class TWWWPMasterView
    {

        public string Empid { get; set; }
        public string DayName { get; set; }

        public  TWWWPMorningView  TwwpMorning_V { get; set; }
        public  TWWWPEveningView  TwwpEvening_V { get; set; }

    }

    public class WorkScheduleView
    {

        public string Empid { get; set; }
        public string masterId { get; set; }
        public string day  { get; set; }
        public string date { get; set; }

        public  WorkScheduleMorningView  morningList { get; set; }
        public  WorkScheduleEveningView  eveningList { get; set; }

    }


    public class WS_AF
    {

        public string Empid { get; set; }
        public string masterId { get; set; }
        public string day { get; set; }
        public string date { get; set; }
        
        public string ApprovalStatus { get; set; }
        public string AmendmentStatus { get; set; }

        public WorkScheduleMorningView morningList { get; set; }
        public WorkScheduleEveningView eveningList { get; set; }

    }

    public class WSMasterView
    {

        public string Empid { get; set; }
        public string DayName { get; set; }
        public string DayVal { get; set; }
        public string MonthVal { get; set; }
        public string YearVal { get; set; }

        public WSMorningView WSMorning_V { get; set; }
        public WSEveningView WSEvening_V { get; set; }

    }

    public class TWWWPMorningView
    {

        public string WorkSession { get; set; }
        public string TourTypeId { get; set; }
        public string TourType  { get; set; }
        public string WorkTypeId { get; set; }
        public string WorkType  { get; set; }
        public string DayNameValueId { get; set; }
        public string DayNameValue  { get; set; }
        public string DeliveryDayNameId { get; set; }
        public string DeliveryDayName  { get; set; }
        public string StartTime { get; set; }
        public string StartPoint { get; set; }

        public string EndTime { get; set; }
        public string EndPoint { get; set; }



    }



    public class TWWWPEveningView
    {

        public string WorkSession { get; set; }
        public string TourTypeId { get; set; }
        public string TourType { get; set; }
        public string WorkTypeId { get; set; }
        public string WorkType { get; set; }
        public string DayNameValueId { get; set; }
        public string DayNameValue { get; set; }
        public string DeliveryDayNameId { get; set; }
        public string DeliveryDayName { get; set; }
        public string StartTime { get; set; }
        public string StartPoint { get; set; }

        public string EndTime { get; set; }
        public string EndPoint { get; set; }

    }



    public class WorkScheduleMorningView
    {

        public string WorkSession { get; set; }
        public string TourTypeId { get; set; }
        public string TourType { get; set; }
        public string WorkTypeId { get; set; }
        public string WorkType { get; set; }
        public string DayNameValueId { get; set; }
        public string DayNameValue { get; set; }
        public string DeliveryDayNameId { get; set; }
        public string DeliveryDayName { get; set; }
        public string StartTime { get; set; }
        public string StartPoint { get; set; }

        public string EndTime { get; set; }
        public string EndPoint { get; set; }
        public string Territory { get; set; }
        public string Place { get; set; }
        public string travelById { get; set; }
        public string travelBy  { get; set; }



    }



    public class WorkScheduleEveningView
    {

        public string WorkSession { get; set; }
        public string TourTypeId { get; set; }
        public string TourType { get; set; }
        public string WorkTypeId { get; set; }
        public string WorkType { get; set; }
        public string DayNameValueId { get; set; }
        public string DayNameValue { get; set; }
        public string DeliveryDayNameId { get; set; }
        public string DeliveryDayName { get; set; }
        public string StartTime { get; set; }
        public string StartPoint { get; set; }

        public string EndTime { get; set; }
        public string EndPoint { get; set; }

        public string Territory { get; set; }
        public string Place { get; set; }
        public string travelById { get; set; }
        public string travelBy { get; set; }


    }

    public class TWWWPMorning
    { 

        public string WorkSession { get; set; }
        public string TourTypeId { get; set; }
        public string WorkTypeId { get; set; }
        public string DayNameValueId { get; set; }
        public string DeliveryDayNameId { get; set; }
        public string StartTime { get; set; }
        public string StartPoint { get; set; }

        public string EndTime { get; set; }
        public string EndPoint { get; set; }
        

         
    }


    public class Wss_Morning
    {

        public string WorkSession { get; set; }
        public string TourTypeId { get; set; }
        public string WorkTypeId { get; set; }
        public string DayNameValueId { get; set; }
        public string DeliveryDayNameId { get; set; }
        public string StartTime { get; set; }
        public string StartPoint { get; set; }

        public string EndTime { get; set; }
        public string EndPoint { get; set; }
        public string travelById { get; set; }
        public string Place { get; set; }
        public string Territory { get; set; }



    }


    public class Wss_Morning_up
    {

        public string WorkSession { get; set; }
        public string EndAddress { get; set; }
        public string DeliveryDayNameId { get; set; }
        public string EndTime { get; set; }
        public string ScheduleDate { get; set; }
        public string StartAddress { get; set; }
        public string StartTime { get; set; }
        public string TerritoryId { get; set; }

        public string TourTypeId { get; set; }
        public string WorkTypeId { get; set; }
        public string TravelBy { get; set; }
        public string DayNameValueId { get; set; }
        public string Place { get; set; }




    }

    public class Wss_Even_up
    {

        public string WorkSession { get; set; }
        public string EndAddress { get; set; }
        public string EndTime { get; set; }
        public string ScheduleDate { get; set; }
        public string StartAddress { get; set; }
        public string StartTime { get; set; }
        public string TerritoryId { get; set; }

        public string TourTypeId { get; set; }
        public string TravelBy { get; set; }
        public string Place { get; set; }



    }

    public class Wss_Evening
    {

        public string WorkSession { get; set; }
        public string TourTypeId { get; set; }
        public string WorkTypeId { get; set; }
        public string DayNameValueId { get; set; }
        public string DeliveryDayNameId { get; set; }
        public string StartTime { get; set; }
        public string StartPoint { get; set; }

        public string EndTime { get; set; }
        public string EndPoint { get; set; }
        public string travelById { get; set; }
        public string Place { get; set; }
        public string Territory { get; set; }



    }

    public class WSMorning
    { 

        public string WorkSession { get; set; }
        public string TourTypeId { get; set; }
        public string WorkTypeId { get; set; }
        public string DeliveryDayNameId { get; set; }
        public string TerritoryId { get; set; }
        public string TerritoryName { get; set; }
        public string Place { get; set; }
        public string TravelBy { get; set; }
        public string StartTime { get; set; }
        public string StartAddress { get; set; }
        public string EndTime { get; set; }
        public string EndAddress { get; set; }
        public string ScheduleDate { get; set; }

    }


    public class WSMorningView
    {

        public string WorkSession { get; set; }
        public string TourType  { get; set; }
        public string WorkType  { get; set; }
        public string DeliveryDayName  { get; set; }
   
        public string TerritoryName { get; set; }
        public string Place { get; set; }
        public string Travel  { get; set; }
        public string StartTime { get; set; }
        public string StartAddress { get; set; }
        public string EndTime { get; set; }
        public string EndAddress { get; set; }
        public string ScheduleDate { get; set; }

    }

    public class WSEveningView
    {

        public string WorkSession { get; set; }
        public string TourType { get; set; }
        public string WorkType { get; set; }
        public string DeliveryDayName { get; set; }

        public string TerritoryName { get; set; }
        public string Place { get; set; }
        public string Travel { get; set; }
        public string StartTime { get; set; }
        public string StartAddress { get; set; }
        public string EndTime { get; set; }
        public string EndAddress { get; set; }
        public string ScheduleDate { get; set; }

    }

    public class WSEvening
    {

        public string WorkSession { get; set; }
        public string TourTypeId { get; set; }
        public string WorkTypeId { get; set; }
        public string DeliveryDayNameId { get; set; }
        public string TerritoryId { get; set; }
        public string TerritoryName { get; set; }
        public string Place { get; set; }
        public string TravelBy { get; set; }
        public string StartTime { get; set; }
        public string StartAddress { get; set; }
        public string EndTime { get; set; }
        public string EndAddress { get; set; }
        public string ScheduleDate { get; set; }

    }

    public class TWWWPEvening
    {
        
        public string WorkSession { get; set; }
        public string TourTypeId { get; set; }
        public string WorkTypeId { get; set; }
        public string DayNameValueId { get; set; }
        public string DeliveryDayNameId { get; set; }
        public string StartTime { get; set; }
        public string StartPoint { get; set; }

        public string EndTime { get; set; }
        public string EndPoint { get; set; }

        public string Territory { get; set; }


        public List<WS_Travelby> Travelby { get; set; }


    }

    public class WS_Travelby
    {
        public int? empId { get; set; }

    }
        public class TourPlanInfo_Applog_DAO
    {

        public int TPMaster { get; set; }
        public int? MonthValue { get; set; }
        public int? YearValue { get; set; }
        public int? TourPlanApprovalId { get; set; }
         
        public int? EmpInfoId { get; set; }

        public string Date { get; set; }

        public int? FromEmpId { get; set; }

        public int? ToEmpId { get; set; }

        public int? TableId { get; set; }

        public string Status { get; set; }

        public string Comments { get; set; }

        public string Type { get; set; }

        public int? Step { get; set; }

        public int? GroupId { get; set; }

        public int? RegionId { get; set; }

        public int? AreaId { get; set; }

        public int? TerritoryId { get; set; }



        public int? RoleTypeId { get; set; }

        public int? ToRoleTypeId { get; set; }

        public int? MenuId { get; set; }

        public string TerritoryName { get; set; }
        public string TerritoryCode { get; set; }
        public string AreaCode { get; set; }




        public string ApprovalStatus { get; set; }
        public string EmpMasterCode { get; set; }
        public string EmpName { get; set; }



        public int MIOEmpId { get; set; }
        public int ASMEMPId { get; set; }
        public int RSMEMPId { get; set; }
        public int NSMEMPId { get; set; }
        public TourPlanMasterDAO aTourPlanMaster { get; set; }

    }




    public class Twwp_Applog_DAO
    {
        public string DayName { get; set; }
        
        public int? MonthValue { get; set; }
        public int? YearValue { get; set; }
        public int? TwwpApprovalLogId { get; set; }

        public int? EmpInfoId { get; set; }

        public string Date { get; set; }

        public int? FromEmpId { get; set; }

        public int? ToEmpId { get; set; }

        public int? TableId { get; set; }

        public string Status { get; set; }

        public string Comments { get; set; }

        public string Type { get; set; }

        public int? Step { get; set; }

        public int? GroupId { get; set; }

        public int? RegionId { get; set; }

        public int? AreaId { get; set; }

        public int? TerritoryId { get; set; }



        public int? RoleTypeId { get; set; }

        public int? ToRoleTypeId { get; set; }

        public int? MenuId { get; set; }

        public string TerritoryCode { get; set; }
        public string AreaCode { get; set; }




        public int MBEEmpId { get; set; }
        public int MIOEmpId { get; set; }
        public int ASMEMPId { get; set; }
        public int RSMEMPId { get; set; }
        public int NSMEMPId { get; set; }
 
        public TWWWPMorningView TwwpMorning_V { get; set; }
        public TWWWPEveningView TwwpEvening_V { get; set; }

    }



    public class WS_Applog_DAO
    {

        public string Empid { get; set; }
        public string masterId { get; set; }
        public string day { get; set; }
        public string date { get; set; }

        public string ApprovalStatus { get; set; }
        public string EmpMasterCode { get; set; }
        public string EmpName { get; set; }
        public string TerritoryName { get; set; }  
        public string MbeWSMasterId { get; set; }
        public string MbeWSApprovalLogId { get; set; }

        public int? MonthValue { get; set; }
        public int? YearValue { get; set; }
        public int? TwwpApprovalLogId { get; set; }

        public int? EmpInfoId { get; set; }

        public string CreateAt { get; set; }

        public int? FromEmpId { get; set; }

        public int? ToEmpId { get; set; }

        public int? TableId { get; set; }

        public string Status { get; set; }

        public string Comments { get; set; }

        public string Type { get; set; }

        public int? Step { get; set; }

        public int? GroupId { get; set; }

        public int? RegionId { get; set; }

        public int? AreaId { get; set; }

        public int? TerritoryId { get; set; }



        public int? RoleTypeId { get; set; }

        public int? ToRoleTypeId { get; set; }

        public int? MenuId { get; set; }

        public string TerritoryCode { get; set; }
        public string AreaCode { get; set; }




        public int MBEEmpId { get; set; }
        public int MIOEmpId { get; set; }
        public int ASMEMPId { get; set; }
        public int RSMEMPId { get; set; }
        public int NSMEMPId { get; set; }

        public WorkScheduleMorningView WSMorning_V { get; set; }
        public WorkScheduleEveningView WSEvening_V { get; set; }

    }

    public class TWWWP_Mas
    {

        public int TWWWPMasterId { get; set; }
        public string EmpName { get; set; }


        public string EmpMasterCode { get; set; }



        public string createAt { get; set; }
        public string ApprovalStatus { get; set; }

        public string TerritoryName { get; set; }
        

        public List<Twwp_Applog_DAO> Twwp_App { get; set; }

    }

        public class DWSP_Applog_DAO
    {

        public int DWSPMasterId { get; set; }
        public int? MonthValue { get; set; }
        public int? YearValue { get; set; }
        public int? DWSPApprovalId { get; set; }

        public int? EmpInfoId { get; set; }

        public string Date { get; set; }

        public int? FromEmpId { get; set; }

        public int? ToEmpId { get; set; }

        public int? TableId { get; set; }

        public string Status { get; set; }

        public string Comments { get; set; }

        public string Type { get; set; }

        public int? Step { get; set; }

        public int? GroupId { get; set; }

        public int? RegionId { get; set; }

        public int? AreaId { get; set; }

        public int? TerritoryId { get; set; }



        public int? RoleTypeId { get; set; }

        public int? ToRoleTypeId { get; set; }

        public int? MenuId { get; set; }

        public string TerritoryName { get; set; }
        public string TerritoryCode { get; set; }
        public string AreaCode { get; set; }




        public string ApprovalStatus { get; set; }
        public string EmpMasterCode { get; set; }
        public string EmpName { get; set; }



        public int MIOEmpId { get; set; }
        public int ASMEMPId { get; set; }
        public int RSMEMPId { get; set; }
        public int NSMEMPId { get; set; }
        public DWSPMasterDAO aDWSPMasterDAO { get; set; }

    }

    public class DoctorVisitPlan_Applog_DAO
    {

        public int DocTPMaster { get; set; }
        public int? MonthValue { get; set; }
        public int? YearValue { get; set; }
        public int? VisitPlanApprovalId { get; set; }

        public int? EmpInfoId { get; set; }

        public string Date { get; set; }

        public int? FromEmpId { get; set; }

        public int? ToEmpId { get; set; }

        public int? TableId { get; set; }

        public string Status { get; set; }

        public string Comments { get; set; }

        public string Type { get; set; }

        public int? Step { get; set; }

        public int? GroupId { get; set; }

        public int? RegionId { get; set; }

        public int? AreaId { get; set; }

        public int? TerritoryId { get; set; }



        public int? RoleTypeId { get; set; }

        public int? ToRoleTypeId { get; set; }

        public int? MenuId { get; set; }

        public string TerritoryName { get; set; }
        public string TerritoryCode { get; set; }
        public string AreaCode { get; set; }




        public string ApprovalStatus { get; set; }
        public string EmpMasterCode { get; set; }
        public string EmpName { get; set; }



        public int MIOEmpId { get; set; }
        public int ASMEMPId { get; set; }
        public int RSMEMPId { get; set; }
        public int NSMEMPId { get; set; }
        public DoctorVisitPlanMasterDAO aDoctorVisitPlanMaster { get; set; }

    }
    public class TourPlanMasterDAO
    {
        public int? TPMaster { get; set; }
        public int EmpInfoId { get; set; }
        public string MonthValue { get; set; }
        public string YearValue { get; set; }
        public string MonthName { get; set; }
     
       
        public string ApprovalStatus { get; set; }
        public string ExHQ { get; set; }
        public string  HQ { get; set; }
        public string OS { get; set; }
        public bool IsFinalSubmit { get; set; }
        public List<TourPlanDtlsDAODate> aTourPlanDate { get; set; }
     
        

    }


   

    public class DoctorVisitPlanMasterDAO
    {
        public int? DocTPMaster { get; set; }
        public int EmpInfoId { get; set; }
        public string MonthValue { get; set; }
        public string YearValue { get; set; }
        public string MonthName { get; set; }


        public string ApprovalStatus { get; set; }
        
        
        public bool IsFinalSubmit { get; set; }

        public List<dcvisDtlsDAODate> aDoctorVisitPlanDetail{ get; set; }


    }


    public class TourPlanInfoMasterDao
    {
        public int? TourPlanId { get; set; }
        public int? TPMaster { get; set; }
        public int? GroupId { get; set; }
        public int? RegionId { get; set; }
   
        public int? AreaId { get; set; }
        public int? TerritoryId { get; set; }
        public int? SubTerritoryId { get; set; }
        public int? MarketId { get; set; }
        public int? TourTypeId { get; set; }
        public int? TPId { get; set; }
        public int? EmpInfoId { get; set; }
        public string Comment { get; set; }
        public bool IsMarketWise { get; set; }
        public bool IsApproved { get; set; }
        public string GroupName { get; set; }
        public string RegionName { get; set; }
        public string AreaName { get; set; }
        public string TerritoryName { get; set; }
        public string SubTerritoryName { get; set; }
        public string MarketName { get; set; }
        public string CustomerName { get; set; }
        public string ShiftText { get; set; }
        public string TourTypeName { get; set; }
        public string TPName { get; set; }
        public string MonthValue { get; set; }
        public string YearValue { get; set; }
        public string DayValue { get; set; }
        public string TourPlanDate { get; set; }
        public string SerialNo { get; set; }
        public string IsFinalSubmit { get; set; }
        public List<CustomerDAO> aCustomerMasterList { get; set; }

    }

    public class tpStatusDAO
    {
        public int? TPMaster { get; set; }
        public string MonthValue { get; set; }
        public string YearValue { get; set; }
        public int EmpInfoId { get; set; }
        public string IsFinalSubmit { get; set; }
        public string ApprovalStatus { get; set; }
        public int ApprovedBy { get; set; }
        public string ApprovedDate { get; set; }
        public string FinalSubmitRemarks { get; set; }
        public string ApprovalRemarks { get; set; }
        
        public List<TourTypeDAO> aTourTypeDAOList { get; set; }

    }

    public class TourTypeDAO
    {
       
        public string TourTypeName { get; set; }
        public string Balance { get; set; }

    }


    public class CustomerDAO
    {
        public int CustomerMasterId { get; set; }
        public string CustomerCode { get; set; } 
        public string CustomerName { get; set; }

    }

    public class SaveTourPlan_Applog_DAO
    {
        public int? TourPlanApprovalId { get; set; }

        public DateTime? Date { get; set; }

        public int? FromEmpId { get; set; }

        public int? ToEmpId { get; set; }

        public int? TableId { get; set; }

        public string Status { get; set; }

        public string Comments { get; set; }

        public string Type { get; set; }

        public int? Step { get; set; }

        public int? GroupId { get; set; }

        public int? RegionId { get; set; }

        public int? AreaId { get; set; }

        public int? TerritoryId { get; set; }

        public int? ToGroupId { get; set; }

        public int? ToRegionId { get; set; }

        public int? ToAreaId { get; set; }

        public int? ToTerritoryId { get; set; }

        public int? EntryByS { get; set; }

        public DateTime? EntryDateS { get; set; }

        public TimeSpan? EntryTimeS { get; set; }

        public int? ApproveByS { get; set; }

        public DateTime? ApproveDateS { get; set; }

        public TimeSpan? ApproveTimeS { get; set; }

        public int? EntryByApp { get; set; }

        public DateTime? EntryDateApp { get; set; }

        public TimeSpan? EntryTimeApp { get; set; }

        public int? ApproveByApp { get; set; }

        public DateTime? ApproveDateApp { get; set; }

        public TimeSpan? ApproveTimeApp { get; set; }

        public int? RoleTypeId { get; set; }

        public int? ToRoleTypeId { get; set; }
        public int? MenuId { get; set; }

    }



    public class SaveTWWP_Applog_DAO
    {
        public int? TwwpApprovalLogId { get; set; }

        public DateTime? Date { get; set; }

        public int? FromEmpId { get; set; }

        public int? ToEmpId { get; set; }

        public int? TableId { get; set; }

        public string Status { get; set; }

        public string Comments { get; set; }

        public string Type { get; set; }

        public int? Step { get; set; }
         

        public int? RoleTypeId { get; set; }

        public int? ToRoleTypeId { get; set; }
        public int? MenuId { get; set; }

    }


    public class SaveWS_Applog_DAO
    {
        public int? MbeWSApprovalLogId { get; set; }

        public DateTime? Date { get; set; }

        public int? FromEmpId { get; set; }

        public int? ToEmpId { get; set; }

        public int? TableId { get; set; }

        public string Status { get; set; }

        public string Comments { get; set; }

        public string Type { get; set; }

        public int? Step { get; set; }


        public int? RoleTypeId { get; set; }

        public int? ToRoleTypeId { get; set; }
        public int? MenuId { get; set; }

    }

    public class SaveDWSP_Applog_DAO
    {
        public int? DWSPApprovalId { get; set; }

        public DateTime? Date { get; set; }

        public int? FromEmpId { get; set; }

        public int? ToEmpId { get; set; }

        public int? TableId { get; set; }

        public string Status { get; set; }

        public string Comments { get; set; }

        public string Type { get; set; }

        public int? Step { get; set; }

        public int? GroupId { get; set; }

        public int? RegionId { get; set; }

        public int? AreaId { get; set; }

        public int? TerritoryId { get; set; }

        public int? ToGroupId { get; set; }

        public int? ToRegionId { get; set; }

        public int? ToAreaId { get; set; }

        public int? ToTerritoryId { get; set; }

        public int? EntryByS { get; set; }

        public DateTime? EntryDateS { get; set; }

        public TimeSpan? EntryTimeS { get; set; }

        public int? ApproveByS { get; set; }

        public DateTime? ApproveDateS { get; set; }

        public TimeSpan? ApproveTimeS { get; set; }

        public int? EntryByApp { get; set; }

        public DateTime? EntryDateApp { get; set; }

        public TimeSpan? EntryTimeApp { get; set; }

        public int? ApproveByApp { get; set; }

        public DateTime? ApproveDateApp { get; set; }

        public TimeSpan? ApproveTimeApp { get; set; }

        public int? RoleTypeId { get; set; }

        public int? ToRoleTypeId { get; set; }
        public int? MenuId { get; set; }

    }
    public class SaveDoctorVisit_Applog_DAO
    {
        public int? VisitPlanApprovalId { get; set; }

        public DateTime? Date { get; set; }

        public int? FromEmpId { get; set; }

        public int? ToEmpId { get; set; }

        public int? TableId { get; set; }

        public string Status { get; set; }

        public string Comments { get; set; }

        public string Type { get; set; }

        public int? Step { get; set; }

        public int? GroupId { get; set; }

        public int? RegionId { get; set; }

        public int? AreaId { get; set; }

        public int? TerritoryId { get; set; }

        public int? ToGroupId { get; set; }

        public int? ToRegionId { get; set; }

        public int? ToAreaId { get; set; }

        public int? ToTerritoryId { get; set; }

        public int? EntryByS { get; set; }

        public DateTime? EntryDateS { get; set; }

        public TimeSpan? EntryTimeS { get; set; }

        public int? ApproveByS { get; set; }

        public DateTime? ApproveDateS { get; set; }

        public TimeSpan? ApproveTimeS { get; set; }

        public int? EntryByApp { get; set; }

        public DateTime? EntryDateApp { get; set; }

        public TimeSpan? EntryTimeApp { get; set; }

        public int? ApproveByApp { get; set; }

        public DateTime? ApproveDateApp { get; set; }

        public TimeSpan? ApproveTimeApp { get; set; }

        public int? RoleTypeId { get; set; }

        public int? ToRoleTypeId { get; set; }
        public int? MenuId { get; set; }

    }
    public class TourPlanDtlsDAO
    {
        public int CustomerMasterId { get; set; }
        public int MarketId { get; set; }
      
        public string TourPlanDate { get; set; }
        public string CustomerName { get; set; }
        public string MarketName { get; set; }
        public int TPId { get; set; }
        public string TPName { get; set; }

       
    }


    public class DWSPDtlsDAO
    {
 
      

        public string FCBAmount { get; set; }
        public string GeneralAmount { get; set; }
        public string CampaignAmount { get; set; }
      


    }
    public class TourPlanDtlsDAODate
    {
        
        public string DayValue { get; set; }
        public string DayName { get; set; }

        public List<TourPlanDtlsDAO> aTourPlanDtlsDAO { get; set; }

    }

    public class DWSPDtlsDAODate
    {

        public string DayValue { get; set; }
        public string DayName { get; set; }

        public string FCBAmount { get; set; }
        public string GeneralAmount { get; set; }
        public string CampaignAmount { get; set; }

    }
    public class VisitPlanDtlsDAO
    { 
         
        public string DoctorName { get; set; }
         


    }
    public class dcvisDtlsDAODate
    {
        public string DayValue { get; set; }
        public string DayName { get; set; }
        public string VisitPlanDate { get; set; }
        public List<VisitPlanDtlsDAO> aVisitDtlsDAO { get; set; }
         

    }
    public class DoctrVisitDtlsDAODate
    {

        public string DayValue { get; set; }
        public string DayName { get; set; }

        public List<TourPlanDtlsDAODate> aVisitPlanDtlsDAO { get; set; }

    }
    public class MessageDao
    {
        public string isSuccess { get; set; }

        public List<TourPlanInfoMasterDao> aTourPlanInfo { get; set; }
    }
}