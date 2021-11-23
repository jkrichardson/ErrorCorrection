using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib;
using Dapper;
using PMI;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Packaging;



namespace ErrorCorrection
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ERRORHISTORY> err = new List<ERRORHISTORY>();
            RATES rates = new RATES();
            List<ERRORHISTORY> errout = new List<ERRORHISTORY>();
            ERRORHISTORY z = new ERRORHISTORY();
            

            Process P = new Process();


            try
            {
                err = P.GetErrors();
                foreach (ERRORHISTORY j in err)
                {
                    rates = P.GetRates(j.GroupNo, j.CoverageStatus, Convert.ToInt32(j.CovStartDate), j.TotalDeductions);
                    if (rates != null)
                    {
                        z = P.ProcessAmounts(j, rates);
                        errout.Add(z);
                    }
                }
                P.BuildExcelOutput(errout);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.HResult);
                Console.WriteLine(ex.ToString());
            }





        }       

    }

    class Process
    {
        public List<ERRORHISTORY> GetErrors()
        {
            String q = "Select * from ErrorHistory where notes = 'NOCV' and TotalDeductions > 0 ";
            List<ERRORHISTORY> err = new List<ERRORHISTORY>();
            try
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["PMI"].ConnectionString))
                {
                    conn.Open();
                    err = conn.Query<ERRORHISTORY>(q).ToList<ERRORHISTORY>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.HResult);
                Console.WriteLine(ex.ToString());
                
            }
           

            return err;

        }

        public RATES GetRates(string grp,string covstat, int startdt, decimal tot)
        {
            string q = string.Concat("Select top 1 * from GroupRates where GroupNo='",grp,"' and CoverageStatus='",covstat,"' and ", startdt,
                " between StartDate and Enddate and TotalDeductions >= ",tot,"  order by TotalDeductions");

            RATES rates = new RATES();

            try
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["PMI"].ConnectionString))
                {
                    conn.Open();
                    rates = conn.QuerySingleOrDefault<RATES>(q);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.HResult);
                Console.WriteLine(ex.ToString());
            }

            return rates;
        }

        public ERRORHISTORY ProcessAmounts(ERRORHISTORY j, RATES m)
        {
            ERRORHISTORY l = j;
            decimal temptot = j.TotalDeductions;

            try
            {
                /* MEDICAL */
                if (m.MedicalDed != 0 && temptot <= m.TotalDeductions && temptot >= m.MedicalDed)
                {
                    l.MedicalDed = m.MedicalDed;
                    temptot = temptot - m.MedicalDed;
                }
                else
                {
                    if (m.MedicalDed != 0 && temptot <= m.TotalDeductions && temptot <= m.MedicalDed)
                    {
                        l.MedicalDed = temptot;
                        temptot = 0;
                    }
                }

                /* RX */
                if (m.RXDed != 0 && temptot <= m.TotalDeductions && temptot >= m.RXDed)
                {
                    l.RXDed = m.RXDed;
                    temptot = temptot - m.RXDed;
                }
                else
                {
                    if (m.RXDed != 0 && temptot <= m.TotalDeductions && temptot <= m.RXDed)
                    {
                        l.RXDed = temptot;
                        temptot = 0;
                    }
                }

                /* DENTAL */
                if (m.DentalDed != 0 && temptot <= m.TotalDeductions && temptot >= m.DentalDed)
                {
                    l.DentalDed = m.DentalDed;
                    temptot = temptot - m.DentalDed;
                }
                else
                {
                    if (m.DentalDed != 0 && temptot <= m.TotalDeductions && temptot <= m.DentalDed)
                    {
                        l.DentalDed = temptot;
                        temptot = 0;
                    }
                }

                /* VISION */
                if (m.VisionDed != 0 && temptot <= m.TotalDeductions && temptot >= m.VisionDed)
                {
                    l.VisionDed = m.VisionDed;
                    temptot = temptot - m.VisionDed;
                }
                else
                {
                    if (m.VisionDed != 0 && temptot <= m.TotalDeductions && temptot <= m.VisionDed)
                    {
                        l.VisionDed = temptot;
                        temptot = 0;
                    }
                }

                /* LIFE */
                if (m.Lifeded != 0 && temptot <= m.TotalDeductions && temptot >= m.Lifeded)
                {
                    l.LifeDed = m.Lifeded;
                    temptot = temptot - m.Lifeded;
                }
                else
                {
                    if (m.Lifeded != 0 && temptot <= m.TotalDeductions && temptot <= m.Lifeded)
                    {
                        l.LifeDed = temptot;
                        temptot = 0;
                    }
                }

                /* STD */
                if (m.STDDed != 0 && temptot <= m.TotalDeductions && temptot >= m.STDDed)
                {
                    l.STDDed = m.STDDed;
                    temptot = temptot - m.STDDed;
                }
                else
                {
                    if (m.STDDed != 0 && temptot <= m.TotalDeductions && temptot <= m.STDDed)
                    {
                        l.STDDed = temptot;
                        temptot = 0;
                    }
                }

                /* CRITICAL ILLNESS */
                if (m.CriticalIllnessDed != 0 && temptot <= m.TotalDeductions && temptot >= m.CriticalIllnessDed)
                {
                    l.CriticalIllnessDed = m.CriticalIllnessDed;
                    temptot = temptot - m.CriticalIllnessDed;
                }
                else
                {
                    if (m.CriticalIllnessDed != 0 && temptot <= m.TotalDeductions && temptot <= m.CriticalIllnessDed)
                    {
                        l.CriticalIllnessDed = temptot;
                        temptot = 0;
                    }
                }

                /* ACCIDENT */
                if (m.AccidentDed != 0 && temptot <= m.TotalDeductions && temptot >= m.AccidentDed)
                {
                    l.AccidentDed = m.AccidentDed;
                    temptot = temptot - m.AccidentDed;
                }
                else
                {
                    if (m.AccidentDed != 0 && temptot <= m.TotalDeductions && temptot <= m.AccidentDed)
                    {
                        l.AccidentDed = temptot;
                        temptot = 0;
                    }
                }

                /* BUNDLED */
                if (m.Bundled != 0 && temptot <= m.TotalDeductions && temptot >= m.Bundled)
                {
                    l.Bundled = temptot;
                    temptot = 0;
                }
                else
                {
                    if (m.Bundled != 0 && temptot <= m.TotalDeductions && temptot <= m.Bundled)
                    {
                        l.Bundled = temptot;
                        temptot = 0;
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.HResult);
                Console.WriteLine(ex.ToString());
            }

           

            return l;
        }

        public void BuildExcelOutput(List<ERRORHISTORY> E)
        {
            var file = new FileInfo(@"\\charwood1\Websites\PMI\TEMP\ErrorTable.xlsx");
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            int i = 2;

            try
            {
                ExcelPackage pkg = new ExcelPackage(file);
                pkg.Workbook.Worksheets.Add("Errors");

                pkg = Headers(pkg);
                               
                foreach (ERRORHISTORY n in E)
                {
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 1].Value = n.ErrorNo;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 2].Value = n.SSN;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 3].Value = n.GroupNo;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 4].Value = n.LocationNo;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 5].Value = n.PRDBatchId;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 6].Value = n.ClientEmployeeId;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 7].Value = n.RIMSInternalEnrNo;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 8].Value = n.FirstName;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 9].Value = n.LastName;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 10].Value = n.MedicalDed;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 11].Value = n.DentalDed;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 12].Value = n.VisionDed;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 13].Value = n.LifeDed;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 14].Value = n.STDDed;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 15].Value = n.PRDEndDate;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 16].Value = n.EnrolleeState;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 17].Value = n.CovStartDate;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 18].Value = n.CovEndDate;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 19].Value = n.PremRecDate;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 20].Value = n.ClientDedCode;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 21].Value = n.EmployeeDedAmount;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 22].Value = n.CompanyFundedAmount;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 23].Value = n.CheckDate;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 24].Value = n.TotalDeductions;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 25].Value = n.CoverageStatus;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 26].Value = n.CovPlan;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 27].Value = n.CreationDate;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 28].Value = n.CreatedById;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 29].Value = n.BillCycleNo;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 30].Value = n.Client;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 31].Value = n.BillCycleCode;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 32].Value = n.BillingYear;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 33].Value = n.BillingMonth;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 34].Value = n.BatchSeqNo;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 35].Value = n.TransDate;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 36].Value = n.LastUpdatedByDate;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 37].Value = n.LastUpdatedById;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 38].Value = n.InstructionsToHandleError;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 39].Value = n.RecordData;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 40].Value = n.RecordsReadCount;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 41].Value = n.Status;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 42].Value = n.Source;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 43].Value = n.Server;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 44].Value = n.IpAddress;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 45].Value = n.ErrorDate;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 46].Value = n.ReceivedFileName;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 47].Value = n.ReceivedDirectory;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 48].Value = n.ErrorMessage;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 49].Value = n.ErrorType;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 50].Value = n.ErrorClass;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 51].Value = n.ErrorFunction;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 52].Value = n.Notes;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 53].Value = n.CriticalIllnessDed;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 54].Value = n.AccidentDed;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 55].Value = n.UniversalLifeDed;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 56].Value = n.WholeLifeDed;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 57].Value = n.LegalDed;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 58].Value = n.RXDed;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 59].Value = n.InHospitalDed;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 60].Value = n.AccidentalDeathDed;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 61].Value = n.NewBenefitDed;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 62].Value = n.PAIAdminFee;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 63].Value = n.ResolutionReAdminFee;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 64].Value = n.CltBenCd;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 65].Value = n.Med_EE_AgeBand;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 66].Value = n.CI_EE_AgeBand;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 67].Value = n.CI_EE_Prem;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 68].Value = n.CI_EE_Volume;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 69].Value = n.CI_SP_RiderPrem;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 70].Value = n.CI_SP_RiderVolume;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 71].Value = n.CI_CH_RiderPrem;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 72].Value = n.CI_CH_RiderVolume;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 73].Value = n.CI_EE_WellnessRider;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 74].Value = n.CI_SP_WellnessRider;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 75].Value = n.CI_CH_WellnessRider;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 76].Value = n.CI_EE_RestorationRider;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 77].Value = n.CI_SP_RestorationRider;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 78].Value = n.CI_CH_RestorationRider;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 79].Value = n.CI_EE_RecurrenceRider;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 80].Value = n.CI_SP_RecurrenceRider;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 81].Value = n.CI_CH_RecurrenceRider;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 82].Value = n.CI_SP_AgeBand;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 83].Value = n.BrokerAdminFee;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 84].Value = n.IDT911Fee;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 85].Value = n.ResolutionReAdminFeeRx;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 86].Value = n.PAIAdminFeeRx;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 87].Value = n.ACAMedFee;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 88].Value = n.Bundled;
                    pkg.Workbook.Worksheets["Errors"].Cells[i, 89].Value = n.Hearing;
                    i = i + 1;
                    
                }


                pkg.Save();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.HResult);
                Console.WriteLine(ex.ToString());
            }
           

        }

        public ExcelPackage Headers(ExcelPackage p)
        {
            
            string[] errhdr = new string[] { "ErrorNo", "SSN", "GroupNo", "LocationNo", "PRDBatchId", "ClientEmployeeId", "RIMSInternalEnrNo",
                                            "FirstName", "LastName", "MedicalDed", "DentalDed", "VisionDed", "LifeDed", "STDDed", "PRDEndDate",
                                            "EnrolleeState", "CovStartDate", "CovEndDate", "PremRecDate", "ClientDedCode", "EmployeeDedAmount",
                                            "CompanyFundedAmount", "CheckDate", "TotalDeductions", "CoverageStatus", "CovPlan", "CreationDate",
                                            "CreatedById", "BillCycleNo", "Client", "BillCycleCode", "BillingYear", "BillingMonth", "BatchSeqNo",
                                            "TransDate", "LastUpdatedByDate", "LastUpdatedById", "InstructionsToHandleError", "RecordData",
                                            "RecordsReadCount", "Status", "Source", "Server", "IpAddress", "ErrorDate", "ReceivedFileName",
                                            "ReceivedDirectory", "ErrorMessage", "ErrorType", "ErrorClass", "ErrorFunction", "Notes",
                                            "CriticalIllnessDed", "AccidentDed", "UniversalLifeDed", "WholeLifeDed", "LegalDed", "RXDed", "InHospitalDed",
                                            "AccidentalDeathDed", "NewBenefitDed", "PAIAdminFee", "ResolutionReAdminFee", "CltBenCd", "Med_EE_AgeBand",
                                            "CI_EE_AgeBand", "CI_EE_Prem", "CI_EE_Volume", "CI_SP_RiderPrem", "CI_SP_RiderVolume", "CI_CH_RiderPrem",
                                            "CI_CH_RiderVolume", "CI_EE_WellnessRider", "CI_SP_WellnessRider", "CI_CH_WellnessRider",
                                            "CI_EE_RestorationRider", "CI_SP_RestorationRider", "CI_CH_estorationRider", "CI_EE_RecurrenceRider",
                                            "CI_SP_RecurrenceRider", "CI_CH_RecurrenceRider", "CI_SP_AgeBand", "BrokerAdminFee", "IDT911Fee",
                                            "ResolutionReAdminFeeRx", "PAIAdminFeeRx", "ACAMedFee", "Bundled", "Hearing" };

            try
            {
                
                    for (int i = 0; i < errhdr.Length; i++)
                    {

                        p.Workbook.Worksheets["Errors"].Cells[1,i+1].Value = errhdr[i].ToString();
                    }
                p.Save();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.HResult);
                Console.WriteLine(ex.ToString());
            }
           
            return p;
        }
    }
}
