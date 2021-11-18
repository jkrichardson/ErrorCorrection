using System;
using System.Collections.Generic;
using System.Text;
using Dapper.Contrib.Extensions;

namespace PMI
{
    /***************************************************************/
    /************************** TABLES *****************************/
    /***************************************************************/
    #region "TABLES"
    [Table("SSNChangeAudit")]
    public class SSNCHANGEAUDIT
    {
        public long ID { get; set; }
        public int OldSSN { get; set; }
        public int NewSSN { get; set; }
        public string GroupNo { get; set; }
        public int RecChanged { get; set; }
        public string TableChanged { get; set; }
        public DateTime ChangeTS { get; set; }
    }

    [Table("payrolldeduction")]
    public class PAYROLLDEDUCTION
    {
        [Key]
        public int SSN { get; set; }
        [Key]
        public string GroupNo { get; set; }
        public string LocationNo { get; set; }
        public long PRDBatchId { get; set; }
        public string ClientEmployeeId { get; set; }
        public string RIMSInternalEnrNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal? MedicalDed { get; set; }
        public decimal? DentalDed { get; set; }
        public decimal? VisionDed { get; set; }
        public decimal? LifeDed { get; set; }
        public decimal? STDDed { get; set; }
        public string PRDEndDate { get; set; }
        public string EnrolleeState { get; set; }
        [Key]
        public string CovStartDate { get; set; }
        public string CovEndDate { get; set; }
        public string PremRecDate { get; set; }
        public string BenClass { get; set; }
        public decimal? EmployeeDedAmount { get; set; }
        public decimal? CompanyFundedAmount { get; set; }
        public string CheckDate { get; set; }
        public decimal? TotalDeductions { get; set; }
        public string CoverageStatus { get; set; }
        public string CovPlan { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreatedById { get; set; }
        public string BillCycleNo { get; set; }
        public string Client { get; set; }
        public string BillCycleCode { get; set; }
        [Key]
        public string BillingYear { get; set; }
        public string BillingMonth { get; set; }
        public int? BatchSeqNo { get; set; }
        public string TransDate { get; set; }
        public DateTime? LastUpDatedByDate { get; set; }
        public string LastUpdatedById { get; set; }
        public decimal? CriticalIllnessDed { get; set; }
        public decimal? AccidentDed { get; set; }
        public decimal? UniversalLifeDed { get; set; }
        public decimal? WholeLifeDed { get; set; }
        public decimal? LegalDed { get; set; }
        public decimal? RXDed { get; set; }
        public decimal? InHospitalDed { get; set; }
        public decimal? AccidentalDeathDed { get; set; }
        public decimal? NewBenefitDed { get; set; }
        public decimal? PAIAdminFee { get; set; }
        public decimal? ResolutionReAdminFee { get; set; }
        public string Med_EE_AgeBand { get; set; }
        public string CI_EE_AgeBand { get; set; }
        public decimal? CI_EE_Prem { get; set; }
        public decimal? CI_EE_Volume { get; set; }
        public decimal? CI_SP_RiderPrem { get; set; }
        public decimal? CI_SP_RiderVolume { get; set; }
        public decimal? CI_CH_RiderPrem { get; set; }
        public decimal? CI_CH_RiderVolume { get; set; }
        public decimal? CI_EE_WellnessRider { get; set; }
        public decimal? CI_SP_WellnessRider { get; set; }
        public decimal? CI_CH_WellnessRider { get; set; }
        public decimal? CI_EE_RestorationRider { get; set; }
        public decimal? CI_SP_RestorationRider { get; set; }
        public decimal? CI_CH_RestorationRider { get; set; }
        public decimal? CI_EE_RecurrenceRider { get; set; }
        public decimal? CI_SP_RecurrenceRider { get; set; }
        public decimal? CI_CH_RecurrenceRider { get; set; }
        public string CI_SP_AgeBand { get; set; }
        public decimal? BrokerAdminFee { get; set; }
        public decimal? IDT911Fee { get; set; }
        public decimal? ResolutionReAdminFeeRx { get; set; }
        public decimal? PAIAdminFeeRx { get; set; }
        public decimal? ACAMedFee { get; set; }
        public decimal? Bundled { get; set; }
        public decimal? Hearing { get; set; }
        public long ID { get; set; }
    }

