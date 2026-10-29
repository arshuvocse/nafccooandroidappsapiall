using System;
using System.Collections.Generic;

namespace SalesSolutionWebAPI.Models
{
    public class OrderMaster
    {

        public int OrderId { get; set; }
        public int EmpId { get; set; }
        public int ComunitId { get; set; }
        public string OrderCode { get; set; }
        public string MioCode { get; set; }
        public string CustomerCode { get; set; }
        public DateTime SubmittedDate { get; set; }
        public DateTime CollectionDate { get; set; }


        public List<OrderDetails> OrderDetails { get; set; }

        public bool isSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public string IsFromCustomer { get; set; }
        public string MIOName { get; set; }
        public string CustomerName { get; set; }
        public string GrossValue { get; set; }
        public string SubmDate { get; set; }

        public int IsPending { get; set; }
        public int IsConfirm { get; set; }
        public int IsInvoiced { get; set; }
        public int IsPayment { get; set; }
        public int IsDelivered { get; set; }

        public string Remarks { get; set; }
        public string OrderType { get; set; }


    }


    public class SaveDoctorrequirementMasterDAO
    {

        public int OrderId { get; set; }
        public int DoctorId { get; set; }
        public int EmpId { get; set; }
     
      
        public DateTime SubmittedDate { get; set; }
        public DateTime CollectionDate { get; set; }


    

        

        public string Remarks { get; set; }
        public List<SaveDoctorrequirementDetailsDAO> OrderSampleDetails { get; set; }


    }

    public class Expense_List
    {
        public String date { get; set; }
        public String daAmount { get; set; }
        public String MarketTourType { get; set; }
        public String mileageAmount { get; set; }
        public String expenseAmount { get; set; }
        public String totalAmount { get; set; }
     

    }
    public class Order_List
    {
        public String GrossValue { get; set; }
        public String ApprovalStatus { get; set; }
        public String MIOName { get; set; }
        public String OrderStatus { get; set; }
        public String OrderCode { get; set; }
        public String CustomerName { get; set; }
        public int OrderId { get; set; }
        public String SubmissionDate { get; set; }
        public String OrderType { get; set; }
        public String CreatedBy { get; set; }
        public String CustomerType { get; set; }
        public string CreatedAt { get; set; }

    }

    public class CWSData
    {
        public String SN { get; set; }
        public String customer_name { get; set; }
        public String ordered_qty { get; set; }
        public String ordered_value { get; set; }
        

    }
    public class pwsDataLists
    {
        public String SN { get; set; }

        public String product_name { get; set; }
        public String order_times { get; set; }
        public String ordered_qty { get; set; }
        public String ordered_value { get; set; }


    }

    public class Total_Net_Amount
    {

        public string TotalNetAmount { get; set; }
        public List <Order_List> Order_Lists { get; set; }

    }


    public class Grand_Total
    {

        public string GrandTotal { get; set; }
        public string Allowences { get; set; }
        public List<Expense_List> Expense_Lists { get; set; }

    }

    public class CWSRDAO
    {

        public string total_qty { get; set; }
        public string total_amount { get; set; }
        public List<CWSData> cwsDataList { get; set; }

    }


    public class PWSRDAO
    {

        public string total_ot { get; set; }
        public string total_qty { get; set; }
        public string total_amount { get; set; }
        public List<pwsDataLists> pwsDataList { get; set; }

    }



    public class LvMaster
    {

    
        public List<LeaveType_List> LeaveTypeList { get; set; }
        public List<Leave_List> LeaveList { get; set; }

    }

    public class Leave_List
    {
        public String LeaveApplicationId { get; set; }

        public String UserName { get; set; }
        public String LeaveTypeName { get; set; }
        public String LeaveFromDate { get; set; }
        public String LeaveToDate { get; set; }
        public String CreatedAt { get; set; }
        public String Days { get; set; }
        public String Reason { get; set; }
        public String ApprovalStatus { get; set; }


    }

    public class LeaveType_List
    {
        public String Type { get; set; }

        public String Value { get; set; }
       


    }

    public class EmployeeWiseTotalDAO
    {

        public string TotalOrder { get; set; }
        public string totalDcr { get; set; }
        public string TotalRX { get; set; }
        

    }
    public class Order_ApplogDAO
    {

        public int OrderApprovalId { get; set; }




        public string EntryDate { get; set; }

        public int? EmpInfoId { get; set; }




        public string ApprovalStatus { get; set; }

        public int? MarketId { get; set; }




        public string MarketName { get; set; }


        public int? MenuId { get; set; }

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
        public string EmpMasterCode { get; set; }
        public string EmpName { get; set; }
        public string TerritoryName { get; set; }
        public string TerritoryCode { get; set; }
        public string AreaCode { get; set; }
        public string AreaName { get; set; }
        public string RegionCode { get; set; }
        public string RegionName { get; set; }

        public string ImageString { get; set; }

        public string ImagePreName { get; set; }


        public int MIOEmpId { get; set; }
        public int ASMEMPId { get; set; }
        public int RSMEMPId { get; set; }
        public int NSMEMPId { get; set; }
        public OrderMasterDAO aOrderMasterDAO { get; set; }
        public mCustMaster aCustMasterDAO { get; set; }
    }

    public class mCustMaster
    {
        public int CustomerMasterId { get; set; }
        public string CustomerCode { get; set; }
        public int CategoryId { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string CellNo { get; set; }
        public string Addrees2 { get; set; }
        public int MarketId { get; set; }
        
        public string City { get; set; }
        public string ConPerson { get; set; }
        public string ShippingCond { get; set; }
        public string MarketCode { get; set; }
        public string MarketName { get; set; }
    }
        public class OrderMasterDAO
    {
        public int? OrderId { get; set; }
        public string OrderCode { get; set; }
       
        public decimal TotalAmount { get; set; }

        public decimal TotalTP { get; set; }
        public decimal TotalVAT { get; set; }



         
        public List<OrderDtls> aOrderDtls { get; set; }



    }

    public class OrderDtls
    {
        public int ProductId { get; set; }
     

        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal TotalTradePrice { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalVatAmount { get; set; }
       
    }

    public class OrderSaveApprovalLogDAO
    {

        public int? OrderApprovalId { get; set; }
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
        public string EntryByS { get; set; }
        public DateTime? EntryDateS { get; set; }
        public TimeSpan? EntryTimeS { get; set; }
        public String ApproveByS { get; set; }
        public DateTime? ApproveDateS { get; set; }
        public TimeSpan? ApproveTimeS { get; set; }
        public String EntryByApp { get; set; }
        public DateTime? EntryDateApp { get; set; }
        public TimeSpan? EntryTimeApp { get; set; }
        public String ApproveByApp { get; set; }
        public DateTime? ApproveDateApp { get; set; }
        public TimeSpan? ApproveTimeApp { get; set; }
        public int? MenuId { get; set; }

    }
}