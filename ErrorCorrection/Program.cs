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



namespace ErrorCorrection
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ERRORHISTORY> err = new List<ERRORHISTORY>();
            List<RATES> rates = new List<RATES>();
            Process P = new Process();

            err = P.GetErrors();
            rates = P.GetRates();
        }       

    }

    class Process
    {
        public List<ERRORHISTORY> GetErrors()
        {
            String q = "Select * from ErrorHistory where notes = 'NOCV' and TotalDeductions > 0 ";
            List<ERRORHISTORY> err = new List<ERRORHISTORY>();
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["PMI"].ConnectionString))
            {
                conn.Open();
                err = conn.Query<ERRORHISTORY>(q).ToList<ERRORHISTORY>();
            }

            return err;

        }

        public List<RATES> GetRates()
        {
            string q = @"Select distinct GroupNo,CoverageStatus, MedicalDed,DentalDed,VisionDed,LifeDed,STDDed,RXDed,CriticalIllnessDed,AccidentDed,Bundled,TotalDeductions
		                            ,cast(min(CovStartDate) as int) as StartDate,cast(max(CovEndDate) as int) as EndDate 
                        from prdhistory 
                        where AdjustmentType='Deduction' 
                        group by GROUPNO,CoverageStatus, TotalDeductions,MedicalDed,DentalDed,VisionDed,LifeDed,STDDed,RXDed,CriticalIllnessDed,AccidentDed,Bundled
                        order by TotalDeductions";

            List<RATES> rates = new List<RATES>();
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["PMI"].ConnectionString))
            {
                conn.Open();
                rates = conn.Query<RATES>(q).ToList<RATES>();
            }

            return rates;
        }
    }
}