    [Table("PRDReceive")]
    public class PRDRECEIVE
    {
        [Key]
        public long PRDBatchId { get; set; }
        public string ReceivedClientData { get; set; }
        public string ReceivedDirectory { get; set; }
        public string ReceivedFileName { get; set; }
        public string IpAddress { get; set; }
        public string PremRecDate { get; set; }
        public DateTime? DatePRDSourceProcessed { get; set; }
        public DateTime? PRDProcessFinished { get; set; }
        public string CreatedById { get; set; }
        public string Client { get; set; }
        public int? RecordsReadCount { get; set; }
        public int? PossibleErrorRecordNo { get; set; }
        public int? BatchSeqNo { get; set; }
        public string Notes { get; set; }
        public decimal? BatchDeductionTotal { get; set; }
        public string CheckDate { get; set; }
        public string InvoiceSentDate { get; set; }
        public string InvoiceCheckDate { get; set; }
        public string InvoiceCovEndDate { get; set; }
        public string MAS90BatchId { get; set; }
        public int? StartAtRecordNo { get; set; }
        public string Importid { get; set; }
        public string InvoiceStatus { get; set; }
        public int? MAS90BatchNo { get; set; }
        public long FILEID { get; set; }
    }

    [Table("ErrorHistory")]
    public class ERRORHISTORY
    {
        [Key]
        public int ErrorNo { get; set; }
        public int? SSN { get; set; }
        public string GroupNo { get; set; }
        public string LocationNo { get; set; }
        public long? PRDBatchId { get; set; }
        public string ClientEmployeeId { get; set; }
        public string RIMSInternalEnrNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal? MedicalDed { get; set; }
        public decimal? DentalDed { get; set; }
        public decimal? VisionDed { get; set; }
        public decimal? LifeDed { get; set; }
        public decimal? STDDed { get; set; }
        public string PRDEndDate { get; set; }
        public string EnrolleeState { get; set; }
        public string CovStartDate { get; set; }
        public string CovEndDate { get; set; }
        public string PremRecDate { get; set; }
        public string BenClass { get; set; }
        public decimal? EmployeeDedAmount { get; set; }
        public decimal? CompanyFundedAmount { get; set; }
        public string CheckDate { get; set; }
        public decimal? TotalDeductions { get; set; }
        public string CoverageStatus { get; set; }
        public string CovPlan { get; set; }
        public DateTime? CreationDate { get; set; }
        public string CreatedById { get; set; }
        public string BillCycleNo { get; set; }
        public string Client { get; set; }
        public string BillCycleCode { get; set; }
        public string BillingYear { get; set; }
        public string BillingMonth { get; set; }
        public int? BatchSeqNo { get; set; }
        public string TransDate { get; set; }
        public DateTime? LastUpdatedByDate { get; set; }
        public string LastUpdatedById { get; set; }
        public string InstructionsToHandleError { get; set; }
        public string RecordData { get; set; }
        public int? RecordsReadCount { get; set; }
        public string Status { get; set; }
        public string Source { get; set; }
        public string Server { get; set; }
        public string IpAddress { get; set; }
        public DateTime? ErrorDate { get; set; }
        public string ReceivedFileName { get; set; }
        public string ReceivedDirectory { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorType { get; set; }
        public string ErrorClass { get; set; }
        public string ErrorFunction { get; set; }
        public string Notes { get; set; }
        public decimal? CriticalIllnessDed { get; set; }
        public decimal? AccidentDed { get; set; }
        public decimal? UniversalLifeDed { get; set; }
        public decimal? WholeLifeDed { get; set; }
        public decimal? LegalDed { get; set; }
        public decimal? RXDed { get; set; }
        public decimal? InHospitalDed { get; set; }
        public decimal? AccidentalDeathDed { get; set; }
        public decimal? NewBenefitDed { get; set; }
        public decimal? PAIAdminFee { get; set; }
        public decimal? ResolutionReAdminFee { get; set; }
        public string CltBenCd { get; set; }
        public string Med_EE_AgeBand { get; set; }
        public string CI_EE_AgeBand { get; set; }
        public decimal? CI_EE_Prem { get; set; }
        public decimal? CI_EE_Volume { get; set; }
        public decimal? CI_SP_RiderPrem { get; set; }
        public decimal? CI_SP_RiderVolume { get; set; }
        public decimal? CI_CH_RiderPrem { get; set; }
        public decimal? CI_CH_RiderVolume { get; set; }
        public decimal? CI_EE_WellnessRider { get; set; }
        public decimal? CI_SP_WellnessRider { get; set; }
        public decimal? CI_CH_WellnessRider { get; set; }
        public decimal? CI_EE_RestorationRider { get; set; }
        public decimal? CI_SP_RestorationRider { get; set; }
        public decimal? CI_CH_RestorationRider { get; set; }
        public decimal? CI_EE_RecurrenceRider { get; set; }
        public decimal? CI_SP_RecurrenceRider { get; set; }
        public decimal? CI_CH_RecurrenceRider { get; set; }
        public string CI_SP_AgeBand { get; set; }
        public decimal? BrokerAdminFee { get; set; }
        public decimal? IDT911Fee { get; set; }
        public decimal? ResolutionReAdminFeeRx { get; set; }
        public decimal? PAIAdminFeeRx { get; set; }
        public decimal? ACAMedFee { get; set; }
        public decimal? Bundled { get; set; }
        public decimal? Hearing { get; set; }
    }

    [Table("PRDHistory")]
    public class PRDHISTORY
    {
        public int SSN { get; set; }
        public string GroupNo { get; set; }
        public string LocationNo { get; set; }
        public long PRDBatchId { get; set; }
        public string ClientEmployeeId { get; set; }
        public string RIMSInternalEnrNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal? MedicalDed { get; set; }
        public decimal? DentalDed { get; set; }
        public decimal? VisionDed { get; set; }
        public decimal? LifeDed { get; set; }
        public decimal? STDDed { get; set; }
        public string PRDEndDate { get; set; }
        public string EnrolleeState { get; set; }
        public string CovStartDate { get; set; }
        public string CovEndDate { get; set; }
        public string PremRecDate { get; set; }
        public string BenClass { get; set; }
        public decimal? EmployeeDedAmount { get; set; }
        public decimal? CompanyFundedAmount { get; set; }
        public string CheckDate { get; set; }
        public decimal? TotalDeductions { get; set; }
        public string CoverageStatus { get; set; }
        public string CovPlan { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreatedById { get; set; }
        public string BillCycleNo { get; set; }
        public string Client { get; set; }
        public string BillCycleCode { get; set; }
        public string BillingYear { get; set; }
        public string BillingMonth { get; set; }
        public int? BatchSeqNo { get; set; }
        public string AdjustmentType { get; set; }
        public string ReasonCode { get; set; }
        public string Notes { get; set; }
        public string TransDate { get; set; }
        public DateTime? LastUpdatedByDate { get; set; }
        public string LastUpdatedById { get; set; }
        public long UniqueId { get; set; }
        public decimal? CriticalIllnessDed { get; set; }
        public decimal? AccidentDed { get; set; }
        public decimal? UniversalLifeDed { get; set; }
        public decimal? WholeLifeDed { get; set; }
        public decimal? LegalDed { get; set; }
        public decimal? RXDed { get; set; }
        public decimal? InHospitalDed { get; set; }
        public decimal? AccidentalDeathDed { get; set; }
        public decimal? NewBenefitDed { get; set; }
        public decimal? PAIAdminFee { get; set; }
        public decimal? ResolutionReAdminFee { get; set; }
        public string Med_EE_AgeBand { get; set; }
        public string CI_EE_AgeBand { get; set; }
        public decimal? CI_EE_Prem { get; set; }
        public decimal? CI_EE_Volume { get; set; }
        public decimal? CI_SP_RiderPrem { get; set; }
        public decimal? CI_SP_RiderVolume { get; set; }
        public decimal? CI_CH_RiderPrem { get; set; }
        public decimal? CI_CH_RiderVolume { get; set; }
        public decimal? CI_EE_WellnessRider { get; set; }
        public decimal? CI_SP_WellnessRider { get; set; }
        public decimal? CI_CH_WellnessRider { get; set; }
        public decimal? CI_EE_RestorationRider { get; set; }
        public decimal? CI_SP_RestorationRider { get; set; }
        public decimal? CI_CH_RestorationRider { get; set; }
        public decimal? CI_EE_RecurrenceRider { get; set; }
        public decimal? CI_SP_RecurrenceRider { get; set; }
        public decimal? CI_CH_RecurrenceRider { get; set; }
        public string CI_SP_AgeBand { get; set; }
        public decimal? BrokerAdminFee { get; set; }
        public decimal? IDT911Fee { get; set; }
        public decimal? ResolutionReAdminFeeRx { get; set; }
        public decimal? PAIAdminFeeRx { get; set; }
        public decimal? ACAMedFee { get; set; }
        public decimal? Bundled { get; set; }
        public decimal? Hearing { get; set; }
    }

    [Table("GroupProperties")]
    public class GROUPPROPERTIES
    {
        public long id { get; set; }
        public string GroupNo { get; set; }
        public string CovDay { get; set; }
        public int CovDayNum { get; set; }
    }

    public class RATES
    {
        public string GroupNo { get; set; }
        public string CoverageStatus { get; set; }
        public decimal MedicalDed { get; set; }
        public decimal DentalDed { get; set; }
        public decimal VisionDed { get; set; }
        public decimal Lifeded { get; set; }
        public decimal STDDed { get; set; }
        public decimal RXDed { get; set; }
        public decimal CriticalIllnessDed { get; set; }
        public decimal AccidentDed { get; set; }
        public decimal Bundled { get; set; }
        public decimal TotalDeductions { get; set; }
        public int StartDate { get; set; }
        public int EndDate { get; set; }
    }

    #endregion

    /***************************************************************/
    /************************** VIEWS ******************************/
    /***************************************************************/
    #region "VIEWS"
    public class VW_PRD_INVOICE
    {
        public int? PRDBatchId { get; set; }
        public string LocationNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? SSN { get; set; }
        public decimal? TotalDeductions { get; set; }
        public decimal? MedicalDed { get; set; }
        public decimal? DentalDed { get; set; }
        public decimal? VisionDed { get; set; }
        public decimal? LifeDed { get; set; }
        public decimal? STDDed { get; set; }
        public decimal? RXDed { get; set; }
        public decimal? Bundled { get; set; }
        public decimal? CriticalIllnessDed { get; set; }
        public decimal? AccidentDed { get; set; }
        public string CovStartDate { get; set; }
        public string CovEndDate { get; set; }
        public string Client { get; set; }
        public string GroupNo { get; set; }
        public string BillCycleCode { get; set; }
        public string PRDEndDate { get; set; }
        public decimal? EmployeeDedAmount { get; set; }
        public decimal? CompanyFundedAmount { get; set; }
        public int? BatchSeqNo { get; set; }
        public string PremRecDate { get; set; }
        public string CheckDate { get; set; }
        public string TBL { get; set; }
    }


    public class VW_PAYROLLDEDUCTION
    {
        public int SSN { get; set; }
        public string GroupNo { get; set; }
        public string LocationNo { get; set; }
        public int? PRDBatchId { get; set; }
        public string ClientEmployeeId { get; set; }
        public string RIMSInternalEnrNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal? MedicalDed { get; set; }
        public decimal? DentalDed { get; set; }
        public decimal? VisionDed { get; set; }
        public decimal? LifeDed { get; set; }
        public decimal? STDDed { get; set; }
        public string PRDEndDate { get; set; }
        public string EnrolleeState { get; set; }
        public string CovStartDate { get; set; }
        public string CovEndDate { get; set; }
        public string PremRecDate { get; set; }
        public string ClientDedCode { get; set; }
        public decimal? EmployeeDedAmount { get; set; }
        public decimal? CompanyFundedAmount { get; set; }
        public string CheckDate { get; set; }
        public decimal? TotalDeductions { get; set; }
        public string CoverageStatus { get; set; }
        public string CovPlan { get; set; }
        public DateTime? CreationDate { get; set; }
        public string CreatedById { get; set; }
        public string BillCycleNo { get; set; }
        public string Client { get; set; }
        public string BillCycleCode { get; set; }
        public string BillingYear { get; set; }
        public string BillingMonth { get; set; }
        public int? BatchSeqNo { get; set; }
        public string TransDate { get; set; }
        public DateTime? LastUpDatedByDate { get; set; }
        public string LastUpdatedById { get; set; }
        public decimal? CriticalIllnessDed { get; set; }
        public decimal? AccidentDed { get; set; }
        public decimal? UniversalLifeDed { get; set; }
        public decimal? WholeLifeDed { get; set; }
        public decimal? LegalDed { get; set; }
        public decimal? RXDed { get; set; }
        public decimal? InHospitalDed { get; set; }
        public decimal? AccidentalDeathDed { get; set; }
        public decimal? NewBenefitDed { get; set; }
        public decimal? PAIAdminFee { get; set; }
        public decimal? ResolutionReAdminFee { get; set; }
        public string Med_EE_AgeBand { get; set; }
        public string CI_EE_AgeBand { get; set; }
        public decimal? CI_EE_Prem { get; set; }
        public decimal? CI_EE_Volume { get; set; }
        public decimal? CI_SP_RiderPrem { get; set; }
        public decimal? CI_SP_RiderVolume { get; set; }
        public decimal? CI_CH_RiderPrem { get; set; }
        public decimal? CI_CH_RiderVolume { get; set; }
        public decimal? CI_EE_WellnessRider { get; set; }
        public decimal? CI_SP_WellnessRider { get; set; }
        public decimal? CI_CH_WellnessRider { get; set; }
        public decimal? CI_EE_RestorationRider { get; set; }
        public decimal? CI_SP_RestorationRider { get; set; }
        public decimal? CI_CH_RestorationRider { get; set; }
        public decimal? CI_EE_RecurrenceRider { get; set; }
        public decimal? CI_SP_RecurrenceRider { get; set; }
        public decimal? CI_CH_RecurrenceRider { get; set; }
        public string CI_SP_AgeBand { get; set; }
        public decimal? BrokerAdminFee { get; set; }
        public decimal? IDT911Fee { get; set; }
        public decimal? ResolutionReAdminFeeRx { get; set; }
        public decimal? PAIAdminFeeRx { get; set; }
        public decimal? ACAMedFee { get; set; }
        public decimal? Bundled { get; set; }
        public decimal? Hearing { get; set; }
        public string SocialSecurityNo { get; set; }
    }

    public class PRDHISTORY_SEARCH
    {
        public int SSN { get; set; }
        public string GroupNo { get; set; }
        public string LocationNo { get; set; }
        public int PRDBatchId { get; set; }
        public string ClientEmployeeId { get; set; }
        public string RIMSInternalEnrNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal? MedicalDed { get; set; }
        public decimal? DentalDed { get; set; }
        public decimal? VisionDed { get; set; }
        public decimal? LifeDed { get; set; }
        public decimal? STDDed { get; set; }
        public string PRDEndDate { get; set; }
        public string EnrolleeState { get; set; }
        public string CovStartDate { get; set; }
        public string CovEndDate { get; set; }
        public string PremRecDate { get; set; }
        public string ClientDedCode { get; set; }
        public decimal? EmployeeDedAmount { get; set; }
        public decimal? CompanyFundedAmount { get; set; }
        public string CheckDate { get; set; }
        public decimal? TotalDeductions { get; set; }
        public string CoverageStatus { get; set; }
        public string CovPlan { get; set; }
        public DateTime? CreationDate { get; set; }
        public string CreatedById { get; set; }
        public string BillCycleNo { get; set; }
        public string Client { get; set; }
        public string BillCycleCode { get; set; }
        public string BillingYear { get; set; }
        public string BillingMonth { get; set; }
        public int? BatchSeqNo { get; set; }
        public string AdjustmentType { get; set; }
        public string ReasonCode { get; set; }
        public string Notes { get; set; }
        public string TransDate { get; set; }
        public DateTime? LastUpdatedByDate { get; set; }
        public string LastUpdatedById { get; set; }
        public int UniqueId { get; set; }
        public decimal? CriticalIllnessDed { get; set; }
        public decimal? AccidentDed { get; set; }
        public decimal? UniversalLifeDed { get; set; }
        public decimal? WholeLifeDed { get; set; }
        public decimal? LegalDed { get; set; }
        public decimal? RXDed { get; set; }
        public decimal? InHospitalDed { get; set; }
        public decimal? AccidentalDeathDed { get; set; }
        public decimal? NewBenefitDed { get; set; }
        public decimal? PAIAdminFee { get; set; }
        public decimal? ResolutionReAdminFee { get; set; }
        public string Med_EE_AgeBand { get; set; }
        public string CI_EE_AgeBand { get; set; }
        public decimal? CI_EE_Prem { get; set; }
        public decimal? CI_EE_Volume { get; set; }
        public decimal? CI_SP_RiderPrem { get; set; }
        public decimal? CI_SP_RiderVolume { get; set; }
        public decimal? CI_CH_RiderPrem { get; set; }
        public decimal? CI_CH_RiderVolume { get; set; }
        public decimal? CI_EE_WellnessRider { get; set; }
        public decimal? CI_SP_WellnessRider { get; set; }
        public decimal? CI_CH_WellnessRider { get; set; }
        public decimal? CI_EE_RestorationRider { get; set; }
        public decimal? CI_SP_RestorationRider { get; set; }
        public decimal? CI_CH_RestorationRider { get; set; }
        public decimal? CI_EE_RecurrenceRider { get; set; }
        public decimal? CI_SP_RecurrenceRider { get; set; }
        public decimal? CI_CH_RecurrenceRider { get; set; }
        public string CI_SP_AgeBand { get; set; }
        public decimal? BrokerAdminFee { get; set; }
        public decimal? IDT911Fee { get; set; }
        public decimal? ResolutionReAdminFeeRx { get; set; }
        public decimal? PAIAdminFeeRx { get; set; }
    }
    #endregion

    /***************************************************************/
    /********************* Stored Procedures ***********************/
    /***************************************************************/
    #region "STORED PROCEDURES"
    public class BATCHDELETE
    {
        public long? old { get; set; }
    }

    public class CHANGEBATCHID
    {
        public long? oldbid { get; set; }
        public long? newbid { get; set; }
    }

    public class END_OF_MONTH_TOTALS
    {
        public string enddate { get; set; }
    }
        
    public class END_OF_MONTH_TRANSDATE_INSERT
    {
        public string enddate { get; set; }
    }

    public class INSERTERRORS
    {
        public string SSN { get; set; }
        public string GroupNo { get; set; }
        public string LocationNo { get; set; }
        public int? PRDBatchId { get; set; }
        public string ClientEmployeeId { get; set; }
        public string RIMSInternalEnrNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal? MedicalDed { get; set; }
        public decimal? DentalDed { get; set; }
        public decimal? VisionDed { get; set; }
        public decimal? LifeDed { get; set; }
        public decimal? STDDed { get; set; }
        public string PRDEndDate { get; set; }
        public string EnrolleeState { get; set; }
        public string CovStartDate { get; set; }
        public string CovEndDate { get; set; }
        public string PremRecDate { get; set; }
        public string ClientDedCode { get; set; }
        public decimal? EmployeeDedAmount { get; set; }
        public decimal? CompanyFundedAmount { get; set; }
        public string CheckDate { get; set; }
        public decimal? TotalDeductions { get; set; }
        public string CoverageStatus { get; set; }
        public string CovPlan { get; set; }
        public string CreatedById { get; set; }
        public string BillCycleNo { get; set; }
        public string Client { get; set; }
        public string BillCycleCode { get; set; }
        public string BillingYear { get; set; }
        public string BillingMonth { get; set; }
        public int? BatchSeqNo { get; set; }
        public string TransDate { get; set; }
        public string LastUpdatedById { get; set; }
        public string InstructionsToHandleError { get; set; }
        public string RecordData { get; set; }
        public int? RecordsReadCount { get; set; }
        public string Status { get; set; }
        public string Source { get; set; }
        public string Server { get; set; }
        public string IpAddress { get; set; }
        public string ReceivedFileName { get; set; }
        public string ReceivedDirectory { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorType { get; set; }
        public string ErrorClass { get; set; }
        public string ErrorFunction { get; set; }
        public string Notes { get; set; }
        public decimal? CriticalIllnessDed { get; set; }
        public decimal? AccidentDed { get; set; }
        public decimal? UniversalLifeDed { get; set; }
        public decimal? WholeLifeDed { get; set; }
        public decimal? LegalDed { get; set; }
        public decimal? RXDed { get; set; }
        public decimal? InHospitalDed { get; set; }
        public decimal? AccidentalDeathDed { get; set; }
        public decimal? NewBenefitDed { get; set; }
        public decimal? PAIAdminFee { get; set; }
        public decimal? ResolutionReAdminFee { get; set; }
        public string CltBenCd { get; set; }
        public string Med_EE_AgeBand { get; set; }
        public string CI_EE_AgeBand { get; set; }
        public decimal? CI_EE_Prem { get; set; }
        public decimal? CI_EE_Volume { get; set; }
        public decimal? CI_SP_RiderPrem { get; set; }
        public decimal? CI_SP_RiderVolume { get; set; }
        public decimal? CI_CH_RiderPrem { get; set; }
        public decimal? CI_CH_RiderVolume { get; set; }
        public decimal? CI_EE_WellnessRider { get; set; }
        public decimal? CI_SP_WellnessRider { get; set; }
        public decimal? CI_CH_WellnessRider { get; set; }
        public decimal? CI_EE_RestorationRider { get; set; }
        public decimal? CI_SP_RestorationRider { get; set; }
        public decimal? CI_CH_RestorationRider { get; set; }
        public decimal? CI_EE_RecurrenceRider { get; set; }
        public decimal? CI_SP_RecurrenceRider { get; set; }
        public decimal? CI_CH_RecurrenceRider { get; set; }
        public string CI_SP_AgeBand { get; set; }
        public decimal? BrokerAdminFee { get; set; }
        public decimal? IDT911Fee { get; set; }
        public decimal? ResolutionReAdminFeeRx { get; set; }
        public decimal? PAIAdminFeeRx { get; set; }
        public decimal? ACAMedFee { get; set; }
        public decimal? Bundled { get; set; }
        public decimal? Hearing { get; set; }
    }

    public class INSERTPAYROLLDEDUCTION
    {
        public string SSN { get; set; }
        public string GroupNo { get; set; }
        public string LocationNo { get; set; }
        public int? PRDBatchId { get; set; }
        public string ClientEmployeeId { get; set; }
        public string RIMSInternalEnrNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal? MedicalDed { get; set; }
        public decimal? DentalDed { get; set; }
        public decimal? VisionDed { get; set; }
        public decimal? LifeDed { get; set; }
        public decimal? STDDed { get; set; }
        public string PRDEndDate { get; set; }
        public string EnrolleeState { get; set; }
        public string CovStartDate { get; set; }
        public string CovEndDate { get; set; }
        public string PremRecDate { get; set; }
        public string ClientDedCode { get; set; }
        public decimal? EmployeeDedAmount { get; set; }
        public decimal? CompanyFundedAmount { get; set; }
        public string CheckDate { get; set; }
        public decimal? TotalDeductions { get; set; }
        public string CoverageStatus { get; set; }
        public string CovPlan { get; set; }
        public string CreatedById { get; set; }
        public string BillCycleNo { get; set; }
        public string Client { get; set; }
        public string BillCycleCode { get; set; }
        public string BillingYear { get; set; }
        public string BillingMonth { get; set; }
        public int? BatchSeqNo { get; set; }
        public string TransDate { get; set; }
        public string LastUpdatedById { get; set; }
        public decimal? CriticalIllnessDed { get; set; }
        public decimal? AccidentDed { get; set; }
        public decimal? UniversalLifeDed { get; set; }
        public decimal? WholeLifeDed { get; set; }
        public decimal? LegalDed { get; set; }
        public decimal? RXDed { get; set; }
        public decimal? InHospitalDed { get; set; }
        public decimal? AccidentalDeathDed { get; set; }
        public decimal? NewBenefitDed { get; set; }
        public decimal? PAIAdminFee { get; set; }
        public decimal? ResolutionReAdminFee { get; set; }
        public string Med_EE_AgeBand { get; set; }
        public string CI_EE_AgeBand { get; set; }
        public decimal? CI_EE_Prem { get; set; }
        public decimal? CI_EE_Volume { get; set; }
        public decimal? CI_SP_RiderPrem { get; set; }
        public decimal? CI_SP_RiderVolume { get; set; }
        public decimal? CI_CH_RiderPrem { get; set; }
        public decimal? CI_CH_RiderVolume { get; set; }
        public decimal? CI_EE_WellnessRider { get; set; }
        public decimal? CI_SP_WellnessRider { get; set; }
        public decimal? CI_CH_WellnessRider { get; set; }
        public decimal? CI_EE_RestorationRider { get; set; }
        public decimal? CI_SP_RestorationRider { get; set; }
        public decimal? CI_CH_RestorationRider { get; set; }
        public decimal? CI_EE_RecurrenceRider { get; set; }
        public decimal? CI_SP_RecurrenceRider { get; set; }
        public decimal? CI_CH_RecurrenceRider { get; set; }
        public string CI_SP_AgeBand { get; set; }
        public decimal? BrokerAdminFee { get; set; }
        public decimal? IDT911Fee { get; set; }
        public decimal? ResolutionReAdminFeeRx { get; set; }
        public decimal? PAIAdminFeeRx { get; set; }
        public decimal? ACAMedFee { get; set; }
        public decimal? Bundled { get; set; }
        public decimal? Hearing { get; set; }
        public int? FileRecCount { get; set; }
    }

    public class INSERTPRDHISTORY
    {
        public string SSN { get; set; }
        public string GroupNo { get; set; }
        public string LocationNo { get; set; }
        public int? PRDBatchId { get; set; }
        public string ClientEmployeeId { get; set; }
        public string RIMSInternalEnrNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal? MedicalDed { get; set; }
        public decimal? DentalDed { get; set; }
        public decimal? VisionDed { get; set; }
        public decimal? LifeDed { get; set; }
        public decimal? STDDed { get; set; }
        public string PRDEndDate { get; set; }
        public string EnrolleeState { get; set; }
        public string CovStartDate { get; set; }
        public string CovEndDate { get; set; }
        public string PremRecDate { get; set; }
        public string ClientDedCode { get; set; }
        public decimal? EmployeeDedAmount { get; set; }
        public decimal? CompanyFundedAmount { get; set; }
        public string CheckDate { get; set; }
        public decimal? TotalDeductions { get; set; }
        public string CoverageStatus { get; set; }
        public string CovPlan { get; set; }
        public string CreatedById { get; set; }
        public string BillCycleNo { get; set; }
        public string Client { get; set; }
        public string BillCycleCode { get; set; }
        public string BillingYear { get; set; }
        public string BillingMonth { get; set; }
        public int? BatchSeqNo { get; set; }
        public string AdjustmentType { get; set; }
        public string ReasonCode { get; set; }
        public string Notes { get; set; }
        public string TransDate { get; set; }
        public string LastUpdatedById { get; set; }
        public decimal? CriticalIllnessDed { get; set; }
        public decimal? AccidentDed { get; set; }
        public decimal? UniversalLifeDed { get; set; }
        public decimal? WholeLifeDed { get; set; }
        public decimal? LegalDed { get; set; }
        public decimal? RXDed { get; set; }
        public decimal? InHospitalDed { get; set; }
        public decimal? AccidentalDeathDed { get; set; }
        public decimal? NewBenefitDed { get; set; }
        public decimal? PAIAdminFee { get; set; }
        public decimal? ResolutionReAdminFee { get; set; }
        public string Med_EE_AgeBand { get; set; }
        public string CI_EE_AgeBand { get; set; }
        public decimal? CI_EE_Prem { get; set; }
        public decimal? CI_EE_Volume { get; set; }
        public decimal? CI_SP_RiderPrem { get; set; }
        public decimal? CI_SP_RiderVolume { get; set; }
        public decimal? CI_CH_RiderPrem { get; set; }
        public decimal? CI_CH_RiderVolume { get; set; }
        public decimal? CI_EE_WellnessRider { get; set; }
        public decimal? CI_SP_WellnessRider { get; set; }
        public decimal? CI_CH_WellnessRider { get; set; }
        public decimal? CI_EE_RestorationRider { get; set; }
        public decimal? CI_SP_RestorationRider { get; set; }
        public decimal? CI_CH_RestorationRider { get; set; }
        public decimal? CI_EE_RecurrenceRider { get; set; }
        public decimal? CI_SP_RecurrenceRider { get; set; }
        public decimal? CI_CH_RecurrenceRider { get; set; }
        public string CI_SP_AgeBand { get; set; }
        public decimal? BrokerAdminFee { get; set; }
        public decimal? IDT911Fee { get; set; }
        public decimal? ResolutionReAdminFeeRx { get; set; }
        public decimal? PAIAdminFeeRx { get; set; }
        public decimal? ACAMedFee { get; set; }
        public decimal? Bundled { get; set; }
        public decimal? Hearing { get; set; }
    }

    public class INSERTPRDRECEIVE
    {
        public int? PRDBatchId { get; set; }
        public string ReceivedClientData { get; set; }
        public string ReceivedDirectory { get; set; }
        public string ReceivedFileName { get; set; }
        public string IpAddress { get; set; }
        public string CreatedById { get; set; }
        public string Client { get; set; }
        public int? RecordsReadCount { get; set; }
        public int? PossibleErrorRecordNo { get; set; }
        public int? BatchSeqNo { get; set; }
        public string Notes { get; set; }
        public decimal? BatchDeductionTotal { get; set; }
        public string CheckDate { get; set; }
        public string InvoiceSentDate { get; set; }
        public string InvoiceCheckDate { get; set; }
        public string InvoiceCovEndDate { get; set; }
        public string MAS90BatchId { get; set; }
        public int? ImportNo { get; set; }
        public string ImportId { get; set; }
        public string InvoiceStatus { get; set; }
        public int? MAS90BatchNo { get; set; }
    }

    #endregion

    /***************************************************************/
    /********************* Misc PMI Process ************************/
    /***************************************************************/
    #region "PMI PROCESSES"

   


    
    #endregion

    /***************************************************************/
    /*********************** Quick Link ****************************/
    /***************************************************************/
    public class QLINFO
    {
        public int eenmbr { get; set; }
        public string eegpno { get; set; }
        public int eessno { get; set; }
        public string eefnam { get; set; }
        public string eelname { get; set; }
        public string eeloca { get; set; }
        public string eeplan { get; set; }
        public string eecvst { get; set; }
        public string eeitdt { get; set; }
        public string eeftdt { get; set; }
        public string eeembc { get; set; }
    }

   
    

}
